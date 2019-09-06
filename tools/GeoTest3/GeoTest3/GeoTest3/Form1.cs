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

        DisplayManager displayManager;
        DataCleaner dataCleaner;
        FacilityManager facilityManager;


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
            this.displayManager = new DisplayManager(this.textBox1, this.textBox2, this.textBox3, this.listBox1, this.treeView1, this.treeView2);

            this.dataCleaner = new DataCleaner(this.displayManager);
            this.facilityManager = new FacilityManager(this.displayManager, this.appOptions);
        }

        private void OnExit(object sender, EventArgs e) {
            Application.Exit();
        }



        // *** File Management ***
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
                this.displayManager.DisplayTextFile(this.csvTable2.CsvFile());
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




        // *** Interface Management ***
        

        private void LoadHeaderComboBox(string[] headers) {
            this.columnComboBox.Items.Clear();
            for (int i = 0; i < headers.Length; i++)
                this.columnComboBox.Items.Add(headers[i]);
        }




        private void OnColumnSelected(object sender, EventArgs e) {
            string header = this.columnComboBox.Text;
            int column = this.csvTable2.LookupColumn(header);
            this.displayManager.DisplayTextFile(this.csvTable2.dataColumns[column].UniqueElements(), 20000);

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

        private void OnTreeOneSelect(object sender, TreeViewEventArgs e) {
            this.nameSet1 = new NameSet(this.treeView1.SelectedNode);
            this.treeView1.SelectedNode.BackColor = Color.PowderBlue;
            this.textBox1.Text = this.nameSet1.ToString();

        }

        private void OnTreeTwoSelect(object sender, TreeViewEventArgs e) {
            this.nameSet2 = new NameSet(this.treeView2.SelectedNode);
            this.textBox2.Text = this.nameSet2.ToString();
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

        // *** Data Cleaning ***

        private void OnCapitalizeClick(object sender, EventArgs e) {
            this.dataCleaner.CapitalizeColumn(this.csvTable2, this.columnComboBox.Text);
        }

        private void OnSubstituteClick(object sender, EventArgs e) {
            string oldText = this.oldTextBox.Text;
            string newText = this.newTextBox.Text;

            if (oldText.Equals("") || newText.Equals(""))
                return;

            int col = this.csvTable2.LookupColumn("Admin 1");
            this.csvTable2.ReplaceText(newText, oldText, col);

            string[] unique = csvTable2.dataColumns[col].UniqueElements();
            this.displayManager.DisplayTextFile(unique);
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

        // *** FACILITY MANAGEMENT ***

        private void OnMatchNames(object sender, EventArgs e) {
            this.facilityManager.MatchNames(this.nameSet1, this.nameSet2);
        }

        private void OnApplySubstitution(object sender, EventArgs e) {
            this.facilityManager.ApplyNameSubstitutions(this.nameSet2, this.csvTable2, this.listBox1);
        }

        private void OnMatchAllFacilities(object sender, EventArgs e) {
            this.facilityManager.MatchAllFacilities(this.csvTable1, this.csvTable2);
        }
    }
}
