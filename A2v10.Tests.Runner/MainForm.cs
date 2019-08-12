// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using A2v10.Tests.Runner.Properties;

namespace A2v10.Tests.Runner
{
	public partial class MainForm : Form
	{

		public String AppDir { get; set; }
		public String ConfigFile { get; set; }

		private ThreadQueue _threadQueue;
		private Int32 _countThreads;

		public MainForm()
		{
			InitializeComponent();
		}

		private void RunAll(TreeNodeCollection nodes)
		{
			if (nodes == null)
				return;

			foreach (var n in nodes)
			{
				if (n is TreeNode node)
				{
					RunOne(node);
					RunAll(node.Nodes);
				}
			}
			UpdateUI();
		}

		private void RunOne(TreeNode node)
		{
			if (!(node.Tag is NodeInfo ni))
				return;

			if (ni.Type != NodeType.Feature)
				return;

			node.SetRunning();

			_countThreads += 1;
			UpdateUI();

			// thread safe!
			MethodInvoker mi = delegate ()
			{
				node.SetResult();
				_countThreads -= 1;
				UpdateUI();
			};

			Exception runException = null;

			// thread safe!
			MethodInvoker exceptionInvoker = delegate ()
			{
				node.SetException(runException);
				_countThreads -= 1;
				UpdateUI();
			};


			_threadQueue.Enqueue(() => {
				try
				{
					Browser.Current.RunOne(ni.Path, (run) => ni.Steps.Add(run));
					this.Invoke(mi);
				}
				catch (Exception ex)
				{
					runException = ex;
					this.Invoke(exceptionInvoker);
				}
			});
		}

		#region Commands
		private void RunAll(Object sender, EventArgs e)
		{
			RunAll(treeView.Nodes);
		}

		private void RunOne(Object sender, EventArgs e)
		{
			var node = treeView.SelectedNode;
			if (node == null) return;
			if (node.IsFeature())
				RunOne(node);
			else
				RunAll(node.Nodes);
		}

		private void OnReload(Object sender, EventArgs e)
		{
			treeView.Nodes.Clear();
			LoadTree(AppDir, treeView.Nodes);
		}
		#endregion



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
			var dirs = Directory.EnumerateDirectories(path).OrderBy(x => x);
			foreach (var d in dirs)
			{
				var node = NodeInfo.CreateNode(Path.GetFileName(d), d, NodeType.Folder);
				nodes.Add(node);
				LoadTree(d, node.Nodes);

				var files = Directory.EnumerateFiles(d, "*.feature.xaml").OrderBy(x => x);
				foreach (var f in files)
				{
					var file = NodeInfo.CreateNode(GetSimpleFileName(f), f, NodeType.Feature);
					node.Nodes.Add(file);
				}

				node.Expand();
			}
			UpdateUI();
		}

		#region Events

		private void OnLoad(Object sender, EventArgs e)
		{
			ExeConfigurationFileMap configMap = new ExeConfigurationFileMap()
			{
				ExeConfigFilename = ConfigFile
			};
			var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			Config.CreateConfig(config, AppDir);

			String html = Resources.layout;
			webBrowser1.DocumentText = html; // "<html><head><style body {color:red;}></style></head><body></body></html>";
			webBrowser1.DocumentCompleted += (ds, arg) => {
				LoadTree(AppDir, treeView.Nodes);
			};
			_threadQueue = new ThreadQueue();
		}

		private void OnClosing(Object sender, FormClosingEventArgs e)
		{
			Browser.Close();
		}

		private void TreeViewAfterSelect(Object sender, TreeViewEventArgs e)
		{
			UpdateUI();
		}
		#endregion

		private void SetCurrentNodeText()
		{
			var node = treeView.SelectedNode;
			var nodeInfo = node?.Tag as NodeInfo;

			var dom = webBrowser1.Document.DomDocument as dynamic;
			var elem = dom.getElementById("root");
			elem.parentNode.removeChild(elem);

			var h = webBrowser1.Document.CreateElement("div");

			if (node == null || nodeInfo == null || nodeInfo.Type == NodeType.Folder)
			{
				h.InnerHtml = "<div id=\"root\"></div>";
			}
			else
			{
				h.InnerHtml = node.DescriptionHTML();
			}
			webBrowser1.Document.Body.AppendChild(h);
		}

		private void SetButtonsState()
		{
			Boolean isEnabled = _countThreads == 0;

			toolRunAll.Enabled = isEnabled;
			toolReload.Enabled = isEnabled;
			toolRunOne.Enabled = isEnabled && treeView.SelectedNode != null;
		}

		private void UpdateUI()
		{
			SetCurrentNodeText();
			SetButtonsState();
		}
	}
}
