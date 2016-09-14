using System;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using Vns.QuanLyDoanRa.Domain;
using Vns.Erp.Core.Dao;
using Vns.Erp.Core.Domain;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain.Report;
namespace Vns.QuanLyDoanRa.Dao
{
    public interface IVnsSoDuCuoiKyDao : IDao<VnsSoDuCuoiKy, Guid>
	{
        void DeleteBy(DateTime NgayTinh, Guid NguonId, String NghiepVu);
        IList<RP_SoDuTaiKhoan> GetLstSoDu(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_NguonId, string p_NghiepVu);
	}
}