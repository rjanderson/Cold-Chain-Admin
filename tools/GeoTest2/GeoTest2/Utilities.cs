using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GeoTest2 {
    class Utilities {

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
                    Traverse(node.ChildNodes[i], sb, d + 1);
                }
            }

        }

        public static string TruncateString(string str, int maxLen) {
            return (str.Length <= maxLen) ? str : "..." + str.Substring(str.Length - maxLen);
        }
    }
}
