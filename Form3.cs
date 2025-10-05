using System;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        private bool IsValidNumber(string input)
        {
            double temp;
            return double.TryParse(input, out temp);
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

   
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

      
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.ReadOnly = true;
        }

       
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.ReadOnly = true;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            double so1, so2, so3;

            string nhap1 = textBox1.Text.Trim();
            string nhap2 = textBox2.Text.Trim();
            string nhap3 = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(nhap1))
            {
                MessageBox.Show("Vui lòng nhập Số thứ 1!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(nhap1, out so1))
            {
                MessageBox.Show("Số thứ 1 không hợp lệ! Vui lòng nhập số (nguyên hoặc thập phân).",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(nhap2))
            {
                MessageBox.Show("Vui lòng nhập Số thứ 2!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(nhap2, out so2))
            {
                MessageBox.Show("Số thứ 2 không hợp lệ! Vui lòng nhập số (nguyên hoặc thập phân).",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
         
            if (string.IsNullOrEmpty(nhap3))
            {
                MessageBox.Show("Vui lòng nhập Số thứ 3!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(nhap3, out so3))
            {
                MessageBox.Show("Số thứ 3 không hợp lệ! Vui lòng nhập số (nguyên hoặc thập phân).",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        
            double max = Math.Max(so1, Math.Max(so2, so3));
            double min = Math.Min(so1, Math.Min(so2, so3));

            textBox4.Text = max.ToString();
            textBox5.Text = min.ToString();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
