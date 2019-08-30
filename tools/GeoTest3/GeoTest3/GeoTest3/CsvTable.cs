using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CsvHelper;
using System.Data;


namespace GeoTest3 {
    public class CsvTable {
        string[] textDocument;
        string[] headers;
        string filePath;
        int columns;
        int rows;

        public CsvColumn[] dataColumns; 

        public CsvTable() {

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
            this.headers = new string[cols];

            int i = 0;
            foreach (var property in record0.Keys) {
                this.headers[i] = property;
                i++;
            }

            List<string>[] cLists = new List<string>[cols];
            for (i = 0; i < cols; i++)
                cLists[i] = new List<string>();

            foreach (var record in dataRecords) {
                for (i = 0; i < cols; i++) {
                    string str = (string)record[this.headers[i]];
                    cLists[i].Add(Utilities.CleanString(str));
                }
            }

            this.columns = cols;
            this.rows = cLists[0].Count;

            this.dataColumns = new CsvColumn[cols];
            for (i = 0; i < cols; i++)
                this.dataColumns[i] = new CsvColumn(cLists[i], this.headers[i]);

            createTextDocument();

        }

        private void createTextDocument() {
            this.textDocument = new string[this.rows + 1];
            this.textDocument[0] = headerString();
            for (int i = 0; i < this.rows; i++)
                this.textDocument[i + 1] = this.rowString(i);

        }
        public string[] TextDocument {
            get { return textDocument; }
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

        public int LookupColumn(string str) {
            for (int i = 0; i < this.columns; i++)
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

            for (int i = 0; i < this.columns; i++) {
                rowString += Utilities.QuoteIfNeeded(this.headers[i]);
                if (i < this.columns - 1)
                    rowString += ",";
            }


            return rowString;
        }

        private string rowString(int row) {
            string str = "";
            for (int i = 0; i < this.columns; i++) {  
                str += Utilities.QuoteIfNeeded(this.dataColumns[i].StringAt(row));
                if (i < this.columns - 1)
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
    }
}
