using System;
using System.IO;
using System.Net;
using System.Text;

namespace KeyManagementPoC.Clients
{
	internal class BarbicanClient
	{
		internal string AuthToken;
		internal const string RestApiUrl = "http://keymanager.fictive.ab";

		internal BarbicanClient()
		{
			Authenticate();
		}

		internal string GetKey(string keyId)
		{
			return Connect(":9311/v1/secrets/" + keyId + "/payload", "GET", "", true);
		}

		internal void Authenticate()
		{
			AuthToken = Connect("/identity/v3/auth/tokens", "POST", "{\"auth\":{\"identity\":{\"methods\":[\"password\"],\"password\":{\"user\":{\"name\":\"barbican\",\"domain\":{\"name\":\"default\"},\"password\":\"secret\"}}}}}", false, true);
		}

		internal string Connect(string endpoint, string method = "GET", string data = "", bool useToken = false, bool getHeader = false)
		{
			var request = (HttpWebRequest)WebRequest.Create(RestApiUrl + endpoint);

			if (useToken)
			{
				request.Headers.Add("X-Auth-Token", AuthToken);
				request.Accept = "text/plain";

			}

			if (method != "GET")
			{
				request.Method = method;
				request.ContentType = "application/json";
				request.ContentLength = data.Length;

				using (var stream = request.GetRequestStream())
				{
					stream.Write(Encoding.ASCII.GetBytes(data), 0, data.Length);
				}
			}

			var response = (HttpWebResponse)request.GetResponse();

			if (getHeader)
			{
				return response.Headers.GetValues("X-Subject-Token")?[0] ?? throw new InvalidOperationException();
			}

			using (var reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException(), Encoding.ASCII))
			{
				return reader.ReadToEnd();
			}
		}
	}
}
