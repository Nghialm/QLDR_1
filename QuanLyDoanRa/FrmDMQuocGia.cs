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
    public partial class FrmDMQuocGia : Form
    {
        private IVnsDmHeThongService _VnsDmHeThongService;
        public IVnsDmHeThongService VnsDmHeThongService
        {
            get { return _VnsDmHeThongService; }
            set { _VnsDmHeThongService = value; }
        }

        private VnsDmQuocGia _QuocGia;
        public VnsDmQuocGia QuocGia
        {
            get { return _QuocGia; }
            set { _QuocGia = value; }
        }

        private IVnsDmQuocGiaService _VnsDmQuocGiaService;
        public IVnsDmQuocGiaService VnsDmQuocGiaService 
        {
            get { return _VnsDmQuocGiaService; }
            set { _VnsDmQuocGiaService = value; }
        }

        private int PgSize = General.NumberOfPage;         //hien thi 5 row
        public FormUpdate status;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;
        public FrmDMQuocGia()
        {
            InitializeComponent();
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
                case (Keys.Control | Keys.R):
                    btnLamMoi_Click(null, null);
                    break;
                case (Keys.Control | Keys.C):
                    btnClose_Click(null, null);
                    break;
                case (Keys.Control | Keys.T):
                    btnTatCa_Click(null, null);
                    break;
                //case (Keys.Control | Keys.S):
                //    btnTimKiem_Click_1(null, null);
                //    break;
                //case (Keys.Control | Keys.H):
                //    btnHuy_Click(null, null);
                //    break;
                case ( Keys.Escape):
                    btnClose_Click(null, null);
                    break;  
            }
            return base.ProcessCmdKey(ref msg, keyData);
        } 
       
        private void Search()
        {
            IList likeProps = new ArrayList();
            IList likeValues = new ArrayList();
            if (txtMaNuoc.Text.ToString() != "")
            {
                likeProps.Add("MaNuoc");
                likeValues.Add("%" + txtMaNuoc.Text.ToString() + "%");
            }
            // tim kiem theo dia chi
            if (txtTenNuoc.Text.ToString() != "")
            {
                likeProps.Add("TenNuoc");
                likeValues.Add("%" + txtTenNuoc.Text.ToString() + "%");
            }
            this.gctQuocGia.DataSource = null;
            this.gctQuocGia.DataSource = this.VnsDmQuocGiaService.ListLike(-1, -1, null, null, likeProps, likeValues, null);
        }

        IList<VnsDmQuocGia> DanhSachQuocGia = new List<VnsDmQuocGia>();
        IList<VnsDmHeThong> DanhSachHeThong = new List<VnsDmHeThong>();

        private void BindingData(int CurrentPageIndex)
        {
            btnHuy.Enabled = false;
            CalculateTotalPages();
            // Hien thi du lieu len gridcontrol
            VnsOrder obj = new VnsOrder(true, "MaNuoc");
            IList<VnsOrder> orders = new List<VnsOrder>();
            orders.Add(obj);
            txtSoTrang.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();

            DanhSachQuocGia = this.VnsDmQuocGiaService.ListLike((CurrentPageIndex - 1) * PgSize, PgSize, null, null, null, null, orders);
            this.gctQuocGia.DataSource = DanhSachQuocGia;
            
        }
        private void BindDmHeThong()
        {
            // Do du lieu vao lookUpEdit
            //int[] phanloai = new int[] { 1, 2, 3 };
            //this.luePhanLoai.Properties.DataSource = phanloai;
            IList props = new ArrayList();
            IList values = new ArrayList();
            props.Add("DoiTuong");
            values.Add("CAP_BAC_QG");
            this.luePhanLoai.Properties.DataSource = this.VnsDmHeThongService.List(-1, -1, props, values, null);
            this.luePhanLoai.Properties.DisplayMember = "Ten";
            this.luePhanLoai.Properties.ValueMember = "GiaTri";
        }
        private void CalculateTotalPages()
        {
            int rowCount = this.VnsDmQuocGiaService.GetCount();
            TotalPage = rowCount / PgSize;
            if (rowCount % PgSize > 0)
                TotalPage += 1;     //tong so trang
        }

        private void btnThem_Click(object sender, EventArgs e)
        {   
            try
            {
               LamMoi();
               btnHuy.Enabled = true;
               btnXoa.Enabled = false;
               
               gctQuocGia.Enabled = false;

            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }
        private void FrmDMQuocGia_Load(object sender, EventArgs e)
        {
            BindDmHeThong();
            BindingData(CurrentPageIndex);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvQuocGia.GetFocusedRowCellValue(colNuocId).ToString() != "")
                {
                    QuocGia = new Vns.QuanLyDoanRa.Domain.VnsDmQuocGia();
                    QuocGia.Id = new Guid(gvQuocGia.GetFocusedRowCellValue(colNuocId).ToString());
                    QuocGia = this.VnsDmQuocGiaService.GetById(QuocGia.Id);
                    if (MessageBox.Show("Bạn có đồng ý xóa mục  " + QuocGia.TenNuoc, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.VnsDmQuocGiaService.DeleteById(QuocGia.Id);
                        MessageBox.Show("Đã xóa mục " + QuocGia.TenNuoc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindingData(1);
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



        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            QuocGia = new VnsDmQuocGia();
            QuocGia.NuocId = Guid.NewGuid();
            this.txtMaNuoc.Text = "";
            this.txtTenNuoc.Text = "";
            luePhanLoai.EditValue = "";
            this.txtMaNuoc.Focus();          
        }

        private Boolean CheckInput()
        {

            if (txtMaNuoc.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập mã");
                txtMaNuoc.Focus();
                return false;
            }

            if (txtTenNuoc.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập tên");
                txtTenNuoc.Focus();
                return false;
            }

            if (luePhanLoai.EditValue == null)
            {
                Commons.Commons.Message_Warning("Bạn chưa chọn nhóm nước");
                luePhanLoai.Focus();
                return false;
            }
            return true;
        }

        private void SetFocusGrid(Guid DmQuocGiaId, int i)
        {
            if (DmQuocGiaId == new Guid())
            {
                gvQuocGia.FocusedRowHandle = gvQuocGia.RowCount - 1;
                if (gvQuocGia.RowCount == 1)
                {
                    gvQuocGia_FocusedRowChanged(null, null);
                }
            }
            else
            {
                gvQuocGia.FocusedRowHandle = i;
            }
        }
        private void gctQuocGia_Click(object sender, EventArgs e)
        {
            int count = this.VnsDmQuocGiaService.GetCount();
            if (count > 0)
            {
                this.txtMaNuoc.Text = gvQuocGia.GetFocusedRowCellValue(colMaNuoc).ToString();
                this.txtTenNuoc.Text = gvQuocGia.GetFocusedRowCellValue(colTenNuoc).ToString();
                luePhanLoai.EditValue = Int32.Parse(gvQuocGia.GetFocusedRowCellValue(colPhanLoai).ToString());
            }
            else
            {
                MessageBox.Show("Không Có Dữ Liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            Search();

            int Count = this.gvQuocGia.RowCount;
            if (Count > 0)
            {
                MessageBox.Show("Tìm Kiếm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tìm Kiếm Thất Bại ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            BindingData(1); 
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //btnTatCa.Enabled = true;
            //btnTimKiem.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            
            txtMaNuoc.Text = "";
            txtTenNuoc.Text = "";            
            gctQuocGia.Enabled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gctQuocGia.ShowPrintPreview();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Guid Id = new Guid() ;
                int i = 0;

                if (!CheckInput())
                    return;
                Id = QuocGia.NuocId;
                i = gvQuocGia.FocusedRowHandle;

                GetObject();
                BindingData(CurrentPageIndex);

                SetFocusGrid(Id, i);
                gctQuocGia.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }


        private void FrmDMQuocGia_KeyDown(object sender, KeyEventArgs e)
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
        
        //for (int i = 0; i < gvLichCongTac.RowCount; i++)
        //            {
        //                LichCongTac = new Vns.QuanLyDoanRa.Domain.VnsLichCongTac();
        //                LichCongTac.Id = new Guid();
        //                LichCongTac.CongTacId = _doanra.Id;
        //                LichCongTac.NuocId = (Guid)gvLichCongTac.GetRowCellValue(i, colNuocDen);
        //                LichCongTac.DiaDiem = gvLichCongTac.GetRowCellValue(i, colDiaDiem).ToString();
        //                LichCongTac.TrangThai = (int)gvLichCongTac.GetRowCellValue(i, colTrangThai);
        //                LichCongTac.MoTa = gvLichCongTac.GetRowCellValue(i, colMoTa).ToString();
        //                LichCongTac.NgayDi = (DateTime)gvLichCongTac.GetRowCellValue(i, colNgayDi);
        //                LichCongTac.NgayVe = (DateTime)gvLichCongTac.GetRowCellValue(i, colNgayVe);
        //                this.VnsLichCongTacService.SaveOrUpdate(LichCongTac);
        //            }
        private void ThemDong()
        {
            VnsDmQuocGia obj = new VnsDmQuocGia();
            DanhSachQuocGia.Add(obj);
            gvQuocGia.RefreshData();
        }
        private void XoaDong()
        {
            DanhSachQuocGia.RemoveAt(this.gvQuocGia.RowCount - 1);
            SetFocus_AfterAddRow();
            gvQuocGia.RefreshData();
        }

        private void SetFocus_AfterAddRow()
        {
            
            gvQuocGia.FocusedRowHandle = this.gvQuocGia.RowCount - 1;
            gvQuocGia.SelectRow(int.Parse(Handle.ToString()));
            try
            {
                gvQuocGia.FocusedColumn = gvQuocGia.VisibleColumns[0];
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void gctQuocGia_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void gvQuocGia_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    
                        ThemDong();
                        SetFocus_AfterAddRow();
                    
                    break;
                //case Keys.Enter:
                //    if (GridHelper.CheckAddNewRow(gvQuocGia))
                //    {
                //        ThemDong();
                //        SetFocus_AfterAddRow();
                //    }
                //    break;
                case Keys.F8:
                    
                        XoaDong();
                        SetFocus_AfterAddRow();
                    
                    break;
            }
        }
        private void GetObject()
        {
            if (QuocGia == null)
            {
                QuocGia = new Vns.QuanLyDoanRa.Domain.VnsDmQuocGia();
                
            }
            QuocGia.MaNuoc = txtMaNuoc.Text;
            QuocGia.TenNuoc = txtTenNuoc.Text;
            if (luePhanLoai.EditValue != null)
            {
                QuocGia.PhanLoai = (int)luePhanLoai.EditValue;
            }
            this.VnsDmQuocGiaService.SaveOrUpdate(QuocGia);
            Commons.Commons.Message_Information("Lưu thành công");
        }

        private void gvQuocGia_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle <0)
            {
                LamMoi();
                return;
            }
            VnsDmQuocGia objTemp = (VnsDmQuocGia)gvQuocGia.GetRow(e.FocusedRowHandle);
             QuocGia = VnsDmQuocGiaService.GetById(objTemp.Id);            
             this.txtMaNuoc.EditValue = QuocGia.MaNuoc;
             this.txtTenNuoc.EditValue = QuocGia.TenNuoc;
             this.luePhanLoai.EditValue = QuocGia.PhanLoai;
        }
    }
}
