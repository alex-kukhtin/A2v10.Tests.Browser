
using System;
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
