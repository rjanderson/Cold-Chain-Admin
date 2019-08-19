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

    }

    
}
