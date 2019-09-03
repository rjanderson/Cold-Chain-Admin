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

        public NameSet() {
            this.fullPath = "";
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



        public MatchResult CompareNames(NameSet target, Algorithm alg = Algorithm.Basic) {
            MatchResult result = null;

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

        MatchResult Basic(NameSet target) {
            MatchResult result = new MatchResult();

            foreach (string str1 in this.names) {
                int index = target.Names.IndexOf(str1);
                if (index > -1)
                    result.Add(str1, str1, 1);
                else
                    result.Add(str1, "", 0);                 
            }
            return result;
        }

        MatchResult LongestCommonSubsequence(NameSet target) {
            MatchResult result = new MatchResult();

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


    }

    public class MatchResult {
        List<string> source;
        List<string> best;
        List<int> score;

        public MatchResult() {
            this.source = new List<string>();
            this.best = new List<string>();
            this.score = new List<int>();
        }

        public void Add(string s, string b, int i) {
            this.source.Add(s);
            this.best.Add(b);
            this.score.Add(i);
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.source.Count; i++)
                sb.Append(this.source[i] + ": " + this.best[i] + " -- " + this.score[i] + "\r\n");

            return sb.ToString();
        }
    }
}
