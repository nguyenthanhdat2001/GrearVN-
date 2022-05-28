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
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }
        private Form activeForm = null;
        private void openChilForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            DangNhap login = new DangNhap();
            DialogResult rs = login.ShowDialog();
            if (rs != DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            DialogResult result = MessageBox.Show("Bạn có muốn thoát ?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChilForm(new KhachHang());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChilForm(new Nhanvien());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChilForm(new Nhacungcap());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChilForm(new Hang());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChilForm(new PhieuNhap());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openChilForm(new PhieuXuat());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Bạn có muốn thoát phiên đăng nhập ?", "Đăng xuất", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                this.Hide();
                DangNhap dn = new DangNhap();
                dn.ShowDialog();
            }    
        }
    }
}
