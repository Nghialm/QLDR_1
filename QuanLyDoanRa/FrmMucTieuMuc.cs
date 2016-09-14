using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.Erp.Core.Domain;
using System.Collections;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Domain;

namespace QuanLyDoanRa
{
    public partial class FrmMucTieuMuc : Form
    {
        private Vns.QuanLyDoanRa.Domain.VnsDmMucTieuMuc _Muc;

        public Vns.QuanLyDoanRa.Domain.VnsDmMucTieuMuc Muc
        {
            get { return _Muc; }
            set { _Muc = value; }
        }

        private IVnsDmMucTieuMucService _VnsDmMucTieuMucService;

        public IVnsDmMucTieuMucService VnsDmMucTieuMucService
        {
            get { return _VnsDmMucTieuMucService; }
            set { _VnsDmMucTieuMucService = value; }
        }
        public FrmMucTieuMuc()
        {
            InitializeComponent();
        }

        private int PgSize = General.NumberOfPage;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;

        // tinh tong so trang
        private void TongSoTrang()
        {
            int rowCount = this.VnsDmMucTieuMucService.GetCount();
            TotalPage = rowCount / PgSize;
            if (rowCount % PgSize > 0)
                TotalPage += 1;
        }

        IList<VnsDmMucTieuMuc> lstDanhSach = new List<VnsDmMucTieuMuc>();

        private void BindData(int CurrentPageIndex)
        {
            btnHuy.Enabled = false;
            TongSoTrang();
            // Hien thi du lieu len gridcontrol
            VnsOrder obj = new VnsOrder(true, "MaMuc");
            IList<VnsOrder> orders = new List<VnsOrder>();
            orders.Add(obj);
            txtTrangHienTai.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
            //
            lstDanhSach = this.VnsDmMucTieuMucService.ListLike((CurrentPageIndex - 1) * PgSize, PgSize, null, null, null, null, orders);
            this.gctMucTieuMuc.DataSource = lstDanhSach;
            // Do du lieu vao lookUpEdit
            this.lueMucCha.Properties.DataSource = this.VnsDmMucTieuMucService.List(-1, -1, null, null, null);
            this.lueMucCha.Properties.DisplayMember = "TenMuc";
            this.lueMucCha.Properties.ValueMember = "Id";
        }

        private void FrmMucTieuMuc_Load(object sender, EventArgs e)
        {
            BindData(CurrentPageIndex);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.I):
                    btnThem_Click(null, null);
                    break;
                case (Keys.Control | Keys.U):
                    btnSua_Click(null, null);
                    break;
                case (Keys.Control | Keys.D):
                    btnXoa_Click(null, null);
                    break;
              
                case (Keys.Escape):
                    btnClose_Click(null, null);
                    break;
                //case (Keys.Control | Keys.T):
                //    btnTatCa_Click(null, null);
                //    break;
                //case (Keys.Control | Keys.S):
                //    btnTimKiem_Click(null, null);
                //    break;
                case (Keys.Control | Keys.H):
                    btnHuy_Click(null, null);
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ThemGianTiep()
        {
            txtMaMuc.Focus();
            if (txtMaMuc.Text != "")
            {
                Muc = new Vns.QuanLyDoanRa.Domain.VnsDmMucTieuMuc();
                Muc.Id = Guid.NewGuid();
                Muc.MaMuc = txtMaMuc.Text;
                Muc.TenMuc = txtTenMuc.Text;
                if (lueMucCha.EditValue != null)
                {
                    Muc.IdMucCha = new Guid(lueMucCha.EditValue.ToString());
                }
                this.VnsDmMucTieuMucService.SaveOrUpdate(Muc);
                MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);             
                BindData(1);
            }
            else
            {
                MessageBox.Show("Yêu cầu nhập Mã Mục", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // them muc moi
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                LamMoi();
                gctMucTieuMuc.Enabled = false;
                btnSua.Enabled = true;
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }
        private void GetObject()
        {
            if (Muc == null)
            {
                Muc = new VnsDmMucTieuMuc();
            }

            Muc.MaMuc = txtMaMuc.Text;
            Muc.TenMuc = txtTenMuc.Text;
            if (lueMucCha.EditValue != null)
            {
                Muc.IdMucCha = new Guid(lueMucCha.EditValue.ToString());
            }
            if (txtThuTu.Text != "")
                Muc.ThuTu = Int32.Parse(txtThuTu.Text);
            this.VnsDmMucTieuMucService.SaveOrUpdate(Muc);
            Commons.Commons.Message_Information("Lưu thành công");
        }

        private Boolean CheckInput()
        {

            if (txtTenMuc.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập mã");
                txtTenMuc.Focus();
                return false;
            }

            if (txtMaMuc.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập tên");
                txtMaMuc.Focus();
                return false;
            }

            return true;
        }

        private void SetFocusGrid(Guid MucTieuMucId, int i)
        {
            if (MucTieuMucId == new Guid())
            {
                gvMucTieuMuc.FocusedRowHandle = gvMucTieuMuc.RowCount - 1;
                if (gvMucTieuMuc.RowCount == 1)
                {
                    gvMucTieuMuc_FocusedRowChanged(null, null);
                }
            }
            else
            {
                gvMucTieuMuc.FocusedRowHandle = i;
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Guid Id = new Guid();
                int i = 0;
                if (!CheckInput())
                    return;
                Id = Muc.Id;
                i = gvMucTieuMuc.FocusedRowHandle;

                GetObject();
                BindData(CurrentPageIndex);

                SetFocusGrid(Id, i);
                gctMucTieuMuc.Enabled = true;
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvMucTieuMuc.GetFocusedRowCellValue(colMucID).ToString() != "")
                {
                    Muc = new Vns.QuanLyDoanRa.Domain.VnsDmMucTieuMuc();
                    Muc.Id = new Guid(gvMucTieuMuc.GetFocusedRowCellValue(colMucID).ToString());
                    Muc = this.VnsDmMucTieuMucService.GetById(Muc.Id);
                    if (MessageBox.Show("Bạn có đồng ý xóa mục  " + Muc.TenMuc, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.VnsDmMucTieuMucService.DeleteById(Muc.Id);
                        MessageBox.Show("Đã xóa mục " + Muc.TenMuc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindData(1);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa chọn mục cần xóa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra lại hệ thống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Timkiem()
        {
            // cho tim kiem like
            IList likeProps = new ArrayList();
            IList likeValues = new ArrayList();

            // cho tim kiem chinh xac
            IList props = new ArrayList();
            IList values = new ArrayList();
            if (txtMaMuc.Text.ToString() != "")
            {
                likeProps.Add("MaMuc");
                likeValues.Add("%" + txtMaMuc.Text.ToString() + "%");
            }

            if (txtTenMuc.Text.ToString() != "")
            {
                likeProps.Add("TenMuc");
                likeValues.Add("%" + txtTenMuc.Text.ToString() + "%");
            }
            if (lueMucCha.EditValue != null)
            {
                props.Add("IdMucCha");
                values.Add(new Guid(lueMucCha.EditValue.ToString()));
            }
            this.gctMucTieuMuc.DataSource = this.VnsDmMucTieuMucService.ListLike(-1, -1, props, values, likeProps, likeValues, null);
            if (gvMucTieuMuc.RowCount > 0)
            {
                MessageBox.Show("Tìm thấy " + gvMucTieuMuc.RowCount + " kết quả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có kết quả thích hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                Timkiem();
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra lại hệ thống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void LamMoi()
        {
            Muc = new VnsDmMucTieuMuc();
            //Muc.Id = Guid.NewGuid();
            btnHuy.Enabled = true;
            txtMaMuc.Text = "";
            txtTenMuc.Text = "";
            lueMucCha.EditValue = null;
        }
      
        private void btnTrangDau_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = 1;
            BindData(CurrentPageIndex);
        }

        private void btnTrangTruoc_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex > 1)
            {
                this.CurrentPageIndex--;
                BindData(CurrentPageIndex);
            }
        }

        private void btnTrangSau_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex < this.TotalPage)
            {
                this.CurrentPageIndex++;
                BindData(CurrentPageIndex);
            }
        }

        private void btnTrangCuoi_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = TotalPage;
            BindData(CurrentPageIndex);
        }

        // Sua muc duoc lua chon


        private void btnTatCa_Click(object sender, EventArgs e)
        {
            BindData(1);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {   
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            txtMaMuc.Text = "";
            txtTenMuc.Text = "";
            lueMucCha.EditValue = null;            
            gctMucTieuMuc.Enabled = true;            
        }


        private void SetFocus_AfterAddrow()
        {
            gvMucTieuMuc.FocusedRowHandle = this.gvMucTieuMuc.RowCount - 1;
            gvMucTieuMuc.SelectRow(int.Parse(Handle.ToString()));
            try
            {
                gvMucTieuMuc.FocusedColumn = gvMucTieuMuc.VisibleColumns[0];
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ThemDong()
        {
            VnsDmMucTieuMuc obj = new VnsDmMucTieuMuc();
            lstDanhSach.Add(obj);
            gvMucTieuMuc.RefreshData();
        }

        private void XoaDong()
        {
            try
            {
                if (this.gvMucTieuMuc.RowCount >= 1)
                {
                    lstDanhSach.RemoveAt(this.gvMucTieuMuc.RowCount - 1);
                    gvMucTieuMuc.RefreshData();
                }
                else
                {
                    MessageBox.Show("Không có bản ghi nào được chọn");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FrmMucTieuMuc_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
                {
                    btnThem_Click(btnThem, null);
                }
                else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control && btnSua.Enabled==true)
                {
                    btnSua_Click(btnSua, null);
                }
                else if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
                {
                    btnXoa_Click(btnXoa, null);
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void gvMucTieuMuc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    ThemDong();
                    SetFocus_AfterAddrow();
                    break;
                case Keys.F8:
                    XoaDong();
                    SetFocus_AfterAddrow();
                    break;
                case Keys.Enter:
                    if (GridHelper.CheckAddNewRow(gvMucTieuMuc))
                    {
                        ThemDong();
                        SetFocus_AfterAddrow();
                    }
                    break;
            }
        }

        private void gvMucTieuMuc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                LamMoi();
                return;
            }
            VnsDmMucTieuMuc objTemp = (VnsDmMucTieuMuc)gvMucTieuMuc.GetRow(e.FocusedRowHandle);
            Muc = VnsDmMucTieuMucService.GetById(objTemp.Id);
            if (Muc == null) return;

            this.txtMaMuc.EditValue = Muc.MaMuc;
            this.txtTenMuc.EditValue = Muc.TenMuc;
            this.lueMucCha.EditValue = Muc.IdMucCha;
            this.txtThuTu.EditValue = Muc.ThuTu;
        }

    }
}
