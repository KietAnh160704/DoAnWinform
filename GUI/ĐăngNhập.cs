﻿using BUS.User;
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
        private UserService userService;
        public Form1()
        {
            InitializeComponent();
            userService = new UserService();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tìm_Kiếm_Sách tks = new Tìm_Kiếm_Sách();
            tks.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUserID.Text;
            string password = txtPassword.Text;

            if (userService.Login(username, password))
            {
                QuảnLý QL = new QuảnLý();
                QL.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng.");
            }
                                      
        }
        private void PerformLogin()
        {
            string username = txtUserID.Text;
            string password = txtPassword.Text;

            if (userService.Login(username, password))
            {
                QuảnLý QL = new QuảnLý();
                QL.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng.");
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformLogin();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Đăng Nhập";
            label1.ForeColor = Color.Red;
            label2.ForeColor = Color.Red;
        }
    }
}
