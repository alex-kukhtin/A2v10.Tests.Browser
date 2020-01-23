// Copyright © 2020 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	public class PropertyGridItemCollection : List<PropertyGridItem>
	{

	}

	[ContentProperty("Items")]
	public class PropertyGrid : ElementStepContainer
	{
		public PropertyGridItemCollection Items { get; set; } = new PropertyGridItemCollection();
		public override ITestElement FindScope(IScope scope)
		{
			String xPath = String.Empty;
			if (!String.IsNullOrEmpty(TestId))
				xPath = $".//table[contains(@class, 'prop-grid')][@test-id='{TestId}']";

			return scope.GetElementByXPath(xPath);
		}

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			ITestElement scope = FindScope(control);
			foreach (var itm in Items)
			{
				itm.ElementRun(root, browser, scope);
			}
		}
	}

	public class PropertyGridItem : ElementStep
	{
		public Int32 Index { get; set; }
		public String Name { get; set; }
		public String Value { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			ITestElement td;
			if (!String.IsNullOrEmpty(Name))
			{
				String xPath = $".//tr/td[contains(@class, 'prop-name')][normalize-space()={Name.XPathText()}]/../td[contains(@class, 'prop-value')]";
				td = control.GetElementByXPath(xPath);
			}
			else
			{
				String xPath = $".//tr";
				var rows = control.GetElementsByXPath(xPath);
				if (Index < 0 || Index >= rows.Count)
					throw new TestException($"Index was outside the bounds of the array. (Index={Index}, Rows={rows.Count})");
				var row = rows[Index];
				td = row.GetElementByXPath("./td[contains(@class, 'prop-value')]");
			}
			if (td.Text != Value)
			{
				throw new TestException($"Invalid property grid value. Actual:'{td.Text}', expected: '{Value}'");
			}
		}
	}
}
