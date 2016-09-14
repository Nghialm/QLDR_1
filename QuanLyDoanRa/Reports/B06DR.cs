using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Service.Report;
using Vns.QuanLyDoanRa.Domain.Report;

namespace QuanLyDoanRa.Reports
{
    public partial class B06DR : DevExpress.XtraReports.UI.XtraReport
    {
        public IReportService ReportService;
        public B06DR()
        {
            InitializeComponent();
        }

        private DateTime m_TuNgay;
        private DateTime m_DenNgay;
        private int m_Flag;
        string m_Time;

        public B06DR(DateTime p_TuNgay, DateTime p_DenNgay, int p_Plag, string time)
        {
            InitializeComponent();
            m_TuNgay = p_TuNgay;
            m_DenNgay = p_DenNgay;
            m_Flag = p_Plag;
            m_Time = time;

            lblChucDanhNguoiKiBangBieu.Text = General.ChucDanhNguoiKyBangBieu;
            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;
            lblTenNguoiKiBangBieu.Text = General.TenNguoiKyBangBieu;
            lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;
            lblSignDate.Text = General.GenSignDate(m_DenNgay);
        }

        private void B06DR_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime abc = m_TuNgay;
            ReportService = (ReportService)ObjectFactory.GetObject("ReportService");
            lblTen.Text = "BẢNG THEO DÕI CÔNG NỢ ĐOÀN RA";
            lblTime.Text = m_Time;
            if (m_Flag == 1)
            {
                lblPhan.Text = "CÁC ĐOÀN PHẢI THU HOÀN TẠM ỨNG/ QUYẾT TOÁN";
                this.DataSource = ReportService.ReportBc06Dr(m_TuNgay, m_DenNgay, new Guid(),1);
            }
            else
            {
                lblPhan.Text = "II:CHI QUYẾT TOÁN";
                this.DataSource = ReportService.ReportBc06Dr(m_TuNgay, m_DenNgay, new Guid(), 2);
            }
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
