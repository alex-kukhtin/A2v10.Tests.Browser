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

		public ElementStepCollection Steps { get; set; } = new ElementStepCollection();

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			if (String.IsNullOrEmpty(Id))
				throw new TestException("SelectRow. Attribute 'Id' is required");
			var id = Id.ResolveValue(root);
			var script = $"return window.__tests__.$invoke({{target: 'datagrid', testId: '{Parent.TestId}', action: 'selectRow', id: '{id}'}});";
			var result = browser.ExecuteScript(script);
			if (result == null || result != "success")
				throw new TestException($"Could not select element with id='{id}'");

			Thread.Sleep(100); // Vue

			var row = elem.GetElementByXPath(".//tr[contains($class, 'dg-row') or contains(@class, 'active')]");

			foreach (var step in Steps)
				step.ElementRun(root, browser, row);
		}
	}
}
