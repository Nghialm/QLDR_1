using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Domain.Report;
using QuanLyDoanRa.Commons;
using Vns.QuanLyDoanRa.Service.Interface;
using System.IO;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.QuanLyDoanRa;

namespace QuanLyDoanRa.Reports
{
    public partial class frmTabInB02 : DevExpress.XtraEditors.XtraForm
    {
        
        private DateTime mTuNgay=DateTime.Now;
        private DateTime mDenNgay = DateTime.Now;
        private string mTitleTime = "";
        private Guid mLoaiDoanRaId;

        public frmTabInB02()
        {
            InitializeComponent();
        }

        public frmTabInB02(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId, string p_TitleTime)
        {
            InitializeComponent();
            mTuNgay = p_TuNgay;
            mDenNgay = p_DenNgay;
            mLoaiDoanRaId = p_LoaiDoanRaId;
            mTitleTime = p_TitleTime;
            LoaData();
        }

        private void LoaData()
        {
            B02DR_P1 Phan1;
            B02DR_P2 Phan2;
            B02DR_P3 Phan3;

            IReportService ReportService = (IReportService)ObjectFactory.GetObject("ReportService");
            IList<VnsReportTongHop> lstBaoCaoTongHop = ReportService.BaoCaoTongHopDoanRa(mTuNgay, mDenNgay, mLoaiDoanRaId, 2, ReportType.RP02);

            List<VnsReportTongHop> lstrp = new List<VnsReportTongHop>(lstBaoCaoTongHop);
            lstrp.Sort(VnsReportTongHop.CompareSoQuyetToan);

            Phan1 = new B02DR_P1();
            Phan1.p_DenNgay = mDenNgay;
            printControl1.PrintingSystem = Phan1.PrintingSystem;
            Phan1.strTitle = mTitleTime;
            Phan1.LoadData(lstrp);
            Phan1.CreateDocument();

            Phan2 = new B02DR_P2();
            printControl2.PrintingSystem = Phan2.PrintingSystem;
            Phan2.strTitle = mTitleTime;
            Phan2.LoadData(lstrp);
            Phan2.CreateDocument();

            Phan3 = new B02DR_P3();
            printControl3.PrintingSystem = Phan3.PrintingSystem;
            Phan3.strTitle = mTitleTime;
            Phan3.LoadData(lstrp);
            Phan3.CreateDocument();


        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                if (xtraTabControl1.SelectedTabPage == tabTamUng)
                {
                    printBarManager1.PrintControl = printControl1;
                }
                else if (xtraTabControl1.SelectedTabPage == tabHoanUng)
                {
                    printBarManager1.PrintControl = printControl2;
                }
                else if (xtraTabControl1.SelectedTabPage == tabQuyetToan)
                {
                    printBarManager1.PrintControl = printControl3;
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }



        #region BackUp

        //private void frmTabInB02_Load(object sender, EventArgs e)
        //{
        //    IVnsGiaoDichService VnsGiaoDichService = (IVnsGiaoDichService)ObjectFactory.GetObject("VnsGiaoDichService");
        //    IList<ViewQuyetToan> lstGiaoDich = VnsGiaoDichService.listHoanThuQuyetToan(dTuNgay, dDenNgay, LoaiDoanRaId);
        //    xtraTabControl1.SelectedTabPage = tabTamUng;

        //    Phan1 = (B02DR_P1)ObjectFactory.GetObject("B02DR_P1");
        //    Phan1.dTuNgay = dTuNgay;
        //    Phan1.dDenNgay = dDenNgay;
        //    Phan1.strTitle = strTitle;
        //    Phan1.LoaiDoanRaId = LoaiDoanRaId;
        //    this.printControl1.PrintingSystem = Phan1.PrintingSystem;
        //    this.Phan1.LoadData(lstGiaoDich);
        //    this.Phan1.CreateDocument();

        //    Phan2 = (B02DR_P2)ObjectFactory.GetObject("B02DR_P2");
        //    Phan2.dTuNgay = dTuNgay;
        //    Phan2.dDenNgay = dDenNgay;
        //    Phan2.LoaiDoanRaId = LoaiDoanRaId;
        //    Phan2.strTitle = strTitle;
        //    this.printControl2.PrintingSystem = Phan2.PrintingSystem;
        //    this.Phan2.LoadData(lstGiaoDich);
        //    this.Phan2.CreateDocument();

        //    Phan3 = (B02DR_P3)ObjectFactory.GetObject("B02DR_P3");
        //    Phan3.dTuNgay = dTuNgay;
        //    Phan3.dDenNgay = dDenNgay;
        //    Phan3.strTitle = strTitle;
        //    Phan3.LoaiDoanRaId = LoaiDoanRaId;
        //    this.printControl3.PrintingSystem = Phan3.PrintingSystem;
        //    this.Phan3.LoadData(lstGiaoDich);
        //    this.Phan3.CreateDocument();
        //    List<VnsDoanRaParameter> lstparameter = new List<VnsDoanRaParameter>();
        //    string displayCol = "TenDoan;CongTacTaiNuoc;TruongDoan;SoNguoiDi;ThoiGianDuyetDuToan;SoTBQuyetToan;TienQuyetToan;NguoiThanhToan;TongUSD;TongSoVND;TienMatUSD;TyGiaTienMat;TienMatVND;ChuyenKhoanUSD;TyGiaChuyenKhoan;ChuyenKhoanVND;ThuHoanTUQTTienMatUSD;ThuHoanTUQTTienMatTyGia;ThuHoanTUQTTienMatVND;ThuHoanTUQTTienMatUSDThangTruoc;ThuHoanTUQTTyGiaThangTruoc;ThuHoanTUQTTienMatVNDThangTruoc;";
        //    displayCol += "CKChiQTUSD;TyGiaCKChiQT;CKChiQTVND;TienMatChiQTUSD;TienMatTyGiaChiQT;TienMatChiQTVND;TongSoUSDSoQT;TongSoVNDSoQT;TienMatUSDSoQT;TienMatTyGiaSoQT;";
        //    displayCol += "TienMatVNDSoQT;ChuyenKhoanUSDSoQT;ChuyenKhoanTyGiaSoQT;ChuyenKhoanVNDSoQT;TM6801;TM6802;TM6803;TM6804;TM6805;TM6806;TM6849;PhaiThuUSD;TyGiaPhaiThu;PhaiThuVND;PhaiTraUSD";
        //    //ucExports1.ExportToExcelWithInterop(Directory.GetCurrentDirectory() + "\\TongHopDoanRa.xls", Directory.GetCurrentDirectory() + "\\TempReport\\TongHopDoanRa.xls", dataSet, "QT", lstparameter, 12, 2, displayCol, true);
        //    ucExports1.CleanParameter();
        //    string values = "QUYẾT TOÁN ĐOÀN RA " + strTitle;
        //    VnsDoanRaParameter pr = new VnsDoanRaParameter(values, "Table1", 3, 7);
        //    ucExports1.AddParameter(pr);
        //    ucExports1.TemplateFileName = "TongHopDoanRa.xls";
        //    ucExports1.ExportData = dataSet;
        //    ucExports1.TemplateSheet = "QT";
        //    ucExports1.DisplayCol = displayCol;
        //    ucExports1.StartRow = 12;
        //    ucExports1.StartCol = 2;
        //}

        //private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        //{
        //    try
        //    {
        //        if (xtraTabControl1.SelectedTabPage == tabTamUng)
        //        {
        //            printBarManager1.PrintControl = printControl1;
        //        }
        //        else if (xtraTabControl1.SelectedTabPage == tabHoanUng)
        //        {
        //            printBarManager1.PrintControl = printControl2;
        //        }
        //        else if (xtraTabControl1.SelectedTabPage == tabQuyetToan)
        //        {
        //            printBarManager1.PrintControl = printControl3;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Commons.Commons.Message_Error(ex);
        //    }
        //}

        #endregion
    }
}