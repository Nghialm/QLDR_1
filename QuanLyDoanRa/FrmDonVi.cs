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
using System.Collections;
using Vns.Erp.Core.Domain;

namespace QuanLyDoanRa
{
    public partial class FrmDonVi : Form
    {
        #region "Property Service"
        private VnsDonVi _DonVi;
        public VnsDonVi DonVi
        {
            get { return _DonVi; }
            set { _DonVi = value; }
        }

        private IVnsDonViService _VnsDonViService;
        public IVnsDonViService VnsDonViService
        {
            get { return _VnsDonViService; }
            set { _VnsDonViService = value; }
        }

        private IVnsDmHeThongService _VnsDmHeThongService;
        public IVnsDmHeThongService VnsDmHeThongService
        {
            get { return _VnsDmHeThongService; }
            set { _VnsDmHeThongService = value; }
        }
        #endregion
        public FrmDonVi()
        {
            InitializeComponent();
        }
        public FormUpdate FormStatus;
        private int PgSize = General.NumberOfPage;         //hien thi 5 row
        public FormUpdate status;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;
        IList<VnsDonVi> DanhSachDonVi = new List<VnsDonVi>();

        private void CalculateTotalPages()
        {
            int rowCount = this.VnsDonViService.GetCount();
            TotalPage = rowCount / PgSize;
            if (rowCount % PgSize > 0)
                TotalPage += 1;     //tong so trang
        }
        private void Search()
        {
            IList likeProps = new ArrayList();
            IList likeValues = new ArrayList();
            if (txtTenDonVi.Text.ToString() != "")
            {
                likeProps.Add("TenDonVi");
                likeValues.Add("%" + txtTenDonVi.Text.ToString() + "%");
            }
            // tim kiem theo dia chi
            if (txtMaDonVi.Text.ToString() != "")
            {
                likeProps.Add("MaDonVi");
                likeValues.Add("%" + txtMaDonVi.Text.ToString() + "%");
            }
            this.gctDonVi.DataSource = null;
            this.gctDonVi.DataSource = this.VnsDonViService.ListLike(-1, -1, null, null, likeProps, likeValues, null);
        }

        private void BindDmHeThong()
        {
            IList props = new ArrayList();
            IList values = new ArrayList();
            props.Add("DoiTuong");
            values.Add("CAP_BAC_TV");
            this.cboLoaiDonVi.Properties.DataSource = this.VnsDmHeThongService.List(-1, -1, props, values, null);
            this.cboLoaiDonVi.Properties.DisplayMember = "Ten";
            this.cboLoaiDonVi.Properties.ValueMember = "GiaTri";
        }
        private void BindingData(int CurrentPageIndex)
        {
            btnHuy.Enabled = false;
            CalculateTotalPages();
            // Hien thi du lieu len gridcontrol
            VnsOrder obj = new VnsOrder(true, "TenDonVi");
            IList<VnsOrder> orders = new List<VnsOrder>();
            orders.Add(obj);
            txtSoTrang.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
            DanhSachDonVi = this.VnsDonViService.ListLike((CurrentPageIndex - 1) * PgSize, PgSize, null, null, null, null, orders);
            this.gctDonVi.DataSource = DanhSachDonVi;

            if (FormStatus == FormUpdate.Update)
            {
                btnHuy.Enabled = false;
                DonVi = this.VnsDonViService.GetById(DonVi.DonViId);
                txtTenDonVi.Text = DonVi.TenDonVi.ToString();
                txtMaDonVi.Text = DonVi.MaDonVi.ToString();
                cboLoaiDonVi.EditValue = DonVi.LoaiDonVi;
            }

        }

        private void GetObject()
        {
            if (DonVi == null)
            {
                DonVi = new VnsDonVi();
            }

            DonVi.TenDonVi = txtTenDonVi.Text.ToString();
            DonVi.MaDonVi = txtMaDonVi.Text.ToString();
            DonVi.LoaiDonVi = (int)cboLoaiDonVi.EditValue;
            VnsDonViService.SaveOrUpdate(DonVi);
        }

        private void LamMoi()
        {
            txtTenDonVi.ResetText();
            txtMaDonVi.ResetText();
            cboLoaiDonVi.EditValue = null;
            DonVi = new VnsDonVi();
            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaDonVi.Focus();
            LamMoi();
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            groupControl2.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            BindingData(CurrentPageIndex);
            this.btnHuy.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (groupControl1.Enabled == false)
                {
                    Commons.Commons.Message_Warning("Đang ở chế độ thêm mới");
                    return;
                } 

                if(gvDonVi.RowCount ==0 || gvDonVi.FocusedRowHandle <0)
                {
                    Commons.Commons.Message_Warning("Không có bản ghi nào được lựa chọn");
                    return;
                } 
                VnsDonVi obj =(VnsDonVi)gvDonVi.GetRow(gvDonVi.FocusedRowHandle);

                if (Commons.Commons.Message_Confirm("Bạn có chắc chắn muốn xóa bản ghi này?"))
                {
                    this.VnsDonViService.DeleteById(obj.DonViId);
                    gvDonVi.DeleteSelectedRows();
                    gvDonVi.RefreshData();
                    //Commons.Commons.Message_Information("Xóa dữ liệu thành công");
                }

                if (gvDonVi.RowCount > 0)
                {
                    gvDonVi.FocusedRowHandle = 0;
                    gvDonVi_FocusedRowChanged(null, null);
                }
                else
                {
                    LamMoi();
                }
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra lại hệ thống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Boolean CheckInput()
        {
            if (txtTenDonVi.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập tên đơn vị");
                txtTenDonVi.Focus();
                return false;
            }

            if (txtMaDonVi.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập mã đơn vị");
                txtMaDonVi.Focus();
                return false;
            }

            if (cboLoaiDonVi.EditValue == null)
            {
                Commons.Commons.Message_Warning("Bạn chưa chọn loại đơn vị");
                cboLoaiDonVi.Focus();
                return false;
            }
            return true;
        }

        private void SetFocusGrid(Guid DmHtId, int i)
        {
            if (DmHtId == new Guid())
            {
                gvDonVi.FocusedRowHandle = gvDonVi.RowCount - 1;
                if (gvDonVi.RowCount == 1)
                {
                    gvDonVi_FocusedRowChanged(null, null);
                }
            }
            else
            {
                gvDonVi.FocusedRowHandle = i;
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
                Id = DonVi.DonViId;
                i = gvDonVi.FocusedRowHandle;

                GetObject();
                BindingData(CurrentPageIndex);

                SetFocusGrid(Id, i);
                btnHuy.Enabled = false;
                btnThem.Enabled = true;
                groupControl2.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int LuuDonVi()
        {
            DonVi = new Vns.QuanLyDoanRa.Domain.VnsDonVi();
            DonVi.DonViId = (Guid)gvDonVi.GetFocusedRowCellValue(colDonViId);
            DonVi.TenDonVi = txtTenDonVi.Text.ToString();
            DonVi.MaDonVi = txtMaDonVi.Text.ToString();
            if (cboLoaiDonVi.EditValue != null)
            {
                DonVi.LoaiDonVi = (int)cboLoaiDonVi.EditValue;
            }

            if (FormStatus == FormUpdate.Update)
                VnsDonViService.Merge(DonVi);
            else
                VnsDonViService.SaveOrUpdate(DonVi);
            return 1;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {          
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            txtTenDonVi.Text = "";
            txtMaDonVi.Text = "";
            cboLoaiDonVi.EditValue = null;
            groupControl2.Enabled = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            BindingData(1);
        }

        private void FrmDonVi_Load(object sender, EventArgs e)
        {
            BindDmHeThong();
            BindingData(CurrentPageIndex);
        }

        private void gctDonVi_Click(object sender, EventArgs e)
        {
            int count = this.VnsDonViService.GetCount();
            if (count > 0)
            {
                this.txtTenDonVi.Text = gvDonVi.GetFocusedRowCellValue(colTenDonVi).ToString();
                this.txtMaDonVi.Text = gvDonVi.GetFocusedRowCellValue(colMaDonVi).ToString();
                this.cboLoaiDonVi.EditValue = (int)gvDonVi.GetFocusedRowCellValue(colLoaiDonVi);
            }
            else
            {
                MessageBox.Show("Không Có Dữ Liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTrangDau_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = 1;
            BindingData(CurrentPageIndex);
        }

        private void btnTrangTruoc_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex > 1)
            {
                this.CurrentPageIndex--;
                BindingData(CurrentPageIndex);
            }
        }

        private void btnTrangSau_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex < this.TotalPage)
            {
                this.CurrentPageIndex++;
                BindingData(CurrentPageIndex);
            }
        }

        private void btnTrangCuoi_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = TotalPage;
            BindingData(CurrentPageIndex);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDonVi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvDonVi.FocusedRowHandle < 0)
            {
                LamMoi();
                return;
                
            }
            DonVi = (VnsDonVi)gvDonVi.GetRow(gvDonVi.FocusedRowHandle);

            if (DonVi == null) return;

            this.txtTenDonVi.EditValue = DonVi.TenDonVi;
            this.txtMaDonVi.EditValue = DonVi.MaDonVi;
            this.cboLoaiDonVi.EditValue = DonVi.LoaiDonVi;
        }

        private void FrmDonVi_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
                {
                    btnThem_Click(btnThem, null);
                }
                else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
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

    }
}
