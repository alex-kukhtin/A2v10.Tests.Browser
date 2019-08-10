// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Scenarios")]
	public class Feature
	{
		public String Description { get; set; }
		public ScenarioCollection Scenarios { get; set; }
	}
}
