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

            XmlNode header = doc.FirstChild;

            sb.Append(header.InnerText +"\r\n\r\n");

            XmlNode root = header.NextSibling;

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

        public static void FilterNodes(XmlDocument doc, string[] strings) {

            XmlNode node = doc.FirstChild;
            while (node != null) {
                XmlNode nextNode = node.NextSibling;
                FilterNode(node);

                node = nextNode;
            }

        }

        public static void FilterNode(XmlNode node) {
 
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
