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
        AdminTree adminDistricts;
        AdminTree admin2;

        string country = "Pakistan";

        public Form1() {
            InitializeComponent();

        }


        private void OnDistrictLoad(object sender, EventArgs e) {
            this.districts = LoadCsvTable();
            int col = districts.LookupColumn("Admin 1");
            string[] unique = districts.dataColumns[col].UniqueElements();
            DisplayTextFile(unique, this.textBox1, 100);
            
            this.toolStripFileLabel1.Text = "Admin File: " + Utilities.TruncateString(this.districts.FilePath, 70);

            this.adminDistricts = new AdminTree(this.districts, country);
            this.adminDistricts.BuildTreeView(this.treeView1);

        }

        private CsvTable LoadCsvTable() {
             
            string filePath = string.Empty;
            CsvTable csvTable = new CsvTable(country);
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
            if (this.csvTable1 != null) {
                /*
                int col = csvTable1.LookupColumn("Admin 1");
                if (col != -1) {
                    string[] unique = csvTable1.dataColumns[col].UniqueElements();
                    DisplayTextFile(unique, this.textBox2, 100);
                    this.toolStripFileLabel2.Text = "CSV File: " + Utilities.TruncateString(this.csvTable1.FilePath, 70);
                } */

                DisplayTextFile(this.csvTable1.CsvFile(), this.textBox2, 100);
                LoadHeaderComboBox(csvTable1.Headers);

                this.admin2 = new AdminTree(this.csvTable1, country);
                this.admin2.BuildTreeView(this.treeView2);
            }
        }

        private void LoadHeaderComboBox(string[] headers) {
            this.columnComboBox.Items.Clear();
            for (int i = 0; i < headers.Length; i++)
                this.columnComboBox.Items.Add(headers[i]);
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
            DisplayTextFile(this.csvTable1.CsvFile(), this.textBox2, 100);
            this.toolStripFileLabel2.Text = "CSV File: " + Utilities.TruncateString(this.csvTable1.FilePath, 70);
        }

        private void OnColumnSelected(object sender, EventArgs e) {
            string header = this.columnComboBox.Text;
            int column = this.csvTable1.LookupColumn(header);
            DisplayTextFile(this.csvTable1.dataColumns[column].UniqueElements(), this.textBox2, 1000);

        }

        private void OnCapitalizeClick(object sender, EventArgs e) {
            string columnName = this.columnComboBox.Text;
            int column = this.csvTable1.LookupColumn(columnName);

            if (column != -1) {
                this.csvTable1.dataColumns[column].Capitalize();
                DisplayTextFile(this.csvTable1.dataColumns[column].UniqueElements(), this.textBox2, 1000);
            }
        }
    }
}
