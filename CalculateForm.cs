using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculateForm : Form
    {
        string Number1 = null, Number2 = null, op = null;
        int dot1 = 0, dot2 = 0;
        bool plus1 = true, plus2 = true;
        double result = 0.0;

        public CalculateForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void equationChange ()
        {
            if (op == null)
            {
                if (Number1 == null)
                    equation.Text = "0";
                else
                    equation.Text = (plus1 ? "" : "-") + Number1;

            } else
            {
                if (Number2 == null)
                    equation.Text = (plus1 ? "" : "-") + Number1 + op + "\r\n" + "0";
                else
                    equation.Text = (plus1 ? "" : "-") + Number1 + op + "\r\n" + (plus2 ? "" : "-") + Number2;
            }
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            if (op == null)
                Number1 += '1';
            else
                Number2 += '1';
            equationChange();
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            if (op == null)
                Number1 += '2';
            else
                Number2 += '2';
            equationChange();
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            if (op == null)
                Number1 += '3';
            else
                Number2 += '3';
            equationChange();
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            if (op == null)
                Number1 += '4';
            else
                Number2 += '4';
            equationChange();
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            if (op == null)
                Number1 += '5';
            else
                Number2 += '5';
            equationChange();
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            if (op == null)
                Number1 += '6';
            else
                Number2 += '6';
            equationChange();
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            if (op == null)
                Number1 += '7';
            else
                Number2 += '7';
            equationChange();
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            if (op == null)
                Number1 += '8';
            else
                Number2 += '8';
            equationChange();
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            if (op == null)
                Number1 += '9';
            else
                Number2 += '9';
            equationChange();
        }
        private void btn_0_Click(object sender, EventArgs e)
        {
            if (op == null)
            {
                if (Number1 == null)
                    return;
                Number1 += '0';
                equation.Text = Number1;
            }
            else
            {
                if (Number2 == null)
                    return;
                Number2 += '0';
                equation.Text = Number1 + op + "\r\n" + Number2;
            }
        }

        private void plus_Click(object sender, EventArgs e)
        {
            if (Number2 != null)
                calculate_Click(null, null);
            op = "+";
            equationChange();
        }

        private void subtract_Click(object sender, EventArgs e)
        {
            if (Number2 != null)
                calculate_Click(null, null);
            op = "-";
            equationChange();
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            if (Number2 != null)
                calculate_Click(null, null);
            op = "×";
            equationChange();
        }

        private void divide_Click(object sender, EventArgs e)
        {
            if (Number2 != null)
                calculate_Click(null, null);
            op = "÷";
            equationChange();
        }

        private void power_Click(object sender, EventArgs e)
        {
            if (Number2 != null)
                calculate_Click(null, null);
            op = "^";
            equationChange();
        }

        private void plus_Or_Minus_Click(object sender, EventArgs e)
        {
            if (op == null)
            {
                if (plus1)
                    plus1 = false;
                 else
                    plus1 = true;
            } else if (op != null)
            {
                if (plus2)
                    plus2 = false;
                else
                    plus2 = true;
            }
            equationChange();
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            double n1, n2;
            if (Number1 == null) n1 = 0;//如果Number为null，则n值为0.
            else n1 = double.Parse(Number1);
            if (Number2 == null) n2 = 0;//如果Number为null，则n值为0.
            else n2 = double.Parse(Number2);
            if (!plus1) n1 = -n1;
            if (!plus2) n2 = -n2;

            switch (op)
            {
                case "+": result = n1 + n2; break;
                case "-": result = n1 - n2; break;
                case "×": result = n1 * n2; break;
                case "÷":
                    {
                        if (n2 == 0)
                        {
                            cleanAll_Click(null, null);
                            equation.Text = "除数不能为零";
                            return;
                        }
                        result = n1 / n2; break;
                    }
                case "^": result = Math.Pow(n1, n2); break;
                default: result = n1; break;
            }
            equation.Text = (plus1 ? "" : "-") + Number1 + op + (plus2 ? "" : "-") + Number2 + "=" + result.ToString();
            equation.Text = result.ToString();

            Number1 = result.ToString(); Number2 = null; op = null;
            plus2 = true;
            if (Number1.StartsWith("-")) {
                Number1 = Number1.Remove(0, 1);
                plus1 = false;
            }else
                plus1 = true;
            
            if (Number1.Contains("."))
                dot1 = 1;
            else
                dot1 = 0;

            if (Number1 == "0")
                Number1 = null;
            dot2 = 0;
        }

        private void cleanAll_Click(object sender, EventArgs e)
        {
            Number1 = null;
            Number2 = null;
            op = null;
            result = 0.0;
            equation.Text = "0";
            dot1 = 0;
            dot2 = 0;
            plus1 = true;
            plus2 = true;
        }
        private void delete_Click(object sender, EventArgs e)
        {
            if (op == null && Number1 != null)
            {
                if (Number1.EndsWith("."))
                    dot1 = 0;
                if (Number1.Length > 1)
                    Number1 = Number1.Remove(Number1.Length - 1, 1);
                else
                {
                    Number1 = null;
                    plus1 = true;
                }
            } else if (op != null && Number2 != null)
            {
                if (Number2.EndsWith("."))
                    dot2 = 0;
                if (Number2.Length > 1)
                    Number2 = Number2.Remove(Number2.Length - 1, 1);
                else
                {
                    Number2 = null;
                    plus2 = true;
                }
            }
            equationChange();
        }

        private void dot_Click(object sender, EventArgs e)
        {
            if (op == null && dot1 == 1 || dot2 == 1)
                return;

            if (op == null && dot1 == 0)
            {
                if (Number1 == null)
                    Number1 = Number1 + "0.";
                else
                    Number1 = Number1 + "."; 
                dot1 ++;
            }
            else if (dot2 == 0)
            {
                if (Number2 == null)
                    Number2 = Number2 + "0.";
                else
                    Number2 = Number2 + ".";
                dot2 ++;
            }
            equationChange();
        }
        private void equation_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
