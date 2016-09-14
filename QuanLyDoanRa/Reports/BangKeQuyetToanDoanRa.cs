using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain.Report;

namespace QuanLyDoanRa.Reports
{
    public partial class BangKeQuyetToanDoanRa : DevExpress.XtraReports.UI.XtraReport
    {
        public BangKeQuyetToanDoanRa()
        {
            InitializeComponent();
        }
        public string strTenBC = "";
        public void LoadData(IList<VnsReport> lstBaoCaoTongHop)
        {   
            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;            
            //lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;
            string str = "";
            if (lstBaoCaoTongHop.Count > 0)
            {
                VnsReport a = lstBaoCaoTongHop[0];
                str = a.TenDoanRa + " " + ". Quyết toán đoàn đ.c " + a.TenTruongDoan + " đi công tác tại " + a.NuocCongTac + " " + a.NgayDi;
            }
            lblTenTongHop.Text = str;
            lblThongBao2.Text = str;
            this.DataSource = lstBaoCaoTongHop;
        }

    }
}
