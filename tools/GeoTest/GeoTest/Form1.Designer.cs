namespace GeoTest {
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
            this.openKmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolKmlStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.kmlFileLabel = new System.Windows.Forms.Label();
            this.textFileLabel = new System.Windows.Forms.Label();
            this.countToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.step1CDATAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.step2ExtractTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1070, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openKmlToolStripMenuItem,
            this.openTextToolStripMenuItem,
            this.saveToolKmlStripMenuItem,
            this.saveTextToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openKmlToolStripMenuItem
            // 
            this.openKmlToolStripMenuItem.Name = "openKmlToolStripMenuItem";
            this.openKmlToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openKmlToolStripMenuItem.Text = "Open KML";
            this.openKmlToolStripMenuItem.Click += new System.EventHandler(this.OnOpenKmlClick);
            // 
            // openTextToolStripMenuItem
            // 
            this.openTextToolStripMenuItem.Name = "openTextToolStripMenuItem";
            this.openTextToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openTextToolStripMenuItem.Text = "Open Text ";
            this.openTextToolStripMenuItem.Click += new System.EventHandler(this.OnOpenTextClick);
            // 
            // saveToolKmlStripMenuItem
            // 
            this.saveToolKmlStripMenuItem.Name = "saveToolKmlStripMenuItem";
            this.saveToolKmlStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolKmlStripMenuItem.Text = "Save KML";
            this.saveToolKmlStripMenuItem.Click += new System.EventHandler(this.OnSaveKmlClick);
            // 
            // saveTextToolStripMenuItem
            // 
            this.saveTextToolStripMenuItem.Name = "saveTextToolStripMenuItem";
            this.saveTextToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveTextToolStripMenuItem.Text = "Save Text";
            this.saveTextToolStripMenuItem.Click += new System.EventHandler(this.OnSaveTextClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitClick);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countToolStripMenuItem1,
            this.filterToolStripMenuItem1,
            this.processToolStripMenuItem1});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(450, 27);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(587, 541);
            this.textBox1.TabIndex = 1;
            // 
            // kmlFileLabel
            // 
            this.kmlFileLabel.AutoSize = true;
            this.kmlFileLabel.Location = new System.Drawing.Point(12, 30);
            this.kmlFileLabel.Name = "kmlFileLabel";
            this.kmlFileLabel.Size = new System.Drawing.Size(54, 13);
            this.kmlFileLabel.TabIndex = 2;
            this.kmlFileLabel.Text = "KML File: ";
            // 
            // textFileLabel
            // 
            this.textFileLabel.AutoSize = true;
            this.textFileLabel.Location = new System.Drawing.Point(12, 55);
            this.textFileLabel.Name = "textFileLabel";
            this.textFileLabel.Size = new System.Drawing.Size(50, 13);
            this.textFileLabel.TabIndex = 3;
            this.textFileLabel.Text = "Text File:";
            // 
            // countToolStripMenuItem1
            // 
            this.countToolStripMenuItem1.Name = "countToolStripMenuItem1";
            this.countToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.countToolStripMenuItem1.Text = "Count";
            // 
            // filterToolStripMenuItem1
            // 
            this.filterToolStripMenuItem1.Name = "filterToolStripMenuItem1";
            this.filterToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.filterToolStripMenuItem1.Text = "Filter";
            // 
            // processToolStripMenuItem1
            // 
            this.processToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.step1CDATAToolStripMenuItem,
            this.step2ExtractTablesToolStripMenuItem});
            this.processToolStripMenuItem1.Name = "processToolStripMenuItem1";
            this.processToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.processToolStripMenuItem1.Text = "Process";
            // 
            // step1CDATAToolStripMenuItem
            // 
            this.step1CDATAToolStripMenuItem.Name = "step1CDATAToolStripMenuItem";
            this.step1CDATAToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.step1CDATAToolStripMenuItem.Text = "Step 1: CDATA";
            this.step1CDATAToolStripMenuItem.Click += new System.EventHandler(this.OnStepOneClick);
            // 
            // step2ExtractTablesToolStripMenuItem
            // 
            this.step2ExtractTablesToolStripMenuItem.Name = "step2ExtractTablesToolStripMenuItem";
            this.step2ExtractTablesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.step2ExtractTablesToolStripMenuItem.Text = "Step 2: Extract Tables";
            this.step2ExtractTablesToolStripMenuItem.Click += new System.EventHandler(this.OnStepTwoClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 580);
            this.Controls.Add(this.textFileLabel);
            this.Controls.Add(this.kmlFileLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "GeoTest";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openKmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveToolKmlStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTextToolStripMenuItem;
        private System.Windows.Forms.Label kmlFileLabel;
        private System.Windows.Forms.Label textFileLabel;
        private System.Windows.Forms.ToolStripMenuItem countToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem step1CDATAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem step2ExtractTablesToolStripMenuItem;
    }
}

