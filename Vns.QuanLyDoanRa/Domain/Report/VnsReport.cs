using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
    public class VnsReport
    {
        #region Phan Chung
        private Guid _DoanRaId;

        public Guid DoanRaId
        {
            get { return _DoanRaId; }
            set { _DoanRaId = value; }
        }
        private string _TenDoanRa;

        public string TenDoanRa
        {
            get { return _TenDoanRa; }
            set { _TenDoanRa = value; }
        }

        private string _TenDoanRaVietTat;
        public string TenDoanRaVietTat
        {
            get { return _TenDoanRaVietTat; }
            set { _TenDoanRaVietTat = value; }
        }
        private Guid _LoaiDoanRaId;

        public Guid LoaiDoanRaId
        {
            get { return _LoaiDoanRaId; }
            set { _LoaiDoanRaId = value; }
        }
        private string _TenLoaiDoanRa;

        public string TenLoaiDoanRa
        {
            get { return _TenLoaiDoanRa; }
            set { _TenLoaiDoanRa = value; }
        }
        private string _NuocCongTac;

        public string NuocCongTac
        {
            get { return _NuocCongTac; }
            set { _NuocCongTac = value; }
        }

        private string _TruongDoan;

        public string TruongDoan
        {
            get { return _TruongDoan; }
            set { _TruongDoan = value; }
        }

        private string _TenTruongDoan;

        public string TenTruongDoan
        {
            get { return _TenTruongDoan; }
            set { _TenTruongDoan = value; }
        }
        private int _SoNguoiDi;

        public int SoNguoiDi
        {
            get { return _SoNguoiDi; }
            set { _SoNguoiDi = value; }
        }
        private DateTime _ThangDuyetDt;

        public DateTime ThangDuyetDt
        {
            get { return _ThangDuyetDt; }
            set { _ThangDuyetDt = value; }
        }

        private DateTime _ThangDuyetQt;

        public DateTime ThangDuyetQt
        {
            get { return _ThangDuyetQt; }
            set { _ThangDuyetQt = value; }
        }

        private string _SoTbQt;

        public string SoTbQt
        {
            get { return _SoTbQt; }
            set { _SoTbQt = value; }
        }
        private decimal _TienQt;

        public decimal TienQt
        {
            get { return _TienQt; }
            set { _TienQt = value; }
        }
        private string _NguoiQt;

        public string NguoiQt
        {
            get { return _NguoiQt; }
            set { _NguoiQt = value; }
        }

        private string _NgayDi;
        public string NgayDi
        {
            get { return _NgayDi; }
            set { _NgayDi = value; }
        }
        #endregion

        #region TAM UNG

        private decimal _TU_TM_VND;

        public decimal TU_TM_VND
        {
            get { return _TU_TM_VND; }
            set { _TU_TM_VND = value; }
        }
        private decimal _TU_TM_USD;

        public decimal TU_TM_USD
        {
            get { return _TU_TM_USD; }
            set { _TU_TM_USD = value; }
        }

        public decimal TU_TM_TG
        {
            get
            {
                if (_TU_TM_USD == 0)
                    return 0;
                else
                    return _TU_TM_VND / _TU_TM_USD;
            }
        }
        private decimal _TU_CK_VND;

        public decimal TU_CK_VND
        {
            get { return _TU_CK_VND; }
            set { _TU_CK_VND = value; }
        }
        private decimal _TU_CK_USD;

        public decimal TU_CK_USD
        {
            get { return _TU_CK_USD; }
            set { _TU_CK_USD = value; }
        }

        public decimal TU_CK_TG
        {
            get
            {
                if (_TU_CK_USD == 0)
                    return 0;
                else
                    return _TU_CK_VND / _TU_CK_USD;
            }
        }

        #endregion

        #region THU HOAN = so tien đã thu sau khi quyet toan

        private decimal _TH_USD;

        public decimal TH_USD
        {
            get { return _TH_USD; }
            set { _TH_USD = value; }
        }

        public decimal TH_TG
        {
            get
            {
                if (_TH_USD == 0)
                    return 0;
                else
                    return _TH_VND / _TH_USD;
            }
        }
        private decimal _TH_VND;

        public decimal TH_VND
        {
            get { return _TH_VND; }
            set { _TH_VND = value; }
        }

        private decimal _TH_CK_USD;

        public decimal TH_CK_USD
        {
            get { return _TH_CK_USD; }
            set { _TH_CK_USD = value; }
        }
        private decimal _TH_CK_VND;

        public decimal TH_CK_VND
        {
            get { return _TH_CK_VND; }
            set { _TH_CK_VND = value; }
        }
        private decimal _TH_TM_USD;

        public decimal TH_TM_USD
        {
            get { return _TH_TM_USD; }
            set { _TH_TM_USD = value; }
        }
        private decimal _TH_TM_VND;

        public decimal TH_TM_VND
        {
            get { return _TH_TM_VND; }
            set { _TH_TM_VND = value; }
        }

        #endregion

        #region CHI QUYET TOAN = So tien phai tra sau khi quyet toan QT_TU >0

        public decimal Chi_QT_CK_USD
        {
            get
            {
                decimal ChiQt = QT_CK_USD - TU_CK_USD;
                if (ChiQt <= 0)
                    return 0;
                else
                    return ChiQt;
            }
        }

        public decimal Chi_QT_CK_TG
        {
            get
            {
                if (Chi_QT_CK_USD == 0)
                    return 0;
                else
                    return Chi_QT_CK_VND / Chi_QT_CK_USD;
            }
        }

        public decimal Chi_QT_CK_VND
        {
            get
            {
                decimal ChiQt = QT_CK_VND - TU_CK_VND;
                if (ChiQt <= 0)
                    return 0;
                else
                    return ChiQt;
            }
        }

        public decimal Chi_QT_TM_USD
        {
            get
            {
                decimal ChiQt = QT_TM_USD - TU_TM_USD;
                if (ChiQt <= 0)
                    return 0;
                else
                    return ChiQt;
            }
        }

        public decimal Chi_QT_TM_TG
        {
            get
            {
                if (Chi_QT_TM_USD == 0)
                    return 0;
                else
                    return Chi_QT_TM_VND / Chi_QT_TM_USD;
            }
        }
        public decimal Chi_QT_TM_VND
        {
            get
            {
                decimal ChiQt = QT_TM_VND - TU_TM_VND;
                if (ChiQt <= 0)
                    return 0;
                else
                    return ChiQt;
            }
        }


        #endregion

        #region SO TIEN DA TRA SAU KHI QT
        private decimal _QT_DT_TM_VND;

        public decimal QT_DT_TM_VND
        {
            get { return _QT_DT_TM_VND; }
            set { _QT_DT_TM_VND = value; }
        }
        private decimal _QT_DT_TM_USD;

        public decimal QT_DT_TM_USD
        {
            get { return _QT_DT_TM_USD; }
            set { _QT_DT_TM_USD = value; }
        }
        private decimal _QT_DT_CK_VND;

        public decimal QT_DT_CK_VND
        {
            get { return _QT_DT_CK_VND; }
            set { _QT_DT_CK_VND = value; }
        }
        private decimal _QT_DT_CK_USD;

        public decimal QT_DT_CK_USD
        {
            get { return _QT_DT_CK_USD; }
            set { _QT_DT_CK_USD = value; }
        }

        public decimal QT_DT_TM_TG
        {
            get
            {
                if (QT_DT_TM_USD == 0)
                    return 0;
                else
                    return QT_DT_TM_VND / QT_DT_TM_USD;
            }
        }

        public decimal QT_DT_CK_TG
        {
            get
            {
                if (QT_DT_CK_USD == 0)
                    return 0;
                else
                    return QT_DT_CK_VND / QT_DT_CK_USD;
            }
        }
        #endregion

        #region SO QUYẾT TOÁN = TU + Chi.QT - Phai.Thu

        private decimal _So_QT_TM_USD;

        public decimal So_QT_TM_USD
        {
            get
            {
                return So_QT_USD_Tong - So_QT_CK_USD;
            }
            set { _So_QT_TM_USD = value; }
        }

        public decimal So_QT_TM_TG
        {
            get
            {
                if (So_QT_TM_USD == 0)
                    return 0;
                else
                    return So_QT_TM_VND / So_QT_TM_USD;
            }
        }
        private decimal _So_QT_TM_VND;

        public decimal So_QT_TM_VND
        {
            get
            {
                return So_QT_VND_Tong - So_QT_CK_VND;
            }
            set { _So_QT_TM_VND = value; }
        }
        private decimal _So_QT_CK_USD;

        public decimal So_QT_CK_USD
        {
            get
            {
                return QT_CK_USD;
            }
            set { _So_QT_CK_USD = value; }
        }

        public decimal So_QT_CK_TG
        {
            get
            {
                if (So_QT_CK_USD == 0)
                    return 0;
                else
                    return So_QT_CK_VND / So_QT_CK_USD;
            }
        }
        private decimal _So_QT_CK_VND;

        public decimal So_QT_CK_VND
        {
            get
            {
                return QT_CK_VND;
            }
            set { _So_QT_CK_VND = value; }
        }

        public decimal So_QT_USD_Tong
        {
            get 
            {
                decimal So_QT_USD_Tong = TongTamUngUSD + QT_DT_TM_USD + QT_DT_CK_USD - CN_PhaiThu_USD;
                return So_QT_USD_Tong;                
            }
        }

        public decimal So_QT_VND_Tong
        {
            get {
                decimal So_QT_VND_Tong = TongTamUngVND + QT_DT_TM_VND + QT_DT_CK_VND - CN_PhaiThu_VND;
                return So_QT_VND_Tong; 
            }
        }

        #endregion

        #region SO THONG BAO QUYET TOAN = Tien Trong Bang Qt
        private decimal _QT_CK_USD;

        public decimal QT_CK_USD
        {
            get { return _QT_CK_USD; }
            set { _QT_CK_USD = value; }
        }

        public decimal QT_CK_TG
        {
            get
            {
                if (_QT_CK_USD == 0)
                    return 0;
                else
                    return _QT_CK_VND / _QT_CK_USD;
            }
        }
        private decimal _QT_CK_VND;

        public decimal QT_CK_VND
        {
            get { return _QT_CK_VND; }
            set { _QT_CK_VND = value; }
        }

        private decimal _QT_TM_USD;

        public decimal QT_TM_USD
        {
            get { return _QT_TM_USD; }
            set { _QT_TM_USD = value; }
        }

        public decimal QT_TM_TG
        {
            get
            {
                if (_QT_TM_USD == 0)
                    return 0;
                else
                    return _QT_TM_VND / QT_TM_USD;
            }
        }
        private decimal _QT_TM_VND;

        public decimal QT_TM_VND
        {
            get { return _QT_TM_VND; }
            set { _QT_TM_VND = value; }
        }

        #endregion

        #region TACH SO QUYET TOAN
        private decimal _M_6801;

        public decimal M_6801
        {
            get { return _M_6801; }
            set { _M_6801 = value; }
        }
        private decimal _M_6802;

        public decimal M_6802
        {
            get { return _M_6802; }
            set { _M_6802 = value; }
        }
        private decimal _M_6803;

        public decimal M_6803
        {
            get { return _M_6803; }
            set { _M_6803 = value; }
        }
        private decimal _M_6804;

        public decimal M_6804
        {
            get { return _M_6804; }
            set { _M_6804 = value; }
        }
        private decimal _M_6805;

        public decimal M_6805
        {
            get { return _M_6805; }
            set { _M_6805 = value; }
        }
        private decimal _M_6806;

        public decimal M_6806
        {
            get { return _M_6806; }
            set { _M_6806 = value; }
        }
        private decimal _M_6849;

        public decimal M_6849
        {
            get { return _M_6849; }
            set { _M_6849 = value; }
        }
        #endregion

        #region SO PHAI THU, PHAI TRA
        public decimal CN_PhaiThu_USD
        {
            get
            {
                decimal PhaiThuUSD = _TienQt + TH_USD - TU_CK_USD - TU_TM_USD; //TU_CK_USD
                if (PhaiThuUSD >= 0)
                    return 0;
                else
                    return Math.Abs(PhaiThuUSD);
            }
        }
        public decimal CN_PhaiThu_TG
        {
            get
            {
                if (CN_PhaiThu_USD == 0)
                    return CN_PhaiThu_USD;
                else
                    return CN_PhaiThu_VND / CN_PhaiThu_USD;
            }
        }

        public decimal CN_PhaiThu_VND
        {
            get
            {
                if (CN_PhaiThu_USD == 0)
                    return 0;
                else
                {
                    decimal tyGia = TongTamUngUSD == 0 ? 0 : TongTamUngVND / TongTamUngUSD;
                    decimal PhaiThuVND = (QT_CK_USD * tyGia) + (QT_TM_USD * tyGia) + TH_VND - TU_CK_VND_MR - TU_TM_VND_MR;
                    if (PhaiThuVND >= 0)
                        return 0;
                    else
                        return Math.Abs(PhaiThuVND);
                }
            }
        }

        public decimal CN_PhaiTra_USD
        {
            get
            {
                decimal PhaiTraUSD = QT_CK_USD + QT_TM_USD - QT_DT_CK_USD - QT_DT_TM_USD - TU_CK_USD_MR - TU_TM_USD_MR;

                if (PhaiTraUSD > 0)
                    return PhaiTraUSD;
                else
                    return 0;
            }
        }

        public decimal CN_PhaiTra_TG
        {
            get
            {
                if (CN_PhaiTra_USD == 0)
                    return 0;
                else
                    return CN_PhaiTra_VND / CN_PhaiTra_USD;
            }
        }

        public decimal CN_PhaiTra_VND
        {
            get
            {
                decimal PhaiTraVND = QT_CK_VND + QT_TM_VND - TH_VND - TU_CK_VND - TU_TM_VND;

                if (PhaiTraVND > 0)
                    return PhaiTraVND;
                else
                    return 0;
            }
        }

        public decimal BK_QT_ChiQT_USD
        {
            get
            {
                decimal PhaiThuUSD = Chi_QT_CK_USD;// _TienQt - TU_HU_Chua_QT_CK_USD - TU_HU_Chua_QT_TM_USD; //Chi_QT_CK_USD
                if (PhaiThuUSD >= 0)
                    return Math.Abs(PhaiThuUSD);
                else
                    return 0;
            }
        }
        public decimal BK_QT_ThuQT_USD
        {
            get
            {
                decimal PhaiThuUSD = _TienQt - TU_HU_Chua_QT_CK_USD - TU_HU_Chua_QT_TM_USD-BK_QT_ChiQT_USD;
                if (PhaiThuUSD < 0)
                    return Math.Abs(PhaiThuUSD);
                else
                    return 0;
            }
        }
        #endregion

        #region Ham tao

        public VnsReport(VnsDoanCongTac objDoanCongTac, DateTime tu_ngay, DateTime den_ngay)
        {
            _TU_NGAY = tu_ngay;
            _DEN_NGAY = den_ngay;
            _DoanRaId = objDoanCongTac.Id;
            _TenDoanRa = objDoanCongTac.Ten;
            _LoaiDoanRaId = objDoanCongTac.LoaiDoanRaId;
            _TenLoaiDoanRa = objDoanCongTac.TenLoaiDoanRa;
            _TruongDoan = objDoanCongTac.TenTruongDoan;
            _TenDoanRaVietTat = objDoanCongTac.TenVietTat;
            _NgayDi = " ngày " + objDoanCongTac.NgayDi.ToString("dd/MM/yyyy");
            _TenTruongDoan = objDoanCongTac.TruongDoan;
            _SoTbQt = objDoanCongTac.SoThongBaoQuyetToan;
            _NuocCongTac = GetLichCongTac(objDoanCongTac.DanhSachLichCongTac);
            _SoNguoiDi = GetTongThanhVien(objDoanCongTac.DanhSachThanhVien);
            _TienQt = GetSoTienQuyetToan(objDoanCongTac.DanhSachQuyetToanDoan);

            if (objDoanCongTac.DanhSachDuToanDoan.Count > 0) // DUng bo =0
                _ThangDuyetDt = objDoanCongTac.DanhSachDuToanDoan[0].NgayDuToan;

            if (objDoanCongTac.DanhSachQuyetToanDoan.Count > 0) // DUng bo =0
            {
                _ThangDuyetQt = objDoanCongTac.DanhSachQuyetToanDoan[0].NgayCt;

                foreach (VnsQuyetToanDoan objQt in objDoanCongTac.DanhSachQuyetToanDoan)
                {
                    if (objQt.objMucTieuMuc.MaMuc.Equals("6801"))
                        _M_6801 += objQt.SoTien;
                    else if (objQt.objMucTieuMuc.MaMuc.Equals("6802"))
                        _M_6802 += objQt.SoTien;
                    else if (objQt.objMucTieuMuc.MaMuc.Equals("6803"))
                        _M_6803 += objQt.SoTien;
                    else if (objQt.objMucTieuMuc.MaMuc.Equals("6804"))
                        _M_6804 += objQt.SoTien;
                    else if (objQt.objMucTieuMuc.MaMuc.Equals("6805"))
                        _M_6805 += objQt.SoTien;
                    else if (objQt.objMucTieuMuc.MaMuc.Equals("6806"))
                        _M_6806 += objQt.SoTien;
                    else if (objQt.objMucTieuMuc.MaMuc.Equals("6849"))
                        _M_6849 += objQt.SoTien;
                }
            }

            else
                _ThangDuyetDt = DateTime.MaxValue;


        }

        private decimal GetSoTienQuyetToan(IList<VnsQuyetToanDoan> lst)
        {
            decimal sotienQt = 0;
            foreach (VnsQuyetToanDoan objQt in lst)
            {
                sotienQt += objQt.SoTien;
            }
            return sotienQt;
        }

        private int GetTongThanhVien(IList<VnsThanhVien> lst)
        {
            int tv = 0;
            foreach (VnsThanhVien obj in lst)
            {
                tv += obj.SoLuong;
            }
            return tv;
        }

        private string GetLichCongTac(IList<VnsLichCongTac> lst)
        {
            string lct = "";
            foreach (VnsLichCongTac obj in lst)
            {
                if (lct == "")
                {
                    lct = obj.objNuocDen.TenNuoc;
                }
                else
                    lct = string.Format("{0}, {1}", lct, obj.objNuocDen.TenNuoc);
            }
            return lct;
        }

        #endregion

        #region Property mo rong

        private DateTime _TU_NGAY;

        public DateTime TU_NGAY
        {
            get { return _TU_NGAY; }
            set { _TU_NGAY = value; }
        }
        private DateTime _DEN_NGAY;

        public DateTime DEN_NGAY
        {
            get { return _DEN_NGAY; }
            set { _DEN_NGAY = value; }
        }

        public decimal TU_TM_USD_MR
        {
            get
            {
                if (_ThangDuyetDt == DateTime.MaxValue)
                    return TU_TM_USD;
                else if (_ThangDuyetQt >= VnsConvert.CStartOfDate(_TU_NGAY) && _ThangDuyetQt <= VnsConvert.CEndOfDate(_DEN_NGAY))
                    return TU_TM_USD;
                else
                    return 0;
            }
        }

        public decimal TU_TM_VND_MR
        {
            get
            {
                if (_ThangDuyetDt == DateTime.MaxValue)
                    return TU_TM_VND;
                else if (_ThangDuyetQt >= VnsConvert.CStartOfDate(_TU_NGAY) && _ThangDuyetQt <= VnsConvert.CEndOfDate(_DEN_NGAY))
                    return TU_TM_VND;
                else
                    return 0;
            }
        }


        public decimal TU_CK_VND_MR
        {
            get
            {
                if (_ThangDuyetDt == DateTime.MaxValue)
                    return TU_CK_VND;
                else if (_ThangDuyetQt >= VnsConvert.CStartOfDate(_TU_NGAY) && _ThangDuyetQt <= VnsConvert.CEndOfDate(_DEN_NGAY))
                    return TU_CK_VND;
                else
                    return 0;
            }
        }

        public decimal TU_CK_USD_MR
        {
            get
            {
                if (_ThangDuyetDt == DateTime.MaxValue)
                    return TU_CK_USD;
                else if (_ThangDuyetQt >= VnsConvert.CStartOfDate(_TU_NGAY) && _ThangDuyetQt <= VnsConvert.CEndOfDate(_DEN_NGAY))
                    return TU_CK_USD;
                else
                    return 0;
            }
        }


        public decimal TU_CK_TG_MR
        {
            get
            {
                if (TU_CK_USD_MR == 0)
                    return 0;
                else
                    return TU_CK_VND_MR / TU_CK_USD_MR;

            }
        }

        public decimal TU_TM_TG_MR
        {
            get
            {
                if (TU_TM_USD_MR == 0)
                    return 0;
                else
                    return TU_TM_VND_MR / TU_TM_USD_MR;
            }
        }

        public decimal TongTamUngVND
        {
            get
            {
                return TU_TM_VND_MR + TU_CK_VND_MR;
            }
        }

        public decimal TongTamUngUSD
        {
            get
            {
                return TU_TM_USD_MR + TU_CK_USD_MR;
            }
        }

        public decimal Tong_QT_USD
        {
            get
            {
                return _QT_TM_USD + _QT_CK_USD;
            }
        }

        public decimal Tong_QT_VND
        {
            get
            {
                return _QT_TM_VND + _QT_CK_VND;
            }
        }

        private decimal _HU_TrongThang_TM_USD;

        public decimal HU_TrongThang_TM_USD
        {
            get { return _HU_TrongThang_TM_USD; }
            set { _HU_TrongThang_TM_USD = value; }
        }

        private decimal _HU_TrongThang_TM_VND;

        public decimal HU_TrongThang_TM_VND
        {
            get { return _HU_TrongThang_TM_VND; }
            set { _HU_TrongThang_TM_VND = value; }
        }

        private decimal _HU_TrongThang_CK_VND;

        public decimal HU_TrongThang_CK_VND
        {
            get { return _HU_TrongThang_CK_VND; }
            set { _HU_TrongThang_CK_VND = value; }
        }
        private decimal _HU_TrongThang_CK_USD;

        public decimal HU_TrongThang_CK_USD
        {
            get { return _HU_TrongThang_CK_USD; }
            set { _HU_TrongThang_CK_USD = value; }
        }

        private decimal _HU_Chua_QT_TM_USD;

        public decimal HU_Chua_QT_TM_USD
        {
            get { return _HU_Chua_QT_TM_USD; }
            set { _HU_Chua_QT_TM_USD = value; }
        }
        private decimal _HU_Chua_QT_TM_VND;

        public decimal HU_Chua_QT_TM_VND
        {
            get { return _HU_Chua_QT_TM_VND; }
            set { _HU_Chua_QT_TM_VND = value; }
        }

        public decimal HU_Chua_QT_TM_TG
        {
            get
            {
                if (_HU_Chua_QT_TM_USD == 0)
                    return 0;
                else
                    return _HU_Chua_QT_TM_VND / _HU_Chua_QT_TM_USD;
            }
        }

        private decimal _HU_Chua_QT_CK_USD;

        public decimal HU_Chua_QT_CK_USD
        {
            get { return _HU_Chua_QT_CK_USD; }
            set { _HU_Chua_QT_CK_USD = value; }
        }
        private decimal _HU_Chua_QT_CK_VND;

        public decimal HU_Chua_QT_CK_VND
        {
            get { return _HU_Chua_QT_CK_VND; }
            set { _HU_Chua_QT_CK_VND = value; }
        }

        public decimal HU_Chua_QT_CK_TG
        {
            get
            {
                if (_HU_Chua_QT_CK_USD == 0)
                    return 0;
                else
                    return _HU_Chua_QT_CK_VND / _HU_Chua_QT_CK_USD;
            }
        }

        public decimal TU_HU_Chua_QT_TM_USD
        {
            get { return TU_TM_USD_MR-HU_Chua_QT_TM_USD; }
            //set { _TU_HU_Chua_QT_TM_USD = value; }
        }

        public decimal TU_HU_Chua_QT_CK_USD
        {
            get { return TU_CK_USD_MR-HU_Chua_QT_CK_USD; }
            //set { _TU_HU_Chua_QT_CK_USD = value; }
        }

        #endregion
    }
}
