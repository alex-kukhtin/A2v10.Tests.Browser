// Copyright © 2019 Alex Kukhtin. All rights reserved.

using A2v10.Tests.Browser;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace A2v10.Tests.Runner
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(String[] args)
		{
			String path = Directory.GetCurrentDirectory();
			if (args.Length > 0)
				path = args[0];

			String configPath = Path.Combine(path, "Tests.Runner.config");
			if (!File.Exists(configPath))
				MessageBox.Show($"Config file '{configPath}' not found", "Usage", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

			ExeConfigurationFileMap configMap = new ExeConfigurationFileMap()
			{
				ExeConfigFilename = configPath
			};

			HostsCollection _hosts = null;
			try
			{
				var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
				if ((config.Sections["hosts"] is HostsSection hs))
					_hosts = hs.hosts;
				else
				{
					MessageBox.Show("Invalid configuration file (configPath)");
					return;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Config error: {ex.Message}");
				return;
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(_hosts, path));
		}
	}
}
