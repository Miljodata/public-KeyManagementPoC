using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace KeyManagementPoC
{
	public class ApiDatabasePrivatePublicCertificate
	{
		private KeyManager kms = new KeyManager();

		[Benchmark]
		public string Database0() => kms.GetKey("ConnectionString", "database");
		[Benchmark]
		public string Database1() => kms.GetKey("ConnectionString", "database");
		[Benchmark]
		public string Database2() => kms.GetKey("ConnectionString", "database");
		[Benchmark]
		public string Database3() => kms.GetKey("ConnectionString", "database");
		[Benchmark]
		public string Database4() => kms.GetKey("ConnectionString", "database");
		[Benchmark]
		public string Database5() => kms.GetKey("ConnectionString", "database");
		[Benchmark]
		public string Database6() => kms.GetKey("ConnectionString", "database");
		[Benchmark]
		public string Database7() => kms.GetKey("ConnectionString", "database");
		[Benchmark]
		public string Database8() => kms.GetKey("ConnectionString", "database");
		[Benchmark]
		public string Database9() => kms.GetKey("ConnectionString", "database");

		[Benchmark]
		public string Api0() => kms.GetKey("APIKey", "api");
		[Benchmark]
		public string Api1() => kms.GetKey("APIKey", "api");
		[Benchmark]
		public string Api2() => kms.GetKey("APIKey", "api");
		[Benchmark]
		public string Api3() => kms.GetKey("APIKey", "api");
		[Benchmark]
		public string Api4() => kms.GetKey("APIKey", "api");
		[Benchmark]
		public string Api5() => kms.GetKey("APIKey", "api");
		[Benchmark]
		public string Api6() => kms.GetKey("APIKey", "api");
		[Benchmark]
		public string Api7() => kms.GetKey("APIKey", "api");
		[Benchmark]
		public string Api8() => kms.GetKey("APIKey", "api");
		[Benchmark]
		public string Api9() => kms.GetKey("APIKey", "api");

		[Benchmark]
		public string Private0() => kms.GetKey("AppLevelDecryptionKey", "privatekey");
		[Benchmark]
		public string Private1() => kms.GetKey("AppLevelDecryptionKey", "privatekey");
		[Benchmark]
		public string Private2() => kms.GetKey("AppLevelDecryptionKey", "privatekey");
		[Benchmark]
		public string Private3() => kms.GetKey("AppLevelDecryptionKey", "privatekey");
		[Benchmark]
		public string Private4() => kms.GetKey("AppLevelDecryptionKey", "privatekey");
		[Benchmark]
		public string Private5() => kms.GetKey("AppLevelDecryptionKey", "privatekey");
		[Benchmark]
		public string Private6() => kms.GetKey("AppLevelDecryptionKey", "privatekey");
		[Benchmark]
		public string Private7() => kms.GetKey("AppLevelDecryptionKey", "privatekey");
		[Benchmark]
		public string Private8() => kms.GetKey("AppLevelDecryptionKey", "privatekey");
		[Benchmark]
		public string Private9() => kms.GetKey("AppLevelDecryptionKey", "privatekey");

		[Benchmark]
		public string Public0() => kms.GetKey("AppLevelEncryptionKey", "publickey");
		[Benchmark]
		public string Public1() => kms.GetKey("AppLevelEncryptionKey", "publickey");
		[Benchmark]
		public string Public2() => kms.GetKey("AppLevelEncryptionKey", "publickey");
		[Benchmark]
		public string Public3() => kms.GetKey("AppLevelEncryptionKey", "publickey");
		[Benchmark]
		public string Public4() => kms.GetKey("AppLevelEncryptionKey", "publickey");
		[Benchmark]
		public string Public5() => kms.GetKey("AppLevelEncryptionKey", "publickey");
		[Benchmark]
		public string Public6() => kms.GetKey("AppLevelEncryptionKey", "publickey");
		[Benchmark]
		public string Public7() => kms.GetKey("AppLevelEncryptionKey", "publickey");
		[Benchmark]
		public string Public8() => kms.GetKey("AppLevelEncryptionKey", "publickey");
		[Benchmark]
		public string Public9() => kms.GetKey("AppLevelEncryptionKey", "publickey");

		[Benchmark]
		public string Secret0() => kms.GetKey("Password", "secretkey");
		[Benchmark]
		public string Secret1() => kms.GetKey("Password", "secretkey");
		[Benchmark]
		public string Secret2() => kms.GetKey("Password", "secretkey");
		[Benchmark]
		public string Secret3() => kms.GetKey("Password", "secretkey");
		[Benchmark]
		public string Secret4() => kms.GetKey("Password", "secretkey");
		[Benchmark]
		public string Secret5() => kms.GetKey("Password", "secretkey");
		[Benchmark]
		public string Secret6() => kms.GetKey("Password", "secretkey");
		[Benchmark]
		public string Secret7() => kms.GetKey("Password", "secretkey");
		[Benchmark]
		public string Secret8() => kms.GetKey("Password", "secretkey");
		[Benchmark]
		public string Secret9() => kms.GetKey("Password", "secretkey");

		[Benchmark]
		public string Certificate0() => kms.GetKey("18fe3e715ced5e5f4dacfea66ab6f90a7e400d40", "certificate");
		[Benchmark]
		public string Certificate1() => kms.GetKey("18fe3e715ced5e5f4dacfea66ab6f90a7e400d40", "certificate");
		[Benchmark]
		public string Certificate2() => kms.GetKey("18fe3e715ced5e5f4dacfea66ab6f90a7e400d40", "certificate");
		[Benchmark]
		public string Certificate3() => kms.GetKey("18fe3e715ced5e5f4dacfea66ab6f90a7e400d40", "certificate");
		[Benchmark]
		public string Certificate4() => kms.GetKey("18fe3e715ced5e5f4dacfea66ab6f90a7e400d40", "certificate");
		[Benchmark]
		public string Certificate5() => kms.GetKey("18fe3e715ced5e5f4dacfea66ab6f90a7e400d40", "certificate");
		[Benchmark]
		public string Certificate6() => kms.GetKey("18fe3e715ced5e5f4dacfea66ab6f90a7e400d40", "certificate");
		[Benchmark]
		public string Certificate7() => kms.GetKey("18fe3e715ced5e5f4dacfea66ab6f90a7e400d40", "certificate");
		[Benchmark]
		public string Certificate8() => kms.GetKey("18fe3e715ced5e5f4dacfea66ab6f90a7e400d40", "certificate");
		[Benchmark]
		public string Certificate9() => kms.GetKey("18fe3e715ced5e5f4dacfea66ab6f90a7e400d40", "certificate");
	}

	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<ApiDatabasePrivatePublicCertificate>();
			Console.ReadKey();
		}
	}
}
