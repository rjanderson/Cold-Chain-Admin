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
            XmlElement root = doc.DocumentElement;

            List<string> lineList = new List<string>();
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

    }

    
}
