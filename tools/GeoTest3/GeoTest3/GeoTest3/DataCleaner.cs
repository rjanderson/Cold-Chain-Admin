using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTest3 {
    public class DataCleaner {
        DisplayManager displayManager;

        public DataCleaner(DisplayManager dm) {
            displayManager = dm;
        }

        public void CapitalizeColumn(CsvTable csv, string columnName) {
            if (csv == null)
                return;
            int column = csv.LookupColumn(columnName);
            if (column == -1)
                return;

            csv.dataColumns[column].Capitalize();
            displayManager.DisplayTextFile(csv.dataColumns[column].UniqueElements(), 1000);
        }
    }
}
