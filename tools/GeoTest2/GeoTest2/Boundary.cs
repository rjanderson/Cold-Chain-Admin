using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GeoTest2 {
    public class Boundary {
        List<Polygon> polygons;

        public Boundary() {
            polygons = new List<Polygon>();
        }

        public void Add(Polygon poly) {
            polygons.Add(poly);
        }

        public void Display(Graphics g) {
            foreach (Polygon poly in polygons)
                poly.Display(g);
        }
    }

    public class Polygon : List<Coord> {
        public Polygon(string coords) : base() {

            char[] delimiters = { ' ', ',' };
            string[] separate = coords.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < separate.Length; i += 2) {
                try {
                    float longitude = float.Parse(separate[i]);
                    float latitude = float.Parse(separate[i + 1]);

                    this.Add(new Coord(longitude, latitude));
                     
                }
                catch (FormatException) {
                    MessageBox.Show("Formatting error in boundary string");
                }
            }
        }

        public void Display(Graphics g) {

            Pen pen = new Pen(Color.Red);

            for (int i = 0; i < Count - 1; i++) {
                g.DrawLine(pen, this[i].Longitude, this[i].Latitude, this[i + 1].Longitude, this[i + 1].Latitude);
            }
        }
    }


    public class Coord {
        public float Longitude;
        public float Latitude;

        public Coord(float longitude, float latitude) {
            Longitude = longitude;
            Latitude = latitude;
        }
    }

 
}
