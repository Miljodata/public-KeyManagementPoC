using System;
using System.Configuration;
using KeyManagementPoC.Interfaces;

namespace KeyManagementPoC
{
	internal class KeyManager : IKeyManager
	{
		internal IKeyManager ActualKeyManager;

		internal KeyManager()
		{
			string currentKeyManagementSystem = ConfigurationManager.AppSettings["currentKeyManagementSystem"];

			switch (currentKeyManagementSystem)
			{
				case "simple":
					ActualKeyManager = new SimpleKeyManager();
					break;
				case "knox":
					ActualKeyManager = new KnoxKeyManager();
					break;
				case "vault":
					ActualKeyManager = new VaultKeyManager();
					break;
				case "keywhiz":
					ActualKeyManager = new KeywhizKeyManager();
					break;
				case "barbican":
					ActualKeyManager = new BarbicanKeyManager();
					break;
				case "conjur":
					ActualKeyManager = new ConjurKeyManager();
					break;
				default:
					throw new NotImplementedException();
			}
		}

		public string GetKey(string id, string type)
		{
			return ActualKeyManager.GetKey(id, type);
		}
	}
}
