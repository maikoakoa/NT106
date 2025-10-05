using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form10 : Form
    {
        private string favoriteDishesString = string.Empty;
        private readonly char separator = ';';
        private readonly Random random = new Random();

        public Form10()
        {
            InitializeComponent();
            UpdateListBox();
        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            if (!string.IsNullOrEmpty(favoriteDishesString))
            {
                string[] dishes = favoriteDishesString.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries)
                                                      .Select(d => d.Trim())
                                                      .Where(d => !string.IsNullOrEmpty(d))
                                                      .ToArray();

                foreach (string dish in dishes)
                {
                    listBox1.Items.Add(dish);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string newDish = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(newDish))
            {
                if (!string.IsNullOrEmpty(favoriteDishesString))
                {
                    favoriteDishesString += separator + newDish;
                }
                else
                {
                    favoriteDishesString = newDish;
                }

                UpdateListBox();
                textBox1.Clear();
                label1.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên món ăn bạn muốn thêm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(favoriteDishesString))
            {
                label1.Text = "Danh sách món ăn rỗng.";
                return;
            }

            string[] dishes = favoriteDishesString.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(d => d.Trim())
                                                  .Where(d => !string.IsNullOrEmpty(d))
                                                  .ToArray();

            if (dishes.Length > 0)
            {
                int randomIndex = random.Next(0, dishes.Length);
                string selectedDish = dishes[randomIndex];
                
                label1.Text = $"Hôm nay bạn sẽ ăn: {selectedDish}";
            }
            else
            {
                label1.Text = "Không có món ăn hợp lệ trong danh sách.";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một món ăn trong danh sách để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string selectedDish = listBox1.SelectedItem.ToString();

            List<string> dishes = favoriteDishesString.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries)
                                                      .Select(d => d.Trim())
                                                      .Where(d => !string.IsNullOrEmpty(d) && d != selectedDish)
                                                      .ToList();

            favoriteDishesString = string.Join(separator.ToString(), dishes);

            UpdateListBox();
            label1.Text = $"Đã xóa món: {selectedDish}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            favoriteDishesString = string.Empty;
            listBox1.Items.Clear();
            textBox1.Clear();
            label1.Text = "Đã xóa toàn bộ danh sách hiện tại. Hãy thêm món mới!";
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void Form10_Load(object sender, EventArgs e) { }
    }
}