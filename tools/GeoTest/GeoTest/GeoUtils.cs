using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;


namespace GeoTest {
    class GeoUtils {
        public static String XmlString(XmlDocument doc) {
            StringBuilder sb = new StringBuilder();

            XmlNode root = doc.DocumentElement;

            Traverse(root, sb, 0);


           


            return sb.ToString();
        }

        static void Traverse(XmlNode node, StringBuilder sb, int d) {
            sb.Append(d + ": " + node.Name + "\r\n");
            if (node.HasChildNodes) {
                for (int i = 0; i < node.ChildNodes.Count; i++) {
                    Traverse(node.ChildNodes[i], sb, d+1);
                }
            }

        }

        public static void FilterNodes(XmlDocument doc, string[]  strings) {

            XmlElement root = doc.DocumentElement;
            // Note that this will not filter the root node if it matches the string
            foreach (var str in strings)
                FilterNodes(root, str);
        }

        public static void FilterNodes(XmlNode element, string str) {
                
            if (element.HasChildNodes) {
                int count = element.ChildNodes.Count;
                int i = 0;

                while (i < count) {
                    XmlNode childNode = element.ChildNodes[i];
                    if (String.Equals(childNode.Name, str)) {
                        element.RemoveChild(childNode);
                        count--;
                    } else {
                        FilterNodes(childNode, str);
                        i++;
                    }
                }
            }

        }

        public static int CountNodes(XmlDocument doc, string str) {
            XmlElement root = doc.DocumentElement;

            return CountNodes(root, str);
        }

        public static int CountNodes(XmlNode element, string str) {
       

            int count = 0;
            if (String.Equals(element.Name, str))
                count = 1;


            if (element.HasChildNodes) {
                for (int i = 0; i < element.ChildNodes.Count; i++) {
                    count += CountNodes(element.ChildNodes[i], str);
                }
            }

            return count;
        }

        public static string[] ExtractAdminTable(XmlDocument doc) {

            List<string> lineList = new List<string>();
            string headerString = "Region Name,  Level 1 Name,  Level 1 Code, Level 2 Name, Level 2 Code, Level 3 Name, Level 3 Code,";
            lineList.Add(headerString);

            XmlNodeList nodeList = doc.GetElementsByTagName("AdminRegion");
            foreach (XmlElement node in nodeList) {
                lineList.Add(GetAdminData(node));
            }

            return lineList.ToArray();
        }

        static string GetAdminData(XmlElement node) {
            string rowString = "";

            XmlNodeList nodeList = node.GetElementsByTagName("RegionName");
            if (nodeList.Count > 0)
                rowString = nodeList[0].InnerText + ", ";
            else
                rowString = ",";

            string[] outerList = { "Level1", "Level2", "Level3" };
            string[] innerList = { "Name", "Code"};

            foreach (string str1 in outerList) {
                XmlNodeList nodeList1 = node.GetElementsByTagName(str1);
                if (nodeList1.Count > 0) {
                    foreach (string str2 in innerList) {
                        XmlNodeList nodeList2 = ((XmlElement) nodeList1[0]).GetElementsByTagName(str2);
                        if (nodeList2.Count > 0)
                            rowString += nodeList2[0].InnerText + ", ";
                        else
                            rowString += ", ";
                    }
                }
                else
                    rowString += ", , ";

            }

            return rowString;
        }

        public static XmlDocument UpdateRegionBoundaries(XmlDocument doc) {
            XmlDocument newDoc = (XmlDocument)doc.Clone();

            XmlNodeList nodeList = newDoc.GetElementsByTagName("coordinates");
            foreach (XmlElement node in nodeList) {
                node.InnerText = UpdateBoundary(node.InnerText);
            }

            return newDoc;
        }

        static string UpdateBoundary(string boundaryString) {
            char[] delimiters = { ' ', ',' };
            StringBuilder sb = new StringBuilder();

            string[] separate = boundaryString.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < separate.Length; i += 3) {
                try {
                    decimal longitude = decimal.Parse(separate[i]);
                    decimal latitude = decimal.Parse(separate[i + 1]);
                    decimal altitude = decimal.Parse(separate[i + 2]);

                    string coordString = " " + longitude.ToString("F4") + ","+ latitude.ToString("F4") + ","+ altitude.ToString();  
                    sb.Append(coordString);
                }
                catch (FormatException) {
                    MessageBox.Show("Formatting error in boundary string");
                    return "Format Error";

                }
            }
            return sb.ToString();
        }

    }

    
}
