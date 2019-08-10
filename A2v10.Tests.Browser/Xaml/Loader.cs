using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;

namespace A2v10.Tests.Browser.Xaml
{
	public static class Loader
	{
		public static Feature LoadFeature(String fullPath)
		{
			return XamlServices.Load(fullPath) as Feature;
		}
	}
}
