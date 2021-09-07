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
		private readonly string file;
		private Logger(string name)
		{
			Name = name;
			file = Environment.CurrentDirectory + $"\\{Name}.log";
			if (File.Exists(file))
			{
				File.WriteAllText(file,"");
				File.SetAttributes(file, FileAttributes.Normal);
			}
			Timer = new Timer(5000); // X/1000=Y seconds
			Timer.Elapsed += OnTimedEvent;
			Timer.AutoReset = true;
			Timer.Enabled = true;
		}
		public void Close()
		{
			/*if (File.Exists(file))
			{
				File.SetAttributes(file, FileAttributes.Normal);
				File.Delete(file);
			}*/
		}
		private void OnTimedEvent(object sender, ElapsedEventArgs e)
		{
			if (sb.ToString() == "")
				return;
			File.AppendAllText(file, sb.ToString());
			File.SetAttributes(file, FileAttributes.Normal);
			sb.Clear();
		}
		public void Write(string text, params object[] obj)
		{
			Write(Level.INFO, text, obj);
		}
		public void Write(Level level, string text, params object[] obj)
		{
			string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			text = $"[{time}] [{Name}/{level.GetStringValue()}]" + text;
			if (level == Level.ERROR)
				Console.Error.WriteLine(text, obj);
			else
				Console.WriteLine(text, obj);
			sb.AppendLine(string.Format(text, obj));
		}
	}
}
