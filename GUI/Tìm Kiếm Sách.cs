using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DAL.Acess;

namespace GUI
{
    public partial class Tìm_Kiếm_Sách : Form
    {
        private readonly SachService sachService = new SachService();
        private readonly TheLoaiService theLoaiService = new TheLoaiService();
        Model1 context = new Model1();
        public Tìm_Kiếm_Sách()
        {
            InitializeComponent();
            sachService = new SachService();
            theLoaiService = new TheLoaiService();
        }

        private void Tìm_Kiếm_Sách_Load(object sender, EventArgs e)
        {
            try

            {
                setGridViewStyle(dataGridView1);
                var listSach = sachService.GetAll();
                var listTheLoais = theLoaiService.GetAll();
                FillCombobox(listTheLoais);
                BindGrid(listSach);
                cmbTheloai.Text = "Chọn Thể Loại Để Tìm Kiếm";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillCombobox(List<THELOAI> listTheloai)
        {
            listTheloai.Insert(0, new THELOAI());
            this.cmbTheloai.DataSource = listTheloai;
            this.cmbTheloai.DisplayMember = "TenTheLoai";
            this.cmbTheloai.ValueMember = "MaTheLoai";
        }
        private void BindGrid(List<SACH> listSach)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in listSach)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.MaSach;
                dataGridView1.Rows[index].Cells[1].Value = item.TenSach;
                dataGridView1.Rows[index].Cells[2].Value = item.NhaXuatBan;
                dataGridView1.Rows[index].Cells[3].Value = item.NamXuatBan;
                dataGridView1.Rows[index].Cells[4].Value = item.SoLuongSachHienCo;
                dataGridView1.Rows[index].Cells[5].Value = item.THELOAI != null ? item.THELOAI.TenTheLoai : "Chưa có thể loại";  // Tên thể loại
                dataGridView1.Rows[index].Cells[6].Value = item.SoLuongSachMuon;
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

        private void cmbTheloai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();
                string maTheLoai = cmbTheloai.SelectedValue != null ? cmbTheloai.SelectedValue.ToString() : "";
                var result = sachService.SearchBooksUser(searchTerm, maTheLoai);
                BindGrid(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }
    }
}
