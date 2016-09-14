using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Service.Interface;
using Vns.QuanLyDoanRa.Domain.Report;

namespace Vns.QuanLyDoanRa.Service.Interface.Report
{
    public interface IRP_BC03DRService : IErpService<BC03DR, Guid>
    {
        IList<BC03DR> GetData_BC03DR(String p_MaTk, DateTime m_TuNgay, DateTime m_DenNgay, Guid p_LoaiDoanRaId);
    }
}
