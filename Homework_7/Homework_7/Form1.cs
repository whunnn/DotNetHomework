using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        private Graphics graphics;
        static double  th1 = 30 * Math.PI / 180;
        static double  th2 = 20 * Math.PI / 180;
        static double per1 = 0.6;
        static double per2 = 0.7;



        void drawCayLeyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayLeyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayLeyTree(n - 1, x1, y1, per2 * leng, th - th2);

        }

        void drawLine(double x0,double y0,double x1,double y1)
        {
            switch (comboBox1.SelectedItem)
            {
                case "蓝色": graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "绿色": graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "红色":
                    graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "紫色":
                    graphics.DrawLine(Pens.Purple, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "黑色":
                    graphics.DrawLine(Pens.Black, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
            }
        }       
                       
        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = panel2.CreateGraphics();
            graphics.Clear(BackColor);
            drawCayLeyTree((int)deepn.Value, 400, 620, (double)length.Value, -Math.PI / 2);
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            per1 = (double)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            per2 = (double)numericUpDown2.Value;
        }

        private void numericUpDown3_ValueChanged_1(object sender, EventArgs e)
        {
            th1 = (double)numericUpDown3.Value * Math.PI / 180;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            th2 = (double)numericUpDown4.Value * Math.PI / 180;
        }
    }
}
