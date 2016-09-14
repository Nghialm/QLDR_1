using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Service.Interface;
using Vns.QuanLyDoanRa.Domain.Report;

namespace Vns.QuanLyDoanRa.Service.Interface.Report
{
    public interface IRP_BC04DRService : IErpService<RP_BC04DR, Guid>
    {
        IList<RP_BC04DR> GetDataRp04Dr(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId);
        List<RP_SoDuTaiKhoan> GetSoDuTaiKhoan(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo, string p_TrangThaiCt);
        List<RP_SoDuTaiKhoan> GetBangKeQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo, string p_TrangThaiCt);
    }
}
