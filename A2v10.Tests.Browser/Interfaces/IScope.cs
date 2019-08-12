// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;

namespace A2v10.Tests.Browser
{
	public interface IScope
	{
		IReadOnlyList<ITestElement> GetElementsByXPath(String xPath);
		IReadOnlyList<ITestElement> GetElementsByClassName(String className);

		ITestElement GetElementByXPath(String xPath);
	}
}
