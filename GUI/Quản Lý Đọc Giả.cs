using BUS;
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
    public partial class Quản_Lý_Đọc_Giả : Form
    {
        private readonly ThanhVienService thanhvienService = new ThanhVienService();
        Model1 context = new Model1();
        public Quản_Lý_Đọc_Giả()
        {
            InitializeComponent();
            thanhvienService = new ThanhVienService();
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void BindGrid(List<THANHVIEN> listThanhVien)
        {
            dgvThanhVien.Rows.Clear();
            foreach (var item in listThanhVien)
            {
                int index = dgvThanhVien.Rows.Add();
                dgvThanhVien.Rows[index].Cells[0].Value = item.MaThanhVien;
                dgvThanhVien.Rows[index].Cells[1].Value = item.TenThanhVien;
                dgvThanhVien.Rows[index].Cells[2].Value = item.DiaChi;
                dgvThanhVien.Rows[index].Cells[3].Value = item.SoDienThoai;
                dgvThanhVien.Rows[index].Cells[4].Value = item.Email;
                dgvThanhVien.Rows[index].Cells[5].Value = item.NgayDangKyThanhVien;

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
        private void Quản_Lý_Đọc_Giả_Load(object sender, EventArgs e)
        {
            try
            {
                setGridViewStyle(dgvThanhVien);
                var listThanhVien = thanhvienService.GetAll();
                BindGrid(listThanhVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                THANHVIEN newThanhVien = new THANHVIEN
                {
                    MaThanhVien = txtMaDG.Text,
                    TenThanhVien = txtTenDG.Text,
                    DiaChi = txtDiaChi.Text,
                    SoDienThoai = txtSDT.Text,
                    Email = txtEmail.Text,
                    NgayDangKyThanhVien = DateTime.Now
                };


                thanhvienService.AddThanhVien(newThanhVien);


                var listThanhVien = thanhvienService.GetAll();
                BindGrid(listThanhVien);

                MessageBox.Show("Thêm thành viên mới thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm thành viên: " + ex.Message);
            }
        }

        private void dgvThanhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvThanhVien.Rows[e.RowIndex];
                txtMaDG.Text = selectedRow.Cells[0].Value.ToString();
                txtTenDG.Text = selectedRow.Cells[1].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells[2].Value.ToString();
                txtSDT.Text = selectedRow.Cells[3].Value.ToString();
                txtEmail.Text = selectedRow.Cells[4].Value.ToString();
                dtNgayLamThe.Text = selectedRow.Cells[5].Value.ToString();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvThanhVien.SelectedRows.Count > 0)
            {
                var selectedRow = dgvThanhVien.SelectedRows[0];

                string oldMaThanhVien = selectedRow.Cells[0].Value.ToString(); // Mã cũ
                string newMaThanhVien = txtMaDG.Text; // Mã mới từ TextBox
                string tenThanhVien = txtTenDG.Text;
                string diaChi = txtDiaChi.Text;
                string soDienThoai = txtSDT.Text;
                string email = txtEmail.Text;
                DateTime ngayDangKy = dtNgayLamThe.Value;

                var updatedMember = new THANHVIEN
                {
                    MaThanhVien = newMaThanhVien,
                    TenThanhVien = tenThanhVien,
                    DiaChi = diaChi,
                    SoDienThoai = soDienThoai,
                    Email = email,
                    NgayDangKyThanhVien = ngayDangKy
                };

                thanhvienService.UpdateThanhVien(updatedMember, oldMaThanhVien);

                BindGrid(thanhvienService.GetAll());
                MessageBox.Show("Cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một thành viên để cập nhật.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvThanhVien.SelectedRows.Count > 0)
                {
                    string maThanhVien = dgvThanhVien.SelectedRows[0].Cells[0].Value.ToString();

                    thanhvienService.DeleteThanhVien(maThanhVien);

                    // Cập nhật lại DataGridView sau khi xóa
                    var listThanhVien = thanhvienService.GetAll();
                    BindGrid(listThanhVien);
                    MessageBox.Show("Xóa thành viên thành công. ");
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một thành viên để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();

                List<THANHVIEN> listThanhVien;

                if (string.IsNullOrEmpty(searchTerm))
                {
                    listThanhVien = thanhvienService.GetAll();
                }
                else
                {
                    listThanhVien = thanhvienService.SearchThanhVien(searchTerm);
                }

                BindGrid(listThanhVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();

                List<THANHVIEN> listThanhVien;

                if (string.IsNullOrEmpty(searchTerm))
                {
                    listThanhVien = thanhvienService.GetAll();
                }
                else
                {
                    listThanhVien = thanhvienService.SearchThanhVien(searchTerm);
                }

                BindGrid(listThanhVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
