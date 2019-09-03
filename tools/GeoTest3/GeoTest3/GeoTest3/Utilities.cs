using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace GeoTest3 {
    public class Utilities {
        public static string TruncateString(string str, int maxLen) {
            return (str.Length <= maxLen) ? str : "..." + str.Substring(str.Length - maxLen);
        }

        public static string CleanString(string str) {
            string pattern = "[^ -~]+";
            Regex reg_exp = new Regex(pattern);
            string result = reg_exp.Replace(str, "");

            return result;
        }

        public static string QuoteIfNeeded(string str) {
            string str1 = str.Replace("\"", "\"\"");
            if (str1.Contains(",") || str1.Contains("\"") || str1.Contains("\n"))
                str1 = "\"" + str1 + "\"";
            return str1;
        }

        public static string Capitalize(string str) {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string str1 = textInfo.ToLower(str);
            string str2 = textInfo.ToTitleCase(str1);
            string str3 = str2.Trim();

            return str3;
        }

        public static int LcsLength(string str1, string str2) {
            int[,] lcs = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i < str1.Length + 1; i++)
                lcs[i, 0] = 0;
            for (int j = 0; j < str2.Length + 1; j++)
                lcs[0, j] = 0;
            for (int i = 1; i < str1.Length + 1; i++)
                for (int j = 1; j < str2.Length + 1; j++) {
                    if (str1[i - 1] == str2[j - 1])
                        lcs[i, j] = lcs[i - 1, j - 1] + 1;
                    else
                        lcs[i, j] = Math.Max(lcs[i, j - 1], lcs[i - 1, j]);
                }


            return lcs[str1.Length, str2.Length];
        }


    }
}
