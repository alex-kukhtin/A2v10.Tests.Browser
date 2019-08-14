// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class ModelValue : Step
	{
		public String Path { get; set; }
		public String To { get; set; }

		public override void Run(IRootElement root, IWebBrowser browser, IScope scope)
		{
			var script = $"return window.__tests__.$invoke({{target: 'controller', testId: '{Parent.TestId}', action: 'eval', path: '{Path}'}});";
			var result = browser.ExecuteScript(script);
			if (result == null)
				throw new TestException($"Could not evaluate expression {Path}");
			root.SetValue(To, result);
		}
	}
}
