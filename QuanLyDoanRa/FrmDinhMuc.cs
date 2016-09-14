using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.Erp.Core;
using NHibernate.Mapping;
using Vns.QuanLyDoanRa.Domain;
using System.Collections;
using Vns.Erp.Core.Domain;
using System;
using System.Collections.Generic;

namespace QuanLyDoanRa
{
    public partial class FrmDinhMuc : Form
    {
        private Vns.QuanLyDoanRa.Domain.VnsDmHeThong _HeThong;

        public Vns.QuanLyDoanRa.Domain.VnsDmHeThong HeThong
        {
            get { return _HeThong; }
            set { _HeThong = value; }
        }
        private IVnsDmHeThongService _VnsDmHeThongService;

        public IVnsDmHeThongService VnsDmHeThongService
        {
            get { return _VnsDmHeThongService; }
            set { _VnsDmHeThongService = value; }
        }
        private Vns.QuanLyDoanRa.Domain.VnsDinhMuc _DinhMuc;
        public Vns.QuanLyDoanRa.Domain.VnsDinhMuc DinhMuc
        {
            get { return _DinhMuc; }
            set { _DinhMuc = value; }
        }
        private IVnsDinhMucService _VnsDinhMucService;
        public IVnsDinhMucService VnsDinhMucService
        {
            get { return _VnsDinhMucService; }
            set { _VnsDinhMucService = value; }
        }

        private Vns.QuanLyDoanRa.Domain.VnsDmQuocGia _QuocGia;
        public Vns.QuanLyDoanRa.Domain.VnsDmQuocGia QuocGia
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

        private IVnsDmMucTieuMucService _VnsDmMucTieuMucService;
        public IVnsDmMucTieuMucService VnsDmMucTieuMucService
        {
            get { return _VnsDmMucTieuMucService; }
            set { _VnsDmMucTieuMucService = value; }
        }

        IList<VnsDmDinhMucTemp> lstDataSource = null;
        public FrmDinhMuc()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.I):
                    btnThemMoi_Click(null, null);
                    break;
                case (Keys.Control | Keys.U):
                    btnSua_Click(null, null);
                    break;
                case (Keys.Control | Keys.D):
                    btnXoa_Click(null, null);
                    break;
                case (Keys.Control | Keys.R):
                    btnReset_Click(null, null);
                    break;
                case (Keys.Control | Keys.C):
                    btnClose_Click(null, null);
                    break;
                //case (Keys.Control | Keys.T):
                  //  btnTatCa_Click(null, null);
                    //break;
               // case (Keys.Control | Keys.S):
                    //btnTimKiem_Click(null, null);
                 //   break;
                case (Keys.Control | Keys.H):
                    btnHuy_Click(null, null);
                    break;
                case (Keys.Escape):
                    btnClose_Click(null, null);
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        } 
        private int PgSize = General.NumberOfPage;         //hien thi 5 row
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;

        private void LamMoi()
        {
            DinhMuc = new VnsDinhMuc();
            //Muc.Id = Guid.NewGuid();
            btnHuy.Enabled = true;
           // dtNgayApdung.EditValue = DateTime.Now;
            txtDinhMuc.Text = "";
            lueMucId.EditValue = null;
        }

        private void GetObject()
        {
            if (DinhMuc == null)
            {
                DinhMuc = new VnsDinhMuc();
            }
            DinhMuc.NgayApDung = dtNgayApdung.DateTime;
            if (lueNhomNuoc.EditValue != null)
            {
                DinhMuc.NhomNuoc = (Convert.ToInt32(lueNhomNuoc.EditValue));
            }
            DinhMuc.LoaiCapVu = Convert.ToInt32(lueLoaiCapVu.EditValue);
            if (lueMucId.EditValue != null)
            {
                DinhMuc.MucId = new Guid(lueMucId.EditValue.ToString());
                VnsDmMucTieuMuc objTempMuc = this.VnsDmMucTieuMucService.GetById(DinhMuc.MucId);
                if (objTempMuc != null)
                    DinhMuc.ThuTu = objTempMuc.ThuTu;
            }
            DinhMuc.DinhMuc = Convert.ToDecimal(txtDinhMuc.Text);
            if (lueNuocId.EditValue != null)
            {
                DinhMuc.NuocId = lueNuocId.EditValue.ToString();
            }
            DinhMuc.DienGiai = txtDienGiai.Text;
            DinhMuc.CachTinh = (int)cboCachTinh.EditValue;
            this.VnsDinhMucService.SaveOrUpdate(DinhMuc);
            Commons.Commons.Message_Information("Lưu thành công");
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                LamMoi();
                gctDinhMuc.Enabled = false;                
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
            
        }

        private Boolean CheckInput()
        {

            if (txtDinhMuc.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa định mức");
                txtDinhMuc.Focus();
                return false;
            }
            return true;
        }

        private void SetFocusGrid(Guid DinhMucId, int i)
        {
            if (DinhMucId == new Guid())
            {
                gvDinhMuc.FocusedRowHandle = gvDinhMuc.RowCount - 1;
                if (gvDinhMuc.RowCount == 1)
                {
                    gvDinhMuc_FocusedRowChanged(null, null);
                }
            }
            else
            {
                gvDinhMuc.FocusedRowHandle = i;
            }
        }
        private void CalculateTotalPages()
        {
            int rowCount = this.VnsDinhMucService.GetCount();
            TotalPage = rowCount / PgSize;
            if (rowCount % PgSize > 0)
                TotalPage += 1;     //tong so trang
        }

        private void BindingData(int CurrentPageIndex)
        {
            lstDataSource = new List<VnsDmDinhMucTemp>();

            btnHuy.Enabled = false;
            CalculateTotalPages();
            // Hien thi du lieu len gridcontrol
            VnsOrder obj = new VnsOrder(true, "DinhMuc");
            IList<VnsOrder> orders = new List<VnsOrder>();
            orders.Add(obj);
            txtSoTrang.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
            IList<VnsDinhMuc>lstDinhMuc = this.VnsDinhMucService.ListLike((CurrentPageIndex - 1) * PgSize, PgSize, null, null, null, null, orders);
            foreach (VnsDinhMuc objDm in lstDinhMuc)
            {
                VnsDmDinhMucTemp temp = new VnsDmDinhMucTemp();
                temp.CachTinh = objDm.CachTinh;
                temp.DinhMuc = objDm.DinhMuc;
                temp.DinhMucId = objDm.Id;
                temp.LoaiCapVu = objDm.LoaiCapVu;
                temp.MucId = objDm.MucId;
                //if (objDm.Muc != null)
                //{
                //    temp.TenMuc = objDm.Muc.TenMuc;
                //}
                temp.TenMuc = objDm.DienGiai;
                temp.NhomNuoc = objDm.NhomNuoc;
                temp.NgayApDung = objDm.NgayApDung;
                IList<VnsDmHeThong> lst = this.VnsDmHeThongService.GetByDoiTuongAndMa("CAP_BAC_TV", objDm.LoaiCapVu.ToString());
                if (lst.Count > 0)
                {
                    temp.TenDoiTuong = lst[0].Ten;
                }
                lstDataSource.Add(temp);
            }
            this.gcDinhMuc.DataSource = lstDataSource;
            // Do du lieu vao lookUpEdit
            //int[] phanloai = new int[] {1,2,3};
            //this.lueNhomNuoc.Properties.DataSource = phanloai;
        }

        public void BindMuc()
        {
            this.lueMucId.Properties.DataSource = this.VnsDmMucTieuMucService.List(-1, -1, null, null, null);     //hiển thị danh sách mới
            this.lueMucId.Properties.DisplayMember = "TenMuc";
            this.lueMucId.Properties.ValueMember = "Id";
        }

        public void BindDmNuoc()
        {
            this.lueNuocId.Properties.DataSource = this.VnsDmQuocGiaService.List(-1, -1, null, null, null);     //hiển thị danh sách mới
            this.lueNuocId.Properties.DisplayMember = "TenNuoc";
            this.lueNuocId.Properties.ValueMember = "TenNuoc";
        }
        public void BindLoaiCapVu()
        {
            List<VnsDmHeThong> lstcapbac = new List<VnsDmHeThong>();
            VnsDmHeThong vnstmpCap = new VnsDmHeThong();
            vnstmpCap.GiaTri = 0;
            vnstmpCap.Ten = "Tất cả";
            lstcapbac.Add(vnstmpCap);
            lstcapbac.AddRange(VnsDmHeThongService.GetByDoiTuong("CAP_BAC_TV"));
            this.lueLoaiCapVu.Properties.DataSource = lstcapbac;
            this.lueLoaiCapVu.Properties.DisplayMember = "GiaTri";
            this.lueLoaiCapVu.Properties.ValueMember = "GiaTri";

            List<VnsDmHeThong> lstcapQG = new List<VnsDmHeThong>();
            VnsDmHeThong vnstmpQG = new VnsDmHeThong();
            vnstmpQG.GiaTri = 0;
            vnstmpQG.Ten = "Tất cả";
            lstcapQG.Add(vnstmpCap);
            lstcapQG.AddRange(VnsDmHeThongService.GetByDoiTuong("CAP_BAC_QG"));
            this.lueNhomNuoc.Properties.DataSource = lstcapQG;
            this.lueNhomNuoc.Properties.DisplayMember = "GiaTri";
            this.lueNhomNuoc.Properties.ValueMember = "GiaTri";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LamMoi();
            //ResetControl();
            //this.lueNuocId.EditValue = "";
            //BindingData(CurrentPageIndex);
            //this.btnHuy.Enabled = true;
        }

        private void ResetControl()
        {
            this.dtNgayApdung.ResetText();
            this.txtDinhMuc.ResetText();
            this.lueLoaiCapVu.EditValue = "";
            this.lueMucId.EditValue = new Guid();
            this.lueNhomNuoc.EditValue = "";
        }

        private void FrmDinhMuc_Load(object sender, EventArgs e)
        {
            BindCachTinh();
            //cboCachTinh.ItemIndex = 0;
            BindMuc();
            BindDmNuoc();
            BindLoaiCapVu();
            BindingData(CurrentPageIndex);
        }

        private void BindCachTinh()
        {
            // Do du lieu len lueTrangThai
            this.cboCachTinh.Properties.DataSource = VnsDmHeThongService.GetByDoiTuong("CACHTINH_DINHMUC");
            this.cboCachTinh.Properties.DisplayMember = "Ten";
            this.cboCachTinh.Properties.ValueMember = "GiaTri";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDinhMuc.GetFocusedRowCellValue(colDinhMucId).ToString() != "")
                {
                    DinhMuc = new Vns.QuanLyDoanRa.Domain.VnsDinhMuc();
                    DinhMuc.Id = new Guid(gvDinhMuc.GetFocusedRowCellValue(colDinhMucId).ToString());
                    DinhMuc = this.VnsDinhMucService.GetById(DinhMuc.Id);
                    if (MessageBox.Show("Bạn có đồng ý xóa mục  " + DinhMuc.NgayApDung, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.VnsDinhMucService.DeleteById(DinhMuc.Id);                       
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

        private void btnTrangSau_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex < this.TotalPage)
            {
                this.CurrentPageIndex++;
                BindingData(CurrentPageIndex);
            }
        }

        private void btnTrangTruoc_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex > 1)
            {
                this.CurrentPageIndex--;
                BindingData(CurrentPageIndex);
            }
        }

        private void btnTrangDau_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = 1;
            BindingData(CurrentPageIndex);
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // cho tim kiem like
            IList likeProps = new ArrayList();
            IList likeValues = new ArrayList();

            // cho tim kiem chinh xac
            //IList props = new ArrayList();
            //IList values = new ArrayList();
            //if (lueNuocId.EditValue.ToString() != "")
            //{
            //    likeProps.Add("NuocId");
            //    likeValues.Add("%" + lueNuocId.EditValue.ToString() + "%");
            //}
            // tim kiem theo dia chi
            //if (txtDinhMuc.Text.ToString() != "")
            //{
            //    likeProps.Add("DinhMuc");
            //    likeValues.Add("%" + Convert.ToDecimal(txtDinhMuc.Text) + "%");
            //}
            //if (lueMucCha.EditValue != null)
            //{
            //    props.Add("IdMucCha");
            //    values.Add(new Guid(lueMucCha.EditValue.ToString()));
            //}
            this.gcDinhMuc.DataSource = null;
            this.gcDinhMuc.DataSource = this.VnsDinhMucService.ListLike(-1, -1, null, null, likeProps, likeValues, null);
            if (gvDinhMuc.RowCount > 0)
            {
                MessageBox.Show("Tìm thấy " + gvDinhMuc.RowCount + " kết quả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có kết quả thích hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            BindingData(1);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {  
            btnThemMoi.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = false;            
            //btnReset_Click(null, null);            
            gctDinhMuc.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Guid Id = new Guid();
                int i = 0;

                if (!CheckInput())
                    return;
                Id = DinhMuc.Id;
                i = gvDinhMuc.FocusedRowHandle;

                GetObject();
                BindingData(CurrentPageIndex);

                SetFocusGrid(Id, i);
                gctDinhMuc.Enabled = true;
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void gvDinhMuc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle <0) return;
            VnsDmDinhMucTemp objTemp= (VnsDmDinhMucTemp) gvDinhMuc.GetRow(e.FocusedRowHandle);
            DinhMuc = VnsDinhMucService.GetById(objTemp.DinhMucId);
            if (DinhMuc == null) return;

            this.dtNgayApdung.EditValue = DinhMuc.NgayApDung;
            this.txtDinhMuc.EditValue = DinhMuc.DinhMuc;
            this.lueNhomNuoc.EditValue = DinhMuc.NhomNuoc;
            this.lueMucId.EditValue = DinhMuc.MucId;
            this.lueLoaiCapVu.EditValue = DinhMuc.LoaiCapVu;
            this.cboCachTinh.EditValue = DinhMuc.CachTinh;
            this.txtDienGiai.EditValue = DinhMuc.DienGiai;
        }

        private void FrmDinhMuc_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
                {
                    btnThemMoi_Click(btnThemMoi, null);
                }
                else if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control && btnSua.Enabled==true)
                {
                    btnSua_Click(btnSua, null);
                }
                else if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
                {
                    btnXoa_Click(btnXoa, null);
                }
                else if (e.KeyCode == Keys.H && e.Modifiers == Keys.Control)
                {
                    btnHuy_Click(btnHuy, null);
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }
    }

    public class VnsDmDinhMucTemp
    {
        Guid _DinhMucId;
        public Guid DinhMucId
        {
            get { return _DinhMucId; }
            set { _DinhMucId = value; }
        }

        DateTime _NgayApDung;
        public DateTime NgayApDung
        {
            get { return _NgayApDung; }
            set { _NgayApDung = value; }
        }

        int _NhomNuoc;
        public int NhomNuoc
        {
            get { return _NhomNuoc; }
            set { _NhomNuoc = value; }
        }

        int _LoaiCapVu;
        public int LoaiCapVu
        {
            get { return _LoaiCapVu; }
            set { _LoaiCapVu = value; }
        }
        Guid _MucId;
        public Guid MucId
        {
            get { return _MucId; }
            set { _MucId = value; }
        }
        Decimal _DinhMuc;
        public Decimal DinhMuc
        {
            get { return _DinhMuc; }
            set { _DinhMuc = value; }
        }

        String _NuocId;
        public String NuocId
        {
            get { return _NuocId; }
            set { _NuocId = value; }
        }
        int _CachTinh;
        public int CachTinh
        {
            get { return _CachTinh; }
            set { _CachTinh = value; }
        }

        String _TenMuc;
        public String TenMuc
        {
            get { return _TenMuc; }
            set { _TenMuc = value; }
        }

        String _TenDoiTuong;
        public String TenDoiTuong
        {
            get { return _TenDoiTuong; }
            set { _TenDoiTuong = value; }
        }
    }
}
