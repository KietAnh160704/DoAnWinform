using BUS;
using BUS.PhieuMuon;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
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
                dataGridView1.Rows[index].Cells[1].Value = item.TheThanhVien?.MaThanhVien ?? "N/A";
                dataGridView1.Rows[index].Cells[2].Value = item.SACH?.TenSach ?? "N/A";
                dataGridView1.Rows[index].Cells[3].Value = item.MaSach;
                dataGridView1.Rows[index].Cells[4].Value = item.NgayMuon?.ToString("dd/MM/yyyy") ?? "Chưa có ngày mượn";
                dataGridView1.Rows[index].Cells[5].Value = item.NgayTra?.ToString("dd/MM/yyyy") ?? "Chưa có ngày trả";
                dataGridView1.Rows[index].Cells[6].Value = item.TrangThai.HasValue && item.TrangThai.Value ? "Đã trả" : "Chưa trả";
                dataGridView1.Rows[index].Cells[7].Value = item.NHANVIEN?.MaNhanVien ?? "N/A";
                dataGridView1.Rows[index].Cells[8].Value = item.MaTheThanhVien;
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
                using (var context = new Model1())
                {
                    setGridViewStyle(dataGridView1);
                    var listPhieuMuon = phieuMuonService.GetAll();
                    BindGrid(listPhieuMuon);
                    cmbTrangThai.Items.Add("Đã trả");
                    cmbTrangThai.Items.Add("Chưa trả");
                    cmbTrangThai.SelectedIndex = 0;
                }


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
                if (string.IsNullOrWhiteSpace(txtMaPhieu.Text) ||
                    string.IsNullOrWhiteSpace(txtMaSach.Text) ||
                    string.IsNullOrWhiteSpace(txtMaNhanVien.Text) ||
                    string.IsNullOrWhiteSpace(txtMaDG.Text))
                {
                    MessageBox.Show("Tất cả các trường phải được điền đầy đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var phieuMuon = new PHIEUMUON
                {
                    MaPhieuMuon = txtMaPhieu.Text,
                    NgayMuon = dateTimePicker1.Value,
                    NgayTra = dateTimePicker2.Value,
                    MaSach = txtMaSach.Text,
                    MaNhanVien = txtMaNhanVien.Text,
                    MaTheThanhVien = txtMaDG.Text,
                    TrangThai = cmbTrangThai.SelectedIndex == 0
                };

                phieuMuonService.AddPhieu(phieuMuon);
                MessageBox.Show("Thêm phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var listPhieu = phieuMuonService.GetAll();
                BindGrid(listPhieu);

                txtMaPhieu.Clear();
                txtMaSach.Clear();
                txtMaNhanVien.Clear();
                txtMaDG.Clear();
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now.AddDays(7);
                cmbTrangThai.SelectedIndex = 0;
            }

            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => $"{x.PropertyName}: {x.ErrorMessage}");

                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = $"Lỗi xác thực: {fullErrorMessage}";

                MessageBox.Show(exceptionMessage, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                var row = dataGridView1.Rows[e.RowIndex];


                txtMaPhieu.Text = row.Cells[0].Value.ToString();
                txtMaSach.Text = row.Cells[3].Value.ToString();
                txtMaNhanVien.Text = row.Cells[7].Value.ToString();
                txtMaDG.Text = row.Cells[8].Value.ToString();
                txtTenSach.Text = row.Cells[2].Value.ToString();


                if (row.Cells[4].Value != null && DateTime.TryParse(row.Cells[4].Value.ToString(), out DateTime ngayMuon))
                {
                    dateTimePicker1.Value = ngayMuon;
                }
                else
                {
                    dateTimePicker1.Value = DateTime.Now;
                }


                if (row.Cells[5].Value != null && DateTime.TryParse(row.Cells[5].Value.ToString(), out DateTime ngayTra))
                {
                    dateTimePicker2.Value = ngayTra;
                }
                else
                {
                    dateTimePicker2.Value = DateTime.Now;
                }


                cmbTrangThai.SelectedIndex = (row.Cells[6].Value.ToString() == "Đã trả") ? 0 : 1;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhieu = txtMaPhieu.Text.Trim();

                if (string.IsNullOrEmpty(maPhieu))
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập mã phiếu mượn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show("Bạn có chắc muốn xóa phiếu mượn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    phieuMuonService.DeletePhieu(maPhieu);
                    MessageBox.Show("Xóa phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    var listPhieu = phieuMuonService.GetAll();
                    BindGrid(listPhieu);

                    txtMaPhieu.Clear();
                    txtMaSach.Clear();
                    txtMaNhanVien.Clear();
                    txtMaDG.Clear();
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now.AddDays(7);
                    cmbTrangThai.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaPhieu.Text) ||
                    string.IsNullOrWhiteSpace(txtMaSach.Text) ||
                    string.IsNullOrWhiteSpace(txtMaNhanVien.Text) ||
                    string.IsNullOrWhiteSpace(txtMaDG.Text))
                {
                    MessageBox.Show("Tất cả các trường phải được điền đầy đủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var phieuMuon = new PHIEUMUON
                {
                    MaPhieuMuon = txtMaPhieu.Text,
                    NgayMuon = dateTimePicker1.Value,
                    NgayTra = dateTimePicker2.Value,
                    MaSach = txtMaSach.Text,
                    MaNhanVien = txtMaNhanVien.Text,
                    MaTheThanhVien = txtMaDG.Text,
                    TrangThai = cmbTrangThai.SelectedIndex == 0
                };

                phieuMuonService.UpdatePhieu(phieuMuon);

                MessageBox.Show("Cập nhật phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


                var listPhieu = phieuMuonService.GetAll();
                BindGrid(listPhieu);
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => $"{x.PropertyName}: {x.ErrorMessage}");

                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = $"Lỗi xác thực: {fullErrorMessage}";

                MessageBox.Show(exceptionMessage, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string maPhieuMuon = txtTimKiem.Text.Trim();

                if (string.IsNullOrWhiteSpace(maPhieuMuon))
                {
                    MessageBox.Show("Vui lòng nhập mã phiếu mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                var phieuMuon = phieuMuonService.GetPhieuMuonByMa(maPhieuMuon);

                if (phieuMuon != null)
                {
                    
                    BindGrid(new List<PHIEUMUON> { phieuMuon });
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phiếu mượn với mã: " + maPhieuMuon, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}
    

