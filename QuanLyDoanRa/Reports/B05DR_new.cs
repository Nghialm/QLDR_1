﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Domain.Report;

namespace QuanLyDoanRa.Reports
{
    public partial class B05DR_new : DevExpress.XtraReports.UI.XtraReport
    {
        public IReportService ReportService;
        DateTime m_TuNgay;
        DateTime m_DenNgay;
        string smTime;
        public B05DR_new()
        {
            InitializeComponent();
        }

        public B05DR_new(DateTime p_tungay, DateTime p_Denngay, string sTime)
        {
            InitializeComponent();
            m_TuNgay = p_tungay;
            m_DenNgay = p_Denngay;
            smTime = sTime;
        }

        private void B05DR_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {   
            lblTen.Text = "BẢNG TỔNG HỢP CÔNG NỢ ĐOÀN RA";
            lblTime.Text = smTime;
            ReportService = (IReportService)ObjectFactory.GetObject("ReportService");

            lblChucDanhNguoiKiBangBieu.Text = General.ChucDanhNguoiKyBangBieu;
            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;
            lblTenNguoiKiBangBieu.Text = General.TenNguoiKyBangBieu;
            lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;

            this.DataSource = Commons.Commons.ToDataTable<RP_BC05DR>(ReportService.ReportBc05Dr( m_TuNgay,  m_DenNgay, new Guid()));
        }

    }
}
