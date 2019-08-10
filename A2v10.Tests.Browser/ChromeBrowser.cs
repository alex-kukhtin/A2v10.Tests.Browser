
using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace A2v10.Tests.Browser
{
	public class ChromeBrowser : IWebBrowser, IDisposable
	{
		private ChromeDriver _driver;
		private INavigation _navigate;

		ChromeBrowser()
		{
		}

		void Start() {
			if (_driver != null)
				return;
			ChromeOptions opts = new ChromeOptions()
			{
				PageLoadStrategy = PageLoadStrategy.Eager
			};

			_driver = new ChromeDriver(opts);
			_navigate = _driver.Navigate();
		}

		void EnsureDriver()
		{
			if (_driver == null)
				throw new InvalidOperationException("Browser is not running");
		}

		#region IWebBrowser
		public void GotoUrl(String url)
		{
			EnsureDriver();
			_navigate.GoToUrl(url);
		}

		public void WaitForComplete()
		{
			EnsureDriver();
			String readyState = String.Empty;
			while (readyState != "0")
			{
				readyState = _driver.ExecuteScript("return window.__requestsCount__;")?.ToString();
				Thread.Sleep(20);
			}
		}
		#endregion

		#region IDisposable
		public void Dispose()
		{
			Dispose(true);
		}
		#endregion

		protected virtual void Dispose(Boolean dispoising)
		{
			if (dispoising)
				OnDispose();
		}

		internal virtual void OnDispose()
		{
			var driver = _driver;
			_driver = null;
			if (driver != null)
			{
				driver.Close();
				driver.Dispose();
			}
		}
	}
}
