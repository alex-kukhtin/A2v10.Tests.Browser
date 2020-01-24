// Copyright © 2019-2020 Alex Kukhtin. All rights reserved.

using System;
using System.Configuration;

namespace A2v10.Tests.Browser
{
	public class HostsSection: ConfigurationSection
	{
		[ConfigurationProperty("", IsDefaultCollection = true)]
		public HostsCollection hosts => (HostsCollection)base[String.Empty];

	}

	[ConfigurationCollection(typeof(SourceElement), AddItemName = "host", CollectionType = ConfigurationElementCollectionType.BasicMap)]
	public class HostsCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new HostElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((HostElement)element).name;
		}

		public HostElement GetSource(String key)
		{
			return (HostElement)BaseGet(key);
		}
	}


	[ConfigurationCollection(typeof(SourceElement), AddItemName = "source", CollectionType = ConfigurationElementCollectionType.BasicMap)]
	public class SourcesCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new SourceElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((SourceElement)element).name;
		}

		public SourceElement GetSource(String key)
		{
			return (SourceElement)BaseGet(key);
		}
	}


	public class SourceElement : ConfigurationElement
	{
		[ConfigurationProperty("name", IsKey = true, IsRequired = true)]
		public String name
		{
			get { return (String)this["name"]; }
			set { this["name"] = value; }
		}

		[ConfigurationProperty("directory", IsRequired = true)]
		public String directory
		{
			get { return (String)this["directory"]; }
			set { this["directory"] = value; }
		}

		[ConfigurationProperty("url", IsRequired = true)]
		public String url
		{
			get { return (String)this["url"]; }
			set { this["url"] = value; }
		}


		[ConfigurationProperty("login", IsRequired = true)]
		public String login
		{
			get { return (String)this["login"]; }
			set { this["login"] = value; }
		}

		[ConfigurationProperty("password", IsRequired = true)]
		public String password
		{
			get { return (String)this["password"]; }
			set { this["password"] = value; }
		}

		[ConfigurationProperty("company", IsRequired = false)]
		public String company
		{
			get { return (String)this["company"]; }
			set { this["company"] = value; }
		}

		[ConfigurationProperty(nameof(period), IsRequired = false)]
		public String period
		{
			get { return (String)this[nameof(period)]; }
			set { this[nameof(period)] = value; }
		}
	}


	public class HostElement : ConfigurationElement
	{
		[ConfigurationProperty("name", IsKey = true, IsRequired = true)]
		public String name
		{
			get { return (String)this["name"]; }
			set { this["name"] = value; }
		}

		[ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
		public SourcesCollection sources
		{
			get { return (SourcesCollection)this[String.Empty]; }
			set { this[String.Empty] = value; }
		}
	}
}
