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
    public partial class QuảnLý : Form
    {
        public QuảnLý()
        {
            InitializeComponent();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quản_Lý_Sách frm2 = new Quản_Lý_Sách();
            frm2.Show();
            this.Hide();

        }

        private void QuảnLý_Load(object sender, EventArgs e)
        {

        }

        private void quảnLýĐọcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quản_Lý_Đọc_Giả frm1 = new Quản_Lý_Đọc_Giả();
            frm1.Show();
            this. Hide();
        }

        private void quảnLýTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quản_Lý_Tác_Giả frm3 = new Quản_Lý_Tác_Giả();
            frm3.Show();
            this. Hide();
        }

        private void quảnLýMượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quản_Lý_Mượn_Sách frm4 = new Quản_Lý_Mượn_Sách();
            frm4.Show();
            this. Hide();

        }

        private void quảnLýTrảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quản_Lý_Trả_Sách frm5 = new Quản_Lý_Trả_Sách();
            frm5.Show();
            this. Hide();

        }

        private void quảnLýPhiếuPhạtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quản_Lý_Phiếu_Phạt frm6 = new Quản_Lý_Phiếu_Phạt();
            frm6.Show();
            this. Hide();
        }
    }
}
