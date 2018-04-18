using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRCoder;
using BendyCrypto.Models;
using System.Threading.Tasks;
using AzureDB;
using System.IO;
namespace BendyCrypto.Controllers
{
	public class HomeController : Controller
	{
		
		public string ReadRequest()
		{
			using(StreamReader mreader = new StreamReader(Request.InputStream)) {
				return mreader.ReadToEnd();
				
			}
			
		}
		

		public async Task<ActionResult> CryptoVote(string id)
		{
			
			return View(new CryptoVoteModel() { Identity = await BendyDb.Instance.Database["keys"].RetrieveOne<Identity>(id) });
		}

		[HttpPost]
		public async Task<ActionResult> DoSomething()
		{

			return Content("You entered " + ReadRequest());
		}

		public async Task<ActionResult> Index()
		{


			var db = BendyDb.Instance.Database["keys"];
			//var rdb = BendyDb.Instance.RangedDatabase["list"];


			//foreach (var item in Global.IDs) {await db.Upsert(new Identity() { Key = item, PublicKey = new byte[0], Used = false });}
			
			//var samekey = await db.RetrieveOne<EncryptionKey>(guid);

			//await BendyDb.Instance.Database["keys"].Upsert());
			return View((await db.RetrieveMany<Identity>(Global.IDs)).OrderBy(k => k.Key));
		}

		public ActionResult GetQrCode()
		{
			using (QRCoder.QRCodeGenerator gen = new QRCodeGenerator()) {
				using (var data = gen.CreateQrCode(Guid.NewGuid().ToString(), QRCodeGenerator.ECCLevel.L)) {
					using (QRCoder.SvgQRCode code = new SvgQRCode(data)) {
						return Content(code.GetGraphic(5), "image/svg+xml");
					}
				}
			}
		}
	}
}