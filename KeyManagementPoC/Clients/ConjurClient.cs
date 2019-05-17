using System;
using System.IO;
using System.Net;
using System.Web;
using System.Text;

namespace KeyManagementPoC.Clients
{
	internal class ConjurClient
	{
		internal string AuthToken;
		internal const string RestApiUrl = "https://keymanager.fictive.ab:8443";

		internal ConjurClient()
		{
			// Used to allow self signed certificate, should not be used in production.
			ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

			Authenticate();
		}

		internal string GetKey(string keyId)
		{
			return Connect($"/secrets/test/variable/{keyId}/password");
		}

		internal void Authenticate()
		{
			string response = Connect("/authn/test/host%2Ftestproject%2Ftestproject/authenticate", "POST", "1mne6762xf8txh2z118y72gapq5w1zdbzs12x4h84cq7dagse331f5");

			AuthToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(response ?? string.Empty));
		}

		internal string Connect(string endpoint, string method = "GET", string data = "")
		{
			var request = (HttpWebRequest)WebRequest.Create(RestApiUrl + endpoint);

			request.Headers.Add("Authorization", $"Token token=\"{AuthToken}\"");

			if (method != "GET")
			{
				request.Method = method;

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
	}
}
