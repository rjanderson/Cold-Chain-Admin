using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace GeoTest3 {
    public class AdminTree {
        public AdminTree(CsvTable table, string level0) {
            root = new AdminLevelNode(level0);

            for (int row = 0; row < table.Rows; row++) {
                List<string> adminPath = table.GetAdminPath(row);
                root.AddAdminPath(adminPath, 1);
            }
        }

        public AdminTreeNode Root {
            get { return root; }
        }
        AdminTreeNode root;

        public void BuildTreeView(TreeView treeView) {
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            treeView.Nodes.Add(this.root.MakeTree());
            treeView.EndUpdate();

        }

        public void AddFacilityNodes(CsvTable table) {
            int col = table.LookupColumn("Facility");
            if (col == -1)
                return;
            for (int row = 0; row < table.Rows; row++) {
                List<string> adminPath = table.GetAdminPath(row);
                root.AddFacility(adminPath, 1, table.dataColumns[col].StringAt(row));
            }

        }
    }

    public class AdminTreeNode {
        AdminTreeNode parent;
        AdminNodeCollection children;

        public AdminTreeNode() {
            this.parent = null;
            this.children = new AdminNodeCollection();

        }
        public AdminTreeNode(string name) : this() {
           this.name = name;
        }

        public AdminTreeNode(List<string> adminPath, int level) : this(adminPath[level]) {
            if (level + 1 == adminPath.Count)
                return;

            AdminTreeNode childNode = new AdminTreeNode(adminPath, level + 1);
            children.Add(childNode);
            childNode.parent = this;
        }

        protected string name;
        public string Name {
            get { return name; }
        }

        public void AddAdminPath(List<string> adminPath, int level) {
            if (level >= adminPath.Count)
                return;
            string region = adminPath[level];

            int index = children.IndexOfKey(region);
            if (index != -1) {
                children[index].AddAdminPath(adminPath, level + 1);
                return;
            }

            AdminTreeNode pathNode = new AdminTreeNode(adminPath, level);
            pathNode.parent = this;

            int pos = 0;
            for (int i = 0; i < children.Count; i++) {
                if (region.CompareTo(children[i].Name) < 0)
                    break;
                pos++;
            }

            children.Insert(pos, pathNode);

        }

        public TreeNode MakeTree() {
            TreeNode node = new TreeNode(this.Name);

            foreach (AdminTreeNode adminNode in this.children)
                node.Nodes.Add(adminNode.MakeTree());

            return node;

        }

        public void AddFacility(List<string> adminPath, int level, string facility) {

            if (level < adminPath.Count) {
                string region = adminPath[level];
                int index = children.IndexOfKey(region);
                children[index].AddFacility(adminPath, level + 1, facility);
            } else {
                FacilityNode facilityNode = new FacilityNode(facility);
                facilityNode.parent = this;
                int pos = children.InsertPosition(facility);
                children.Insert(pos, facilityNode);
            }
        }
    }

    public class AdminNodeCollection : List<AdminTreeNode> {
        public int IndexOfKey(string region) {
            for (int i = 0; i < this.Count; i++)
                if (this[i].Name.Equals(region))
                    return i;
            return -1;
        }

        public int InsertPosition(string facility) {
            int pos = 0;
            for (int i = 0; i < this.Count; i++) {
                if (facility.CompareTo(this[i].Name) < 0)
                    break;
                pos++;
            }

            return pos;
        }
    }

    public class FacilityNode : AdminTreeNode {
        public FacilityNode (string name) : base (name) {
        }
    }

    public class AdminLevelNode : AdminTreeNode {
        public AdminLevelNode (string name) : base(name) {

        }
    }

    public class AdminIterator : IEnumerator<AdminTreeNode> {

        Stack<AdminTreeNode> nodeStack;
        AdminTree adminTree;

        public AdminIterator (AdminTree at) {
            adminTree = at;
            nodeStack = null;
        }

        public bool MoveNext() {
            if (nodeStack == null) {
                nodeStack = new Stack<AdminTreeNode>();
                nodeStack.Push(adminTree.Root);
                return true;
            } else if (nodeStack.Count == 0) {
                return false;
            } else {
                return true;
            }          
        }

        public void Reset() {
            throw new NotSupportedException();
        }


        public AdminTreeNode Current {
            get { return nodeStack.Peek(); }
        }

        object IEnumerator.Current  {
            get { return Current; }
        }

        void IDisposable.Dispose() { }
    }

}
