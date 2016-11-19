using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.QuanLyDoanRa.Domain;
using QuanLyDoanRa.Reports;
using QuanLyDoanRa.Controls;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Domain.Report;

namespace QuanLyDoanRa
{
    public partial class FrmUyNhiemChiEdit : Form
    {
        #region "Property Service"
        public IVnsLoaiChungTuService VnsLoaiChungTuService;
        public IVnsDmKhachHangService VnsDmKhachHangService;
        public IVnsChungTuService VnsChungTuService;
        public IVnsGiaoDichService VnsGiaoDichService;
        public IVnsNghiepVuService VnsNghiepVuService;
        public IVnsLoaiDoanRaService VnsLoaiDoanRaService;
        public IVnsDoanCongTacService VnsDoanCongTacService;
        public IVnsDmMucTieuMucService VnsDmMucTieuMucService;
        public IVnsDmHeThongService VnsDmHeThongService;
        public IVnsNgoaiTeService VnsNgoaiTeService;
        #endregion

        #region "Variable"
        private FormUpdate m_FormStatus;
        private VnsLoaiChungTu m_objLoaiChungTu;
        private VnsChungTu m_objChungTu = new VnsChungTu();
        private string m_groupCt;
        private IList<VnsGiaoDich> lstGiaoDich;
        private IList<VnsGiaoDich> lstDelGiaoDich;
        private IList<VnsNghiepVu> lstNghiepVu;
        #endregion

        #region ShowForm

        public FrmUyNhiemChiEdit()
        {
            InitializeComponent();
        }

        public Guid Show_Form(VnsChungTu p_objChungTu, FormUpdate p_FormStatus, string groupCt)
        {
            m_FormStatus = p_FormStatus;
            m_objChungTu = p_objChungTu;
            m_groupCt = groupCt;

            

            /*Trong truong hop giay bao no, nguoi dung can chi tiet so can cu quyet toan => dung truong MoTa de luu thong tin nay*/
            if (groupCt == "GBN" || groupCt == "GBN_VND")
            {
                colMoTa.Visible = true;
            }
            else
            {
                colMoTa.Visible = false;
            }

            InitControl();
            BindCombo();
            BindData();

            if (this.ShowDialog() == DialogResult.OK)
            {
                return m_objChungTu.Id;
            }
            else
            {
                return new Guid();
            }
        }
        #endregion

        #region "Functions"

        private void InitControl()
        {
            VnsLoaiChungTu objLoaiChungTu = VnsLoaiChungTuService.GetByMa(m_groupCt);
            if (objLoaiChungTu != null)
                this.Text = objLoaiChungTu.Ten;

            if (m_groupCt == "NPT")
            {
                //this.Text = "Phiếu thu";
                btDSKhoNte.Visible = false;
            }
            else if (m_groupCt == "NPC")
            {
                //this.Text = "Phiếu chi";
                btDSKhoNte.Visible = true;
            }
            else if (m_groupCt == "KTK")
                this.Text = "Phiếu kế toán khác";
            else if (m_groupCt == "GBN")
            {
                //this.Text = "Giấy báo nợ";
                btDSKhoNte.Visible = true;
            }
            else if (m_groupCt == "GBC")
            {
                //this.Text = "Giấy báo có";
                btDSKhoNte.Visible = false;
            }
            if (m_FormStatus == FormUpdate.Insert)
            {
                btnInPhieu.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                btnInPhieu.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
        private void BindData()
        {
            switch (m_FormStatus)
            {
                case FormUpdate.Update:
                    m_objChungTu = VnsChungTuService.GetById(m_objChungTu.Id);
                    cboLoaiChungTu.EditValue = m_objChungTu.MaLoaiChungTu;
                    m_objLoaiChungTu = (VnsLoaiChungTu)cboLoaiChungTu.Properties.GetRowByKeyValue(cboLoaiChungTu.EditValue);
                    SetObject();
                    break;
            }
        }

        private void BindDataToCbo()
        {
            //Bind data to Loai ctu
            IList<VnsLoaiChungTu> lstLoaiCt = VnsLoaiChungTuService.GetByGroup(m_groupCt);
            cboLoaiChungTu.Properties.DataSource = lstLoaiCt;
            cboLoaiChungTu.Properties.ValueMember = "MaLoaiChungTu";
            cboLoaiChungTu.Properties.DisplayMember = "Ten";

            if (lstLoaiCt.Count > 0)
                cboLoaiChungTu.EditValue = lstLoaiCt[0].MaLoaiChungTu;
            //Bind data to trang thai

            List<VnsDmHeThong> lstTrangThai = new List<VnsDmHeThong>();
            lstTrangThai.Add(new VnsDmHeThong());
            lstTrangThai.AddRange(VnsDmHeThongService.GetByDoiTuong("TRANG_THAI_PHIEU"));
            cboTrangThai.Properties.DataSource = lstTrangThai;
            cboTrangThai.Properties.ValueMember = "Ma";
            cboTrangThai.Properties.DisplayMember = "Ten";

            List<VnsNgoaiTe> lstNgoaiTe = new List<VnsNgoaiTe>();
            //lstNgoaiTe.Add(new VnsNgoaiTe());
            lstNgoaiTe.AddRange(VnsNgoaiTeService.GetAll());
            cboNgoaiTe.DataSource = lstNgoaiTe;
        }

        private void SetColumnByLoaiPhieu(decimal _LoaiPhieu)
        {
            if (_LoaiPhieu == 1)
            {
                _GridView.Columns["DoanRaNoId"].Visible = true;
                _GridView.Columns["LoaiDoanRaNoId"].Visible = true;
                _GridView.Columns["DoanRaCoId"].Visible = false;
                _GridView.Columns["LoaiDoanRaCoId"].Visible = false;
                _GridView.Columns["TyGiaTuDong"].Visible = false;
            }
            else if (_LoaiPhieu == 0)
            {
                _GridView.Columns["DoanRaCoId"].Visible = true;
                _GridView.Columns["LoaiDoanRaCoId"].Visible = true;
                _GridView.Columns["DoanRaNoId"].Visible = false;
                _GridView.Columns["LoaiDoanRaNoId"].Visible = false;
                _GridView.Columns["TyGiaTuDong"].Visible = false;
            }
            else
            {
                _GridView.Columns["DoanRaCoId"].Visible = false;
                _GridView.Columns["LoaiDoanRaCoId"].Visible = true;
                _GridView.Columns["DoanRaNoId"].Visible = false;
                _GridView.Columns["LoaiDoanRaNoId"].Visible = true;
                _GridView.Columns["TyGiaTuDong"].Visible = true;
            }
        }

        private IList<String> GetIdTenByMaNv(String MaNv)
        {
            IList<String> lst = new List<String>();
            foreach (VnsNghiepVu obj in lstNghiepVu)
            {
                if (MaNv == obj.MaNghiepVu)
                {
                    lst.Add(obj.NghiepVuId.ToString());
                    lst.Add(obj.TenNghiepVu);
                }
            }
            return lst;
        }

        private void BindCombo()
        {
            BindDataToCbo();

            List<VnsDoanCongTac> lstDoanCongTac = new List<VnsDoanCongTac>();
            lstDoanCongTac.Add(new VnsDoanCongTac());
            lstDoanCongTac.AddRange(VnsDoanCongTacService.GetAllOrderByNgayDi());
            cboDoanRaNoId.DataSource = lstDoanCongTac;
            rcboDoanRaNoId.DataSource = lstDoanCongTac;
            cboDoanRaCoId.DisplayMember = "TenHienThi";
            cboDoanRaCoId.ValueMember = "Id";
            cboDoanRaCoId.DataSource = lstDoanCongTac;

            rcboDoanRaCoId.DataSource = lstDoanCongTac;

            List<VnsLoaiDoanRa> lstLoaiDoanRa = new List<VnsLoaiDoanRa>();
            lstLoaiDoanRa.Add(new VnsLoaiDoanRa());
            lstLoaiDoanRa.AddRange(VnsLoaiDoanRaService.GetAll());
            cboLoaiDoanRaCoId.DataSource = lstLoaiDoanRa;
            cboLoaiDoanRaNoId.DataSource = lstLoaiDoanRa;

            //Bind khach hang
            List<VnsDmKhachHang> lstKhachHang = new List<VnsDmKhachHang>();
            lstKhachHang.Add(new VnsDmKhachHang());
            lstKhachHang.AddRange(VnsDmKhachHangService.GetAll());
            cboMaKhachHang.Properties.DataSource = lstKhachHang;
            cboMaKhachHang.Properties.DisplayMember = "MaKhachHang";
            cboMaKhachHang.Properties.ValueMember = "Id";
        }

        private void AddRow()
        {
            if (lstGiaoDich == null) lstGiaoDich = new List<VnsGiaoDich>();

            lstGiaoDich.Add(new VnsGiaoDich());
            _GridControl.DataSource = lstGiaoDich;
            _GridControl.RefreshDataSource();

            Commons.GridHelper.SetFocusAfterAddRow(_GridView);
        }

        private void DeleteRow()
        {
            if (_GridView.FocusedRowHandle < 0) return;

            VnsGiaoDich gd = (VnsGiaoDich)_GridView.GetRow(_GridView.FocusedRowHandle);
            if (lstDelGiaoDich == null)
                lstDelGiaoDich = new List<VnsGiaoDich>();
            lstDelGiaoDich.Add(gd);
            _GridView.DeleteSelectedRows();
            _GridView.RefreshData();
        }

        private void GetObject()
        {
            if (m_objChungTu == null)
                m_objChungTu = new VnsChungTu();

            bool flg = false;
            switch (m_FormStatus)
            {
                case FormUpdate.Insert:
                    flg = true;
                    if (string.IsNullOrEmpty(ucCtuSo.Text))
                    {
                        ucCtuSo.Soct(m_objLoaiChungTu.IdDmCha, dteNgayCt.DateTime.Month, dteNgayCt.DateTime.Year);
                        ucCtuSo.Text = ucCtuSo.SO_CHUNG_TU;
                    }
                    break;
                case FormUpdate.Update:
                    flg = false;
                    break;
            }

            m_objChungTu.LoaiChungTutId = m_objLoaiChungTu.LoaiChungTuId;
            m_objChungTu.MaLoaiChungTu = m_objLoaiChungTu.MaLoaiChungTu;
            m_objChungTu.TrangThai = 0;
            if (cboTrangThai.EditValue != null)
            {
                if (cboTrangThai.EditValue.ToString() != "")
                {
                    m_objChungTu.TrangThai = int.Parse(cboTrangThai.EditValue.ToString());
                }
            }
            if (cboTrangThai.Properties.ReadOnly == true)
                m_objChungTu.TrangThai = 0;

            m_objChungTu.NhomCt = m_objLoaiChungTu.MaDmCha;
            m_objChungTu.NgayCt = dteNgayCt.DateTime;
            m_objChungTu.NgayHt = dteNgayht.DateTime;
            m_objChungTu.NguoiGiaoDich = txtNguoiNhan.Text;
            m_objChungTu.NguoiGiaoDichVietTat = txtTenVietTat.Text;
            m_objChungTu.DiaChi = txtDiaChi.Text;
            m_objChungTu.SoCt = ucCtuSo.Text;
            m_objChungTu.NoiDung = txtNoiDung.Text;
            m_objChungTu.NhomCt = m_objLoaiChungTu.MaDmCha;

            IList<String> lst;
            foreach (VnsGiaoDich obj in lstGiaoDich)
            {
                if (cboMaKhachHang.EditValue != null)
                {
                    obj.KhachHangCoId = new Guid(cboMaKhachHang.EditValue.ToString());
                    obj.KhachHangNoId = new Guid(cboMaKhachHang.EditValue.ToString());
                }
                obj.DuLuong = obj.SoTienNt;

                //lst= new List<String>();
                //if (m_objLoaiChungTu.LoaiPhieu == 1)
                //{
                //    lst = GetIdTenByMaNv(m_objLoaiChungTu.MaTkCo);
                //    obj.MaTkCo = m_objLoaiChungTu.MaTkCo;
                //    if (lst.Count>0)
                //    {
                //        obj.TenTkCo =lst[1];
                //        obj.TkCoId = new Guid(lst[0]);
                //    }
                //}
                //else
                //{
                //    lst = GetIdTenByMaNv(m_objLoaiChungTu.MaTkNo);
                //    obj.MaTkNo = m_objLoaiChungTu.MaTkNo;
                //    if (lst.Count > 0)
                //    {
                //        obj.TenTkNo = lst[1];
                //        obj.TkNoId = new Guid(lst[0]);
                //    }
                //}
            }

            VnsChungTuService.SaveChungTu(flg, m_objChungTu, lstGiaoDich, lstDelGiaoDich);
        }

        private void SetObject()
        {
            cboLoaiChungTu.EditValue = m_objChungTu.MaLoaiChungTu;
            dteNgayCt.EditValue = m_objChungTu.NgayCt;
            dteNgayht.EditValue = m_objChungTu.NgayHt;
            txtNguoiNhan.Text = m_objChungTu.NguoiGiaoDich;
            txtTenVietTat.Text = m_objChungTu.NguoiGiaoDichVietTat;
            ucCtuSo.Text = m_objChungTu.SoCt;
            txtNoiDung.Text = m_objChungTu.NoiDung;
            cboTrangThai.EditValue = m_objChungTu.TrangThai;
            lstGiaoDich = VnsGiaoDichService.GetByChungTu(m_objChungTu.Id);
            _GridControl.DataSource = lstGiaoDich;

            if (lstGiaoDich.Count > 0)
            {
                cboMaKhachHang.EditValue = lstGiaoDich[0].KhachHangCoId;
            }
            txtDiaChi.Text = m_objChungTu.DiaChi;
        }

        private Boolean CheckInput()
        {
            if (cboLoaiChungTu.EditValue == null)
            {
                Commons.Commons.Message_Warning("Bạn chưa chọn loại chứng từ");
                cboLoaiChungTu.Focus();
                return false;
            }
            if (dteNgayCt.Text == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập ngày chứng từ");
                dteNgayCt.Focus();
                return false;
            }

            if (dteNgayht.Text == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập ngày hạch toán");
                dteNgayht.Focus();
                return false;
            }

            if (_GridView.RowCount == 0)
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập chi tiết hoạch toán");
                return false;
            }
            return true;
        }

        #endregion

        #region "Events"

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    AddRow();
                    break;
                case Keys.F8:
                    DeleteRow();
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
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

        private void gvTamUng_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (_GridView.FocusedRowHandle < 0) return;
                VnsGiaoDich tmp = (VnsGiaoDich)_GridView.GetRow(_GridView.FocusedRowHandle);
                switch (e.Column.Name)
                {
                    case "colTkNoId":
                        VnsNghiepVu tmpNghiepVuNo = (VnsNghiepVu)cboNghiepVuNo.GetDataSourceRowByKeyValue(tmp.TkNoId);
                        tmp.TenTkNo = tmpNghiepVuNo.TenNghiepVu;
                        tmp.MaTkNo = tmpNghiepVuNo.MaNghiepVu;
                        break;
                    case "colTkCoId":
                        VnsNghiepVu tmpNghiepVuCo = (VnsNghiepVu)CboNghiepVuCo.GetDataSourceRowByKeyValue(tmp.TkCoId);
                        tmp.TenTkCo = tmpNghiepVuCo.TenNghiepVu;
                        tmp.MaTkCo = tmpNghiepVuCo.MaNghiepVu;
                        break;
                    case "colDoanRaNoId":
                        VnsDoanCongTac tmpDoanCongTacNo = (VnsDoanCongTac)rcboDoanRaNoId.GetRowByKeyValue(tmp.DoanRaNoId);
                        if (tmpDoanCongTacNo != null)
                        {
                            if (m_objLoaiChungTu.LoaiPhieu != 2)
                            {
                                tmp.DoanRaCoId = tmp.DoanRaNoId;
                                tmp.LoaiDoanRaNoId = tmpDoanCongTacNo.LoaiDoanRaId;
                                tmp.LoaiDoanRaCoId = tmpDoanCongTacNo.LoaiDoanRaId;
                            }
                        }
                        break;
                    case "colDoanRaCoId":
                        VnsDoanCongTac tmpDoanCongTacCo = (VnsDoanCongTac)rcboDoanRaCoId.GetRowByKeyValue(tmp.DoanRaCoId);
                        if (tmpDoanCongTacCo != null)
                        {
                            if (m_objLoaiChungTu.LoaiPhieu != 2)
                            {
                                tmp.DoanRaNoId = tmp.DoanRaCoId;
                                tmp.LoaiDoanRaNoId = tmpDoanCongTacCo.LoaiDoanRaId;
                                tmp.LoaiDoanRaCoId = tmpDoanCongTacCo.LoaiDoanRaId;
                            }
                        }
                        break;
                    case "colSoTienNte":
                    case "colTyGia":
                        tmp.SoTien = tmp.SoTienNt * tmp.TyGia;
                        break;
                    case "colLoaiDoanRaNoId":
                        if (m_objLoaiChungTu.LoaiPhieu != 2)
                        {
                            tmp.LoaiDoanRaCoId = tmp.LoaiDoanRaNoId;
                        }
                        break;
                    case "colLoaiDoanRaCoId":
                        if (m_objLoaiChungTu.LoaiPhieu != 2)
                        {
                            tmp.LoaiDoanRaNoId = tmp.LoaiDoanRaCoId;
                        }
                        break;
                    case "colNgoaiTeId":
                        if (tmp.NgoaiTeId == Vns.QuanLyDoanRa.Globals.NoiTeId)
                        {
                            tmp.SoTienNt = 1;
                            tmp.TyGia = 1;
                        }
                        break;

                }
                _GridControl.RefreshDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvTamUng_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter)
                    return;

                if (Commons.GridHelper.CheckAddNewRow(_GridView, true))
                {
                    AddRow();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtNgayChungTu_Leave(object sender, EventArgs e)
        {
            if (dteNgayCt.Text != "")
                dteNgayht.DateTime = dteNgayCt.DateTime;
        }

        private void cboMaKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                VnsDmKhachHang objKhachHang = (VnsDmKhachHang)cboMaKhachHang.Properties.GetRowByKeyValue(cboMaKhachHang.EditValue);
                if (objKhachHang != null)
                {
                    txtTenKhachHang.Text = objKhachHang.TenKhachHang;
                    txtDiaChi.Text = objKhachHang.DiaChi;
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }

        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                popView.ShowPopup(Control.MousePosition);

            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }

        }

        private void barInphieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!CheckInput())
                    return;
                if (lstGiaoDich == null)
                {
                    Commons.Commons.Message_Warning("Bạn chưa nhập dữ liệu");
                    return;
                }
                frmInPhieu frm = new frmInPhieu(m_objChungTu, lstGiaoDich, m_objLoaiChungTu);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void barInUyNhiemChi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!CheckInput())
                    return;

                ReportHelper rpHelper = new ReportHelper();
                rpHelper.CallReportUyNhiemChi(m_objChungTu, lstGiaoDich);

                //VnsDmKhachHang objKhachHang = (VnsDmKhachHang)cboMaKhachHang.Properties.GetRowByKeyValue(cboMaKhachHang.EditValue);
                //if (objKhachHang == null)
                //    objKhachHang = new VnsDmKhachHang();
                //Decimal SoTien = 0;
                //foreach (VnsGiaoDich obj in lstGiaoDich)
                //{
                //    SoTien = SoTien + obj.SoTienNt;
                //    obj.NoiDung = txtNoiDung.Text;
                //}
                //InUyNhiemChi PrintUyNhiem = new InUyNhiemChi(m_objChungTu, objKhachHang, lstGiaoDich, SoTien, dteNgayCt.DateTime);
                //PrintUyNhiem.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }
        private void FrmUyNhiemChiEdit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
                {
                    btnSave_Click(btnSave, null);
                }

            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void cboLoaiChungTu_EditValueChanged(object sender, EventArgs e)
        {
            m_objLoaiChungTu = (VnsLoaiChungTu)cboLoaiChungTu.Properties.GetRowByKeyValue(cboLoaiChungTu.EditValue);
            SetColumnByLoaiPhieu(m_objLoaiChungTu.LoaiPhieu);
            //Bind data by loai ct
            if (m_objLoaiChungTu.LoaiPhieu == 2)
            {
                lstNghiepVu = VnsNghiepVuService.GetAll();
                cboNghiepVuNo.DataSource = lstNghiepVu;
                CboNghiepVuCo.DataSource = lstNghiepVu;
            }
            else
            {
                lstNghiepVu = VnsNghiepVuService.GetAll();
                cboNghiepVuNo.DataSource = VnsNghiepVuService.GetNghiepVuKtk(lstNghiepVu, false, m_objLoaiChungTu);
                CboNghiepVuCo.DataSource = VnsNghiepVuService.GetNghiepVuKtk(lstNghiepVu, true, m_objLoaiChungTu);
            }

            if (m_objLoaiChungTu.IsTrangThai == 1)
            {
                cboTrangThai.Properties.ReadOnly = false;
            }
            else
            {
                cboTrangThai.Properties.ReadOnly = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (m_objChungTu != null)
            {
                if (Commons.Commons.Message_Confirm("Bạn có muốn xóa bản ghi này không?"))
                {
                    VnsChungTuService.DeleteChungTu(m_objChungTu);
                    Commons.Commons.Message_Information("Xóa thành công");
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }
        #endregion

        private void btDSKhoNte_Click(object sender, EventArgs e)
        {
            GetSoDu4Input frmkho = (GetSoDu4Input)ObjectFactory.GetObject("GetSoDu4Input");

            if (m_objChungTu != null)
                frmkho.ChungTuId = m_objChungTu.Id;
            else
                frmkho.ChungTuId = new Guid();

            frmkho.ShowDialog();

            if (!frmkho.IsOk) return;

            if (lstGiaoDich == null) lstGiaoDich = new List<VnsGiaoDich>();

            IList<RP_Doan_CongNo> lstcongno = frmkho.LstPhanBo;
            if (lstcongno != null)
            {
                foreach (RP_Doan_CongNo tmpcongno in lstcongno)
                {
                    VnsGiaoDich tmp = new VnsGiaoDich();
                    tmp.SoTienNt = tmpcongno.SoTienXuat;
                    tmp.TyGia = tmpcongno.TyGia;
                    tmp.SoTien = tmpcongno.SoTienXuat * tmpcongno.TyGia;

                    lstGiaoDich.Add(tmp);
                }
            }

            _GridControl.DataSource = lstGiaoDich;
            _GridControl.RefreshDataSource();
        }

        private void _GridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

        }

        private void _GridView_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (_GridView.FocusedRowHandle < 0) return;
            VnsGiaoDich tmp = (VnsGiaoDich)_GridView.GetRow(_GridView.FocusedRowHandle);

            if (_GridView.FocusedColumn.Name == "colSoTienNte" || _GridView.FocusedColumn.Name == "colTyGia")
            {
                if (tmp.NgoaiTeId == Vns.QuanLyDoanRa.Globals.NoiTeId)
                {
                    e.Cancel = true;
                }
            }

        }

        //private void FrmUyNhiemChiEdit_Load(object sender, EventArgs e)
        //{

        //}
    }
}
