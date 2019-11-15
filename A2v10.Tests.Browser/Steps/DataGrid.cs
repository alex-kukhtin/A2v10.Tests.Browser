// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.ComponentModel;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Steps")]

	public class DataGrid : ElementStep, ISupportInitialize
	{
		public DataGridStepCollection Steps { get; set; } = new DataGridStepCollection();

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			String xPath = String.Empty;

			if (!String.IsNullOrEmpty(TestId))
				xPath = $".//div[contains(@class, 'data-grid-container')][@test-id='{TestId}']";

			var dataGrid = control.GetElementByXPath(xPath);

			foreach (var step in Steps)
			{
				step.ElementRun(root, browser, dataGrid);
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
