using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRCoder;
using BendyCrypto.Models;
using System.Threading.Tasks;
using AzureDB;
namespace BendyCrypto.Controllers
{
	class EncryptionKey
	{
		public EncryptionKey()
		{

		}
		public Guid Key { get; set; }
		public byte[] PublicKey { get; set; }
		public bool Used { get; set; }
	}
	public class HomeController : Controller
	{
		
		public async Task<ActionResult> Index()
		{
			var db = BendyDb.Instance.Database["keys"];
			var guid = Guid.NewGuid();
			await db.Upsert(new EncryptionKey() { Key = guid, PublicKey = new byte[0], Used = true });
			
			var samekey = await db.RetrieveOne<EncryptionKey>(guid);

			//await BendyDb.Instance.Database["keys"].Upsert());
			return View();
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