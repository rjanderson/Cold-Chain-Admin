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
        string defaultLevel0;

        public CsvColumn[] dataColumns; 

        public CsvTable(string country) {
            defaultLevel0 = country;
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
            for (int i = 1; i <= adminLevels; i++) {
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

        public void Substitute(string newText, string oldText, int col) {
            dataColumns[col].Substitute(newText, oldText );

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

        public void Substitute(string newText, string oldText) {
            for (int i = 0; i < sData.Length; i++)
                if (sData[i].Equals(oldText))
                    sData[i] = newText;
        }

        public void Capitalize() {
            TextInfo textInfo = new CultureInfo("en-US",false).TextInfo;

            for (int i = 0; i < sData.Length; i++) {
                string str1 = textInfo.ToLower(sData[i]);
                string str2 = textInfo.ToTitleCase(str1);
                sData[i] = str2;
            }

        }
    }
}
