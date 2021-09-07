using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FNaFMP
{
	public class AuthData
	{
		public bool success { get; set; }
		public string message { get; set; }
		public string username { get; set; }
	}
	public class GamejoltAuth
	{
		private const string API_URL = "https://api.gamejolt.com/api/game/v1_2";
		private const string LOGIN_EP = "/users/auth/?game_id={0}&username={1}&user_token={2}";
		private const string DATA_EP = "/users/?game_id={0}&username={1}";
		private const string BATCH_EP = "/batch/?game_id={0}";
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
		public AuthData Login(string user, string token)
		{
			WebClient web = new WebClient();
			string login_link = string.Format(LOGIN_EP, GameID, user, token);
			login_link += "&signature=" + Hash(login_link + GameKey);
			login_link = HttpUtility.UrlEncode(login_link);
			string data_link = string.Format(DATA_EP, GameID, user);
			data_link += "&signature=" + Hash(data_link + GameKey);
			data_link = HttpUtility.UrlEncode(data_link);
			string batch_link = string.Format(BATCH_EP,GameID);
			string full_link = API_URL + batch_link + "&requests[]=" + login_link + "&requests[]=" + data_link;
			string full_sign = Hash(full_link + GameKey);
			string api;
			try
			{
				api = web.DownloadString(full_link + "&signature=" + full_sign);
			}
			catch (Exception e)
			{
				return new AuthData
				{
					message = e.Message,
					success = false
				};
			}
			dynamic response = JsonConvert.DeserializeObject(api, typeof(object));
			bool success = (bool)response.response.success;
			if(!success)
				return new AuthData
				{
					message = (string)response.response.message,
					success = false
				};
			var auth = response.response.responses[0];
			var data = response.response.responses[1];
			success = (bool)auth.success && (bool)data.success;
			string message = !success ? (!(bool)auth.success ? (string)auth.message : (string)data.message) : "";
			string username = success ? (string)data.users[0].username : user;
			web.Dispose();
			if (!success)
				return new AuthData
				{
					success = false,
					message = message
				};
			else
				return new AuthData
				{
					success = true,
					username = username
				};
		}

		private string Hash(string input)
		{
			var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
			return string.Concat(hash.Select(b => b.ToString("x2")));
		}
	}
}
