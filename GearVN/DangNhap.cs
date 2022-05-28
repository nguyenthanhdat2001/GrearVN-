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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string con_str = "Data Source=NGUYENTHANHDAT\\SQLEXPRESS;Initial Catalog=GearVN;User ID=sa;Password=123456";
                SqlConnection conn = new SqlConnection(con_str);
                conn.Open();

                string tk = textBox1.Text;
                string mk = textBox2.Text;
                string query = "select count(*) from DangNhap where TaiKhoan = @tk and MatKhau = @mk";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@tk", tk));
                cmd.Parameters.Add(new SqlParameter("@mk", mk));
                int soluong = (int)cmd.ExecuteScalar();

                conn.Close();

                if (soluong == 1)
                {
                    MessageBox.Show("Đăng nhập thành công !");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản mật khẩu không chính xác");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
