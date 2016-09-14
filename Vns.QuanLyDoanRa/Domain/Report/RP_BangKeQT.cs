using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
   public class RP_BangKeQT 
    {
        public virtual Guid LoaiDoanRaId { get; set; }
        public virtual string TenLoaiDoanRa { get; set; }
        public virtual Guid DoanRaId { get; set; }
        public virtual String NoiDung { get; set; }
        public virtual decimal TongVND { get; set; }
        public virtual decimal TongUSD { get; set; }
        public virtual decimal TienMatVND { get; set; }
        public virtual decimal TienMatUSD { get; set; }
        public virtual decimal TienMatTG { get; set; }
        public virtual decimal ChuyenKhoanVND { get; set; }
        public virtual decimal ChuyenKhoanTG { get; set; }
        public virtual decimal ChuyenKhoanUSD { get; set; }
    }
}
