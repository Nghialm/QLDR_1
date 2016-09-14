using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Service.Interface;
namespace QuanLyDoanRa.Reports
{
    public partial class BangKeCtuGhiSo1 : DevExpress.XtraReports.UI.XtraReport
    {
        public IRP_BC04DRService RP_BC04DRService;
        public IVnsDoanCongTacService VnsDoanCongTacService;
        DataTable dt;
        public BangKeCtuGhiSo1()
        { 
            InitializeComponent();
        }

        public BangKeCtuGhiSo1(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo, string p_TrangThaiCt, string TenCt, string p_Time)
        {
            InitializeComponent();

            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiKyBangBieu;
            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;
            lblTenNguoiKiBangBieu.Text = General.TenNguoiKyBangBieu;
            lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;

            lblTenBc.Text = "BẢNG KÊ CHỨNG TỪ GHI SỔ " + TenCt.ToUpper();
            lblTime.Text = p_Time;
            RP_BC04DRService = (IRP_BC04DRService)ObjectFactory.GetObject("RP_BC04DRService");
            VnsDoanCongTacService = (IVnsDoanCongTacService)ObjectFactory.GetObject("VnsDoanCongTacService");

            List<RP_SoDuTaiKhoan> lstSoDuTk = RP_BC04DRService.GetSoDuTaiKhoan(p_TuNgay, p_DenNgay, p_TkCo, p_TkNo, p_TrangThaiCt);
            foreach (RP_SoDuTaiKhoan objSoDu in lstSoDuTk)
            {
                if (objSoDu.DoanRaId != new Guid())
                {
                    VnsDoanCongTac objDct = new VnsDoanCongTac();
                    objDct = VnsDoanCongTacService.GetById(objSoDu.DoanRaId);
                    if(objDct!= null)
                    {
                        objSoDu.TenDoanRa = objDct.Ten;
                        objSoDu.TenLoaiDoanRa = objDct.TenLoaiDoanRa;
                    }
                }
            }

            dt = Commons.Commons.ToDataTable<RP_SoDuTaiKhoan>(lstSoDuTk);
        }

        private void BangKeCtuGhiSo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.DataSource = dt;
        }
        
    }
}
