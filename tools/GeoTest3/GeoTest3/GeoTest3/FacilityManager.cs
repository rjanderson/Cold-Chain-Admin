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
            MatchResult result1 = ns1.CompareNames(ns2, applicationOptions.MatchingAlgorithm);
            displayManager.Text1 = result1.ToString();

            MatchResult result2 = ns2.CompareNames(ns1, applicationOptions.MatchingAlgorithm);
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
    }
}
