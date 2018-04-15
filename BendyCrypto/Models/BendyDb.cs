using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AzureDB;

namespace BendyCrypto.Models
{
	public class BendyDb
	{
		static BendyDb bdb;
		AzureDB.TableDb db;
		public TableDb Database {
			get
			{
				return db;
			}
		}
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
			}else {

				db = new TableDb(new ScaledAzureDb(new AzureDatabase[] { new AzureDatabase(System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString, "doesntmatter") }));
				
			}
		}
	}
}