using System;
using NHibernate;
using NHibernate.Cfg;
using Nullables;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using Vns.Erp.Core.Dao.NHibernate;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Dao;
using Vns.Erp.Core.Dao;
using Spring.Transaction.Interceptor;
using NHibernate.Criterion;
namespace Vns.QuanLyDoanRa.Dao.NHibernate
{
    public interface IVnsHtSoCtMaxDao : IDao<VnsHtSoCtMax, System.Guid>
	{
        VnsHtSoCtMax GetByThangNamEtc(Guid LoaichungtuId, int Thang, int Nam);
        VnsHtSoCtMax GetByNamEtc(Guid LoaichungtuId, int Thang, int Nam);
	}
}