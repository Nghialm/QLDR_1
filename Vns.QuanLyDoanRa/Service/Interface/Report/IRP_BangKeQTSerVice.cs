using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Service.Interface;
using Vns.QuanLyDoanRa.Domain.Report;

namespace Vns.QuanLyDoanRa.Service.Interface.Report
{
    public interface IRP_BangKeQTService : IErpService<RP_BangKeQT, Guid>
    {
        IList<RP_BangKeQT> GetDataBangkeQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay);

    }
}
