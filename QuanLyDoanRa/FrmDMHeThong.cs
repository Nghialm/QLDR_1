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
    public partial class FrmDMHeThong : Form
    {
        

        #region"Variables"
        private VnsDmHeThong ObjHeThong;
        public IVnsDmHeThongService VnsDmHeThongService;

        public FrmDMHeThong()
        {
            InitializeComponent();
        }

        private int PgSize = General.NumberOfPage;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;
        #endregion

        #region"Functions"

        private void TongSoTrang()
        {
            int rowCount = this.VnsDmHeThongService.GetCount();
            TotalPage = rowCount / PgSize;
            if (rowCount % PgSize > 0)
                TotalPage += 1;
        }
        private void BindData(int CurrentPageIndex)
        {
            btnHuy.Enabled = false;
            TongSoTrang();
            // Hien thi du lieu len gridcontrol
            VnsOrder obj = new VnsOrder(true, "Ma");
            IList<VnsOrder> orders = new List<VnsOrder>();
            orders.Add(obj);
            txtTrangHienTai.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
            this.gctHeThong.DataSource = this.VnsDmHeThongService.ListLike((CurrentPageIndex - 1) * PgSize, PgSize, null, null, null, null, orders);
        }

        private void LamMoi()
        {
            ObjHeThong = new VnsDmHeThong();
            txtMa.Focus();
            txtMa.Text = "";
            txtTen.Text = "";
            txtDoiTuong.Text = "";
            txtGiaTri.Text = "";
            txtThuTu.Text = "";
        }

        private void GetObject()
        {
            if (ObjHeThong == null)
            {
                ObjHeThong = new VnsDmHeThong();
            }

            ObjHeThong.Ma = txtMa.Text;
            ObjHeThong.Ten = txtTen.Text;
            ObjHeThong.DoiTuong = txtDoiTuong.Text;
            ObjHeThong.GiaTri = int.Parse(txtGiaTri.Text);
            ObjHeThong.ThuTu = int.Parse(txtThuTu.Text);
            
            VnsDmHeThongService.SaveOrUpdate(ObjHeThong);
            Commons.Commons.Message_Information("Lưu thành công");
        }

        private Boolean CheckInput()
        {

            if (txtMa.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập mã");
                txtMa.Focus();
                return false;
            }

            if (txtTen.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập tên");
                txtTen.Focus();
                return false;
            }

            if (txtDoiTuong.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập đối tượng");
                txtDoiTuong.Focus();
                return false;
            }

            if (txtGiaTri.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập giá trị");
                txtGiaTri.Focus();
                return false;
            }

            if (txtThuTu.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập thứ tự");
                txtThuTu.Focus();
                return false;
            }
            return true;
        }

        private void SetFocusGrid(Guid DmHtId, int i)
        {
            if (DmHtId == new Guid())
            {
                gvHeThong.FocusedRowHandle = gvHeThong.RowCount - 1;
                if (gvHeThong.RowCount == 1)
                {
                    gvHeThong_FocusedRowChanged(null, null);
                }
            }
            else
            {
                gvHeThong.FocusedRowHandle = i;
            }
        }

        #endregion
        // tinh tong so trang


        #region"Events"

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                LamMoi();
                groupControl.Enabled = false;
                btnHuy.Enabled = true;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void txtGiaTri_KeyPress(object sender, KeyPressEventArgs e)
        {
            string ValidChar = "0123456789" + Convert.ToChar(8).ToString();
            if (!ValidChar.Contains(e.KeyChar))
                e.Handled = true;
        }

        private void txtThuTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            string ValidChar = "0123456789" + Convert.ToChar(8).ToString();
            if (!ValidChar.Contains(e.KeyChar))
                e.Handled = true;
        }

        private void FrmDMHeThong_Load(object sender, EventArgs e)
        {
            BindData(CurrentPageIndex);
        }

        private void btnTrangDau_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = 1;
            BindData(CurrentPageIndex);
        }

        private void btnTrangCuoi_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = TotalPage;
            BindData(CurrentPageIndex);
        }

        private void btnTrangSau_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex < this.TotalPage)
            {
                this.CurrentPageIndex++;
                BindData(CurrentPageIndex);
            }
        }

        private void btnTrangTruoc_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex > 1)
            {
                this.CurrentPageIndex--;
                BindData(CurrentPageIndex);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
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
                if (gvHeThong.FocusedRowHandle < 0)
                {
                    Commons.Commons.Message_Information("Không có bản ghi nào được lựa chọn");
                    return;
                }

                if (Commons.Commons.Message_Confirm("Bạn có chắc chắn muốn xóa bản ghi này?"))
                {
                    VnsDmHeThong obj = (VnsDmHeThong)gvHeThong.GetRow(gvHeThong.FocusedRowHandle);
                    gvHeThong.DeleteSelectedRows();
                    this.VnsDmHeThongService.DeleteById(obj.Id);
                    if (gvHeThong.RowCount > 0)
                    {
                        gvHeThong.FocusedRowHandle = 0;
                        gvHeThong_FocusedRowChanged(null, null);
                    }
                    else
                    {
                        LamMoi();
                    }
                    Commons.Commons.Message_Information("Xóa dữ liệu thành công");
                }
            }
            catch(Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                IList likeProps = new ArrayList();
                IList likeValues = new ArrayList();
                if (txtMa.Text.ToString() != "")
                {
                    likeProps.Add("Ma");
                    likeValues.Add("%" + txtMa.Text.ToString() + "%");
                }
                // tim kiem theo dia chi
                if (txtTen.Text.ToString() != "")
                {
                    likeProps.Add("Ten");
                    likeValues.Add("%" + txtTen.Text.ToString() + "%");
                }
                if (txtDoiTuong.Text.ToString() != "")
                {
                    likeProps.Add("DoiTuong");
                    likeValues.Add("%" + txtDoiTuong.Text.ToString() + "%");
                }
                if (txtGiaTri.Text.ToString() != "")
                {
                    likeProps.Add("GiaTri");
                    likeValues.Add("%" + txtGiaTri.Text.ToString() + "%");
                }
                if (txtThuTu.Text.ToString() != "")
                {
                    likeProps.Add("ThuTu");
                    likeValues.Add("%" + txtThuTu.Text.ToString() + "%");
                }
                this.gctHeThong.DataSource = this.VnsDmHeThongService.ListLike(-1, -1, null, null, likeProps, likeValues, null);
                if (gvHeThong.RowCount > 0)
                {
                    MessageBox.Show("Tìm thấy " + gvHeThong.RowCount + " kết quả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnHuy_Click(object sender, EventArgs e)
        {           
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;
            groupControl.Enabled = true;
            //btnHuy.Enabled = true;
            btnThem.Enabled = true;
            LamMoi();
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            BindData(1);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Guid Id = new Guid();
                int i = 0;

                if (!CheckInput())
                    return;
                Id = ObjHeThong.Id;
                i = gvHeThong.FocusedRowHandle;

                GetObject();
                BindData(CurrentPageIndex);

                SetFocusGrid(Id, i);
                btnHuy.Enabled = false;
                btnThem.Enabled = true;
                groupControl.Enabled = true;
                btnXoa.Enabled = true;
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

        private void gvHeThong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvHeThong.FocusedRowHandle < 0)
            {
                //ObjHeThong = null;
                LamMoi();
                return;
            }
            ObjHeThong = (VnsDmHeThong)gvHeThong.GetRow(gvHeThong.FocusedRowHandle);

            if (ObjHeThong == null) return;

            txtMa.EditValue = ObjHeThong.Ma;
            txtTen.EditValue = ObjHeThong.Ten;
            txtThuTu.EditValue = ObjHeThong.ThuTu;
            txtDoiTuong.EditValue = ObjHeThong.DoiTuong;
            txtGiaTri.EditValue = ObjHeThong.GiaTri;
        }

        #endregion

        private void FrmDMHeThong_KeyDown(object sender, KeyEventArgs e)
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
