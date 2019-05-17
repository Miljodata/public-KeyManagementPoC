using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using KeyManagementPoC;

namespace UnitTests
{
	[TestFixture]
	public class GetKeyTests
	{
		[Test]
		public void Pass_type_database_should_get_database_key()
		{
			var kms = new KeyManager();
			Assert.That(kms.GetKey("ConnectionString", "database"), Is.EqualTo("ThisIsADatabaseConnectionString"));
		}

		[Test]
		public void Pass_type_api_should_get_api_key()
		{
			var kms = new KeyManager();
			Assert.That(kms.GetKey("APIKey", "api"), Is.EqualTo("ThisIsAAPIKey"));
		}

		[Test]
		public void Pass_type_public_should_get_public_key()
		{
			var kms = new KeyManager();
			Assert.That(kms.GetKey("AppLevelEncryptionKey", "publickey"), Is.EqualTo("ThisIsAPublicKey"));
		}

		[Test]
		public void Pass_type_private_should_get_private_key()
		{
			var kms = new KeyManager();
			Assert.That(kms.GetKey("AppLevelDecryptionKey", "privatekey"), Is.EqualTo("ThisIsAPrivateKey"));
		}

		[Test]
		public void Pass_type_private_should_get_secret_key()
		{
			var kms = new KeyManager();
			Assert.That(kms.GetKey("Password", "secretkey"), Is.EqualTo("ThisIsAPassword"));
		}

		[Test]
		public void Pass_type_certificate_should_get_private_key()
		{
			var kms = new KeyManager();
			var returvarde = kms.GetKey(ConfigurationManager.AppSettings["CertificateThumbprint"], "certificate");
			var cert = new X509Certificate2(Convert.FromBase64String(returvarde));
			Assert.That(cert.Thumbprint, Is.EqualTo("18fe3e715ced5e5f4dacfea66ab6f90a7e400d40".ToUpper()));
		}
	}
}
