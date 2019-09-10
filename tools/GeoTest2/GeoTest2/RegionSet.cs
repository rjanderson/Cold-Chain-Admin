using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace GeoTest2 {
    public class RegionSet : List<Region> {
        RectangleF bounds;
        public RectangleF Bounds {
            get { return bounds; }
        }

       

        public RegionSet(XmlDocument xmlDocument) {

            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Placemark");
 //           List<Region> regions = new List<Region>();

            foreach (XmlElement element in nodeList) {
                Region region = new Region(element);
                InsertFromEnd(region);
 //               regions.Add(region);
            }

            bounds = this[0].Bounds;
            for (int i = 1; i < this.Count; i++)
                bounds = Utilities.MergeRectangles(bounds, this[i].Bounds);

        }

        public string[] Names() {
                string[] names = new string[this.Count];
                for (int i = 0; i < this.Count; i++)
                    names[i] = this[i].ToString();           

                return names;
        }

        public int Levels {
            get {
                int levels = 0;

                for (int i = 0; i < this.Count; i++)
                    levels = Math.Max(levels, this[i].Levels);
               
                return levels;
            }
        }

        public string CsvHeader {
            get {
                string str = "";

                int levels = Levels;
                for (int i = 0; i <= levels; i++)
                    str += "Admin " + i + ",";
                str += "Latitude,Longitude";

                return str;
            }
        }

        public string[] AdminCsvFile() {
            string[] names = Names();
            string[] csvRows = new string[names.Length + 1];

            csvRows[0] = CsvHeader;
            for (int i = 0; i < names.Length; i++)
                csvRows[i + 1] = names[i];

            return csvRows;
        }

        public string[] RegionInfo {
            get {
                string[] names = new string[this.Count];

                for (int i = 0; i < this.Count; i++)
                    names[i] = this[i].ToString() + " | " + this[i].RegionInfo();

                return names;
            }


        }

        public void InsertFromEnd(Region region) {
            this.Add(region);
            int i = this.Count - 1;
            while (i > 0 && this[i].Before(this[i - 1])){
                Region temp = this[i - 1];
                this[i - 1] = this[i];
                this[i] = temp;
                i--;
            }
        }

        public void LoadTreeView(TreeView treeView) {
            treeView.BeginUpdate();

            treeView.CheckBoxes = true;

            foreach (Region region in this) {
                region.AddToTreeView(treeView);
            }

            treeView.EndUpdate();
        }

        public void Display(Graphics g, PointF scale, PointF translate) {
            g.Clear(Color.Cornsilk);

            foreach (Region region in this) {
                region.Display(g, scale, translate);
            }
        }
    }
}
