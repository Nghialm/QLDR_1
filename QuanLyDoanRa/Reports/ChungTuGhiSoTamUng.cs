using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.QuanLyDoanRa.Domain;
using System.Collections.Generic;
using Vns.QuanLyDoanRa;
using Vns.QuanLyDoanRa.Service.Interface.Report;
//using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Domain.Report;

namespace QuanLyDoanRa.Reports
{
    public partial class ChungTuGhiSoTamUng : DevExpress.XtraReports.UI.XtraReport
    {
        public IRP_BC04DRService RP_BC04DRService;
        private IVnsGiaoDichService _VnsGiaoDichService;
        public IVnsGiaoDichService VnsGiaoDichService
        {
            get { return _VnsGiaoDichService; }
            set { _VnsGiaoDichService = value; }
        }

        private IVnsLoaiDoanRaService _VnsLoaiDoanRaService;
        public IVnsLoaiDoanRaService VnsLoaiDoanRaService
        {
            get { return _VnsLoaiDoanRaService; }
            set { _VnsLoaiDoanRaService = value; }
        }
        decimal dTongTienUSD = 0;
        decimal dTongTienVND = 0;
        decimal dTienMatUSD = 0;
        decimal dTienMatVnd = 0;
        decimal dTienCKUSD = 0;
        decimal dTienCKVnd = 0;

        decimal dTongTien_BanDang_USD = 0;
        decimal dTongTien_BanDang_VND = 0;
        decimal dTienMat_BanDang_USD = 0;
        decimal dTienMat_BanDang_Vnd = 0;
        decimal dTienCK_BanDang_USD = 0;
        decimal dTienCK_BanDang_Vnd = 0;

        decimal dTongTien_165_USD = 0;
        decimal dTongTien_165_VND = 0;
        decimal dTienMat_165_USD = 0;
        decimal dTienMat_165_Vnd = 0;
        decimal dTienCK_165_USD = 0;
        decimal dTienCK_165_Vnd = 0;
        string strNgayThang = "";

        public ChungTuGhiSoTamUng()
        {
            InitializeComponent();
        }
        public void LoadData(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo, string p_TrangThaiCt, string TenCt, string p_Time, int giaTri)
        {
            RP_BC04DRService = (IRP_BC04DRService)Vns.Erp.Core.ObjectFactory.GetObject("RP_BC04DRService");
            strNgayThang = "Ngày " + p_DenNgay.Day.ToString() + " tháng " + p_DenNgay.Month.ToString() + " năm " + p_DenNgay.Year.ToString();
            IList<VnsGiaoDich> lstGiaoDich = new List<VnsGiaoDich>();
            List<RP_SoDuTaiKhoan> lstSoDuTk = RP_BC04DRService.GetSoDuTaiKhoan(p_TuNgay, p_DenNgay, p_TkCo, p_TkNo, p_TrangThaiCt);

            
            foreach (RP_SoDuTaiKhoan objGD in lstSoDuTk)
            {
                VnsLoaiDoanRa objLDR = this.VnsLoaiDoanRaService.GetById(objGD.LoaiDoanRaId);
                dTongTienUSD += objGD.PsTangUSD;
                dTongTienVND += objGD.PsTangVND;
                switch (giaTri)
                {
                    case 1: //Nhan tien btc
                        #region Nhan tien btc
                        //txtMaTKCo.Text = Globals.TkTamUng;
                        txtTienMatTKNo.Text = Globals.TkTienMat;
                        txtCKNo.Text = Globals.TkTienChuyenKhoan;
                        // phi chuyen tien
                        //461-1121(có - nợ tiền mặt)
                        //461 -1122tiền gửi ngân hàng
                        //461 - 661 - phí chuyển tiền
                        // phi chuyen tien
                        if (objGD.MaTkNo.StartsWith(Globals.TkTienMat))
                        {
                            dTienMatUSD += objGD.PsTangUSD;
                            dTienMatVnd += objGD.PsTangVND;
                        }
                        if (objGD.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan))
                        {
                            dTienCKUSD += objGD.PsTangUSD;
                            dTienCKVnd += objGD.PsTangVND;
                        }
                        if (objLDR != null && objLDR.MaLoaiDoanRa == "1") // cac ban Dang
                        {
                            dTongTien_BanDang_USD += objGD.PsTangUSD;
                            dTongTien_BanDang_VND += objGD.PsTangVND;
                            if (objGD.MaTkNo.StartsWith(Globals.TkTienMat))
                            {
                                dTienMat_BanDang_USD += objGD.PsTangUSD;
                                dTienMat_BanDang_Vnd += objGD.PsTangVND;
                            }
                            if (objGD.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan))
                            {
                                dTienCK_BanDang_USD += objGD.PsTangUSD;
                                dTienCK_BanDang_Vnd += objGD.PsTangVND;
                            }
                        }
                        else if (objLDR != null && objLDR.MaLoaiDoanRa == "2") // Den An 165
                        {
                            dTongTien_165_USD += objGD.PsTangUSD;
                            dTongTien_165_VND += objGD.PsTangVND;
                            if (objGD.MaTkNo.StartsWith(Globals.TkTienMat))
                            {
                                dTienMat_165_USD += objGD.PsTangUSD;
                                dTienMat_165_Vnd += objGD.PsTangVND;
                            }
                            if (objGD.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan))
                            {
                                dTienCK_165_USD += objGD.PsTangUSD;
                                dTienCK_165_Vnd += objGD.PsTangVND;
                            }
                        }
                        #endregion
                        break;
                    case 2: //Tam ung
                        #region Tam ung
                        txtMaTKNo.Text = Globals.TkTamUng;
                        txtTienMatMaTKCo.Text = Globals.TkTienMat;
                        txtCKMaTKCO.Text = Globals.TkTienChuyenKhoan;
                        if (objGD.MaTkCo.StartsWith(Globals.TkTienMat))
                        {
                            dTienMatUSD += objGD.PsTangUSD;
                            dTienMatVnd += objGD.PsTangVND;

                        }
                        if (objGD.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan))
                        {
                            dTienCKUSD += objGD.PsTangUSD;
                            dTienCKVnd += objGD.PsTangVND;
                        }
                        if (objLDR != null && objLDR.MaLoaiDoanRa == "1") // cac ban Dang
                        {
                            dTongTien_BanDang_USD += objGD.PsTangUSD;
                            dTongTien_BanDang_VND += objGD.PsTangVND;
                            if (objGD.MaTkCo.StartsWith(Globals.TkTienMat))
                            {
                                dTienMat_BanDang_USD += objGD.PsTangUSD;
                                dTienMat_BanDang_Vnd += objGD.PsTangVND;
                            }
                            if (objGD.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan))
                            {
                                dTienCK_BanDang_USD += objGD.PsTangUSD;
                                dTienCK_BanDang_Vnd += objGD.PsTangVND;
                            }
                        }
                        else if (objLDR != null && objLDR.MaLoaiDoanRa == "2") // Den An 165
                        {
                            dTongTien_165_USD += objGD.PsTangUSD;
                            dTongTien_165_VND += objGD.PsTangVND;
                            if (objGD.MaTkCo.StartsWith(Globals.TkTienMat))
                            {
                                dTienMat_165_USD += objGD.PsTangUSD;
                                dTienMat_165_Vnd += objGD.PsTangVND;
                            }
                            if (objGD.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan))
                            {
                                dTienCK_165_USD += objGD.PsTangUSD;
                                dTienCK_165_Vnd += objGD.PsTangVND;
                            }
                        }
                        #endregion
                        break;
                    case 3: // Quyet toan
                        #region Quyet toan
                        txtMaTKNo.Text = Globals.TkThanhToanNguoiBan;
                        txtMaTKCo.Text = Globals.TkTamUng;
                        txtTienMatTKNo.Text = Globals.TkThanhToanTienMat;
                        txtCKNo.Text = Globals.TkThanhToanChuyenKhoan;
                        if (objGD.MaTkNo.StartsWith(Globals.TkThanhToanTienMat))
                        {
                            dTienMatUSD += objGD.PsTangUSD;
                            dTienMatVnd += objGD.PsTangVND;
                        }
                        if (objGD.MaTkNo.StartsWith(Globals.TkThanhToanChuyenKhoan))
                        {
                            dTienCKUSD += objGD.PsTangUSD;
                            dTienCKVnd += objGD.PsTangVND;
                        }
                        if (objLDR != null && objLDR.MaLoaiDoanRa == "1") // cac ban Dang
                        {
                            dTongTien_BanDang_USD += objGD.PsTangUSD;
                            dTongTien_BanDang_VND += objGD.PsTangVND;
                            if (objGD.MaTkNo.StartsWith(Globals.TkThanhToanTienMat))
                            {
                                dTienMat_BanDang_USD += objGD.PsTangUSD;
                                dTienMat_BanDang_Vnd += objGD.PsTangVND;
                            }
                            if (objGD.MaTkNo.StartsWith(Globals.TkThanhToanChuyenKhoan))
                            {
                                dTienCK_BanDang_USD += objGD.PsTangUSD;
                                dTienCK_BanDang_Vnd += objGD.PsTangVND;
                            }
                        }
                        else if (objLDR != null && objLDR.MaLoaiDoanRa == "2") // Den An 165
                        {
                            dTongTien_165_USD += objGD.PsTangUSD;
                            dTongTien_165_VND += objGD.PsTangVND;
                            if (objGD.MaTkNo.StartsWith(Globals.TkThanhToanTienMat))
                            {
                                dTienMat_165_USD += objGD.PsTangUSD;
                                dTienMat_165_Vnd += objGD.PsTangVND;
                            }
                            if (objGD.MaTkNo.StartsWith(Globals.TkThanhToanChuyenKhoan))
                            {
                                dTienCK_165_USD += objGD.PsTangUSD;
                                dTienCK_165_Vnd += objGD.PsTangVND;
                            }
                        }
                        #endregion
                        break;
                    case 4: //Chi quyet toan
                        #region Chi quyet toan
                        txtMaTKNo.Text = Globals.TkThanhToanNguoiBan;
                        txtTienMatMaTKCo.Text = Globals.TkTienMat;
                        txtCKMaTKCO.Text = Globals.TkTienChuyenKhoan;
                        if (objGD.MaTkCo.StartsWith(Globals.TkTienMat))
                        {
                            dTienMatUSD += objGD.PsTangUSD;
                            dTienMatVnd += objGD.PsTangVND;
                        }
                        if (objGD.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan))
                        {
                            dTienCKUSD += objGD.PsTangUSD;
                            dTienCKVnd += objGD.PsTangVND;
                        }
                        if (objLDR != null && objLDR.MaLoaiDoanRa == "1") // cac ban Dang
                        {
                            dTongTien_BanDang_USD += objGD.PsTangUSD;
                            dTongTien_BanDang_VND += objGD.PsTangVND;
                            if (objGD.MaTkCo.StartsWith(Globals.TkTienMat))
                            {
                                dTienMat_BanDang_USD += objGD.PsTangUSD;
                                dTienMat_BanDang_Vnd += objGD.PsTangVND;
                            }
                            if (objGD.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan))
                            {
                                dTienCK_BanDang_USD += objGD.PsTangUSD;
                                dTienCK_BanDang_Vnd += objGD.PsTangVND;
                            }
                        }
                        else if (objLDR != null && objLDR.MaLoaiDoanRa == "2") // Den An 165
                        {
                            dTongTien_165_USD += objGD.PsTangUSD;
                            dTongTien_165_VND += objGD.PsTangVND;
                            if (objGD.MaTkCo.StartsWith(Globals.TkTienMat))
                            {
                                dTienMat_165_USD += objGD.PsTangUSD;
                                dTienMat_165_Vnd += objGD.PsTangVND;
                            }
                            if (objGD.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan))
                            {
                                dTienCK_165_USD += objGD.PsTangUSD;
                                dTienCK_165_Vnd += objGD.PsTangVND;
                            }
                        }
                        #endregion
                        break;
                    case 5: //Thu quyet toan
                        #region Thu quyet toan
                        txtMaTKCo.Text = Globals.TkTamUng;
                        txtTienMatMaTKCo.Text = Globals.TkTienMat;
                        txtCKMaTKCO.Text = Globals.TkTienChuyenKhoan;
                        if (objGD.MaTkNo.StartsWith(Globals.TkTienMat))
                        {
                            dTienMatUSD += objGD.PsTangUSD;
                            dTienMatVnd += objGD.PsTangVND;
                        }
                        if (objGD.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan))
                        {
                            dTienCKUSD += objGD.PsTangUSD;
                            dTienCKVnd += objGD.PsTangVND;
                        }
                        if (objLDR != null && objLDR.MaLoaiDoanRa == "1") // cac ban Dang
                        {
                            dTongTien_BanDang_USD += objGD.PsTangUSD;
                            dTongTien_BanDang_VND += objGD.PsTangVND;
                            if (objGD.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan))
                            {
                                dTienMat_BanDang_USD += objGD.PsTangUSD;
                                dTienMat_BanDang_Vnd += objGD.PsTangVND;
                            }
                            if (objGD.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan))
                            {
                                dTienCK_BanDang_USD += objGD.PsTangUSD;
                                dTienCK_BanDang_Vnd += objGD.PsTangVND;
                            }
                        }
                        else if (objLDR != null && objLDR.MaLoaiDoanRa == "2") // Den An 165
                        {
                            dTongTien_165_USD += objGD.PsTangUSD;
                            dTongTien_165_VND += objGD.PsTangVND;
                            if (objGD.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan))
                            {
                                dTienMat_165_USD += objGD.PsTangUSD;
                                dTienMat_165_Vnd += objGD.PsTangVND;
                            }
                            if (objGD.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan))
                            {
                                dTienCK_165_USD += objGD.PsTangUSD;
                                dTienCK_165_Vnd += objGD.PsTangVND;
                            }
                        }
                        #endregion
                        break;

                }
                if (p_TkNo == Globals.TkTamUng && p_TkCo == Globals.TkNghiepVuTienMatvaChuyenKhoan && p_TrangThaiCt == "0")// Tam Ung
                {

                }
                if (p_TkNo == Globals.TkNghiepVuTienMatvaChuyenKhoan && p_TkCo == Globals.TkTamUng && p_TrangThaiCt == "-1")// quyet toan
                {

                }
                if (p_TkNo == Globals.TkTamUng && p_TkCo == Globals.TkNghiepVuTienMatvaChuyenKhoan && p_TrangThaiCt == "1;2")// Chi Quyet Toan
                {

                }
                if (p_TkNo == Globals.TkNghiepVuTienMatvaChuyenKhoan && p_TkCo == Globals.TkTamUng && p_TrangThaiCt == "-1")// Thu quyet toan
                {

                }
                // Nhan tien tu bo tai chinh
                if (p_TkNo == Globals.TkNghieVuNhanTienBtc && p_TkCo == Globals.TkThuNganSach && p_TrangThaiCt == "-1")// Thu quyet toan
                {

                }
            }
            lblTongCong.Text = String.Format("{0:n0}", dTongTienUSD) + " USD";// TĐ " +
            lblTongCongTongVND.Text = String.Format("{0:n0}", dTongTienVND) + " Đ";
            lblTongCongTienMat.Text = String.Format("{0:n0}", dTienMatUSD) + " USD";// TĐ " + 
            lblTongCongTienMatVND.Text = String.Format("{0:n0}", dTienMatVnd) + " Đ";
            lblTongCongCK.Text = String.Format("{0:n0}", dTienCKUSD) + " USD";// TĐ " + 
            lblTongCongChuyenKhoanVND.Text = String.Format("{0:n0}", dTienCKVnd) + " Đ";

            lblTongCongBanDang.Text = String.Format("{0:n0}", dTongTien_BanDang_USD) + " USD";// TĐ " + 
            lblTongCongDangVND.Text = String.Format("{0:n0}", dTongTien_BanDang_VND) + " Đ";
            lblTienMatBanDang.Text = String.Format("{0:n0}", dTienMat_BanDang_USD) + " USD";// TĐ " + 
            lblTongCongDangTienMatVND.Text = String.Format("{0:n0}", dTienMat_BanDang_Vnd) + " Đ";
            lblCKBanDang.Text = String.Format("{0:n0}", dTienCK_BanDang_USD) + " USD";// TĐ " +
            lblTongCongDangChuyenKhoanVND.Text = String.Format("{0:n0}", dTienCK_BanDang_Vnd) + " Đ";

            lblTongCong165.Text = String.Format("{0:n0}", dTongTien_165_USD) + " USD";// TĐ " + 
            lblTongCong165VND.Text = String.Format("{0:n0}", dTongTien_165_VND) + " Đ";
            lblTienMat165.Text = String.Format("{0:n0}", dTienMat_165_USD) + " USD";// TĐ " +
            lblTongCong165TienMatVND.Text = String.Format("{0:n0}", dTienMat_165_Vnd) + " Đ";
            lblCK165.Text = String.Format("{0:n0}", dTienCK_165_USD) + " USD";// TĐ " +
            lblTongCong165ChuyenKhoanVND.Text = String.Format("{0:n0}", dTienCK_165_Vnd) + " Đ";

            lblTongTienMatVND.Text = String.Format("{0:n0}", (dTienMatVnd));//dTienMatUSD +
            lblTongCKVND.Text = String.Format("{0:n0}", (dTienCKVnd)); //dTienCKUSD+
            //lblTongCong.Text = String.Format("{0:n0}", (dTongTienVND)); //dTongTienUSD + 
            lblTongCongTong.Text = String.Format("{0:n0}", (dTienMatVnd + dTienCKVnd)); //dTienMatUSD + dTienCKUSD +
        }

        private void ChungTuGhiSoTamUng_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblNgayIn.Text = strNgayThang;
        }
    }
}
