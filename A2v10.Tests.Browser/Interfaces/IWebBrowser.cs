// Copyright © 2019-2020 Alex Kukhtin. All rights reserved.

using System;

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
		void AdvancedClick(ITestElement elem, Int32 x = 0, Int32 y = 0);
		void Escape();
		IWindow GetLastNewWindow();
		IPrintWindow GetPrintWindow();
		String ExecuteScript(String script);
		Object ExecuteScriptObject(String script);
		void WaitForComplete();
		ITestElement ActiveElement();
		IRunScenario StartScenario(String name, String description);
	}
}
