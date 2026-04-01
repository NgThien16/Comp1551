using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture7_GUI_TEXT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Addition_Click(object sender, EventArgs e)
        {
            string num1_str = tbNum1.Text;
            string num2_str = tbNum2.Text;

            double num1 = double.Parse(num1_str);
            double num2 = double.Parse(num2_str);

            double sum = num1+ num2;

            tbResult.Text = sum.ToString();
        }

        private void Mul(object sender, EventArgs e)
        {
            string num1_str = tbNum1.Text;
            string num2_str = tbNum2.Text;

            double num1 = double.Parse(num1_str);
            double num2 = double.Parse(num2_str);

            double mul = num1 * num2;

            tbResult.Text = mul.ToString();
        }

        private void Sub(object sender, EventArgs e)
        {
            string num1_str = tbNum1.Text;
            string num2_str = tbNum2.Text;

            double num1 = double.Parse(num1_str);
            double num2 = double.Parse(num2_str);

            double sub = num1 - num2;

            tbResult.Text = sub.ToString();
        }

        private void Div(object sender, EventArgs e)
        {
            string num1_str = tbNum1.Text;
            string num2_str = tbNum2.Text;

            double num1 = double.Parse(num1_str);
            double num2 = double.Parse(num2_str);

            double div = num1 / num2;
            if (num2 == 0)
            {
                tbResult.Text = "Error";
                lbError.Text = "Cannot divide by zero!";
                MessageBox.Show("Cannot divide by zero!");
            }
            else
            {

                tbResult.Text = div.ToString();
            }
        }

        private void Execute(object sender, EventArgs e)
        {
            double num1 =double.Parse(tbNum1.Text);
            double num2 =double.Parse(tbNum2.Text);
            double result = 0;
            if (rbAdd.Checked)
            {
                result = num1 + num2;

            }
            else if (rbSub.Checked)
            {
                result = num1 - num2;
            }
            else if (rbMul.Checked)
            {
                result = num1 * num2;
            }else if(rbDiv.Checked){
                result = num1 / num2;
            }
            tbResult.Text = result.ToString();
        }

        private void btbClear_Click(object sender, EventArgs e)
        {
            tbNum1.Text = "";
            tbNum2.Text = "";
            tbResult.Text = "";
        }
    }
}
