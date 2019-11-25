// Copyright © 2019 Alex Kukhtin. All rights reserved.

using OpenQA.Selenium;
using System;
using System.Threading;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	public class CancelPrint : PrintStep
	{
		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement elem)
		{
			String script =
				"return document.querySelector('print-preview-app').shadowRoot" +
				".querySelector('#sidebar').shadowRoot"+
				".querySelector('print-preview-button-strip').shadowRoot"+
				".querySelector('cr-button.cancel-button')";

			var cancelButton = browser.ExecuteScriptObject(script);
			if (cancelButton is IWebElement cancelElem)
				cancelElem.Click();
		}
	}
}
