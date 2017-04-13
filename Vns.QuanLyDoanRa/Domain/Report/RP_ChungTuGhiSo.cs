using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
    public class RP_ChungTuGhiSo
    {
        private Guid _LoaiDoanRaId;
        public Guid LoaiDoanRaId
        {
            get { return _LoaiDoanRaId; }
            set { _LoaiDoanRaId = value; }
        }

        private Guid _DoanRaId;
        public Guid DoanRaId
        {
            get { return _DoanRaId; }
            set { _DoanRaId = value; }
        }

        public String SoTBDT { get; set; }
        public String SoTBQT { get; set; }

        private string _TenLoaiDoanRa;
        public string TenLoaiDoanRa
        {
            get { return _TenLoaiDoanRa; }
            set { _TenLoaiDoanRa = value; }
        }

        private string _TenDoanRa;
        public string TenDoanRa
        {
            get { return _TenDoanRa; }
            set { _TenDoanRa = value; }
        }

        public decimal TongTien_TM_VND
        {
            get { return TM_VND + CK_VND + CPK_VND; }

        }
        public decimal TongTien_CK_USD
        {
            get
            {
                return TM_USD + CK_USD + CPK_USD;
            }
        }

        private decimal _TM_VND;
        public decimal TM_VND
        {
            get { return _TM_VND; }
            set { _TM_VND = value; }
        }


        private decimal _TM_USD;
        public decimal TM_USD
        {
            get { return _TM_USD; }
            set { _TM_USD = value; }
        }


        private decimal _CK_VND;
        public decimal CK_VND
        {
            get { return _CK_VND; }
            set { _CK_VND = value; }
        }


        private decimal _CK_USD;

        public decimal CK_USD
        {
            get { return _CK_USD; }
            set { _CK_USD = value; }
        }

        private int _SoLuongDoanRa;
        public int SoLuongDoanRa
        {
            get { return _SoLuongDoanRa; }
            set { _SoLuongDoanRa = value; }
        }

        private string _TrichYeu;
        public string TrichYeu
        {
            get { return _TrichYeu; }
            set { _TrichYeu = value; }
        }

        private string _ChungTuKemTheo;
        public string ChungTuKemTheo
        {
            get { return _ChungTuKemTheo; }
            set { _ChungTuKemTheo = value; }
        }

        private string _MaTKNo;
        public string MaTKNo
        {
            get { return _MaTKNo; }
            set { _MaTKNo = value; }
        }
        private string _MaTKCo;
        public string MaTKCo
        {
            get { return _MaTKCo; }
            set { _MaTKCo = value; }
        }

        public string MaTk
        {
            get;
            set;
        }

        public string MaTkTm
        {
            get;
            set;
        }

        public string MaTkCk
        {
            get;
            set;
        }

        public string MaTkK
        {
            get;
            set;
        }

        public decimal CPK_USD
        {
            get;
            set;
        }

        public decimal CPK_VND 
        {
            get;
            set;
        }

        public decimal CPK_TyGia
        { get; set; }

        public decimal CPK_Tong 
        {
            get 
            {
                return CPK_USD + CPK_VND;
            }
        }
        public RP_ChungTuGhiSo(RP_SoDuTaiKhoan obj, int GiaTri, string strThoiGian, string TenLoaiDoanRa, string TenDoanRa, int countDr, int ctGoc)//(VnsReport obj, int giatri)
        {
            // 1: nhan vien tu bo tai chinh
            // 2: tam ung
            // 3: quyet toan
            // 4: chi quyet toan
            // 5: thu quyet toan
            // 6: rut tien mat
            _LoaiDoanRaId = obj.LoaiDoanRaId;
            _DoanRaId = obj.DoanRaId;
            _TenLoaiDoanRa = TenLoaiDoanRa;
            _TenDoanRa = TenDoanRa;
            _ChungTuKemTheo = "Kèm theo " + ctGoc.ToString() + " bộ chứng từ gốc";
            switch (GiaTri)
            {
                // tien tu bo tai chinh
                case 1:
                    MaTkTm = Globals.TkTienMat;
                    MaTkCk = Globals.TkTienChuyenKhoanVND;
                    MaTk = Globals.TkThuNganSach;
                    MaTkK = Globals.TkNghiepVuChiHoatDong;
                    _TrichYeu = "Bộ Tài chính cấp kinh phí bổ sung đoàn ra các Ban đảng để thanh toán các đoàn đi công tác nước ngoài bằng tiền mặt, chuyển khoản, ngoại tệ (USD)";
                    if (obj.MaTkCo.StartsWith(Globals.TkThuNganSach) && obj.MaTkNo.StartsWith(Globals.TkTienMat))
                    {
                        _TM_USD = obj.PsTangUSD;
                        _TM_VND = obj.PsTangVND;
                    }
                    if (obj.MaTkCo.StartsWith(Globals.TkThuNganSach) && obj.MaTkNo.StartsWith(Globals.TkTienChuyenKhoanVND))
                    {
                        //_CK_USD = obj.PsTangUSD;
                        _CK_VND = obj.PsTangVND;
                    }
                    if (obj.MaTkCo.StartsWith(Globals.TkThuNganSach) && obj.MaTkNo.StartsWith(Globals.TkNghiepVuChiHoatDong))
                    {
                        CPK_USD = obj.PsTangUSD;
                        CPK_VND = obj.PsTangVND;
                    }
                    break;
                case 2: // Tam Ung
                    MaTkTm = Globals.TkTienMatVND;
                    MaTkCk = Globals.TkTienChuyenKhoanVND;
                    //MaTk
                    MaTkK = Globals.TkTienMat;
                    MaTk = Globals.TkTamUng;
                    _TrichYeu = "Xuất quỹ tiền mặt, chuyển khoản bằng ngoại tệ( USD) cho các cơ quan, đơn vị ở Trung ương đi công tác nước ngoài, Tổng số " + countDr.ToString() + " đoàn";
                    if (obj.MaTkCo.StartsWith(Globals.TkTienMatVND))
                    {
                        //_TM_USD = obj.PsTangUSD;
                        _TM_VND = obj.PsTangVND;
                    }
                    if (obj.MaTkCo.StartsWith(Globals.TkTienMat))
                    {
                        CPK_USD = obj.PsTangUSD;
                        CPK_VND = obj.PsTangVND;
                    }
                    if (obj.MaTkCo.StartsWith(Globals.TkTienChuyenKhoanVND))
                    {
                        _CK_VND = obj.PsTangVND;
                        //_CK_USD = obj.PsTangUSD;
                    }
                    break;
                case 3: // Quyet Toan
                    _TrichYeu = "Quyết toán các đoàn " + strThoiGian + " bằng ngoại tệ  (USD) tiền mặt, chuyển khoản vé máy bay của " + countDr.ToString() + " đoàn các cơ quan Trung ương đi công tác nước ngoài.";
                    MaTkTm = Globals.TkThanhToanTienMat_Rp;
                    MaTkCk = Globals.TkThanhToanChuyenKhoan_Rp;
                    //MaTk = Globals.TkTamUng_Rp;
                    MaTk = Globals.TkNghiepVuChiHoatDong;
                    if (obj.MaTkNo.StartsWith(Globals.TkThanhToanTienMat))
                    {
                        _TM_USD = obj.PsTangUSD;
                        _TM_VND += obj.PsTangVND;
                    }
                    if (obj.MaTkNo.StartsWith(Globals.TkThanhToanChuyenKhoan))
                    {
                        _CK_VND = obj.PsTangVND;
                        _CK_USD = obj.PsTangUSD;
                    }
                    break;
                case 4: // Chi Quyet Toan
                    MaTkTm = Globals.TkTienMat_Rp;
                    MaTkCk = Globals.TkTienChuyenKhoan_Rp;
                    MaTk = Globals.TkNghiepVuChiHoatDong;
                    _TrichYeu = "Chi quyết toán đoàn ra bằng ngoại tệ tiền mặt, chuyển khoản ( USD ) các Ban Đảng Trung ương đi công tác nước ngoài, " + countDr.ToString() + " đoàn.";
                    //Quy dinh cpk la chi quyet toan tien USD
                    if (obj.MaTkCo.StartsWith(Globals.TkTienMat))
                    {
                        CPK_USD = obj.PsTangUSD;
                        CPK_VND = obj.PsTangVND;
                    }

                    if (obj.MaTkCo.StartsWith(Globals.TkTienMatVND))
                    {
                        _TM_VND = obj.PsTangVND;
                    }

                    if (obj.MaTkCo.StartsWith(Globals.TkTienChuyenKhoanVND))
                    {
                        _CK_VND = obj.PsTangVND;
                    }
                    break;
                case 5:// Thu QT
                    MaTkTm = Globals.TkTienMat_Rp;
                    MaTkCk = Globals.TkTienChuyenKhoan_Rp;
                    MaTk = Globals.TkTamUng_Rp;
                    _TrichYeu = "Thu chênh lệch Quyết toán/tạm ứng các đoàn ra bằng ngoại tệ (USD) tiền mặt các Ban Đảng Trung ương đi công tác  nước ngoài, " + countDr.ToString() + " đoàn.";
                    if (obj.MaTkNo.StartsWith(Globals.TkTienMatVND) && obj.MaTkCo.StartsWith(Globals.TkTamUng))
                    {
                        //_TM_USD = obj.PsTangUSD;
                        _TM_VND += obj.PsTangVND;
                    }

                    if (obj.MaTkNo.StartsWith(Globals.TkTienMat) && obj.MaTkCo.StartsWith(Globals.TkTamUng))
                    {
                        CPK_USD = obj.PsTangUSD;
                        CPK_VND += obj.PsTangVND;
                    }

                    if (obj.MaTkNo.StartsWith(Globals.TkTienChuyenKhoanVND) && obj.MaTkCo.StartsWith(Globals.TkTamUng))
                    {
                        _CK_VND = obj.PsTangVND;
                        //_CK_USD = obj.PsTangUSD;
                    }
                    break;
                case 6:// Rut tien mat
                    MaTkTm = Globals.TkTienChuyenKhoanVND;
                    //MaTkCk = Globals.Tk;
                    MaTk = Globals.TkTienMatVND;
                    _TrichYeu = "Rút tiền VNĐ (chi các đoàn cơ quan Đảng ở Trung ương đi công tác nước ngoài) từ Kho bạc Nhà nước  vể nhập quỹ tiền mặt trong tháng.";
                    if (obj.MaTkNo.StartsWith(Globals.TkTienMatVND) && obj.MaTkCo.StartsWith(Globals.TkTienChuyenKhoanVND))
                    {
                        //_TM_USD = obj.PsTangUSD;
                        _TM_VND += obj.PsTangVND;
                    }
                    //if (obj.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan) && obj.MaTkCo.StartsWith(Globals.TkTamUng))
                    //{
                    //    _CK_VND = obj.PsTangVND;
                    //    _CK_USD = obj.PsTangUSD;
                    //}
                    break;
            }
        }

        public RP_ChungTuGhiSo(VnsLoaiDoanRa loaiddoanra, int GiaTri, string strThoiGian, int countDr, int ctGoc)
        {
            // 1: nhan vien tu bo tai chinh
            // 2: tam ung
            // 3: quyet toan
            // 4: chi quyet toan
            // 5: thu quyet toan
            _TM_USD = 0;
            _TM_VND = 0;
            _CK_USD = 0;
            _CK_VND = 0;

            _LoaiDoanRaId = loaiddoanra.Id;
            //_DoanRaId = obj.DoanRaId;
            _TenLoaiDoanRa = loaiddoanra.TenLoaiDoanRa;
            //_TenDoanRa = TenDoanRa;
            _ChungTuKemTheo = "Kèm theo " + ctGoc.ToString() + " bộ chứng từ gốc";
            switch (GiaTri)
            {
                // tien tu bo tai chinh
                case 1:
                    MaTkTm = Globals.TkTienMat_Rp;
                    MaTkCk = Globals.TkTienChuyenKhoan_Rp;
                    MaTk = Globals.TkThuNganSach;
                    _TrichYeu = "Bộ Tài chính cấp kinh phí bổ sung đoàn ra các Ban đảng để thanh toán các đoàn đi công tác nước ngoài bằng tiền mặt, chuyển khoản, ngoại tệ (USD)";
                    //_TrichYeu = 
                    break;
                case 2: // Tam Ung
                    MaTkTm = Globals.TkTienMat_Rp;
                    MaTkCk = Globals.TkTienChuyenKhoan_Rp;
                    MaTk = Globals.TkTamUng_Rp;
                    _TrichYeu = "Xuất quỹ tiền mặt, chuyển khoản bằng ngoại tệ( USD) cho các cơ quan, đơn vị ở Trung ương đi công tác nước ngoài, Tổng số " + countDr.ToString() + " đoàn";
                    break;
                case 3: // Quyet Toan
                    _TrichYeu = "Quyết toán các đoàn " + strThoiGian + " bằng ngoại tệ  (USD) tiền mặt, chuyển khoản vé máy bay của " + countDr.ToString() + " đoàn các cơ quan Trung ương đi công tác nước ngoài.";
                    MaTkTm = Globals.TkThanhToanTienMat_Rp;
                    MaTkCk = Globals.TkThanhToanChuyenKhoan_Rp;
                    MaTk = Globals.TkNghiepVuChiHoatDong;
                    break;
                case 4: // Chi Quyet Toan
                    MaTkTm = Globals.TkTienMat_Rp;
                    MaTkCk = Globals.TkTienChuyenKhoan_Rp;
                    MaTk = Globals.TkTamUng_Rp;
                    _TrichYeu = "Chi quyết toán đoàn ra bằng ngoại tệ tiền mặt, chuyển khoản ( USD ) các Ban Đảng Trung ương đi công tác nước ngoài, " + countDr.ToString() + " đoàn.";
                    break;
                case 5:// Thu QT
                    MaTkTm = Globals.TkTienMat_Rp;
                    MaTkCk = Globals.TkTienChuyenKhoan_Rp;
                    MaTk = Globals.TkTamUng_Rp;
                    _TrichYeu = "Thu chênh lệch Quyết toán/tạm ứng các đoàn ra bằng ngoại tệ (USD) tiền mặt các Ban Đảng Trung ương đi công tác  nước ngoài, " + countDr.ToString() + " đoàn.";
                    break;
            }
        }


        
    }
}
