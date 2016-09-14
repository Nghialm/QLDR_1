using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.QuanLyDoanRa.Domain.Report;

namespace QuanLyDoanRa
{
    public partial class FrmNamKeToan : DevExpress.XtraEditors.XtraForm
    {
        public IReportService ReportService;

        public FrmNamKeToan()
        {
            InitializeComponent();
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            string namketoan = txtNam.Text;
            General.NamKeToan = int.Parse(txtNam.Text);
            GetXmlInfo.WriteInfo(namketoan);

            

            this.Close();
        }

        private void FrmTongHopKinhPhi_Load(object sender, EventArgs e)
        {
            int namketoan = GetXmlInfo.GetNamKeToan();
            txtNam.Text = namketoan.ToString();
        }

        private void FrmNamKeToan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    }
}