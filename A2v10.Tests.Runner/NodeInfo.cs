// Copyright © 2019 Alex Kukhtin. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;

using A2v10.Tests.Browser;

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
		public Boolean HasSteps => Steps.Count > 0;

		public List<IRunScenario> Steps { get; set; } = new List<IRunScenario>();

		public Boolean IsSuccess => !Running && HasSteps && Steps.All(x => x.IsSuccess);
		public Boolean IsFailure => !Running && HasSteps && Steps.Any(x => x.IsFailure);

		internal const Int32 IMAGE_FOLDER = 0;
		internal const Int32 IMAGE_HIDDEN = 4;
		internal const Int32 IMAGE_SUCCESS = 2;
		internal const Int32 IMAGE_FAIL = 3;
		internal const Int32 IMAGE_NOT_STARTED = 1;
		internal const Int32 IMAGE_LOADING = 5;

		public void Clear()
		{
			Steps.Clear();
		}

		public static TreeNode CreateNode(String text, String path, NodeType type)
		{
			var node = new TreeNode()
			{
				Text = text,
				Tag = new NodeInfo()
				{
					Type = type,
					Path = path
				}
			};
			if (type == NodeType.Folder)
				node.SetImage(IMAGE_FOLDER);
			else
				node.SetImage(IMAGE_HIDDEN);
			return node;
		}

		public String GetStepsHtml()
		{
			var sb = new StringBuilder("<ul class=\"scenario\">");
			foreach (var rs in Steps)
			{
				var state = rs.IsSuccess ? "success" : 
							rs.IsFailure ? "fail" : "undefined";

				sb.Append($"<li><span class=\"{state} state\"></span><span class=\"step\">");
				sb.Append($"<span class=\"step\">{rs.Name}</span>");
				sb.Append($"<div class=\"descr\">{rs.Description}</div>");
				if (rs.IsFailure) {
					sb.Append($"<span class=\"ex\">{WebUtility.HtmlEncode(rs.Exception?.Message)}</span>");
				}
				sb.Append("</li>");
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
		public static void SetImage(this TreeNode node, Int32 image)
		{
			node.ImageIndex = image;
			node.SelectedImageIndex = image;
		}

		public static void Clear(this TreeNode node)
		{
			node.SetImage(NodeInfo.IMAGE_HIDDEN);
			if (node.Tag is NodeInfo ni)
				ni.Clear();
		}

		public static void SetRunning(this TreeNode node)
		{
			node.SetImage(NodeInfo.IMAGE_LOADING);
			var ni = node.Tag as NodeInfo;
			ni.Clear();
			ni.Running = true;
		}

		public static void SetResult(this TreeNode node)
		{
			var ni = node.Tag as NodeInfo;
			if (ni.Type == NodeType.Folder)
				return;
			ni.Running = false;
			Int32 image = ni.IsSuccess ? NodeInfo.IMAGE_SUCCESS : NodeInfo.IMAGE_FAIL;
			node.SetImage(image);
		}

		public static void SetException(this TreeNode node, Exception ex)
		{
			var ni = node.Tag as NodeInfo;
			if (ni.Type == NodeType.Folder)
				return;
			ni.Running = false;
			var sc = new RunScenario();
			sc.WriteException(ex);
			sc.Name = "Runtime Exception";
			ni.Steps.Add(sc);
			Int32 image = NodeInfo.IMAGE_FAIL;
			node.SetImage(image);
		}

		public static String DescriptionHTML(this TreeNode node)
		{
			var ni = node.Tag as NodeInfo;

			var stepsHtml = ni.GetStepsHtml();
			var state = ni.IsSuccess ? "success" :
				ni.IsFailure ? "fail" : "undefined";
			String html = $"<div id=\"root\"><h1><span class=\"{state} state big\"></span>{node.Text}</h1>{stepsHtml}</div>";
			return html;
		}
	}
}

