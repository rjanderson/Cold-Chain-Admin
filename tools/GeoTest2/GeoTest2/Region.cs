using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
    }
}
