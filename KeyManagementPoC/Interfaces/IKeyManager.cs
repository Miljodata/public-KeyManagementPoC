using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using KeyManagementPoC.Clients;

namespace KeyManagementPoC.Interfaces
{
	internal interface IKeyManager
	{
		string GetKey(string id, string type);
	}

	internal class SimpleKeyManager : IKeyManager
	{
		public string GetKey(string id, string type)
		{
			switch (type)
			{
				case "database":
					return ConfigurationManager.AppSettings[id];

				case "api":
					return ConfigurationManager.AppSettings[id];

				case "publickey":
					return ConfigurationManager.AppSettings[id];

				case "privatekey":
					return ConfigurationManager.AppSettings[id];

				case "secretkey":
					return ConfigurationManager.AppSettings[id];

				case "certificate":
					var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
					store.Open(OpenFlags.ReadOnly);

					string certificateThumbprint = id;
					X509Certificate2 foundCertificate = null;

					foreach (X509Certificate2 searchCertificate in store.Certificates)
					{
						if (searchCertificate.Thumbprint == null || !searchCertificate.Thumbprint.ToUpper().Equals(certificateThumbprint.ToUpper())) continue;
						foundCertificate = searchCertificate;
						break;
					}

					if (foundCertificate == null)
					{
						throw new InvalidOperationException();
					}

					return Convert.ToBase64String(foundCertificate.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks);

				default:
					throw new NotImplementedException();
			}
		}
	}

	internal class KnoxKeyManager : IKeyManager
	{
		internal KnoxClient Client;

		internal KnoxKeyManager()
		{
			Client = new KnoxClient();
		}

		public string GetKey(string id, string type)
		{
			switch (type)
			{
				case "database":
					return Client.GetKey(id);

				case "api":
					return Client.GetKey(id);

				case "publickey":
					return Client.GetKey(id);

				case "privatekey":
					return Client.GetKey(id);

				case "secretkey":
					return Client.GetKey(id);

				case "certificate":
					return Client.GetKey(id);

				default:
					throw new NotImplementedException();
			}
		}
	}

	internal class VaultKeyManager : IKeyManager
	{
		internal VaultClient Client;

		internal VaultKeyManager()
		{
			Client = new VaultClient();
		}

		public string GetKey(string id, string type)
		{
			switch (type)
			{
				case "database":
					return Client.GetKey(id);

				case "api":
					return Client.GetKey(id);

				case "publickey":
					return Client.GetKey(id);

				case "privatekey":
					return Client.GetKey(id);

				case "secretkey":
					return Client.GetKey(id);

				case "certificate":
					return Client.GetKey(id);

				default:
					throw new NotImplementedException();
			}
		}
	}

	internal class KeywhizKeyManager : IKeyManager
	{
		internal KeywhizClient Client;

		internal KeywhizKeyManager()
		{
			Client = new KeywhizClient();
		}

		public string GetKey(string id, string type)
		{
			switch (type)
			{
				case "database":
					return Client.GetKey(id);

				case "api":
					return Client.GetKey(id);

				case "publickey":
					return Client.GetKey(id);

				case "privatekey":
					return Client.GetKey(id);

				case "secretkey":
					return Client.GetKey(id);

				case "certificate":
					return Client.GetKey(id);

				default:
					throw new NotImplementedException();
			}
		}
	}

	internal class BarbicanKeyManager : IKeyManager
	{
		internal BarbicanClient Client;

		internal BarbicanKeyManager()
		{
			Client = new BarbicanClient();
		}

		public string GetKey(string id, string type)
		{
			switch (type)
			{
				case "database":
					return Client.GetKey("08f73403-3cda-4f36-b8bb-6a10620747ec");

				case "api":
					return Client.GetKey("a6c22dbe-4d3d-43f8-8298-307e44896526");

				case "publickey":
					return Client.GetKey("872e494b-b3f0-4e3b-b192-f98cc6c5c695");

				case "privatekey":
					return Client.GetKey("e7ade0ec-d8a2-4b4f-8497-255622591710");

				case "secretkey":
					return Client.GetKey("f5fb6d1a-ef26-4f1f-92e0-7cdcfc27c406");

				case "certificate":
					return Client.GetKey("b8290a4a-f495-4477-9b42-edbde79000fb");

				default:
					throw new NotImplementedException();
			}
		}
	}

	internal class ConjurKeyManager : IKeyManager
	{
		internal ConjurClient Client;

		internal ConjurKeyManager()
		{
			Client = new ConjurClient();
		}

		public string GetKey(string id, string type)
		{
			switch (type)
			{
				case "database":
					return Client.GetKey(id);

				case "api":
					return Client.GetKey(id);

				case "publickey":
					return Client.GetKey(id);

				case "privatekey":
					return Client.GetKey(id);

				case "secretkey":
					return Client.GetKey(id);

				case "certificate":
					return Client.GetKey(id);

				default:
					throw new NotImplementedException();
			}
		}
	}
}
