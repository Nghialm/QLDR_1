using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.QuanLyDoanRa;

namespace QuanLyDoanRa
{
    public partial class FrmEditDuToan : Form
    {
        #region Property
        private IVnsDuToanDoanService _VnsDuToanDoanService;
        public IVnsDuToanDoanService VnsDuToanDoanService
        {
            get { return _VnsDuToanDoanService; }
            set { _VnsDuToanDoanService = value; }
        }

        private IVnsDmQuocGiaService _VnsDmQuocGiaService;
        public IVnsDmQuocGiaService VnsDmQuocGiaService
        {
            get { return _VnsDmQuocGiaService; }
            set { _VnsDmQuocGiaService = value; }
        }

        private IVnsDmMucTieuMucService _VnsDmMucTieuMucService;
        public IVnsDmMucTieuMucService VnsDmMucTieuMucService
        {
            get { return _VnsDmMucTieuMucService; }
            set { _VnsDmMucTieuMucService = value; }
        }

        public IVnsDoanCongTacService VnsDoanCongTacService;
        public IVnsDmHeThongService VnsDmHeThongService;
        #endregion
        public VnsDoanCongTac DoanRa;
        private IList<VnsDuToanDoan> lstDuToanDoanRa = new List<VnsDuToanDoan>();

        public int LanDuToan = 0;
     
        public FrmEditDuToan()
        {
            InitializeComponent();
        }

        private void FrmEditDuToan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            this.cboTenMuc.DataSource = this.VnsDmMucTieuMucService.GetAll();
            if (DoanRa != null)
            {
                txtTenDoan.Text = DoanRa.Ten;
                txtLoaiDoanRa.Text = DoanRa.TenLoaiDoanRa;
                txtTruongDoan.Text = DoanRa.TruongDoan;
                txtNgayDi.Text = DoanRa.NgayDi.ToString("dd/MM/yyyy");
                txtNgayVe.Text = DoanRa.NgayVe.ToString("dd/MM/yyyy");
                txtSoTbDuToan.Text = DoanRa.SoThongBaoDuToan;
                txtMoTa.Text = DoanRa.MoTa;
                if (DoanRa.DanhSachDuToanDoan != null && DoanRa.DanhSachDuToanDoan.Count > 0)
                {
                    txtNgayLapDuToan.EditValue = DoanRa.DanhSachDuToanDoan[0].NgayDuToan;
                }

                txtNgayDuToan.EditValue = DoanRa.NgayDuyetDuToan;
                //lstDuToanDoanRa = DoanRa.DanhSachDuToanDoan;                
                lstDuToanDoanRa = VnsDuToanDoanService.GetByDoanCongTac(DoanRa.Id, LanDuToan);
                grvDuToan.DataSource = lstDuToanDoanRa;
                grvDuToan.RefreshDataSource();
            }
        }

        private void btnLapDuToan_Click(object sender, EventArgs e)
        {
            lstDuToanDoanRa = new List<VnsDuToanDoan>();
            lstDuToanDoanRa = VnsDuToanDoanService.TinhDuToan444(DoanRa.NgayDi, DoanRa);            
            grvDuToan.DataSource = lstDuToanDoanRa;
            grvDuToan.RefreshDataSource();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDuToan_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.F4:
            //        ThemDong();
            //        break;
            //    case Keys.F8:
            //        XoaDong();
            //        break;
            //}
        }

        private void XoaDong()
        {
            if (gvDuToan.FocusedRowHandle < 0) return;
            if (gvDuToan.FocusedRowHandle >= 0)
            {
                VnsDuToanDoan tmpdel = (VnsDuToanDoan)gvDuToan.GetRow(gvDuToan.FocusedRowHandle);              
            }
            gvDuToan.DeleteSelectedRows();
            gvDuToan.RefreshData();
        }

        private void ThemDong()
        {
            if (lstDuToanDoanRa == null) lstDuToanDoanRa = new List<VnsDuToanDoan>();

            lstDuToanDoanRa.Add(new VnsDuToanDoan());

            gvDuToan.RefreshData();
            Commons.GridHelper.SetFocusAfterAddRow(gvDuToan);
        }

        private void gvDuToan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gvDuToan.FocusedRowHandle < 0) return;
            VnsDuToanDoan tmp = (VnsDuToanDoan)gvDuToan.GetRow(gvDuToan.FocusedRowHandle);
            tmp.CongTacId = DoanRa.Id;
            switch (e.Column.Name)
            {
                case "colMaMuc":
                    VnsDmMucTieuMuc tmpMuc = (VnsDmMucTieuMuc)cboTenMuc.GetDataSourceRowByKeyValue(tmp.MucId);
                    tmp.TenKhoanChi = tmpMuc.TenMuc;
                    break;
                case "colTien":
                    if (tmp.SoTienDuToan != 0)
                    {
                        tmp.SoTienDuToanVND = 0;
                        tmp.NgoaiTeId = Globals.NgoaiTeId;
                    }
                    break;
                case "colTienVND":
                    if (tmp.SoTienDuToanVND != 0)
                    {
                        tmp.SoTienDuToan = 0;
                        tmp.NgoaiTeId = Globals.NoiTeId;
                    }
                    break;
            }
        }

        private String GetMaMucTieuMucById(Guid id)
        {
            IList<VnsDmMucTieuMuc> lstMtm = VnsDmMucTieuMucService.GetAll();
            foreach (VnsDmMucTieuMuc obj in lstMtm)
            {
                if (obj.Id == id)
                    return obj.MaMuc;
            }
            return "";
        }

        private void grvDuToan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            if (Commons.GridHelper.CheckAddNewRow(gvDuToan, true))
            {
                ThemDong();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) return;

            if (LanDuToan == 0)
            {
                DoanRa.NgayDuyetDuToan = (DateTime)txtNgayDuToan.EditValue;
                DoanRa.SoThongBaoDuToan = txtSoTbDuToan.Text;
                //DoanRa.DanhSachDuToanDoan = null;
                VnsDoanCongTacService.Merge(DoanRa);
            }

            VnsDuToanDoanService.DeleteByDoanCongTac(DoanRa.Id, LanDuToan);

            foreach (VnsDuToanDoan obj in lstDuToanDoanRa)
            {
                // if (obj.Id == new Guid())
                obj.NgayDuToan = (DateTime)txtNgayLapDuToan.EditValue; //DateTime.Now;
                obj.LanDuToan = LanDuToan;
                obj.CongTacId = DoanRa.Id;

                if (obj.SoTienDuToan == 0) obj.NgoaiTeId = Globals.NoiTeId;
                if (obj.SoTienDuToanVND == 0) obj.NgoaiTeId = Globals.NgoaiTeId;
                
                VnsDuToanDoanService.Save(obj);
            }

            MessageBox.Show("Đã lưu dự toán thành công");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Escape):
                    btnHuy_Click(null, null);
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FrmEditDuToan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
                {
                    btnLuu_Click(btnLuu, null);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    ThemDong();
                }
                else if (e.KeyCode == Keys.F8)
                {
                    if (Commons.Commons.Message_Confirm("Bạn có chắc chắn xóa bản ghi?", false))
                    {
                        XoaDong();
                    }
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void gvDuToan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {   
                return;
            }
            VnsDuToanDoan tmp = (VnsDuToanDoan)gvDuToan.GetRow(gvDuToan.FocusedRowHandle);
            //txtNgayLapDuToan.EditValue = tmp.NgayDuToan;
        }

        private void txtNgayLapDuToan_Validating(object sender, CancelEventArgs e)
        {
            if (txtNgayLapDuToan.EditValue == null)
            {
                dxErrorProvider1.SetError(txtNgayLapDuToan, "Yêu cầu nhập số liệu!");
                e.Cancel = true;
            }
            else
            {
                dxErrorProvider1.SetError(txtNgayLapDuToan, "");
            }
        }

        private void txtNgayDuToan_Validating(object sender, CancelEventArgs e)
        {
            if (txtNgayDuToan.EditValue == null)
            {
                dxErrorProvider1.SetError(txtNgayDuToan, "Yêu cầu nhập số liệu!");
                e.Cancel = true;
            }
            else
            {
                dxErrorProvider1.SetError(txtNgayDuToan, "");
            }
        }
    }
}
