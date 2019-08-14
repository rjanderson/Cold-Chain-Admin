﻿using System;
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

        private void OnFileOpenClick(object sender, EventArgs e) {
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
                    catch (Exception) { };

                    
                }
            }

            MessageBox.Show(xmlDoc.ToString(), "File Content at path: " + filePath, MessageBoxButtons.OK);
        }

        private void OnExitClick(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
