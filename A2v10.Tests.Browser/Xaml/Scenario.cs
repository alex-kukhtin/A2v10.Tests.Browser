// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	public class ScenarioCollection : List<Scenario>
	{
	}

	[ContentProperty("Steps")]
	public class Scenario
	{
		public String Description { get; set; }
		public StepCollection Steps { get; set; }
	}
}
