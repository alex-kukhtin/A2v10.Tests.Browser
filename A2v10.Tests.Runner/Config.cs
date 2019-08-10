using A2v10.Tests.Browser.Xaml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2v10.Tests.Runner
{
	public class Config
	{
		public static Config Current
		{
			get
			{
				if (_current == null)
					throw new InvalidOperationException("No current configuration");
				return _current;
			}
		}

		public String Url => GetKey("url");
		public String Login => GetKey("login");
		public String Password => GetKey("password");


		public static void CreateConfig(Configuration config, String appDir)
		{
			_current = new Config(config, appDir);
		}

		public Feature GetFuture(String dir)
		{
			const String extension = ".feature.xaml";
			String path = dir;
			if (!Path.IsPathRooted(dir))
				path = Path.Combine(_appDir, dir);
			path = path.ToLower();
			if (!path.EndsWith(extension))
				path += extension;
			return Loader.LoadFeature(path);
		}

		private Config(Configuration config, String appDir)
		{
			_configuration = config;
			_appDir = appDir;
		}

		String GetKey(String key)
		{
			var x = _configuration?.AppSettings?.Settings[key];
			return x.Value;
		}

		private static Config _current;
		private readonly Configuration _configuration;
		private readonly String _appDir;
	}
}
