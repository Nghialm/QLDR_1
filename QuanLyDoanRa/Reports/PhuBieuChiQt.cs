using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Vns.QuanLyDoanRa.Service.Interface;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.Erp.Core;
namespace QuanLyDoanRa.Reports
{
    public partial class PhuBieuChiQt : DevExpress.XtraReports.UI.XtraReport
    {
        private  DateTime dTuNgay = DateTime.Now;
        private DateTime dDenNgay = DateTime.Now;
        private string time = "";
        public PhuBieuChiQt(DateTime tn, DateTime dn, string tm)
        {
            InitializeComponent();
            dTuNgay = tn;
            dDenNgay = dn;
            time = tm;
        }
        

        int i = 0;
        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            i++;
            if (i == 1)
                e.Cancel = true;
        }

        private void PhuBieuChiQT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblTenBaoCao.Text = "PHỤ BIỂU CHI TIẾT QUYẾT TOÁN KINH PHÍ ĐOÀN RA " + time.ToUpper();
            lblPhu.Text = "(Kèm theo tổng hơp quyết toán số      - QT/VPTW, ngày    tháng   năm    )";
            lblDonVi.Text = "";

            lblChucDanhNguoiKiBangBieu.Text = General.ChucDanhNguoiKyBangBieu;
            lblNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;
            lblTenNguoiKyBangBieu.Text = General.TenNguoiKyBangBieu;
            lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;
            lblSignDate.Text = General.GenSignDate(dDenNgay);

            IReportService ReportService = (IReportService)ObjectFactory.GetObject("ReportService");
            int TongSoDoan = 0; int TongSoQuyetToan = 0;

            /*
             * 1. Quyet toan
             * 2. Tam ung
             * 3. Nuoc di cong tac
             * 4. So nguoi di cong tac
             */
            IList<PhuBieuChiQt_Dem> lst_dem = new List<PhuBieuChiQt_Dem>();

            IList<PhuBieuChiQT> lstSource = ReportService.PhuBieuChiQt(dTuNgay, dDenNgay, out lst_dem);
            this.DataSource = lstSource;

            PhuBieuChiQt_Dem doan_qt = lst_dem[0];
            PhuBieuChiQt_Dem doan_tu = lst_dem[1];
            PhuBieuChiQt_Dem nuoc_ct = lst_dem[2];
            PhuBieuChiQt_Dem songuoidi = lst_dem[3];

            xrDrQt.Text = doan_qt.Tong.ToString(); xrDrQt_BD.Text = doan_qt.CacBanDang.ToString(); xrDrQt_165.Text = doan_qt.DeAn165.ToString();

            xrDr.Text = doan_tu.Tong.ToString(); xrDr_BD.Text = doan_tu.CacBanDang.ToString(); xrDr_165.Text = doan_tu.DeAn165.ToString();

            xrDr_N.Text = nuoc_ct.Tong.ToString(); xrDr_N_BD.Text = nuoc_ct.CacBanDang.ToString(); xrDr_N_165.Text = nuoc_ct.DeAn165.ToString();

            xrDr_Tv.Text = songuoidi.Tong.ToString(); xrDr_Tv_BD.Text = songuoidi.CacBanDang.ToString(); xrDr_Tv_165.Text = songuoidi.DeAn165.ToString();
        }
    }
}
