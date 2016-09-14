using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
    public class BC03DR
    {
        public virtual Guid LoaiDoanRaId { get; set; }
        public virtual String TenLoaiDoanRa { get; set; }
        public virtual Guid DoanRaId { get; set; }
        public virtual String TenDoan { get; set; }
        public virtual String TenDoanRaVietTat { get; set; }
        public virtual String NuocCongTac { get; set; }
        public virtual Guid NuocCongTacId { get; set; }
        public virtual String TruongDoan { get; set; }
        public virtual String ThangDuyetDt { get; set; }
        public virtual String SoTbDt { get; set; }
        public virtual decimal DtDuocDuyet { get; set; }
        public virtual String NguoiTamUng { get; set; }
        public virtual decimal TongUSD { get; set; }
        public virtual decimal TongVND { get; set; }
        public virtual decimal TienMatUSD { get; set; }
        public virtual decimal TienMatTG { get; set; }
        public virtual decimal TienMatVND { get; set; }
        public virtual decimal ChuyenKhoanUSD { get; set; }
        public virtual decimal ChuyenKhoanTG { get; set; }
        public virtual decimal ChuyenKhoanVND { get; set; }
        public virtual int GroupThang { get; set; }
        public virtual String TenGroupThang { get; set; }
        public virtual DateTime NgayDuyetDt { get; set; }

        public BC03DR(VnsReportChuaQt obj, int type)
        {
            LoaiDoanRaId = obj.LoaiDoanRaId;
            TenLoaiDoanRa = obj.TenLoaiDoanRa;
            DoanRaId = obj.DoanRaId;
            TenDoan = obj.TenDoan;
            TenDoanRaVietTat = obj.TenDoanVietTat;
            NuocCongTac = obj.NuocCongTac;
            TruongDoan = obj.TruongDoan;
            ThangDuyetDt = obj.ThangDuyetDt;
            SoTbDt = obj.SoTbDt;
            DtDuocDuyet = obj.DtDuocDuyet;
            NguoiTamUng = obj.NguoiTamUng;
            TongUSD = obj.TongUSD;
            TongVND = obj.TongVND;
            TienMatTG = obj.TienMatTG;
            TienMatUSD = obj.TienMatUSD;
            TienMatVND = obj.TienMatVND;
            ChuyenKhoanTG = obj.ChuyenKhoanTG;
            ChuyenKhoanUSD = obj.ChuyenKhoanUSD;
            ChuyenKhoanVND = obj.ChuyenKhoanVND;
            GroupThang = type;
            if (type == 1)
                TenGroupThang = "Kỳ trước chuyển sang";
            else
                TenGroupThang = " Kỳ này";
        }        

        #region Ham so sanh
        public static int CompareSoDuToan(BC03DR x, BC03DR y)
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
                    int retvalSoDuToan = 0;
                    //int revalSoChungTu = 0;
                    retvalSoDuToan = x.SoTbDt.CompareTo(y.SoTbDt);
                    return retvalSoDuToan;
                }
            }
        }
        #endregion
    }
}
