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
                if (lines[i].Contains("<table")) {
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
            newLines.Add("<ExtendedData><SchemeData>");
            while (!lines[i].Contains("<table")) {
                string data = ExtractItem(lines[i]);
                if (data != null) {
                    newLines.Add("<RegionName>" + data + "</RegionName>");
                }
                i++;
            }
            i++;
            AdminBlock adminBlock = new AdminBlock();
            while (!lines[i].Contains("</table>")) {
                adminBlock.Process(lines[i]);
                i++;
            }
            newLines.AddRange(adminBlock.ToKml());
            i++;
            while (!lines[i].Contains("</table>"))
                i++;
            newLines.Add("</SchemeData></ExtendedData>");
            return i + 1;


        }

        public static string ExtractItem(string line) {
            int index = line.IndexOf("<td>");
            if (index > -1 && line.EndsWith("</td>"))
                return line.Substring(index + 4, line.Length - index - 9);
            return null;
        }

        class AdminBlock {
            enum state {initial, n1, c1, n2, c2, n3, c3 };

            state State = state.initial;

            string name3;
            string code3;
            string name2;
            string code2;
            string name1;
            string code1;

            public List<string> ToKml() {
                List<string> result = new List<string>();
                
 
                if (name1 != null) {
                    result.Add("<SimpleData name=\"NAME_1\" >"+ name1 + "</SimpleData>");
                    result.Add("<SimpleData name=\"CODE_1\" >" + code1 + "</SimpleData>");
                }
                if (name2 != null) {
                    result.Add("<SimpleData name=\"NAME_2\" >" + name2 + "</SimpleData>");
                    result.Add("<SimpleData name=\"CODE_2\" >" + code2 + "</SimpleData>");
                } 
                if (name3 != null) {
                    result.Add("<SimpleData name=\"NAME_3\" >" + name3 + "</SimpleData>");
                    result.Add("<SimpleData name=\"CODE_3\" >" + code3 + "</SimpleData>");
                }
                return result;
            }

            public void Process(string line) {
                string str = TextUtils.ExtractItem(line);
                if (str == null)
                    return;

                switch (State) {
                    case state.initial:
                        if (str.Equals("admin1Name_en"))
                            State = state.n1;
                        else if (str.Equals("admin1Pcode"))
                            State = state.c1;
                        else if (str.Equals("admin2Name_en"))
                            State = state.n2;
                        else if (str.Equals("admin2Pcode"))
                            State = state.c2;
                        else if (str.Equals("admin3Name_en"))
                            State = state.n3;
                        else if (str.Equals("admin3Pcode"))
                            State = state.c3;
                        break;
                    case state.n1:
                        name1 = str;
                        State = state.initial;
                        break;
                    case state.c1:
                        code1 = str;
                        State = state.initial;
                        break;
                    case state.n2:
                        name2 = str;
                        State = state.initial;
                        break;
                    case state.c2:
                        code2 = str;
                        State = state.initial;
                        break;
                    case state.n3:
                        name3 = str;
                        State = state.initial;
                        break;
                    case state.c3:
                        code3 = str;
                        State = state.initial;
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
