
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;

namespace A2v10.Tests.Browser
{
	public class TestWindow : IWindow
	{
		public readonly ChromeDriver _driver;

		public TestWindow(ChromeDriver driver)
		{
			_driver = driver;
		}

		public String Title => _driver.Title;

		public String Url => GetUrl();
	
		public IReadOnlyList<ITestElement> GetElementsByXPath(String xPath)
		{
			var elems = _driver.FindElementsByXPath(xPath);
			var result = new List<ITestElement>();
			foreach (var e in elems)
				result.Add(new TestElement(e));
			return result;
		}

		public IReadOnlyList<ITestElement> GetElementsByClassName(String className)
		{
			var elems = _driver.FindElementsByClassName(className);
			var result = new List<ITestElement>();
			foreach (var e in elems)
				result.Add(new TestElement(e));
			return result;
		}

		public ITestElement GetElementByXPath(String xPath)
		{
			var elem = _driver.FindElementByXPath(xPath);
			return new TestElement(elem);
		}

		public void Close()
		{
			var h = _driver.WindowHandles;
			if (h.Count == 1)
			{
				_driver.SwitchTo().Window(h[0]);
				return;
			}
			_driver.SwitchTo().Window(h[h.Count - 1]);
			_driver.Close();
			_driver.SwitchTo().Window(h[0]);
		}

		private String GetUrl()
		{
			var uri = new Uri(_driver.Url);
			return uri.LocalPath;
		}
	}
}
