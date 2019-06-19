using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kvaliph_project
{
    public partial class frmTheory : Form
    {
        public frmTheory()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            frmMenu a = new frmMenu();
            a.Show();
            Hide();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Orange;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string s = treeView1.SelectedNode.Name;
            s = s.Replace("gal", "a");
            richTextBox1.LoadFile("razd\\" + s + ".rtf");
        }

        private void frmTheory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
