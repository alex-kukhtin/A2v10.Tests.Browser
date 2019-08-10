using System;
using System.Configuration;
using System.Windows.Forms;

namespace A2v10.Tests.Runner
{
	public partial class MainForm : Form
	{

		public String ConfigFile { get; set; }

		public MainForm()
		{
			InitializeComponent();
		}

		private void RunAll(Object sender, EventArgs e)
		{
			Browser.Current.RunAll();
		}

		private void OnLoad(Object sender, EventArgs e)
		{
			ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
			configMap.ExeConfigFilename = ConfigFile;
			var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
		}
	}
}
