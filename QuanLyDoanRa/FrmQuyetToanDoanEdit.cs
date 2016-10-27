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
using Vns.QuanLyDoanRa;

namespace QuanLyDoanRa
{
    public partial class FrmQuyetToanDoanEdit : DevExpress.XtraEditors.XtraForm
    {
        public FrmQuyetToanDoanEdit()
        {
            InitializeComponent();
        }

        #region"Variables"

        Guid m_DoanRaId;
        FormUpdate m_FormState;
        String m_LoaiChungTu;
        private Decimal m_LanQuyetToan;
        private VnsDoanCongTac objDoanCongTac;
        private IList<VnsQuyetToanDoan> lstQuyetToanDoanRa = new List<VnsQuyetToanDoan>();
        private IList<VnsDuToanDoan> lstDuToanDoanRa = new List<VnsDuToanDoan>();
        private Boolean DoLoadData = false;
        private VnsLoaiChungTu objLoaiChungTu = new VnsLoaiChungTu();
        public IVnsDmMucTieuMucService VnsDmMucTieuMucService;
        public IVnsDoanCongTacService VnsDoanCongTacService;
        public IVnsDuToanDoanService VnsDuToanDoanService;
        public IVnsLoaiChungTuService VnsLoaiChungTuService;
        public IVnsNghiepVuService VnsNghiepVuService;
        public IVnsQuyetToanDoanService VnsQuyetToanDoanService;
        private VnsNghiepVu objNghiepVu = new VnsNghiepVu();
        #endregion

        #region"Show_Form"

        public Guid Show_Form(FormUpdate p_FormState, Guid p_DoanRaId, String p_LoaiChungTu, Decimal LanQuyetToan)
        {
            try
            {
                m_FormState = p_FormState;
                m_DoanRaId = p_DoanRaId;
                m_LoaiChungTu = p_LoaiChungTu;

                if (m_FormState == FormUpdate.Update)
                {
                    cboDoanCongTac.Properties.ReadOnly = true;
                }
                else
                {
                    cboDoanCongTac.Properties.ReadOnly = false;
                }

                cboLanQuyetToan.SelectedIndex = Convert.ToInt32(LanQuyetToan);

                m_LanQuyetToan = LanQuyetToan;
                dteNgayCt.DateTime = DateTime.Now.Date;
                objLoaiChungTu = VnsLoaiChungTuService.GetByMa(p_LoaiChungTu);
                DoLoadData = true;
                InitData();

                objNghiepVu = VnsNghiepVuService.GetByKey("MaNghiepVu", Vns.QuanLyDoanRa.Globals.TkThanhToanTienMat);

                DoLoadData = false;
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }

            if (this.ShowDialog() == DialogResult.OK)
                return m_DoanRaId;
            else
                return new Guid();
        }

        #endregion

        #region"Functions"

        private void InitData()
        {
            BindDataToCbo();
            switch (m_FormState)
            {
                case FormUpdate.Insert:
                    grcQuyetToan.DataSource = lstQuyetToanDoanRa;
                    objDoanCongTac = VnsDoanCongTacService.GetById(m_DoanRaId);
                    if (objDoanCongTac != null)
                    {
                        cboDoanCongTac.EditValue = objDoanCongTac.Id;
                    }
                    break;
                case FormUpdate.Update:
                    SetObject();
                    break;
            }
        }

        private void BindDataToCbo()
        {
            cboMucId.DataSource = VnsDmMucTieuMucService.GetAll();

            if (m_FormState == FormUpdate.Update && m_LanQuyetToan != 0)
            {
                cboDoanCongTac.Properties.DataSource = VnsDoanCongTacService.GetAll();
            }
            else
            {
                cboDoanCongTac.Properties.DataSource = VnsDoanCongTacService.GetDoanRa(0);
            }

            cboDoanCongTac.Properties.ValueMember = "Id";
            cboDoanCongTac.Properties.DisplayMember = "Ten";

            cboTaiKhoan.DataSource = VnsNghiepVuService.GetDatasourceByLoaiCt(VnsNghiepVuService.GetAll(), objLoaiChungTu);

        }

        private void AddNewRow()
        {
            if (lstQuyetToanDoanRa == null) lstQuyetToanDoanRa = new List<VnsQuyetToanDoan>();
            VnsQuyetToanDoan objQt = new VnsQuyetToanDoan();
            if (objNghiepVu != null)
            {
                objQt.TkId = objNghiepVu.NghiepVuId;
                objQt.MaTk = objNghiepVu.MaNghiepVu;
                objQt.TenTk = objNghiepVu.TenNghiepVu;
                objQt.ChungTuId = ChungTuCuId;
            }

            lstQuyetToanDoanRa.Add(objQt);
            grvQuyetToan.RefreshData();
            Commons.GridHelper.SetFocusAfterAddRow(grvQuyetToan);
        }

        private void DeleteRow()
        {
            if (grvQuyetToan.FocusedRowHandle < 0) return;

            VnsQuyetToanDoan tmpdel = (VnsQuyetToanDoan)grvQuyetToan.GetRow(grvQuyetToan.FocusedRowHandle);
            grvQuyetToan.DeleteSelectedRows();
            grvQuyetToan.RefreshData();
        }

        private Guid LayIdChungTu()
        {
            foreach (VnsQuyetToanDoan tmp in lstQuyetToanDoanRa)
            {
                if (!VnsCheck.IsNullGuid(tmp.ChungTuId)) return tmp.ChungTuId;
            }

            return new Guid();
        }

        private void GetThongTinDuToan()
        {
            if (cboDoanCongTac.EditValue == null)
            {
                Commons.Commons.Message_Warning("Bạn chưa chọn đoàn ra");
                cboDoanCongTac.Focus();
                return;
            }

            lstDuToanDoanRa = VnsDuToanDoanService.GetByDoanCongTac(new Guid(cboDoanCongTac.EditValue.ToString()));
            if (lstDuToanDoanRa == null) return;

            //Guid chungtucuId = LayIdChungTu();

            lstQuyetToanDoanRa = new List<VnsQuyetToanDoan>();
            VnsQuyetToanDoan obj;
            foreach (VnsDuToanDoan tmp in lstDuToanDoanRa)
            {
                obj = new VnsQuyetToanDoan();
                obj = tmp.GenQuyetToanDoan();
                if (objNghiepVu != null)
                {
                    obj.TkId = objNghiepVu.NghiepVuId;
                    obj.MaTk = objNghiepVu.MaNghiepVu;
                    obj.TenTk = objNghiepVu.TenNghiepVu;
                    obj.ChungTuId = ChungTuCuId;
                }
                lstQuyetToanDoanRa.Add(obj);
            }

            grcQuyetToan.DataSource = lstQuyetToanDoanRa;
        }

        private Boolean CheckInput()
        {
            if (dteNgayCt.Text == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập ngày chứng từ");
                dteNgayCt.Focus();
                return false;
            }

            if (cboDoanCongTac.EditValue == null)
            {
                Commons.Commons.Message_Warning("Bạn chưa chọn đoàn ra");
                cboDoanCongTac.Focus();
                return false;
            }

            if (grvQuyetToan.RowCount == 0)
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập thông tin quyết toán đoàn ra");
                return false;
            }
            return true;
        }


        Guid ChungTuCuId = new Guid();
        private void SetObject()
        {
            objDoanCongTac = VnsDoanCongTacService.GetById(m_DoanRaId);
            if (objDoanCongTac != null)
            {
                cboDoanCongTac.EditValue = objDoanCongTac.Id;
                txtSoThongBaoQT.Text = objDoanCongTac.SoThongBaoQuyetToan;
            }
            lstQuyetToanDoanRa = VnsQuyetToanDoanService.GetByDoanCongTac(m_DoanRaId, m_LanQuyetToan);
            ChungTuCuId = LayIdChungTu();
            grcQuyetToan.DataSource = lstQuyetToanDoanRa;
            if (lstQuyetToanDoanRa.Count > 0)
            {
                dteNgayCt.DateTime = lstQuyetToanDoanRa[0].NgayCt;
            }
        }

        private VnsDoanCongTac GenDoanCongTac(VnsDoanCongTac objOld)
        {
            VnsDoanCongTac objNew = new VnsDoanCongTac();
            objNew.Id = Guid.NewGuid();
            objNew.TruongDoan = objOld.TruongDoan;
            objNew.Ten = objOld.Ten;
            objNew.MoTa = objOld.MoTa;
            objNew.NgayDi = objOld.NgayDi;
            objNew.NgayVe = objOld.NgayVe;
            objNew.TrangThai = objOld.TrangThai;
            objNew.ChucVuTruongDoanId = objOld.ChucVuTruongDoanId;
            objNew.DonViId = objOld.DonViId;
            objNew.LoaiDoanRaId = objOld.LoaiDoanRaId;
            objNew.SoThongBaoDuToan = objOld.SoThongBaoDuToan;
            objNew.NgayDuyetDuToan = objOld.NgayDuyetDuToan;
            objNew.DanhSachThanhVien = new List<VnsThanhVien>();
            objNew.DanhSachLichCongTac = new List<VnsLichCongTac>();
            objNew.DanhSachDuToanDoan = new List<VnsDuToanDoan>();

            //objNew.
            objNew.TenTruongDoan = objOld.TenTruongDoan;
            objNew.SoThongBaoQuyetToan = txtSoThongBaoQT.Text;
            objNew.TenVietTat = objOld.TenVietTat;
            objNew.NguoiGiaoDich = objOld.NguoiGiaoDich;
            objNew.NguoiGiaoDichVietTat = objOld.NguoiGiaoDichVietTat;
            objNew.IdBanDau = objOld.Id;
            return objNew;
        }


        private void GetObject()
        {
            //Lap quyet toan quan 
            //Neu Lap quyet toan lan dau: Su dung Doan ra da ton tai
            //Neu Lap quyet toan bo sung (Khong phai sua) se intert moi
            VnsDoanCongTac doandautien = new VnsDoanCongTac();
            if (m_FormState == FormUpdate.Insert && m_LanQuyetToan != 0)
            {
                if (VnsCheck.IsNullGuid(objDoanCongTac.Id) || objDoanCongTac.Id == objDoanCongTac.IdBanDau)
                    objDoanCongTac = GenDoanCongTac((VnsDoanCongTac)Commons.ComboHelper.GetSelectData(cboDoanCongTac));
            }
            else
            {

            }

            doandautien = VnsDoanCongTacService.GetById(objDoanCongTac.IdBanDau);

            objDoanCongTac.TrangThai = 2;// đã quyết toán

            //Ngay quyet toan lay quyet toan lan dau, quyet toan bo sung khong cap nhat vao quyet toan doan
            if (cboLanQuyetToan.SelectedIndex == 0)
                objDoanCongTac.NgayQuyetToan = dteNgayCt.DateTime;
            else
                objDoanCongTac.NgayQuyetToan = dteNgayCt.DateTime;

            objDoanCongTac.NgayDuyetDuToan = doandautien.NgayDuyetDuToan;
            objDoanCongTac.SoThongBaoDuToan = doandautien.SoThongBaoDuToan;

            foreach (VnsQuyetToanDoan objqt in lstQuyetToanDoanRa)
            {
                objqt.NgayCt = dteNgayCt.DateTime;
                objqt.NgayHt = dteNgayCt.DateTime;
                objqt.LanQuyetToan = cboLanQuyetToan.SelectedIndex;
                objqt.CongTacId = (Guid)cboDoanCongTac.EditValue;

                if (objqt.SoTien == 0)
                    objqt.NgoaiTeId = Globals.NoiTeId;
                else
                    objqt.NgoaiTeId = Globals.NgoaiTeId;
            }
            objDoanCongTac.DanhSachQuyetToanDoan = lstQuyetToanDoanRa;
            VnsChungTu objChungTu = new VnsChungTu();
            objChungTu.MaLoaiChungTu = objLoaiChungTu.MaLoaiChungTu;
            objChungTu.LoaiChungTutId = objLoaiChungTu.LoaiChungTuId;
            objChungTu.NgayCt = dteNgayCt.DateTime;
            objChungTu.NgayHt = dteNgayCt.DateTime;
            List<string> lstStr = VnsLoaiChungTuService.GetSoCT_prefix(objChungTu.LoaiChungTutId, DateTime.Now.Month, DateTime.Now.Year);
            if (lstStr.Count > 0)
                objChungTu.SoCt = lstStr[0] + lstStr[1];
            objChungTu.NoiDung = String.Format("Quyết toán đoàn ra: {0} {1} {2}"
                , objDoanCongTac.Ten
                , (String.IsNullOrEmpty(objDoanCongTac.SoTbDuToan) ? "" : " - DT: ") + objDoanCongTac.SoTbDuToan
                , (String.IsNullOrEmpty(objDoanCongTac.SoThongBaoQuyetToan) ? "" : " - QT: ") + objDoanCongTac.SoThongBaoQuyetToan);
            objChungTu.NguoiGiaoDich = objDoanCongTac.Ten;

            IList<VnsGiaoDich> lstGiaoDich = new List<VnsGiaoDich>();
            VnsNghiepVu objNghiepVuCo = VnsNghiepVuService.GetByKey("MaNghiepVu", objLoaiChungTu.MaTkCo);
            VnsGiaoDich objGiaoDich;
            foreach (VnsQuyetToanDoan obj in lstQuyetToanDoanRa)
            {
                // thanh toan bang ngoai te thi ko luu vao vnsGiaoDich
                //Sua lai thanh toan bang ngoai te van luu binh thuong
                objGiaoDich = new VnsGiaoDich();
                objGiaoDich.Id = Guid.NewGuid();
                objGiaoDich.TkNoId = obj.TkId;
                objGiaoDich.MaTkNo = obj.MaTk;
                objGiaoDich.TenTkNo = obj.TenTk;
                objGiaoDich.TkCoId = objNghiepVuCo.NghiepVuId;
                objGiaoDich.MaTkCo = objNghiepVuCo.MaNghiepVu;
                objGiaoDich.TenTkCo = objNghiepVuCo.TenNghiepVu;
                objGiaoDich.SoTienNt = obj.SoTien;
                objGiaoDich.SoTien = obj.SoTienVND;
                objGiaoDich.NgoaiTeId = obj.NgoaiTeId;
                objGiaoDich.TyGia = obj.TyGia;
                objGiaoDich.DoanRaCoId = objDoanCongTac.Id;
                objGiaoDich.DoanRaNoId = objDoanCongTac.Id;
                objGiaoDich.LoaiDoanRaCoId = objDoanCongTac.LoaiDoanRaId;
                objGiaoDich.LoaiDoanRaNoId = objDoanCongTac.LoaiDoanRaId;
                objGiaoDich.MucTieuMucCoId = obj.MucId;
                objGiaoDich.MucTieuMucNoId = obj.MucId;
                objGiaoDich.NoiDung = objChungTu.NoiDung;
                lstGiaoDich.Add(objGiaoDich);
            }

            //Decimal FlgLoad = 0;
            //if (m_LanQuyetToan == 0) FlgLoad = 1;
            //else FlgLoad = 0;

            //IList<VnsQuyetToanDoan> lsttmp = new List<VnsQuyetToanDoan>();
            //lsttmp = VnsQuyetToanDoanService.GetByDoanCongTac(objDoanCongTac.Id, FlgLoad);

            //foreach (VnsQuyetToanDoan tmp in lsttmp)
            //{
            //    //tmp.ChungTuId = objChungTu.Id;
            //    objDoanCongTac.DanhSachQuyetToanDoan.Add(tmp);


            VnsDoanCongTac sel = (VnsDoanCongTac)Commons.ComboHelper.GetSelectData(cboDoanCongTac);

            objDoanCongTac.SoThongBaoQuyetToan = txtSoThongBaoQT.Text;
            //objDoanCongTac.SoThongBaoDuToan = sel.SoThongBaoDuToan;

            VnsQuyetToanDoanService.SaveQuyetToanDoan(objDoanCongTac, objChungTu, lstGiaoDich, cboLanQuyetToan.SelectedIndex);

            //if (objDoanCongTac != null)
            //{
            //    objDoanCongTac.SoThongBaoQuyetToan = txtSoThongBaoQT.Text;
            //    VnsDoanCongTacService.SaveOrUpdate(objDoanCongTac);
            //}
            MessageBox.Show("Đã lưu quyết toán thành công");
        }

        #endregion

        #region"Events"

        private void grvQuyetToan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            if (Commons.GridHelper.CheckAddNewRow(grvQuyetToan))
                AddNewRow();
        }

        private void grvQuyetToan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (grvQuyetToan.FocusedRowHandle < 0) return;
            VnsQuyetToanDoan tmp = (VnsQuyetToanDoan)grvQuyetToan.GetRow(grvQuyetToan.FocusedRowHandle);
            switch (e.Column.Name)
            {
                case "colMucId":
                    VnsDmMucTieuMuc tmpMuc = (VnsDmMucTieuMuc)cboMucId.GetDataSourceRowByKeyValue(tmp.MucId);
                    tmp.TenKhoanChi = tmpMuc.TenMuc;
                    break;
                case "TkId":
                    VnsNghiepVu objNghiepVu = (VnsNghiepVu)cboTaiKhoan.GetDataSourceRowByKeyValue(tmp.TkId);
                    tmp.TenTk = objNghiepVu.TenNghiepVu;
                    tmp.MaTk = objNghiepVu.MaNghiepVu;
                    break;
                case "colSoTien":
                    break;
                case "colSoTienVND":
                    if (tmp.SoTienVND != 0) tmp.SoTien = 0;
                    break;
                case "TyGia":
                    tmp.SoTienVND = tmp.SoTien * tmp.TyGia;
                    break;
            }
        }

        private void FrmQuyetToanDoanEdit_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    AddNewRow();
                    Commons.GridHelper.SetFocusAfterAddRow(grvQuyetToan);
                    break;
                case Keys.F8:
                    if (Commons.Commons.Message_Confirm("Bạn có chắc chắn xóa bản ghi?", false))
                    {
                        DeleteRow();
                    }
                    break;
            }

            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                btnLuu_Click(btnLuu, null);
            }

        }

        #endregion



        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckInput())
                    return;
                GetObject();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void btnDuToan_Click(object sender, EventArgs e)
        {
            try
            {
                GetThongTinDuToan();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboDoanCongTac_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                objDoanCongTac = (VnsDoanCongTac)Commons.ComboHelper.GetSelectData(cboDoanCongTac);
                if (objDoanCongTac == null) return;

                txtTruongDoan.Text = objDoanCongTac.TruongDoan;
                txtLoaiDoanRa.Text = objDoanCongTac.TenLoaiDoanRa;
                txtNgayDi.Text = objDoanCongTac.NgayDi.ToString("dd/MM/yyyy");
                txtNgayVe.Text = objDoanCongTac.NgayVe.ToString("dd/MM/yyyy");
                txtMoTa.Text = objDoanCongTac.MoTa;
                if (!DoLoadData)
                {
                    m_DoanRaId = objDoanCongTac.Id;
                    SetObject();
                }
            }

            catch (Exception Ex)
            {
                Commons.Commons.Message_Error(Ex);
            }
        }

        private void FrmQuyetToanDoanEdit_Load(object sender, EventArgs e)
        {

        }
    }
}