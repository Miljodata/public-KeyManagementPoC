using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Script.Serialization;

namespace KeyManagementPoC.Clients
{
	internal class KeywhizClient
	{
		internal X509Certificate2 ClientCert;
		internal const string RestApiUrl = "https://keymanager.fictive.ab:4444";
		internal JavaScriptSerializer JsonSerializer;

		internal KeywhizClient()
		{
			// Used to allow self signed certificate, should not be used in production.
			ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

			ClientCert = GetAuthCertificate("KeywhizClientCert");
			JsonSerializer = new JavaScriptSerializer();
		}

		internal string GetKey(string keyId)
		{
			string response = Connect("/automation/secrets?name=" + keyId);
			var jsonObj = JsonSerializer.Deserialize<dynamic>(response);

			return Encoding.UTF8.GetString(Convert.FromBase64String(jsonObj[0]["secret"] ?? string.Empty));
		}

		internal string Connect(string endpoint)
		{
			var request = (HttpWebRequest)WebRequest.Create(RestApiUrl + endpoint);
			request.ClientCertificates = new X509Certificate2Collection(ClientCert);

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
