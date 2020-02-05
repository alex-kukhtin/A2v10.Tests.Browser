// Copyright © 2019-2020 Alex Kukhtin. All rights reserved.

using System;
using OpenQA.Selenium;

namespace A2v10.Tests.Browser
{
	public interface ITestElement: IScope
	{
		String Text { get; }

		void Click();
		void TypeText(String text);
		void Enter();
		void Clear();
		String TagName { get; }
		String GetAttribute(String name);
		IWebElement RawElement { get; }

		ITestElement TryGetElementByXPath(String xPath);
	}
}
