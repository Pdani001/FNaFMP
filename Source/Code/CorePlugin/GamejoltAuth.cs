using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FNaFMP
{
	public class AuthResponse
	{
		public AuthData response { get; set; }
	}
	public class AuthData
	{
		public bool success { get; set; }
		public string message { get; set; }
	}
	public class GamejoltAuth
	{
		private const string URL = "https://api.gamejolt.com/api/game/v1_2/users/auth/?game_id={0}&username={1}&user_token={2}";
		private string GameID = "";
		private string GameKey = "";
		public GamejoltAuth(string gameid, string gamekey)
		{
			if ((gameid == null || gameid.Length == 0) || (gamekey == null || gamekey.Length == 0))
			{
				throw new ArgumentException("GameKey/GameID is empty or null");
			}
			GameID = gameid;
			GameKey = gamekey;
		}
		public AuthResponse Login(string user, string token)
		{
			WebClient web = new WebClient();
			string link = string.Format(URL, GameID, user, token);
			string signature = link + GameKey;
			signature = Hash(signature);
			string api = web.DownloadString(link+"&signature="+signature);
			AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(api);
			web.Dispose();
			return authResponse;
		}

		private string Hash(string input)
		{
			var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
			return string.Concat(hash.Select(b => b.ToString("x2")));
		}
	}
}
