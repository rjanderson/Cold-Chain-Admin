using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTest {
    class TextUtils {
        public static string[] RemoveEmptyLines(string[] lines) {
            List<string> newLines = new List<string>();

            foreach (string line in lines) {
                if (line.Length > 0)
                    newLines.Add(line);
            }

            return newLines.ToArray();
        }
       
    }
}
