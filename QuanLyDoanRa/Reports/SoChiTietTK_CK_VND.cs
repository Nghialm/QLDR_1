using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Service.Interface;
using System.Collections.Generic;

namespace QuanLyDoanRa.Reports
{
    public partial class SoChiTietTK_CK_VND : DevExpress.XtraReports.UI.XtraReport
    {
        public SoChiTietTK_CK_VND()
        {
            InitializeComponent();
        }

        private DateTime m_TuNgay;
        private DateTime m_DenNgay;
        private string m_MaTK;
        private string m_MaTKDu;
        private IRP_SoDuTaiKhoanService RP_SoDuTaiKhoanService;
        private IVnsSoDuCuoiKyService VnsSoDuCuoiKyService;
        private IReportService ReportService;
        public SoChiTietTK_CK_VND(DateTime p_TuNgay, DateTime p_DenNgay, String Time, string MaTk, string MaTkDu)
        {
            InitializeComponent();
            m_TuNgay = p_TuNgay;
            m_DenNgay = p_DenNgay;
            m_MaTK = MaTk;
            m_MaTKDu = MaTkDu;
            RP_SoDuTaiKhoanService = (IRP_SoDuTaiKhoanService)ObjectFactory.GetObject("RP_SoDuTaiKhoanService");
            VnsSoDuCuoiKyService = (IVnsSoDuCuoiKyService)ObjectFactory.GetObject("VnsSoDuCuoiKyService");
            ReportService = (IReportService)ObjectFactory.GetObject("ReportService");
            if (MaTk ==Vns.QuanLyDoanRa.Globals.TkTienMat)
            {
                lblTenBc.Text = string.Format("SỔ CHI TIẾT TÀI KHOẢN {0} ĐOÀN RA NĂM {1}", "111.2", p_TuNgay.Year.ToString());
                lblTime.Text = string.Format("Nợ TK 312 tạm ứng các đoàn đi công tác nước ngoài tháng {0}-{1}", p_TuNgay.ToString("MM"), p_DenNgay.Year.ToString());
                lblPhiChuyenTien.Visible = true;

                decimal vnd = 0;
                decimal usd = 0;
                IList<RP_SoDuTaiKhoan> lstPhiChuyenTien = RP_SoDuTaiKhoanService.lstPhatSinhTrongThang(m_TuNgay, m_DenNgay, Vns.QuanLyDoanRa.Globals.TkThuNganSach, Vns.QuanLyDoanRa.Globals.TkNghiepVuChiHoatDong);
                foreach (RP_SoDuTaiKhoan obj in lstPhiChuyenTien)
                {
                    if (obj.MaTkNo.StartsWith(Vns.QuanLyDoanRa.Globals.TkNghiepVuChiHoatDong) && obj.MaTkCo.StartsWith(Vns.QuanLyDoanRa.Globals.TkThuNganSach))
                    {
                        vnd += obj.PsGiamVND;
                        usd += obj.PsGiamUSD;
                    }
                }
                lblPhiChuyenTien.Text = string.Format("Phí chuyển tiền {0} USD x {1} đ = {2} đ", usd.ToString("n0"), usd == 0 ? "0" : (vnd / usd).ToString("n0"), vnd.ToString("n0"));
            }
            else if (MaTk == Vns.QuanLyDoanRa.Globals.TkTienChuyenKhoan)
            {
                lblTenBc.Text = string.Format("SỔ CHI TIẾT TÀI KHOẢN {0} ĐOÀN RA NĂM {1}", "3791.1.105. 8969", p_TuNgay.Year.ToString());
                lblTime.Text = string.Format("Số TK {0} chuyển khoản các đoàn đi công tác nước ngoài tháng {1}-{2}", "112.2", p_TuNgay.ToString("MM"),p_TuNgay.Year.ToString());
                lblPhiChuyenTien.Visible = false;
            }
            else
            {
                lblTenBc.Text = string.Format("SỔ CHI TIẾT TÀI KHOẢN {0} ĐOÀN RA ", MaTk);
                lblTime.Text = Time;
            }

            lblChucDanhNguoiKiBangBieu.Text = General.ChucDanhNguoiKyBangBieu;
            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;
            lblTenNguoiKiBangBieu.Text = General.TenNguoiKyBangBieu;
            lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;
        }

        private void SoChiTietTK_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            SoChiTietTK_CK_VND_P1 p1 = (SoChiTietTK_CK_VND_P1)((XRSubreport)sender).ReportSource;

            IList<RP_SoDuTaiKhoan> lstdata = new List<RP_SoDuTaiKhoan>();

            if (m_MaTK == Vns.QuanLyDoanRa.Globals.TkTienMat || m_MaTK == Vns.QuanLyDoanRa.Globals.TkTienChuyenKhoan)
            {
                //p1.DataSource = p1.GetData(ReportService.GetListSoDuTaiKhoan(m_MaTK,DateTime.MinValue, m_TuNgay.AddDays(-1), Null.NullGuid, Null.NullGuid));
                lstdata = ReportService.GetListSoDuTaiKhoan(m_MaTK, Null.NullDate, m_TuNgay.AddDays(-1), Null.NullGuid, Null.NullGuid);
            }
            else
            {
                //p1.DataSource = p1.GetData(RP_SoDuTaiKhoanService.lstGetDuCoCtTk112ThangTruocChuyenSang(DateTime.MinValue, m_TuNgay.AddDays(-1), m_MaTK, m_MaTKDu));
                lstdata = RP_SoDuTaiKhoanService.lstGetDuCoCtTk112ThangTruocChuyenSang(Null.NullDate, m_TuNgay.AddDays(-1), m_MaTK, m_MaTKDu);
            }

            for (int i = lstdata.Count -1; i >= 0; i--)
            {
                if (lstdata[i].SoDuUSD == 0)
                    lstdata.RemoveAt(i);
            }

            p1.DataSource = p1.GetData(lstdata, m_MaTK);
        }

        private void xrSubreport2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            SoChiTietTK_CK_VND_P2 p2 = (SoChiTietTK_CK_VND_P2)((XRSubreport)sender).ReportSource;
           
            IList<RP_SoDuTaiKhoan> lstSoDu = RP_SoDuTaiKhoanService.lstPhatSinhTrongThang(m_TuNgay, m_DenNgay, m_MaTK, m_MaTKDu);          
            
            p2.DataSource = p2.GetData(lstSoDu);
        }

        private void xrSubreport3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            SoChiTietTK_CK_VND_P3 p3 = (SoChiTietTK_CK_VND_P3)((XRSubreport)sender).ReportSource;
            IList<RP_SoDuTaiKhoan> lstdata = new List<RP_SoDuTaiKhoan>();
            if (m_MaTK == Vns.QuanLyDoanRa.Globals.TkTienMat || m_MaTK == Vns.QuanLyDoanRa.Globals.TkTienChuyenKhoan)
            {
                lstdata = ReportService.GetListSoDuTaiKhoan(m_MaTK, Null.NullDate, m_DenNgay, Null.NullGuid, Null.NullGuid);
            }
            else
            {
                lstdata = RP_SoDuTaiKhoanService.lstGetDuCoCtTk112ThangTruocChuyenSang(Null.NullDate, m_DenNgay, m_MaTK, m_MaTKDu);
            }

            for (int i = lstdata.Count - 1; i >= 0; i--)
            {
                if (lstdata[i].SoDuUSD == 0)
                    lstdata.RemoveAt(i);
            }

            p3.DataSource = p3.GetData(lstdata);
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
