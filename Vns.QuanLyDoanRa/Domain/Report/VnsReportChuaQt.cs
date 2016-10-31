using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
    public class VnsReportChuaQt   
    {
        private Guid _loaiDoanRaId;

        public Guid LoaiDoanRaId
        {
            get { return _loaiDoanRaId; }
            set { _loaiDoanRaId = value; }
        }
        private String _TenLoaiDoanRa;

        public String TenLoaiDoanRa
        {
            get { return _TenLoaiDoanRa; }
            set { _TenLoaiDoanRa = value; }
        }
        private Guid _DoanRaId;

        public Guid DoanRaId
        {
            get { return _DoanRaId; }
            set { _DoanRaId = value; }
        }
        private String _TenDoan;

        public String TenDoan
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

        private String _NuocCongTac;

        public String NuocCongTac
        {
            get { return _NuocCongTac; }
            set { _NuocCongTac = value; }
        }
       
        private String _TruongDoan;

        public String TruongDoan
        {
            get { return _TruongDoan; }
            set { _TruongDoan = value; }
        }
        
        private String _ThangDuyetDt;
        public String ThangDuyetDt
        {
            get { return _ThangDuyetDt; }
            set { _ThangDuyetDt = value; }
        }
        
        private String _SoTbDt;
        public String SoTbDt
        {
            get { return _SoTbDt; }
            set { _SoTbDt = value; }
        }

        private decimal _DtDuocDuyet;
        public decimal DtDuocDuyet
        {
            get { return _DtDuocDuyet; }
            set { _DtDuocDuyet = value; }
        }

        public virtual decimal DuToanDuocDuyetVND { get; set; }

        private String _NguoiTamUng;

        public String NguoiTamUng
        {
            get { return _NguoiTamUng; }
            set { _NguoiTamUng = value; }
        }

        public decimal TongUSD
        {
            get { return _TienMatUSD + _ChuyenKhoanUSD; }
            
        }

        public decimal TongVND
        {
            get { return _TienMatVND + _ChuyenKhoanVND + TienTamUngVND; }
        }

        private decimal _TienMatUSD;
        public decimal TienMatUSD
        {
            get { return _TienMatUSD; }
            set { _TienMatUSD = value; }
        }

        private decimal _TienMatTG;
        public decimal TienMatTG
        {
            get {
                if (_TienMatUSD == 0)
                    return 0;
                else
                    return _TienMatVND / _TienMatUSD;
            }
        }

        private decimal _TienMatVND;
        public decimal TienMatVND
        {
            get { return _TienMatVND; }
            set { _TienMatVND = value; }
        }
        
        private decimal _ChuyenKhoanUSD;
        public decimal ChuyenKhoanUSD
        {
            get { return _ChuyenKhoanUSD; }
            set { _ChuyenKhoanUSD = value; }
        }
        
        private decimal _ChuyenKhoanTG;
        public decimal ChuyenKhoanTG
        {
            get
            {
                if (_ChuyenKhoanUSD == 0)
                    return 0;
                else
                    return _ChuyenKhoanVND / _ChuyenKhoanUSD;
            }
        }

        private decimal _ChuyenKhoanVND;
        public decimal ChuyenKhoanVND
        {
            get { return _ChuyenKhoanVND; }
            set { _ChuyenKhoanVND = value; }
        }

        #region Thong tin bo sung them SoTienTamUngVND
        public virtual decimal TienTamUngVND { get; set; }
        #endregion

        private DateTime _NgayQt;
        public DateTime NgayQt
        {
            get { return _NgayQt; }
            set { _NgayQt = value; }
        }
        private DateTime _NgayDt;
        public DateTime NgayDt
        {
            get { return _NgayDt; }
            set { _NgayDt = value; }
        }
        public VnsReportChuaQt(VnsDoanCongTac obj)
        {
            _loaiDoanRaId = obj.LoaiDoanRaId;
            _TenLoaiDoanRa = obj.TenLoaiDoanRa;
            _DoanRaId = obj.Id;
            _TenDoan = obj.Ten;
            _TenDoanVietTat = obj.TenVietTat;
            _NuocCongTac = GetLichCongTac(obj.DanhSachLichCongTac);
            _TruongDoan = obj.TenTruongDoan;
            _ThangDuyetDt = obj.DanhSachDuToanDoan.Count > 0 ? obj.DanhSachDuToanDoan[0].NgayDuToan.ToString("MM/yyyy") : "";
            _DtDuocDuyet = GetSoTienDuToan(obj.DanhSachDuToanDoan);
            DuToanDuocDuyetVND = GetSoTienDuToanVND(obj.DanhSachDuToanDoan);
            _SoTbDt = obj.SoThongBaoDuToan;
            _NgayQt = obj.NgayQuyetToan;
            _NgayDt = obj.DanhSachDuToanDoan.Count > 0 ? obj.DanhSachDuToanDoan[0].NgayDuToan : DateTime.MaxValue;
        }

        private decimal GetSoTienDuToan(IList<VnsDuToanDoan> lst)
        {
            decimal sotienQt = 0;
            foreach (VnsDuToanDoan objQt in lst)
            {
                sotienQt += objQt.SoTienDuToan;
            }
            return sotienQt;
        }

        private decimal GetSoTienDuToanVND(IList<VnsDuToanDoan> lst)
        {
            decimal sotienQt = 0;
            foreach (VnsDuToanDoan objQt in lst)
            {
                sotienQt += objQt.SoTienDuToanVND;
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
    }
}
