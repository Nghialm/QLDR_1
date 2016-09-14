using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Service.Interface;
using Vns.QuanLyDoanRa.Domain.Report;

namespace Vns.QuanLyDoanRa.Service.Interface.Report
{
    public interface IRP_BC06DRService : IErpService<RP_BC06DR, Guid>
    {
        List<RP_BC06DR> GetDataHoanUng(DateTime p_TuNgay, DateTime p_DenNgay);
        List<RP_BC06DR> GetDataChiQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay);
    }
}
