// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Markup;

namespace A2v10.Tests.Browser.Xaml
{
	public class ElementStepCollection : List<ElementStep>
	{
		public virtual void ElementsRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			foreach (var step in this)
			{
				step.ElementRun(root, browser, control);
			}
		}
	}

	public abstract class ElementStep : Step, ISupportInitialize
	{
		public override void Run(IRootElement root, IWebBrowser browser, IScope scope)
		{
			throw new System.NotImplementedException();
		}

		public abstract void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control);

		public virtual void OnInit()
		{

		}

		#region ISupportInitialize
		public void BeginInit()
		{
		}

		public void EndInit()
		{
			OnInit();
		}
		#endregion
	}

	[ContentProperty("Steps")]
	public abstract class ElementStepContainer : ElementStep
	{
		public ElementStepCollection Steps { get; set; } = new ElementStepCollection();

		public abstract ITestElement FindScope(IScope scope);

		public override void ElementRun(IRootElement root, IWebBrowser browser, ITestElement control)
		{
			ITestElement scope = FindScope(control);
			Steps.ElementsRun(root, browser, scope);
		}
	}
}
