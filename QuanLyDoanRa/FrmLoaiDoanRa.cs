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
using Vns.QuanLyDoanRa.Domain;

namespace QuanLyDoanRa
{
    public partial class FrmLoaiDoanRa : Form
    {

        #region"Variables"
        public IVnsLoaiDoanRaService VnsLoaiDoanRaService;

        private VnsLoaiDoanRa ObjLoaiDoanRa;
        private int PgSize = General.NumberOfPage;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;

        public FrmLoaiDoanRa()
        {
            InitializeComponent();
        }

        #endregion
        
        #region"Functions"

        // tinh tong so trang
        private void TongSoTrang()
        {
            int rowCount = this.VnsLoaiDoanRaService.GetCount();
            TotalPage = rowCount / PgSize;
            if (rowCount % PgSize > 0)
                TotalPage += 1;
        }

        private void BindData(int CurrentPageIndex)
        {
            btnHuy.Enabled = false;
            TongSoTrang();
            // Hien thi du lieu len gridcontrol
            VnsOrder obj = new VnsOrder(true, "MaLoaiDoanRa");
            IList<VnsOrder> orders = new List<VnsOrder>();
            orders.Add(obj);
            txtTrangHienTai.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
            this.gctLoaiDoanRa.DataSource = this.VnsLoaiDoanRaService.ListLike((CurrentPageIndex - 1) * PgSize, PgSize, null, null, null, null, orders);
        }

        private void LamMoi()
        {
            txtMaLoaiDoanRa.ResetText();
            txtTenLoaiDoanRa.ResetText();
            txtMaLoaiDoanRa.Focus();

            ObjLoaiDoanRa = new VnsLoaiDoanRa();
        }

        private Boolean CheckInput()
        {
            if (txtMaLoaiDoanRa.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập mã loại đoàn ra");
                txtMaLoaiDoanRa.Focus();
                return false;
            }

            if (txtTenLoaiDoanRa.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập tên loại đoàn ra");
                txtTenLoaiDoanRa.Focus();
                return false;
            }

            return true;
        }

        private void GetObject()
        { 
            if(ObjLoaiDoanRa ==null)
            {
                ObjLoaiDoanRa = new VnsLoaiDoanRa();
            }
            ObjLoaiDoanRa.MaLoaiDoanRa = txtMaLoaiDoanRa.Text;
            ObjLoaiDoanRa.TenLoaiDoanRa = txtTenLoaiDoanRa.Text;
            VnsLoaiDoanRaService.SaveOrUpdate(ObjLoaiDoanRa);
            Commons.Commons.Message_Information("Lưu dữ liệu thành công");
        }

        private void SetFocusGrid(Guid Id, int i)
        {
            if (Id == new Guid())
            {
                gvLoaiDoanRa.FocusedRowHandle = gvLoaiDoanRa.RowCount - 1;
                if (gvLoaiDoanRa.RowCount == 1)
                {
                    gvLoaiDoanRa_FocusedRowChanged(null, null);
                }
            }
            else
            {
                gvLoaiDoanRa.FocusedRowHandle = i;
            }
        }


        #endregion

        #region"Functions"

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
               LamMoi();
               groupboxloaidoanra.Enabled = false;
               btnHuy.Enabled = true;
               btnThem.Enabled = false;
               btnXoa.Enabled = false;
            }
            catch(Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void FrmLoaiDoanRa_Load(object sender, EventArgs e)
        {
            BindData(CurrentPageIndex);
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnTatCa.Enabled = true;
            btnTimKiem.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            LamMoi();

            groupboxloaidoanra.Enabled = true;
            btnHuy.Enabled = false ;
            btnThem.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (groupboxloaidoanra.Enabled == false)
                {
                    Commons.Commons.Message_Information("Đang ở chế độ thêm mới");
                    return;
                }

                if (Commons.Commons.Message_Confirm("Bạn có chắc chắn muốn xóa bản ghi này?"))
                {
                    VnsLoaiDoanRa obj =(VnsLoaiDoanRa)gvLoaiDoanRa.GetRow(gvLoaiDoanRa.FocusedRowHandle);
                    gvLoaiDoanRa.DeleteSelectedRows();
                    VnsLoaiDoanRaService.DeleteById(ObjLoaiDoanRa.Id);
                    Commons.Commons.Message_Information("Xóa dữ liệu thành công");

                    if (gvLoaiDoanRa.RowCount > 0)
                    {
                        gvLoaiDoanRa.FocusedRowHandle = 0;
                        gvLoaiDoanRa_FocusedRowChanged(null, null);
                    }
                    else
                    {
                        LamMoi();
                    }

                }
            }
            catch(Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckInput())
                    return;

                Guid id = ObjLoaiDoanRa.Id;
                int i = gvLoaiDoanRa.FocusedRowHandle;

                GetObject();

                SetFocusGrid(id, i);

                BindData(CurrentPageIndex);

                btnHuy.Enabled = false;
                btnThem.Enabled = true;
                groupboxloaidoanra.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            BindData(1);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                IList likeProps = new ArrayList();
                IList likeValues = new ArrayList();
                if (txtMaLoaiDoanRa.Text.ToString() != "")
                {
                    likeProps.Add("MaLoaiDoanRa");
                    likeValues.Add("%" + txtMaLoaiDoanRa.Text.ToString() + "%");
                }
                // tim kiem theo dia chi
                if (txtTenLoaiDoanRa.Text.ToString() != "")
                {
                    likeProps.Add("TenLoaiDoanRa");
                    likeValues.Add("%" + txtTenLoaiDoanRa.Text.ToString() + "%");
                }
                this.gctLoaiDoanRa.DataSource = this.VnsLoaiDoanRaService.ListLike(-1, -1, null, null, likeProps, likeValues, null);
                if (gvLoaiDoanRa.RowCount > 0)
                {
                    Commons.Commons.Message_Information("Tìm thấy " + gvLoaiDoanRa.RowCount + " kết quả");
                }
                else
                {
                    Commons.Commons.Message_Information("Không có kết quả thích hợp");
                }
            }
            catch(Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void gvLoaiDoanRa_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int i = gvLoaiDoanRa.FocusedRowHandle;
                if (i < 0)
                {
                    btnLamMoi_Click(null, null);
                    return;
                }

                ObjLoaiDoanRa = (VnsLoaiDoanRa)gvLoaiDoanRa.GetRow(i);
                if (ObjLoaiDoanRa != null)
                {
                    txtMaLoaiDoanRa.Text = ObjLoaiDoanRa.MaLoaiDoanRa;
                    txtTenLoaiDoanRa.Text = ObjLoaiDoanRa.TenLoaiDoanRa;
                }

            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        #endregion

        private void FrmLoaiDoanRa_KeyDown(object sender, KeyEventArgs e)
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
