using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Vns.QuanLyDoanRa.Service.Interface;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain.Report;

namespace QuanLyDoanRa.Reports
{
    public partial class B02DR_P4 : DevExpress.XtraReports.UI.XtraReport
    {
        public string strTitle = "";

        public B02DR_P4()
        {
            InitializeComponent();
        }
        public void LoadData(IList<VnsReportTongHop> lstTongHopDoanRa)
        {
            //lblTenBaoCao.Text = "CÔNG NỢ " + strTitle.ToUpper(); ;
            lblChucDanhNguoiKiBangBieu.Text = General.ChucDanhNguoiKyBangBieu;
            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;
            lblTenNguoiKiBangBieu.Text = General.TenNguoiKyBangBieu;
            lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;

            this.DataSource = lstTongHopDoanRa;
        }
        int i = 0;
        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            i++;
            if (i == 1)
                e.Cancel = true;
        }
    }
}
