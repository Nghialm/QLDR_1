using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Vns.QuanLyDoanRa.Service.Interface;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Domain.Report;
namespace QuanLyDoanRa.Reports
{
    public partial class B01DR : DevExpress.XtraReports.UI.XtraReport
    {
        private IVnsGiaoDichService _VnsGiaoDichService;
        public IVnsGiaoDichService VnsGiaoDichService
        {
            get { return _VnsGiaoDichService; }
            set { _VnsGiaoDichService = value; }
        }

        private IVnsChungTuService _VnsChungTuService;
        public IVnsChungTuService VnsChungTuService
        {
            get { return _VnsChungTuService; }
            set { _VnsChungTuService = value; }
        }

        private IVnsDoanCongTacService _VnsDoanCongTacService;
        public IVnsDoanCongTacService VnsDoanCongTacService
        {
            get { return _VnsDoanCongTacService; }
            set { _VnsDoanCongTacService = value; }
        }

        private IVnsLoaiDoanRaService _VnsLoaiDoanRaService;
        public IVnsLoaiDoanRaService VnsLoaiDoanRaService
        {
            get { return _VnsLoaiDoanRaService; }
            set { _VnsLoaiDoanRaService = value; }
        }

        private IVnsDmQuocGiaService _VnsDmQuocGiaService;

        public IVnsDmQuocGiaService VnsDmQuocGiaService
        {
            get { return _VnsDmQuocGiaService; }
            set { _VnsDmQuocGiaService = value; }
        }
        public  DateTime dTuNgay = DateTime.Now;
        public DateTime  dDenNgay = DateTime.Now;
        public string strTitle;
        public B01DR()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            DataSource = null;
            IList<ViewTamUngDoanRa> lstTamUng = new List<ViewTamUngDoanRa>();
            lstTamUng = this.VnsGiaoDichService.ListViewTamUng(dTuNgay, dDenNgay);
            lblTenBaoCao.Text = "BẢNG TỔNG HỢP CÁC ĐOÀN RA TẠM ỨNG " + strTitle.ToUpper();// + Thang.ToString() + "-" + Nam.ToString();
            lblChucDanhNguoiKiBangBieu.Text = General.ChucDanhNguoiKyBangBieu;
            lblNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;
            lblTenNguoiKyBangBieu.Text = General.TenNguoiKyBangBieu;
            lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;
            lblSignDate.Text = General.GenSignDate(dDenNgay);

            List<ViewTamUngDoanRa> lstRp = new List<ViewTamUngDoanRa>(lstTamUng);
            lstRp.Sort(ViewTamUngDoanRa.CompareSoDuToanTangDan);
            string SoTBDuToan = "ZZZ";
            List<ViewTamUngDoanRa> lstRpFinal = new List<ViewTamUngDoanRa>();
            ViewTamUngDoanRa RpFinal = new ViewTamUngDoanRa();
            foreach (ViewTamUngDoanRa tmp in lstRp)
            {
                if (SoTBDuToan != tmp.SoTBDuToan)
                {
                    RpFinal = tmp;
                    SoTBDuToan = tmp.SoTBDuToan;
                    lstRpFinal.Add(RpFinal);
                }
                else
                {
                    tmp.DuToanDuocDuyet = 0;
                    RpFinal.ChuyenKhoanUSD += tmp.ChuyenKhoanUSD;
                    RpFinal.ChuyenKhoanVND += tmp.ChuyenKhoanVND;
                    RpFinal.TienMatUSD += tmp.TienMatUSD;
                    RpFinal.TienMatVND += tmp.TienMatVND;
                    RpFinal.TongUSD += tmp.TongUSD;
                    RpFinal.TongSoVND += tmp.TongSoVND;
                    RpFinal.TienTamUngVND += tmp.TienTamUngVND;
                }
            }

            DataSource = lstRpFinal;
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
