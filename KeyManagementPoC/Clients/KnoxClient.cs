using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Script.Serialization;

namespace KeyManagementPoC.Clients
{
	internal class KnoxClient
	{
		internal X509Certificate2 ClientCert;
		internal string CommonName;
		internal const string RestApiUrl = "https://keymanager.fictive.ab:9000";
		internal JavaScriptSerializer JsonSerializer;

		internal KnoxClient()
		{
			ClientCert = GetAuthCertificate("ClientCert");
			CommonName = ClientCert.Subject.Split(',')[0].Split(new string[] { "CN=" }, StringSplitOptions.None)[1];
			JsonSerializer = new JavaScriptSerializer();

			// Used to allow self signed certificate, should not be used in production.
			ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
		}

		internal string GetKey(string keyId)
		{
			string response = Connect("/v0/keys/" + keyId + "/");
			var jsonObj = JsonSerializer.Deserialize<dynamic>(response);

			if (jsonObj["code"] != 0)
			{
				throw new Exception("Could not get key. Error: " + jsonObj["message"]);
			}

			foreach (dynamic keyVersion in jsonObj["data"]["versions"])
			{
				if (keyVersion["status"] == "Primary")
				{
					return Encoding.UTF8.GetString(Convert.FromBase64String(keyVersion["data"]));
				}
			}

			return string.Empty;
		}

		internal string Connect(string endpoint)
		{
			ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
			var request = (HttpWebRequest)WebRequest.Create(RestApiUrl + endpoint);
			request.ClientCertificates = new X509Certificate2Collection(ClientCert);

			request.Headers.Add("Authorization", "0t" + CommonName);

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
