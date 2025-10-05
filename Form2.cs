using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nhap1 = textBox1.Text.Trim();
            string nhap2 = textBox2.Text.Trim();

           
            if (!int.TryParse(nhap1, out int so1))
            {
                MessageBox.Show("Số thứ 1 không hợp lệ! Vui lòng nhập số nguyên.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (!int.TryParse(nhap2, out int so2))
            {
                MessageBox.Show("Số thứ 2 không hợp lệ! Vui lòng nhập số nguyên.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int num1, num2;
            long sum = 0;
            num1 = Int32.Parse(textBox1.Text.Trim());
            num2 = Int32.Parse(textBox2.Text.Trim());
            sum = num1 + num2;
            textBox3.Text = sum.ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
