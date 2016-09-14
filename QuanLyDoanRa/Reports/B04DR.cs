using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Domain.Report;

namespace QuanLyDoanRa.Reports
{
    public partial class B04DR : DevExpress.XtraReports.UI.XtraReport
    {
        public IReportService ReportService;

        private DateTime m_TuNgay;
        private DateTime m_DenNgay;
        private Guid m_LoaiDoanRaId;
        private string m_TenLoaiDoanRa;
        string m_time;
        public B04DR()
        {
            InitializeComponent();
        }

        public B04DR(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId, string p_TenLoaiDoanRa, string Time)
        {
            InitializeComponent();
            m_TuNgay = p_TuNgay;
            m_DenNgay = p_DenNgay;
            m_LoaiDoanRaId = p_LoaiDoanRaId;
            m_TenLoaiDoanRa = p_TenLoaiDoanRa;
            m_time = Time;
        }

        private void B04DR_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (m_TenLoaiDoanRa =="")
                lblTenBc.Text = "BẢNG TỔNG HỢP KINH PHÍ ĐOÀN RA";
            else
                lblTenBc.Text = "BẢNG TỔNG HỢP KINH PHÍ ĐOÀN RA "+ m_TenLoaiDoanRa.ToUpper();

            lblTime.Text = m_time;
            ReportService = (IReportService)ObjectFactory.GetObject("ReportService");
            lblChucDanhNguoiKiBangBieu.Text = General.ChucDanhNguoiKyBangBieu;
            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;
            lblTenNguoiKiBangBieu.Text = General.TenNguoiKyBangBieu;
            lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;
            lblSignDate.Text = General.GenSignDate(m_DenNgay);
            this.DataSource = ReportService.ReportBc04Dr(m_TuNgay, m_DenNgay, m_LoaiDoanRaId);
        }

        private void xrTableCell37_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

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
