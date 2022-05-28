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
    public partial class Nhacungcap : Form
    {
        public Nhacungcap()
        {
            InitializeComponent();
        }
        ConnectDB db = new ConnectDB();
        public void getData()
        {
            string query = "Select * from NhaCungCap";
            DataSet ds = db.getData(query, "NhaCungCap", null);
            dgv_nhacungcap.DataSource = ds.Tables["NhaCungCap"];
        }
        public void Reload()
        {
            btn_them.Enabled = true;
            txt_mancc.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            txt_mancc.Text = "";
            txt_tenncc.Text = "";
            txt_sdt.Text = "";
            txt_diachi.Text = "";
            txt_email.Text = "";
        }
        private void Nhacungcap_Load(object sender, EventArgs e)
        {
            Reload();
            getData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                    string query = "Insert into NhaCungCap values (@mancc, @tenncc, @sdt, @diachi, @email)";
                    List<SqlParameter> data = new List<SqlParameter>();
                    data.Add(new SqlParameter("@mancc", txt_mancc.Text));
                    data.Add(new SqlParameter("@tenncc", txt_tenncc.Text));
                    data.Add(new SqlParameter("@sdt", txt_sdt.Text));
                    data.Add(new SqlParameter("@diachi", txt_diachi.Text));
                    data.Add(new SqlParameter("@email", txt_email.Text));

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
            try
            {
                string query = "Update NhaCungCap set TenNCC = @tenncc,SDT=@sdt,DiaChi=@diachi,Email=@email where IDNCC = @mancc";
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@mancc", txt_mancc.Text));
                data.Add(new SqlParameter("@tenncc", txt_tenncc.Text));
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
                string query = "delete from NhaCungCap where IDNCC = @mancc";
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@mancc", txt_mancc.Text));
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
                string query = "select * from NhaCungCap where TenNCC like '%' + @keyword + '%'";
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@keyword", keyword));
                DataSet ds = db.getData(query, "NhaCungCap", data);
                dgv_nhacungcap.DataSource = ds.Tables["NhaCungCap"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgv_nhacungcap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_them.Enabled = false;
            txt_mancc.Enabled = false;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            int i = e.RowIndex;
            if (i >= 0)
            {
                txt_mancc.Text = dgv_nhacungcap.Rows[i].Cells["IDNCC"].Value.ToString();
                txt_tenncc.Text = dgv_nhacungcap.Rows[i].Cells["TenNCC"].Value.ToString();
                txt_sdt.Text = dgv_nhacungcap.Rows[i].Cells["SDT"].Value.ToString();
                txt_diachi.Text = dgv_nhacungcap.Rows[i].Cells["DiaChi"].Value.ToString();
                txt_email.Text = dgv_nhacungcap.Rows[i].Cells["Email"].Value.ToString();
            }
        }
    }
}
