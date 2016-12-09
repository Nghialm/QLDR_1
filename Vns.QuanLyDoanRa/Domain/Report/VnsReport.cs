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

        #region bang ke quyet toan doan
        private decimal _TienQt_TM;
        public decimal TienQt_TM
        {
            get { return _TienQt_TM; }
            set { _TienQt_TM = value; }
        }

        private decimal _TienQt_CK;
        public decimal TienQt_CK
        {
            get { return _TienQt_CK; }
            set { _TienQt_CK = value; }
        }

        private decimal _TienQtVND_TM;
        public decimal TienQtVND_TM
        {
            get { return _TienQtVND_TM; }
            set { _TienQtVND_TM = value; }
        }

        private decimal _TienQTVND_CK;
        public decimal TienQTVND_CK
        {
            get { return _TienQTVND_CK; }
            set { _TienQTVND_CK = value; }
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

        private decimal _TU_VND_TM;
        public decimal TU_VND_TM
        {
            get { return _TU_VND_TM; }
            set { _TU_VND_TM = value; }
        }


        private decimal _TU_VND_CK;
        public decimal TU_VND_CK
        {
            get { return _TU_VND_CK; }
            set { _TU_VND_CK = value; }
        }

        #endregion

        #region Chi QT
        public decimal Chi_Qt_USD
        {
            get
            {
                if (TU_TM_USD < TienQt_TM) return TienQt_TM - TU_TM_USD;
                else return 0;
            }
        }

        public decimal Chi_Qt_VND_TM
        {
            get
            {
                if (TU_TM_VND < TienQtVND_TM) return TienQtVND_TM - TU_VND_TM;
                else return 0;
            }
        }

        public decimal Chi_Qt_VND_CK
        {
            get
            {
                if (TU_VND_CK < TienQTVND_CK) return TienQTVND_CK - TU_VND_CK;
                else return 0;
            }
        }
        #endregion

        #region Thu QT
        public decimal Thu_QT_USD
        {
            get
            {
                if (TU_TM_USD > TienQt_TM) return TU_TM_USD - TienQt_TM;
                else return 0;
            }
        }

        public decimal Thu_Qt_VND_TM
        {
            get
            {
                if (TU_TM_VND > TienQtVND_TM) return TU_VND_TM - TienQtVND_TM;
                else return 0;
            }
        }

        public decimal Thu_Qt_VND_CK
        {
            get
            {
                if (TU_VND_CK > TienQTVND_CK) return TU_VND_CK - TienQTVND_CK;
                else return 0;
            }
        }
        #endregion



        #region Ham tao

        public VnsReport(VnsDoanCongTac objDoanCongTac, DateTime tu_ngay, DateTime den_ngay)
        {
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
            GetSoTienQuyetToan(objDoanCongTac.DanhSachQuyetToanDoan);

            if (objDoanCongTac.DanhSachDuToanDoan.Count > 0) // DUng bo =0
                _ThangDuyetDt = objDoanCongTac.DanhSachDuToanDoan[0].NgayDuToan;

        }

        private void GetSoTienQuyetToan(IList<VnsQuyetToanDoan> lst)
        {
            decimal sotienQt_TM = 0, sotienQt_CK =0;
            decimal sotienQtVND_TM = 0, sotienQtVND_CK = 0;

            foreach (VnsQuyetToanDoan objQt in lst)
            {
                if (objQt.NgoaiTeId == Globals.NgoaiTeId)
                {
                    if (objQt.MaTk == Globals.TkThanhToanTienMat)
                        sotienQt_TM += objQt.SoTien;
                    else if (objQt.MaTk == Globals.TkThanhToanChuyenKhoan)
                        sotienQt_CK += objQt.SoTien;
                }
                else if (objQt.NgoaiTeId == Globals.NoiTeId)
                {
                    if (objQt.MaTk == Globals.TkThanhToanTienMat)
                        sotienQtVND_TM += objQt.SoTienVND;
                    else if (objQt.MaTk == Globals.TkThanhToanChuyenKhoan)
                        sotienQtVND_CK += objQt.SoTienVND;
                }
            }

            _TienQt_TM = sotienQt_TM;
            _TienQt_CK = sotienQt_CK;

            _TienQtVND_TM = sotienQtVND_TM;
            _TienQTVND_CK = sotienQtVND_CK;
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
    }
}
