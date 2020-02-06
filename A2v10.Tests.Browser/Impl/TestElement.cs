// Copyright © 2019-2020 Alex Kukhtin. All rights reserved.

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
		public String TagName => _elem.TagName.ToLowerInvariant();
		public IWebElement RawElement => _elem;

		public void Click(Boolean checkEnabled = true)
		{
			if (checkEnabled && !_elem.Enabled)
				throw new TestException($"Element is not currently enabled and so may not be interacted with");
			_elem.Click();
		}

		public Boolean IsSame(ITestElement elem)
		{
			return _elem.Equals(elem.RawElement);
		}

		public void TypeText(String text)
		{
			if (!_elem.Enabled)
				throw new TestException($"Element is not currently enabled and so may not be interacted with");
			if (text == null)
				return;
			if (_elem.GetAttribute("class").Contains("trigger-input"))
			{
				Thread.Sleep(300); // needed!
				foreach (var t in text)
				{
					var sKey = new String(t, 1);
					_elem.SendKeys(sKey);
					Thread.Sleep(10);
				}
			}
			else
			{
				_elem.SendKeys(text);
			}
			Thread.Sleep(50);
		}

		public void Enter()
		{
			_elem.SendKeys(Keys.Enter);
		}

		public void Clear()
		{
			_elem.Clear();
		}

		public ITestElement TryGetElementByXPath(String xPath)
		{
			try
			{
				var elem = _elem.FindElement(By.XPath(xPath));
				return new TestElement(elem);
			}
			catch (Exception /*ex*/) {
				return null;
			}
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
