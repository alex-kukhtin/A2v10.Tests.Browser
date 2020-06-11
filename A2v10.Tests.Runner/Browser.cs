// Copyright © 2019-2020 Alex Kukhtin. All rights reserved.

using System;
using A2v10.Tests.Browser;
using A2v10.Tests.Browser.Xaml;

namespace A2v10.Tests.Runner
{
	public class Browser : IDisposable
	{
		public static Browser Current
		{
			get
			{
				if (_current == null)
					_current = new Browser();
				return _current;
			}
		}

		public static void Close()
		{
			if (_current != null)
				_current.Dispose();
		}

		private static Browser _current;

		private ChromeBrowser _browser;

		private Browser()
		{
			_browser = new ChromeBrowser();
			var config = Config.Current;
			_browser.Start(config.Url);
			if (!String.IsNullOrEmpty(config.Login) && !String.IsNullOrEmpty(config.Password))
				_browser.Login(config.Login, config.Password);
			SwitchToCompany(_browser, config.CompanyName);
			SwitchToPeriod(_browser, config.Period);
		}

		public void RunAll()
		{
		}

		public static void Restart()
		{
			if (_current == null)
				return;
			var config = Config.Current;
			_current._browser.Restart(config.Url);
			_current._browser.Login(config.Login, config.Password);
			SwitchToCompany(_current._browser, config.CompanyName);
			SwitchToPeriod(_current._browser, config.Period);
		}

		public void RunOne(String futureFile, Action<IRunScenario> run)
		{
			var config = Config.Current;
			var future = config.GetFuture(futureFile);
			future.RunAll(_browser, run);
		}

		public void Dispose()
		{
			var browser = _browser;
			_browser = null;
			if (browser != null)
				browser.Dispose();
		}

		static void SwitchToCompany(ChromeBrowser browser, String companyName)
		{
			if (String.IsNullOrEmpty(companyName))
				return;
			var f = new Feature();
			var s = new Scenario();
			var c = new SelectCompany() {
				Text = companyName
			};
			s.Steps.Add(c);
			f.Scenarios.Add(s);
			f.RunAll(browser, (r) => { });
		}

		static void SwitchToPeriod(ChromeBrowser browser, String period)
		{
			if (String.IsNullOrEmpty(period))
				return;
			var f = new Feature();
			var s = new Scenario();
			var c = new SelectPeriod()
			{
				Text = period
			};
			s.Steps.Add(c);
			f.Scenarios.Add(s);
			f.RunAll(browser, (r) => { });
		}
	}
}
