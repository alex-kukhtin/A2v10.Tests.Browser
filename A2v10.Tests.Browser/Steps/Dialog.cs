// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.ComponentModel;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Steps")]
	public class Dialog : EnsureDialog, ISupportInitialize
	{
		public StepCollection Steps { get; set; } = new StepCollection();

		public override void Run(IRootElement root, IWebBrowser browser, IScope scope)
		{
			ITestElement dialog = FindDialog(browser);

			foreach (var step in Steps)
			{
				step.Run(root, browser, dialog);
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
