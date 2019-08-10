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
	public class Scenario : XamlItem
	{
		public String Description { get; set; }
		public String Name { get; set; }
		public StepCollection Steps { get; set; } = new StepCollection();

		public override void Run(IWebBrowser browser)
		{
			foreach (var st in Steps)
				st.Run(browser);
		}
	}
}
