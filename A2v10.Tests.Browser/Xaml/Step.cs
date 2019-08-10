// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;

namespace A2v10.Tests.Browser.Xaml
{
	public class StepCollection : List<Step>
	{

	}

	public abstract class Step
	{
		public String Description { get; set; }
		public abstract void Run(IWebBrowser browser);
	}
}
