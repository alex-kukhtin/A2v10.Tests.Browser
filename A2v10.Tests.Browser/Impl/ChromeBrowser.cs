// Copyright © 2019-2022 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

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

		public void Start(String url)
		{
			if (_driver == null)
			{
				ChromeOptions opts = new ChromeOptions()
				{
					PageLoadStrategy = PageLoadStrategy.Eager,
					Proxy = null
				};
				_driver = new ChromeDriver(opts);
				_driver.Manage().Window.Size = new Size(1600, 1000);
			}
			_navigate = _driver.Navigate();
			_navigate.GoToUrl(url);
		}

		public void Restart(String url)
		{
			_navigate = _driver.Navigate();
			_navigate.GoToUrl($"{url}/account/login");
		}

		public void Login(String login, String passsword)
		{
			var inputLogin = _driver.FindElement(By.Id("login"));
			inputLogin.SendKeys(login);

			var inputPassword = _driver.FindElement(By.Id("password"));
			inputPassword.SendKeys(passsword);

			var btnSubmit = _driver.FindElement(By.Id("submit"));
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
					if (rs is Boolean boolRs)
						readyState = boolRs;
					if (readyState)
					{
						Thread.Sleep(50); // Vue
						return;
					}
					Thread.Sleep(20);
					Debug.WriteLine("waiting...");
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
			var exceptions = _driver.FindElements(By.ClassName("app-exception"));
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
			Thread.Sleep(50); // Vue
			elem.Click();
			WaitForComplete();
			Thread.Sleep(50); // Vue
			EnsureNoAppException();
		}
		
		public void AdvancedClick(ITestElement elem, Int32 x = 0, Int32 y = 0)
		{
			var act = new Actions(_driver);
			act.MoveToElement(elem.RawElement, x, y)//, MoveToElementOffsetOrigin.TopLeft)
			.Click()
			.Build()
			.Perform();
		}

		public ITestElement ActiveElement() {
			var elem = _driver.SwitchTo().ActiveElement();
			if (elem != null)
				return new TestElement(elem);
			return null;
		}


		public ITestElement GetElementByXPath(String xPath, Boolean checkVisibility = true)
		{
			EnsureDriver();
			var elem = _driver.FindElement(By.XPath(xPath));
			return new TestElement(elem);
		}

		public IReadOnlyList<ITestElement> GetElementsByXPath(String xPath)
		{
			EnsureDriver();
			var elems = _driver.FindElements(By.XPath(xPath));
			var result = new List<ITestElement>();
			foreach (var e in elems)
				result.Add(new TestElement(e));
			return result;
		}

		public IReadOnlyList<ITestElement> GetElementsByClassName(String className)
		{
			EnsureDriver();
			var elems = _driver.FindElements(By.ClassName(className));
			var result = new List<ITestElement>();
			foreach (var e in elems)
				result.Add(new TestElement(e));
			return result;
		}

		public void Escape()
		{
			EnsureDriver();
			var body = _driver.FindElement(By.TagName("body"));
			body?.SendKeys(Keys.Escape);
		}

		public IWindow GetLastNewWindow()
		{
			EnsureDriver();
			var handles = _driver.WindowHandles;
			if (handles.Count < 2)
				throw new TestException($"Window not found");
			var winName = handles[handles.Count - 1];

			var st = _driver.SwitchTo();
			st.Window(winName);
			WaitForComplete();
			EnsureNoAppException();
			return new TestWindow(_driver);
		}

		void WaitForNewWindow()
		{
			Int32 xCount = _driver.WindowHandles.Count;
			while (_driver.WindowHandles.Count == xCount)
				Thread.Sleep(500);
		}

		public IPrintWindow GetPrintWindow()
		{
			Int32 initCount = _driver.WindowHandles.Count;
			WaitForNewWindow();
			EnsureDriver();
			var handles = _driver.WindowHandles;
			if (handles.Count < 2)
				throw new TestException($"Window not found");
			var winName = handles[handles.Count - 1];

			var st = _driver.SwitchTo();
			st.Window(winName);
			return new TestPrintWindow(_driver, initCount);
		}

		public String ExecuteScript(String script)
		{
			EnsureDriver();
			var val = _driver.ExecuteScript(script);
			WaitForComplete();
			if (val == null)
				return null;
			return val.ToString();
		}

		public Object ExecuteScriptObject(String script)
		{
			EnsureDriver();
			var val = _driver.ExecuteScript(script);
			if (val == null)
				return null;
			return val;
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
