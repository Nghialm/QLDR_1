using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.QuanLyDoanRa.Domain;
using Vns.Erp.Core;
using QuanLyDoanRa.Commons;
using Vns.QuanLyDoanRa.Domain.Report;
using System.IO;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.QuanLyDoanRa;

namespace QuanLyDoanRa.Reports
{
    public partial class frmReportByLoaiDR : DevExpress.XtraEditors.XtraForm
    {
        public frmReportByLoaiDR()
        {
            InitializeComponent();
        }
        public frmReportByLoaiDR(string rp)
        {
            InitializeComponent();
            string reportName = rp;
        }

        #region "Properties"
        public IVnsLoaiDoanRaService VnsLoaiDoanRaService;
        public IVnsGiaoDichService VnsGiaoDichService;
        public IRP_BC03DRService RP_BC03DRService;
        public IRP_BC04DRService RP_BC04DRService;
        #endregion

        #region "Variables"
        DateTime dTuNgay = DateTime.Now;
        DateTime dDenNgay = DateTime.Now;
        #endregion

        #region "Functions"
        private void LoadLayOut(string reportName)
        {
            Guid LoaiDoanRa;
            if (cboLoaiDoanRa.EditValue != null)
                LoaiDoanRa = new Guid(cboLoaiDoanRa.EditValue.ToString());
            else
                LoaiDoanRa = new Guid();

            dTuNgay = dateTimeInput1.StartDate;
            dDenNgay = dateTimeInput1.EndDate;
            switch (reportName)
            {
                case "02DN":
                    //  Export to excel using intercrop
                    // function name: 
                    //VnsExport xp = new VnsExport();


                    //if (thang > 0 && nam > 0)
                    //{
                    //    IList<DateTime> lstNgay = Commons.Commons.GetTuNgayDenNgayTrongThang(thang, nam);

                    //    dTuNgay = lstNgay[0];
                    //    dDenNgay = lstNgay[1];
                    //}

                    //IList<ViewQuyetToan> lstData = this.VnsGiaoDichService.listHoanThuQuyetToan(dTuNgay, dDenNgay, LoaiDoanRa);
                    //DataTable temp = Commons.Commons.ToDataTable<ViewQuyetToan>(lstData);
                    //DataSet ds = new DataSet("table");
                    //ds.Tables.Add(temp);
                    //List<VnsDoanRaParameter> lstparameter = new List<VnsDoanRaParameter>();
                    //string displayCol = "TenDoan;CongTacTaiNuoc;TruongDoan;SoNguoiDi;ThoiGianDuyetDuToan;SoTBQuyetToan;TienQuyetToan;NguoiThanhToan;TongUSD;TongSoVND;TienMatUSD;TyGiaTienMat;TienMatVND;ChuyenKhoanUSD;TyGiaChuyenKhoan;ChuyenKhoanVND;ThuHoanTUQTTienMatUSD;ThuHoanTUQTTienMatTyGia;ThuHoanTUQTTienMatVND;ThuHoanTUQTTienMatUSDThangTruoc;ThuHoanTUQTTyGiaThangTruoc;ThuHoanTUQTTienMatVNDThangTruoc;";
                    //displayCol += "CKChiQTUSD;TyGiaCKChiQT;CKChiQTVND;TienMatChiQTUSD;TienMatTyGiaChiQT;TienMatChiQTVND;TongSoUSDSoQT;TongSoVNDSoQT;TienMatUSDSoQT;TienMatTyGiaSoQT;";
                    //displayCol += "TienMatVNDSoQT;ChuyenKhoanUSDSoQT;ChuyenKhoanTyGiaSoQT;ChuyenKhoanVNDSoQT;TM6801;TM6802;TM6803;TM6804;TM6805;TM6806;TM6849;PhaiThuUSD;TyGiaPhaiThu;PhaiThuVND;PhaiTraUSD";
                    ////ucExports1.ExportToExcelWithInterop(Directory.GetCurrentDirectory() + "\\TongHopDoanRa.xls", Directory.GetCurrentDirectory() + "\\TempReport\\TongHopDoanRa.xls", dataSet, "QT", lstparameter, 12, 2, displayCol, true);
                    //ucExports1.CleanParameter();
                    //string values = dateTimeInput1.TitleTime;//"QUYẾT TOÁN ĐOÀN RA THÁNG " + thang.ToString() + " NĂM " + nam.ToString();
                    //VnsDoanRaParameter pr = new VnsDoanRaParameter(values, "Table1", 3, 7);
                    //ucExports1.AddParameter(pr);
                    //ucExports1.TemplateFileName = "TongHopDoanRa.xls";
                    //ucExports1.ExportData = ds;
                    //ucExports1.TemplateSheet = "QT";
                    //ucExports1.DisplayCol = displayCol;
                    //ucExports1.StartRow = 12;
                    //ucExports1.StartCol = 2;
                    //ucExports1.Filenamedefault = "QuyetToanDoanRa.xls";
                    Reports.frmTabInB02 frm = new frmTabInB02(dTuNgay, dDenNgay, LoaiDoanRa, dateTimeInput1.TitleTime);
                    frm.ShowDialog();
                    break;
                case "03DN":
                    Reports.B03DR B03DR = new B03DR(dTuNgay, dDenNgay, LoaiDoanRa, "", dateTimeInput1.TitleTime);
                    B03DR.ShowPreviewDialog();
                    break;
                case "03DR_LDR":
                    Reports.B03DR B03DR1 = new B03DR(dTuNgay, dDenNgay, LoaiDoanRa, cboLoaiDoanRa.Text, dateTimeInput1.TitleTime);
                    B03DR1.ShowPreviewDialog();
                    break;
                case "04DN":
                    Reports.B04DR B04DR = new B04DR(dTuNgay, dDenNgay, LoaiDoanRa, "", dateTimeInput1.TitleTime);
                    B04DR.ShowPreviewDialog();
                    break;
                case "04DR_LDR":
                    Reports.B04DR_Detail B04DR1 = new B04DR_Detail(dTuNgay, dDenNgay, LoaiDoanRa, cboLoaiDoanRa.Text, dateTimeInput1.TitleTime, chkCheckZero.Checked);
                    B04DR1.ShowPreviewDialog();
                    break;
                case "PB_TH_KP":
                    Reports.PhuBieuTongHopKinhPhiDoanRa pbTHkp = new PhuBieuTongHopKinhPhiDoanRa(dTuNgay, dDenNgay, LoaiDoanRa, cboLoaiDoanRa.Text, dateTimeInput1.TitleTime);
                    pbTHkp.ShowPreviewDialog();
                    break;
                case "PB_TH_KP_LDR":
                    Reports.PhuBieuTongHopKinhPhiDoanRa pbthkpdr = new PhuBieuTongHopKinhPhiDoanRa(dTuNgay, dDenNgay, LoaiDoanRa, cboLoaiDoanRa.Text, dateTimeInput1.TitleTime);
                    pbthkpdr.ShowPreviewDialog();
                    break;
            }
        }

        private void BindDataToCbo()
        {
            List<VnsLoaiDoanRa> lstLoaiDoanRa = new List<VnsLoaiDoanRa>();
            lstLoaiDoanRa.Add(new VnsLoaiDoanRa());
            lstLoaiDoanRa.AddRange(VnsLoaiDoanRaService.GetAll());
            cboLoaiDoanRa.Properties.DataSource = lstLoaiDoanRa;
            cboLoaiDoanRa.Properties.ValueMember = "Id";
            cboLoaiDoanRa.Properties.DisplayMember = "TenLoaiDoanRa";
        }

        #endregion

        #region "Events"

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoadLayOut(this.AccessibleDescription);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReportByLoaiDR_Load(object sender, EventArgs e)
        {

            string reportName = this.AccessibleDescription;

            //hô hô
            switch (reportName)
            {
                case "PB_TH_KP":
                    dateTimeInput1.ChonDkNam = 2;
                    break;
                case "04DN":
                    dateTimeInput1.ChonDkNam = 1;
                    break;
                case "04DR_LDR":
                    dateTimeInput1.ChonDkNam = 0;
                    break;
                default:
                    dateTimeInput1.ChonDkNam = 1;
                    break;
            }
            //if (reportName == "04DN" || reportName == "04DR_LDR")
            //{
            //    dateTimeInput1.IsThang = false;

            //}
            //else
            //    dateTimeInput1.IsThang = true;

            dateTimeInput1.SetDieuKienMacDinh();

            chkCheckZero.Visible = false;

            if (reportName == "04DN" || reportName == "03DN")
            {
                cboLoaiDoanRa.Properties.ReadOnly = true;
            }
            else
                if (reportName == "04DR_LDR")
                {
                    cboLoaiDoanRa.Properties.ReadOnly = true;
                    chkCheckZero.Visible = true;
                }
                else
                {
                    cboLoaiDoanRa.Properties.ReadOnly = false;
                }

            BindDataToCbo();
            this.Text = this.Tag.ToString();
        }

        private void ExportDataToExcel(Controls.ucExports ucExports, int p_StartRow, int p_StartCol, string p_ColDisplay, DataTable dt, List<VnsDoanRaParameter> lstparameter, string template)
        {
            DataSet ds = new DataSet("table");
            ds.Tables.Add(dt);
            ucExports.CleanParameter();

            foreach (VnsDoanRaParameter objPr in lstparameter)
            {
                ucExports.AddParameter(objPr);
            }
            ucExports.TemplateFileName = template;
            ucExports.ExportData = ds;
            ucExports.TemplateSheet = "QT";
            ucExports.DisplayCol = p_ColDisplay;
            ucExports.StartRow = p_StartRow;
            ucExports.StartCol = p_StartCol;
        }

        private void LoadDataExportExcel(string ReportName)
        {
            Guid LoaiDoanRa;
            if (cboLoaiDoanRa.EditValue != null)
                LoaiDoanRa = new Guid(cboLoaiDoanRa.EditValue.ToString());
            else
                LoaiDoanRa = new Guid();
            DateTime dTuNgay = dateTimeInput1.StartDate;
            DateTime dDenNgay = dateTimeInput1.EndDate;

            if (ReportName == "02DN")
            {

                IReportService ReportService = (IReportService)ObjectFactory.GetObject("ReportService");
                IList<VnsReportTongHop> lstBaoCaoTongHop = ReportService.BaoCaoTongHopDoanRa(dTuNgay, dDenNgay, LoaiDoanRa, 2, ReportType.RP02);

                List<VnsDoanRaParameter> lstparameter = new List<VnsDoanRaParameter>();
                string displayCol = "TenDoanRa;NuocCongTac;TruongDoan;SoNguoiDi;ThangDuyetDt;SoTbQt;TienQt;NguoiQt;TongTamUngUSD;TongTamUngVND;TU_TM_USD;TU_TM_TG;TU_TM_VND;TU_CK_USD;TU_CK_TG;TU_CK_VND;TH_TONG_USD;TH_TONG_TG;TH_TONG_VND;";//ThuHoanTUQTTienMatUSDThangTruoc;ThuHoanTUQTTyGiaThangTruoc;ThuHoanTUQTTienMatVNDThangTruoc;
                displayCol += "Chi_QT_CK_USD;Chi_QT_CK_TG;Chi_QT_CK_VND;Chi_QT_TM_USD;Chi_QT_TM_TG;Chi_QT_TM_VND;So_QT_USD_Tong;So_QT_VND_Tong;So_QT_TM_USD;So_QT_TM_TG;";
                displayCol += "So_QT_TM_VND;So_QT_CK_USD;So_QT_CK_TG;So_QT_CK_VND;M_6801;M_6802;M_6803;M_6804;M_6805;M_6806;M_6849;CN_PhaiThu_USD;CN_PhaiThu_TG;CN_PhaiThu_VND;CN_PhaiTra_USD";
                //ucExports1.ExportToExcelWithInterop(Directory.GetCurrentDirectory() + "\\TongHopDoanRa.xls", Directory.GetCurrentDirectory() + "\\TempReport\\TongHopDoanRa.xls", dataSet, "QT", lstparameter, 12, 2, displayCol, true);
                ucExports1.CleanParameter();
                string values = "QUYẾT TOÁN ĐOÀN RA ";// mTitleTime;
                VnsDoanRaParameter pr = new VnsDoanRaParameter(values, "Table1", 3, 7);
                ucExports1.AddParameter(pr);
                ucExports1.TemplateFileName = "TongHopDoanRa.xls";
                DataTable table = Commons.Commons.ToDataTable<VnsReportTongHop>(lstBaoCaoTongHop);
                DataSet dataSet = new DataSet("Table1");
                dataSet.Tables.Add(table);
                ucExports1.ExportData = dataSet;
                ucExports1.TemplateSheet = "QT";
                ucExports1.DisplayCol = displayCol;
                ucExports1.StartRow = 12;
                ucExports1.StartCol = 2;
                //IList<ViewQuyetToan> lstData = this.VnsGiaoDichService.listHoanThuQuyetToan(dTuNgay, dDenNgay, LoaiDoanRa);

                //List<VnsDoanRaParameter> lstparameter = new List<VnsDoanRaParameter>();
                //string displayCol = "TenDoan;CongTacTaiNuoc;TruongDoan;SoNguoiDi;ThoiGianDuyetDuToan;SoTBQuyetToan;TienQuyetToan;NguoiThanhToan;TongUSD;TongSoVND;TienMatUSD;TyGiaTienMat;TienMatVND;ChuyenKhoanUSD;TyGiaChuyenKhoan;ChuyenKhoanVND;ThuHoanTUQTTienMatUSD;ThuHoanTUQTTienMatTyGia;ThuHoanTUQTTienMatVND;ThuHoanTUQTTienMatUSDThangTruoc;ThuHoanTUQTTyGiaThangTruoc;ThuHoanTUQTTienMatVNDThangTruoc;";
                //displayCol += "CKChiQTUSD;TyGiaCKChiQT;CKChiQTVND;TienMatChiQTUSD;TienMatTyGiaChiQT;TienMatChiQTVND;TongSoUSDSoQT;TongSoVNDSoQT;TienMatUSDSoQT;TienMatTyGiaSoQT;";
                //displayCol += "TienMatVNDSoQT;ChuyenKhoanUSDSoQT;ChuyenKhoanTyGiaSoQT;ChuyenKhoanVNDSoQT;TM6801;TM6802;TM6803;TM6804;TM6805;TM6806;TM6849;PhaiThuUSD;TyGiaPhaiThu;PhaiThuVND;PhaiTraUSD";
                ////ucExports1.ExportToExcelWithInterop(Directory.GetCurrentDirectory() + "\\TongHopDoanRa.xls", Directory.GetCurrentDirectory() + "\\TempReport\\TongHopDoanRa.xls", dataSet, "QT", lstparameter, 12, 2, displayCol, true);
                //ucExports1.CleanParameter();
                //string values = "QUYẾT TOÁN ĐOÀN RA THÁNG " + thang.ToString() + " NĂM " + nam.ToString();
                //VnsDoanRaParameter pr = new VnsDoanRaParameter(values, "Table1", 3, 7);
                //ucExports1.AddParameter(pr);
                //ucExports1.TemplateFileName = "TongHopDoanRa.xls";
                //ucExports1.ExportData = ds;
                //ucExports1.TemplateSheet = "QT";
                //ucExports1.DisplayCol = displayCol;
                //ucExports1.StartRow = 12;
                //ucExports1.StartCol = 2;
            }
            //if (ReportName == "03DN")
            //{
            //    string strTenLoaiDoanRa = cboLoaiDoanRa.Text;
            //    string pTenBaoCao = "";
            //    DateTime dt = new DateTime(nam, thang, 1);
            //    if (strTenLoaiDoanRa == "")
            //        pTenBaoCao = "TỔNG HỢP CÁC ĐOÀN RA CHƯA ĐƯỢC QUYẾT TOÁN THÁNG " + (dt.AddMonths(-1).Month).ToString() + " CHUYỂN SANG THÁNG " + dt.Month.ToString() + " NĂM " + nam.ToString();
            //    else
            //        pTenBaoCao = "TỔNG HỢP CÁC ĐOÀN RA CHƯA ĐƯỢC QUYẾT TOÁN (" + strTenLoaiDoanRa.ToUpper() + ") THÁNG " + (dt.AddMonths(-1).Month).ToString() + " CHUYỂN SANG THÁNG " + thang.ToString() + " NĂM " + nam.ToString();
            //    RP_BC03DRService = (IRP_BC03DRService)ObjectFactory.GetObject("RP_BC03DRService");
            //    DataTable temp03BR = Commons.Commons.ToDataTable<BC03DR>(RP_BC03DRService.GetData_BC03DR(string.Empty, dDenNgay, dDenNgay, LoaiDoanRa));
            //    DataSet ds03dr = new DataSet("table");
            //    ds03dr.Tables.Add(temp03BR);
            //    List<VnsDoanRaParameter> lstparameter_03dr = new List<VnsDoanRaParameter>();
            //    VnsDoanRaParameter pr_03dr = new VnsDoanRaParameter(pTenBaoCao, "Table1", 3, 1);
            //    string displayCol_03dr = "TenLoaiDoanRa;TenDoan;NuocCongTac;TruongDoan;ThangDuyetDt;SoTbDt;DtDuocDuyet;NguoiTamUng;TongUSD;TongVND;TienMatUSD;TienMatTG;TienMatVND;ChuyenKhoanUSD;ChuyenKhoanTG;ChuyenKhoanVND;GroupThang;TenGroupThang;NgayDuyetDt";
            //    ucExports1.CleanParameter();
            //    ucExports1.AddParameter(pr_03dr);
            //    ucExports1.TemplateFileName = "TempB03DR.xls";
            //    ucExports1.ExportData = ds03dr;
            //    ucExports1.TemplateSheet = "CQT03DR";
            //    ucExports1.DisplayCol = displayCol_03dr;
            //    ucExports1.Filenamedefault = "TongHopCacDoanRaChua Quyet Toan.xls";
            //    ucExports1.StartRow = 12;
            //    ucExports1.StartCol = 2;
            //}
            //if (ReportName == "03DR_LDR")
            //{
            //    string strTenLoaiDoanRa_LDR = cboLoaiDoanRa.Text;
            //    string pTenBaoCao_LDR = "";
            //    DateTime dt_LDR = new DateTime(nam, thang, 1);
            //    if (strTenLoaiDoanRa_LDR == "")
            //        pTenBaoCao_LDR = "TỔNG HỢP CÁC ĐOÀN RA CHƯA ĐƯỢC QUYẾT TOÁN THÁNG " + (dt_LDR.AddMonths(-1).Month).ToString() + " CHUYỂN SANG THÁNG " + dt_LDR.Month.ToString() + " NĂM " + nam.ToString();
            //    else
            //        pTenBaoCao_LDR = "TỔNG HỢP CÁC ĐOÀN RA CHƯA ĐƯỢC QUYẾT TOÁN (" + strTenLoaiDoanRa_LDR.ToUpper() + ") THÁNG " + (dt_LDR.AddMonths(-1).Month).ToString() + " CHUYỂN SANG THÁNG " + thang.ToString() + " NĂM " + nam.ToString();
            //    RP_BC03DRService = (IRP_BC03DRService)ObjectFactory.GetObject("RP_BC03DRService");
            //    DataTable temp03BR_LDR = Commons.Commons.ToDataTable<BC03DR>(RP_BC03DRService.GetData_BC03DR(string.Empty, dTuNgay, dDenNgay, LoaiDoanRa));
            //    DataSet ds03dr_ldr = new DataSet("table");
            //    ds03dr_ldr.Tables.Add(temp03BR_LDR);
            //    List<VnsDoanRaParameter> lstparameter_03dr_ldr = new List<VnsDoanRaParameter>();
            //    VnsDoanRaParameter pr_03dr_ldr = new VnsDoanRaParameter(pTenBaoCao_LDR, "Table1", 3, 1);
            //    string displayCol_03dr_ldr = "TenLoaiDoanRa;TenDoan;NuocCongTac;TruongDoan;ThangDuyetDt;SoTbDt;DtDuocDuyet;NguoiTamUng;TongUSD;TongVND;TienMatUSD;TienMatTG;TienMatVND;ChuyenKhoanUSD;ChuyenKhoanTG;ChuyenKhoanVND;GroupThang;TenGroupThang;NgayDuyetDt";
            //    ucExports1.CleanParameter();
            //    ucExports1.AddParameter(pr_03dr_ldr);
            //    ucExports1.TemplateFileName = "TempB03DR.xls";
            //    ucExports1.Filenamedefault = "TongHopDoanRaChuaDuocQuyetToan.xls";
            //    ucExports1.ExportData = ds03dr_ldr;
            //    ucExports1.TemplateSheet = "CQT03DR";
            //    ucExports1.DisplayCol = displayCol_03dr_ldr;
            //    ucExports1.StartRow = 12;
            //    ucExports1.StartCol = 2;
            //}
            //if (ReportName == "04DN")
            //{
            //    //string strTenLoaiDoanRa_04DR = cboLoaiDoanRa.Text;
            //    //string pTenBaoCao_04DR = "";
            //    //DateTime dt_04DR = new DateTime(nam, thang, 1);

            //    //RP_BC04DRService = (IRP_BC04DRService)ObjectFactory.GetObject("RP_BC04DRService");

            //    //if (strTenLoaiDoanRa_04DR == "")
            //    //    pTenBaoCao_04DR = "BẢNG TỔNG HỢP KINH PHÍ ĐOÀN RA THÁNG " + thang.ToString() + "-" + nam.ToString();
            //    //else
            //    //    pTenBaoCao_04DR = "BẢNG TỔNG HỢP KINH PHÍ ĐOÀN RA (" + strTenLoaiDoanRa_04DR.ToUpper() + ") THÁNG " + thang.ToString() + "-" + nam.ToString();
            //    //RP_BC03DRService = (IRP_BC03DRService)ObjectFactory.GetObject("RP_BC03DRService");
            //    //DataTable tempdt_04DR = Commons.Commons.ToDataTable<RP_BC04DR>(RP_BC04DRService.GetDataRp04Dr(dTuNgay, dDenNgay, LoaiDoanRa));
            //    //DataSet ds04dr = new DataSet("table");
            //    //ds04dr.Tables.Add(tempdt_04DR);
            //    //List<VnsDoanRaParameter> lstparameter_04dr = new List<VnsDoanRaParameter>();
            //    //VnsDoanRaParameter pr_04dr = new VnsDoanRaParameter(pTenBaoCao_04DR, "Table1", 4, 1);
            //    //string displayCol_04dr = "NoiDung;TongVND;TongUSD;TienMatVND;TienMatUSD;ChuyenKhoanVND;ChuyenKhoanUSD";
            //    //ucExports1.CleanParameter();
            //    //ucExports1.AddParameter(pr_04dr);
            //    //ucExports1.TemplateFileName = "TempB04DR.xls";
            //    //ucExports1.Filenamedefault = "BangTongHopKinhPhiDoanRa.xls";
            //    //ucExports1.ExportData = ds04dr;
            //    //ucExports1.TemplateSheet = "B04DR";
            //    //ucExports1.DisplayCol = displayCol_04dr;
            //    //ucExports1.StartRow = 8;
            //    //ucExports1.StartCol = 2;
            //}
            //if (ReportName == "04DR_LDR")
            //{   
            //    string strTenLoaiDoanRa_04DR_LDR = cboLoaiDoanRa.Text;
            //    string pTenBaoCao_04DR_LDR = "";
            //    DateTime dt_04DR_LDR = new DateTime(nam, thang, 1);

            //    RP_BC04DRService = (IRP_BC04DRService)ObjectFactory.GetObject("RP_BC04DRService");

            //    if (strTenLoaiDoanRa_04DR_LDR == "")
            //        pTenBaoCao_04DR_LDR = "BẢNG TỔNG HỢP KINH PHÍ ĐOÀN RA THÁNG " + thang.ToString() + "-" + nam.ToString();
            //    else
            //        pTenBaoCao_04DR_LDR = "BẢNG TỔNG HỢP KINH PHÍ ĐOÀN RA (" + strTenLoaiDoanRa_04DR_LDR.ToUpper() + ") THÁNG " + thang.ToString() + "-" + nam.ToString();
            //    RP_BC03DRService = (IRP_BC03DRService)ObjectFactory.GetObject("RP_BC03DRService");
            //    DataTable tempdt_04DR_LDR = Commons.Commons.ToDataTable<RP_BC04DR>(RP_BC04DRService.GetDataRp04Dr(dTuNgay,dDenNgay, LoaiDoanRa));
            //    DataSet ds04dr_LDR = new DataSet("table");
            //    ds04dr_LDR.Tables.Add(tempdt_04DR_LDR);
            //    List<VnsDoanRaParameter> lstparameter_04dr_LDR = new List<VnsDoanRaParameter>();
            //    VnsDoanRaParameter pr_04dr_LDR = new VnsDoanRaParameter(pTenBaoCao_04DR_LDR, "Table1", 4, 1);
            //    string displayCol_04dr_LDR = "NoiDung;TongVND;TongUSD;TienMatVND;TienMatUSD;ChuyenKhoanVND;ChuyenKhoanUSD";
            //    ucExports1.CleanParameter();
            //    ucExports1.AddParameter(pr_04dr_LDR);
            //    ucExports1.TemplateFileName = "TempB04DR.xls";
            //    ucExports1.ExportData = ds04dr_LDR;
            //    ucExports1.TemplateSheet = "B04DR";
            //    ucExports1.Filenamedefault = "BangTongHopKinhPhiDoanRa.xls";
            //    ucExports1.DisplayCol = displayCol_04dr_LDR;
            //    ucExports1.StartRow = 8;
            //    ucExports1.StartCol = 2;    
            //}
        }

        #endregion

        private void ucExports1_BeforExport(object sender, EventArgs e)
        {
            string reportName = this.AccessibleDescription;
            LoadDataExportExcel(reportName);
        }

    }
}