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
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        ConnectDB db = new ConnectDB();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void getData()
        {
            string query = "Select * from KhachHang";
            DataSet ds = db.getData(query, "KhachHang", null);
            dgv_khachhang.DataSource = ds.Tables["KhachHang"];
        }
        public void Reload()
        {
            btn_them.Enabled = true;
            txt_makh.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            txt_makh.Text = "";
            txt_tenkhach.Text = "";
            txt_sdt.Text = "";
            txt_diachi.Text = "";
            txt_email.Text = "";
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            Reload();
            getData();
        }

        private void dgv_khachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_them.Enabled = false;
            txt_makh.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            int i = e.RowIndex;
            if (i >= 0)
            {
                txt_makh.Text = dgv_khachhang.Rows[i].Cells["IDKH"].Value.ToString();
                txt_tenkhach.Text = dgv_khachhang.Rows[i].Cells["TenKH"].Value.ToString();
                txt_sdt.Text = dgv_khachhang.Rows[i].Cells["SDT"].Value.ToString();
                txt_diachi.Text = dgv_khachhang.Rows[i].Cells["DiaChi"].Value.ToString();
                txt_email.Text = dgv_khachhang.Rows[i].Cells["Email"].Value.ToString();
            }
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            Reload();
            getData();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_makh.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin !");
                }
                else
                {
                    string query = "Insert into KhachHang values (@makh, @tenkh, @sdt, @diachi, @email)";
                    List<SqlParameter> data = new List<SqlParameter>();
                    data.Add(new SqlParameter("@makh", txt_makh.Text));
                    data.Add(new SqlParameter("@tenkh", txt_tenkhach.Text));
                    data.Add(new SqlParameter("@sdt", txt_sdt.Text));
                    data.Add(new SqlParameter("@diachi", txt_diachi.Text));
                    data.Add(new SqlParameter("@email", txt_email.Text));

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
                string query = "update KhachHang set TenKH = @tenkh,SDT=@sdt,DiaChi=@diachi,Email=@email where IDKH = @makh";
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@makh", txt_makh.Text));
                data.Add(new SqlParameter("@tenkh", txt_tenkhach.Text));
                data.Add(new SqlParameter("@sdt", txt_sdt.Text));
                data.Add(new SqlParameter("@diachi", txt_diachi.Text));
                data.Add(new SqlParameter("@email", txt_email.Text));

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
                string query = "delete from KhachHang where IDKH = @makh";
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@makh", txt_makh.Text));
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

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txt_timkiem.Text;
                string query = "select * from KhachHang where TenKH like '%' + @keyword + '%'";
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@keyword", keyword));
                DataSet ds = db.getData(query, "KhachHang", data);
                dgv_khachhang.DataSource = ds.Tables["KhachHang"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
