using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureDB;

namespace Comptroller
{
	public class Identity
	{
		public Identity()
		{

		}
		public string Key { get; set; }
		public byte[] PublicKey { get; set; }
		public bool Used { get; set; }
	}
	class Program
	{
		static async Task prog_main()
		{
			var sdb = new ScaledAzureDb(new AzureDatabase[] { new AzureDatabase(File.ReadAllLines("C:\\data\\config.txt")[0], "doesntmatter") });
			var db = new TableDb(sdb);
			/*var rdb = new RangedTableDb(new ScaledAzureDb(new AzureDatabase[] { new AzureDatabase(File.ReadAllLines("C:\\data\\config.txt")[0], "doesntmatter") }));*/

			/*await rdb["testtable"].Retrieve(50, 100, m => {
				foreach(var iable in m) {
					Console.WriteLine(iable.Key + " == " + iable["Value"]);
				}
				return true;
			});*/
			await sdb.Retrieve(null, null, cb => {
				foreach(var iable in cb) {
					Console.WriteLine(Encoding.UTF8.GetString(iable.Key));

				}
				return true;
			});
			while (true) {
				string name = Console.ReadLine();
				var id = new Identity() { Key = name, PublicKey = new byte[0], Used = false };
				await db["keys"].Upsert(id);
			}
			
		}
		static void Main(string[] args)
		{
			prog_main().Wait();
		}
	}
}
