using BUS;
using BUS.PhieuMuon;
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
    public partial class Quản_Lý_Mượn_Sách : Form
    {
        private readonly PhieuMuonService phieuMuonService = new PhieuMuonService();
        Model1 context = new Model1();
        public Quản_Lý_Mượn_Sách()
        {
            InitializeComponent();
            phieuMuonService = new PhieuMuonService();
        }
        private void BindGrid(List<PHIEUMUON> listPhieuMuon)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in listPhieuMuon)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.MaPhieuMuon;
                dataGridView1.Rows[index].Cells[1].Value = item.TheThanhVien.MaThanhVien;
                dataGridView1.Rows[index].Cells[2].Value = item.SACH.TenSach;
                dataGridView1.Rows[index].Cells[3].Value = item.MaSach;
                dataGridView1.Rows[index].Cells[4].Value = item.SACH.SoLuongSachMuon;
                dataGridView1.Rows[index].Cells[5].Value = item.NgayMuon.HasValue ? item.NgayMuon.Value.ToString("dd/MM/yyyy") : "Chưa có ngày mượn"; 
                dataGridView1.Rows[index].Cells[6].Value = item.NgayTra.HasValue ? item.NgayTra.Value.ToString("dd/MM/yyyy") : "Chưa có ngày trả";
                dataGridView1.Rows[index].Cells[7].Value = item.TrangThai.HasValue && item.TrangThai.Value ? "Đã trả" : "Chưa trả"; 
            }
        }
        public void setGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgview.BackgroundColor = Color.White;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void Quản_Lý_Mượn_Sách_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dataGridView1);
                var listPhieuMuon = phieuMuonService.GetAll(); 
                BindGrid(listPhieuMuon);  
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
