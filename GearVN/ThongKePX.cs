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
    public partial class ThongKePX : Form
    {
        public ThongKePX()
        {
            InitializeComponent();
        }

        ConnectDB db = new ConnectDB();
        public void getData()
        {
            string query = "Select * from PhieuXuat";
            DataSet ds = db.getData(query, "PhieuXuat", null);
            dgv_phieuxuat.DataSource = ds.Tables["PhieuXuat"];
        }

        public void ThongKe()
        {
            string query = "Select * from PhieuXuat where ((NgayXuat >='" + dt_start.Value.Date.ToString("MM-dd-yyyy") + "') AND (NgayXuat <='" + dt_end.Value.Date.ToString("MM-dd-yyyy") + "'))";
            DataSet ds = db.getData(query, "PhieuXuat", null);
            dgv_phieuxuat.DataSource = ds.Tables["PhieuXuat"];
        }

        private void btn_thongke_Click(object sender, EventArgs e)
        {
            ThongKe();
            int cl = dgv_phieuxuat.Rows.Count;
            double giagoc = 0;
            double thue = 0;
            double thanhtien = 0;
            for (int i = 0; i < cl - 1; i++)
            {
                giagoc += (double.Parse(dgv_phieuxuat.Rows[i].Cells["SoLuongXuat"].Value.ToString()) * double.Parse(dgv_phieuxuat.Rows[i].Cells["DonGiaXuat"].Value.ToString()));
                thue += double.Parse(dgv_phieuxuat.Rows[i].Cells["Thue"].Value.ToString());
                thanhtien += double.Parse(dgv_phieuxuat.Rows[i].Cells["ThanhTien"].Value.ToString());
            }
            txt_giagoc.Text = giagoc.ToString();
            txt_tongthue.Text = thue.ToString();
            txt_thanhtien.Text = thanhtien.ToString();
        }

        private void ThongKePX_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
