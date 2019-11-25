// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;

namespace A2v10.Tests.Browser
{
	public interface IRunScenario
	{
		String Name { get; }
		String Description { get; set; }

		Exception Exception { get; }
		Boolean IsSuccess { get; }
		Boolean IsFailure { get; }

		void WriteException(Exception ex);
		void SetSuccess();
	}

	public interface IWebBrowser: IScope
	{
		void GotoUrl(String url);
		void Navigate(String url);
		void Click(ITestElement elem);
		void Escape();
		IWindow GetLastNewWindow();
		IPrintWindow GetPrintWindow();
		String ExecuteScript(String script);
		Object ExecuteScriptObject(String script);
		void WaitForComplete();

		IRunScenario StartScenario(String name, String description);
	}
}
