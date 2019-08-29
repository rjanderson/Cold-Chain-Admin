using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GeoTest3 {
    public class CsvTable {
        string[] textDocument;
        string[] headers;
        string filePath;
        int cols;
        int rows;

        public CsvColumn[] columns; 

        public CsvTable() {

        }

        public void Load(string filePath) {
            textDocument = System.IO.File.ReadAllLines(filePath);
            rows = textDocument.Length - 1;

            char[] delimiters = { ',' };
            headers = textDocument[0].Split(delimiters);
            cols = headers.Length;

            columns = new CsvColumn[cols];

            for (int i = 0; i < cols; i++)
                columns[i] = new CsvColumn(rows, headers[i]);

            for (int j = 0; j < rows; j++) {
                string[] rowData = textDocument[j + 1].Split(delimiters);
                for (int i = 0; i < cols; i++) {
                    try {
                        columns[i].Assign(j, rowData[i]);
                    }
                    catch (Exception exception) {
                        MessageBox.Show(exception.Message + "i " + i + " j " + j);
                    };
                }
            }
        }

        public string[] TextDocument {
            get { return textDocument; }
        }

        public string[] Headers {
            get { return headers; }
        }

        public int Cols {
            get { return cols; }
        }

        public int Rows {
            get { return rows; }
        }

        public string FilePath {
            get { return filePath; }
            set { filePath = value; }
        }

        public int LookupColumn(string str) {
            for (int i = 0; i < cols; i++)
                if (headers[i].Equals(str))
                    return i;
            return -1;
        }

        public void Substitute(string newText, string oldText, int col) {
            columns[col].Substitute(newText, oldText );

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

            foreach (string str in headers)
                rowString += str + ",";

            return rowString;
        }

        private string rowString(int row) {
            string str = "";
            for (int i = 0; i < cols; i++)
                str += columns[i].StringAt(row) + ",";

            return str;

        }
    }

    public class CsvColumn {
        string[] sData;
        string header;

        public CsvColumn(int rows, string header) {
            this.header = header;
            sData = new string[rows];            
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
