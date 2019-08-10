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
				MessageBox.Show("Usage: TestRunner configfile", "TestRunner", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			String path = Path.ChangeExtension(args[0], ".config");

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(
				new MainForm()
				{
					ConfigFile = path
				}
				);
		}
	}
}
