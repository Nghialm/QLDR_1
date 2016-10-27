using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vns.Erp.Core;
using QuanLyDoanRa;
using System.Threading;
using QuanLyDoanRa.Reports;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Service.Interface;

namespace QuanLyDoanRa
{
    public partial class frmMain1 : DevExpress.XtraEditors.XtraForm
    {
        IInfoService _InfoService;
        public IInfoService InfoService
        {
            get { return _InfoService; }
            set { _InfoService = value; }
        }

        public frmMain1()
        {
            InitializeComponent();
        }
                
        #region Fucntion

        private void KhoiTaoHeThong()
        {
            string _DicSource = Application.ExecutablePath;

            int _i1 = _DicSource.Split('\\').Length;
            string _temp = _DicSource.Split('\\')[_i1 - 1];
            _DicSource = _DicSource.Replace(_temp, "");

            string _fileTemp = "/App_Data/QuanLyDoanRa.db";
            General.FileDataBase = _DicSource + _fileTemp;
            General.NamKeToan = GetXmlInfo.GetNamKeToan();

            Info objInfo = _InfoService.GetByKey("Ma", "p_NumberOfPage");
            if (objInfo != null)
                General.NumberOfPage = int.Parse(objInfo.GiaTri);
            else
                General.NumberOfPage = 50;
        }

        private void LoadThamSoBaoCao()
        {
            IList<Info> lstInfo = InfoService.GetAll();
            
            foreach (Info obj in lstInfo)
            {
                if (obj.Ma == "p_NguoiLapBieu")
                {
                    General.ChucDanhNguoiLapBieu = obj.GiaTri;
                }

                if (obj.Ma == "p_TenNguoiLapBieu")
                {
                    General.TenNguoiLapBieu = obj.GiaTri;
                }

                if (obj.Ma == "p_ChucDanhKeToanTruong")
                {
                    General.ChucDanhKeToanTruong = obj.GiaTri;
                }

                if (obj.Ma == "p_TenKeToanTruong")
                {
                    General.TenKeToanTruong = obj.GiaTri;
                }

                if (obj.Ma == "p_ChucDanhNguoiKyBangBieu")
                {
                    General.ChucDanhNguoiKyBangBieu = obj.GiaTri;
                }

                if (obj.Ma == "p_TenNguoiKyBangBieu")
                {
                    General.TenNguoiKyBangBieu = obj.GiaTri;
                }

                if (obj.Ma == "p_NguoiPheDuyetDuToan")
                {
                    General.NguoiPheDuyetDuToan = obj.GiaTri;
                }

                if (obj.Ma == "p_NguoiPheDuyetQuyetToan")
                {
                    General.NguoiPheDuyetQuyetToan = obj.GiaTri;
                }

                if (obj.Ma == "p_ChucDanhDuyetDuToan")
                {
                    General.ChucDanhDuyetDuToan = obj.GiaTri;
                }

                if (obj.Ma == "p_ChucDanhDuyetQuyetToan")
                {
                    General.ChucDanhDuyetQuyetToan = obj.GiaTri;
                }

                if (obj.Ma == "p_NOITE")
                {
                    Vns.QuanLyDoanRa.Globals.NoiTeId = VnsConvert.CGuid(obj.GiaTri);
                }

                if (obj.Ma == "p_NGOAITE")
                {
                    Vns.QuanLyDoanRa.Globals.NgoaiTeId = VnsConvert.CGuid(obj.GiaTri);
                }
            }

            General.lstThamSo = lstInfo;
        }

        #endregion

        #region He Thong
        private void BarDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Thread.CurrentPrincipal = null;
            FrmLogin frmLogin = (FrmLogin)ObjectFactory.GetObject("frmLogin");
            frmLogin.ShowDialog();
        }

        private void barDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmLogin frmLogin = (FrmLogin)ObjectFactory.GetObject("frmLogin");
            frmLogin.ShowDialog();
        }

        private void barBackUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //FrmBackupDuLieu frm = ObjectFactory.GetObject("FrmBackupDuLieu") as FrmBackupDuLieu;
            //frm.ShowDialog();
            BackupDatabase frm = new BackupDatabase();
            frm.ShowDialog();
           
        }

        private void barRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmKhoiPhucDuLieu frm = ObjectFactory.GetObject("FrmKhoiPhucDuLieu") as FrmKhoiPhucDuLieu;
            frm.ShowDialog();
        }

        private void barThamSo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThamSoHeThong FrmThamSoHeThong = (frmThamSoHeThong)ObjectFactory.GetObject("frmThamSoHeThong");
            FrmThamSoHeThong.Show();
        }

        private void barNamKt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmNamKeToan frm = ObjectFactory.GetObject("frmNamKeToan") as FrmNamKeToan;
            frm.ShowDialog();
        }

        private void barThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn thoát ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Application.Exit();
            }
        }

        #endregion

        #region Danh Muc

        private void barDmMtm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmMucTieuMuc frmMucTieuMuc = (FrmMucTieuMuc)ObjectFactory.GetObject("frmMucTieuMuc");
            frmMucTieuMuc.Show();
        }

        private void barDmQg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDMQuocGia frmDMQuocGia = (FrmDMQuocGia)ObjectFactory.GetObject("frmDMQuocGia");
            frmDMQuocGia.Show();
        }

        private void BarDmDM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDinhMuc frmDinhMuc = (FrmDinhMuc)ObjectFactory.GetObject("frmDinhMuc");
            frmDinhMuc.Show();
        }

        private void BarDmHt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDMHeThong frmDMHeThong = (FrmDMHeThong)ObjectFactory.GetObject("frmDMHeThong");
            frmDMHeThong.Show();
        }

        private void barDmLoaiDV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmLoaiDoanRa frmLoaiDoanRa = (FrmLoaiDoanRa)ObjectFactory.GetObject("frmLoaiDoanRa");
            frmLoaiDoanRa.Show();
        }

        private void BarDmCv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDMChucVu frmDanhMucChucVu = (FrmDMChucVu)ObjectFactory.GetObject("frmChucVu");
            frmDanhMucChucVu.Show();
        }

        private void BarDmDv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDonVi frmDonVi = (FrmDonVi)ObjectFactory.GetObject("frmDonVi");
            frmDonVi.Show();
        }

        private void barDmKh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhMucKhachHang frm = ObjectFactory.GetObject("frmDanhMucKhachHang") as frmDanhMucKhachHang;
            frm.ShowDialog();
        }

        #endregion

        #region Du Toan - Quyet Toan
        private void BarDoanCt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDSDoanCongTac frmDSDoanCongTac = (FrmDSDoanCongTac)ObjectFactory.GetObject("frmDSDoanCongTac");
            frmDSDoanCongTac.ShowDialog();
        }

        private void BarDT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDuToan frmDuToan = (FrmDuToan)ObjectFactory.GetObject("frmDuToan");
            frmDuToan.ShowDialog();
        }

        private void BarQt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmQuyetToanDoan frmQuyetToanDoan = (FrmQuyetToanDoan)ObjectFactory.GetObject("frmQuyetToanDoan");
            frmQuyetToanDoan.AccessibleDescription = "QT";
            frmQuyetToanDoan.ShowDialog();
        }

        #endregion

        #region Phieu - Giao Dich
        private void barPt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmUyNhiemChi FrmTamUng = (FrmUyNhiemChi)ObjectFactory.GetObject("frmUyNhiemChi");

            FrmTamUng.AccessibleDescription = "NPT";
            FrmTamUng.Show();
        }

        private void barPc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmUyNhiemChi FrmTamUng = (FrmUyNhiemChi)ObjectFactory.GetObject("frmUyNhiemChi");

            FrmTamUng.AccessibleDescription = "NPC";
            FrmTamUng.Show();
        }

        private void barGbn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmUyNhiemChi FrmTamUng = (FrmUyNhiemChi)ObjectFactory.GetObject("frmUyNhiemChi");

            FrmTamUng.AccessibleDescription = "GBN";
            FrmTamUng.Show();
        }      

        //private void BarTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    FrmTamUng FrmTamUng = (FrmTamUng)ObjectFactory.GetObject("frmTamUng");

        //    FrmTamUng.AccessibleDescription = "TU";
        //    FrmTamUng.Show();
        //}

        //private void BarHu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    FrmTamUng FrmTamUng = (FrmTamUng)ObjectFactory.GetObject("frmTamUng");
        //    FrmTamUng.AccessibleDescription = "HU";
        //    FrmTamUng.Show();
        //}

        //private void BarUNc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    FrmUyNhiemChi frm = (FrmUyNhiemChi)ObjectFactory.GetObject("frmUyNhiemChi");
        //    frm.AccessibleDescription = "UNC";
        //    frm.Show();
        //}

        private void BarTk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSearchChungTu frm = ObjectFactory.GetObject("frmSearchChungTu") as frmSearchChungTu;
            frm.ShowDialog();
        }

        private void barTyGia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmTinhTyGia frm = ObjectFactory.GetObject("FrmTinhTyGia") as FrmTinhTyGia;
            frm.ShowDialog();
        }
        
        #endregion

        #region Bao Cao
        private void bar01Dr_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportByThangNam frm01 = (frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
            frm01.AccessibleDescription = "01DN";
            frm01.Tag = e.Item.Caption;
            frm01.ShowDialog();
        }

        private void bar02Dr_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            frmReportByLoaiDR frm02 = (frmReportByLoaiDR)ObjectFactory.GetObject("frmReportByLoaiDR");
            frm02.AccessibleDescription = "02DN";
            frm02.Tag = e.Item.Caption;
            frm02.ShowDialog();
        }

        private void Bar03Dr01_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportByLoaiDR frm03 = (frmReportByLoaiDR)ObjectFactory.GetObject("frmReportByLoaiDR");
            frm03.AccessibleDescription = "03DN";
            frm03.Tag = e.Item.Caption;
            frm03.ShowDialog();
        }

        private void bar03Dr02_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportByLoaiDR frm031 = (frmReportByLoaiDR)ObjectFactory.GetObject("frmReportByLoaiDR");
            frm031.AccessibleDescription = "03DR_LDR";
            frm031.Tag = e.Item.Caption;
            frm031.ShowDialog();
        }

        private void bar04Dr01_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportByLoaiDR frm04 = (frmReportByLoaiDR)ObjectFactory.GetObject("frmReportByLoaiDR");
            frm04.AccessibleDescription = "04DN";
            frm04.Tag = e.Item.Caption;
            frm04.ShowDialog();
        }

        private void bar04Dr02_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportByLoaiDR frm041 = (frmReportByLoaiDR)ObjectFactory.GetObject("frmReportByLoaiDR");
            frm041.AccessibleDescription = "04DR_LDR";
            frm041.Tag = e.Item.Caption;
            frm041.ShowDialog();
        }

        private void bar06Dr_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportByThangNam frm05 = (frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
            frm05.AccessibleDescription = "05DN";
            frm05.Tag = e.Item.Caption;
            frm05.ShowDialog();
        }

        private void bar06Dr01_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportByThangNam frm06 = (frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
            frm06.AccessibleDescription = "06DN1";
            frm06.Tag = e.Item.Caption;
            frm06.ShowDialog();
        }

        private void bar06Dr02_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportByThangNam frm061 = (frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
            frm061.AccessibleDescription = "06DN2";
            frm061.Tag = e.Item.Caption;
            frm061.ShowDialog();
        }

        private void barSoCttk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSoCTTaiKhoan frmctTK = (frmSoCTTaiKhoan)ObjectFactory.GetObject("frmSoCTTaiKhoan");
            frmctTK.AccessibleDescription = "CTTK";
            frmctTK.Tag = e.Item.Caption;
            frmctTK.ShowDialog();
        }

        private void barBktu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportByThangNam barRPBangKeTU = (frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
            barRPBangKeTU.AccessibleDescription = "barRPBangKeTU";
            barRPBangKeTU.Tag = e.Item.Caption;
            barRPBangKeTU.ShowDialog();
        }

        private void barbkqt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportByThangNam barRpBangKeQT = (frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
            barRpBangKeQT.AccessibleDescription = "barRpBangKeQT";
            barRpBangKeQT.Tag = e.Item.Caption;
            barRpBangKeQT.ShowDialog();
        }

        private void barbkctgs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportByThangNam barRpCtGhiSoQT = (frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
            barRpCtGhiSoQT.AccessibleDescription = "barRpCtGhiSoQT";
            barRpCtGhiSoQT.Tag = e.Item.Caption;
            barRpCtGhiSoQT.ShowDialog();
        }

        private void barbangkethtu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportByThangNam barCtGhiSoHoanTU = (frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
            barCtGhiSoHoanTU.AccessibleDescription = "barCtGhiSoHoanTU";
            barCtGhiSoHoanTU.Tag = e.Item.Caption;
            barCtGhiSoHoanTU.ShowDialog();
        }

        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            KhoiTaoHeThong();
            LoadThamSoBaoCao();
            barsttNamKt.Caption = "Năm " + General.NamKeToan.ToString();
        }

        private void barKTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmUyNhiemChi FrmTamUng = (FrmUyNhiemChi)ObjectFactory.GetObject("frmUyNhiemChi");

            FrmTamUng.AccessibleDescription = "KTK";
            FrmTamUng.Show();
        }

        private void BarGbc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmUyNhiemChi FrmTamUng = (FrmUyNhiemChi)ObjectFactory.GetObject("frmUyNhiemChi");

            FrmTamUng.AccessibleDescription = "GBC";
            FrmTamUng.Show();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Reports.FrmReportBangKeCt frm = new Reports.FrmReportBangKeCt();
            frm.Show();
        }

        private void barChungTuGhiSo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Reports.FrmChungTuGhiSo frm = new FrmChungTuGhiSo();
            frm.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportByThangNam frm01 = (frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
            frm01.AccessibleDescription = "PB_QT";
            frm01.Tag = e.Item.Caption;
            frm01.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportByThangNam frm01 = (frmReportByThangNam)ObjectFactory.GetObject("frmReportByThangNam");
            frm01.AccessibleDescription = "PB_TH_QT";
            frm01.Tag = e.Item.Caption;
            frm01.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportByLoaiDR frm04 = (frmReportByLoaiDR)ObjectFactory.GetObject("frmReportByLoaiDR");
            frm04.AccessibleDescription = "PB_TH_KP";
            frm04.Tag = e.Item.Caption;
            frm04.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportByLoaiDR frm04 = (frmReportByLoaiDR)ObjectFactory.GetObject("frmReportByLoaiDR");
            frm04.AccessibleDescription = "PB_TH_KP_LDR";
            frm04.Tag = e.Item.Caption;
            frm04.ShowDialog();
        }

        private void barQuanTriNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmQuanTriNguoiDung FrmQuanTriNguoiDung = (FrmQuanTriNguoiDung)ObjectFactory.GetObject("FrmQuanTriNguoiDung");
            FrmQuanTriNguoiDung.Show();
        }

        private void btPhieuThuVND_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmUyNhiemChi FrmTamUng = (FrmUyNhiemChi)ObjectFactory.GetObject("frmUyNhiemChi");

            FrmTamUng.AccessibleDescription = "PT_VND";
            FrmTamUng.Show();
        }

        private void btPhieuChiVND_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmUyNhiemChi FrmTamUng = (FrmUyNhiemChi)ObjectFactory.GetObject("frmUyNhiemChi");

            FrmTamUng.AccessibleDescription = "PC_VND";
            FrmTamUng.Show();
        }

        private void btGiayBaoNoVND_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmUyNhiemChi FrmTamUng = (FrmUyNhiemChi)ObjectFactory.GetObject("frmUyNhiemChi");

            FrmTamUng.AccessibleDescription = "GBN_VND";
            FrmTamUng.Show();
        }

        private void btGiayBaoCoVND_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmUyNhiemChi FrmTamUng = (FrmUyNhiemChi)ObjectFactory.GetObject("frmUyNhiemChi");

            FrmTamUng.AccessibleDescription = "GBC_VND";
            FrmTamUng.Show();
        } 
    }
}