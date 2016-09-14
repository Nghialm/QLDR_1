using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
    public class VnsInQtTu
    {

        public virtual Guid IdMucCha { get; set; }
        public virtual String MaMucCha { get; set; }
        public virtual String MaMuc { get; set; }
        public virtual String TenMuc { get; set; }
        public virtual String DienGiai { get; set; }
        public virtual decimal SoTien { get; set; }
        public virtual decimal SoTienVND { get; set; }
        public virtual String TenKhoanChi { get; set; }
        public virtual int LanDuToan { get; set; }

        public VnsInQtTu()
        {
            this.IdMucCha = new Guid();
            this.MaMucCha = String.Empty;
            this.MaMuc = String.Empty;
            this.TenMuc = String.Empty;
            this.DienGiai = String.Empty;
            this.TenKhoanChi = String.Empty;
            this.SoTien = decimal.MaxValue;
            this.SoTienVND = decimal.MaxValue;
            this.LanDuToan = 0;
        }

        public static int CompareSoQuyetToan(VnsInQtTu x, VnsInQtTu y)
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
                    retvalSoQuyetToan = x.MaMuc.CompareTo(y.MaMuc);
                    return retvalSoQuyetToan;
                }
            }
        }

    }
}
