using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Web;

namespace BendyCrypto.Models
{
	public class KeyEntry
	{
		public KeyEntry() { }
		public const string SERVER_ID = "server";
		public KeyEntry(RSACryptoServiceProvider cryptoServiceProvider)
		{
			Key = SERVER_ID;
			parameters = cryptoServiceProvider.ExportParameters(true);
		}
		public string Key;
		public RSAParameters parameters;
	}
}