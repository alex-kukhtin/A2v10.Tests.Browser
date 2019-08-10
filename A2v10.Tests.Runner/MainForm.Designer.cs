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
			this.toolRunAll = new System.Windows.Forms.ToolStripButton();
			this.mainStatusBar = new System.Windows.Forms.StatusStrip();
			this.treeImageList = new System.Windows.Forms.ImageList(this.components);
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.treeView = new System.Windows.Forms.TreeView();
			this.toolRunOne = new System.Windows.Forms.ToolStripButton();
			this.statusSuccess = new System.Windows.Forms.ToolStripStatusLabel();
			this.mainToolStrip.SuspendLayout();
			this.mainStatusBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainToolStrip
			// 
			this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolRunOne,
            this.toolRunAll});
			this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
			this.mainToolStrip.Name = "mainToolStrip";
			this.mainToolStrip.Size = new System.Drawing.Size(759, 25);
			this.mainToolStrip.TabIndex = 0;
			this.mainToolStrip.Text = "toolStrip1";
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
			// mainStatusBar
			// 
			this.mainStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusSuccess});
			this.mainStatusBar.Location = new System.Drawing.Point(0, 535);
			this.mainStatusBar.Name = "mainStatusBar";
			this.mainStatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
			this.mainStatusBar.Size = new System.Drawing.Size(759, 22);
			this.mainStatusBar.TabIndex = 1;
			this.mainStatusBar.Text = "mainStatusBar";
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
			this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.splitContainer1.Size = new System.Drawing.Size(759, 510);
			this.splitContainer1.SplitterDistance = 375;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 2;
			// 
			// treeView
			// 
			this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView.ImageIndex = 0;
			this.treeView.ImageList = this.treeImageList;
			this.treeView.Location = new System.Drawing.Point(0, 0);
			this.treeView.Name = "treeView";
			this.treeView.SelectedImageIndex = 0;
			this.treeView.Size = new System.Drawing.Size(375, 510);
			this.treeView.TabIndex = 0;
			this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewAfterSelect);
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
			// statusSuccess
			// 
			this.statusSuccess.Name = "statusSuccess";
			this.statusSuccess.Size = new System.Drawing.Size(48, 17);
			this.statusSuccess.Text = "Success";
			this.statusSuccess.Visible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(759, 557);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.mainStatusBar);
			this.Controls.Add(this.mainToolStrip);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Name = "MainForm";
			this.Text = "Browser Test Runner";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
			this.Load += new System.EventHandler(this.OnLoad);
			this.mainToolStrip.ResumeLayout(false);
			this.mainToolStrip.PerformLayout();
			this.mainStatusBar.ResumeLayout(false);
			this.mainStatusBar.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
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
	}
}

