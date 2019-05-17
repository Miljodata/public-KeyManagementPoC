using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Script.Serialization;

namespace KeyManagementPoC.Clients
{
	internal class VaultClient
	{
		internal X509Certificate2 ClientCert;
		internal string AuthToken;
		internal const string RestApiUrl = "https://keymanager.fictive.ab:8200";
		internal JavaScriptSerializer JsonSerializer;

		internal VaultClient()
		{
			// Used to allow self signed certificate, should not be used in production.
			ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

			ClientCert = GetAuthCertificate("ClientCert");
			JsonSerializer = new JavaScriptSerializer();

			Authenticate();
		}

		internal string GetKey(string keyId)
		{
			string response = Connect("/v1/secret/" + keyId);
			var jsonObj = JsonSerializer.Deserialize<dynamic>(response);
			return jsonObj["data"]["key"] ?? string.Empty;
		}

		internal void Authenticate()
		{
			string response = Connect("/v1/auth/cert/login", "POST", "{\"name\": \"prod\"}", true);
			var jsonObj = JsonSerializer.Deserialize<dynamic>(response);

			AuthToken = jsonObj["auth"]["client_token"] ?? string.Empty;
		}

		internal string Connect(string endpoint, string method = "GET", string data = "", bool useCert = false)
		{
			var request = (HttpWebRequest)WebRequest.Create(RestApiUrl + endpoint);

			if (useCert)
			{
				request.ClientCertificates = new X509Certificate2Collection(ClientCert);
			}
			else
			{
				request.Headers.Add("X-Vault-Token", AuthToken);
			}

			if (method != "GET")
			{
				request.Method = method;
				request.ContentType = "application/x-www-form-urlencoded";
				request.ContentLength = data.Length;

				using (var stream = request.GetRequestStream())
				{
					stream.Write(Encoding.ASCII.GetBytes(data), 0, data.Length);
				}
			}

			var response = (HttpWebResponse)request.GetResponse();

			using (var reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException(), Encoding.ASCII))
			{
				return reader.ReadToEnd();
			}
		}

		internal X509Certificate2 GetAuthCertificate(string id)
		{
			var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
			store.Open(OpenFlags.ReadOnly);

			string certificateThumbprint = ConfigurationManager.AppSettings[id];
			X509Certificate2 foundCertificate = null;

			foreach (X509Certificate2 searchCertificate in store.Certificates)
			{
				if (searchCertificate.Thumbprint == null || !searchCertificate.Thumbprint.ToUpper().Equals(certificateThumbprint.ToUpper())) continue;
				foundCertificate = searchCertificate;
				break;
			}

			if (foundCertificate == null)
			{
				throw new InvalidOperationException("Could not retreive certificate with thumbprint " + certificateThumbprint);
			}

			return foundCertificate;
		}
	}
}
