using BUS.PhieuPhatService;
using BUS.TacGia;
using DAL;
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
    public partial class Quản_Lý_Phiếu_Phạt : Form
    {
        private readonly PhieuPhatService phieuPhatService = new PhieuPhatService();
        Model1 context = new Model1();
        public Quản_Lý_Phiếu_Phạt()
        {
            InitializeComponent();
            
        }
        public void setGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgview.BackgroundColor = Color.White;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void BindGrid(List<THEPHAT> listPhieu)
        {
            dataGridView2.Rows.Clear();
            foreach (var item in listPhieu)
            {
                int index = dataGridView2.Rows.Add();
                dataGridView2.Rows[index].Cells[0].Value = item.MaThePhat;
                dataGridView2.Rows[index].Cells[1].Value = item.MaPhieuMuon;
                dataGridView2.Rows[index].Cells[2].Value = item.MaNhanVien;
                dataGridView2.Rows[index].Cells[3].Value = item.TienPhat;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QuảnLý frm1 = new QuảnLý();
            frm1.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Quản_Lý_Phiếu_Phạt_Load(object sender, EventArgs e)
        {
            setGridViewStyle(dataGridView2);
            List<THEPHAT> tHEPHATs = new List<THEPHAT>();
            BindGrid(tHEPHATs);
        }
    }
}
