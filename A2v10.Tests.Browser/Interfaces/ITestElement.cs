// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser
{
	public interface ITestElement: IScope
	{
		String Text { get; }

		void Click();
		void TypeText(String text);
	}
}
