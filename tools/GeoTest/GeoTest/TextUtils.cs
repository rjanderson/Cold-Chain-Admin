using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTest {
    class TextUtils {
        public static string[] RemoveEmptyLines(string[] lines) {
            List<string> newLines = new List<string>();

            foreach (string line in lines) {
                if (line.Length > 0)
                    newLines.Add(line);
            }

            return newLines.ToArray();
        }

        public static string[] RemoveLine(string[] lines, string str) {
            List<string> newLines = new List<string>();

            foreach (string line in lines) {
                if (!line.StartsWith(str))  
                    newLines.Add(line);
            }

            return newLines.ToArray();

        }

        public static string[] RemoveSubstring(string[] lines, string str) {
            List<string> newLines = new List<string>();

            foreach (string line in lines) {
                int index = line.IndexOf(str);
                if (index == -1)
                    newLines.Add(line);
                else
                    newLines.Add(line.Remove(index, str.Length));
            }

            return newLines.ToArray();
            
        }

        public static string TruncateString(string str, int maxLen) {
            return (str.Length <= maxLen) ? str : "..." + str.Substring(str.Length - maxLen);
        }

        public static string[] ExtractTables(string[] lines) {
            List<string> newLines = new List<string>();

            int i = 0;
            while (i < lines.Length){
                if (lines[i].StartsWith("<table")) {
                    i = ProcessTable(lines, i, newLines);
                }
                else {
                    newLines.Add(lines[i]);
                    i++;
                }

            }

            return newLines.ToArray();

        }

        static int ProcessTable(string[] lines, int index, List<string> newLines) {
            int i = index + 1;
            newLines.Add("<AdminRegion>");
            while (!lines[i].StartsWith("<table")) {
                string data = ExtractItem(lines[i]);
                if (data != null) {
                    newLines.Add("<RegionName>" + data + "</RegionName>");
                }
                i++;
            }
            i++;
            while (!lines[i].StartsWith("</table>"))
                i++;
            i++;
            while (!lines[i].StartsWith("</table>"))
                i++;
            newLines.Add("</AdminRegion>");
            return i + 1;


        }

        static string ExtractItem(string line) {
            if (line.StartsWith("<td>") && line.EndsWith("</td>"))
                return line.Substring(4, line.Length - 9);
            return null;
        }
    }
}
