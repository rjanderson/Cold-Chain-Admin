namespace GeoTest2 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openKMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveKMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearTreeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripFileLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.displayButton = new System.Windows.Forms.Button();
            this.regionInfoButton = new System.Windows.Forms.Button();
            this.compressButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openKMLToolStripMenuItem,
            this.saveKMLToolStripMenuItem,
            this.toolStripSeparator2,
            this.clearTreeViewToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openKMLToolStripMenuItem
            // 
            this.openKMLToolStripMenuItem.Name = "openKMLToolStripMenuItem";
            this.openKMLToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.openKMLToolStripMenuItem.Text = "Open KML";
            this.openKMLToolStripMenuItem.Click += new System.EventHandler(this.OnOpenKmlClick);
            // 
            // saveKMLToolStripMenuItem
            // 
            this.saveKMLToolStripMenuItem.Name = "saveKMLToolStripMenuItem";
            this.saveKMLToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.saveKMLToolStripMenuItem.Text = "Save KML";
            this.saveKMLToolStripMenuItem.Click += new System.EventHandler(this.OnSaveKmlClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(147, 6);
            // 
            // clearTreeViewToolStripMenuItem
            // 
            this.clearTreeViewToolStripMenuItem.Name = "clearTreeViewToolStripMenuItem";
            this.clearTreeViewToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.clearTreeViewToolStripMenuItem.Text = "Clear TreeView";
            this.clearTreeViewToolStripMenuItem.Click += new System.EventHandler(this.OnClearTreeViewClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(147, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFileLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 633);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1084, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripFileLabel
            // 
            this.toolStripFileLabel.Name = "toolStripFileLabel";
            this.toolStripFileLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 71);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(430, 206);
            this.textBox1.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 283);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(430, 315);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnSelectedItemChanged);
            // 
            // mapPanel
            // 
            this.mapPanel.BackColor = System.Drawing.Color.Cornsilk;
            this.mapPanel.Location = new System.Drawing.Point(459, 27);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(601, 571);
            this.mapPanel.TabIndex = 4;
            this.mapPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnMapPanelPaint);
            // 
            // displayButton
            // 
            this.displayButton.Location = new System.Drawing.Point(12, 27);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(75, 23);
            this.displayButton.TabIndex = 5;
            this.displayButton.Text = "Display Map";
            this.displayButton.UseVisualStyleBackColor = true;
            this.displayButton.Click += new System.EventHandler(this.OnDisplayButtonClick);
            // 
            // regionInfoButton
            // 
            this.regionInfoButton.Location = new System.Drawing.Point(102, 27);
            this.regionInfoButton.Name = "regionInfoButton";
            this.regionInfoButton.Size = new System.Drawing.Size(75, 23);
            this.regionInfoButton.TabIndex = 6;
            this.regionInfoButton.Text = "Region Info";
            this.regionInfoButton.UseVisualStyleBackColor = true;
            this.regionInfoButton.Click += new System.EventHandler(this.OnRegionInfoClick);
            // 
            // compressButton
            // 
            this.compressButton.Location = new System.Drawing.Point(196, 27);
            this.compressButton.Name = "compressButton";
            this.compressButton.Size = new System.Drawing.Size(75, 23);
            this.compressButton.TabIndex = 7;
            this.compressButton.Text = "Compress";
            this.compressButton.UseVisualStyleBackColor = true;
            this.compressButton.Click += new System.EventHandler(this.OnCompressClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 655);
            this.Controls.Add(this.compressButton);
            this.Controls.Add(this.regionInfoButton);
            this.Controls.Add(this.displayButton);
            this.Controls.Add(this.mapPanel);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Geo2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openKMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveKMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripFileLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem clearTreeViewToolStripMenuItem;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.Button regionInfoButton;
        private System.Windows.Forms.Button compressButton;
    }
}

