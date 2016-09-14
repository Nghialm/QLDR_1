using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
    public class ViewQuyetToan
    {
        private string _TenDoan;

        public string TenDoan
        {
            get { return _TenDoan; }
            set { _TenDoan = value; }
        }

        private string _TenDoanVietTat;
        public string TenDoanVietTat
        {
            get { return _TenDoanVietTat; }
            set { _TenDoanVietTat = value; }
        }
        private string _CongTacTaiNuoc;

        public string CongTacTaiNuoc
        {
            get { return _CongTacTaiNuoc; }
            set { _CongTacTaiNuoc = value; }
        }
        private string _TruongDoan;
        public string TruongDoan
        {
            get { return _TruongDoan; }
            set { _TruongDoan = value; }
        }

        private string _SoNguoiDi;
        public string SoNguoiDi
        {
            get { return _SoNguoiDi; }
            set { _SoNguoiDi = value; }
        }
        private string _PhieuChiSo;
        public string PhieuChiSo
        {
            get { return _PhieuChiSo; }
            set { _PhieuChiSo = value; }
        }

        private string _SoTBQuyetToan;
        public string SoTBQuyetToan
        {
            get { return _SoTBQuyetToan; }
            set { _SoTBQuyetToan = value; }
        }

        private decimal _TienQuyetToan;
        public decimal TienQuyetToan
        {
            get { return _TienQuyetToan; }
            set { _TienQuyetToan = value; }
        }
        private decimal _TongUSD;

        public decimal TongUSD
        {
            get { return _TongUSD; }
            set { _TongUSD = value; }
        }
        private decimal _TongSoVND;

        public decimal TongSoVND
        {
            get { return _TongSoVND; }
            set { _TongSoVND = value; }
        }
        private decimal _TienMatUSD;

        public decimal TienMatUSD
        {
            get { return _TienMatUSD; }
            set { _TienMatUSD = value; }
        }
        private decimal _TienMatVND;

        public decimal TienMatVND
        {
            get { return _TienMatVND; }
            set { _TienMatVND = value; }
        }
        private decimal _TyGiaTienMat;

        public decimal TyGiaTienMat
        {
            get { return _TyGiaTienMat; }
            set { _TyGiaTienMat = value; }
        }
        private decimal _ChuyenKhoanUSD;

        public decimal ChuyenKhoanUSD
        {
            get { return _ChuyenKhoanUSD; }
            set { _ChuyenKhoanUSD = value; }
        }
        private decimal _ChuyenKhoanVND;

        public decimal ChuyenKhoanVND
        {
            get { return _ChuyenKhoanVND; }
            set { _ChuyenKhoanVND = value; }
        }
        private decimal _TyGiaChuyenKhoan;

        public decimal TyGiaChuyenKhoan
        {
            get { return _TyGiaChuyenKhoan; }
            set { _TyGiaChuyenKhoan = value; }
        }

        private string _NguonKinhPhi;//LoaiDoanRa
        public string NguonKinhPhi
        {
            get { return _NguonKinhPhi; }
            set { _NguonKinhPhi = value; }
        }

        private string _NguoiThanhToan;
        public string NguoiThanhToan
        {
            get { return _NguoiThanhToan; }
            set { _NguoiThanhToan = value; }
        }

        private string _ThoiGianDuyetDuToan;
        public string ThoiGianDuyetDuToan
        {
            get { return _ThoiGianDuyetDuToan; }
            set { _ThoiGianDuyetDuToan = value; }
        }
        // Thu Hoan QT
        private decimal _ThuHoanTUQTTienMatUSD;
        public decimal ThuHoanTUQTTienMatUSD
        {
            get { return _ThuHoanTUQTTienMatUSD; }
            set { _ThuHoanTUQTTienMatUSD = value; }
        }
        
        private decimal _ThuHoanTUQTTienMatVND;
        public decimal ThuHoanTUQTTienMatVND
        {
            get { return _ThuHoanTUQTTienMatVND; }
            set { _ThuHoanTUQTTienMatVND = value; }
        }
       
        private decimal _ThuHoanTUQTTienMatTyGia;
        public decimal ThuHoanTUQTTienMatTyGia
        {
            get { return _ThuHoanTUQTTienMatTyGia; }
            set { _ThuHoanTUQTTienMatTyGia = value; }
        }

        private decimal _ThuHoanTUQTTienMatVNDThangTruoc;
        public decimal ThuHoanTUQTTienMatVNDThangTruoc
        {
            get { return _ThuHoanTUQTTienMatVNDThangTruoc; }
            set { _ThuHoanTUQTTienMatVNDThangTruoc = value; }
        }
       
        private decimal _ThuHoanTUQTTienMatUSDThangTruoc;
        public decimal ThuHoanTUQTTienMatUSDThangTruoc
        {
            get { return _ThuHoanTUQTTienMatUSDThangTruoc; }
            set { _ThuHoanTUQTTienMatUSDThangTruoc = value; }
        }
     
        private decimal _ThuHoanTUQTTyGiaThangTruoc;
        public decimal ThuHoanTUQTTyGiaThangTruoc
        {
            get { return _ThuHoanTUQTTyGiaThangTruoc; }
            set { _ThuHoanTUQTTyGiaThangTruoc = value; }
        }
     
        private decimal _CKChiQTUSD;
        public decimal CKChiQTUSD
        {
            get { return _CKChiQTUSD; }
            set { _CKChiQTUSD = value; }
        }

        private decimal _TyGiaCKChiQT;
        public decimal TyGiaCKChiQT
        {
            get { return _TyGiaCKChiQT; }
            set { _TyGiaCKChiQT = value; }
        }

        private decimal _CKChiQTVND;
        public decimal CKChiQTVND
        {
            get { return _CKChiQTVND; }
            set { _CKChiQTVND = value; }
        }

        private decimal _TienMatChiQTUSD;
        public decimal TienMatChiQTUSD
        {
            get { return _TienMatChiQTUSD; }
            set { _TienMatChiQTUSD = value; }
        }

        private decimal _TienMatTyGiaChiQT;
        public decimal TienMatTyGiaChiQT
        {
            get { return _TienMatTyGiaChiQT; }
            set { _TienMatTyGiaChiQT = value; }
        }

        private decimal _TienMatChiQTVND;
        public decimal TienMatChiQTVND
        {
            get { return _TienMatChiQTVND; }
            set { _TienMatChiQTVND = value; }
        }

        private decimal _TongSoUSDSoQT;
        public decimal TongSoUSDSoQT
        {
            get { return _TongSoUSDSoQT; }
            set { _TongSoUSDSoQT = value; }
        }

        private decimal _TongSoVNDSoQT;
        public decimal TongSoVNDSoQT
        {
            get { return _TongSoVNDSoQT; }
            set { _TongSoVNDSoQT = value; }
        }

        private decimal _TienMatUSDSoQT;
        public decimal TienMatUSDSoQT
        {
            get { return _TienMatUSDSoQT; }
            set { _TienMatUSDSoQT = value; }
        }

        private decimal _TienMatTyGiaSoQT;
        public decimal TienMatTyGiaSoQT
        {
            get { return _TienMatTyGiaSoQT; }
            set { _TienMatTyGiaSoQT = value; }
        }

        private decimal _TienMatVNDSoQT;
        public decimal TienMatVNDSoQT
        {
            get { return _TienMatVNDSoQT; }
            set { _TienMatVNDSoQT = value; }
        }

        private decimal _ChuyenKhoanUSDSoQT;
        public decimal ChuyenKhoanUSDSoQT
        {
            get { return _ChuyenKhoanUSDSoQT; }
            set { _ChuyenKhoanUSDSoQT = value; }
        }
      
        private decimal _ChuyenKhoanVNDSoQT;
        public decimal ChuyenKhoanVNDSoQT
        {
            get { return _ChuyenKhoanVNDSoQT; }
            set { _ChuyenKhoanVNDSoQT = value; }
        }
     
        private decimal _ChuyenKhoanTyGiaSoQT;
        public decimal ChuyenKhoanTyGiaSoQT
        {
            get { return _ChuyenKhoanTyGiaSoQT; }
            set { _ChuyenKhoanTyGiaSoQT = value; }
        }
       
        private decimal _TM6801;
        public decimal TM6801
        {
            get { return _TM6801; }
            set { _TM6801 = value; }
        }

        private decimal _TM6802;
        public decimal TM6802
        {
            get { return _TM6802; }
            set { _TM6802 = value; }
        }

        private decimal _TM6803;
        public decimal TM6803
        {
            get { return _TM6803; }
            set { _TM6803 = value; }
        }

        private decimal _TM6804;
        public decimal TM6804
        {
            get { return _TM6804; }
            set { _TM6804 = value; }
        }

        private decimal _TM6805;
        public decimal TM6805
        {
            get { return _TM6805; }
            set { _TM6805 = value; }
        }

        private decimal _TM6806;
        public decimal TM6806
        {
            get { return _TM6806; }
            set { _TM6806 = value; }
        }

        private decimal _TM6849;
        public decimal TM6849
        {
            get { return _TM6849; }
            set { _TM6849 = value; }
        }

        private decimal _PhaiThuUSD;
        public decimal PhaiThuUSD
        {
            get { return _PhaiThuUSD; }
            set { _PhaiThuUSD = value; }
        }

        private decimal _TyGiaPhaiThu;
        public decimal TyGiaPhaiThu
        {
            get { return _TyGiaPhaiThu; }
            set { _TyGiaPhaiThu = value; }
        }

        private decimal _PhaiThuVND;
        public decimal PhaiThuVND
        {
            get { return _PhaiThuVND; }
            set { _PhaiThuVND = value; }
        }

        private decimal _PhaiTraUSD;
        public decimal PhaiTraUSD
        {
            get { return _PhaiTraUSD; }
            set { _PhaiTraUSD = value; }
        }

        private int _CoPhatSinh;
        public int CoPhatSinh
        {
            get { return _CoPhatSinh; }
            set { _CoPhatSinh = value; }
        }
    }
}
