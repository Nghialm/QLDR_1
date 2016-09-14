using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Vns.Erp.Core;
using System.Threading;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.QuanLyDoanRa.Domain;

namespace QuanLyDoanRa
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        IInfoService _InfoService;
        public IInfoService InfoService
        {
            get { return _InfoService; }
            set { _InfoService = value; }
        }

        public FrmMain()
        {
            InitializeComponent();
            KhoiTaoHeThong();
        }

        private void KhoiTaoHeThong()
        {
            string _DicSource = Application.ExecutablePath;
            
            int _i1 = _DicSource.Split('\\').Length;
            string _temp = _DicSource.Split('\\')[_i1 - 1];
            _DicSource = _DicSource.Replace(_temp, "");
            
            string _fileTemp = "/App_Data/QuanLyDoanRa.db";            
            General.FileDataBase = _DicSource+_fileTemp;
            General.NamKeToan = GetXmlInfo.GetNamKeToan();
        }

        private void LoadThamSoHeThong()
        {
            Info _infoNguoiLapBieu = this.InfoService.GetByKey("Ma", "p_NguoiLapBieu");
            if (_infoNguoiLapBieu != null)
            {
                General.ChucDanhNguoiLapBieu = _infoNguoiLapBieu.GiaTri;
            }


            Info _infoTenNguoiLapBieu = this.InfoService.GetByKey("Ma", "p_TenNguoiLapBieu");
            if (_infoTenNguoiLapBieu != null)
            {
                General.TenNguoiLapBieu = _infoTenNguoiLapBieu.GiaTri;
            }

            Info _infoKeToanTruong = this.InfoService.GetByKey("Ma", "p_ChucDanhKeToanTruong");
            if (_infoKeToanTruong != null)
            {
                General.ChucDanhKeToanTruong = _infoKeToanTruong.GiaTri;
            }

            Info _infoTenKeToanTruong = this.InfoService.GetByKey("Ma", "p_TenKeToanTruong");
            if (_infoTenKeToanTruong != null)
            {
                General.TenKeToanTruong = _infoTenKeToanTruong.GiaTri;
            }
            Info _infoChucDanhNguoiKyBangBieu = this.InfoService.GetByKey("Ma", "p_ChucDanhNguoiKyBangBieu");
            if (_infoChucDanhNguoiKyBangBieu != null)
            {
               General.ChucDanhNguoiKyBangBieu = _infoChucDanhNguoiKyBangBieu.GiaTri;
            }

            Info _infoTenNguoiKyBangBieu = this.InfoService.GetByKey("Ma", "p_TenNguoiKyBangBieu");
            if (_infoTenNguoiKyBangBieu != null)
            {
                General.TenNguoiKyBangBieu = _infoTenNguoiKyBangBieu.GiaTri;
            }

            General.lstThamSo = InfoService.GetAll();
        }
        private void barThoat_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn thoát ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Application.Exit();
            }
        }

        private void barDmMucTieuMuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmMucTieuMuc frmMucTieuMuc = (FrmMucTieuMuc)ObjectFactory.GetObject("frmMucTieuMuc");
            frmMucTieuMuc.Show();
        }

        private void barDmQuocGia_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            FrmDMQuocGia frmDMQuocGia = (FrmDMQuocGia)ObjectFactory.GetObject("frmDMQuocGia");
            frmDMQuocGia.Show();
        }

        private void barThongTinDoanRa_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            FrmDSDoanCongTac frmDSDoanCongTac = (FrmDSDoanCongTac)ObjectFactory.GetObject("frmDSDoanCongTac");
            frmDSDoanCongTac.Show();
        }

        private void barChungTu_ItemClick(object sender, ItemClickEventArgs e)
        {
            //FrmChungTu frmChungTu = (FrmChungTu)ObjectFactory.GetObject("frmChungTu");
            //frmChungTu.Show();
        }
        

        private void barDinhMucCT_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDinhMuc frmDinhMuc = (FrmDinhMuc)ObjectFactory.GetObject("frmDinhMuc");
            frmDinhMuc.Show();
        }

        private void barQuyetToan_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmQuyetToanDoan frmQuyetToanDoan = (FrmQuyetToanDoan)ObjectFactory.GetObject("frmQuyetToanDoan");
            frmQuyetToanDoan.AccessibleDescription = "QT";
            frmQuyetToanDoan.Show();
        }

        private void barDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmLogin frmLogin = (FrmLogin)ObjectFactory.GetObject("frmLogin");
            frmLogin.ShowDialog();
        }

        

        private void barDuToan_ItemClick(object sender, ItemClickEventArgs e)
        {
            //FrmDuToanDoanRa frmDuToanDoanRa = (FrmDuToanDoanRa)ObjectFactory.GetObject("frmDuToanDoanRa");
            //frmDuToanDoanRa.Show();

            FrmDuToan frmDuToan = (FrmDuToan)ObjectFactory.GetObject("frmDuToan");
            frmDuToan.Show();
        }

        private void barDmLoaiDonVi_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmLoaiDoanRa frmLoaiDoanRa = (FrmLoaiDoanRa)ObjectFactory.GetObject("frmLoaiDoanRa");
            frmLoaiDoanRa.Show();
        }

        private void barDmHeThong_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDMHeThong frmDMHeThong = (FrmDMHeThong)ObjectFactory.GetObject("frmDMHeThong");
            frmDMHeThong.Show();
        }

        #region "Chung Tu"
        private void barPhieuTamUng_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTamUng FrmTamUng = (FrmTamUng)ObjectFactory.GetObject("frmTamUng");

            FrmTamUng.AccessibleDescription = "TU";
            FrmTamUng.Show();
        }

        private void barPhieuHoanUng_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTamUng FrmTamUng = (FrmTamUng)ObjectFactory.GetObject("frmTamUng");
            FrmTamUng.AccessibleDescription = "HU";
            FrmTamUng.Show();
        }

        private void barPhieuThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUyNhiemChi FrmTamUng = (FrmUyNhiemChi)ObjectFactory.GetObject("frmUyNhiemChi");

            FrmTamUng.AccessibleDescription = "PT";
            FrmTamUng.Show();
        }

        private void barPhieuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUyNhiemChi FrmTamUng = (FrmUyNhiemChi)ObjectFactory.GetObject("frmUyNhiemChi");

            FrmTamUng.AccessibleDescription = "PC";
            FrmTamUng.Show();
        }
        #endregion

        private void barDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Thread.CurrentPrincipal = null;
            FrmLogin frmLogin = (FrmLogin)ObjectFactory.GetObject("frmLogin");
            frmLogin.ShowDialog();
        }

        private void barDmNghiepVu_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barDmChucVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDMChucVu frmDanhMucChucVu = (FrmDMChucVu)ObjectFactory.GetObject("frmChucVu");
            frmDanhMucChucVu.Show();
        }

        private void barDanhMucDonVi_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDonVi frmDonVi = (FrmDonVi)ObjectFactory.GetObject("frmDonVi");
            frmDonVi.Show();
        }

        private void ReportItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "barRp01DR":
                    Reports.frmReportByThangNam frm01 = (Reports.frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
                    frm01.AccessibleDescription = "01DN";
                    frm01.Tag = e.Item.Caption;
                    frm01.Show();
                    break;
                case "barRp02DR":

                    Reports.frmReportByLoaiDR frm02= (Reports.frmReportByLoaiDR)ObjectFactory.GetObject("frmReportByLoaiDR");
                    frm02.AccessibleDescription = "02DN";
                    frm02.Tag = e.Item.Caption;
                    frm02.Show();
                    break;
               case "barRp03DR":
                    Reports.frmReportByLoaiDR frm03 = (Reports.frmReportByLoaiDR)ObjectFactory.GetObject("frmReportByLoaiDR");                    
                    frm03.AccessibleDescription = "03DN";
                    frm03.Tag = e.Item.Caption;
                    frm03.Show();
                    break;
               case "barRp03DR_LDR":
                    Reports.frmReportByLoaiDR frm031 = (Reports.frmReportByLoaiDR)ObjectFactory.GetObject("frmReportByLoaiDR");
                    frm031.AccessibleDescription = "03DR_LDR";
                    frm031.Tag = e.Item.Caption;
                    frm031.Show();
                    break;
                case "barRp04DR":
                    Reports.frmReportByLoaiDR frm04 = (Reports.frmReportByLoaiDR)ObjectFactory.GetObject("frmReportByLoaiDR");
                    frm04.AccessibleDescription = "04DN";
                    frm04.Tag = e.Item.Caption;
                    frm04.Show();
                    break;
                case "barRp04DR_LDR":
                    Reports.frmReportByLoaiDR frm041 = (Reports.frmReportByLoaiDR)ObjectFactory.GetObject("frmReportByLoaiDR");
                    frm041.AccessibleDescription = "04DR_LDR";
                    frm041.Tag = e.Item.Caption;
                    frm041.Show();
                    break;
                case "barRp05DR":
                    Reports.frmReportByThangNam frm05 = (Reports.frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
                    frm05.AccessibleDescription = "05DN";
                    frm05.Tag = e.Item.Caption;
                    frm05.Show();
                    break;
                    
                case "barRp06DR":
                    Reports.frmReportByThangNam frm06 = (Reports.frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
                    frm06.AccessibleDescription = "06DN1";
                    frm06.Tag = e.Item.Caption;
                    frm06.Show();
                    break;
                case "barRp06DR1":
                    Reports.frmReportByThangNam frm061 = (Reports.frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
                    frm061.AccessibleDescription = "06DN2";
                    frm061.Tag = e.Item.Caption;
                    frm061.Show();
                    break;
                case "BarRpSoCtTaiKhoan":
                    Reports.frmSoCTTaiKhoan frmctTK = (Reports.frmSoCTTaiKhoan)ObjectFactory.GetObject("frmSoCTTaiKhoan");
                    frmctTK.AccessibleDescription = "CTTK";
                    frmctTK.Tag = e.Item.Caption;
                    frmctTK.Show();
                    break;
                case "barRPBangKeTU":
                    Reports.frmReportByThangNam barRPBangKeTU = (Reports.frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
                    barRPBangKeTU.AccessibleDescription = "barRPBangKeTU";
                    barRPBangKeTU.Tag = e.Item.Caption;
                    barRPBangKeTU.Show();
                    break;
                case "barRpBangKeQT":
                    Reports.frmReportByThangNam barRpBangKeQT = (Reports.frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
                    barRpBangKeQT.AccessibleDescription = "barRpBangKeQT";
                    barRpBangKeQT.Tag = e.Item.Caption;
                    barRpBangKeQT.Show();
                    break;
                case "barRpCtGhiSoQT":
                    Reports.frmReportByThangNam barRpCtGhiSoQT = (Reports.frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
                    barRpCtGhiSoQT.AccessibleDescription = "barRpCtGhiSoQT";
                    barRpCtGhiSoQT.Tag = e.Item.Caption;
                    barRpCtGhiSoQT.Show();
                    break;
                case "barCtGhiSoHoanTU":
                    Reports.frmReportByThangNam barCtGhiSoHoanTU = (Reports.frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
                    barCtGhiSoHoanTU.AccessibleDescription = "barCtGhiSoHoanTU";
                    barCtGhiSoHoanTU.Tag = e.Item.Caption;
                    barCtGhiSoHoanTU.Show();
                    break;
            }
          
        }

        private void barRp01DR_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportItemClick(sender, e);
        }

        private void barRp02DR_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportItemClick(sender, e);
        }

        private void barRp03DR_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportItemClick(sender, e);
        }

        private void barRp04DR_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportItemClick(sender, e);
        }

        private void barRp05DR_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportItemClick(sender, e);

        }

        private void barRp06DR_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportItemClick(sender, e);
        }

        private void BarRpSoCtTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportItemClick(sender, e);
        }

        private void barRPBangKeTU_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportItemClick(sender, e);
        }

        private void barRpBangKeQT_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportItemClick(sender, e);
        }

        private void barRpCtGhiSoQT_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportItemClick(sender, e);
        }

        private void barCtGhiSoHoanTU_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportItemClick(sender, e);
        }

        private void barSaoLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmBackupDuLieu frm = ObjectFactory.GetObject("FrmBackupDuLieu") as FrmBackupDuLieu;
            frm.ShowDialog();
        }

        private void barPhucHoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmKhoiPhucDuLieu frm = ObjectFactory.GetObject("FrmKhoiPhucDuLieu") as FrmKhoiPhucDuLieu;
            frm.ShowDialog();
        }

        private void barRp03DR_LDR_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportItemClick(sender, e);
        }

        private void barRp04DR_LDR_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportItemClick(sender, e);
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadThamSoHeThong();
            barSttNam.Caption = "Năm " + General.NamKeToan.ToString();
        }

        private void btnThamSoHeThong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThamSoHeThong FrmThamSoHeThong = (frmThamSoHeThong)ObjectFactory.GetObject("frmThamSoHeThong");
            FrmThamSoHeThong.Show();
        }

        private void barRp06DR1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportItemClick(sender, e);
        }

        private void barDmKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDanhMucKhachHang frm = ObjectFactory.GetObject("frmDanhMucKhachHang") as frmDanhMucKhachHang;
            frm.ShowDialog();
        }

        private void barUyNhiemChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUyNhiemChi frm = (FrmUyNhiemChi)ObjectFactory.GetObject("frmUyNhiemChi");
            frm.AccessibleDescription = "UNC";
            frm.Show();
        }

        private void barTimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSearchChungTu frm = ObjectFactory.GetObject("frmSearchChungTu") as frmSearchChungTu;
            frm.ShowDialog();
        }

        private void barTinhTyGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTinhTyGia frm = ObjectFactory.GetObject("FrmTinhTyGia") as FrmTinhTyGia;
            frm.ShowDialog();
        }

        private void barNamKt_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmNamKeToan frm = ObjectFactory.GetObject("frmNamKeToan") as FrmNamKeToan;
            frm.ShowDialog();

            barSttNam.Caption = "Năm " + General.NamKeToan.ToString();
        }

        private void barGiayBaoNo_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUyNhiemChi FrmTamUng = (FrmUyNhiemChi)ObjectFactory.GetObject("frmUyNhiemChi");

            FrmTamUng.AccessibleDescription = "GBN";
            FrmTamUng.Show();
        }

        private void barGiayBaoCo_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUyNhiemChi FrmTamUng = (FrmUyNhiemChi)ObjectFactory.GetObject("frmUyNhiemChi");

            FrmTamUng.AccessibleDescription = "GBC";
            FrmTamUng.Show();
        }



    }
}