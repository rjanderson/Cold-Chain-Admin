using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;


namespace GeoTest2 {
    public class XmlUtilities {
        public static XmlDocument CompressBoundaries(XmlDocument doc) {
            XmlDocument newDoc = (XmlDocument)doc.Clone();

            XmlNodeList nodeList = newDoc.GetElementsByTagName("coordinates");
            foreach (XmlElement node in nodeList) {
                node.InnerText = UpdateBoundary(node.InnerText);
            }

            return newDoc;
        }

        static string UpdateBoundary(string boundaryString) {
            List<PointF> points = ExtractPoints(boundaryString);
            List<PointF> sparsePoints = SparsifyPoints(points, 0.005F);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sparsePoints.Count; i++) {
                string coordString = " " + sparsePoints[i].X.ToString("F4") + "," + sparsePoints[i].Y.ToString("F4");
                sb.Append(coordString);
            }

            
            return sb.ToString();
        } 

        static List<PointF> ExtractPoints(string str) {
            List<PointF> points = new List<PointF>();
            char[] delimiters = { ' ', ',' };
             
            string[] separate = str.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < separate.Length - 1; i += 2) {
                float longitude = float.Parse(separate[i]);
                float latitude = float.Parse(separate[i + 1]);
                points.Add(new PointF(longitude, latitude));  
            }

            return points;
        }

        static List<PointF> SparsifyPoints(List<PointF> points, float epsilon) {
            List<PointF> sparsePoints = new List<PointF>();

            PointF current = points[0];
            sparsePoints.Add(current);

            for (int i = 1; i < points.Count; i++) {
                if (Utilities.DistF(current, points[i]) > epsilon) {
                    current = points[i];
                    sparsePoints.Add(current);
                }
            }


            return sparsePoints;
        }
    }
}
