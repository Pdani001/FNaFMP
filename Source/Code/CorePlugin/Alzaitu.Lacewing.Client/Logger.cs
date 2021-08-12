using Alzaitu.Lacewing.EnumHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Alzaitu.Lacewing.Client
{
	internal class Logger
	{
		public enum Level
		{
			[StringValue("INFO")]
			INFO,
			[StringValue("WARN")]
			WARN,
			[StringValue("ERR")]
			ERROR
		}
		private static Dictionary<string, Logger> logs = new Dictionary<string, Logger>();
		public static Logger GetLogger(string name)
		{
			if (!logs.ContainsKey(name))
				logs.Add(name, new Logger(name));
			return logs[name];
		}

		private readonly string Name;
		private StringBuilder sb = new StringBuilder();
		private Timer Timer;
		private Logger(string name)
		{
			if (File.Exists(Environment.CurrentDirectory + "\\" + Name + ".log"))
			{
				File.Delete(Environment.CurrentDirectory + "\\" + Name + ".log");
			}
			Name = name;
			Timer = new Timer(5000); // X/1000=Y seconds
			Timer.Elapsed += OnTimedEvent;
			Timer.AutoReset = true;
			Timer.Enabled = true;
		}

		private void OnTimedEvent(object sender, ElapsedEventArgs e)
		{
			File.AppendAllText(Environment.CurrentDirectory + "\\" + Name + ".log", sb.ToString());
			sb.Clear();
		}
		public void Write(string text, params object[] obj)
		{
			Write(Level.INFO, text, obj);
		}
		public void Write(Level level, string text, params object[] obj)
		{
			string time = DateTime.Now.ToString("HH:mm:ss");
			text = $"[{time}] [{Name}/{level.GetStringValue()}]" + text;
			Console.WriteLine(text,obj);
			sb.AppendLine(string.Format(text, obj));
		}
	}
}
