// Copyright © 2019 Alex Kukhtin. All rights reserved.

using A2v10.Tests.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A2v10.Tests.Runner
{
	public enum NodeType
	{
		Folder,
		Feature
	}

	public class StepInfo
	{
		public String Name { get; set; }
	}


	public class NodeInfo
	{
		public NodeType Type { get; set; }
		public String Path { get; set; }
		public Boolean Running { get; set; }

		public Boolean IsFolder => Type == NodeType.Folder;
		public Boolean IsFeature => Type == NodeType.Feature;

		public List<IRunScenario> Steps { get; set; } = new List<IRunScenario>();

		public Boolean IsSuccess => Steps.All(x => x.IsSuccess);

		public void Clear()
		{
			Steps.Clear();
		}

		public String GetExceptionsHtml()
		{
			var sb = new StringBuilder("<ul class=\"ex-list\">");
			foreach (var rs in Steps)
			{
				if (rs.IsSuccess)
					sb.Append($"<li>{rs.Name} - success </li>");
				else
					sb.Append($"<li>{rs.Name} - failure <span class=\"ex-text\">{rs.Exception?.Message}</span></li>");
			}
			sb.Append("</ul>");
			return sb.ToString();
		}
	}


	public static class TreeNodeExtenstions
	{
		public static Boolean IsFeature(this TreeNode node)
		{
			if (node == null)
				return false;
			if (node.Tag is NodeInfo ni)
				return ni.IsFeature;
			return false;
		}
	}
}

