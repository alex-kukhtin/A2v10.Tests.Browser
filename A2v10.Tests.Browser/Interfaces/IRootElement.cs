// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;

namespace A2v10.Tests.Browser
{
	public interface IRootElement
	{
		void DeclareVariable(String name, String value);
		void SetValue(String name, String value);
		String GetValue(String name);
	}
}
