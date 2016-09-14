using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

using System.Collections.Generic;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Domain.Report;

namespace QuanLyDoanRa.Reports
{
    public partial class BangKeTamUng : DevExpress.XtraReports.UI.XtraReport
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
        public DateTime dTuNgay = DateTime.Now;
        public DateTime dDenNgay = DateTime.Now;
        public string strTitle;
        public BangKeTamUng()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            DataSource = null;
            
            IList<ViewTamUngDoanRa> lstTamUng = new List<ViewTamUngDoanRa>();
                
            //if (Thang > 0 && Nam>0)
            //{
            //    IList<DateTime> lstNgay = Commons.Commons.GetTuNgayDenNgayTrongThang(Thang,Nam);
            //    dTuNgay = lstNgay[0];
            //    dDenNgay = lstNgay[1];              
            //}
            lstTamUng = this.VnsGiaoDichService.ListViewTamUng(dTuNgay, dDenNgay);
            lblTenBaoCao.Text = "BẢNG KÊ TẠM ỨNG CÁC ĐOÀN RA " + strTitle.ToUpper();
            lblChucDanhNguoiKiBangBieu.Text = General.ChucDanhNguoiKyBangBieu;
            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;
            lblTenNguoiKiBangBieu.Text = General.TenNguoiKyBangBieu;
            lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;
            lblSignDate.Text = General.GenSignDate_EndMonth(dDenNgay);

            DataSource = lstTamUng;
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
