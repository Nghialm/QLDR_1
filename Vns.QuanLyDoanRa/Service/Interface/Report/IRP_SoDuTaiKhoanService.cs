using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Service.Interface;
using Vns.QuanLyDoanRa.Domain.Report;

namespace Vns.QuanLyDoanRa.Service.Interface.Report
{
    public interface IRP_SoDuTaiKhoanService : IErpService<RP_SoDuTaiKhoan, Guid>
    {
        IList<RP_SoDuTaiKhoan> lstGetDuCoCtTk112ThangTruocChuyenSang(DateTime p_TuNgay, DateTime p_DenNgay, string MaTk, string MaTkDu);
        List<RP_SoDuTaiKhoan> lstPhatSinhTrongThang(DateTime p_TuNgay, DateTime p_DenNgay, string MaTk, string MaTkDu);
    }
}
