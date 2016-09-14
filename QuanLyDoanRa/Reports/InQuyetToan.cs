using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Vns.QuanLyDoanRa.Domain;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain.Report;

namespace QuanLyDoanRa.Reports
{
    public partial class InQuyetToan : DevExpress.XtraReports.UI.XtraReport
    {
        IList<VnsInQtTu> lstQT = new List<VnsInQtTu>(); 
        
        public InQuyetToan()
        {
            InitializeComponent();
        }

        public InQuyetToan(IList<VnsInQtTu> lst,VnsDoanCongTac objDoanRa,string Flag)
        {
            LoadData(lst, objDoanRa, Flag);
            return;
            InitializeComponent();
            string GiaTri = "";
            string TienVNDong = "";
            string TienUSD;
            long dSoTien = 0;
            string strPrInQuyetToan = "";

            if (Flag == "QT")
            {
                GiaTri = "Giá trị quyết toán :";
                strPrInQuyetToan = "Quyết toán tiền (USD)";
                lblNguoiPheDuyet.Text = General.NguoiPheDuyetQuyetToan;
                lblChucDanhPheDuyet.Text = General.ChucDanhDuyetQuyetToan;
            }
            else
            {
                GiaTri = "Giá trị dự toán :";
                strPrInQuyetToan = "Dự toán tiền (USD)";
                lblNguoiPheDuyet.Text = General.NguoiPheDuyetDuToan;
                lblChucDanhPheDuyet.Text = General.ChucDanhDuyetDuToan;
            }

            lstQT = lst;            
            foreach (VnsInQtTu obj in lstQT)
            {
                dSoTien += (long)obj.SoTien;                
            }

            TienUSD = String.Format("{0:0,0}", dSoTien) + " USD (";
            TienVNDong = Commons.Commons.DocTienBangChu(dSoTien, "");
            TienVNDong = TienVNDong.ToLower() + " đô la Mỹ).";
            rtTrachNhiem.Text = string.Format("         {0} chịu trách nhiệm thanh toán theo đúng quy định hiện hành của Đảng và Nhà nước.", objDoanRa.Ten);
            rtTenDonVi.Text =string.Format("- {0},",  objDoanRa.Ten);
            rtTienVietBangChu.Text = string.Format("         {0} {1} {2}", GiaTri, TienUSD, TienVNDong);
            lblTieuDeInQuyetToan.Text = strPrInQuyetToan;
        }
        public void LoadData(IList<VnsInQtTu> lst, VnsDoanCongTac objDoanRa, string Flag)
        {
            InitializeComponent();
            string GiaTri = "";

            string TienVND = "";
            string TienVNDChu = "";

            string TienUSD;
            string TienUSDChu;

            long dSoTien = 0;
            long dSoTienVND = 0;
            string strPrInQuyetToan = "";
            string strPrInQuyetToanVND = "";

            if (Flag == "QT")
            {
                GiaTri = "Giá trị quyết toán :";
                strPrInQuyetToan = "Quyết toán tiền (USD)";
                strPrInQuyetToanVND = "Quyết toán tiền (VNĐ)";
                lblNguoiPheDuyet.Text = General.NguoiPheDuyetQuyetToan;
                lblChucDanhPheDuyet.Text = General.ChucDanhDuyetQuyetToan;
            }
            else
            {
                GiaTri = "Giá trị dự toán :";
                strPrInQuyetToan = "Dự toán tiền (USD)";
                strPrInQuyetToanVND = "Dự toán tiền (VNĐ)";
                lblNguoiPheDuyet.Text = General.NguoiPheDuyetDuToan;
                lblChucDanhPheDuyet.Text = General.ChucDanhDuyetDuToan;
            }

            lstQT = lst;
            foreach (VnsInQtTu obj in lstQT)
            {
                dSoTien += (long)obj.SoTien;
                dSoTienVND += (long)obj.SoTienVND;
            }

            TienUSD = String.Format("{0:0,0}", dSoTien) + " USD (";
            TienUSDChu = Commons.Commons.DocTienBangChu(dSoTien, "");
            TienUSDChu = TienUSDChu.ToLower() + " đô la Mỹ).";

            TienVND = String.Format("{0:0,0}", dSoTienVND) + " đồng (";
            TienVNDChu = Commons.Commons.DocTienBangChu(dSoTienVND, "");
            TienVNDChu = TienVNDChu.ToLower() + " đồng).";

            rtTrachNhiem.Text = string.Format("         {0} chịu trách nhiệm thanh toán theo đúng quy định hiện hành của Đảng và Nhà nước.", objDoanRa.Ten);
            rtTenDonVi.Text = string.Format("- {0},", objDoanRa.Ten);

            string strUSD = string.Format("         {0} {1} {2}", "- Tiền USD: ", TienUSD, TienUSDChu);
            string strVND = string.Format("         {0} {1} {2}", "- Tiền Việt Nam đồng: ", TienVND, TienVNDChu);

            rtTienVietBangChu.Text = GiaTri;
            rtVanPhong.Text = strUSD + " \n" + strVND;
            lblTieuDeInQuyetToan.Text = strPrInQuyetToan;
            lblTieuDeInQuyetToanVND.Text = strPrInQuyetToanVND;
        }
        private void InQuyetToan_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {            
            this.DataSource = Commons.Commons.ToDataTable<VnsInQtTu>(lstQT);            
        }
    }
}
