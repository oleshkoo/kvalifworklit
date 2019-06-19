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
    public partial class Graphic : Form
    {
        public Graphic()
        {
            InitializeComponent();
        }
        int n, n1, z, kolvohodov, st, ostatok1;
        void reshenie()
        {
            while (n / (z + 1) > 1)
            {
                if ((n - (n % (z + 1))) / (z + 1) > n % (z + 1))
                {
                    n = (n - (n % (z + 1))) / (z + 1);
                    kolvohodov = kolvohodov + z * st;
                }
                else if ((n - (n % (z + 1))) / (z + 1) == n % (z + 1))
                {
                    n = (n - (n % (z + 1))) / (z + 1);
                    kolvohodov = kolvohodov + (z + 1) * st;
                }
                else
                {
                    ostatok1 = n % (z + 1);
                    n = (n - (n % (z + 1))) / (z + 1);
                    kolvohodov = kolvohodov + z * st + (ostatok1 - 1);
                }
                st = z;
            }
            kolvohodov = kolvohodov + (n - 1) * st;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            frmMenu z = new frmMenu();
            z.Show();
            Hide();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Orange;
        }

        private void Graphic_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Graphic_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            n = Convert.ToInt32(textBox1.Text);
            if(n<=0)
            {
                MessageBox.Show("Введіть додатній N");
                return;
            }
            else
            {
                n1 = n;
                for (z = 1; z < n1; z++)
                {
                    st = 1;
                    chart1.Series[1].Points.AddXY(z, n1 - 1);
                    kolvohodov = 0;
                    n = n1;
                    reshenie();
                    chart1.Series[0].Points.AddXY(z, kolvohodov);
                }
            }
        }
    }
}
