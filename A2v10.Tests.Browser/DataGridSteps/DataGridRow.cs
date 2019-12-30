// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Threading;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Steps")]
	public class DataGridRow : DataGridStep
	{
		public String Id { get; set; }
		public String Text { get; set; }

		public ElementStepCollection Steps { get; set; } = new ElementStepCollection();

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			ITestElement row = null;
			if (!String.IsNullOrEmpty(Id))
			{
				var id = Id.ResolveValue(root);
				var script = $"return window.__tests__.$invoke({{target: 'datagrid', testId: '{Parent.TestId}', action: 'selectRow', id: '{id}'}});";
				var result = browser.ExecuteScript(script);
				if (result == null || result != "success")
					throw new TestException($"Could not select element with id='{id}'");
				Thread.Sleep(100); // Vue

				row = elem.GetElementByXPath(".//tr[contains(@class, 'dg-row') and contains(@class, 'active')]");
			}
			else if (!String.IsNullOrEmpty(Text))
			{
				var cell = elem.GetElementByXPath($".//tr[contains(@class, 'dg-row')]/td//span[normalize-space()='{Text.XPathText()}']/ancestor::tr");
				cell.Click();
				Thread.Sleep(100); // Vue
				row = cell;
				//row = cell.GetElementByXPath("./ancestor::tr");
			}

			if (row == null)
				throw new TestException("DataGridRow. Attributes 'Id' or 'Text' are required");


			foreach (var step in Steps)
				step.ElementRun(root, browser, row);
		}
	}
}
