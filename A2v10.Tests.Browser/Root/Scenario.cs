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
		public ElementStepCollection Steps { get; set; } = new ElementStepCollection();

		public override void Run(IRootElement root, IWebBrowser browser, IScope scope)
		{
			var shell = scope.GetElementsByClassName("shell")[0];
			foreach (var st in Steps)
				st.ElementRun(root, browser, shell);
		}
	}
}
