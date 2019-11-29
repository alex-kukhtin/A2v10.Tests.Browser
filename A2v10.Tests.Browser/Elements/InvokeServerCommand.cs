// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser.Xaml
{
	public class InvokeServerCommand : Step
	{
		public String Command { get; set; }
		public String Path { get; set; }
		public String To { get; set; }
		public String Id { get; set; }

		public override void Run(IRootElement root, IWebBrowser browser, IScope scope)
		{
			if (Command is null)
				throw new TestException("InvokeServerCommand. Command is required");
			if (Path is null)
				throw new TestException("InvokeServerCommand. Path is required");

			var id = Id.ResolveValue(root) ?? "";
			var invokeScript = $"return window.__tests__.$invoke({{target: 'shell', action: 'invoke', cmd: '{Command}', path: '{Path}', id:'{id}'}});";
			var lastResultScript = $"return window.__tests__.$lastResult();";

			var result = browser.ExecuteScript(invokeScript);

			result = browser.ExecuteScript(lastResultScript);

			if (result == null)
				throw new TestException($"Error invoking command '{Command}'");

			// 'sucess:id' or 'error:exception message here'
			if (result.StartsWith("success:"))
				root.SetValue(To, result.Substring(8));
			else if (result.StartsWith("error:"))
				throw new TestException(result.Substring(6));
			else
				throw new TestException($"Invalid response value: '{result}'");
		}
	}
}
