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
    public partial class Nhanvien : Form
    {
        public Nhanvien()
        {
            InitializeComponent();
        }
        ConnectDB db = new ConnectDB();

        public void getData()
        {
            string query = "Select * from NhanVien";
            DataSet ds = db.getData(query, "NhanVien", null);
            dgv_nhanvien.DataSource = ds.Tables["NhanVien"];
        }
        public void Reload()
        {
            btn_them.Enabled = true;
            txt_manv.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            txt_manv.Text = "";
            txt_tennv.Text = "";
            txt_sdt.Text = "";
            txt_diachi.Text = "";
            dtngaysinh.Text = "";
            cmb_gt.SelectedIndex = 0;
            txt_chucvu.Text = "";
            txt_luongcoban.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Nhanvien_Load_1(object sender, EventArgs e)
        {
            Reload();
            getData();
        }

        private void dgv_nhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_them.Enabled = false;
            txt_manv.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            int i = e.RowIndex;
            if (i >= 0)
            {
                txt_manv.Text = dgv_nhanvien.Rows[i].Cells["IDNV"].Value.ToString();
                txt_tennv.Text = dgv_nhanvien.Rows[i].Cells["TenNV"].Value.ToString();
                txt_sdt.Text = dgv_nhanvien.Rows[i].Cells["SDT"].Value.ToString();
                txt_diachi.Text = dgv_nhanvien.Rows[i].Cells["DiaChi"].Value.ToString();
                dtngaysinh.Text = dgv_nhanvien.Rows[i].Cells["NamSinh"].Value.ToString();
                txt_chucvu.Text = dgv_nhanvien.Rows[i].Cells["ChucVu"].Value.ToString();
                txt_luongcoban.Text = dgv_nhanvien.Rows[i].Cells["LuongCoBan"].Value.ToString();
                cmb_gt.Text = dgv_nhanvien.Rows[i].Cells["GioiTinh"].Value.ToString();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_manv.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin !");
                }
                else
                {
                    string query = "Insert into NhanVien values (@manv, @tennv, @ngaysinh, @gioitinh, @sdt, @diachi, @chucvu, @luongcoban)";
                    List<SqlParameter> data = new List<SqlParameter>();
                    data.Add(new SqlParameter("@manv", txt_manv.Text));
                    data.Add(new SqlParameter("@tennv", txt_tennv.Text));
                    data.Add(new SqlParameter("@sdt", txt_sdt.Text));
                    data.Add(new SqlParameter("@ngaysinh", dtngaysinh.Text));
                    data.Add(new SqlParameter("@gioitinh", cmb_gt.Text));
                    data.Add(new SqlParameter("@diachi", txt_diachi.Text));
                    data.Add(new SqlParameter("@chucvu", txt_chucvu.Text));
                    data.Add(new SqlParameter("@luongcoban", txt_luongcoban.Text));

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
            try
            {
                string query = "Update NhanVien set TenNV=@tennv, NamSinh=@ngaysinh, GioiTinh=@gioitinh, SDT=@sdt, DiaChi=@diachi, ChucVu=@chucvu, LuongCoBan=@luongcoban where IDNV = @manv";
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@manv", txt_manv.Text));
                data.Add(new SqlParameter("@tennv", txt_tennv.Text));
                data.Add(new SqlParameter("@sdt", txt_sdt.Text));
                data.Add(new SqlParameter("@ngaysinh", dtngaysinh.Text));
                data.Add(new SqlParameter("@gioitinh", cmb_gt.Text));
                data.Add(new SqlParameter("@diachi", txt_diachi.Text));
                data.Add(new SqlParameter("@chucvu", txt_chucvu.Text));
                data.Add(new SqlParameter("@luongcoban", txt_luongcoban.Text));

                db.execute(query, data);
                MessageBox.Show("Sửa thành công !");
                Reload();
                getData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "delete from NhanVien where IDNV = @manv";
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@manv", txt_manv.Text));
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

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txt_timkiem.Text;
                string query = "select * from NhanVien where TenNV like '%' + @keyword + '%'";
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@keyword", keyword));
                DataSet ds = db.getData(query, "NhanVien", data);
                dgv_nhanvien.DataSource = ds.Tables["NhanVien"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
