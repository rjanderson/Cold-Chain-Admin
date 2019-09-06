namespace GeoTest3 {
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDistrictsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCSV2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applySubstitutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.substituteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capitalizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractFaciltiyTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSuffixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeFacilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDistianceMatchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripFileLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripFileLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.newTextBox = new System.Windows.Forms.TextBox();
            this.oldTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.columnComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.matchButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.matchAllFacilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 79);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(245, 332);
            this.textBox1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1409, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDistrictsToolStripMenuItem,
            this.loadCSVToolStripMenuItem,
            this.saveCSVToolStripMenuItem,
            this.saveCSV2ToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadDistrictsToolStripMenuItem
            // 
            this.loadDistrictsToolStripMenuItem.Name = "loadDistrictsToolStripMenuItem";
            this.loadDistrictsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.loadDistrictsToolStripMenuItem.Text = "Load CSV 1";
            this.loadDistrictsToolStripMenuItem.Click += new System.EventHandler(this.OnCsvOneLoad);
            // 
            // loadCSVToolStripMenuItem
            // 
            this.loadCSVToolStripMenuItem.Name = "loadCSVToolStripMenuItem";
            this.loadCSVToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.loadCSVToolStripMenuItem.Text = "Load CSV 2";
            this.loadCSVToolStripMenuItem.Click += new System.EventHandler(this.OnLoadCsvTwo);
            // 
            // saveCSVToolStripMenuItem
            // 
            this.saveCSVToolStripMenuItem.Name = "saveCSVToolStripMenuItem";
            this.saveCSVToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.saveCSVToolStripMenuItem.Text = "Save CSV 1";
            this.saveCSVToolStripMenuItem.Click += new System.EventHandler(this.OnSaveCsvOne);
            // 
            // saveCSV2ToolStripMenuItem
            // 
            this.saveCSV2ToolStripMenuItem.Name = "saveCSV2ToolStripMenuItem";
            this.saveCSV2ToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.saveCSV2ToolStripMenuItem.Text = "Save CSV 2";
            this.saveCSV2ToolStripMenuItem.Click += new System.EventHandler(this.OnSaveCsvTwo);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExit);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matchAllFacilitiesToolStripMenuItem,
            this.matchToolStripMenuItem,
            this.applySubstitutionToolStripMenuItem,
            this.toolStripSeparator4,
            this.substituteToolStripMenuItem,
            this.capitalizeToolStripMenuItem,
            this.extractFaciltiyTypesToolStripMenuItem,
            this.removeSuffixToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.toolStripSeparator3,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator2});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // matchToolStripMenuItem
            // 
            this.matchToolStripMenuItem.Name = "matchToolStripMenuItem";
            this.matchToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.matchToolStripMenuItem.Text = "Match Names";
            this.matchToolStripMenuItem.Click += new System.EventHandler(this.OnMatchNames);
            // 
            // applySubstitutionToolStripMenuItem
            // 
            this.applySubstitutionToolStripMenuItem.Name = "applySubstitutionToolStripMenuItem";
            this.applySubstitutionToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.applySubstitutionToolStripMenuItem.Text = "Apply Substitution";
            this.applySubstitutionToolStripMenuItem.Click += new System.EventHandler(this.OnApplySubstitution);
            // 
            // substituteToolStripMenuItem
            // 
            this.substituteToolStripMenuItem.Name = "substituteToolStripMenuItem";
            this.substituteToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.substituteToolStripMenuItem.Text = "Substitute";
            this.substituteToolStripMenuItem.Click += new System.EventHandler(this.OnSubstituteClick);
            // 
            // capitalizeToolStripMenuItem
            // 
            this.capitalizeToolStripMenuItem.Name = "capitalizeToolStripMenuItem";
            this.capitalizeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.capitalizeToolStripMenuItem.Text = "Capitalize";
            this.capitalizeToolStripMenuItem.Click += new System.EventHandler(this.OnCapitalizeClick);
            // 
            // extractFaciltiyTypesToolStripMenuItem
            // 
            this.extractFaciltiyTypesToolStripMenuItem.Name = "extractFaciltiyTypesToolStripMenuItem";
            this.extractFaciltiyTypesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.extractFaciltiyTypesToolStripMenuItem.Text = "Extract Faciltiy Types";
            this.extractFaciltiyTypesToolStripMenuItem.Click += new System.EventHandler(this.OnExtractTypes);
            // 
            // removeSuffixToolStripMenuItem
            // 
            this.removeSuffixToolStripMenuItem.Name = "removeSuffixToolStripMenuItem";
            this.removeSuffixToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.removeSuffixToolStripMenuItem.Text = "Remove Suffixes";
            this.removeSuffixToolStripMenuItem.Click += new System.EventHandler(this.OnRemoveSuffixClick);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.filterToolStripMenuItem.Text = "Filter Rows";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.OnFilterRowClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(179, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.includeFacilitiesToolStripMenuItem,
            this.editDistianceMatchingToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // includeFacilitiesToolStripMenuItem
            // 
            this.includeFacilitiesToolStripMenuItem.Name = "includeFacilitiesToolStripMenuItem";
            this.includeFacilitiesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.includeFacilitiesToolStripMenuItem.Text = "Include Facilities";
            this.includeFacilitiesToolStripMenuItem.Click += new System.EventHandler(this.OnIncludeFacilitiesClick);
            // 
            // editDistianceMatchingToolStripMenuItem
            // 
            this.editDistianceMatchingToolStripMenuItem.Checked = true;
            this.editDistianceMatchingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.editDistianceMatchingToolStripMenuItem.Name = "editDistianceMatchingToolStripMenuItem";
            this.editDistianceMatchingToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.editDistianceMatchingToolStripMenuItem.Text = "LCS Matching";
            this.editDistianceMatchingToolStripMenuItem.Click += new System.EventHandler(this.OnEditDistanceMatching);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(179, 6);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFileLabel1,
            this.toolStripFileLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 830);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1409, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripFileLabel1
            // 
            this.toolStripFileLabel1.Name = "toolStripFileLabel1";
            this.toolStripFileLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripFileLabel2
            // 
            this.toolStripFileLabel2.Name = "toolStripFileLabel2";
            this.toolStripFileLabel2.Size = new System.Drawing.Size(0, 22);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(263, 79);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(264, 332);
            this.textBox2.TabIndex = 4;
            // 
            // newTextBox
            // 
            this.newTextBox.Location = new System.Drawing.Point(1264, 45);
            this.newTextBox.Name = "newTextBox";
            this.newTextBox.Size = new System.Drawing.Size(126, 20);
            this.newTextBox.TabIndex = 5;
            // 
            // oldTextBox
            // 
            this.oldTextBox.Location = new System.Drawing.Point(1049, 45);
            this.oldTextBox.Name = "oldTextBox";
            this.oldTextBox.Size = new System.Drawing.Size(128, 20);
            this.oldTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(974, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Old Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1190, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "New Text";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 430);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(245, 397);
            this.treeView1.TabIndex = 9;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTreeOneSelect);
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(263, 430);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(264, 397);
            this.treeView2.TabIndex = 10;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTreeTwoSelect);
            // 
            // columnComboBox
            // 
            this.columnComboBox.FormattingEnabled = true;
            this.columnComboBox.Location = new System.Drawing.Point(835, 42);
            this.columnComboBox.Name = "columnComboBox";
            this.columnComboBox.Size = new System.Drawing.Size(121, 21);
            this.columnComboBox.TabIndex = 11;
            this.columnComboBox.SelectedIndexChanged += new System.EventHandler(this.OnColumnSelected);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(782, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Columns";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(269, 414);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "CSV Two";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "CSV One";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(775, 79);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(622, 748);
            this.textBox3.TabIndex = 15;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(543, 79);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(211, 342);
            this.listBox1.TabIndex = 16;
            // 
            // matchButton
            // 
            this.matchButton.Location = new System.Drawing.Point(12, 27);
            this.matchButton.Name = "matchButton";
            this.matchButton.Size = new System.Drawing.Size(89, 23);
            this.matchButton.TabIndex = 17;
            this.matchButton.Text = "Match Names";
            this.matchButton.UseVisualStyleBackColor = true;
            this.matchButton.Click += new System.EventHandler(this.OnMatchNames);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(119, 27);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 18;
            this.applyButton.Text = "Apply ";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.OnApplySubstitution);
            // 
            // matchAllFacilitiesToolStripMenuItem
            // 
            this.matchAllFacilitiesToolStripMenuItem.Name = "matchAllFacilitiesToolStripMenuItem";
            this.matchAllFacilitiesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.matchAllFacilitiesToolStripMenuItem.Text = "Match All Facilities";
            this.matchAllFacilitiesToolStripMenuItem.Click += new System.EventHandler(this.OnMatchAllFacilities);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(179, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 855);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.matchButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.columnComboBox);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.oldTextBox);
            this.Controls.Add(this.newTextBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Geo3";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDistrictsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripFileLabel1;
        private System.Windows.Forms.ToolStripMenuItem loadCSVToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripLabel toolStripFileLabel2;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem substituteToolStripMenuItem;
        private System.Windows.Forms.TextBox newTextBox;
        private System.Windows.Forms.TextBox oldTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem saveCSVToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.ComboBox columnComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem capitalizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeFacilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveCSV2ToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ToolStripMenuItem matchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDistianceMatchingToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button matchButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.ToolStripMenuItem applySubstitutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractFaciltiyTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSuffixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matchAllFacilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

