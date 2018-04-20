using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Testicer
{
	class Program
	{
		const string json = "{alg\":\"RSA-OAEP-256\", \"d\":\"IwgO7foBD3uWcQYdMtR_Nd3XdYGuz0atiIMpHahVRBesWuz4iXx6h-bu28xCUWdtJd46ZCpR6QdLEVL5u27wheoyGk_E7r-yAkiqx1it1TdedXqrR-JdnCsau3-Aa8G58I8paaFGKNmOPORdjVTnN7eBsV7MRDU0aUtdKvKcFRcYTN5ttQN_YMo50RA0V-wUNWdv7eimxRb_QS-GCuVKkJ8t3kUqn6poNZd8X8Pioti12ZlprouaRKJJ-jayZElyxBgL2DGfdB1gxEfivsWCCV-AiFKkFJoyL370NywZSV_QIcmTRAKHHkPhIClUjzwlOA4fo9RRb6QYxFKlilT37Q\", \"dp\":\"VQ6l9WhV4Oic5N67sV_BwKORLuaUPK8TbQsuhXE9MPP8EooIX4dluO4CX6d8itolOw7atwq9L5SREvYP_5fMlbodNB_RZ61QRJtp7w1B5WumAdImIREhCjtb9_Kg_DMWKcQT7mOIAMDkocVCGX4HL7OIscd1qWeXhpeyl9JcdWU\", \"dq\":\"MSRokh5bBXBUMdlm4PP-PJ3dKf0cEVx2NnUNRboVxaFYv0r7hdKpf0bBYHp_tI1teNvVM_drx4fN7QToP-_aIOR0f91D21lcziZAZaV6FyrUMX9rHp_4FUreaFmxopEDEmIW8HQFVCqr2A7CwONSmZtlJCnKwcF-y_LKlvftsDU\", \"e\":\"AQAB\", \"ext\":true, \"key_ops\":[\"decrypt\"],\"kty\":\"RSA\",\"n\":\"siK_6Fd_W071h4gcbER3__suA8RRW7ZiPIvjWpbjXvL702Tg9UoGZL6kDbU1Pb6DNhRlAu3U7xNkqc9i5DCu-ILRhACZykDMY_HHf_O1VSv8ORbF77cXsTzBD5yu4SQFRPYpihi8OYmgvFp8KvkLP_Vho60k3GjoubcP5s8pjXMsQFImJVKauezTKIwSLgs-OERhKQVcWkz0HANT02mOdPAGd3T5AVO90zaGOW-biaXrA2j2PXTlEKcv6Uj_QVCiHBb33r9lq6oqvYq8rirsnVczZRi0tjguUaPeyc7TkRuOxWFVKr8zLEcA8Cjrb25EEB5IOoT7MnyAnNSsXV4wwQ\",\"p\":\"5VBk-PqXDMIguaNPtftWCFVc8RMwZ1LexpSWxP3pNnf1tMRfQnArTqdfpnaaY6GZq_EbTlW_Fvya-GtHmOCmniRc8yb921wCa9sgOC9xJHxCvYo9rswtfM7agzk5pTOopKU6vJsgfcrquUL3PEqxjReq4W4N7mJZWP1ur-Zu-VU\",\"q\":\"xt2tfnUmhO31QPpGACPmx_bsUUkkONoCGeF8z7LJ-1a1ksRXFGDrfzSqI1_4JQHRd7rL4UfG81Tsng4WrltN5QKhVbgy2JyO9DVn5mv1xFuLyh9XBSeTtT8M_0I3fOdyCls6s4X-1U3qIlfWpHX6Wwzc-tBrKqsDO1GG6XN7qb0\",\"qi\":\"c0GUSsM1ipwYQVd-3FrK1_nyw_U17idOWgfO7SWlhAYLg7a8ekAHpGlLVIYXtP24ABIoIG2cPd7X-a5lBWO6GdyosGuFv_AUSP5CR_wqFiVQaamWiM7FsJ7OFCs4XLQLwUOxUotxwGz3gadTZmeADu33dccLJVCMONOOFsfq2H0\"}";
	static void Main(string[] args)
		{
			var q = "xt2tfnUmhO31QPpGACPmx_bsUUkkONoCGeF8z7LJ-1a1ksRXFGDrfzSqI1_4JQHRd7rL4UfG81Tsng4WrltN5QKhVbgy2JyO9DVn5mv1xFuLyh9XBSeTtT8M_0I3fOdyCls6s4X-1U3qIlfWpHX6Wwzc-tBrKqsDO1GG6XN7qb0";
			var p = "5VBk-PqXDMIguaNPtftWCFVc8RMwZ1LexpSWxP3pNnf1tMRfQnArTqdfpnaaY6GZq_EbTlW_Fvya-GtHmOCmniRc8yb921wCa9sgOC9xJHxCvYo9rswtfM7agzk5pTOopKU6vJsgfcrquUL3PEqxjReq4W4N7mJZWP1ur-Zu-VU";
			var n = "siK_6Fd_W071h4gcbER3__suA8RRW7ZiPIvjWpbjXvL702Tg9UoGZL6kDbU1Pb6DNhRlAu3U7xNkqc9i5DCu-ILRhACZykDMY_HHf_O1VSv8ORbF77cXsTzBD5yu4SQFRPYpihi8OYmgvFp8KvkLP_Vho60k3GjoubcP5s8pjXMsQFImJVKauezTKIwSLgs-OERhKQVcWkz0HANT02mOdPAGd3T5AVO90zaGOW-biaXrA2j2PXTlEKcv6Uj_QVCiHBb33r9lq6oqvYq8rirsnVczZRi0tjguUaPeyc7TkRuOxWFVKr8zLEcA8Cjrb25EEB5IOoT7MnyAnNSsXV4wwQ";

			BigInteger Q = new BigInteger(FromBase64Url(q).Reverse().ToArray());
			BigInteger P = new BigInteger(FromBase64Url(p).Reverse().ToArray());
			BigInteger N = new BigInteger(FromBase64Url(n).Reverse().ToArray());
			Console.WriteLine(Q);
			Console.WriteLine(P);
			Console.WriteLine(N);
			Console.WriteLine(new BigInteger(FromBase64Url("AQAB")));
			foreach (var item in FromBase64Url("AQAB")) {
				Console.WriteLine(item);
			}
		}
		static byte[] FromBase64Url(string base64Url)
		{
			string padded = base64Url.Length % 4 == 0
				? base64Url : base64Url + "====".Substring(base64Url.Length % 4);
			string base64 = padded.Replace("_", "/")
								  .Replace("-", "+");
			return Convert.FromBase64String(base64);
		}
	}
}
