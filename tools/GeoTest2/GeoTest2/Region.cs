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
    public class Region {
        const int MAX_LEVELS = 10;

        string[] adminNames;
        string[] adminCodes;
        Boundary boundary;

        int levels;
        public int Levels {
            get { return levels; }
        }

        public Region (XmlElement element) {
            adminNames = new string[MAX_LEVELS + 1];
            adminCodes = new string[MAX_LEVELS + 1];
            levels = 0;

            XmlNodeList nodeList = element.GetElementsByTagName("SimpleData");

            foreach (XmlElement node in nodeList) {
                if (node.HasAttribute("name")) {
                    string attribute = node.GetAttribute("name");
                    if (attribute.StartsWith("NAME_")) {
                        string levelString = attribute.Substring(5);
                        int level = Int32.Parse(levelString);
                        if (level > MAX_LEVELS)
                            throw new Exception("Illegal attribute " + attribute);
                        if (level > levels)
                            levels = level;
                        adminNames[level] = node.InnerText;
                    }

                }
                 
                 
            }

            XmlNodeList polyList = element.GetElementsByTagName("coordinates");
            boundary = new Boundary();
            foreach (XmlElement coordNode in polyList) {
                Polygon poly = new Polygon(coordNode.InnerText);
                boundary.Add(poly);
            }


        }

        public override string ToString() {
            string result = "";

            for (int i = 0; i <= levels; i++) {
                result += adminNames[i];
                if (i < levels)
                    result += ", ";
            }
            return result;
        }

        public bool Before(Region region) {
            int n = Math.Min(Levels, region.Levels);
            for (int i = 0; i <= n; i++) {
                int result = adminNames[i].CompareTo(region.adminNames[i]);
                if (result < 0)
                    return true;
                if (result > 0)
                    return false;
            }
            return Levels < region.Levels;
        }

        public void AddToTreeView(TreeView treeView) {
            TreeNodeCollection tnc = treeView.Nodes;

            TreeViewHelper(0, tnc);
        }

        void TreeViewHelper(int d, TreeNodeCollection tnc) {
            if (d > Levels)
                return;

            string name = adminNames[d];
            int pos = tnc.Count - 1;
            bool match = false;
            while (pos >= 0) {
                int res = tnc[pos].Text.CompareTo(name);
                if (res < 0) {
                    match = false;
                    break;
                }
                if (res == 0) {
                    match = true;
                    break;
                }
                pos--;
            }
            if (match) {
                TreeViewHelper(d + 1, tnc[pos].Nodes);
            } else {
                TreeNode node = new TreeNode(name);
                tnc.Insert(pos + 1, node);
                TreeViewHelper(d + 1, node.Nodes);
            }
            
        }

        public void Display(Graphics g, PointF scale, PointF translate) {
            boundary.Display(g, scale, translate);
        }

        public RectangleF Bounds
        {
            get { return boundary.Bounds; }
        }

  
    }
}
