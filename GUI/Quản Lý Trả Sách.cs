﻿using System;
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
    public partial class Quản_Lý_Trả_Sách : Form
    {
        public Quản_Lý_Trả_Sách()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QuảnLý frm1 = new QuảnLý();
            frm1.Show();
            this.Hide();
        }
    }
}
