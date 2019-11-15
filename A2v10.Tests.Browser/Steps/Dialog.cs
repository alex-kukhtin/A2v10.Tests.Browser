// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.ComponentModel;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Steps")]
	public class Dialog : EnsureDialog, ISupportInitialize
	{
		public ElementStepCollection Steps { get; set; } = new ElementStepCollection();

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			ITestElement dialog = FindDialog(browser);

			foreach (var step in Steps)
			{
				step.ElementRun(root, browser, dialog);
			}
		}

		#region ISupportInitialize
		public void BeginInit()
		{
		}

		public void EndInit()
		{
			foreach (var s in Steps)
				s.Parent = this;
		}
		#endregion
	}
}
