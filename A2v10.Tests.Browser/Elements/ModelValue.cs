// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class ModelValue : ElementStep
	{
		public String Path { get; set; }
		public String To { get; set; }

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			var testId = "null";
			if (!String.IsNullOrEmpty(Parent?.TestId))
				testId = $"'{Parent.TestId}'";
			var script = $"return window.__tests__.$invoke({{target: 'controller', testId: {testId}, action: 'eval', path: '{Path}'}});";
			var result = browser.ExecuteScript(script);
			if (result == null)
				throw new TestException($"Could not evaluate expression '{Path}'");
			root.SetValue(To, result);
		}
	}
}
