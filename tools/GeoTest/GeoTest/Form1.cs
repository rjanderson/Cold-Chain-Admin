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


namespace GeoTest {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public XmlDocument xmlDocument;
        public string[] textDocument;

        public string[] filterStrings = {"Snippet", "color", "extrude"};
        int MaxLines = 50;


        private void OnOpenKmlClick(object sender, EventArgs e) {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var xmlDoc = new XmlDocument();

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
  //              openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();
                    try {
                        xmlDoc.Load(fileStream);
                    }
                    catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    };

                    this.xmlDocument = xmlDoc;
                    this.textBox1.Text = GeoUtils.XmlString(this.xmlDocument);
                }
            }

 //           MessageBox.Show(xmlDoc.ToString(), "File Content at path: " + filePath, MessageBoxButtons.OK);
        }

        private void OnExitClick(object sender, EventArgs e) {
            Application.Exit();
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

        private void OnFilterClick(object sender, EventArgs e) {
            if (this.xmlDocument != null)
                GeoUtils.FilterNodes(this.xmlDocument, filterStrings);
        }

        private void OnCountClick(object sender, EventArgs e) {
            int count = 0;

            if (this.xmlDocument != null)
                count = GeoUtils.CountNodes(this.xmlDocument, "Snippet");

            MessageBox.Show("Count: " + count);

        }

        private void OnOpenTextClick(object sender, EventArgs e) {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var xmlDoc = new XmlDocument();

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
 
                //              openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
 
                    try {
                        this.textDocument  = System.IO.File.ReadAllLines(filePath);

                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    };

                    DisplayTextFile(MaxLines);

                    
                }
            }
        }

        private void OnSaveTextClick(object sender, EventArgs e) {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {

                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    string filePath = saveFileDialog.FileName;
                    System.IO.File.WriteAllLines(filePath, this.textDocument);
                     
                }
            }
        }

        private void OnStepOneClick(object sender, EventArgs e) {
            if (this.textDocument == null)
                return;

            this.textDocument = TextUtils.RemoveEmptyLines(this.textDocument);
            DisplayTextFile(MaxLines);

        }

        private void DisplayTextFile(int maxLines) {
            StringBuilder sb = new StringBuilder();

            int max = (this.textDocument.Length < maxLines) ? this.textDocument.Length : maxLines;

            for (int i = 0; i < max; i++)
                sb.Append(this.textDocument[i] + "\r\n");

            this.textBox1.Text = sb.ToString();

        }
    }
}
