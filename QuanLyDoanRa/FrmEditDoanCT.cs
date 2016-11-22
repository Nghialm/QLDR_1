using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.Erp.Core;
using Vns.Erp.Core.Domain;
using System.Collections;
using Vns.QuanLyDoanRa.Domain;

namespace QuanLyDoanRa
{
    public partial class FrmEditDoanCT : Form
    {

        #region"Variables"
        private IList<VnsLichCongTac> lstLichCongTac = new List<VnsLichCongTac>();
        private IList<VnsLichCongTac> lstDelLichCongTac = new List<VnsLichCongTac>();
        private IList<VnsThanhVien> lstThanhVien = new List<VnsThanhVien>();
        private IList<VnsThanhVien> lstDeleteThanhVien = new List<VnsThanhVien>();
        private IList<LichCongTacThanhVien> lstDataSource = new List<LichCongTacThanhVien>();
        private VnsDoanCongTac _DoanRa;
        private bool OnloadData = false;

        public VnsDoanCongTac DoanRa
        {
            get { return _DoanRa; }
            set { _DoanRa = value; }
        }

        private VnsLichCongTac _LichCongTac;
        public VnsLichCongTac LichCongTac
        {
            get { return _LichCongTac; }
            set { _LichCongTac = value; }
        }

        private VnsThanhVien _ThanhVien;
        public VnsThanhVien ThanhVien
        {
            get { return _ThanhVien; }
            set { _ThanhVien = value; }
        }

        public FormUpdate FormStatus;

        #endregion

        #region  "Property Service"

        public IVnsDoanCongTacService VnsDoanCongTacService;
        public IVnsLoaiDoanRaService VnsLoaiDoanRaService;
        public IVnsDmHeThongService VnsDmHeThongService;
        public IVnsDmQuocGiaService VnsDmQuocGiaService;
        public IVnsLichCongTacService VnsLichCongTacService;
        public IVnsThanhVienService VnsThanhVienService;
        public IVnsDonViService VnsDonViService;
        public IVnsDanhMucChucVuService VnsDanhMucChucVuService;
        #endregion
         
        #region"Functions"

        public FrmEditDoanCT()
        {
            InitializeComponent();
        }

        private void BindDataToCbo()
        {
            // do du lieu len lueLoaiDoanRa
            lueLoaiDoanRa.Properties.DataSource = this.VnsLoaiDoanRaService.List(-1, -1, null, null, null);
            lueLoaiDoanRa.Properties.DisplayMember = "TenLoaiDoanRa";
            lueLoaiDoanRa.Properties.ValueMember = "Id";

            // Do du lieu len lueTrangThai
            lueTrangThai.Properties.DataSource = VnsDmHeThongService.GetByDoiTuong("TRANGTHAI_DOANRA");
            lueTrangThai.Properties.DisplayMember = "Ten";
            lueTrangThai.Properties.ValueMember = "GiaTri";

            //cboNuocDen.DataSource = this.VnsDmQuocGiaService.GetAll();
            //cboNuocDen.DisplayMember = "TenNuoc";
            //cboNuocDen.ValueMember = "Id";
            rcboNuocDen.DataSource = this.VnsDmQuocGiaService.GetAll();

            luegTrangThai.DataSource = VnsDmHeThongService.GetByDoiTuong("TRANGTHAI_DOANRA");
            luegTrangThai.DisplayMember = "Ten";
            luegTrangThai.ValueMember = "GiaTri";

            luegPhanLoai.DataSource = VnsDmHeThongService.GetByDoiTuong("CAP_BAC_TV");
            luegPhanLoai.DisplayMember = "Ten";
            luegPhanLoai.ValueMember = "GiaTri";

            VnsOrder orderDonVi = new VnsOrder(true, "TenDonVi");
            List<VnsOrder> lstorders = new List<VnsOrder>();
            lstorders.Add(orderDonVi);
            luDonVi.Properties.DataSource = this.VnsDonViService.List(-1, -1, null, null, lstorders);
            luDonVi.Properties.DisplayMember = "TenDonVi";
            luDonVi.Properties.ValueMember = "DonViId";

            //VnsOrder orderChucVu = new VnsOrder(true, "TenChucVu");
            //List<VnsOrder> lstordersChuVu = new List<VnsOrder>();
            //lstorders.Add(orderChucVu);
            IList<VnsDanhMucChucVu> lst = VnsDanhMucChucVuService.GetAll();
            luChucVuTruongDoan.Properties.DataSource = lst;
            luChucVuTruongDoan.Properties.DisplayMember = "TenChucVu";
            luChucVuTruongDoan.Properties.ValueMember = "ChucVuId";
        }

        private IList<LichCongTacThanhVien> SetLichCongTacThanhVien(IList<VnsLichCongTac> lstLichCongTac, IList<VnsThanhVien> lstThanhVien)
        {
            IList<LichCongTacThanhVien> lstLichConTacThanhVien = new List<LichCongTacThanhVien>();
            LichCongTacThanhVien objTemp;
            int SoLuongThanhVienA;
            int SoLuongThanhVienB;
            foreach (VnsLichCongTac tempLichCongTac in lstLichCongTac)
            {
                objTemp = new LichCongTacThanhVien();
                SoLuongThanhVienA = 0;
                SoLuongThanhVienB = 0;

                objTemp.LichCongTacId = tempLichCongTac.Id;
                objTemp.DiaDiem = tempLichCongTac.DiaDiem;
                objTemp.LoaiQuocGia = tempLichCongTac.LoaiQuocGia;
                objTemp.MoTa = tempLichCongTac.MoTa;
                objTemp.NuocId = tempLichCongTac.NuocId;
                objTemp.NgayDi = tempLichCongTac.NgayDi;
                objTemp.NgayVe = tempLichCongTac.NgayVe;
                objTemp.TrangThai = tempLichCongTac.TrangThai;
                objTemp.CongTacId = tempLichCongTac.CongTacId;
                objTemp.NgayCongTac = tempLichCongTac.NgayCongTac;

                IList<VnsThanhVien> lstThanhVienTemp = GetThanhVienByLichCt(tempLichCongTac.Id, lstThanhVien);

                foreach (VnsThanhVien objTV in lstThanhVienTemp)
                {
                    if (objTV.PhanLoai == 1)
                        SoLuongThanhVienA = objTV.SoLuong;
                    if (objTV.PhanLoai == 2)
                        SoLuongThanhVienB = objTV.SoLuong;
                }
                objTemp.ThanhVienA = SoLuongThanhVienA;
                objTemp.ThanhVienB = SoLuongThanhVienB;
                lstLichConTacThanhVien.Add(objTemp);            
            }
            
            return lstLichConTacThanhVien;
        }

        private IList<VnsThanhVien> GetThanhVienByLichCt(Guid LichCongTacId, IList<VnsThanhVien> lstThanhVien)
        {
            IList<VnsThanhVien> lstTempThanhVien = new List<VnsThanhVien>();

            foreach (VnsThanhVien objThanhVien in lstThanhVien)
            {
                if (objThanhVien.LichCongTacId == LichCongTacId)
                {
                    lstTempThanhVien.Add(objThanhVien);
                }
            }

            return lstTempThanhVien;
        }

        private void GetLichCongTacThanhVien(IList<LichCongTacThanhVien> lstTemp)
        {
            //IList<VnsLichCongTac> lstLichCongTac = new List<VnsLichCongTac>();
            //IList<VnsThanhVien> lstThanhVien = new List<VnsThanhVien>();
            VnsLichCongTac objLichCongTac;
            VnsThanhVien objThanhVien;
            lstThanhVien = new List<VnsThanhVien>();
            lstLichCongTac = new List<VnsLichCongTac>();
            foreach (LichCongTacThanhVien objTemp in lstTemp)
            {
                
                objLichCongTac = new VnsLichCongTac();
                if (objTemp.LichCongTacId == new Guid())
                {
                    objLichCongTac.Id = Guid.NewGuid();
                    objLichCongTac.LichCongTacId = Guid.NewGuid();
                }
                else
                {
                    objLichCongTac.Id = objTemp.LichCongTacId;
                    objLichCongTac.LichCongTacId = objTemp.LichCongTacId;
                }
                
                objLichCongTac.CongTacId = objTemp.CongTacId;
                objLichCongTac.DiaDiem = objTemp.DiaDiem;
                objLichCongTac.LoaiQuocGia = objTemp.LoaiQuocGia;
                objLichCongTac.MoTa = objTemp.MoTa;
                objLichCongTac.NgayDi = objTemp.NgayDi;
                objLichCongTac.NgayVe = objTemp.NgayVe;
                objLichCongTac.NuocId = objTemp.NuocId;
                objLichCongTac.TrangThai = objTemp.TrangThai;
                objLichCongTac.NgayCongTac = objTemp.NgayCongTac;
                objLichCongTac.LoaiQuocGia = objTemp.LoaiQuocGia;
                lstLichCongTac.Add(objLichCongTac);

                //Thanh vien muc A
                objThanhVien = new VnsThanhVien();
                objThanhVien.LichCongTacId = objLichCongTac.Id;
                objThanhVien.SoLuong = objTemp.ThanhVienA;
                objThanhVien.PhanLoai = 1;
                lstThanhVien.Add(objThanhVien);

                //Thanh vien muc B
                objThanhVien = new VnsThanhVien();
                objThanhVien.LichCongTacId = objLichCongTac.Id;
                objThanhVien.SoLuong = objTemp.ThanhVienB;
                objThanhVien.PhanLoai = 2;
                lstThanhVien.Add(objThanhVien);
            
            }
        }       

        private Boolean CheckInput()
        {
            if (luDonVi.EditValue == null)
            {
                Commons.Commons.Message_Warning("Bạn chưa chọn cơ quan lập dự toán");
                luDonVi.Focus();
                return false;
            }

            if (txtTenDoan.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập tên đoàn");
                txtTenDoan.Focus();
                return false;
            }

            if (txtTruongDoan.Text.Trim() == "")
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập trưởng đoàn");
                txtTruongDoan.Focus();
                return false;
            }

            if (luChucVuTruongDoan.EditValue == null)
            {
                Commons.Commons.Message_Warning("Bạn chưa chọn chức vụ trưởng đoàn");
                luChucVuTruongDoan.Focus();
                return false;
            }

            if (lueLoaiDoanRa.EditValue == null)
            {
                Commons.Commons.Message_Warning("Bạn chưa chọn nguồn kinh phí");
                lueLoaiDoanRa.Focus();
                return false;
            }

            if (lueTrangThai.EditValue == null)
            {
                Commons.Commons.Message_Warning("Bạn chưa chọn trạng thái");
                lueTrangThai.Focus();
                return false;
            }

            if (dtNgayDi.EditValue == null)
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập ngày đi");
                dtNgayDi.Focus();
                return false;
            }

            if (dtNgayVe.EditValue == null)
            {
                Commons.Commons.Message_Warning("Bạn chưa nhập ngày về");
                dtNgayVe.Focus();
                return false;
            }

            if ((DateTime)dtNgayVe.EditValue < ((DateTime)dtNgayDi.EditValue))
            {
                Commons.Commons.Message_Warning("Ngày đi phải nhỏ hơn hoặc bằng ngày về");
                return false;
            }
            return true;
        }

        private void ThemDongLich()
        {
            if (lstDataSource == null) lstDataSource = new List<LichCongTacThanhVien>();
            LichCongTacThanhVien lct = new LichCongTacThanhVien();
            lct.LichCongTacId = Guid.NewGuid();
            if (_DoanRa != null)
            {
                lct.CongTacId = _DoanRa.Id;
            }
            lstDataSource.Add(lct);
            this.gctLichCongTac.DataSource = lstDataSource;
            this.gctLichCongTac.RefreshDataSource();
            Commons.GridHelper.SetFocusAfterAddRow(gvLichCongTac);
        }

        private void ThemDongTV()
        {
            if (lstThanhVien == null) lstThanhVien = new List<VnsThanhVien>();
            VnsThanhVien tv = new VnsThanhVien();
            tv.Id = Guid.NewGuid();
            if (_DoanRa != null)
            {
                tv.CongTacId = _DoanRa.Id;
            }
            lstThanhVien.Add(tv);
            this.gctThanhVien.DataSource = lstThanhVien;
            this.gctThanhVien.RefreshDataSource();
            Commons.GridHelper.SetFocusAfterAddRow(gvThanhVien);
        }

        private void XoaDongLich()
        {
            if (gvLichCongTac.FocusedRowHandle < 0) return;

            gvLichCongTac.DeleteSelectedRows();
            gvLichCongTac.RefreshData();
        }

        private void GetObject()
        {
            if (_DoanRa == null)
            {
                _DoanRa = new VnsDoanCongTac();
                DoanRa.Id = Guid.NewGuid();
                DoanRa.IdBanDau = DoanRa.Id;
            }

            _DoanRa.Ten = txtTenDoan.Text;
            _DoanRa.TruongDoan = txtTruongDoan.Text;
            _DoanRa.MoTa = txtMoTa.Text;
            _DoanRa.NgayDi = (DateTime)dtNgayDi.EditValue;
            _DoanRa.NgayVe = (DateTime)dtNgayVe.EditValue;
            _DoanRa.LoaiDoanRaId = (Guid)lueLoaiDoanRa.EditValue;
            _DoanRa.TrangThai = (int)lueTrangThai.EditValue;
            _DoanRa.ChucVuTruongDoanId = (Guid)luChucVuTruongDoan.EditValue;
            _DoanRa.DonViId = (Guid)luDonVi.EditValue;
            _DoanRa.SoThongBaoDuToan = txtSoTbDuToan.Text;
            _DoanRa.TenTruongDoan = txtBiDanhTruongDoan.Text;
            _DoanRa.TenVietTat = txtTenDoanVietTat.Text;
            _DoanRa.NguoiGiaoDichVietTat = txtNguoiGDVietTat.Text;
            _DoanRa.NguoiGiaoDich = txtNguoiGiaoDich.Text;
            if (dtNgayDuyetDuToan.EditValue == null)
            {
                _DoanRa.NgayDuyetDuToan = Null.MaxDate;
            }
            else
            {
                _DoanRa.NgayDuyetDuToan = (DateTime)dtNgayDuyetDuToan.EditValue;
            }
            
            if (_DoanRa.Id != new Guid())
                VnsThanhVienService.DeleteByDoanCongTac(_DoanRa.Id);

            //Get lich cong tac & thanh vien tu list chung
            GetLichCongTacThanhVien(lstDataSource);

            _DoanRa.DanhSachLichCongTac = lstLichCongTac;
            _DoanRa.DanhSachThanhVien = lstThanhVien;

          //  Guid abc = lstThanhVien[0].Id;
            VnsDoanCongTacService.SaveDoanCongTac(ref _DoanRa);
            Guid abc = _DoanRa.Id;
        }

        private void SetObject()
        {
            if (FormStatus == FormUpdate.Update)
            {
                //_DoanRa = VnsDoanCongTacService.GetById(DoanRa.Id);
                txtTenDoan.Text = _DoanRa.Ten;
                txtTruongDoan.Text = _DoanRa.TruongDoan;
                txtMoTa.Text = _DoanRa.MoTa;
                dtNgayDi.EditValue = _DoanRa.NgayDi;
                dtNgayVe.EditValue = _DoanRa.NgayVe;
                dtNgayDuyetDuToan.EditValue = _DoanRa.NgayDuyetDuToan;
                
                lueLoaiDoanRa.EditValue = _DoanRa.LoaiDoanRaId;
                lueTrangThai.EditValue = _DoanRa.TrangThai;
                luChucVuTruongDoan.EditValue = _DoanRa.ChucVuTruongDoanId;
                luDonVi.EditValue = _DoanRa.DonViId;
                txtSoTbDuToan.Text = _DoanRa.SoThongBaoDuToan;
                txtTenDoanVietTat.Text = _DoanRa.TenVietTat;
                txtNguoiGiaoDich.Text = _DoanRa.NguoiGiaoDich;
                txtNguoiGDVietTat.Text = _DoanRa.NguoiGiaoDichVietTat;
                txtBiDanhTruongDoan.Text = _DoanRa.TenTruongDoan;
                lstThanhVien = _DoanRa.DanhSachThanhVien;
                lstLichCongTac = _DoanRa.DanhSachLichCongTac;
              //  if(lstLichCongTac.Count>0)
                 //   Guid abc = lstLichCongTac[0].Id;

                lstDataSource = SetLichCongTacThanhVien(lstLichCongTac, lstThanhVien);
                gctLichCongTac.DataSource = lstDataSource;
            }
        }

    
        private Boolean ThemLich()
        {
            foreach (VnsLichCongTac objLichCongTac in lstLichCongTac)
            {
                objLichCongTac.CongTacId = _DoanRa.Id;
                
                objLichCongTac.Id = Guid.NewGuid();
                VnsLichCongTacService.SaveOrUpdate(objLichCongTac);
            }
            return true;
        }

        #endregion

        #region"Events"

        private void FrmEditDoanCT_Load(object sender, EventArgs e)
        {
            OnloadData = true;
            BindDataToCbo();
            SetObject();
            OnloadData = false;
        }

        private void gctThanhVien_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    ThemDongTV();
                    break;
                case Keys.F8:
                    //XoaDongTV();
                    break;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
                return;
            GetObject();
            this.Close();
        }


        private Boolean Check(int rows)
        {
            if (rows > 0)
                return true;
            return false;
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Escape):
                    btnHuy_Click_1(null, null);
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {

            this.Close();

        }

        private void gvLichCongTac_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gvLichCongTac.FocusedRowHandle < 0) return;
            LichCongTacThanhVien tmp = (LichCongTacThanhVien)gvLichCongTac.GetRow(gvLichCongTac.FocusedRowHandle);
            switch (e.Column.FieldName)
            {
                case "NuocId":
                    VnsDmQuocGia tmpquocgia = (VnsDmQuocGia)rcboNuocDen.GetRowByKeyValue(tmp.NuocId);
                    if (tmpquocgia != null)
                    {
                        tmp.LoaiQuocGia = tmpquocgia.PhanLoai;
                    }
                    break;
            }

        }

        private void gvLichCongTac_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter)
                    return;

                if (Commons.GridHelper.CheckAddNewRow(gvLichCongTac, true))
                {
                    ThemDongLich();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void gvThanhVien_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter)
                    return;

                if (Commons.GridHelper.CheckAddNewRow(gvThanhVien, true))
                {
                    ThemDongTV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FrmEditDoanCT_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
                {
                    btnLuu_Click(btnLuu, null);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    ThemDongLich();
                }
                else if (e.KeyCode == Keys.F8)
                {
                    XoaDongLich();
                }                
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void luDonVi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (OnloadData == true)
                    return;
                VnsDonVi objDonvi = (VnsDonVi)Commons.ComboHelper.GetSelectData(luDonVi);
                if (objDonvi != null)
                {
                    txtTenDoan.Text = objDonvi.TenDonVi;
                    txtTenDoanVietTat.Text = objDonvi.MaDonVi;
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }

        }

        #endregion

        private void dtNgayDuyetDuToan_Validating(object sender, CancelEventArgs e)
        {
            if (dtNgayDuyetDuToan.EditValue == null)
            {
 
            }
        }
    }

    public class LichCongTacThanhVien
    {
        Guid _LichCongTacId;
        public Guid LichCongTacId
        {
            get { return _LichCongTacId; }
            set { _LichCongTacId = value; }
        }

        Guid _CongTacId;
        public Guid CongTacId
        {
            get { return _CongTacId; }
            set { _CongTacId = value; }
        }

        string _DiaDiem;
        public string DiaDiem
        {
            get { return _DiaDiem; }
            set { _DiaDiem = value; }
        }

        Guid _NuocId;
        public Guid NuocId
        {
            get { return _NuocId; }
            set { _NuocId = value; }
        }

        DateTime _NgayDi;
        public DateTime NgayDi
        {
            get { return _NgayDi; }
            set { _NgayDi = value; }
        }

        DateTime _NgayVe;
        public DateTime NgayVe
        {
            get { return _NgayVe; }
            set { _NgayVe = value; }
        }

        int _TrangThai;
        public int TrangThai
        {
            get { return _TrangThai; }
            set { _TrangThai = value; }
        }
        string _MoTa;
        public string MoTa
        {
            get { return _MoTa; }
            set { _MoTa = value; }
        }
        int _LoaiQuocGia;

        public int LoaiQuocGia
        {
            get { return _LoaiQuocGia; }
            set { _LoaiQuocGia = value; }
        }

        int _ThanhVienA;
        public int ThanhVienA
        {
            get { return _ThanhVienA; }
            set { _ThanhVienA = value; }
        }
        int _ThanhVienB;
        public int ThanhVienB
        {
            get { return _ThanhVienB; }
            set { _ThanhVienB = value; }
        }

        decimal _NgayCongTac;
        public decimal NgayCongTac
        {
            get { return _NgayCongTac; }
            set { _NgayCongTac = value; }
        }
    }
}
