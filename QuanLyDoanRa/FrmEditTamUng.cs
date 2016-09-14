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

namespace QuanLyDoanRa
{
    public partial class FrmEditTamUng : Form
    {
        #region "Property Service"
            public IVnsLoaiChungTuService VnsLoaiChungTuService;
            public IVnsChungTuService VnsChungTuService;
            public IVnsGiaoDichService VnsGiaoDichService;
            public IVnsNghiepVuService VnsNghiepVuService;
            public IVnsLoaiDoanRaService VnsLoaiDoanRaService;
            public IVnsDoanCongTacService VnsDoanCongTacService;
            public IVnsDmMucTieuMucService VnsDmMucTieuMucService;
            
        #endregion

        #region "Variable"
            private FormUpdate m_FormStatus;
            private VnsLoaiChungTu m_objLoaiChungTu;
            private VnsChungTu m_objChungTu =  new VnsChungTu();

            private IList<VnsGiaoDich> lstGiaoDich;
            private IList<VnsGiaoDich> lstDelGiaoDich;
            private IList<VnsNghiepVu> lstNghiepVu;

        #endregion

       #region ShowForm

        public Guid Show_Form(VnsLoaiChungTu p_objLoaiChungTu, VnsChungTu p_objChungTu, FormUpdate p_FormStatus)
        {
            m_FormStatus = p_FormStatus;
            m_objChungTu = p_objChungTu;
            m_objLoaiChungTu = p_objLoaiChungTu;

            InitControl();

            this.Text = m_objLoaiChungTu.Ten;
            _groupControlCt.Text = "Chi tiết " + m_objLoaiChungTu.Ten;
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
                if (m_FormStatus == FormUpdate.Insert)
                { btnInPhieu.Enabled = false; }
                else
                { btnInPhieu.Enabled = true; }
            }

            public FrmEditTamUng()
            {
                InitializeComponent();
            }

            private void BindData()
            {
               SetColumnByLoaiPhieu(m_objLoaiChungTu.LoaiPhieu);
               switch (m_FormStatus)
                {
                    case FormUpdate.Update:
                        //m_objChungTu = VnsChungTuService.GetById(m_objChungTu.Id);
                        SetObject();
                        break;
                }
            }            

            private void SetColumnByLoaiPhieu(decimal _LoaiPhieu)
            {
                if (_LoaiPhieu == 1)
                {
                    //Phieu chi(co tren no duoi)
                    _GridView.Columns["TkNoId"].Visible = true;
                    _GridView.Columns["TenTkNo"].Visible = true;
                    _GridView.Columns["DoanRaNoId"].Visible = true;
                    _GridView.Columns["LoaiDoanRaNoId"].Visible = true;
                    //_GridView.Columns["MucTieuMucNoId"].Visible = true;

                    _GridView.Columns["TkCoId"].Visible = false;
                    _GridView.Columns["TenTkCo"].Visible = false;
                    _GridView.Columns["DoanRaCoId"].Visible = false;
                    _GridView.Columns["LoaiDoanRaCoId"].Visible = false;
                    //_GridView.Columns["MucTieuMucCoId"].Visible = false;
                }
                else
                {
                    _GridView.Columns["TkCoId"].Visible = true;
                    _GridView.Columns["TenTkCo"].Visible = true;
                    _GridView.Columns["DoanRaCoId"].Visible = true;
                    _GridView.Columns["LoaiDoanRaCoId"].Visible = true;
                    //_GridView.Columns["MucTieuMucCoId"].Visible = true;

                    _GridView.Columns["TkNoId"].Visible = false;
                    _GridView.Columns["TenTkNo"].Visible = false;
                    _GridView.Columns["DoanRaNoId"].Visible = false;
                    _GridView.Columns["LoaiDoanRaNoId"].Visible = false;
                   // _GridView.Columns["MucTieuMucNoId"].Visible = false;
                }

                //if (m_objLoaiChungTu.MaLoaiChungTu == "PT" || m_objLoaiChungTu.MaLoaiChungTu == "PC")
                //{
                //    btnInPhieu.Visible = true;
                //}
                //else
                //{
                //    btnInPhieu.Visible = false;
                //}
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
                //_GridView.Columns
                lstNghiepVu = VnsNghiepVuService.GetAll();
                cboNghiepVuNo.DataSource =VnsNghiepVuService.GetDatasourceByLoaiCt(lstNghiepVu,m_objLoaiChungTu);
                CboNghiepVuCo.DataSource = VnsNghiepVuService.GetDatasourceByLoaiCt(lstNghiepVu, m_objLoaiChungTu);

                List<VnsDoanCongTac> lstDoanCongTac = new List<VnsDoanCongTac>();
                lstDoanCongTac.Add(new VnsDoanCongTac());
                lstDoanCongTac.AddRange(VnsDoanCongTacService.GetAll());
                cboDoanRaNoId.DataSource = lstDoanCongTac;
                cboDoanRaCoId.DataSource = lstDoanCongTac;

                List<VnsLoaiDoanRa> lstLoaiDoanRa = new List<VnsLoaiDoanRa>();
                lstLoaiDoanRa.Add(new VnsLoaiDoanRa());
                lstLoaiDoanRa.AddRange(VnsLoaiDoanRaService.GetAll());
                cboLoaiDoanRaCoId.DataSource = lstLoaiDoanRa;
                cboLoaiDoanRaNoId.DataSource = lstLoaiDoanRa;
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
                if (this.m_objChungTu == null)
                    this.m_objChungTu = new VnsChungTu();

                bool flg = false;
                switch (m_FormStatus)
                {
                    case FormUpdate.Insert:
                        flg = true;
                        ucCtuSo.Soct(m_objLoaiChungTu.LoaiChungTuId, txtNgayChungTu.DateTime.Month, txtNgayChungTu.DateTime.Year);
                        ucCtuSo.Text = ucCtuSo.SO_CHUNG_TU;
                        //ucCtuSo.Text = "1";
                        break;
                    case FormUpdate.Update:
                        flg = false;
                        break;
                }

                this.m_objChungTu.LoaiChungTutId = m_objLoaiChungTu.LoaiChungTuId;
                this.m_objChungTu.MaLoaiChungTu = m_objLoaiChungTu.MaLoaiChungTu;

                this.m_objChungTu.NgayCt = (DateTime)txtNgayChungTu.EditValue;
                this.m_objChungTu.NgayHt = (DateTime)txtNgayHachToan.EditValue;
                this.m_objChungTu.NguoiGiaoDich = txtNguoiNhan.Text;
                this.m_objChungTu.DiaChi = txtDiaChi.Text;
                this.m_objChungTu.SoCt = ucCtuSo.Text;
                this.m_objChungTu.NoiDung = txtNoiDung.Text;

                IList<String> lst;
                foreach (VnsGiaoDich obj in lstGiaoDich)
                {
                    lst= new List<String>();
                    if (m_objLoaiChungTu.LoaiPhieu == 1)
                    {
                        lst =GetIdTenByMaNv(m_objLoaiChungTu.MaTkCo);
                        obj.MaTkCo = m_objLoaiChungTu.MaTkCo;
                        if (lst.Count>0)
                        {
                            obj.TenTkCo =lst[1];
                            obj.TkCoId = new Guid(lst[0]);
                        }
                    }
                    else
                    {
                        lst = GetIdTenByMaNv(m_objLoaiChungTu.MaTkNo);
                        obj.MaTkNo = m_objLoaiChungTu.MaTkNo;
                        if (lst.Count > 0)
                        {
                            obj.TenTkNo = lst[1];
                            obj.TkNoId = new Guid(lst[0]);
                        }
                    }
                    obj.DuLuong = obj.SoTienNt;
                }

                VnsChungTuService.SaveChungTu(flg, this.m_objChungTu, lstGiaoDich, lstDelGiaoDich);
                //this.IsOk = true;
                //this.Close();
            }

            private void SetObject()
            {
                txtNgayChungTu.EditValue = m_objChungTu.NgayCt;
                txtNgayHachToan.EditValue = m_objChungTu.NgayHt;
                txtNguoiNhan.Text = m_objChungTu.NguoiGiaoDich;
                txtDiaChi.Text = m_objChungTu.DiaChi;
                ucCtuSo.Text = m_objChungTu.SoCt;
                txtNoiDung.Text = m_objChungTu.NoiDung;

                lstGiaoDich = VnsGiaoDichService.GetByChungTu(m_objChungTu.Id);
                //this.m_objChungTu = m_objChungTu;
                _GridControl.DataSource = lstGiaoDich;
            }

            private Boolean CheckInput()
            {
                if (txtNgayChungTu.Text =="")
                {
                    MessageBox.Show("Bạn chưa nhập ngày chứng từ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgayChungTu.Focus();
                    return false;
                }

                if (txtNgayHachToan.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập ngày hạch toán", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgayHachToan.Focus();
                    return false;
                }
                
                if (_GridView.RowCount == 0)
                {
                    MessageBox.Show("Bạn chưa nhập chi tiết hạch toán", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                foreach (VnsGiaoDich obj in lstGiaoDich)
                {
                    //if (obj.NghiepVuId == Guid.Empty)
                    //{
                    //    MessageBox.Show("Bạn chưa nhập đủ mã nghiệp vụ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return false;
                    //}

                    //if (obj.DoanRaId == Guid.Empty)
                    //{
                    //    MessageBox.Show("Bạn chưa nhập đủ đoàn ra", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return false;
                    //}

                    //if (obj.LoaiDoanRaId == Guid.Empty)
                    //{
                    //    MessageBox.Show("Bạn chưa nhập đủ loại đoàn ra", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return false;
                    //}
                }
                return true;
            }

        #endregion

        #region "Events"            

            private void gridControl1_KeyDown(object sender, KeyEventArgs e)
            {
                
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
                  catch(Exception ex)
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
                            VnsDoanCongTac tmpDoanCongTacNo = (VnsDoanCongTac)cboDoanRaNoId.GetDataSourceRowByKeyValue(tmp.DoanRaNoId);
                            tmp.LoaiDoanRaNoId = tmpDoanCongTacNo.LoaiDoanRaId;
                            tmp.LoaiDoanRaCoId = tmpDoanCongTacNo.LoaiDoanRaId;
                            tmp.DoanRaCoId = tmpDoanCongTacNo.Id;
                            break;
                        case "colDoanRaCoId":
                            VnsDoanCongTac tmpDoanCongTacCo = (VnsDoanCongTac)cboDoanRaNoId.GetDataSourceRowByKeyValue(tmp.DoanRaCoId);
                            tmp.LoaiDoanRaCoId = tmpDoanCongTacCo.LoaiDoanRaId;
                            tmp.LoaiDoanRaNoId = tmpDoanCongTacCo.LoaiDoanRaId;
                            tmp.DoanRaNoId = tmpDoanCongTacCo.Id;
                            break;

                        case "colLoaiDoanRaNoId":
                            tmp.LoaiDoanRaCoId = tmp.LoaiDoanRaNoId;
                            break;
                        case "colLoaiDoanRaCoId":
                            tmp.LoaiDoanRaNoId = tmp.LoaiDoanRaCoId;
                            break;

                        case "colSoTienNte":
                        case "colTyGia":
                            tmp.SoTien = tmp.SoTienNt * tmp.TyGia;
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
                if(txtNgayChungTu.Text != "")
                txtNgayHachToan.DateTime = txtNgayChungTu.DateTime;
            }

            private void btnInPhieu_Click(object sender, EventArgs e)
            {
                try
                {
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

            private void FrmEditTamUng_KeyDown(object sender, KeyEventArgs e)
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

                if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
                {
                    btnSave_Click(btnSave, null);
                }
            }

        #endregion          
     }
}
