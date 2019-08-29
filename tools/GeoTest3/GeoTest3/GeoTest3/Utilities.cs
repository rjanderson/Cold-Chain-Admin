using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTest3 {
    public class Utilities {
        public static string TruncateString(string str, int maxLen) {
            return (str.Length <= maxLen) ? str : "..." + str.Substring(str.Length - maxLen);
        }

    }
}
