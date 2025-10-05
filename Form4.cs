using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int txt;
            bool isnumber = Int32.TryParse(textBox1.Text, out txt);
            if (isnumber == false && textBox1.Text != "")
            {
                MessageBox.Show("Vui lòng nhập số nguyên từ 0 đến 9!", "Warning!");
                textBox1.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (Int32.Parse(textBox1.Text))
            {
                case 0:
                    textBox2.Text = "Không";
                    break;
                case 1:
                    textBox2.Text = "Một";
                    break;
                case 2:
                    textBox2.Text = "Hai";
                    break;
                case 3:
                    textBox2.Text = "Ba";
                    break;
                case 4:
                    textBox2.Text = "Bốn";
                    break;
                case 5:
                    textBox2.Text = "Năm";
                    break;
                case 6:
                    textBox2.Text = "Sáu";
                    break;
                case 7:
                    textBox2.Text = "Bảy";
                    break;
                case 8:
                    textBox2.Text = "Tám";
                    break;
                case 9:
                    textBox2.Text = "Chín";
                    break;
                default:
                    MessageBox.Show("Vui lòng nhập số nguyên từ 0 đến 9!", "Warning!");
                    textBox1.Text = "";
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }
    }
}
