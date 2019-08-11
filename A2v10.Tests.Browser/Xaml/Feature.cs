// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Scenarios")]
	public class Feature : XamlItem
	{
		public String Description { get; set; }
		public ScenarioCollection Scenarios { get; set; } = new ScenarioCollection();

		public void RunAll(IWebBrowser browser, Action<IRunScenario> run)
		{
			foreach (var sc in Scenarios)
			{
				var helper = browser.StartScenario(sc.Name, sc.Description);
				try
				{
					sc.Run(browser);
					helper.SetSuccess();
				}
				catch (Exception ex)
				{
					helper.WriteException(ex);
				}
				run(helper);
			}
		}


		public override void Run(IWebBrowser browser)
		{
			throw new NotImplementedException();
		}
	}
}
