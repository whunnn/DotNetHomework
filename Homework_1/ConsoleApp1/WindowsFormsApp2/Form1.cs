using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int op = comboBox1.SelectedIndex;
            Double a = Double.Parse(textBox1.Text);
            Double b = Double.Parse(textBox2.Text);
            switch (op)
            {
                case 0:
                    MessageBox.Show($"{a}+{b}={a + b}");
                    break;
                case 1:
                    MessageBox.Show($"{a}-{b}={a - b}");
                    break;
                case 2:
                    MessageBox.Show($"{a}*{b}={a * b}");
                    break;
                case 3:
                    MessageBox.Show($"{a}/{b}={a / b}");
                    break;

            }

            }
        }
}
