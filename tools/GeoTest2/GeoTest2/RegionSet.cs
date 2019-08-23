using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GeoTest2 {
    public class RegionSet : List<Region> {



        public RegionSet(XmlDocument xmlDocument) {

            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Placemark");

            foreach (XmlElement element in nodeList) {
                Region region = new Region(element);
                this.Add(region);
            }

        }

        public string[] Names {
            get {
                string[] names = new string[this.Count];

                for (int i = 0; i < this.Count; i++)
                    names[i] = this[i].ToString();

                return names;
            }


        }
    }
}
