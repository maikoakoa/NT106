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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int day, month;
            if (!int.TryParse(textBox1.Text, out day)) return;
            if (!int.TryParse(textBox2.Text, out month)) return;

            int maxDay = DateTime.DaysInMonth(2000, month);

            if (day < 1 || day > maxDay)
            {
                MessageBox.Show("Ngày không hợp lệ! Tháng " + month + " chỉ có " + maxDay + " ngày.");
                textBox1.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int month;
            if (int.TryParse(textBox2.Text, out month))
            {
                if (month < 1 || month > 12)
                {
                    MessageBox.Show("Tháng không hợp lệ! Vui lòng nhập từ 1 đến 12.");
                    textBox2.Clear();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Ngày và Tháng!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int day = int.Parse(textBox1.Text);
            int month = int.Parse(textBox2.Text);

            string zodiac = "";

            if ((day >= 21 && month == 3) || (day <= 20 && month == 4))
                zodiac = "Bạch Dương";
            else if ((day >= 21 && month == 4) || (day <= 21 && month == 5))
                zodiac = "Kim Ngưu";
            else if ((day >= 22 && month == 5) || (day <= 21 && month == 6))
                zodiac = "Song Tử";
            else if ((day >= 22 && month == 6) || (day <= 22 && month == 7))
                zodiac = "Cự Giải";
            else if ((day >= 23 && month == 7) || (day <= 22 && month == 8))
                zodiac = "Sư Tử";
            else if ((day >= 23 && month == 8) || (day <= 23 && month == 9))
                zodiac = "Xử Nữ";
            else if ((day >= 24 && month == 9) || (day <= 23 && month == 10))
                zodiac = "Thiên Bình";
            else if ((day >= 24 && month == 10) || (day <= 22 && month == 11))
                zodiac = "Thần Nông";
            else if ((day >= 23 && month == 11) || (day <= 21 && month == 12))
                zodiac = "Nhân Mã";
            else if ((day >= 22 && month == 12) || (day <= 20 && month == 1))
                zodiac = "Ma Kết";
            else if ((day >= 21 && month == 1) || (day <= 19 && month == 2))
                zodiac = "Bảo Bình";
            else if ((day >= 20 && month == 2) || (day <= 20 && month == 3))
                zodiac = "Song Ngư";

            textBox3.Text = zodiac;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
