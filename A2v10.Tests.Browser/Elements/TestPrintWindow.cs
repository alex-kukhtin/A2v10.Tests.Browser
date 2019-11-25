
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;

namespace A2v10.Tests.Browser
{
	public class TestPrintWindow : IPrintWindow
	{
		public readonly ChromeDriver _driver;
		private readonly Int32 _initCount;

		public TestPrintWindow(ChromeDriver driver, Int32 initCount)
		{
			_driver = driver;
			_initCount = initCount;
		}

		public void EnsureClose()
		{
			var h = _driver.WindowHandles;
			if (h.Count == _initCount)
			{
				_driver.SwitchTo().Window(h[h.Count - 1]);
				return;
			}
			throw new TestException("Forgot to close the print window?");
		}
	}
}
