
namespace GearVN
{
    partial class ExportPX
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportPX));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PhieuXuatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GearVNDataSet1 = new GearVN.GearVNDataSet1();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ReportPX = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PhieuXuatTableAdapter = new GearVN.GearVNDataSet1TableAdapters.PhieuXuatTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PhieuXuatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GearVNDataSet1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PhieuXuatBindingSource
            // 
            this.PhieuXuatBindingSource.DataMember = "PhieuXuat";
            this.PhieuXuatBindingSource.DataSource = this.GearVNDataSet1;
            // 
            // GearVNDataSet1
            // 
            this.GearVNDataSet1.DataSetName = "GearVNDataSet1";
            this.GearVNDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(30)))), ((int)(((byte)(31)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 60);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Thông tin phiếu xuất";
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(900, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 60);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(950, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 60);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReportPX
            // 
            this.ReportPX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(52)))));
            this.ReportPX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportPX.DocumentMapWidth = 37;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.PhieuXuatBindingSource;
            this.ReportPX.LocalReport.DataSources.Add(reportDataSource1);
            this.ReportPX.LocalReport.ReportEmbeddedResource = "GearVN.ReportPX.rdlc";
            this.ReportPX.Location = new System.Drawing.Point(0, 60);
            this.ReportPX.Name = "ReportPX";
            this.ReportPX.ServerReport.BearerToken = null;
            this.ReportPX.Size = new System.Drawing.Size(1000, 490);
            this.ReportPX.TabIndex = 3;
            // 
            // PhieuXuatTableAdapter
            // 
            this.PhieuXuatTableAdapter.ClearBeforeFill = true;
            // 
            // ExportPX
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.ReportPX);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExportPX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExportPX";
            this.Load += new System.EventHandler(this.ExportPX_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PhieuXuatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GearVNDataSet1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer ReportPX;
        private System.Windows.Forms.BindingSource PhieuXuatBindingSource;
        private GearVNDataSet1 GearVNDataSet1;
        private GearVNDataSet1TableAdapters.PhieuXuatTableAdapter PhieuXuatTableAdapter;
        private System.Windows.Forms.Label label1;
    }
}