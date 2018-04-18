using BendyCrypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BendyCrypto
{

	public class CryptoVoteModel
	{
		public Identity Identity { get; set; }
	}

	public class Identity
	{
		public Identity()
		{

		}
		public string Key { get; set; }
		public byte[] PublicKey { get; set; }
		public bool Used { get; set; }
	}
	public static class Global
	{
		public static readonly string[] IDs = {
			"Benjamin Altman",
			"Brett Graham",
			"Ian Whitehead",
			"Chen Dun",
			"Lily Sadowsky",
			"Travis Ahrenhoerster",
			"Trung Nguyen",
			"Tara Feldstein",
			"Connor Thompson",
			"Dona Pantova",
			"Zhaoqi Li",
			"Ilse Dippenaar"
		};

		public static async Task<bool> HasMadeKey(string ID)
		{
			var db = BendyDb.Instance.Database["keys"];
			var id = await db.RetrieveOne("ID");
			return id == null;
		}

		public static async Task<bool> HasVoted(string ID)
		{
			throw new NotImplementedException();
		}


	}
}