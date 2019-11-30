
using A2v10.Tests.Browser;
using A2v10.Tests.Browser.Xaml;
using System;
using System.Threading.Tasks;

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
			_browser.Login(config.Login, config.Password);
			SwicthToCompany(_browser, config.CompanyName); 
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
			SwicthToCompany(_current._browser, config.CompanyName);
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

		static void SwicthToCompany(ChromeBrowser browser, String companyName)
		{
			if (String.IsNullOrEmpty(companyName))
				return;
			var f = new Feature();
			var s = new Scenario();
			var c = new SelectCompany();
			c.Text = companyName;
			s.Steps.Add(c);
			f.Scenarios.Add(s);
			f.RunAll(browser, (r) => { });
		}
	}
}
