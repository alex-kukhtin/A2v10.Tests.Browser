
using A2v10.Tests.Browser;
using System;

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

		private static Browser _current;

		private ChromeBrowser _browser;

		private Browser()
		{
			_browser = new ChromeBrowser();
			_browser.Start("http://thishost:81");
			_browser.Login("", "");
		}

		public void RunAll()
		{
		}

		public void Dispose()
		{
			var browser = _browser;
			_browser = null;
			if (browser != null)
				browser.Dispose();
		}
	}
}
