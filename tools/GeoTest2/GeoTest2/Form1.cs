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

        private void OnExitClick(object sender, EventArgs e) {
            Application.Exit();
        }

        private void OnOpenKmlClick(object sender, EventArgs e) {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var xmlDoc = new XmlDocument();

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

                    this.xmlDocument = xmlDoc;
                    this.textBox1.Text = Utilities.XmlString(this.xmlDocument);
                    this.toolStripFileLabel.Text = "KML File: " + Utilities.TruncateString(filePath, 80);
                }
            }


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
    }
}

