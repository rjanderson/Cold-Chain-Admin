using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Drawing;

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

        public static PointF CenterPoint(RectangleF rect) {
            return new PointF(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
        }

        public static RectangleF MergeRectangles(RectangleF rect1, RectangleF rect2) {
            float minX = Math.Min(rect1.Left, rect2.Left);
            float minY = Math.Min(rect1.Top, rect2.Top);
            float maxX = Math.Max(rect1.Left + rect1.Width, rect2.Left + rect2.Width);
            float maxY = Math.Max(rect1.Top + rect1.Height, rect2.Top + rect2.Height);

            return new RectangleF(minX, minY, maxX - minX, maxY - minY);
        }

        public static float DistF(PointF p1, PointF p2) {
            float dx = p1.X - p2.X;
            float dy = p1.Y - p2.Y;
            return (float) Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
