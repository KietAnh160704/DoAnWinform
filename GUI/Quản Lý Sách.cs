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
using BUS;
using DAL.Acess;

namespace GUI
{
    public partial class Quản_Lý_Sách : Form
    {
        private readonly SachService sachService = new SachService();
        private readonly TheLoaiService theLoaiService = new TheLoaiService();
        Model1 context = new Model1();
        public Quản_Lý_Sách()
        {
            InitializeComponent();
            sachService = new SachService();
            theLoaiService = new TheLoaiService();
        }
        private void FillCombobox(List<THELOAI> listTheloai)
        {
            listTheloai.Insert(0, new THELOAI());
            this.cmbTheLoai.DataSource = listTheloai;
            this.cmbTheLoai.DisplayMember = "TenTheLoai";
            this.cmbTheLoai.ValueMember = "MaTheLoai";
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
        private void Quản_Lý_Sách_Load(object sender, EventArgs e)
        {
            try

            {
                setGridViewStyle(dataGridView1);
                var listSach = sachService.GetAll();
                var listTheLoais = theLoaiService.GetAll();
                FillCombobox(listTheLoais);
                BindGrid(listSach);
                cmbTheLoai.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SACH sach = new SACH
                {
                    MaSach = txtMaSach.Text,
                    TenSach = txtTenSach.Text,
                    MaTheLoai = cmbTheLoai.SelectedValue.ToString(),
                    SoLuongSachHienCo = int.Parse(txtSoLuong.Text),
                    NhaXuatBan = txtNXB.Text,
                    NamXuatBan = int.Parse(txtNamXB.Text)
                };
                sachService.AddBook(sach);
                MessageBox.Show("Thêm sách thành công!");
                var listSach = sachService.GetAll();
                BindGrid(listSach);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridView1.SelectedRows[0];
                    string maSach = selectedRow.Cells[0].Value.ToString();
                    sachService.DeleteBook(maSach);
                    MessageBox.Show("Xóa sách thành công!");
                    var listSach = sachService.GetAll();
                    BindGrid(listSach);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sách để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string GetFacultyIdByName(string facultyName)
        {
            using (var context = new Model1())
            {
                return context.THELOAIs
                    .Where(f => f.TenTheLoai.Equals(facultyName, StringComparison.OrdinalIgnoreCase))
                    .Select(f => f.MaTheLoai) 
                    .FirstOrDefault(); 
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                txtMaSach.Text = selectedRow.Cells[0].Value.ToString(); 
                txtTenSach.Text = selectedRow.Cells[1].Value.ToString(); 
                txtNXB.Text = selectedRow.Cells[2].Value.ToString(); 
                txtNamXB.Text = selectedRow.Cells[3].Value.ToString();
                txtSoLuong.Text = selectedRow.Cells[4].Value.ToString();                
                string tenTheLoai = selectedRow.Cells[5].Value.ToString();              
                cmbTheLoai.SelectedValue = GetFacultyIdByName(tenTheLoai);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridView1.SelectedRows[0];
                    string maSach = selectedRow.Cells[0].Value.ToString();

                    SACH sach = new SACH
                    {
                        MaSach = maSach, 
                        TenSach = txtTenSach.Text, 
                        MaTheLoai = cmbTheLoai.SelectedValue.ToString(),
                        SoLuongSachHienCo = int.Parse(txtSoLuong.Text),
                        NhaXuatBan = txtNXB.Text,
                        NamXuatBan = int.Parse(txtNamXB.Text)
                    };

                    
                    sachService.UpdateBook(sach);

                    MessageBox.Show("Cập nhật sách thành công!");

                    
                    var listSach = sachService.GetAll();
                    BindGrid(listSach);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sách để sửa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox8.Text.Trim();
            var searchResults = sachService.SearchBooks(searchTerm);
            BindGrid(searchResults);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
