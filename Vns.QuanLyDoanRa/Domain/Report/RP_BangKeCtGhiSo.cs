using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
    public class RP_BangKeCtGhiSo  
    {
        public virtual Guid DoanRaId { get; set; }
        public virtual Guid LoaiDoanRaId { get; set; } 
        public virtual DateTime NgayHt { get; set; }
        public virtual String SoCt { get; set; }
        public virtual DateTime NgayCt { get; set; }
        public virtual String DienGiai { get; set; }
        public virtual String TenLoaiDoanRa { get; set; }
        public virtual String TenDoanRa { get; set; }
        public virtual decimal TmTyGia { get; set; } 
        public virtual decimal TmVND { get; set; }
        public virtual decimal TmUSD { get; set; }
        public virtual decimal CkVND { get; set; }
        public virtual decimal CkUSD { get; set; }
        public virtual decimal CkTyGia { get; set;}
        public virtual String MaTkNo { get; set; }
        public virtual String MaTkCo { get; set; }
        public virtual decimal TongUSD { get; set; }
        public virtual decimal TongVND { get; set; }

        public virtual decimal VNDTm { get; set; }
        public virtual decimal VNDCk { get; set; }

        public virtual String SoTBDT { get; set; }
        public virtual String SoTBQT { get; set; }

        public RP_BangKeCtGhiSo GetData(RP_SoDuTaiKhoan objSoDu, int GiaTri)
        {
            RP_BangKeCtGhiSo objBangKe = new RP_BangKeCtGhiSo();
            objBangKe.DoanRaId = objSoDu.DoanRaId;
            objBangKe.LoaiDoanRaId = objSoDu.LoaiDoanRaId;
            objBangKe.NgayHt = objSoDu.NgayHt;
            objBangKe.SoCt = objSoDu.SoCt;
            objBangKe.NgayCt = objSoDu.NgayCt;
            objBangKe.DienGiai = objSoDu.DienGiai;
            objBangKe.TenLoaiDoanRa = objSoDu.TenLoaiDoanRa;
            objBangKe.TenDoanRa = objSoDu.TenDoanRa;
            if (objSoDu.MaTkCo == Globals.TkTienMat && GiaTri == 2)
            {
                objBangKe.TmTyGia = objSoDu.TyGia;
                objBangKe.TmUSD = objSoDu.PsTangUSD;
                objBangKe.TmVND = objSoDu.PsTangVND;
            }
            else if (objSoDu.MaTkCo == Globals.TkTienChuyenKhoan && GiaTri == 2)
            {
                objBangKe.CkTyGia = objSoDu.TyGia;
                objBangKe.CkUSD = objSoDu.PsTangUSD;
                objBangKe.CkVND = objSoDu.PsTangVND;
            }

            else if (objSoDu.MaTkNo == Globals.TkThanhToanTienMat && GiaTri == 3)
            {
                objBangKe.TmTyGia = objSoDu.TyGia;
                objBangKe.TmUSD = objSoDu.PsTangUSD;
                objBangKe.TmVND = objSoDu.PsTangVND;
            }
            else if (objSoDu.MaTkNo == Globals.TkThanhToanChuyenKhoan && GiaTri == 3)
            {
                objBangKe.CkTyGia = objSoDu.TyGia;
                objBangKe.CkUSD = objSoDu.PsTangUSD;
                objBangKe.CkVND = objSoDu.PsTangVND;
            }

            objBangKe.TongUSD = objBangKe.TmUSD + objBangKe.CkUSD;
            objBangKe.TongVND = objBangKe.TmVND + objBangKe.CkVND;

            return objBangKe;
        }

        public static int CompareSoTBQT(RP_BangKeCtGhiSo x, RP_BangKeCtGhiSo y)
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
                    int retvalSoQuyetToan = 0;
                    //int revalSoChungTu = 0;
                    retvalSoQuyetToan = x.SoTBQT.CompareTo(y.SoTBQT);
                    return retvalSoQuyetToan;
                }
            }
        }
    }
}
