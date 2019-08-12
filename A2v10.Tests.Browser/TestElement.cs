// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;

using OpenQA.Selenium;

namespace A2v10.Tests.Browser
{
	public class TestElement : ITestElement
	{
		private readonly IWebElement _elem;

		public TestElement(IWebElement elem)
		{
			_elem = elem;
		}

		#region ITestElement
		public String Text => _elem.Text;

		public void Click()
		{
			_elem.Click();
		}

		public ITestElement GetElementByXPath(String xPath)
		{
			var elem = _elem.FindElement(By.XPath(xPath));
			if (!elem.Displayed)
				throw new TestException($"Element '{xPath}' is not currently visible and so may not be interacted with");
			return new TestElement(elem);
		}

		public IReadOnlyList<ITestElement> GetElementsByXPath(String xPath)
		{
			return GetCollection(() => _elem.FindElements(By.XPath(xPath)));
		}

		public IReadOnlyList<ITestElement> GetElementsByClassName(String className)
		{
			return GetCollection(() => _elem.FindElements(By.ClassName(className)));
		}
		#endregion

		private IReadOnlyList<ITestElement> GetCollection(Func<IReadOnlyCollection<IWebElement>> func)
		{
			var result = new List<ITestElement>();
			foreach (var el in func())
				result.Add(new TestElement(el));
			return result;
		}
	}
}
