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
	public class FetchResponse
	{
		public FetchData response { get; set; }
	}
	public class FetchData
	{
		public bool success { get; set; }
		public string message { get; set; }
		public FetchUser[] users { get; set; }
	}
	public class FetchUser
	{
		public string username { get; set; }
	}
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
		private const string LOGIN_URL = "https://api.gamejolt.com/api/game/v1_2/users/auth/?game_id={0}&username={1}&user_token={2}";
		private const string DATA_URL = "https://api.gamejolt.com/api/game/v1_2/users/?game_id={0}&username={1}";
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
			string login_link = string.Format(LOGIN_URL, GameID, user, token);
			string login_sign = Hash(login_link + GameKey);
			string loginapi;
			try
			{
				loginapi = web.DownloadString(login_link + "&signature=" + login_sign);
			}
			catch (Exception e)
			{
				return new AuthResponse
				{
					response = new AuthData
					{
						message = e.Message,
						success = false
					}
				};
			}
			AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(loginapi);
			web.Dispose();
			return authResponse;
		}

		public FetchResponse GetData(string user)
		{
			WebClient web = new WebClient();
			string data_link = string.Format(DATA_URL, GameID, user);
			string data_sign = Hash(data_link + GameKey);
			string dataapi;
			try
			{
				dataapi = web.DownloadString(data_link + "&signature=" + data_sign);
			}
			catch (Exception e)
			{
				return new FetchResponse
				{
					response = new FetchData
					{
						message = e.Message,
						success = false
					}
				};
			}
			Duality.Logs.Core.Write(dataapi);
			FetchResponse response = JsonConvert.DeserializeObject<FetchResponse>(dataapi);
			web.Dispose();
			return response;
		}

		private string Hash(string input)
		{
			var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
			return string.Concat(hash.Select(b => b.ToString("x2")));
		}
	}
}
