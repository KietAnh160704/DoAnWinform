using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupUI();
        }
        private void SetupUI()
        {
            // Thiết lập tiêu đề của form
            this.Text = "Đăng Nhập";
            this.Size = new Size(400, 350); // Đặt kích thước form

            // Thiết lập màu nền form
            this.BackColor = Color.WhiteSmoke;

            // Tạo và định dạng một Label cho tiêu đề
            Label titleLabel = new Label();
            titleLabel.Text = "Welcome to My App";
            titleLabel.Font = new Font("Arial", 18, FontStyle.Bold);
            titleLabel.ForeColor = Color.DarkSlateBlue;
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(100, 30); // Vị trí tiêu đề
            this.Controls.Add(titleLabel);

            // Tạo TextBox cho Username
            TextBox userNameTextBox = new TextBox();
            userNameTextBox.Font = new Font("Arial", 12);
            userNameTextBox.Location = new Point(100, 100);
            userNameTextBox.Width = 200;
            this.Controls.Add(userNameTextBox);

            // Label cho Username TextBox
            Label userNameLabel = new Label();
            userNameLabel.Text = "Username:";
            userNameLabel.Font = new Font("Arial", 10);
            userNameLabel.Location = new Point(100, 80); // Vị trí của label
            this.Controls.Add(userNameLabel);

            // Tạo Password TextBox
            TextBox passwordTextBox = new TextBox();
            passwordTextBox.Font = new Font("Arial", 12);
            passwordTextBox.Location = new Point(100, 150);
            passwordTextBox.Width = 200;
            passwordTextBox.UseSystemPasswordChar = true;  // Ẩn ký tự mật khẩu
            this.Controls.Add(passwordTextBox);

            // Label cho Password TextBox
            Label passwordLabel = new Label();
            passwordLabel.Text = "Password:";
            passwordLabel.Font = new Font("Arial", 10);
            passwordLabel.Location = new Point(100, 130);
            this.Controls.Add(passwordLabel);

            // Tạo Button Đăng Nhập với hiệu ứng hover
            Button loginButton = new Button();
            loginButton.Text = "Đăng Nhập";
            loginButton.Font = new Font("Arial", 12, FontStyle.Bold);
            loginButton.ForeColor = Color.White;
            loginButton.BackColor = Color.SteelBlue;
            loginButton.Location = new Point(100, 200);
            loginButton.Width = 200;
            loginButton.Height = 40;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.FlatAppearance.BorderSize = 0;

            // Thêm sự kiện hover để thay đổi màu nút khi di chuột
            loginButton.MouseEnter += (s, e) =>
            {
                loginButton.BackColor = Color.DeepSkyBlue;
            };

            loginButton.MouseLeave += (s, e) =>
            {
                loginButton.BackColor = Color.SteelBlue;
            };

            this.Controls.Add(loginButton);

            // Xử lý sự kiện bấm nút đăng nhập
            loginButton.Click += (s, e) =>
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo");
            };

            // Thêm nút thoát
            Button closeButton = new Button();
            closeButton.Text = "Thoát";
            closeButton.Font = new Font("Arial", 12, FontStyle.Bold);
            closeButton.ForeColor = Color.White;
            closeButton.BackColor = Color.Red;
            closeButton.Location = new Point(125,250);
            closeButton.Width = 200;
            closeButton.Height = 40;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.FlatAppearance.BorderSize = 0;

            // Thêm sự kiện đóng form khi nhấn thoát
            closeButton.Click += (s, e) =>
            {
                this.Close(); // Đóng form
            };

            // Thêm sự kiện hover cho nút thoát
            closeButton.MouseEnter += (s, e) =>
            {
                closeButton.BackColor = Color.DarkRed;
            };

            closeButton.MouseLeave += (s, e) =>
            {
                closeButton.BackColor = Color.Red;
            };

            this.Controls.Add(closeButton);
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Đăng Nhập ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tìm_Kiếm_Sách tks = new Tìm_Kiếm_Sách();
            tks.Show();
        }
    }
}
