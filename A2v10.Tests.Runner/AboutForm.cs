// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Reflection;
using System.Windows.Forms;
using A2v10.Tests.Runner.Properties;

namespace A2v10.Tests.Runner
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
			picIcon.Image = Resources.checkmark.ToBitmap();
		}

		private void OnCancel(Object sender, EventArgs e)
		{
			Close();
		}

		private void AboutForm_Load(Object sender, EventArgs e)
		{
			var v = Assembly.GetExecutingAssembly().GetName().Version;
			lblVersion.Text = $"Version: {v.Major}.{v.Minor}.{v.Build}";
		}

		private void linkLabel1_LinkClicked(Object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/alex-kukhtin/A2v10.Tests.Browser");
		}

		private void linkLabel2_LinkClicked(Object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("https://selenium.dev/");
		}
	}
}
