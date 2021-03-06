﻿// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;
using System.Threading;

namespace A2v10.Tests.Browser.Xaml
{
	public class StepCollection : List<Step>
	{

	}

	public abstract class Step : XamlItem
	{
		internal Step Parent { get; set; }

		public String TestId { get; set; }
		public String Description { get; set; }

		public void WaitClient()
		{
			Thread.Sleep(50);
		}
	}
}
