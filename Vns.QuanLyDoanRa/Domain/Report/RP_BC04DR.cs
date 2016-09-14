using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
    public class RP_BC04DR
    {
        public virtual Guid DoanRaId { get; set; }
        public virtual Guid LoaiDoanRa { get; set; }
        public virtual String TenDoanRa { get; set; }
        public virtual String SoDuToan { get; set; }
        public virtual String SoQuyetToan { get; set; }

        public virtual string MaNoiDung { get; set; }
        public virtual String NoiDung { get; set; }
        public virtual decimal TongVND { get; set; }
        public virtual decimal TongUSD { get; set; }
        public virtual decimal TienMatVND { get; set; }
        public virtual decimal TienMatUSD { get; set; }
        public virtual decimal ChuyenKhoanVND { get; set; }
        public virtual decimal ChuyenKhoanUSD { get; set; }

        public virtual String TenHienThi
        {
            get
            {
                return String.Format("{0} - TBDT: {1} - TBQT: {2}", TenDoanRa, SoDuToan, SoQuyetToan);
            }
        }
    }
}
