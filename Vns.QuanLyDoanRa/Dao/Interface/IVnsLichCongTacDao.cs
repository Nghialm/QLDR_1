/*
insert license info here
*/
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using Vns.QuanLyDoanRa.Domain;
using Vns.Erp.Core.Dao;
using Vns.Erp.Core.Domain;
using System.Collections.Generic;
namespace Vns.QuanLyDoanRa.Dao
{
	/// <summary>
	///	Generated by MyGeneration using the NHibernate Object Mapping adapted by Gustavo
	/// </summary>	
	public interface IVnsLichCongTacDao:IDao<VnsLichCongTac,Guid>
	{
        IList<VnsLichCongTac> GetByDoanCongTac(Guid CongTacId);
        IList<VnsLichCongTac> GetByDoanCongTacAndNhomNuoc(Guid CongTacId, int LoaiQuocGia);
        Boolean DeleteByDoanCongTac(Guid CongTacId);
        IList<VnsLichCongTac> GetNuocDen(Guid CongTacId);
	}
}
