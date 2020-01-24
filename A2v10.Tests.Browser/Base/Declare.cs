// Copyright © 2019-2020 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;

namespace A2v10.Tests.Browser.Xaml
{

	public class Declarations : List<Declare>
	{

	}

	public class Declare
	{
		public String Name { get; set; }
		public virtual String Value { get; set; }
	}

	public class DeclareDate : Declare
	{
		public Boolean Today { get; set; }
		public String Date { get; set; }
		public DateFormat Format { get; set; }
		public override String Value {
			get
			{
				DateTime dt;
				if (Today)
					dt = DateTime.Today;
				else
					dt = Date.ToDate();
				return dt.ToStringFormat(Format);
			}
		}
	}
}
