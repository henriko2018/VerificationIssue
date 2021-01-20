using System;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;

namespace Lib
{
	public static class Common
	{
		public static void Test()
		{
			// Signature:
			var signature = System.IO.File.ReadAllText("Signature.txt");
			var signedCms = new SignedCms();
			signedCms.Decode(Convert.FromBase64String(signature));
			signedCms.CheckSignature(true); // Cannot use false here because .NET does not trust a root cert that is not in the OS trusted root store.
			var signingCert = signedCms.SignerInfos[0].Certificate;
			//Console.WriteLine("Signing certificate:");
			//Console.WriteLine(signingCert);

			// Root cert:
			var certString = System.IO.File.ReadAllText("TrustedRoot.crt");
			var trustedRootCert = new X509Certificate2(Convert.FromBase64String(certString));
			//Console.WriteLine("Trusted root:");
			//Console.WriteLine(trustedRootCert);

			// Build certificate chain and check status:
			var chain = new X509Chain();
			chain.ChainPolicy.ExtraStore.Add(trustedRootCert);
			chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
			Console.WriteLine("Chain status:");
			Console.WriteLine(chain.Build(signingCert));
			foreach (var chainStatus in chain.ChainStatus)
				Console.WriteLine(chainStatus.Status);
		}
	}
}
