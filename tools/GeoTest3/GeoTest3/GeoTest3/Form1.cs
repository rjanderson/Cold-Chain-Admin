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

        CsvTable csvTable1;
        CsvTable csvTable2;
        NameSet nameSet1;
        NameSet nameSet2;

        AdminTree admin1;
        AdminTree admin2;
        ApplicationOptions appOptions;

        string country = "Pakistan";
        string[] countryFacilities = { "Bhu", "Cd", "Fap", "Rhc", "Ch", "Chak", "Chc", "Civil Hosp", "Dhq Hosp", "Dhq", "Disp", "Epi Center", "Epi Centre",
                                        "Epi", "Gd", "Govt Disp", "Mch Center", "Mch", "Thq Hosp", "Thq" };
        string[] countrySuffixes = { "Fap", "Cd", "Rhc", "Bhu", "Basic Health Unit", "Basic Health Unit." };
        

        public Form1() {
            InitializeComponent();
            InitializeApplication();
        }

        private void InitializeApplication() {
            this.csvTable1 = new CsvTable(country);
            this.csvTable2 = new CsvTable(country);
            this.nameSet1 = new NameSet();
            this.nameSet2 = new NameSet();

            this.appOptions = new ApplicationOptions();
        }


        private void OnCsvOneLoad(object sender, EventArgs e) {
            this.csvTable1 = LoadCsvTable();
            if (this.csvTable1 != null) {

                this.csvTable1.MaxAdminLevels = 2;
                this.toolStripFileLabel1.Text = "CSV One: " + Utilities.TruncateString(this.csvTable1.FilePath, 70);

                this.admin1 = new AdminTree(this.csvTable1, country);
                if (this.appOptions.IncludeFacilities)
                    this.admin1.AddFacilityNodes(this.csvTable1);
                this.admin1.BuildTreeView(this.treeView1);
            }

        }

        private void OnLoadCsvTwo(object sender, EventArgs e) {
            this.csvTable2 = LoadCsvTable();
            if (this.csvTable2 != null) {

                this.csvTable2.MaxAdminLevels = 2;
                DisplayTextFile(this.csvTable2.CsvFile(), this.textBox3, 100);
                LoadHeaderComboBox(csvTable2.Headers);

                this.admin2 = new AdminTree(this.csvTable2, country);
                if (this.appOptions.IncludeFacilities)
                    this.admin2.AddFacilityNodes(this.csvTable2);

                this.admin2.BuildTreeView(this.treeView2);

                this.toolStripFileLabel2.Text = "CSV Two: " + Utilities.TruncateString(this.csvTable2.FilePath, 70);
            }
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

            int col = this.csvTable2.LookupColumn("Admin 1");
            this.csvTable2.ReplaceText(newText, oldText, col);

            string[] unique = csvTable2.dataColumns[col].UniqueElements();
            DisplayTextFile(unique, this.textBox3, 100);   
        }

        private void OnCsvReaderClick(object sender, EventArgs e) {
            this.csvTable2 = LoadCsvTable();
            DisplayTextFile(this.csvTable2.CsvFile(), this.textBox3, 100);
            this.toolStripFileLabel2.Text = "CSV File: " + Utilities.TruncateString(this.csvTable2.FilePath, 70);
        }

        private void OnColumnSelected(object sender, EventArgs e) {
            string header = this.columnComboBox.Text;
            int column = this.csvTable2.LookupColumn(header);
            DisplayTextFile(this.csvTable2.dataColumns[column].UniqueElements(), this.textBox3, 20000);

        }

        private void OnCapitalizeClick(object sender, EventArgs e) {
            string columnName = this.columnComboBox.Text;
            int column = this.csvTable2.LookupColumn(columnName);

            if (column != -1) {
                this.csvTable2.dataColumns[column].Capitalize();
                DisplayTextFile(this.csvTable2.dataColumns[column].UniqueElements(), this.textBox3, 1000);
            }
        }

        private void OnIncludeFacilitiesClick(object sender, EventArgs e) {
            if (this.appOptions.IncludeFacilities) {
                this.appOptions.IncludeFacilities = false;
                this.includeFacilitiesToolStripMenuItem.Checked = false;
            }
            else {
                this.appOptions.IncludeFacilities = true;
                this.includeFacilitiesToolStripMenuItem.Checked = true;
            }
        }

        private void OnSaveCsvOne(object sender, EventArgs e) {
            SaveCsv(this.csvTable1);
        }

        private void OnSaveCsvTwo(object sender, EventArgs e) {
            SaveCsv(this.csvTable2);
        }

        private void SaveCsv(CsvTable csvTable) {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()) {

                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK && this.csvTable2 != null) {
                    string filePath = saveFileDialog.FileName;
                    string[] outputTable = csvTable.CsvFile();
                    System.IO.File.WriteAllLines(filePath, outputTable);
                }
            }
        }

        private void OnTreeOneSelect(object sender, TreeViewEventArgs e) {
            this.nameSet1 = new NameSet(this.treeView1.SelectedNode);
            this.textBox1.Text = this.nameSet1.ToString();

        }

        private void OnTreeTwoSelect(object sender, TreeViewEventArgs e) {
            this.nameSet2 = new NameSet(this.treeView2.SelectedNode);
            this.textBox2.Text = this.nameSet2.ToString();
        }

        private void OnMatchNames(object sender, EventArgs e) {
            if (!this.nameSet1.FullPath.Equals(this.nameSet2.FullPath)) {
                MessageBox.Show("Paths do not match for OnMatchNames");
                return;
            }
            MatchResult result1 = this.nameSet1.CompareNames(nameSet2, this.appOptions.MatchingAlgorithm);
            this.textBox1.Text = result1.ToString();

            MatchResult result2 = this.nameSet2.CompareNames(nameSet1, this.appOptions.MatchingAlgorithm);
            this.textBox2.Text = result2.ToString();
            result2.AddToListBox(this.listBox1);
        }

        private void OnEditDistanceMatching(object sender, EventArgs e) {
            if (this.appOptions.MatchingAlgorithm == NameSet.Algorithm.Basic) {
                this.appOptions.MatchingAlgorithm = NameSet.Algorithm.LCS;
                this.editDistianceMatchingToolStripMenuItem.Checked = true;
            }
            else {
                this.appOptions.MatchingAlgorithm = NameSet.Algorithm.Basic;
                this.editDistianceMatchingToolStripMenuItem.Checked = false;
            }
        }

        private void OnApplySubstitution(object sender, EventArgs e) {
            List<string> path = this.nameSet2.ExtractPath;
            string columnName = "Admin " + path.Count;

            foreach (int i in this.listBox1.SelectedIndices) {
                string str = this.listBox1.Items[i].ToString();
                char[] separator = new char[] { '\\' };
                string[] values = str.Split(separator);
                string oldValue = values[0];
                string newValue = values[1];
                this.csvTable2.Substitute(path, columnName, oldValue, newValue);
            }
        }

        private void OnExtractTypes(object sender, EventArgs e) {
            if (this.csvTable2 != null) {
                this.csvTable2.ExtractTypes(this.countryFacilities);
            }
        }

        private void OnFilterRowClick(object sender, EventArgs e) {
            if (this.csvTable2 != null) {
                string columnName = this.columnComboBox.Text;
                string removeString = this.oldTextBox.Text;
                this.csvTable2.FilterRows(columnName, removeString);
            }

        }

        private void OnRemoveSuffixClick(object sender, EventArgs e) {
            if (this.csvTable2 != null) {
                this.csvTable2.RemoveSuffixes(this.countrySuffixes);
            }
        }
    }
}
