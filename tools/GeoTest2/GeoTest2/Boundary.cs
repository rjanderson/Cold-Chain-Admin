using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GeoTest2 {
    public class Boundary {
        List<Polygon> polygons;
        RectangleF bounds;
        public RectangleF Bounds { 
            get { return bounds; }
        }


        public Boundary() {
            polygons = new List<Polygon>();
        }

        public void Add(Polygon poly) {
            polygons.Add(poly);
            
            if (polygons.Count == 1)
                bounds = poly.Bounds;
            else
                bounds = Utilities.MergeRectangles(bounds, poly.Bounds);

  //          MessageBox.Show(poly.Bounds.ToString() +"///" + bounds.ToString());
        }

        public void Display(Graphics g, PointF scale, PointF translate) {
            foreach (Polygon poly in polygons)
                poly.Display(g, scale, translate);
        }

        public string RegionInfo() {
            string info =  "[" + polygons.Count + "{";
            foreach (Polygon poly in polygons)
                info += poly.RegionInfo() + ",";
            return info.Substring(0, info.Length - 1) + "}]";
        }
    }

    public class Polygon : List<PointF> {
 
        public Polygon(string coords) : base() {

            char[] delimiters = { ' ', ',' };
            string[] separate = coords.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < separate.Length; i += 2) {
                try {
                    float longitude = float.Parse(separate[i]);
                    float latitude = float.Parse(separate[i + 1]);

                    this.Add(new PointF(longitude, latitude));
                     
                }
                catch (FormatException) {
                    MessageBox.Show("Formatting error in boundary string");
                }
            }
        }

        public string RegionInfo() {
            string str = "(" + this.Count + ", " + (Distance / this.Count).ToString("0.0000") + ")";
            return str;
        }

        public float Distance {
            get {
                float d = 0.0F;
                for (int i = 0; i < this.Count - 1; i++)
                    d += Utilities.DistF(this[i], this[i + 1]);
                d += Utilities.DistF(this[this.Count - 1], this[0]);

                return d;

            }
        }

        public RectangleF Bounds {
            get {
                if (Count == 0)
                    throw new Exception("Polygon is empty");

                float minX, maxX, minY, maxY;
                minX = maxX = this[0].X;
                minY = maxY = this[0].Y;
                for (int i = 1; i < Count; i++) {
                    minX = Math.Min(this[i].X, minX);
                    maxX = Math.Max(this[i].X, maxX);
                    minY = Math.Min(this[i].Y, minY);
                    maxY = Math.Max(this[i].Y, maxY);
                }

                return new RectangleF(minX, minY, maxX - minX, maxY - minY);
            }

        }

        PointF[] ToPointArray() {
            PointF[] points = new PointF[this.Count];

            for (int i = 0; i < this.Count; i++)
                points[i] = this[i];

            return points;

        }

        public void Display(Graphics g, PointF scale, PointF translate) {

            Pen pen = new Pen(Color.Red);

            PointF[] points = ToPointArray();

            if (points.Length > 1) {
                for (int i = 0; i < points.Length; i++) {
                    PointF p = points[i];
                    points[i] = new PointF(scale.X * p.X + translate.X, scale.Y * p.Y + translate.Y);

                }
                g.DrawPolygon(pen, points);
            }

        }

  
    }


    
 
}
