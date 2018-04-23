using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Testicer
{
	class Program
	{
		public static byte bitflip(byte b)
		{
			byte o = 0;
			for (int i = 0; i < sizeof(byte) * 8; i++) {
				o <<= 1;
				o |= (byte)(b & 1);
				b >>= 1;
			}
			return o;
		}
		static void Main(string[] args)
		{
			Console.WriteLine(A.a.val);

			using (var rsa = new RSACryptoServiceProvider()) { 
				var a = rsa.ExportParameters(true);
				BigInteger p = new BigInteger(a.P.Reverse().Concat(new byte[1]).ToArray());
				Console.WriteLine("p: {0}", p);
				BigInteger q = new BigInteger(a.Q.Reverse().Concat(new byte[1]).ToArray());
				Console.WriteLine("q: {0}", q);
				BigInteger n = new BigInteger(a.Modulus.Reverse().Concat(new byte[1]).ToArray());
				Console.WriteLine("n: {0}", n);
				Console.WriteLine(p * q == n);
				BigInteger e = new BigInteger(a.Exponent.Reverse().Concat(new byte[1]).ToArray());
				Console.WriteLine(e);
			}
		}
	}
}
public class A
{
	public static A a = new A();
	public int val;
	private A()
	{
		val = B.b.val;
		Console.WriteLine("A");

	}
}

public class B
{
	public static B b = new B();
	public int val;
	private B()
	{
		val = 10;
		Console.WriteLine("B");
	}
}