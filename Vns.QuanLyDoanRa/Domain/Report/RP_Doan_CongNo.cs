using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
    public class RP_Doan_CongNo
    {
        public virtual Guid DoanRaNoId { get; set; }
        public virtual Guid DoanRaCoId { get; set; }
        public virtual Guid LoaiDoanRaNoId { get; set; }
        public virtual Guid LoaiDoanRaCoId { get; set; }
        public virtual decimal PsNo { get; set; }
        public virtual decimal PsNoVND { get; set; }
        public virtual decimal PsCo { get; set; }
        public virtual decimal PsCoVND { get; set; }

        public virtual decimal TyGia { get; set; }

        public virtual decimal DuLuong { get; set; }
        public virtual decimal DuLuongVND { get; set; }

        public void TinhToanDuLuong()
        {
            DuLuong = PsCo - PsNo;
            DuLuongVND = PsCoVND - PsNoVND;
        }

        /// <summary>
        /// Tinh so tien con lai trong quy
        /// </summary>
        public void TinhToanSoDU()
        {
            DuLuong = PsNo - PsCo;
            DuLuongVND = PsNoVND - PsCoVND;
        }

        public virtual decimal SoTienXuat { get; set; }
    }
}
