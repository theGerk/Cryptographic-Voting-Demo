using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AzureDB;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Security.Cryptography;

namespace BendyCrypto.Models
{

	public class SomeUserClass
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		[DataType(DataType.EmailAddress)]
		[Display(Name ="E-mail")]
		public string Email { get; set; }
		[Display(Name ="Credit Card")]
		[DataType(DataType.CreditCard)]
		public string CreditCard { get; set; }
	}


	public class BendyDb
	{

		private static RSAParameters serverKey;
		public static RSAParameters ServerKey { get => serverKey; }

		static BendyDb bdb;
		TableDb db;
		//AzureDB.RangedTableDb rdb;
		public TableDb Database {
			get
			{
				return db;
			}
		}
		/*public RangedTableDb RangedDatabase {
			get
			{
				return rdb;
			}
		}*/
		static object syncobj = new object();
		public static BendyDb Instance {
			get
			{
				
				lock(syncobj) {
					if(bdb == null) {
						bdb = new BendyDb();
					}
					return bdb;
				}
			}
		}
		private BendyDb()
		{
			if(File.Exists("C:\\data\\config.txt")) {
				db = new TableDb(new ScaledAzureDb(new AzureDatabase[] { new AzureDatabase(File.ReadAllLines("C:\\data\\config.txt")[0], "doesntmatter") }));
				/*rdb = new RangedTableDb(new ScaledAzureDb(new AzureDatabase[] { new AzureDatabase(File.ReadAllLines("C:\\data\\config.txt")[0], "doesntmatter") }));*/

			} else {

				db = new TableDb(new ScaledAzureDb(new AzureDatabase[] { new AzureDatabase(System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString, "doesntmatter") }));
				/*rdb = new RangedTableDb(new ScaledAzureDb(new AzureDatabase[] { new AzureDatabase(System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString, "doesntmatter") }));*/
			}
			var oldContext = System.Threading.SynchronizationContext.Current;
			System.Threading.SynchronizationContext.SetSynchronizationContext(null);
			KeyEntry check = db["doesntmatter"].RetrieveOne<KeyEntry>(KeyEntry.SERVER_ID).Result;
			if (check == null) {
				check = new KeyEntry(new RSACryptoServiceProvider());
				db["doesntmatter"].Upsert(check);
			}
			System.Threading.SynchronizationContext.SetSynchronizationContext(oldContext);
			serverKey = check.parameters;
		}
	}
}