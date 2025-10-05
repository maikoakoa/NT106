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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        
            if (!long.TryParse(textBox1.Text, out long number))
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ!", "Warnning");
                return;
            }
            if (number < 0 || number > 999999999999)
            {
                MessageBox.Show("Vui lòng nhập số có tối đa 12 chữ số!", "Lỗi");
                return;
            }

            if (number == 0)
            {
                textBox2.Text = "Không";
                return;
            }

            string[] unit = { "", "nghìn", "triệu", "tỷ" };
            string[] ones = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };

            string result = "";
            int unitIndex = 0;

            while (number > 0)
            {
                int threeDigits = (int)(number % 1000);
                if (threeDigits > 0)
                {
                    int hundred = threeDigits / 100;
                    int tenUnit = threeDigits % 100;
                    int ten = tenUnit / 10;
                    int unitNum = tenUnit % 10;

                    string part = "";

                    if (hundred > 0)
                    {
                        part += ones[hundred] + " trăm";
                        if (ten == 0 && unitNum > 0)
                            part += " linh";
                    }

                    if (ten > 1)
                    {
                        part += " " + ones[ten] + " mươi";
                        if (unitNum == 1) part += " mốt";
                        else if (unitNum == 5) part += " lăm";
                        else if (unitNum > 0) part += " " + ones[unitNum];
                    }
                    else if (ten == 1)
                    {
                        part += " mười";
                        if (unitNum == 1) part += " một";
                        else if (unitNum == 5) part += " lăm";
                        else if (unitNum > 0) part += " " + ones[unitNum];
                    }
                    else if (ten == 0 && hundred == 0 && unitNum > 0)
                    {
                        part += ones[unitNum];
                    }
                    else if (ten == 0 && unitNum > 0)
                    {
                        part += " " + ones[unitNum];
                    }

                    result = part + " " + unit[unitIndex] + " " + result;
                }

                number /= 1000;
                unitIndex++;
            }

            textBox2.Text = result.Trim();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
