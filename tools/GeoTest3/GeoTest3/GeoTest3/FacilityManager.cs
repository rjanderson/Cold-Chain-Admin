using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoTest3 {
    public class FacilityManager {
        DisplayManager displayManager;
        ApplicationOptions applicationOptions;

        public FacilityManager(DisplayManager dm, ApplicationOptions ao) {
            displayManager = dm;
            applicationOptions = ao;
        }

        public void MatchNames(NameSet ns1, NameSet ns2) {
            if (ns1.FullPath != ns2.FullPath) {
                MessageBox.Show("Paths do not match for OnMatchNames");
                return;
            }
            MatchResultSet result1 = ns1.CompareNames(ns2, applicationOptions.MatchingAlgorithm);
            displayManager.Text1 = result1.ToString();

            MatchResultSet result2 = ns2.CompareNames(ns1, applicationOptions.MatchingAlgorithm);
            displayManager.Text2 = result2.ToString();
            result2.AddToListBox(displayManager.ListBox);
        }

        public void ApplyNameSubstitutions(NameSet ns, CsvTable csv, ListBox lb) {
            List<string> path = ns.ExtractPath;
            string columnName = "Admin " + path.Count;

            foreach (int i in lb.SelectedIndices) {
                string str = lb.Items[i].ToString();
                char[] separator = new char[] { '\\' };
                string[] values = str.Split(separator);
                string oldValue = values[0];
                string newValue = values[1];
                csv.Substitute(path, columnName, oldValue, newValue);
            }
        }

        public MatchResultSet MatchAllFacilities(CsvTable csv1, CsvTable csv2) {
            List<string> results = new List<string>();

            if (csv1 == null || csv2 == null)
                return null;

            AdminTree admin1 = new AdminTree(csv1, applicationOptions.Country);
            admin1.AddFacilityNodes(csv1);
            AdminTree admin2 = new AdminTree(csv2, applicationOptions.Country);
            admin2.AddFacilityNodes(csv2);
            AdminIterator adminNodes = new AdminIterator(admin1);
            MatchResultSet resultsToReturn = new MatchResultSet();

            foreach (AdminTreeNode node in adminNodes) {
                Console.WriteLine(node.Name);
                if (node.IsFacility) {
                    string path = node.Path;
                    NameSet facilitiesToMatch = admin2.GetFacilities(path);
                    MatchResult result = facilitiesToMatch.FindBestMatch(node.Name);

                    if (GoodMatch(node.Name, result)) {
                        string resultString = path + "\\" + result.ToString();
                        results.Add(resultString);
                        result.FullPath = path;
                        resultsToReturn.Add(result);
                    }
                }
            }

            displayManager.DisplayTextFile(results, 10000);
            return resultsToReturn;
        }

        private bool GoodMatch(string name, MatchResult result) {
            if (result.Score == 100)
                return true;

            if (result.Score >= name.Length - 2)
                return true;

            return false;
        }

        // Compute the join of facilities based on the list of results.  This is coded to allow for duplicate facility names which are possible
        public void FacilityJoin(MatchResultSet matches, CsvTable csv1, CsvTable csv2) {
            if (matches == null || csv1 == null || csv2 == null)
                return;

            foreach (MatchResult match in matches.Results) {
                string path = match.FullPath;
                string fac1 = match.Source;
                string fac2 = match.Best;
                List<int> indices1 = csv1.LookupFacilities(path, fac1);
                List<int> indices2 = csv2.LookupFacilities(path, fac2);
                foreach (int row1 in indices1) {
                    foreach (int row2 in indices2) {
                        UpdateColumns(row1, csv1, row2, csv2);
                    }
                }

            }
        }

        // Update columns: Add Lat/Long in table1 from table2 if they are not already present
        // An obvious flaw is we get into trouble with a facility named "x"
        private void UpdateColumns(int row1, CsvTable csv1, int row2, CsvTable csv2) {
            if (csv1.StringAt("Match", row1) == "x") {
                string uid2 = csv2.StringAt("UID", row2);
                string lat2 = csv2.StringAt("Latitude", row2);
                string long2 = csv2.StringAt("Longitude", row2);
                string fac2 = csv2.StringAt("Facility", row2);
                csv1.Assign("Link", row1, uid2);
                csv1.Assign("Match", row1, fac2);
                csv1.Assign("Latitude", row1, lat2);
                csv1.Assign("Longitude", row1, long2);

            }

        }

        // Fill in missing coordinates in Table 1 using district information from Table 2
        public void AddDistrictCoords(CsvTable csv1, CsvTable csv2) {
            if (csv1 == null || csv2 == null)
                return;

            for (int row1 = 0; row1 < csv1.Rows; row1++) {
                if (csv1.StringAt("Match", row1) == "x") {
                    for (int row2 = 0; row2 < csv2.Rows; row2++) {
                        if (csv1.StringAt("Admin 1", row1) == csv2.StringAt("Admin 1", row2) &&
                            csv1.StringAt("Admin 2", row1) == csv2.StringAt("Admin 2", row2)) {
                            string lat2 = csv2.StringAt("Latitude", row2);
                            string long2 = csv2.StringAt("Longitude", row2);
                            csv1.Assign("Latitude", row1, lat2);
                            csv1.Assign("Longitude", row1, long2);
                            csv1.Assign("Match", row1, "District");
                        }
                    }
                }
            }
        }

    }    
}
