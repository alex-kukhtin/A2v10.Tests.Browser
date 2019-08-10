using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
			if (args.Length == 0)
			{
				MessageBox.Show("Usage: TestRunner appDir", "TestRunner", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			String path = Path.Combine(args[0], "_tests");
			String configPath = Path.ChangeExtension(Path.Combine(path, "TestRunner"), ".config");

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(
				new MainForm()
				{
					AppDir = path,
					ConfigFile = configPath
				}
				);
		}
	}
}
