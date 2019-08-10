using A2v10.Tests.Browser.Xaml;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace A2v10.Tests.Runner
{
	public partial class MainForm : Form
	{

		public String AppDir { get; set; }
		public String ConfigFile { get; set; }

		const Int32 IMAGE_FOLDER = 0;
		const Int32 IMAGE_HIDDEN = 1;
		const Int32 IMAGE_SUCCESS = 2;
		const Int32 IMAGE_FAIL = 3;

		public MainForm()
		{
			InitializeComponent();
		}

		private void RunAll(Object sender, EventArgs e)
		{
			Browser.Current.RunAll();
		}

		private async void RunOne(Object sender, EventArgs e)
		{
			var node = treeView.SelectedNode;
			node.ImageIndex = IMAGE_HIDDEN;
			node.SelectedImageIndex = IMAGE_HIDDEN;
			await Browser.Current.RunOne(node.Tag.ToString());
			node.ImageIndex = IMAGE_SUCCESS;
			node.SelectedImageIndex = IMAGE_SUCCESS;
		}


		private void OnLoad(Object sender, EventArgs e)
		{
			ExeConfigurationFileMap configMap = new ExeConfigurationFileMap()
			{
				ExeConfigFilename = ConfigFile
			};
			var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			Config.CreateConfig(config, AppDir);
			LoadTree(AppDir, treeView.Nodes);
		}

		String GetSimpleFileName(String file)
		{
			String f = Path.GetFileNameWithoutExtension(file);
			Int32 dot = f.IndexOf('.');
			if (dot != -1)
				return f.Substring(0, dot);
			return f;
		}

		void LoadTree(String path, TreeNodeCollection nodes)
		{
			var dirs = Directory.EnumerateDirectories(path);
			foreach (var d in dirs)
			{
				var node = new TreeNode()
				{
					Text = Path.GetFileName(d),
					ImageIndex = IMAGE_FOLDER,
					SelectedImageIndex = IMAGE_FOLDER,
					Tag = d
				};
				nodes.Add(node);
				LoadTree(d, node.Nodes);
				node.Expand();
				var files = Directory.EnumerateFiles(d, "*.feature.xaml");
				foreach (var f in files)
				{
					var file = new TreeNode()
					{
						Text = GetSimpleFileName(f),
						ImageIndex = IMAGE_HIDDEN,
						SelectedImageIndex = IMAGE_HIDDEN,
						Tag = f
					};
					node.Nodes.Add(file);
				}
			}
		}

		private void OnClosing(Object sender, FormClosingEventArgs e)
		{
			Browser.Close();
		}

		private void TreeViewAfterSelect(Object sender, TreeViewEventArgs e)
		{
			Int32? image = treeView.SelectedNode?.ImageIndex;
			toolRunOne.Enabled = image.HasValue && image.Value != IMAGE_FOLDER;
		}
	}
}
