// Copyright © 2019-2020 Alex Kukhtin. All rights reserved.

using System;
using OpenQA.Selenium;

namespace A2v10.Tests.Browser.Xaml
{
	public class CancelPrint : PrintStep
	{
		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			String script =
@"return document.querySelector('print-preview-app').shadowRoot
	.querySelector('#sidebar').shadowRoot
	.querySelector('print-preview-button-strip').shadowRoot
	.querySelector('cr-button.cancel-button');";

			var cancelButton = browser.ExecuteScriptObject(script);
			if (cancelButton is IWebElement cancelElem)
				cancelElem.Click();
		}
	}
}
