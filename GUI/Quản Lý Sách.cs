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

namespace GUI
{
    public partial class Quản_Lý_Sách : Form
    {
        private readonly SachService sachService = new SachService();
        Model1 context = new Model1();
        public Quản_Lý_Sách()
        {
            InitializeComponent();
            sachService = new SachService();
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
                dataGridView1.Rows[index].Cells[5].Value = item.THELOAI.TenTheLoai;
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
                BindGrid(listSach);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }

}
    

