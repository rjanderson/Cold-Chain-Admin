using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;


namespace GeoTest2 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public XmlDocument xmlDocument;
        public RegionSet regions;

        private void OnExitClick(object sender, EventArgs e) {
            Application.Exit();
        }

        private void OnOpenKmlClick(object sender, EventArgs e) {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var xmlDoc = new XmlDocument();
            RegionSet regions; 

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {

                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {

                    filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();
                    try {
                        xmlDoc.Load(fileStream);
                    }
                    catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    };

                    
                    regions = new RegionSet(xmlDoc);
                    this.treeView1.Nodes.Clear();
                    regions.LoadTreeView(this.treeView1);

                    DisplayTextFile(50, regions.Names);
                        
                    this.toolStripFileLabel.Text = "KML File: " + Utilities.TruncateString(filePath, 80);
                    this.xmlDocument = xmlDoc;
                    this.regions = regions;
                    this.mapPanel.Invalidate();
                }
            }
        }

        private void DisplayTextFile(int maxLines, string[] lines) {
            StringBuilder sb = new StringBuilder();

            int max = (lines.Length < maxLines) ? lines.Length : maxLines;

            for (int i = 0; i < max; i++)
                sb.Append(lines[i] + "\r\n");

            this.textBox1.Text = sb.ToString();
        }


        private void OnSaveKmlClick(object sender, EventArgs e) {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {

                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    Stream fileStream;
                    if ((fileStream = saveFileDialog.OpenFile()) != null) {

                        if (this.xmlDocument != null)
                            this.xmlDocument.Save(fileStream);

                        fileStream.Close();
                    }
                }
            }
        }

        private void OnClearTreeViewClick(object sender, EventArgs e) {
            this.treeView1.BeginUpdate();
            this.treeView1.Nodes.Clear();
            this.treeView1.EndUpdate();
        }

        private void OnSelectedItemChanged(object sender, TreeViewEventArgs e) {
            MessageBox.Show(((TreeViewEventArgs) e).ToString());
        }

        private void OnMapPanelPaint(object sender, PaintEventArgs e) {
            if (this.regions != null)
                regions.Display(e.Graphics);
        }
    }
}

