using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GearVN
{
    public partial class PhieuXuat : Form
    {
        public PhieuXuat()
        {
            InitializeComponent();
        }
        ConnectDB db = new ConnectDB();
        public void getData()
        {
            string query = "Select * from PhieuXuat";
            DataSet ds = db.getData(query, "PhieuXuat", null);
            dgv_phieuxuat.DataSource = ds.Tables["PhieuXuat"];
            getCmb();
        }
        public void Reload()
        {
            btn_them.Enabled = true;
            txt_mapx.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            txt_mapx.Text = "";
            txt_soluong.Text = "";
            txt_thue.Text = "";
            dt_ngayxuat.Text = "";
            txt_dongia.Text = "";
            dt_start.Value = DateTime.Today;
            dt_end.Value = DateTime.Today;
        }
        public void getMaHang()
        {
            string query = "Select * from Hang";
            DataSet ds = db.getData(query, "Hang", null);
            cmb_mahang.DataSource = ds.Tables["Hang"];
            cmb_mahang.ValueMember = "IDHANG";
            cmb_mahang.DisplayMember = "TenHang";
        }
        public void getMaNV()
        {
            string query = "Select * from NhanVien";
            DataSet ds = db.getData(query, "NhanVien", null);
            cmb_manv.DataSource = ds.Tables["NhanVien"];
            cmb_manv.ValueMember = "IDNV";
            cmb_manv.DisplayMember = "TenNV";
        }
        public void getKhach()
        {
            string query = "Select * from KhachHang";
            DataSet ds = db.getData(query, "KhachHang", null);
            cmb_khach.DataSource = ds.Tables["KhachHang"];
            cmb_khach.ValueMember = "IDKH";
            cmb_khach.DisplayMember = "TenKH";
        }
        public void getCmb()
        {
            getMaHang();
            getMaNV();
            getKhach();
        }


        private void PhieuXuat_Load(object sender, EventArgs e)
        {
            Reload();
            getData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            ExportPX ex = new ExportPX();
            ex.ShowDialog();
        }

        private void dgv_phieuxuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_them.Enabled = false;
            txt_mapx.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            int i = e.RowIndex;
            if (i >= 0)
            {
                txt_mapx.Text = dgv_phieuxuat.Rows[i].Cells["IDPX"].Value.ToString();
                dt_ngayxuat.Text = dgv_phieuxuat.Rows[i].Cells["NgayXuat"].Value.ToString();
                cmb_manv.SelectedValue = dgv_phieuxuat.Rows[i].Cells["IDNV"].Value;
                cmb_khach.SelectedValue = dgv_phieuxuat.Rows[i].Cells["IDKH"].Value;
                cmb_mahang.SelectedValue = dgv_phieuxuat.Rows[i].Cells["IDHANG"].Value;
                txt_soluong.Text = dgv_phieuxuat.Rows[i].Cells["SoLuongXuat"].Value.ToString();
                txt_dongia.Text = dgv_phieuxuat.Rows[i].Cells["DonGiaXuat"].Value.ToString();
                txt_thue.Text = dgv_phieuxuat.Rows[i].Cells["Thue"].Value.ToString();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                    string query = "Insert into PhieuXuat values (@mapx, @ngayxuat, @manv, @makh, @mahang, @soluong, @dongia, @thue,null)";
                    List<SqlParameter> data = new List<SqlParameter>();
                    data.Add(new SqlParameter("@mapx", txt_mapx.Text));
                    data.Add(new SqlParameter("@ngayxuat", dt_ngayxuat.Text));
                    data.Add(new SqlParameter("@manv", cmb_manv.SelectedValue.ToString()));
                    data.Add(new SqlParameter("@makh", cmb_khach.SelectedValue.ToString()));
                    data.Add(new SqlParameter("@mahang", cmb_mahang.SelectedValue.ToString()));
                    data.Add(new SqlParameter("@soluong", txt_soluong.Text));
                    data.Add(new SqlParameter("@dongia", txt_dongia.Text));
                    data.Add(new SqlParameter("@thue", txt_thue.Text));

                    db.execute(query, data);
                    MessageBox.Show("Thêm thành công !");
                    Reload();
                    getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string query = "Update PhieuXuat set NgayXuat=@ngayxuat,IDNV=@manv,IDKH=@makh,IDHANG=@mahang, SoLuongXuat=@soluong, DonGiaXuat=@dongia, Thue=@thue where IDPX=@mapx";
            List<SqlParameter> data = new List<SqlParameter>();
            data.Add(new SqlParameter("@mapx", txt_mapx.Text));
            data.Add(new SqlParameter("@ngayxuat", dt_ngayxuat.Text));
            data.Add(new SqlParameter("@manv", cmb_manv.SelectedValue.ToString()));
            data.Add(new SqlParameter("@makh", cmb_khach.SelectedValue.ToString()));
            data.Add(new SqlParameter("@mahang", cmb_mahang.SelectedValue.ToString()));
            data.Add(new SqlParameter("@soluong", txt_soluong.Text));
            data.Add(new SqlParameter("@dongia", txt_dongia.Text));
            data.Add(new SqlParameter("@thue", txt_thue.Text));

            db.execute(query, data);
            MessageBox.Show("Sửa thành công !");
            Reload();
            getData();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "delete from PhieuXuat where IDPX = @mapx";
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@mapx", txt_mapx.Text));
                db.execute(query, data);
                MessageBox.Show("Xóa thành công !");
                Reload();
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            Reload();
            getData();
        }

        private void btn_tinhtien_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txt_timkiem.Text;
                string query = "select * from PhieuXuat where IDPX like '%' + @keyword + '%'";
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@keyword", keyword));
                DataSet ds = db.getData(query, "PhieuXuat", data);
                dgv_phieuxuat.DataSource = ds.Tables["PhieuXuat"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_timkiemngay_Click(object sender, EventArgs e)
        {
            string query = "Select * from PhieuXuat where ((NgayXuat >='" + dt_start.Value.Date.ToString("MM-dd-yyyy") + "') AND (NgayXuat <='" + dt_end.Value.Date.ToString("MM-dd-yyyy") + "'))";
            DataSet ds = db.getData(query, "PhieuNhap", null);
            dgv_phieuxuat.DataSource = ds.Tables["PhieuNhap"];
        }

        private void btn_thongke_Click(object sender, EventArgs e)
        {
            ThongKePX px = new ThongKePX();
            px.ShowDialog();
        }
    }
}
