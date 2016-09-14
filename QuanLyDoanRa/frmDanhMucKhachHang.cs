using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.Erp.Core.Domain;
using System.Collections;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Domain;

namespace QuanLyDoanRa
{
    public partial class frmDanhMucKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frmDanhMucKhachHang()
        {
            InitializeComponent();
        }

        public IVnsDmKhachHangService VnsDmKhachHangService;
        private VnsDmKhachHang ObjKhachHang = new VnsDmKhachHang();
        private int PgSize = General.NumberOfPage;         //hien thi 5 row
        public FormUpdate status;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;
        private IList<VnsDmKhachHang> DanhSachKhachHang = new List<VnsDmKhachHang>();
        private FormUpdate InputState;
        private void CalculateTotalPages()
        {
            int rowCount = this.VnsDmKhachHangService.GetCount();
            TotalPage = rowCount / PgSize;
            if (rowCount % PgSize > 0)
                TotalPage += 1;     //tong so trang
        }

        private void BindingData(int CurrentPageIndex)
        {
            //btnHuy.Enabled = false;
            CalculateTotalPages();
            // Hien thi du lieu len gridcontrol
            VnsOrder obj = new VnsOrder(true, "MaKhachHang");
            IList<VnsOrder> orders = new List<VnsOrder>();
            orders.Add(obj);
            txtSoTrang.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();

            DanhSachKhachHang = this.VnsDmKhachHangService.ListLike((CurrentPageIndex - 1) * PgSize, PgSize, null, null, null, null, orders);
            //Guid id = DanhSachKhachHang[0].Id;
            this.grcKhachHang.DataSource = DanhSachKhachHang;

        }

        private void GetObject()
        {
            if (ObjKhachHang == null)
            {
                ObjKhachHang = new VnsDmKhachHang();
            }
            
            ObjKhachHang.DiaChi = txtDiaChi.Text;
            ObjKhachHang.GhiChu1 = txtGhichu.Text;
            ObjKhachHang.MaCTMT = txtMaCTMT.Text;
            ObjKhachHang.MaDvqhns = txtMaDVQHNS.Text;
            ObjKhachHang.MaKhachHang = txtMaKh.Text;
            ObjKhachHang.SoTaiKhoan = txtSoTK.Text;
            ObjKhachHang.TenKhachHang = txtTenKh.Text;
            ObjKhachHang.GhiChu2 = txtNganHang.Text;
            VnsDmKhachHangService.SaveOrUpdate(ObjKhachHang);
            //Guid id = ObjKhachHang.Id;
            Commons.Commons.Message_Information("Lưu dữ liệu thành công");
        }

        private Boolean CheckInput()
        {
            if (txtMaKh.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập mã khách hàng");
                txtMaKh.Focus();
                return false;
            }

            if (txtTenKh.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập tên khách hàng");
                txtTenKh.Focus();
                return false;
            }

            return true;
        }

        private void LamMoi()
        {
            txtMaKh.Focus();
            txtMaKh.Text = "";
            txtTenKh.Text = "";
            txtDiaChi.Text = "";
            txtMaDVQHNS.Text = "";
            txtSoTK.Text = "";
            txtMaCTMT.Text = "";
            txtGhichu.Text = "";
            txtNganHang.Text = "";
            ObjKhachHang = new VnsDmKhachHang();
        }

        private void RefreshForm()
        {
            BindingData(CurrentPageIndex);
        }

        private void SetFocusGrid(Guid DmHtId, int i)
        {
            if (DmHtId == new Guid())
            {
                grvKhachHang.FocusedRowHandle = grvKhachHang.RowCount - 1;
                if (grvKhachHang.RowCount == 1)
                {
                    grvKhachHang_FocusedRowChanged(null, null);
                }
            }
            else
            {
                grvKhachHang.FocusedRowHandle = i;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                LamMoi();
                groupControl1.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnHuy.Enabled = true;
            }
            catch(Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
            RefreshForm();
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
               if (grvKhachHang.RowCount == 0 || grvKhachHang.FocusedRowHandle < 0)
                {
                    Commons.Commons.Message_Warning("Không có bản ghi nào được lựa chọn");
                    return;
                }

                if(Commons.Commons.Message_Confirm("Bạn có chắc chắn muốn xóa?"))
                {
                    VnsDmKhachHangService.Delete((VnsDmKhachHang)grvKhachHang.GetRow(grvKhachHang.FocusedRowHandle));
                
                    grvKhachHang.DeleteSelectedRows(); 
                    //BindingData(CurrentPageIndex);

                    if (grvKhachHang.RowCount > 0)
                    {
                        grvKhachHang.FocusedRowHandle = 0;
                        grvKhachHang_FocusedRowChanged(null, null);
                    }
                    else 
                    {
                        LamMoi();
                    }
                }

            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
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

                Id = ObjKhachHang.Id;
                i = grvKhachHang.FocusedRowHandle;

                GetObject();
                BindingData(CurrentPageIndex);

                SetFocusGrid(Id, i);
                btnHuy.Enabled = false;
                btnThem.Enabled = true;
                groupControl1.Enabled = true;
                btnXoa.Enabled = true;

            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            LamMoi();
            groupControl1.Enabled = true;
        }

        private void frmDanhMucKhachHang_Load(object sender, EventArgs e)
        {
            BindingData(CurrentPageIndex);
        }

        private void grvKhachHang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int rowIndex = grvKhachHang.FocusedRowHandle;
                if (rowIndex < 0)
                {
                    LamMoi();
                    return;
                }
                ObjKhachHang = (VnsDmKhachHang)grvKhachHang.GetRow(rowIndex);
                if (ObjKhachHang != null)
                {
                    txtTenKh.Text = ObjKhachHang.TenKhachHang;
                    txtMaKh.Text = ObjKhachHang.MaKhachHang;
                    txtDiaChi.Text = ObjKhachHang.DiaChi;
                    txtMaDVQHNS.Text = ObjKhachHang.MaDvqhns;
                    txtMaCTMT.Text = ObjKhachHang.MaCTMT;
                    txtGhichu.Text = ObjKhachHang.GhiChu1;
                    txtSoTK.Text = ObjKhachHang.SoTaiKhoan;
                    txtNganHang.Text = ObjKhachHang.GhiChu2;
                }   

            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void frmDanhMucKhachHang_KeyDown(object sender, KeyEventArgs e)
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