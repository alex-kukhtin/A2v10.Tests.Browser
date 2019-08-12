// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser
{
	public interface IWindow: IScope
	{
		String Title { get; }
		String Url { get; }

		void Close();
	}
}
