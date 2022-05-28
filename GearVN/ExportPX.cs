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
    public partial class ExportPX : Form
    {
        public ExportPX()
        {
            InitializeComponent();
        }

        private void ExportPX_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'GearVNDataSet1.PhieuXuat' table. You can move, or remove it, as needed.
            this.PhieuXuatTableAdapter.Fill(this.GearVNDataSet1.PhieuXuat);

            this.ReportPX.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
