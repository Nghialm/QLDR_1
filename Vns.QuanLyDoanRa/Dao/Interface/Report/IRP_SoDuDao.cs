using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Dao;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Domain;

namespace Vns.QuanLyDoanRa.Dao.Interface.Report
{
    public interface IRP_SoDuDao : IDao<RP_SoDuInfo, Guid>
    {
        IList<RP_SoDuInfo> GetSoTienPhaiThu(DateTime p_TuNgay, DateTime p_DenNgay);
        IList<RP_SoDuInfo> GetSoTienChiQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay);
        IList<VnsGiaoDich> GetLstTamUngDoanRaDaQt(DateTime p_TuNgay, DateTime p_DenNgay);
    }
}
