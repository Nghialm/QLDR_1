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
    public partial class BangKeCtuGhiSo_TC_QT : DevExpress.XtraReports.UI.XtraReport
    {
        public IRP_BC04DRService RP_BC04DRService;
        public IVnsDoanCongTacService VnsDoanCongTacService;
        List<RP_SoDuTaiKhoan> lstSource;
        public BangKeCtuGhiSo_TC_QT()
        {
            InitializeComponent();
        }

        public BangKeCtuGhiSo_TC_QT(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo, string p_TrangThaiCt, string TenCt, string p_Time, int p_Gt)
        {
            InitializeComponent();

            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiKyBangBieu;
            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;
            lblTenNguoiKiBangBieu.Text = General.TenNguoiKyBangBieu;
            lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;
            lblChucDanhNguoiKiBangBieu.Text = General.ChucDanhNguoiKyBangBieu;
            lblSignDate.Text = General.GenSignDate_EndMonth(p_DenNgay);

            lblTenBc.Text = "BẢNG KÊ CHỨNG TỪ GHI SỔ " + TenCt.ToUpper();
            lblTime.Text = p_Time;
            RP_BC04DRService = (IRP_BC04DRService)ObjectFactory.GetObject("RP_BC04DRService");
            VnsDoanCongTacService = (IVnsDoanCongTacService)ObjectFactory.GetObject("VnsDoanCongTacService");
            IList<VnsDoanCongTac> lstDoanCt = VnsDoanCongTacService.GetAll();

            List<RP_SoDuTaiKhoan> lstSoDuTk = RP_BC04DRService.GetSoDuTaiKhoan(p_TuNgay, p_DenNgay, p_TkCo, p_TkNo, p_TrangThaiCt);

            for (int i = 0; i < this.Parameters.Count; i++)
            {
                if (this.Parameters[i].Name == "TKTienMat")
                {
                    this.Parameters[i].Value = Vns.QuanLyDoanRa.Globals.TkTienMat;
                }
                else if (this.Parameters[i].Name == "TKChuyenKhoan")
                {
                    this.Parameters[i].Value = Vns.QuanLyDoanRa.Globals.TkTienChuyenKhoan;
                }
            }

            foreach (RP_SoDuTaiKhoan objSoDu in lstSoDuTk)
            {

                if (objSoDu.DoanRaId != new Guid())
                {
                    VnsDoanCongTac objDct = Commons.Commons.GetDoanRaById(objSoDu.DoanRaId, lstDoanCt);
                    if (objDct != null)
                    {
                        objSoDu.TenDoanRa = objDct.Ten;
                        objSoDu.TenLoaiDoanRa = objDct.TenLoaiDoanRa;
                    }
                    String giatri_diengiai = "";
                    switch (p_Gt)
                    {
                        case 4:
                            giatri_diengiai = "Chi quyết toán";
                            objSoDu.MaTkDoiUng = objSoDu.MaTkCo;
                            break;
                        case 5:
                            giatri_diengiai = "Thu hoàn TƯ/QT";
                            objSoDu.MaTkDoiUng = objSoDu.MaTkNo;
                            break;
                    }

                    if (objSoDu.MaTkDoiUng == Vns.QuanLyDoanRa.Globals.TkTienMat)
                        objSoDu.TenTkDoiUng = string.Format("{0} {1}", objSoDu.TenLoaiDoanRa, "tiền mặt");
                    else if (objSoDu.MaTkDoiUng == Vns.QuanLyDoanRa.Globals.TkTienChuyenKhoan)
                        objSoDu.TenTkDoiUng = string.Format("{0} {1}", objSoDu.TenLoaiDoanRa, "tiền chuyển khoản");

                    objSoDu.DienGiai = giatri_diengiai + String.Format(" - đoàn: đc {0} - {1} - Theo TBQT {2} -TB/VPTW/nb ngày {3} đi {4} ",
                        objDct.TruongDoan, objDct.TenVietTat, objDct.SoThongBaoQuyetToan, objDct.NgayQuyetToan.ToString("dd/MM/yyyy"), objDct.NuocCongTac);
                }
            }

            lstSoDuTk.Sort(RP_SoDuTaiKhoan.CompareSoCt);
            lstSource = lstSoDuTk;
        }



        private void BangKeCtuGhiSo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            this.DataSource = lstSource;
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
