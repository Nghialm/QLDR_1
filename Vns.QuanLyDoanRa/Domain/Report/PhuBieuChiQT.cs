using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
    public class PhuBieuChiQT
    {
        public PhuBieuChiQT()
        {
        }

        public PhuBieuChiQT(VnsQuyetToanDoan objQt, VnsLoaiDoanRa objLoaiDoanCt)
        {

            if (objQt.objMucTieuMuc != null)
            {
                if (objQt.objMucTieuMuc.MaMuc.Equals("6801"))
                    STT = 1;
                else if (objQt.objMucTieuMuc.MaMuc.Equals("6802"))
                    STT = 2;
                else if (objQt.objMucTieuMuc.MaMuc.Equals("6803"))
                    STT = 3;
                else if (objQt.objMucTieuMuc.MaMuc.Equals("6804"))
                    STT = 4;
                else if (objQt.objMucTieuMuc.MaMuc.Equals("6805"))
                    STT = 5;
                else if (objQt.objMucTieuMuc.MaMuc.Equals("6806"))
                    STT = 6;
                else if (objQt.objMucTieuMuc.MaMuc.Equals("6849"))
                    STT = 7;

                TieuMuc = objQt.objMucTieuMuc.MaMuc;                
            }
            //Ngan sach dang
            if (objLoaiDoanCt.MaLoaiDoanRa == "1")
            {
                BanDangUSD += objQt.SoTien;
                BanDangUSD += objQt.SoTienVND;
            }
            else
            {
                DeAnUSD += objQt.SoTien;
                DeAnUSD += objQt.SoTienVND;
            }

            TongUSD = DeAnUSD + BanDangUSD;
            TongVND = DeAnVND + BanDangVND;
        }

        public virtual int STT { get; set; }
        public virtual Guid DoanRaId { get; set; }
        public virtual String TenDoanRa { get; set; }
        public virtual String TieuMuc { get; set; }
        public virtual int Type { get; set; } // 1: QT, 2 TU
        public virtual decimal DeAnUSD { get; set; }
        public virtual decimal DeAnVND { get; set; }
        public virtual decimal BanDangUSD { get; set; }
        public virtual decimal BanDangVND { get; set; }
        public virtual decimal TongUSD { get; set; }
        public virtual decimal TongVND { get; set; }
        public virtual decimal SoThanhVien { get; set; }
        public virtual decimal SoNuocCtac { get; set; }

        public virtual DateTime NgayQuyetToan { get; set; }

        public virtual int DaQuyetToan
        {
            get
            {
                if (NgayQuyetToan >= TuNgay && NgayQuyetToan <= DenNgay)
                    return 1;
                else
                    return 0;
 
            }
        }

        public virtual int TongSoDoan { get; set; }
        public virtual int TongSoQuyetToan { get; set; }

        public virtual DateTime TuNgay
        { get; set; }

        public virtual DateTime DenNgay
        { get; set; }
    }

    public class PhuBieuChiQt_Dem
    {
        private int _Tong;

        public int Tong
        {
            get { return _CacBanDang + _DeAn165; }
        }

        private int _CacBanDang;

        public int CacBanDang
        {
            get { return _CacBanDang; }
            set { _CacBanDang = value; }
        }

        private int _DeAn165;

        public int DeAn165
        {
            get { return _DeAn165; }
            set { _DeAn165 = value; }
        }
    }
}
