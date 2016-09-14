using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Dao;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Domain;

namespace Vns.QuanLyDoanRa.Dao.Interface.Report
{
    public interface IRP_SoDuTaiKhoanDao : IDao<RP_SoDuTaiKhoan, Guid>
    {
        IList<RP_SoDuTaiKhoan> GetSoDuNoTaiKhoan(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo);
        IList<RP_SoDuTaiKhoan> GetSoDuCoTaiKhoan(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo);
        IList<RP_SoDuTaiKhoan> GetSoDuNoGroupByLoaiDoanRa(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo);
        IList<RP_SoDuTaiKhoan> GetSoDuCoGroupByLoaiDoanRa(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo);
    }
}
