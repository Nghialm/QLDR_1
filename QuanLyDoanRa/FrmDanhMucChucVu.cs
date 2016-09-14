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
    public partial class FrmDanhMucChucVu : Form
    {
        VnsDanhMucChucVu _objChucVu = null;
        public VnsDanhMucChucVu ObjChucVu
        {
            get { return _objChucVu; }
            set { _objChucVu = value; }
        }
        IVnsDanhMucChucVuService _VnsDanhMucChucVuService;

        public IVnsDanhMucChucVuService VnsDanhMucChucVuService
        {
            get { return _VnsDanhMucChucVuService; }
            set { _VnsDanhMucChucVuService = value; }
        }
        private int PgSize = General.NumberOfPage;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;

        // tinh tong so trang
        private void TongSoTrang()
        {
            int rowCount = this.VnsDanhMucChucVuService.GetCount();
            TotalPage = rowCount / PgSize;
            if (rowCount % PgSize > 0)
                TotalPage += 1;
        }

        public FrmDanhMucChucVu()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                case (Keys.Escape):
                    btnClose_Click(null, null);
                    break;
                case (Keys.Control | Keys.T):
                    btnTatCa_Click(null, null);
                    break;
                case (Keys.Control | Keys.S):
                    btnTimKiem_Click(null, null);
                    break;
                case (Keys.Control | Keys.H):
                    btnHuy_Click(null, null);
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BindData(int CurrentPageIndex)
        {
           // btnHuy.Enabled = false;
            TongSoTrang();
            // Hien thi du lieu len gridcontrol
            VnsOrder obj = new VnsOrder(true, "TenChucVu");
            IList<VnsOrder> orders = new List<VnsOrder>();
            orders.Add(obj);
            txtTrangHienTai.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
            this.gtcDanhMucChucVu.DataSource = this.VnsDanhMucChucVuService.ListLike((CurrentPageIndex - 1) * PgSize, PgSize, null, null, null, null, orders);
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaLoaiDoanRa.Text != "")
                {
                    this.ObjChucVu = new VnsDanhMucChucVu();
                    this.ObjChucVu.Id = Guid.NewGuid();
                    this.ObjChucVu.TenChucVu = txtMaLoaiDoanRa.Text;
                    //this.ObjChucVu.HeSoa = txtTenLoaiDoanRa.Text;
                    this.VnsDanhMucChucVuService.SaveOrUpdate(this.ObjChucVu);
                    MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(null, null);
                    BindData(1);
                }
                else
                {
                    MessageBox.Show("Yêu cầu nhập tên chức vụ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaLoaiDoanRa.ResetText();
            txtTenLoaiDoanRa.ResetText();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvChucVu.GetFocusedRowCellValue(colChucVuId).ToString() != "")
                {
                    this.ObjChucVu = new VnsDanhMucChucVu();
                    this.ObjChucVu.Id = new Guid(gvChucVu.GetFocusedRowCellValue(colChucVuId).ToString());
                    this.ObjChucVu = this.VnsDanhMucChucVuService.GetById(this.ObjChucVu.Id);
                    if (MessageBox.Show("Bạn có đồng ý xóa chức vụ: " + this.ObjChucVu.TenChucVu, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.VnsDanhMucChucVuService.DeleteById(this.ObjChucVu.Id);
                        MessageBox.Show("Đã xóa mục " + this.ObjChucVu.TenChucVu, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindData(1);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa chọn loại đoàn ra cần xóa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra lại hệ thống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSua.Text == "Sửa")
                {
                    if (gvChucVu.GetFocusedRowCellValue(colChucVuId).ToString() != "")
                    {
                        btnTatCa.Enabled = false;
                        btnTimKiem.Enabled = false;
                        btnThem.Enabled = false;
                        btnXoa.Enabled = false;
                        btnHuy.Enabled = true;
                        btnSua.Text = "Lưu";
                        this.ObjChucVu = new VnsDanhMucChucVu();
                        Guid guidId = new Guid(gvChucVu.GetFocusedRowCellValue(colChucVuId).ToString());
                        this.ObjChucVu = this.VnsDanhMucChucVuService.GetById(guidId);
                        txtMaLoaiDoanRa.Text = this.ObjChucVu.TenChucVu;
                        txtTenLoaiDoanRa.Text = this.ObjChucVu.HeSoa.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn loại đoàn ra cần sửa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (btnSua.Text == "Lưu")
                {
                    if (txtMaLoaiDoanRa.Text != "")
                    {
                        this.ObjChucVu.TenChucVu = txtMaLoaiDoanRa.Text;
                        this.ObjChucVu.HeSoa = double.Parse(txtTenLoaiDoanRa.Text);
                        this.VnsDanhMucChucVuService.SaveOrUpdate(this.ObjChucVu);
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnTatCa.Enabled = true;
                        btnTimKiem.Enabled = true;
                        btnThem.Enabled = true;
                        btnXoa.Enabled = true;
                      //  btnHuy.Enabled = false;
                        btnSua.Text = "Sửa";
                        btnLamMoi_Click(null, null);
                        BindData(1);
                    }
                    else
                    {
                        MessageBox.Show("Yêu cầu nhập Mã loại đoàn ra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra lại hệ thống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaLoaiDoanRa.ResetText();
            txtTenLoaiDoanRa.ResetText();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                IList likeProps = new ArrayList();
                IList likeValues = new ArrayList();
                if (txtMaLoaiDoanRa.Text.ToString() != "")
                {
                    likeProps.Add("TenChucVu");
                    likeValues.Add("%" + txtMaLoaiDoanRa.Text.ToString() + "%");
                }
               
                this.gtcDanhMucChucVu.DataSource = this.VnsDanhMucChucVuService.ListLike(-1, -1, null, null, likeProps, likeValues, null);
                if (gvChucVu.RowCount > 0)
                {
                    MessageBox.Show("Tìm thấy " + gvChucVu.RowCount + " kết quả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có kết quả thích hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra lại hệ thống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {

        }

        private void FrmDanhMucChucVu_Load(object sender, EventArgs e)
        {
            BindData(CurrentPageIndex);
        }

        private void gvChucVu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle <= 0) return;
            VnsDanhMucChucVu objTemp = (VnsDanhMucChucVu)gvChucVu.GetRow(e.FocusedRowHandle);
            VnsDanhMucChucVu ChucVu = VnsDanhMucChucVuService.GetById(objTemp.Id);
            if (ChucVu == null) return;

            this.txtTenLoaiDoanRa.EditValue = ObjChucVu.TenChucVu;
            
        }
    }
}
