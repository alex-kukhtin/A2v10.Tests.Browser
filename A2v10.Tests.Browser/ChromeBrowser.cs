// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace A2v10.Tests.Browser
{
	public class ChromeBrowser : IWebBrowser, IDisposable
	{
		private ChromeDriver _driver;
		private INavigation _navigate;

		private const Int32 WAIT_TIMEOUT = 30000; // ms

		public ChromeBrowser()
		{
		}

		public void Start(String url) {
			if (_driver != null)
				return;
			ChromeOptions opts = new ChromeOptions()
			{
				PageLoadStrategy = PageLoadStrategy.Default
			};

			_driver = new ChromeDriver(opts);
			_navigate = _driver.Navigate();
			_driver.Manage().Window.Size = new Size(1600, 1000);
			_navigate.GoToUrl(url);
		}

		public void Login(String login, String passsword)
		{
			var inputLogin = _driver.FindElementById("login");
			inputLogin.SendKeys(login);

			var inputPassword = _driver.FindElementById("password");
			inputPassword.SendKeys(passsword);

			var btnSubmit = _driver.FindElementById("submit");
			btnSubmit.Click();
			WaitForComplete();
		}

		void EnsureDriver()
		{
			if (_driver == null)
				throw new InvalidOperationException("Browser is not running");
		}

		public void WaitForComplete()
		{
			EnsureDriver();
			var sw = new Stopwatch();
			try
			{
				Boolean readyState = false;
				do
				{
					var rs = _driver.ExecuteScript("return window.__tests__ && window.__tests__.$isReady();");
					Debug.WriteLine(rs);
					if (rs is Boolean)
						readyState = (Boolean)rs;
					if (readyState)
						return;
					Thread.Sleep(20);
					if (sw.ElapsedMilliseconds > WAIT_TIMEOUT)
						throw new TimeoutException();
				} while (!readyState);
			}
			catch (Exception /*ex*/)
			{
				// do nothing
			}
		}

		public void EnsureNoAppException()
		{
			var exceptions = _driver.FindElementsByClassName("app-exception");
			if (exceptions != null && exceptions.Count > 0)
			{
				var text = exceptions[0]?.FindElement(By.ClassName("message"))?.Text;
				if (text != null)
					throw new TestException(text);
				else
					throw new TestException($"Clicking on an item throws an exception");
			}
		}

		#region IWebBrowser

		public IRunScenario StartScenario(String name, String description)
		{
			return new RunScenario()
			{
				Name = name,
				Description = description
			};
		}

		public void GotoUrl(String url)
		{
			EnsureDriver();
			_navigate.GoToUrl(url);
			WaitForComplete();
		}

		public void Navigate(String url)
		{
			EnsureDriver();
			_driver.ExecuteScript($"window.__tests__.$navigate('{url}')");
			WaitForComplete();
			EnsureNoAppException();
		}

		public void Click(ITestElement elem)
		{
			EnsureDriver();
			elem.Click();
			WaitForComplete();
			EnsureNoAppException();
		}

		public ITestElement GetElementByXPath(String xPath, Boolean checkVisibility = true)
		{
			EnsureDriver();
			var elem = _driver.FindElementByXPath(xPath);
			return new TestElement(elem);
		}

		public IReadOnlyList<ITestElement> GetElementsByXPath(String xPath)
		{
			EnsureDriver();
			var elems = _driver.FindElementsByXPath(xPath);
			var result = new List<ITestElement>();
			foreach (var e in elems)
				result.Add(new TestElement(e));
			return result;
		}

		public IReadOnlyList<ITestElement> GetElementsByClassName(String className)
		{
			EnsureDriver();
			var elems = _driver.FindElementsByClassName(className);
			var result = new List<ITestElement>();
			foreach (var e in elems)
				result.Add(new TestElement(e));
			return result;
		}

		public void Escape()
		{
			EnsureDriver();
			var body = _driver.FindElementByTagName("body");
			body?.SendKeys(Keys.Escape);
		}

		public IWindow GetLastNewWindow()
		{
			EnsureDriver();
			var handles = _driver.WindowHandles;
			if (handles.Count < 2)
				throw new TestException($"Window not found");
			var winName = handles[handles.Count - 1];
			_driver.SwitchTo().Window(winName);
			WaitForComplete();
			EnsureNoAppException();
			return new TestWindow(_driver);
		}

		public String ExecuteScript(String script)
		{
			EnsureDriver();
			var val = _driver.ExecuteScript(script);
			if (val == null)
				return null;
			return val.ToString();
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
				try
				{
					driver.Close();
					driver.Dispose();
				} catch (Exception /*ex*/)
				{
					// do nothing. quit
				}
			}
		}
	}
}
