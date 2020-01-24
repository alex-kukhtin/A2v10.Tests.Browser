// Copyright © 2019 Alex Kukhtin. All rights reserved.


namespace A2v10.Tests.Browser.Xaml
{
	public class ClickCaret: ElementStep
	{
		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			// current pos - input
			switch (Parent) {
				case Button btn:
					ClickCaretButton(root, browser, elem);
					return;
			}
			elem.GetElementByXPath("./../a/span[@class='caret']")?.Click();
		}

		void ClickCaretButton(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			var xPath = "./../button[contains(@class, 'btn-caret')]";
			var caret = elem.GetElementByXPath(xPath);
			caret.Click();
			WaitClient();
		}
	}
}
