using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoTest3 {
    public class NameSet {

        public enum Algorithm { Basic, LCS};

        string fullPath;
        public string FullPath {
            get { return fullPath; }
        }

        List<string> names;
        public List<string> Names {
            get { return this.names; }
        }

        public NameSet(string path = "") {
            this.fullPath = path;
            this.names = new List<string>();
        }
        public NameSet(TreeNode treeNode) {
            this.fullPath = treeNode.FullPath;
            this.names = new List<string>();
            foreach (TreeNode node in treeNode.Nodes)
                this.names.Add(node.Text);
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.fullPath + "\r\n");
            foreach (string str in names)
                sb.Append(str + "\r\n");

            return sb.ToString();
        }

        public void AddName(string name) {
            this.names.Add(name);
        }



        public MatchResultSet CompareNames(NameSet target, Algorithm alg = Algorithm.Basic) {
            MatchResultSet result = null;

            switch (alg) {
                case Algorithm.Basic:
                    result = Basic(target);
                    break;
                case Algorithm.LCS:
                    result = LongestCommonSubsequence(target);
                    break;
                default:
                    break;
            }
                
            return result;
        }

        MatchResultSet Basic(NameSet target) {
            MatchResultSet result = new MatchResultSet();

            foreach (string str1 in this.names) {
                int index = target.Names.IndexOf(str1);
                if (index > -1)
                    result.Add(str1, str1, 1);
                else
                    result.Add(str1, "", 0);                 
            }
            return result;
        }

        MatchResultSet LongestCommonSubsequence(NameSet target) {
            MatchResultSet result = new MatchResultSet();

            foreach (string str1 in this.names) {
                int index = target.Names.IndexOf(str1);
                if (index > -1)
                    result.Add(str1, str1, 100);
                else {
                    string best = "";
                    int score = 0;
                    foreach (string str2 in target.Names) {
                        int lcs = Utilities.LcsLength(str1, str2);
                        if (lcs > score) {
                            score = lcs;
                            best = str2;
                        }
                    }
                    result.Add(str1, best, score);

                }
            }
            return result;

        }

        public MatchResult FindBestMatch(string name) {
            string best = "";
            int score = 0;
            foreach (string str in this.Names) {
                if (name == str) {
                    best = str;
                    score = 100;
                } else {
                    int lcs = Utilities.LcsLength(name, str);
                    if (lcs > score) {
                        score = lcs;
                        best = str;
                    }
                }
            }

            return new MatchResult(name, best, score);
        }

        public List<string> ExtractPath {
            get {  return Utilities.PathStringToList(fullPath);  }
        }


    }

    public class MatchResultSet {
        List<MatchResult>  results;
        public List<MatchResult> Results {
            get { return results; }
        }
       
        public MatchResultSet() {
            this.results = new List<MatchResult>();
        }

        public void Add(string s, string b, int i) {
            this.results.Add(new MatchResult(s, b, i));
        }

        public void Add(MatchResult result) {
            this.results.Add(result);
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            foreach (MatchResult result in results)
                sb.Append(result.ToString() + "\r\n");
            return sb.ToString();
        }

        string ItemString(int i) {
            return this.results[i].ToString();

        }

        public void AddToListBox(ListBox listBox) {
            listBox.Items.Clear();
            foreach (MatchResult result in results)
                listBox.Items.Add(result.ToString());
            listBox.ClearSelected();
        }
    }

    public class MatchResult {
        string source;
        string best;
        int score;
        string fullPath;
        public string FullPath {
            get { return fullPath; }
            set { fullPath = value; }
        }

        public string Source {
            get { return source; }
        }

        public string Best {
            get { return best; }
        }

        public int Score {
            get { return score; }
        }

        public MatchResult(string source, string best, int score) {
            this.source = source;
            this.best = best;
            this.score = score;
        }

        public override string ToString() {
            return source  + " : " + best + "\\ -- " + score;
        }
    }


}
