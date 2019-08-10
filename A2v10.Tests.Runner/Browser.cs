
using A2v10.Tests.Browser;
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
		}

		public void RunAll()
		{
			RunOne("dialogs/CreateAgent");
		}

		public Task RunOne(String futureFile)
		{
			var config = Config.Current;
			var future = config.GetFuture(futureFile);
			return Task.Run(() =>
			{
				future.Run(_browser);
			});
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
