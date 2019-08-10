// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using A2v10.Tests.Browser;
using A2v10.Tests.Runner.Properties;

namespace A2v10.Tests.Runner
{
	public partial class MainForm : Form
	{

		public String AppDir { get; set; }
		public String ConfigFile { get; set; }

		const Int32 IMAGE_FOLDER = 0;
		const Int32 IMAGE_HIDDEN = 4;
		const Int32 IMAGE_SUCCESS = 2;
		const Int32 IMAGE_FAIL = 3;
		const Int32 IMAGE_NOT_STARTED = 1;
		const Int32 IMAGE_LOADING = 5;

		public MainForm()
		{
			InitializeComponent();
		}

		private void RunAll(Object sender, EventArgs e)
		{
			ForEachFeature(treeView.Nodes, n =>
			{
				n.ImageIndex = IMAGE_HIDDEN;
				n.SelectedImageIndex = IMAGE_HIDDEN;
				(n.Tag as NodeInfo).Clear();
			});
			RunAll(treeView.Nodes);
			SetButtonsState(disable:true);
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
			SetCurrentNodeText();
		}

		private void RunOne(TreeNode node)
		{
			if (!node.IsFeature())
				return;

			var ni = node.Tag as NodeInfo;
			if (ni.Type != NodeType.Feature)
				return;

			node.ImageIndex = IMAGE_LOADING;
			node.SelectedImageIndex = IMAGE_LOADING;
			ni.Clear();

			MethodInvoker mi = delegate ()
			{
				SetNodeResult(node);
				if (node == treeView.SelectedNode)
					SetCurrentNodeText();
				SetButtonsState();
			};

			_threadQueue.Enqueue(() => {
				Browser.Current.RunOne(ni.Path, (run) => ni.Steps.Add(run));
				this.Invoke(mi);
			});

			SetButtonsState(disable:true);
			//Browser.Current.RunOneAsync(ni.Path, (run) => RunAction(ni, run)).Wait();
		}

		void ForEachFeature(TreeNodeCollection nodes, Action<TreeNode> action)
		{
			foreach (var n in nodes)
			{
				if (n is TreeNode node) {
					var ni = node.Tag as NodeInfo;
					if (ni.Type == NodeType.Feature) {
						action(node);
					}
					ForEachFeature(node.Nodes, action);
				}
			}
		}

		void SetNodeRunning(TreeNode node)
		{
			var ni = node.Tag as NodeInfo;
			if (ni.Type == NodeType.Folder)
				return;
			Int32 image = IMAGE_HIDDEN;
			node.ImageIndex = image;
			node.SelectedImageIndex = image;
			ni.Running = true;
		}

		void SetNodeResult(TreeNode node)
		{
			var ni = node.Tag as NodeInfo;
			if (ni.Type == NodeType.Folder)
				return;
			Int32 image = ni.IsSuccess ? IMAGE_SUCCESS : IMAGE_FAIL;
			node.ImageIndex = image;
			node.SelectedImageIndex = image;
			ni.Running = false;
		}

		private void RunOne(Object sender, EventArgs e)
		{
			this.BringToFront();
			var node = treeView.SelectedNode;
			RunOne(node);
		}

		private ThreadQueue _threadQueue;

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
				var node = new TreeNode()
				{
					Text = Path.GetFileName(d),
					ImageIndex = IMAGE_FOLDER,
					SelectedImageIndex = IMAGE_FOLDER,
					Tag = new NodeInfo()
					{
						Type = NodeType.Folder,
						Path = d
					}
				};
				nodes.Add(node);
				LoadTree(d, node.Nodes);
				var files = Directory.EnumerateFiles(d, "*.feature.xaml").OrderBy(x => x);
				foreach (var f in files)
				{
					var file = new TreeNode()
					{
						Text = GetSimpleFileName(f),
						ImageIndex = IMAGE_HIDDEN,
						SelectedImageIndex = IMAGE_HIDDEN,
						Tag = new NodeInfo()
						{
							Type = NodeType.Feature,
							Path = f
						}
					};
					node.Nodes.Add(file);
				}
				node.Expand();
			}
		}

		private void OnClosing(Object sender, FormClosingEventArgs e)
		{
			Browser.Close();
		}

		private void TreeViewAfterSelect(Object sender, TreeViewEventArgs e)
		{
			SetCurrentNodeText();
			SetButtonsState();
		}

		void SetCurrentNodeText()
		{
			var node = treeView.SelectedNode;
			var nodeInfo = node?.Tag as NodeInfo;
			if (node == null || nodeInfo == null || nodeInfo.Type == NodeType.Folder)
			{
				webBrowser1.Document.Body.InnerHtml = "<div>empty</div>";
			}
			else
			{
				//webBrowser1.DocumentText = "<html><body>I AM THE TEXT FROM SELECTED</body></html>";
				var errorList = nodeInfo.GetExceptionsHtml();
				webBrowser1.Document.Body.InnerHtml = $"<h1>{node.Text}</h1><h3>{nodeInfo.IsSuccess}</h3>{errorList}";
			}
		}

		void SetButtonsState(Boolean disable = false)
		{
			Boolean isEnabled = false;
			if (!disable)
				isEnabled = _threadQueue.IsEmpty;
			toolRunAll.Enabled = isEnabled;
			toolReload.Enabled = isEnabled;

			if (isEnabled)
				isEnabled = treeView.SelectedNode.IsFeature();

			toolRunOne.Enabled = isEnabled;
		}

		private void OnReload(Object sender, EventArgs e)
		{
			treeView.Nodes.Clear();
			LoadTree(AppDir, treeView.Nodes);
			SetCurrentNodeText();
		}
	}
}
