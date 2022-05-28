using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GearVN
{
    public partial class ThongKePN : Form
    {
        public ThongKePN()
        {
            InitializeComponent();
        }

        ConnectDB db = new ConnectDB();
        public void getData()
        {
            string query = "Select * from PhieuNhap";
            DataSet ds = db.getData(query, "PhieuNhap", null);
            dgv_phieunhap.DataSource = ds.Tables["PhieuNhap"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ThongKe()
        {
            string query = "Select * from PhieuNhap where ((NgayNhap >='" + dt_start.Value.Date.ToString("MM-dd-yyyy") + "') AND (NgayNhap <='" + dt_end.Value.Date.ToString("MM-dd-yyyy") + "'))";
            DataSet ds = db.getData(query, "PhieuNhap", null);
            dgv_phieunhap.DataSource = ds.Tables["PhieuNhap"];
        }

        private void btn_thongke_Click(object sender, EventArgs e)
        {
            ThongKe();
            int cl = dgv_phieunhap.Rows.Count;
            double giagoc = 0;
            double thue = 0;
            double thanhtien = 0;
            for (int i = 0; i < cl - 1; i++)
            {
                giagoc += (double.Parse(dgv_phieunhap.Rows[i].Cells["SoLuongNhap"].Value.ToString())* double.Parse(dgv_phieunhap.Rows[i].Cells["DonGiaNhap"].Value.ToString()));
                thue += double.Parse(dgv_phieunhap.Rows[i].Cells["Thue"].Value.ToString());
                thanhtien += double.Parse(dgv_phieunhap.Rows[i].Cells["ThanhTien"].Value.ToString());
            }
            txt_giagoc.Text = giagoc.ToString();
            txt_tongthue.Text = thue.ToString();
            txt_thanhtien.Text = thanhtien.ToString();
        }

        private void ThongKePN_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            getData();
            txt_giagoc.Text = "";
            txt_tongthue.Text = "";
            txt_thanhtien.Text = "";
            dt_start.Value = DateTime.Today;
            dt_end.Value = DateTime.Today;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txt_thanhtien_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void dgv_phieunhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_tongthue_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_giagoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void dt_end_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dt_start_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
