namespace A2v10.Tests.Runner
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mainToolStrip = new System.Windows.Forms.ToolStrip();
			this.toolRunOne = new System.Windows.Forms.ToolStripButton();
			this.toolRunAll = new System.Windows.Forms.ToolStripButton();
			this.toolStop = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolReload = new System.Windows.Forms.ToolStripButton();
			this.toolHelp = new System.Windows.Forms.ToolStripButton();
			this.mainStatusBar = new System.Windows.Forms.StatusStrip();
			this.statusSuccess = new System.Windows.Forms.ToolStripStatusLabel();
			this.treeImageList = new System.Windows.Forms.ImageList(this.components);
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.treeView = new System.Windows.Forms.TreeView();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.mainToolStrip.SuspendLayout();
			this.mainStatusBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainToolStrip
			// 
			this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolRunOne,
            this.toolRunAll,
            this.toolStop,
            this.toolStripSeparator1,
            this.toolReload,
            this.toolHelp});
			this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
			this.mainToolStrip.Name = "mainToolStrip";
			this.mainToolStrip.Size = new System.Drawing.Size(861, 25);
			this.mainToolStrip.TabIndex = 0;
			this.mainToolStrip.Text = "toolStrip1";
			// 
			// toolRunOne
			// 
			this.toolRunOne.Image = ((System.Drawing.Image)(resources.GetObject("toolRunOne.Image")));
			this.toolRunOne.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolRunOne.Name = "toolRunOne";
			this.toolRunOne.Size = new System.Drawing.Size(48, 22);
			this.toolRunOne.Text = "Run";
			this.toolRunOne.Click += new System.EventHandler(this.RunOne);
			// 
			// toolRunAll
			// 
			this.toolRunAll.Image = ((System.Drawing.Image)(resources.GetObject("toolRunAll.Image")));
			this.toolRunAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolRunAll.Name = "toolRunAll";
			this.toolRunAll.Size = new System.Drawing.Size(65, 22);
			this.toolRunAll.Text = "Run All";
			this.toolRunAll.Click += new System.EventHandler(this.RunAll);
			// 
			// toolStop
			// 
			this.toolStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStop.Image")));
			this.toolStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStop.Name = "toolStop";
			this.toolStop.Size = new System.Drawing.Size(51, 22);
			this.toolStop.Text = "Stop";
			this.toolStop.Click += new System.EventHandler(this.OnStop);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolReload
			// 
			this.toolReload.Image = ((System.Drawing.Image)(resources.GetObject("toolReload.Image")));
			this.toolReload.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolReload.Name = "toolReload";
			this.toolReload.Size = new System.Drawing.Size(63, 22);
			this.toolReload.Text = "Reload";
			this.toolReload.Click += new System.EventHandler(this.OnReload);
			// 
			// toolHelp
			// 
			this.toolHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolHelp.Image = ((System.Drawing.Image)(resources.GetObject("toolHelp.Image")));
			this.toolHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolHelp.Name = "toolHelp";
			this.toolHelp.Size = new System.Drawing.Size(23, 22);
			this.toolHelp.Click += new System.EventHandler(this.OnAbout);
			// 
			// mainStatusBar
			// 
			this.mainStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusSuccess});
			this.mainStatusBar.Location = new System.Drawing.Point(0, 676);
			this.mainStatusBar.Name = "mainStatusBar";
			this.mainStatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
			this.mainStatusBar.Size = new System.Drawing.Size(861, 22);
			this.mainStatusBar.TabIndex = 1;
			this.mainStatusBar.Text = "mainStatusBar";
			// 
			// statusSuccess
			// 
			this.statusSuccess.BackColor = System.Drawing.Color.Green;
			this.statusSuccess.ForeColor = System.Drawing.Color.White;
			this.statusSuccess.Name = "statusSuccess";
			this.statusSuccess.Size = new System.Drawing.Size(207, 17);
			this.statusSuccess.Text = "In progress: 50 Pass: 20 Fail:30 Total:50";
			this.statusSuccess.Visible = false;
			// 
			// treeImageList
			// 
			this.treeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImageList.ImageStream")));
			this.treeImageList.TransparentColor = System.Drawing.Color.Magenta;
			this.treeImageList.Images.SetKeyName(0, "Folder_16x_24.bmp");
			this.treeImageList.Images.SetKeyName(1, "StatusHidden_16x.png");
			this.treeImageList.Images.SetKeyName(2, "StatusOK_16x_24.bmp");
			this.treeImageList.Images.SetKeyName(3, "StatusCriticalError_16x_24.bmp");
			this.treeImageList.Images.SetKeyName(4, "StatusNotStarted_16x_24.bmp");
			this.treeImageList.Images.SetKeyName(5, "Loading_Blue_16x.png");
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.treeView);
			this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
			this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainer1.Size = new System.Drawing.Size(861, 651);
			this.splitContainer1.SplitterDistance = 406;
			this.splitContainer1.SplitterWidth = 8;
			this.splitContainer1.TabIndex = 2;
			// 
			// treeView
			// 
			this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView.HideSelection = false;
			this.treeView.ImageIndex = 0;
			this.treeView.ImageList = this.treeImageList;
			this.treeView.Location = new System.Drawing.Point(0, 0);
			this.treeView.Name = "treeView";
			this.treeView.SelectedImageIndex = 0;
			this.treeView.Size = new System.Drawing.Size(406, 651);
			this.treeView.TabIndex = 0;
			this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewAfterSelect);
			// 
			// webBrowser1
			// 
			this.webBrowser1.AllowNavigation = false;
			this.webBrowser1.AllowWebBrowserDrop = false;
			this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.Location = new System.Drawing.Point(0, 0);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(447, 651);
			this.webBrowser1.TabIndex = 1;
			this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
			this.webBrowser1.WebBrowserShortcutsEnabled = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(861, 698);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.mainStatusBar);
			this.Controls.Add(this.mainToolStrip);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Browser Test Runner";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
			this.Load += new System.EventHandler(this.OnLoad);
			this.mainToolStrip.ResumeLayout(false);
			this.mainToolStrip.PerformLayout();
			this.mainStatusBar.ResumeLayout(false);
			this.mainStatusBar.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip mainToolStrip;
		private System.Windows.Forms.StatusStrip mainStatusBar;
		private System.Windows.Forms.ToolStripButton toolRunAll;
		private System.Windows.Forms.ImageList treeImageList;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.ToolStripButton toolRunOne;
		private System.Windows.Forms.ToolStripStatusLabel statusSuccess;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolReload;
		private System.Windows.Forms.ToolStripButton toolStop;
		private System.Windows.Forms.ToolStripButton toolHelp;
	}
}

