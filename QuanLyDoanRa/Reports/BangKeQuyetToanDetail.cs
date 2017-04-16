using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Service;
using System.Data;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.Erp.Core;

namespace QuanLyDoanRa.Reports
{
    public partial class BangKeQuyetToanDetail : DevExpress.XtraReports.UI.XtraReport
    {
        public IRP_BC04DRService RP_BC04DRService;
        public IVnsDoanCongTacService VnsDoanCongTacService;
        public IReportService ReportService;
        DataTable dt;
        public BangKeQuyetToanDetail()
        {
            InitializeComponent();
        }

        public BangKeQuyetToanDetail(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo, string p_TrangThaiCt, string TenCt, string p_Time, int GiaTri) 
        {
            InitializeComponent();

            lblChucDanhNguoiKiBangBieu.Text = General.ChucDanhNguoiKyBangBieu;
            //lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiKyBangBieu;
            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;
            lblTenNguoiKiBangBieu.Text = General.TenNguoiKyBangBieu;
            lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;
            lblSignDate.Text = General.GenSignDate_EndMonth(p_DenNgay);

            lblTenBc.Text = "BẢNG KÊ QUYẾT TOÁN ĐOÀN RA " + TenCt.ToUpper();
            lblTime.Text = p_Time;
            RP_BC04DRService = (IRP_BC04DRService)ObjectFactory.GetObject("RP_BC04DRService");
            VnsDoanCongTacService = (IVnsDoanCongTacService)ObjectFactory.GetObject("VnsDoanCongTacService");
            ReportService = (IReportService)ObjectFactory.GetObject("ReportService");
            //List<RP_SoDuTaiKhoan> lstSoDuTk;
            
            //lstSoDuTk = RP_BC04DRService.GetBangKeQuyetToan(p_TuNgay, p_DenNgay, p_TkCo, p_TkNo, p_TrangThaiCt);

            IList<VnsReportTongHop> lst = ReportService.BaoCaoTongHopDoanRa(p_TuNgay, p_DenNgay, Null.NullGuid, 2, Vns.QuanLyDoanRa.ReportType.RP02);
            

            List<RP_BangKeCtGhiSo> lstBangKe = new List<RP_BangKeCtGhiSo>();
            RP_BangKeCtGhiSo objBangke;
            RP_SoDuTaiKhoan objSoDu;
            foreach (VnsReportTongHop tmp in lst)
            {
                objBangke = new RP_BangKeCtGhiSo();
                objSoDu = new RP_SoDuTaiKhoan();

                objBangke.DoanRaId = tmp.DoanRaId;
                objBangke.TenDoanRa = tmp.TenDoanRa;
                objBangke.LoaiDoanRaId = tmp.LoaiDoanRaId;
                objBangke.TenLoaiDoanRa = tmp.TenLoaiDoanRa;

                objBangke.SoTBDT = tmp.SoTbDt;
                objBangke.SoTBQT = tmp.SoTbQt;

                objBangke.NgayHt = p_TuNgay;
                objBangke.NgayCt = p_TuNgay;
                objBangke.DienGiai = String.Format("Quyết toán đoàn đ.c {0} - {1} - đi {2} bằng ngoại tệ TM, CK thanh toán theo TBQT số: {3} -TB/VPTW/nb - ngày {4}",
                    tmp.TruongDoanFullName, tmp.TenDoanRaVietTat, tmp.NuocCongTac, tmp.SoTbQt, tmp.ThangDuyetQt.ToString("dd-MM-yyyy"));
                
                //objBangke.TmUSD = tmp.So_QT_TM_USD - tmp.Chi_QT_TM_USD;
                //objBangke.TmVND = tmp.So_QT_TM_VND - tmp.Chi_QT_TM_VND;
                objBangke.TmUSD = tmp.Tk_Qt_Tm_Usd;
                objBangke.TmVND = tmp.Tk_Qt_Tm_Vnd;
                objBangke.TmTyGia = objBangke.TmUSD == 0 ? 0 : tmp.Tk_Qt_Tm_Tg;
                
                //objBangke.CkUSD = tmp.So_QT_CK_USD - tmp.Chi_QT_CK_USD;
                //objBangke.CkVND = tmp.So_QT_CK_VND -  tmp.Chi_QT_CK_VND;
                //objBangke.CkTyGia = objBangke.CkUSD == 0 ? 0 : tmp.So_QT_CK_TG;
                objBangke.CkUSD = tmp.Tk_Qt_Ck_Usd;
                objBangke.CkVND = tmp.Tk_Qt_Ck_Vnd;
                objBangke.CkTyGia = objBangke.CkUSD == 0 ? 0 : tmp.Tk_Qt_Ck_Tg;

                objBangke.VNDTm = tmp.So_QT_VND_TM - tmp.Chi_VND_QT_TM;
                objBangke.VNDCk = tmp.So_QT_TONG_VND_USD - tmp.Chi_VND_QT_CK;// tmp.So_QT_VND_CK - tmp.Chi_VND_QT_CK;

                //objBangke.TongUSD = objBangke.TmUSD + objBangke.CkUSD;
                objBangke.TongVND = objBangke.TmVND + objBangke.CkVND + objBangke.VNDTm + objBangke.VNDCk;

                if (tmp.ThangDuyetQt >= p_TuNgay && tmp.ThangDuyetQt <= p_DenNgay)
                    lstBangKe.Add(objBangke);    
            }

            lstBangKe.Sort(RP_BangKeCtGhiSo.CompareSoTBQT);
            dt = Commons.Commons.ToDataTable<RP_BangKeCtGhiSo>(lstBangKe);
            
        }

        public DataTable GetData(DataTable data)//(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo, string p_TrangThaiCt, string TenCt, string p_Time, int GiaTri) 
        {
            InitializeComponent();          
            return data;
        }

        private void BangKeQuyetToanDetail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.DataSource = dt;
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
