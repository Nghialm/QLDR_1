using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
    public class ViewTamUngDoanRa
    {
        public DateTime NgayCt { get; set; }

        private Guid _GiaoDichId = new Guid();
        public Guid GiaoDichId
        {
            get { return _GiaoDichId; }
            set { _GiaoDichId = value; }
        }

        private Guid _DoanRaId;
        public Guid DoanRaId
        {
            get { return _DoanRaId; }
            set { _DoanRaId = value; }
        }

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

        private string _PhieuChiSo;
        public string PhieuChiSo
        {
            get { return _PhieuChiSo; }
            set { _PhieuChiSo = value; }
        }
        
        private string _UNCSo;
        public string UNCSo
        {
            get { return _UNCSo; }
            set { _UNCSo = value; }
        }

        private string _PhieuChiVndSo;
        public string PhieuChiVndSo
        {
            get { return _PhieuChiVndSo; }
            set { _PhieuChiVndSo = value; }
        }

        private string _SoTBDuToan;

        public string SoTBDuToan
        {
            get { return _SoTBDuToan; }
            set { _SoTBDuToan = value; }
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
            get 
            {
                if (_TienMatUSD != 0)
                    return _TienMatVND / _TienMatUSD;
                else
                    return 0;
            }

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

        public string MaNguonKinhPhi
        { get; set; }

        private string _NguonKinhPhi;//LoaiDoanRa
        public string NguonKinhPhi
        {
            get { return _NguonKinhPhi; }
            set { _NguonKinhPhi = value; }
        }

        private string _NguoiTamUngTien;
        public string NguoiTamUngTien
        {
            get { return _NguoiTamUngTien; }
            set { _NguoiTamUngTien = value; }
        }
                
        private string _ThoiGianDuyetDuToan;
        public string ThoiGianDuyetDuToan
        {
            get { return _ThoiGianDuyetDuToan; }
            set { _ThoiGianDuyetDuToan = value; }
        }

        private decimal _DuToanDuocDuyet;
        public decimal DuToanDuocDuyet
        {
            get { return _DuToanDuocDuyet; }
            set { _DuToanDuocDuyet = value; }
        }

        private decimal _DuToanDuocDuyetVND;
        public decimal DuToanDuocDuyetVND
        {
            get { return _DuToanDuocDuyetVND; }
            set { _DuToanDuocDuyetVND = value; }
        }
         
        private DateTime _NgayDi;
        public DateTime NgayDi
        {
            get { return _NgayDi; }
            set { _NgayDi = value; }
        }

        private DateTime _NgayVe;
        public DateTime NgayVe
        {
            get { return _NgayVe; }
            set { _NgayVe = value; }
        }

        #region Thong tin bo sung them SoTienTamUngVND
        private decimal _TienTamUngVND;
        public decimal TienTamUngVND
        {
            get { return _TienTamUngVND; }
            set { _TienTamUngVND = value; }
        }
        #endregion


        #region Ham so sanh
        /// <summary>
        /// Tang dan theo ma nguon ngan sach, giam dan theo so thong bao du toan
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int CompareSoDuToan(ViewTamUngDoanRa x, ViewTamUngDoanRa y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retvalLoaiDoanRa = 0;
                    int retvalSoDuToan = 0;
                    retvalLoaiDoanRa = x.MaNguonKinhPhi.CompareTo(y.MaNguonKinhPhi);
                    if (retvalLoaiDoanRa == 0)
                    {
                        retvalSoDuToan = x.SoTBDuToan.CompareTo(y.SoTBDuToan); //Giam dan
                        return retvalSoDuToan;
                    }
                    else
                        return retvalLoaiDoanRa * -1; //Tang dan
                }
            }
        }

        /// <summary>
        /// Tang dan theo ma nguon ngan sach, tang dan theo so thong bao du toan
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int CompareSoDuToanTangDan(ViewTamUngDoanRa x, ViewTamUngDoanRa y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retvalLoaiDoanRa = 0;
                    int retvalSoDuToan = 0;
                    retvalLoaiDoanRa = x.MaNguonKinhPhi.CompareTo(y.MaNguonKinhPhi);
                    if (retvalLoaiDoanRa == 0)
                    {
                        retvalSoDuToan = x.SoTBDuToan.CompareTo(y.SoTBDuToan) * -1; //Giam dan
                        return retvalSoDuToan;
                    }
                    else
                        return retvalLoaiDoanRa * -1; //Tang dan
                }
            }
        }
        #endregion
        #region Ty gia binh quan
        public decimal TyGiaTienMatBq
        {
            get;
            set;
        }

        public decimal TyGiaChuyenKhoanBq
        {
            get;
            set;
        }
        #endregion
    }
}
