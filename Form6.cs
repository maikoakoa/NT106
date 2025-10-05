using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Lab1
{
    public partial class Form6 : Form
    {
        private class MovieInfo
        {
            public string Name { get; set; }
            public decimal StandardPrice { get; set; }
            public List<string> AvailableRooms { get; set; }
        }

        private class SeatData
        {
            public string Seat { get; set; }
            public string Class { get; set; }
            public decimal PriceMultiplier { get; set; }
        }

        private static readonly List<string> AllSeats = new List<string>
        {
            "A1", "A2", "A3", "A4", "A5",
            "B1", "B2", "B3", "B4", "B5",
            "C1", "C2", "C3", "C4", "C5"
        };

        private static readonly Dictionary<string, MovieInfo> Movies = new Dictionary<string, MovieInfo>
        {
            { "Đào, phở và piano", new MovieInfo { StandardPrice = 45000m, AvailableRooms = new List<string> { "1", "2", "3" } } },
            { "Mai", new MovieInfo { StandardPrice = 100000m, AvailableRooms = new List<string> { "2", "3" } } },
            { "Gặp lại chị bầu", new MovieInfo { StandardPrice = 70000m, AvailableRooms = new List<string> { "1" } } },
            { "Tarot", new MovieInfo { StandardPrice = 90000m, AvailableRooms = new List<string> { "3" } } }
        };

        private static readonly Dictionary<string, SeatData> SeatClasses = new Dictionary<string, SeatData>
        {
            {"A1", new SeatData { Seat = "A1", Class = "Vé Vớt", PriceMultiplier = 0.25m }},
            {"A5", new SeatData { Seat = "A5", Class = "Vé Vớt", PriceMultiplier = 0.25m }},
            {"C1", new SeatData { Seat = "C1", Class = "Vé Vớt", PriceMultiplier = 0.25m }},
            {"C5", new SeatData { Seat = "C5", Class = "Vé Vớt", PriceMultiplier = 0.25m }},

            {"B2", new SeatData { Seat = "B2", Class = "Vé VIP", PriceMultiplier = 2.0m }},
            {"B3", new SeatData { Seat = "B3", Class = "Vé VIP", PriceMultiplier = 2.0m }},
            {"B4", new SeatData { Seat = "B4", Class = "Vé VIP", PriceMultiplier = 2.0m }},

            {"A2", new SeatData { Seat = "A2", Class = "Vé Thường", PriceMultiplier = 1.0m }},
            {"A3", new SeatData { Seat = "A3", Class = "Vé Thường", PriceMultiplier = 1.0m }},
            {"A4", new SeatData { Seat = "A4", Class = "Vé Thường", PriceMultiplier = 1.0m }},
            {"C2", new SeatData { Seat = "C2", Class = "Vé Thường", PriceMultiplier = 1.0m }},
            {"C3", new SeatData { Seat = "C3", Class = "Vé Thường", PriceMultiplier = 1.0m }},
            {"C4", new SeatData { Seat = "C4", Class = "Vé Thường", PriceMultiplier = 1.0m }},
            {"B1", new SeatData { Seat = "B1", Class = "Vé Thường", PriceMultiplier = 1.0m }},
            {"B5", new SeatData { Seat = "B5", Class = "Vé Thường", PriceMultiplier = 1.0m }}
        };

        private static Dictionary<string, Dictionary<string, bool>> BookedSeats = new Dictionary<string, Dictionary<string, bool>>
        {
            { "1", AllSeats.ToDictionary(seat => seat, seat => false) },
            { "2", AllSeats.ToDictionary(seat => seat, seat => false) },
            { "3", AllSeats.ToDictionary(seat => seat, seat => false) }
        };

        private List<CheckBox> seatCheckBoxes;

        public Form6()
        {
            InitializeComponent();
            InitializeSeatControls();
        }

        private void InitializeSeatControls()
        {
            seatCheckBoxes = new List<CheckBox>
            {
                checkBox1, checkBox2, checkBox3, checkBox4, checkBox5,
                checkBox6, checkBox7, checkBox8, checkBox9, checkBox10,
                checkBox11, checkBox12, checkBox13, checkBox14, checkBox15
            };

            for (int i = 0; i < AllSeats.Count; i++)
            {
                string seatName = AllSeats[i];
                seatCheckBoxes[i].Tag = seatName;
                seatCheckBoxes[i].Text = $"{seatName} ({SeatClasses[seatName].Class})";
                seatCheckBoxes[i].CheckedChanged += CheckBox_Seat_CheckedChanged;
            }
        }

        private void CheckBox_Seat_CheckedChanged(object sender, EventArgs e)
        {
            int selectedCount = seatCheckBoxes.Count(cb => cb.Checked);

            if (selectedCount > 2)
            {
                CheckBox currentCb = (CheckBox)sender;
                currentCb.Checked = false;
                MessageBox.Show("Không thể chọn nhiều hơn 2 vé.", "Giới hạn Vé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sender is CheckBox cb)
            {
                string seat = cb.Tag.ToString();
                string selectedMovie = comboBox1.SelectedItem?.ToString();

                if (cb.Checked && selectedMovie != null && Movies.ContainsKey(selectedMovie))
                {
                    var movieInfo = Movies[selectedMovie];
                    var seatData = SeatClasses[seat];
                    decimal ticketPrice = movieInfo.StandardPrice * seatData.PriceMultiplier;
                    cb.Text = $"{seat} ({seatData.Class}) - {ticketPrice.ToString("N0", new CultureInfo("vi-VN"))} VNĐ";
                }
                else
                {
                    cb.Text = $"{seat} ({SeatClasses[seat].Class})";
                }
            }
        }

        private void UpdateSeatAvailability()
        {
            string selectedRoom = comboBox2.SelectedItem?.ToString();

            Dictionary<string, bool> bookedSeatsInRoom = null;
            if (selectedRoom != null && BookedSeats.ContainsKey(selectedRoom))
            {
                bookedSeatsInRoom = BookedSeats[selectedRoom];
            }

            foreach (var cb in seatCheckBoxes)
            {
                string seat = cb.Tag.ToString();

                bool isBooked = bookedSeatsInRoom != null && bookedSeatsInRoom.ContainsKey(seat) && bookedSeatsInRoom[seat];

                if (isBooked)
                {
                    cb.Enabled = false;
                    cb.Checked = false;
                    cb.Text = $"{seat} (ĐÃ BÁN)";
                }
                else
                {
                    cb.Enabled = true;
                    if (cb.Checked)
                        CheckBox_Seat_CheckedChanged(cb, EventArgs.Empty);
                    else
                        cb.Text = $"{seat} ({SeatClasses[seat].Class})";
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(Movies.Keys.ToArray());
            comboBox2.Items.AddRange(BookedSeats.Keys.ToArray());

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;

            UpdateSeatAvailability();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fullName = textBox1.Text.Trim();
            string selectedMovie = comboBox1.SelectedItem?.ToString();
            string selectedRoom = comboBox2.SelectedItem?.ToString();

            List<string> selectedSeats = seatCheckBoxes
                .Where(cb => cb.Checked)
                .Select(cb => cb.Tag.ToString())
                .ToList();

            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Vui lòng nhập Họ và tên khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một Ghế (Tối đa 2 vé).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            MovieInfo movieInfo;
            if (selectedMovie == null || !Movies.TryGetValue(selectedMovie, out movieInfo))
            {
                MessageBox.Show("Vui lòng chọn một Phim hợp lệ.", "Lỗi Dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            if (selectedRoom == null || !BookedSeats.ContainsKey(selectedRoom))
            {
                MessageBox.Show("Vui lòng chọn Phòng chiếu hợp lệ.", "Lỗi Dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }

            bool isMovieAvailableInRoom = movieInfo.AvailableRooms.Contains(selectedRoom);

            if (!isMovieAvailableInRoom)
            {
                MessageBox.Show($"Phim '{selectedMovie}' không được chiếu tại Phòng chiếu {selectedRoom}. Vui lòng kiểm tra lại.", "Lỗi Chọn Phòng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal totalPayment = 0;
            StringBuilder ticketDetails = new StringBuilder();

            var bookedSeatsInRoom = BookedSeats[selectedRoom];
            foreach (var seat in selectedSeats)
            {
                var seatData = SeatClasses[seat];
                decimal ticketPrice = movieInfo.StandardPrice * seatData.PriceMultiplier;
                totalPayment += ticketPrice;

                ticketDetails.AppendLine($"- Ghế {seat} ({seatData.Class}): {ticketPrice.ToString("N0", new CultureInfo("vi-VN"))} VNĐ");
                bookedSeatsInRoom[seat] = true;
            }

            UpdateSeatAvailability();

            string result = $"THÔNG TIN THANH TOÁN\n" +
                            $"Họ và tên khách hàng: {fullName}\n" +
                            $"Tên Phim: {selectedMovie}\n" +
                            $"Phòng Chiếu: {selectedRoom}\n" +
                            $"Vé đã chọn ({selectedSeats.Count} vé):\n" +
                            $"{ticketDetails.ToString()}" +
                            $"============================\n" +
                            $"TỔNG TIỀN CẦN THANH TOÁN: {totalPayment.ToString("N0", new CultureInfo("vi-VN"))} VNĐ";

            MessageBox.Show(result, "Thanh Toán Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;

            foreach (var cb in seatCheckBoxes)
            {
                cb.Checked = false;
            }
            UpdateSeatAvailability();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSeatAvailability();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox6_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox11_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox2_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox7_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox12_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox3_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox8_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox13_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox4_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox9_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox14_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox5_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox10_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox15_CheckedChanged(object sender, EventArgs e) { }
    }
}