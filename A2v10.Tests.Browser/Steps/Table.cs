// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	public class TableRowCollection : List<TableRow>
	{

	}

	[ContentProperty("Rows")]
	public abstract class TableStep : ElementStep
	{
		public TableRowCollection Rows { get; set; } = new TableRowCollection();
		public abstract String tagName { get; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			var body = control.GetElementByXPath($".//{tagName}");
			foreach (var r in Rows)
				r.ElementRun(root, browser, body);
		}
	}

	public class TableStepCollection : List<TableStep>
	{
	}

	public class Body : TableStep
	{
		public override String tagName => "tbody";
	}

	public class Footer : TableStep
	{
		public override String tagName => "tfoot";
	}

	public class Header : TableStep
	{
		public override String tagName => "thead";
	}

	[ContentProperty("Steps")]
	public class Table : Step
	{
		public TableStepCollection Steps { get; set; } = new TableStepCollection();

		public override void Run(IRootElement root, IWebBrowser browser, IScope scope)
		{
			String xPath = String.Empty;
			if (!String.IsNullOrEmpty(TestId))
				xPath = $".//table[contains(@class, 'a2-table')][@test-id='{TestId}']";

			var table = scope.GetElementByXPath(xPath);
			foreach (var s in Steps)
				s.ElementRun(root, browser, table);
		}
	}

	[ContentProperty("Steps")]
	public class TableRow : ElementStep
	{
		public ElementStepCollection Steps { get; set; } = new ElementStepCollection();

		public Int32 Index { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			String xPath = $".//tr";
			var rows = control.GetElementsByXPath(xPath);
			if (Index < 0 || Index >= rows.Count)
				throw new TestException($"Index was outside the bounds of the array. (Index={Index}, Rows={rows.Count})");
			foreach (var step in Steps)
			{
				step.ElementRun(root, browser, rows[Index]);
			}
		}
	}
}
