using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vns.QuanLyDoanRa.Dao.NHibernate;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Service;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.Erp.Core;

namespace QuanLyDoanRa.Reports
{
    public partial class FrmReportBangKeCt : DevExpress.XtraEditors.XtraForm
    {
        public IVnsDmHeThongService VnsDmHeThongService;
        public FrmReportBangKeCt()
        {            
            InitializeComponent();           
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            if (cboLoaiBangKe.EditValue == null)
            {
                Commons.Commons.Message_Warning("Bạn chưa chọn loại chứng từ ghi sổ");
                return;
            }
            VnsDmHeThong objHeThong = new VnsDmHeThong();
            objHeThong = (VnsDmHeThong)cboLoaiBangKe.Properties.GetRowByKeyValue(cboLoaiBangKe.EditValue);

            string[] lstTaiKhoan = objHeThong.Ma.Split('-');
            switch (objHeThong.GiaTri)
            {
                case 2:
                    Reports.BangKeCtuGhiSo rptctgs = new Reports.BangKeCtuGhiSo(dateTimeInput.StartDate, dateTimeInput.EndDate, lstTaiKhoan[0], lstTaiKhoan[1], objHeThong.TrangThaiPhieu, cboLoaiBangKe.Text, dateTimeInput.TitleTime, objHeThong.GiaTri);
                    rptctgs.ShowPreviewDialog();
                    break;
                case 3:
                    Reports.BangKeQuyetToanDetail rptqtdetail = new BangKeQuyetToanDetail(dateTimeInput.StartDate, dateTimeInput.EndDate, lstTaiKhoan[0], lstTaiKhoan[1], objHeThong.TrangThaiPhieu, cboLoaiBangKe.Text, dateTimeInput.TitleTime, objHeThong.GiaTri);
                    rptqtdetail.ShowPreviewDialog();
                    break;
                default:
                    Reports.BangKeCtuGhiSo_TC_QT rptgs1 = new Reports.BangKeCtuGhiSo_TC_QT(dateTimeInput.StartDate, dateTimeInput.EndDate, lstTaiKhoan[0], lstTaiKhoan[1], objHeThong.TrangThaiPhieu, cboLoaiBangKe.Text, dateTimeInput.TitleTime, objHeThong.GiaTri);
                    rptgs1.ShowPreviewDialog();
                    break;
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmReportBangKeCt_Load(object sender, EventArgs e)
        {
            VnsDmHeThongService = (VnsDmHeThongService)ObjectFactory.GetObject("VnsDmHeThongService");
            cboLoaiBangKe.Properties.DataSource = VnsDmHeThongService.GetByDoiTuong("BANGKE_CT_GHISO");
            cboLoaiBangKe.Properties.ValueMember = "GiaTri";
            cboLoaiBangKe.Properties.DisplayMember = "Ten";

            dateTimeInput.IsThang = true;
            dateTimeInput.SetDefault();
        }

    }
}