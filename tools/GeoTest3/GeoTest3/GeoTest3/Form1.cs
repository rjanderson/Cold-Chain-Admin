using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoTest3 {
    public partial class Form1 : Form {

        CsvTable districts;
        CsvTable csvTable1;

        public Form1() {
            InitializeComponent();
        }

        private void OnHelloButtonClick(object sender, EventArgs e) {
            this.textBox1.Text += " Hello!";
        }

        private void OnDistrictLoad(object sender, EventArgs e) {
            this.districts = LoadCsvTable();
            int col = districts.LookupColumn("Admin 1");
            string[] unique = districts.dataColumns[col].UniqueElements();
            DisplayTextFile(unique, this.textBox1, 100);
            
            this.toolStripFileLabel1.Text = "Admin File: " + Utilities.TruncateString(this.districts.FilePath, 70);
             
        }

        private CsvTable LoadCsvTable() {
             
            string filePath = string.Empty;
            CsvTable csvTable = new CsvTable();
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {

                openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();
                    try {
                        csvTable.Load(filePath);
                        csvTable.FilePath = filePath;
                    }
                    catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    };
                }

                return csvTable;
            }
        }

        private void DisplayTextFile(string[] lines, TextBox textBox, int maxLines) {
            StringBuilder sb = new StringBuilder();

            int max = (lines.Length < maxLines) ? lines.Length : maxLines;

            for (int i = 0; i < max; i++)
                sb.Append(lines[i] + "\r\n");

            textBox.Text = sb.ToString();
        }



        private void OnExit(object sender, EventArgs e) {
            Application.Exit();
        }

        private void OnLoadCsv(object sender, EventArgs e) {
            this.csvTable1 = LoadCsvTable();
            int col = csvTable1.LookupColumn("Admin 1");
            string[] unique = csvTable1.dataColumns[col].UniqueElements();
            DisplayTextFile(unique, this.textBox2, 100);
            this.toolStripFileLabel2.Text = "CSV File: " + Utilities.TruncateString(this.csvTable1.FilePath, 70);
        }

        private void OnSubstituteClick(object sender, EventArgs e) {
            string oldText = this.oldTextBox.Text;
            string newText = this.newTextBox.Text;

            if (oldText.Equals("") || newText.Equals(""))
                return;

            int col = this.csvTable1.LookupColumn("Admin 1");
            this.csvTable1.Substitute(newText, oldText, col);

            string[] unique = csvTable1.dataColumns[col].UniqueElements();
            DisplayTextFile(unique, this.textBox2, 100);
        }

        private void OnSaveCsv(object sender, EventArgs e) {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {

                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK && this.csvTable1 != null) {
                    string filePath = saveFileDialog.FileName;
                    string[] csvFile = this.csvTable1.CsvFile();
                    System.IO.File.WriteAllLines(filePath, csvFile);
                }
            }
        }

        private void OnCsvReaderClick(object sender, EventArgs e) {
            this.csvTable1 = LoadCsvTable();
            DisplayTextFile(this.csvTable1.TextDocument, this.textBox2, 100);
            this.toolStripFileLabel2.Text = "CSV File: " + Utilities.TruncateString(this.csvTable1.FilePath, 70);
        }
    }
}
