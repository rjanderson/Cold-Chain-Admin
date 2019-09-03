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

        public NameSet.Algorithm matchingAlgorithm;
        public NameSet.Algorithm MatchingAlgorithm {
            get { return this.matchingAlgorithm; }
            set { this.matchingAlgorithm = value; }
        }
        public ApplicationOptions() {
            this.inlcudeFacilities = false;
            this.matchingAlgorithm = NameSet.Algorithm.Basic;

        }
    }
}
