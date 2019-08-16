using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

        public static XmlDocument FilterNodes(XmlDocument doc, string[] strings) {

            return doc;
        }

    }

    
}
