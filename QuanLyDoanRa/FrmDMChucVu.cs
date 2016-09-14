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
    public partial class FrmDMChucVu : Form
    {
 
        #region"Variables"

        private VnsDanhMucChucVu ObjChucVu;
        public IVnsDanhMucChucVuService VnsDanhMucChucVuService;
        public FrmDMChucVu()
        {
            InitializeComponent();
        }
        public FormUpdate FormStatus;
        private int PgSize = General.NumberOfPage;         //hien thi 5 row
        public FormUpdate status;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;
        IList<VnsDanhMucChucVu> DanhMucChucVu = new List<VnsDanhMucChucVu>();

        #endregion

        #region"Functions"

        private void CalculateTotalPages()
        {
            int rowCount = this.VnsDanhMucChucVuService.GetCount();
            TotalPage = rowCount / PgSize;
            if (rowCount % PgSize > 0)
                TotalPage += 1;     //tong so trang
        }
        private void Search()
        {
            IList likeProps = new ArrayList();
            IList likeValues = new ArrayList();
            if (txtTenChucVu.Text.ToString() != "")
            {
                likeProps.Add("MaNuoc");
                likeValues.Add("%" + txtTenChucVu.Text.ToString() + "%");
            }
            // tim kiem theo dia chi
            if (txtTenChucVu.Text.ToString() != "")
            {
                likeProps.Add("TenChucVu");
                likeValues.Add("%" + txtTenChucVu.Text.ToString() + "%");
            }
            this.gctChucVu.DataSource = null;
            this.gctChucVu.DataSource = this.VnsDanhMucChucVuService.ListLike(-1, -1, null, null, likeProps, likeValues, null);
        }


        private void BindingData(int CurrentPageIndex)
        {
            btnHuy.Enabled = false;
            CalculateTotalPages();
            // Hien thi du lieu len gridcontrol
            VnsOrder obj = new VnsOrder(true, "TenChucVu");
            IList<VnsOrder> orders = new List<VnsOrder>();
            orders.Add(obj);
            txtSoTrang.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
            DanhMucChucVu = this.VnsDanhMucChucVuService.ListLike((CurrentPageIndex - 1) * PgSize, PgSize, null, null, null, null, orders);
            this.gctChucVu.DataSource = DanhMucChucVu;

            //if (FormStatus == FormUpdate.Update)
            //{
            //    btnHuy.Enabled = false;
            //    ObjChucVu = this.VnsDanhMucChucVuService.GetById(ObjChucVu.ChucVuId);
            //    txtTenChucVu.Text = ObjChucVu.TenChucVu.ToString();
            //    txtHeSoA.Text = ObjChucVu.HeSoa.ToString();
            //    txtHeSoB.Text = ObjChucVu.HeSob.ToString();
            //}

        }

        private Boolean CheckInput()
        {
            if (txtTenChucVu.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập tên chức vụ");
                txtTenChucVu.Focus();
                return false;
            }

            if (txtHeSoA.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập Hệ số A");
                txtHeSoA.Focus();
                return false;
            }

            if (txtHeSoB.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập Hệ số B");
                txtHeSoB.Focus();
                return false;
            }

            return true;
        }

        private void LamMoi()
        {
            txtTenChucVu.ResetText();
            txtHeSoA.ResetText();
            txtHeSoB.ResetText();
            txtHeSoA.Text = "0";
            txtHeSoB.Text = "0";
            txtTenChucVu.Focus();
            ObjChucVu = new VnsDanhMucChucVu();
        }

        private void GetObject()
        {
            if (ObjChucVu == null)
            {
                ObjChucVu = new VnsDanhMucChucVu();
            }

            ObjChucVu.TenChucVu = txtTenChucVu.Text;
            ObjChucVu.HeSoa = Convert.ToDouble(txtHeSoA.Text);
            ObjChucVu.HeSob = Convert.ToDouble(txtHeSoB.Text);
            VnsDanhMucChucVuService.SaveOrUpdate(ObjChucVu);

            Commons.Commons.Message_Information("Lưu dữ liệu thành công");
        }

        #endregion

        private void btnThem_Click(object sender, EventArgs e)
        {
          LamMoi();
          groupControl.Enabled = false;
          btnHuy.Enabled = true;
          btnThem.Enabled = false;
          btnXoa.Enabled = false;
        }

        private void FrmDMChucVu_Load(object sender, EventArgs e)
        {
            BindingData(CurrentPageIndex);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            this.btnHuy.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (groupControl.Enabled == false)
                {
                    Commons.Commons.Message_Information("Đang ở chế độ thêm mới");
                    return;
                }

                if (gvDmChucVu.RowCount == 0 || gvDmChucVu.FocusedRowHandle < 0)
                {
                    Commons.Commons.Message_Warning("Không có bản ghi nào được lựa chọn");
                    return;
                }
                
                if (Commons.Commons.Message_Confirm("Bạn có chắc chắn muốn xóa bản ghi này?"))
                {

                    VnsDanhMucChucVuService.DeleteById(((VnsDanhMucChucVu)gvDmChucVu.GetRow(gvDmChucVu.FocusedRowHandle)).ChucVuId);
                    gvDmChucVu.DeleteSelectedRows();
                    gvDmChucVu.RefreshData();
                    Commons.Commons.Message_Information("Xóa dữ liệu thành công");

                }

                if (gvDmChucVu.RowCount > 0)
                {
                    gvDmChucVu.FocusedRowHandle = 0;
                    gvDmChucVu_FocusedRowChanged(null, null);
                }
                else
                {
                    LamMoi();
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void SetFocusGrid(Guid DmHtId, int i)
        {
            if (DmHtId == new Guid())
            {
                gvDmChucVu.FocusedRowHandle = gvDmChucVu.RowCount - 1;
                if (gvDmChucVu.RowCount == 1)
                {
                    gvDmChucVu_FocusedRowChanged(null, null);
                }
            }
            else
            {
                gvDmChucVu.FocusedRowHandle = i;
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
                Id = ObjChucVu.ChucVuId;
                i = gvDmChucVu.FocusedRowHandle;

                GetObject();
                BindingData(CurrentPageIndex);

                SetFocusGrid(Id, i);
                btnHuy.Enabled = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                groupControl.Enabled = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnTatCa.Enabled = true;
            btnTimKiem.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            LamMoi();
            groupControl.Enabled = true;
            //btnHuy.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            BindingData(1);
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

       
        private void gvDmChucVu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvDmChucVu.FocusedRowHandle < 0)
            {
                LamMoi();
                return;                                
            }

            ObjChucVu = (VnsDanhMucChucVu)gvDmChucVu.GetRow(gvDmChucVu.FocusedRowHandle);

            if (ObjChucVu == null) return;

            txtHeSoA.EditValue = ObjChucVu.HeSoa;
            txtHeSoB.EditValue = ObjChucVu.HeSob;
            txtTenChucVu.EditValue = ObjChucVu.TenChucVu;
        }

        private void FrmDMChucVu_KeyDown(object sender, KeyEventArgs e)
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
