using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab1
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();

            string[] parts = input.Split(',');

            if (parts.Length < 6) // Need at least Name + 5 subjects
            {
                MessageBox.Show("Dữ liệu nhập sai format. Cần ít nhất Họ và tên, và 5 môn điểm (cách nhau dấu phẩy ',').", "Lỗi Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string studentName = parts[0].Trim();
            List<float> scores = new List<float>();

            for (int i = 1; i < parts.Length; i++)
            {
                if (float.TryParse(parts[i].Trim(), out float score))
                {
                    scores.Add(score);
                }
                else
                {
                    MessageBox.Show($"Dữ liệu nhập sai format. Điểm '{parts[i].Trim()}' không hợp lệ hoặc thiếu dấu phẩy/cách.", "Lỗi Format Điểm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (scores.Count < 5)
            {
                MessageBox.Show("Dữ liệu nhập sai format. Cần ít nhất 5 môn điểm sau Họ và tên.", "Lỗi Số Môn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Đã nhập đúng format.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox2.Text = studentName;

            if (scores.Count > 0) textBox3.Text = scores[0].ToString(); else textBox3.Clear(); // Môn 1
            if (scores.Count > 1) textBox5.Text = scores[1].ToString(); else textBox5.Clear(); // Môn 2 (Note: textBox5 is used for Môn 2 in the Designer)
            if (scores.Count > 2) textBox4.Text = scores[2].ToString(); else textBox4.Clear(); // Môn 3 (Note: textBox4 is used for Môn 3 in the Designer)
            if (scores.Count > 3) textBox6.Text = scores[3].ToString(); else textBox6.Clear(); // Môn 4
            if (scores.Count > 4) textBox7.Text = scores[4].ToString(); else textBox7.Clear(); // Môn 5

            float averageScore = scores.Average();
            textBox8.Text = averageScore.ToString("F2"); // Display with 2 decimal places

            float maxScore = scores.Max();
            float minScore = scores.Min();
            textBox11.Text = maxScore.ToString();
            textBox12.Text = minScore.ToString();

           
            int passCount = scores.Count(s => s >= 5.0f);
            int failCount = scores.Count - passCount;
            textBox9.Text = passCount.ToString();
            textBox10.Text = failCount.ToString();

            string rank = DetermineRank(averageScore, scores);
            textBox13.Text = rank;
        }

        private string DetermineRank(float avgScore, List<float> scores)
        {
            if (avgScore >= 8.0f && scores.All(s => s >= 6.5f))
            {
                return "Giỏi";
            }
            else if (avgScore >= 6.5f && scores.All(s => s >= 5.0f))
            {
                return "Khá";
            }
            else if (avgScore >= 5.0f && scores.All(s => s >= 3.5f))
            {
                return "Trung Bình";
            }
            else if (avgScore >= 3.5f && scores.All(s => s >= 2.0f))
            {
                return "Yếu";
            }
            else
            {
                return "Kém";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void textBox7_TextChanged(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void textBox8_TextChanged(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void textBox9_TextChanged(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void textBox10_TextChanged(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void textBox11_TextChanged(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void textBox12_TextChanged(object sender, EventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }
        private void textBox13_TextChanged(object sender, EventArgs e) { }
    }
}