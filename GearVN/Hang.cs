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
    public partial class Hang : Form
    {
        public Hang()
        {
            InitializeComponent();
        }
        ConnectDB db = new ConnectDB();

        public void getData()
        {
            string query = "Select * from Hang";
            DataSet ds = db.getData(query, "Hang", null);
            dgv_hang.DataSource = ds.Tables["Hang"];
        }

        public void Reload()
        {
            btn_Them.Enabled = true;
            txt_mahang.Enabled = true;
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
            txt_mahang.Text = "";
            txt_tenhang.Text = "";
            txt_nhasx.Text = "";
            txt_loaihang.Text = "";
            txt_baohanh.Text = "";
            txt_mota.Text = "";
        }

        private void Hang_Load(object sender, EventArgs e)
        {
            Reload();
            getData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_hang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Them.Enabled = false;
            txt_mahang.Enabled = false;
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
            int i = e.RowIndex;
            if(i >= 0)
            {
                txt_mahang.Text = dgv_hang.Rows[i].Cells["IDHANG"].Value.ToString();
                txt_tenhang.Text = dgv_hang.Rows[i].Cells["TenHang"].Value.ToString();
                txt_loaihang.Text = dgv_hang.Rows[i].Cells["LoaiHang"].Value.ToString();
                txt_nhasx.Text = dgv_hang.Rows[i].Cells["NhaSX"].Value.ToString();
                txt_baohanh.Text = dgv_hang.Rows[i].Cells["BaoHanh"].Value.ToString();
                txt_mota.Text = dgv_hang.Rows[i].Cells["MoTa"].Value.ToString();
            }
        }

        private void btn_Lammoi_Click(object sender, EventArgs e)
        {
            Reload();
            getData();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if(txt_mahang.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập thông tin !");
                }
                else
                {
                    string query = "Insert into Hang values (@mahang, @tenhang, @loaihang, @nhasx, @baohanh, @mota)";
                    List<SqlParameter> data = new List<SqlParameter>();
                    data.Add(new SqlParameter("@mahang", txt_mahang.Text));
                    data.Add(new SqlParameter("@tenhang", txt_tenhang.Text));
                    data.Add(new SqlParameter("@loaihang", txt_loaihang.Text));
                    data.Add(new SqlParameter("@nhasx", txt_nhasx.Text));
                    data.Add(new SqlParameter("@baohanh", txt_baohanh.Text));
                    data.Add(new SqlParameter("@mota", txt_mota.Text));

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

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "Update Hang set TenHang = @tenhang, LoaiHang = @loaihang, NhaSX = @nhasx, BaoHanh = @baohanh, MoTa = @mota where IDHANG = @mahang";
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@mahang", txt_mahang.Text));
                data.Add(new SqlParameter("@tenhang", txt_tenhang.Text));
                data.Add(new SqlParameter("@loaihang", txt_loaihang.Text));
                data.Add(new SqlParameter("@nhasx", txt_nhasx.Text));
                data.Add(new SqlParameter("@baohanh", txt_baohanh.Text));
                data.Add(new SqlParameter("@mota", txt_mota.Text));

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

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {  
                string query = "delete from Hang where IDHANG = @mahang";
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@mahang", txt_mahang.Text));
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

        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txt_timkiem.Text;
                string query = "select * from Hang where TenHang like '%' + @keyword + '%' or LoaiHang like '%' + @keyword + '%'";
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@keyword", keyword));
                DataSet ds = db.getData(query, "Hang", data);
                dgv_hang.DataSource = ds.Tables["Hang"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
