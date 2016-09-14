using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using Vns.QuanLyDoanRa.Service.Interface;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.QuanLyDoanRa.Service;

namespace QuanLyDoanRa.Reports
{
    public partial class B03DR : DevExpress.XtraReports.UI.XtraReport
    {
        public IReportService ReportService;
        private DateTime m_tuNgay;
        private DateTime m_denngay;
        private Guid m_LoaiDoanRa;
        private string m_TenLoaiDoanRa;
        private string m_Time;
        //private DataTable m_dtSource;
        public B03DR()
        {
            InitializeComponent();
        }

        public B03DR(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRa, string p_TenLoaiDoanRa, string Time)
        {
            InitializeComponent();
            m_tuNgay = p_TuNgay;
            m_denngay = p_DenNgay;
            m_LoaiDoanRa = p_LoaiDoanRa;
            m_TenLoaiDoanRa = p_TenLoaiDoanRa;
            m_Time = Time;
        }

        private void B03DR_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                DateTime dt = m_tuNgay;
                int iTHANG = m_tuNgay.Month;
                string strTemp = "";
                if (iTHANG < 12)
                {
                    strTemp = "THÁNG " + iTHANG.ToString() + " CHUYỂN SANG THÁNG " + (iTHANG + 1).ToString()+"-"+ m_tuNgay.Year.ToString();
                }
                else
                {
                    strTemp = "THÁNG " + iTHANG.ToString() + " CHUYỂN SANG THÁNG 1-" + (m_tuNgay.Year + 1).ToString();
                }
                if (m_TenLoaiDoanRa == "")
                    lblTenBc.Text = string.Format("TỔNG HỢP CÁC ĐOÀN RA TẠM ỨNG CHƯA ĐƯỢC QUYẾT TOÁN {0}", strTemp);//m_Time.ToUpper()
                else
                    lblTenBc.Text = string.Format("TỔNG HỢP CÁC ĐOÀN RA TẠM ỨNG THUỘC {0} CHƯA ĐƯỢC QUYẾT TOÁN {1} ", m_TenLoaiDoanRa.ToUpper(), strTemp);//m_Time.ToUpper());

                lblTime.Text = m_Time;
                ReportService = (IReportService)ObjectFactory.GetObject("ReportService");
                lblChucDanhNguoiKiBangBieu.Text = General.ChucDanhNguoiKyBangBieu;
                lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;
                lblTenNguoiKiBangBieu.Text = General.TenNguoiKyBangBieu;
                lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;
                lblSignDate.Text = General.GenSignDate(m_denngay);

                IList<BC03DR> lstb03 =  ReportService.ReportBc03Dr(m_tuNgay, m_denngay, m_LoaiDoanRa);
                IVnsLoaiDoanRaService VnsLoaiDoanRaService = (IVnsLoaiDoanRaService)ObjectFactory.GetObject("VnsLoaiDoanRaService");
                List<BC03DR> lstrp = new List<BC03DR>(lstb03);
                lstrp.Sort(BC03DR.CompareSoDuToan);               
                this.DataSource = lstrp;
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private bool CheckExistLoaiDr(Guid id, IList<BC03DR> lstData)
        {
            foreach (BC03DR obj in lstData)
            {
                if (id == obj.LoaiDoanRaId)
                {
                    return true;
                }
            }

            return false;
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
