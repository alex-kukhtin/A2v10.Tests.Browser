// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.IO;

using A2v10.Tests.Browser;
using A2v10.Tests.Browser.Xaml;

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

		public String Url => _source.url;
		public String Login => _source.login;
		public String Password => _source.password;
		public String CompanyName => _source.company;


		public static void CreateConfig(SourceElement source, String appDir)
		{
			_current = new Config(source, appDir);
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

		private Config(SourceElement source, String appDir)
		{
			_source = source;
			_appDir = appDir;
		}

		private static Config _current;
		private readonly SourceElement _source;
		private readonly String _appDir;
	}
}
