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
    public partial class PhieuNhap : Form
    {
        public PhieuNhap()
        {
            InitializeComponent();
        }
        ConnectDB db = new ConnectDB();
        public void getData()
        {
            string query = "Select * from PhieuNhap";
            DataSet ds = db.getData(query, "PhieuNhap", null);
            dgv_phieunhap.DataSource = ds.Tables["PhieuNhap"];
            getCmb();
        }

        public void Reload()
        {
            btn_them.Enabled = true;
            txt_mapn.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            txt_mapn.Text = "";
            txt_soluong.Text = "";
            txt_thue.Text = "";
            dt_ngaynhap.Text = "";       
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
        public void getNCC()
        {
            string query = "Select * from NhaCungCap";
            DataSet ds = db.getData(query, "NhaCungCap", null);
            cmb_nhacc.DataSource = ds.Tables["NhaCungCap"];
            cmb_nhacc.ValueMember = "IDNCC";
            cmb_nhacc.DisplayMember = "TenNCC";
        }
        public void getCmb()
        {
            getMaHang();
            getMaNV();
            getNCC();
        }

        private void PhieuNhap_Load(object sender, EventArgs e)
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
            ExportPN ex = new ExportPN();
            ex.ShowDialog();
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            Reload();
            getData();
        }

        private void btn_tinhtien_Click(object sender, EventArgs e)
        {
            string query = "Select * from PhieuNhap where ((NgayNhap >='" + dt_start.Value.Date.ToString("MM-dd-yyyy") + "') AND (NgayNhap <='" + dt_end.Value.Date.ToString("MM-dd-yyyy") + "'))";
            DataSet ds = db.getData(query, "PhieuNhap", null);
            dgv_phieunhap.DataSource = ds.Tables["PhieuNhap"];
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_mapn.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin !");
                }
                else
                {
                    string query = "Insert into PhieuNhap values (@mapn, @ngaynhap, @manv, @mancc, @mahang, @soluong, @dongia, @thue,null)";
                    List<SqlParameter> data = new List<SqlParameter>();
                    data.Add(new SqlParameter("@mapn", txt_mapn.Text));
                    data.Add(new SqlParameter("@ngaynhap", dt_ngaynhap.Text));
                    data.Add(new SqlParameter("@manv", cmb_manv.SelectedValue.ToString()));
                    data.Add(new SqlParameter("@mancc", cmb_nhacc.SelectedValue.ToString()));
                    data.Add(new SqlParameter("@mahang", cmb_mahang.SelectedValue.ToString()));
                    data.Add(new SqlParameter("@soluong", txt_soluong.Text));
                    data.Add(new SqlParameter("@dongia", txt_dongia.Text));
                    data.Add(new SqlParameter("@thue", txt_thue.Text));

                    db.execute(query, data);
                    MessageBox.Show("Thêm thành công !");
                    Reload();
                    getData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string query = "Update PhieuNhap set NgayNhap=@ngaynhap,IDNV=@manv,IDNCC=@mancc,IDHANG=@mahang, SoLuongNhap=@soluong, DonGiaNhap=@dongia, Thue=@thue where IDPN=@mapn";
            List<SqlParameter> data = new List<SqlParameter>();
            data.Add(new SqlParameter("@mapn", txt_mapn.Text));
            data.Add(new SqlParameter("@ngaynhap", dt_ngaynhap.Text));
            data.Add(new SqlParameter("@manv", cmb_manv.SelectedValue.ToString()));
            data.Add(new SqlParameter("@mancc", cmb_nhacc.SelectedValue.ToString()));
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
                string query = "delete from PhieuNhap where IDPN = @mapn";
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@mapn", txt_mapn.Text));
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

        private void dgv_phieunhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_them.Enabled = false;
            txt_mapn.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            int i = e.RowIndex;
            if (i >= 0)
            {
                txt_mapn.Text = dgv_phieunhap.Rows[i].Cells["IDPN"].Value.ToString();
                dt_ngaynhap.Text = dgv_phieunhap.Rows[i].Cells["NgayNhap"].Value.ToString();
                cmb_manv.SelectedValue = dgv_phieunhap.Rows[i].Cells["IDNV"].Value;
                cmb_nhacc.SelectedValue = dgv_phieunhap.Rows[i].Cells["IDNCC"].Value;
                cmb_mahang.SelectedValue = dgv_phieunhap.Rows[i].Cells["IDHANG"].Value;
                txt_soluong.Text = dgv_phieunhap.Rows[i].Cells["SoLuongNhap"].Value.ToString();
                txt_dongia.Text = dgv_phieunhap.Rows[i].Cells["DonGiaNhap"].Value.ToString();
                txt_thue.Text = dgv_phieunhap.Rows[i].Cells["Thue"].Value.ToString();
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txt_timkiem.Text;
                string query = "select * from PhieuNhap where IDPN like '%' + @keyword + '%'";
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@keyword", keyword));
                DataSet ds = db.getData(query, "PhieuNhap", data);
                dgv_phieunhap.DataSource = ds.Tables["PhieuNhap"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_thongke_Click(object sender, EventArgs e)
        {
            ThongKePN pn = new ThongKePN();
            pn.ShowDialog();
        }
    }
}
