using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
   public class RP_SoDuInfo
    {
        public virtual Guid LoaiDoanRaId { get; set; }
        public virtual String TenLoaiDoanRa { get; set; }
        public virtual Guid DoanRaId { get; set; }
        public virtual Guid TenDoanRa { get; set; }
        public virtual String NoiDung { get; set; }
        public virtual decimal SoTienNt { get; set; }
        public virtual decimal SoTienVND { get; set; }
        public virtual decimal TyGia { get; set; }
    }
}
