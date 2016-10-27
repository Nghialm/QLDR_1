using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.QuanLyDoanRa.Service;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Domain;

namespace QuanLyDoanRa.Reports
{
    public partial class FrmChungTuGhiSo : DevExpress.XtraEditors.XtraForm
    {
        public IVnsDmHeThongService VnsDmHeThongService;

        public FrmChungTuGhiSo()
        {
            InitializeComponent();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmChungTuGhiSo_Load(object sender, EventArgs e)
        {
            VnsDmHeThongService = (VnsDmHeThongService)ObjectFactory.GetObject("VnsDmHeThongService");
            cboLoaiBangKe.Properties.DataSource = VnsDmHeThongService.GetByDoiTuong("BANGKE_CT_GHISO");
            cboLoaiBangKe.Properties.ValueMember = "GiaTri";
            cboLoaiBangKe.Properties.DisplayMember = "Ten";
            dateTimeInput1.IsThang = true;
            dateTimeInput1.SetDefault();
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
            if (objHeThong.GiaTri == 1)
            {
                Reports.ChungTuGhiSo_NhanTien_BTC frm = new ChungTuGhiSo_NhanTien_BTC(dateTimeInput1.StartDate, dateTimeInput1.EndDate, lstTaiKhoan[0], lstTaiKhoan[1], objHeThong.TrangThaiPhieu, objHeThong.GiaTri, dateTimeInput1.TitleTime); //(ChungTuGhiSo)ObjectFactory.GetObject("ChungTuGhiSo");
                frm.CreateDocument();
                frm.ShowPreviewDialog();
            }
            else if (objHeThong.GiaTri == 6)
            {
                Reports.ChungTuGhiSo_RutTienMat frm = new ChungTuGhiSo_RutTienMat(dateTimeInput1.StartDate, dateTimeInput1.EndDate, lstTaiKhoan[0], lstTaiKhoan[1], objHeThong.TrangThaiPhieu, objHeThong.GiaTri, dateTimeInput1.TitleTime); //(ChungTuGhiSo)ObjectFactory.GetObject("ChungTuGhiSo");
                frm.CreateDocument();
                frm.ShowPreviewDialog();
            }
            else
            {
                Reports.ChungTuGhiSo_V2 frm = new ChungTuGhiSo_V2(dateTimeInput1.StartDate, dateTimeInput1.EndDate, lstTaiKhoan[0], lstTaiKhoan[1], objHeThong.TrangThaiPhieu, objHeThong.GiaTri, dateTimeInput1.TitleTime); //(ChungTuGhiSo)ObjectFactory.GetObject("ChungTuGhiSo");
                frm.CreateDocument();
                frm.ShowPreviewDialog();
            }
            
        }
    }
}