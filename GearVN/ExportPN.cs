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
    public partial class ExportPN : Form
    {
        public ExportPN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ExportPN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'GearVNDataSet.PhieuNhap' table. You can move, or remove it, as needed.
            this.PhieuNhapTableAdapter.Fill(this.GearVNDataSet.PhieuNhap);

            this.reportViewer1.RefreshReport();
        }
    }
}
