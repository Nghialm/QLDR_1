using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.Erp.Core;

namespace QuanLyDoanRa.Reports
{
    public partial class frmSoCTTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public frmSoCTTaiKhoan()
        {
            InitializeComponent();
            dateTimeInput1.IsThang = true;
        }

        #region "Properties"
        #endregion

        #region "Variables"
        #endregion

        #region "Functions"
        private void LoadLayOut(string reportName)
        {
            DateTime TuNgay = dateTimeInput1.StartDate;
            DateTime DenNgay = dateTimeInput1.EndDate;
            string Titletime = dateTimeInput1.TitleTime;
            switch (reportName)
            {
                case "CTTK":
                    Reports.SoChiTietTK SoChiTietTK = new SoChiTietTK(TuNgay,DenNgay,Titletime, cboTk.EditValue.ToString(),"");
                    SoChiTietTK.CreateDocument();
                    SoChiTietTK.ShowPreviewDialog();
                    break;                
            }
        }

        private void BindDataToCbo()
        {
            IVnsNghiepVuService VnsNghiepVuService = (IVnsNghiepVuService)ObjectFactory.GetObject("VnsNghiepVuService");

            IList<VnsNghiepVu> lstNghiepVu = VnsNghiepVuService.GetAll();

            for (int i = lstNghiepVu.Count -1; i >=0; i--)
            {
                if (!(lstNghiepVu[i].MaNghiepVu == Vns.QuanLyDoanRa.Globals.TkTienMat ||
                    lstNghiepVu[i].MaNghiepVu == Vns.QuanLyDoanRa.Globals.TkTienChuyenKhoan))
                {
                    lstNghiepVu.RemoveAt(i);
                }
            }

            cboTkCo.Properties.DataSource = lstNghiepVu;
            cboTkCo.Properties.ValueMember = "MaNghiepVu";
            cboTkCo.Properties.DisplayMember = "MaNghiepVu";

            cboTk.Properties.DataSource = lstNghiepVu;
            cboTk.Properties.ValueMember = "MaNghiepVu";
            cboTk.Properties.DisplayMember = "MaNghiepVu";

        }
        
        #endregion

        #region "Events"

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (cboTk.EditValue == null)
            {
                Commons.Commons.Message_Information("Bạn chưa chọn mã tài khoản");
                cboTk.Focus();
                return;
            }

            LoadLayOut(this.AccessibleDescription);
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSoCTTaiKhoan_Load(object sender, EventArgs e)
        {
            this.Text = this.Tag.ToString();
            BindDataToCbo();
        }

        #endregion

       
    }
}