using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Lab1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text.Trim(), out int A))
            {
                MessageBox.Show("Vui lòng nhập số nguyên hợp lệ cho A!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }
            if (!int.TryParse(textBox2.Text.Trim(), out int B))
            {
                MessageBox.Show("Vui lòng nhập số nguyên hợp lệ cho B!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            string luaChon = comboBox1.Text?.Trim();
            if (string.IsNullOrEmpty(luaChon))
            {
                MessageBox.Show("Vui lòng chọn chức năng trong ComboBox!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TextBox output = textBox3.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Multiline);
            if (output == null)
            {
                output = new TextBox()
                {
                    Multiline = true,
                    ReadOnly = true,
                    ScrollBars = ScrollBars.Vertical,
                    Dock = DockStyle.Fill
                };
                textBox3.Controls.Clear();
                textBox3.Controls.Add(output);
            }
            output.Clear();

            if (string.Equals(luaChon, "Bảng cửu chương", StringComparison.OrdinalIgnoreCase))
            {
                

                var sb = new StringBuilder();

                
                int start = Math.Min(B, A);
                int end = Math.Max(B, A);

                sb.AppendLine($"--- Bảng cửu chương từ {start} đến {end} ---");

               
                for (int i = start; i <= end; i++)
                {
                    sb.AppendLine($"\n*** Bảng nhân {i} ***");

                  
                    for (int j = 1; j <= 10; j++)
                    {
                        sb.AppendLine($"{i} x {j} = {i * j}");
                    }
                }

                output.Text = sb.ToString();
            }
            else if (string.Equals(luaChon, "Tính toán giá trị", StringComparison.OrdinalIgnoreCase))
            {
                var sb = new StringBuilder();

                int hieu = A - B;
                if (hieu < 0)
                {
                    sb.AppendLine("(A - B)! không xác định với A < B");
                }
                else
                {
                    System.Numerics.BigInteger fact = 1;
                    for (int i = 1; i <= hieu; i++) fact *= i;
                    sb.AppendLine($"(A - B)! = {fact}");
                }

                System.Numerics.BigInteger tong = 0;
                if (B <= 0)
                {
                    sb.AppendLine("Tổng S = 0 (B <= 0)");
                }
                else
                {
                    for (int i = 1; i <= B; i++)
                        tong += System.Numerics.BigInteger.Pow(A, i);
                    sb.AppendLine($"Tổng S = A^1 + A^2 + ... + A^{B} = {tong}");
                }

                output.Text = sb.ToString();
            }
            else
            {
                output.Text = "Chức năng chưa hỗ trợ: " + luaChon;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
