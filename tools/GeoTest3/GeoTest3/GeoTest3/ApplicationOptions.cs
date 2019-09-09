using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTest3 {
    public class ApplicationOptions {

        private bool inlcudeFacilities;
        public bool IncludeFacilities {
            get { return this.inlcudeFacilities; }
            set { this.inlcudeFacilities = value; }
        }

        private NameSet.Algorithm matchingAlgorithm;
        public NameSet.Algorithm MatchingAlgorithm {
            get { return this.matchingAlgorithm; }
            set { this.matchingAlgorithm = value; }
        }

        private string country;
        public string Country {
            get { return this.country; }
            set { this.country = value; }
        }
            
        public ApplicationOptions() {
            this.inlcudeFacilities = true;
            this.matchingAlgorithm = NameSet.Algorithm.LCS;
            this.country = "Pakistan";
        }
    }
}
