using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int res;
            res=c1.Addition(Convert.ToInt32(txtno1.Text), Convert.ToInt32(txtno2.Text));
            txtres.Text = Convert.ToString(res);
        }

        private void btnsub_Click(object sender, EventArgs e)
        {
            int res;
            res = c1.substraction(Convert.ToInt32(txtno1.Text), Convert.ToInt32(txtno2.Text));
            txtres.Text = Convert.ToString(res);
        }

        private void btnmult_Click(object sender, EventArgs e)
        {
            int res;
            res = c1.Multiplication(Convert.ToInt32(txtno1.Text), Convert.ToInt32(txtno2.Text));
            txtres.Text = Convert.ToString(res);
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            int res;
            res = c1.Divison(Convert.ToInt32(txtno1.Text), Convert.ToInt32(txtno2.Text));
            txtres.Text = Convert.ToString(res);
        }
    }
}
