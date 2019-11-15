// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;
using System.Threading;
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
		public String Text => GetElementText();

		public void Click()
		{
			if (!_elem.Enabled)
				throw new TestException($"Element is not currently enabled and so may not be interacted with");
			_elem.Click();
		}

		public void TypeText(String text)
		{
			if (!_elem.Enabled)
				throw new TestException($"Element is not currently enabled and so may not be interacted with");
			_elem.Click();
			Thread.Sleep(20); // vue set focus
			_elem.SendKeys(text);
		}

		public void Enter()
		{
			_elem.SendKeys(Keys.Enter);
		}

		public ITestElement GetElementByXPath(String xPath, Boolean checkVisibility = true)
		{
			var elem = _elem.FindElement(By.XPath(xPath));
			if (checkVisibility && !elem.Displayed)
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

		public String GetAttribute(String name)
		{
			return _elem.GetAttribute(name);
		}
		#endregion

		private IReadOnlyList<ITestElement> GetCollection(Func<IReadOnlyCollection<IWebElement>> func)
		{
			var result = new List<ITestElement>();
			foreach (var el in func())
				result.Add(new TestElement(el));
			return result;
		}

		String GetElementText()
		{
			if (_elem.TagName.ToLowerInvariant() == "input")
				return _elem.GetAttribute("value");
			return _elem.Text;
		}
	}
}
