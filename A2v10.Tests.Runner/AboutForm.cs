// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
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
	}
}
