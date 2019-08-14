// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Threading;

namespace A2v10.Tests.Browser.Xaml
{
	public class EnsureDialog : Step
	{
		public String Title { get; set; }

		public override void Run(IRootElement root, IWebBrowser browser, IScope scope)
		{
			FindDialog(browser);
		}

		protected ITestElement FindDialog(IWebBrowser browser)
		{
			Thread.Sleep(100); // animation

			String xPath = ".//div[contains(@class, 'modal-wrapper')][contains(@class, 'show')]/div[contains(@class, 'modal-window')]";

			var windows = browser.GetElementsByXPath(xPath);
			if (windows.Count == 0)
				throw new TestException("Element with class 'modal_window' not found");
			var lastWindow = windows[windows.Count - 1];

			if (!String.IsNullOrEmpty(Title))
			{
				var titleElem = lastWindow.GetElementsByXPath(".//div[contains(@class, 'modal-header')]/span");
				if (titleElem.Count != 1)
					throw new TestException($"Dialog with title '{Title}' not found");
				String strTitle = titleElem[0].Text;
				if (strTitle.Trim() != Title.Trim())
					throw new TestException($"Invalid dialog title. Actual:'{strTitle}', expected: '{Title}'");
			}
			if (!String.IsNullOrEmpty(TestId))
			{
				var modalElem = lastWindow.GetElementByXPath(".//div[@class='modal']");
				var testId = modalElem.GetAttribute("test-id");
				if (testId != TestId)
					throw new TestException($"Invalid dialog TestId. Actual:'{testId}', expected: '{TestId}'");
			}
			return lastWindow;
		}
	}
}
