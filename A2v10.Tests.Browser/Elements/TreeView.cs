// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{

	public abstract class TreeViewItemStep : ElementStep
	{

	}

	public class TreeViewItemStepsCollection :List<TreeViewItemStep>
	{

	}

	public class Expand : TreeViewItemStep
	{
		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			var cls = control.GetAttribute("class");
			if (cls.Contains("expanded"))
				return;
			var exp = control.GetElementByXPath(".//a[@class='toggle']");
			exp.Click();
			WaitClient();
			browser.WaitForComplete();
			WaitClient();
		}
	}

	[ContentProperty("Steps")]
	public class TreeViewItem : ElementStep
	{
		public String Text { get; set; }

		public TreeViewItemStepsCollection Steps { get; set; } = new TreeViewItemStepsCollection();

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			String xPath = null;
			if (Text != null)
				xPath = $".//li/div[@class='overlay']/a[normalize-space()={Text.XPathText()}]";
			var item = control.GetElementByXPath(xPath);
			item.Click();
			WaitClient();
			var li = item.GetElementByXPath("./../..");
			foreach (var s in Steps)
			{
				s.ElementRun(root, browser, li);
			}
		}
	}

	public class TreeViewStepsCollection : List<TreeViewItem>
	{

	}

	[ContentProperty("Steps")]
	public class TreeView : ElementStep
	{
		public TreeViewStepsCollection Steps { get; set; } = new TreeViewStepsCollection();

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			String xPath = ".//ul[contains(@class, 'tree-view')]";
			if (TestId != null)
				xPath = $".//ul[contains(@class, 'tree-view')][@test-id='{TestId}']";
			var view = control.GetElementByXPath(xPath);
			foreach (var s in Steps)
			{
				s.ElementRun(root, browser, view);
			}
		}
	}
}
