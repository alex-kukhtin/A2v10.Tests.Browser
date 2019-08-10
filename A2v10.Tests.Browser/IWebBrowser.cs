// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser
{
	public interface IRunScenario
	{
		String Name { get; }
		Exception Exception { get; }
		Boolean IsSuccess { get; }
		Boolean IsFailure { get; }

		void WriteException(Exception ex);
	}

	public interface IWebBrowser
	{
		void GotoUrl(String url);
		void Navigate(String url);
		void Click(String xPath);
		void GetElements(String xPath);
		IRunScenario StartScenario(String name);
	}
}
