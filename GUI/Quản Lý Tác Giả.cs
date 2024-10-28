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
using BUS.TacGia;

namespace GUI
{
    public partial class Quản_Lý_Tác_Giả : Form
    {
        private readonly TacGiaService tacGiaService = new TacGiaService();       
        Model1 context = new Model1();
        public Quản_Lý_Tác_Giả()
        {
            InitializeComponent();
            tacGiaService = new TacGiaService();
        }
        private void BindGrid(List<TACGIA> listTacGia)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in listTacGia)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.MaTacGia;
                dataGridView1.Rows[index].Cells[1].Value = item.Ten;
                dataGridView1.Rows[index].Cells[2].Value = item.HoLot;
                dataGridView1.Rows[index].Cells[3].Value = item.TieuSuTacGia;                
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

        private void Quản_Lý_Tác_Giả_Load(object sender, EventArgs e)
        {
            try

            {
                setGridViewStyle(dataGridView1);
                var listTG = tacGiaService.GetAll();
                BindGrid(listTG);               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QuảnLý frm1 = new QuảnLý();
            frm1.Show();
            this.Hide();
        }
    }
}
