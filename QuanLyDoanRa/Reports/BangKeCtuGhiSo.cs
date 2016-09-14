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
    public partial class BangKeCtuGhiSo : DevExpress.XtraReports.UI.XtraReport
    {
        public IRP_BC04DRService RP_BC04DRService;
        public IVnsDoanCongTacService VnsDoanCongTacService;
        DataTable dt;
        public BangKeCtuGhiSo()
        {
            InitializeComponent();
        }

        public BangKeCtuGhiSo(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo, string p_TrangThaiCt, string TenCt, string p_Time, int GiaTri) 
        {
            InitializeComponent();

            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiKyBangBieu;
            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;
            lblTenNguoiKiBangBieu.Text = General.TenNguoiKyBangBieu;
            lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;
            lblSignDate.Text = General.GenSignDate_EndMonth(p_DenNgay);

            lblTenBc.Text = "BẢNG KÊ CHỨNG TỪ GHI SỔ " + TenCt.ToUpper();
            lblTime.Text = p_Time;
            RP_BC04DRService = (IRP_BC04DRService)ObjectFactory.GetObject("RP_BC04DRService");
            VnsDoanCongTacService = (IVnsDoanCongTacService)ObjectFactory.GetObject("VnsDoanCongTacService");
            List<RP_SoDuTaiKhoan> lstSoDuTk;
            if (GiaTri == 2)
            {
                lstSoDuTk = RP_BC04DRService.GetSoDuTaiKhoan(p_TuNgay, p_DenNgay, p_TkCo, p_TkNo, p_TrangThaiCt);
            }
            else
            {
                lstSoDuTk = RP_BC04DRService.GetBangKeQuyetToan(p_TuNgay, p_DenNgay, p_TkCo, p_TkNo, p_TrangThaiCt);
            }

            List<RP_BangKeCtGhiSo> lstBangKe = new List<RP_BangKeCtGhiSo>();
            RP_BangKeCtGhiSo objBangke;
            foreach (RP_SoDuTaiKhoan objSoDu in lstSoDuTk)
            {
                objBangke = new RP_BangKeCtGhiSo();
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
                objBangke = objBangke.GetData(objSoDu,GiaTri);
                lstBangKe.Add(objBangke);                
            }

            dt = Commons.Commons.ToDataTable<RP_BangKeCtGhiSo>(lstBangKe);
        }

        private void BangKeCtuGhiSo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
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
