using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoTest3 {
    
    // Display outputs from file operations, data cleaning, and facility matching.  This class is a wrapper for the display components.  Facility and admin data should not be accessed
    // through this class
    public class DisplayManager {
        TextBox textBox1;
        TextBox textBox2;
        TextBox textBox3;
        ListBox listBox1;
        TreeView treeView1;
        TreeView treeView2;

        public DisplayManager(TextBox tb1, TextBox tb2, TextBox tb3, ListBox lb1, TreeView tv1, TreeView tv2) {
            this.textBox1 = tb1;
            this.textBox2 = tb2;
            this.textBox3 = tb3;
            this.listBox1 = lb1;
            this.treeView1 = tv1;
            this.treeView2 = tv2;
        }

        public ListBox ListBox {
            get { return this.listBox1; }
        }

        public string Text1 {
            get { return this.textBox1.Text; }
            set { this.textBox1.Text = value; }
        }

        public string Text2 {
            get { return this.textBox2.Text; }
            set { this.textBox2.Text = value; }
        }

        public void DisplayTextFile(string[] lines, int maxLines = 100) {
            StringBuilder sb = new StringBuilder();

            int max = (lines.Length < maxLines) ? lines.Length : maxLines;

            for (int i = 0; i < max; i++)
                sb.Append(lines[i] + "\r\n");

            this.textBox3.Text = sb.ToString();
        }

    }
}
