// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	[ContentProperty("Scenarios")]
	public class Feature : XamlItem, IRootElement
	{
		public String Description { get; set; }
		public ScenarioCollection Scenarios { get; set; } = new ScenarioCollection();

		public Declarations Declarations { get; set; } = new Declarations();

		public void RunAll(IWebBrowser browser, Action<IRunScenario> run)
		{
			foreach (var d in Declarations)
			{
				DeclareVariable(d.Name, d.Value);
			}

			browser.Escape();
			foreach (var sc in Scenarios)
			{
				var helper = browser.StartScenario(sc.Name, sc.Description);
				try
				{
					sc.Run(this, browser, browser);
					helper.SetSuccess();
				}
				catch (Exception ex)
				{
					helper.WriteException(ex);
				}
				run(helper);
			}
		}


		public override void Run(IRootElement root, IWebBrowser browse, IScope scope)
		{
			throw new NotImplementedException();
		}

		private readonly Dictionary<String, String> _storage = new Dictionary<String, String>();

		#region IRootElement
		public void DeclareVariable(String name, String value)
		{
			if (_storage.ContainsKey(name))
				throw new TestException($"Variable '{name}' already declared");
			_storage.Add(name, value);
		}

		public void SetValue(String name, String value)
		{
			if (!_storage.ContainsKey(name))
				throw new TestException($"Variable '{name}' is not declared");
			_storage[name] = value;
		}

		public String GetValue(String name)
		{
			if (!_storage.ContainsKey(name))
				throw new TestException($"Variable '{name}' is not declared");
			return _storage[name];
		}
		#endregion
	}
}
