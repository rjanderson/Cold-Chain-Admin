using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CsvHelper;
using System.Data;
using System.Globalization;


namespace GeoTest3 {
    public class CsvTable {
 //       string[] textDocument;
        string[] headers;
        string filePath;
        int columns;
        int rows;
        int adminLevels;
        int maxAdminLevels;

        string defaultLevel0;

        public CsvColumn[] dataColumns; 

        public CsvTable(string country) {
            defaultLevel0 = country;
            filePath = "";
        }

        public void Load(string filePath) {
           

            List<IDictionary<string, object>> dataRecords;

            using (var reader = new StreamReader(filePath))
            using (var csvReader = new CsvReader(reader)) {
                dataRecords = csvReader.GetRecords<dynamic>()
                       .Select(x => (IDictionary<string, object>)x)
                       .ToList();
            }

            var record0 = dataRecords[0];
            int cols = record0.Count;
            headers = new string[cols];

            int i = 0;
            foreach (var property in record0.Keys) {
                headers[i] = property;
                i++;
            }

            List<string>[] cLists = new List<string>[cols];
            for (i = 0; i < cols; i++)
                cLists[i] = new List<string>();

            foreach (var record in dataRecords) {
                for (i = 0; i < cols; i++) {
                    string str = (string)record[headers[i]];
                    cLists[i].Add(Utilities.CleanString(str));
                }
            }

            columns = cols;
            rows = cLists[0].Count;

            dataColumns = new CsvColumn[cols];
            for (i = 0; i < cols; i++)
                dataColumns[i] = new CsvColumn(cLists[i], headers[i]);

//            createTextDocument();
            setAdminLevels();

        }

        public void setAdminLevels() {
            int levels = -1;
            string levelString;

            do {
                levels++;
                levelString = "Admin " + (levels + 1);
            } while (LookupColumn(levelString) != -1);
            adminLevels = levels;
            maxAdminLevels = levels;
        }

        /*
        private void createTextDocument() {
            textDocument = new string[rows + 1];
            textDocument[0] = headerString();
            for (int i = 0; i < rows; i++)
                textDocument[i + 1] = rowString(i);

        }
        public string[] TextDocument {
            get { return textDocument; }
        }
        */

        public int MaxAdminLevels {
            get { return maxAdminLevels; }
            set { maxAdminLevels = Math.Min(value, adminLevels); }
        }
        public string[] Headers {
            get { return headers; }
        }

        public int Columns {
            get { return columns; }
        }

        public int Rows {
            get { return rows; }
        }

        public string FilePath {
            get { return filePath; }
            set { filePath = value; }
        }

        public List<string> GetAdminPath(int row) {
            List<string> path = new List<string>();
            path.Add(defaultLevel0);
            for (int i = 1; i <= maxAdminLevels; i++) {
                int col = LookupColumn("Admin " + i);
                if (col == -1)
                    throw new Exception("Admin Column missing in GetAdminPath");
                path.Add(dataColumns[col].StringAt(row));
            }

            return path;
        }

        public int LookupColumn(string str) {
            for (int i = 0; i < columns; i++)
                if (headers[i].Equals(str))
                    return i;
            return -1;
        }

        public void Substitute(List<string> parentPath, string columnName, string oldValue, string newValue) {
            int col = LookupColumn(columnName);
            for(int i = 0; i < Rows; i++) {
                if (AdminMatch(parentPath, i)) {
                    if (dataColumns[col].StringAt(i).Equals(oldValue))
                        dataColumns[col].Assign(i, newValue);
                        
                }
            }
        }

        public bool AdminMatch(List<string> path, int row) {
            for(int i = 1; i < path.Count; i++) {
                int col = LookupColumn("Admin " + i);
                if (col == -1)
                    throw new Exception("Admin Column missing in Substitute");
                if (!path[i].Equals(dataColumns[col].StringAt(row)))
                    return false;
            }
            return true;
        }

        public void ReplaceText(string newText, string oldText, int col) {
            dataColumns[col].ReplaceText(newText, oldText);

        }

        public string[] CsvFile() {
            List<string> strings = new List<string>();

            strings.Add(headerString());
            for (int i = 0; i < rows; i++)
                strings.Add(rowString(i));


            return strings.ToArray();
        }

        private string headerString() {
            string rowString = "";

            for (int i = 0; i < columns; i++) {
                rowString += Utilities.QuoteIfNeeded(headers[i]);
                if (i < columns - 1)
                    rowString += ",";
            }


            return rowString;
        }

        private string rowString(int row) {
            string str = "";
            for (int i = 0; i < columns; i++) {  
                str += Utilities.QuoteIfNeeded(dataColumns[i].StringAt(row));
                if (i < columns - 1)
                    str += ",";
            }
            return str;

        }

        public void ExtractTypes(string[] facilityTypes) {
            int facilityColumn = LookupColumn("Facility");
            int typeColumn = LookupColumn("Facility Type");
            if (facilityColumn == -1 || typeColumn == -1)
                return;

            foreach (string facilityType in facilityTypes) {
                for (int row = 0; row < Rows; row++) {
                    string facilityName = dataColumns[facilityColumn].StringAt(row);
                    if (facilityName.StartsWith(facilityType + " ")) {
                        string str = facilityName.Substring(facilityType.Length).Trim();
                        dataColumns[facilityColumn].Assign(row, str);
                        dataColumns[typeColumn].Assign(row, facilityType);
                    }

                }


            }
        }
    }

    public class CsvColumn {
        string[] sData;
        string header;

        public CsvColumn(List<string> data, string header) {
            this.header = header;
            sData = data.ToArray();            
        }

        public void Assign(int row, string str) {
            sData[row] = str;
        }

        public string StringAt(int row) {
            return sData[row];
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append(header + "\r\n");
            for (int i = 0; i < sData.Length; i++) {
                sb.Append(i+1 + ": " + sData[i] + "\r\n");
            }
            return sb.ToString();
        }

        public string[] UniqueElements() {
            string[] data = (string[]) sData.Clone();
            Array.Sort(data);

            List<string> uniqueStrings = new List<string>();
            uniqueStrings.Add(data[0]);
            string str = data[0];

            for (int i = 1; i < data.Length; i++)
                if (!str.Equals(data[i])) {
                    str = data[i];
                    uniqueStrings.Add(str);
                }

            return uniqueStrings.ToArray();
        }

        public void ReplaceText(string newText, string oldText) {
            for (int i = 0; i < sData.Length; i++)
                if (sData[i].Equals(oldText))
                    sData[i] = newText;
        }

        public void Capitalize() {
            for (int i = 0; i < sData.Length; i++)
                sData[i] = Utilities.Capitalize(sData[i]);
        }
    }
}
