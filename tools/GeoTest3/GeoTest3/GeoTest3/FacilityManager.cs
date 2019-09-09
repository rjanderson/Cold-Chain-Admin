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

        public void MatchAllFacilities(CsvTable csv1, CsvTable csv2) {
            List<string> results = new List<string>();

            if (csv1 == null || csv2 == null)
                return;
            AdminTree admin1 = new AdminTree(csv1, applicationOptions.Country);
            admin1.AddFacilityNodes(csv1);
            AdminTree admin2 = new AdminTree(csv2, applicationOptions.Country);
            admin2.AddFacilityNodes(csv2);
            AdminIterator adminNodes = new AdminIterator(admin1);
            foreach (AdminTreeNode node in adminNodes) {
                Console.WriteLine(node.Name);
                if (node.IsFacility) {
                    string path = node.Path;
                    NameSet facilitiesToMatch = admin2.GetFacilities(path);
                    MatchResult result = facilitiesToMatch.FindBestMatch(node.Name);

                    if (GoodMatch(node.Name, result)) {
                        string resultString = path + "\\" + result.ToString();
                        results.Add(resultString);
                    }
                }
            }

            displayManager.DisplayTextFile(results, 10000);                
        }

        private bool GoodMatch(string name, MatchResult result) {
            if (result.Score == 100)
                return true;

            if (result.Score >= name.Length -2)
                return true;

            return false;
        }
   
    }
}
