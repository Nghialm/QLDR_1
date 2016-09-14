using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Web.UI.WebControls;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.Parameters;
using Vns.Erp.Core;
using DevExpress.XtraReports.UI;

namespace QuanLyDoanRa.Reports
{
    public partial class frmReportByThangNam : DevExpress.XtraEditors.XtraForm
    {
        public frmReportByThangNam()
        {
            InitializeComponent();            
        }
        DateTime dTuNgay = DateTime.Now;
        DateTime dDenNgay = DateTime.Now;
        string TitleTime;

        #region "Properties"
        #endregion

        #region "Variables"
       
        #endregion

        #region "Functions"
        private void LoadLayOut(string reportName)
        {
            dateTimeInput1.SetValue();
            dTuNgay = dateTimeInput1.StartDate;
            dDenNgay = dateTimeInput1.EndDate;
            TitleTime = dateTimeInput1.TitleTime;
            switch (reportName)
            {
                case "01DN":
                    Reports.B01DR B01DR = (B01DR)ObjectFactory.GetObject("B01DR");
                   
                    B01DR.dTuNgay = dTuNgay;
                   // parameter.Value = "BẢNG KÊ TẠM ỨNG CÁC ĐOÀN RA THÁNG" +thang.ToString()+"-"+nam.ToString();
                    B01DR.dDenNgay = dDenNgay;
                    B01DR.strTitle = TitleTime;
                  //  BangKeTamUng.CreateDocument();
                    B01DR.LoadData();
                    //B01DR.CreateDocument();
                    B01DR.ShowPreviewDialog();
                    break;
               case "05DN":
                    Reports.B05DR B05DR = new B05DR(dTuNgay, dDenNgay, TitleTime);
                    B05DR.ShowPreviewDialog();
                    break;
                case "06DN1":
                    Reports.B06DR B06DR1 = new B06DR(dTuNgay, dDenNgay,1, TitleTime);
                    B06DR1.ShowPreviewDialog();
                    break;
                case "06DN2":
                    Reports.B07DR B07DR2 = new B07DR(dTuNgay, dDenNgay, 2, TitleTime);
                    B07DR2.ShowPreviewDialog();
                    break;
                case "barRPBangKeTU":
                    Reports.BangKeTamUng BangKeTamUng = (BangKeTamUng)ObjectFactory.GetObject("BangKeTamUng");//new BangKeTamUng();                   
                    BangKeTamUng.dTuNgay = dTuNgay;
                    BangKeTamUng.dDenNgay = dDenNgay;
                    BangKeTamUng.strTitle = TitleTime;                    
                    BangKeTamUng.LoadData();
                    BangKeTamUng.ShowPreviewDialog();
                  break;
                case "barRpBangKeQT":
                    Reports.BangKeQuyetToan BangKeQuyetToan = new BangKeQuyetToan(dTuNgay,dDenNgay, TitleTime);
                    //BangKeQuyetToan.CreateDocument();
                    BangKeQuyetToan.ShowPreviewDialog();
                    break;
                case "barRpCtGhiSoQT":
                    //Reports.BangKeCtGhi BangKeCtGhiGT = new BangKeCtGhi();
                    //BangKeCtGhiGT.CreateDocument();
                    //BangKeCtGhiGT.ShowPreviewDialog();
                    break;
                case "barCtGhiSoHoanTU":
                    //Reports.BangKeCtGhi BangKeCtGhiTU = new BangKeCtGhi();
                    //BangKeCtGhiTU.CreateDocument();
                    //BangKeCtGhiTU.ShowPreviewDialog();
                    break;

                case "PB_QT":
                    Reports.PhuBieuChiQt pb = new PhuBieuChiQt(dTuNgay, dDenNgay, TitleTime);
                    pb.CreateDocument();
                    pb.ShowPreviewDialog();
                    break;
                case "PB_TH_QT":
                    Reports.PhuLuc_TongHopQuyetToanDoanRa pbTh = new PhuLuc_TongHopQuyetToanDoanRa(dTuNgay, dDenNgay, TitleTime);
                    pbTh.CreateDocument();
                    pbTh.ShowPreviewDialog();
                    break;
                    
            }
        }

        #endregion

        #region "Events"
        private void frmReportByThangNam_Load(object sender, EventArgs e)
        {
            this.Text = this.Tag.ToString();
            switch (this.AccessibleDescription)
            {
                case "PB_QT":
                    dateTimeInput1.ChonDkNam = 3;
                    break;
                case "PB_TH_QT":
                    dateTimeInput1.ChonDkNam = 2;
                    break;
                default:
                    dateTimeInput1.ChonDkNam = 1;
                    break;
            }
            //dateTimeInput1.IsThang = true;
            dateTimeInput1.SetDieuKienMacDinh();
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btnNhan_Click(object sender, EventArgs e)
        {
            LoadLayOut(this.AccessibleDescription);
        }


    }
}