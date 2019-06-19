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
    public partial class frmPractic : Form
    {
        int n, z, kolvohodov, st, ostatok1;
        void reshenie()
        {
                while(n/(z + 1) > 1)
            {
                if ((n-(n%(z+1)))/(z+1)>n%(z+1))
                {
                    listBox1.Items.Add(((n - (n % (z + 1))) / (z + 1)).ToString()+" монет * "+(z+1).ToString()+" куп(и) +залишок:"+(n%(z+1)).ToString()+". Кількість зважувань: "+(z* st).ToString());
                    n = (n - (n % (z + 1))) / (z + 1);
                    kolvohodov = kolvohodov + z*st;
                }
                else if((n - (n % (z + 1))) / (z + 1) == n % (z + 1))
                {
                    listBox1.Items.Add(((n - (n % (z + 1))) / (z + 1)).ToString() + " монет * " + (z + 1).ToString() + " куп(и) +залишок:" + (n % (z + 1)).ToString() + ". Кількість зважувань: " + (z * st).ToString());
                    n = (n - (n % (z + 1))) / (z + 1);
                    kolvohodov = kolvohodov + (z+1) * st;
                }
                else
                {
                    ostatok1 = n % (z + 1);
                    listBox1.Items.Add(((n - (n % (z + 1))) / (z + 1)).ToString() + " монет * " + (z + 1).ToString() + " куп(и) +залишок (з попарним зважуванням):" + (n % (z + 1)).ToString() + ". Кількість зважувань: " + ((z * st)+(ostatok1-1)).ToString());
                    n = (n - (n % (z + 1))) / (z + 1);
                    kolvohodov = kolvohodov + z * st+(ostatok1-1);
                }
                st=z;
            }
            listBox1.Items.Add(n.ToString()+" монет * "+st.ToString() + " куп(и)" + ". Кількість зважувань: " + ((n - 1) * st).ToString());
            kolvohodov = kolvohodov + (n-1)*st;
        }
        public frmPractic()
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

        private void frmPractic_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n1;
            st = 1;
            kolvohodov = 0;
            listBox1.Items.Clear();
            n = Convert.ToInt32(textBox1.Text);
            n1 = n;
            z = Convert.ToInt32(textBox2.Text);
            if(z==0)
            {
                MessageBox.Show("Z дорівнює нулю, фальшивих монет немає");
                return;
            }
            if(n<=z)
            {
                MessageBox.Show("Умова задачі N > Z, введіть коректні дані");
                return;
            }
            reshenie();
            if (kolvohodov==n1-1)
            {
                MessageBox.Show("Кількість зважувань метода співпадає з кількістю зважувань попарного порівняння");
            }
            label4.Text = kolvohodov.ToString();
        }
    }
}
