using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.QuanLyDoanRa.Service.Report;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.QuanLyDoanRa.Domain;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain.Report;


namespace QuanLyDoanRa.Reports
{
    public partial class ChungTuGhiSo_RutTienMat : DevExpress.XtraReports.UI.XtraReport
    {
        public IReportService ReportService;
        private IVnsDoanCongTacService _VnsDoanCongTacService;
        public IVnsDoanCongTacService VnsDoanCongTacService
        {
            get { return _VnsDoanCongTacService; }
            set { _VnsDoanCongTacService = value; }
        }

        int iGiaTri;
        DateTime TuNgay;
        DateTime DenNgay;
        string strTime = "";
        string str_TrangThaiCt = "";
        string str_TKNo = "";
        string str_TKCo = "";

        IList<RP_ChungTuGhiSo> lstData = new List<RP_ChungTuGhiSo>();

        public ChungTuGhiSo_RutTienMat()
        {
            InitializeComponent();
        }
        public ChungTuGhiSo_RutTienMat(DateTime p_TuNgay, DateTime p_DenNgay, string p_TkCo, string p_TkNo, string p_TrangThaiCt, int giaTri, string TimeTitle)
        {
            InitializeComponent();
            ReportService = (ReportService)ObjectFactory.GetObject("ReportService");
            iGiaTri = giaTri;
            TuNgay = p_TuNgay;
            DenNgay = p_DenNgay;
            strTime = TimeTitle;
            str_TrangThaiCt = p_TrangThaiCt;
            str_TKCo = p_TkCo;
            str_TKNo = p_TkNo;
            lblNgayThangNam.Text = "Ngày " + p_DenNgay.Day.ToString() + " tháng " + p_DenNgay.Month.ToString() + " năm " + p_DenNgay.Year.ToString();
            //lblKeToanTruong.Text = General.ChucDanhNguoiKyBangBieu;
            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;
            lblTenNguoiKiBangBieu.Text = General.TenNguoiKyBangBieu;
            lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;

            if (giaTri != 3)
                lstData = ReportService.RPChungTuGhiSo(TuNgay, DenNgay, str_TKCo, str_TKNo, str_TrangThaiCt, iGiaTri, strTime);
            else
                lstData = ReportService.RPChungTuGhiSo_QT(TuNgay, DenNgay, str_TKCo, str_TKNo, str_TrangThaiCt, iGiaTri, strTime); //Tam thoi
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ChungTuGhiSoHeader_RutTienMat p1 = (ChungTuGhiSoHeader_RutTienMat)((XRSubreport)sender).ReportSource;
            if (iGiaTri == 1 || iGiaTri == 5)
            {
                p1.DataSource = p1.GetData(lstData, 1);
            }
            else
                p1.DataSource = p1.GetData(lstData, 2);
            
        }

        private void xrSubreport2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ChungTuGhiSoDetail_RutTienMat p2 = (ChungTuGhiSoDetail_RutTienMat)((XRSubreport)sender).ReportSource;
            p2.DataSource = p2.GetData(lstData);
        }
    }
}
