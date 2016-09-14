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
namespace Vns.QuanLyDoanRa.Dao
{
	public interface IVnsDuLuongDauKyDao:IDao<VnsDuLuongDauKy,Guid>
	{
        VnsDuLuongDauKy GetBy(DateTime NgayTinh, Guid NguonId, String NghiepVu);
        void DeleteBy(DateTime NgayTinh, Guid NguonId, String NghiepVu);
	}
}