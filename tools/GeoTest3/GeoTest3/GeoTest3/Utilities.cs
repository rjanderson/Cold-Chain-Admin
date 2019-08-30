using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GeoTest3 {
    public class Utilities {
        public static string TruncateString(string str, int maxLen) {
            return (str.Length <= maxLen) ? str : "..." + str.Substring(str.Length - maxLen);
        }

        public static string CleanString(string str) {
            string pattern = "[^ -~]+";
            Regex reg_exp = new Regex(pattern);
            string result = reg_exp.Replace(str, "");
            
            return str;
        }

    }
}
