using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoTest3 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void OnHelloButtonClick(object sender, EventArgs e) {
            this.textBox1.Text += " Hello!";
        }
    }
}
