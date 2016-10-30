using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
    public class RP_SoDuTaiKhoan
    {
        public virtual Guid CtId { get; set; }
        public virtual Guid DoanRaId { get; set; }
        public virtual Guid LoaiDoanRaId { get; set; } 
        public virtual DateTime NgayHt { get; set; }
        public virtual String SoCt { get; set; }
        public virtual DateTime NgayCt { get; set; }
        public virtual String DienGiai { get; set; }
        public virtual String TenLoaiDoanRa { get; set; }
        public virtual decimal TyGia { get; set; }
        public virtual decimal SoDuVND { get; set; }
        public virtual decimal SoDuUSD { get; set; }
        public virtual decimal PsTangVND { get; set; }
        public virtual decimal PsTangUSD { get; set; }
        public virtual decimal PsGiamVND { get; set; }
        public virtual decimal PsGiamUSD { get; set; }
        public virtual String TenDoanRa { get; set; }
        public virtual String MaTkNo { get; set; }
        public virtual String MaTkCo { get; set; }
        public virtual String MaTkDoiUng { get; set; }
        public virtual String TenTkDoiUng { get; set; }

        public virtual Guid NgoaiTeId { get; set; }

        public virtual String MoTa { get; set; }
        public virtual String DisplayMoTa
        {
            get;
            set;
        }

        public static int CompareSoCt(RP_SoDuTaiKhoan x, RP_SoDuTaiKhoan y)
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
                    retvalSoQuyetToan = x.SoCt.CompareTo(y.SoCt);
                    return retvalSoQuyetToan;
                }
            }
        }
    }
}
