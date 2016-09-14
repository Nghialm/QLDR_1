using System;
using NHibernate;
using NHibernate.Cfg;
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
using NHibernate.Transform;
namespace Vns.QuanLyDoanRa.Dao.NHibernate
{
	[Serializable]
	public sealed class VnsDuLuongDauKyDao:GenericDao<VnsDuLuongDauKy,Guid>,IVnsDuLuongDauKyDao
	{
        public VnsDuLuongDauKy GetBy(DateTime NgayTinh, Guid NguonId, String NghiepVu)
        {
            ICriteria isearch = NHibernateSession.CreateCriteria<VnsDuLuongDauKy>();

            isearch.Add(Restrictions.Eq("NgayTinh", NgayTinh));
            isearch.Add(Restrictions.Eq("NguonId", NguonId));
            isearch.Add(Restrictions.Eq("NghiepVu", NghiepVu));

            isearch.SetResultTransformer(Transformers.DistinctRootEntity);

            IList<VnsDuLuongDauKy> lst = isearch.List<VnsDuLuongDauKy>();

            if (lst != null && lst.Count > 0)
                return lst[0];
            else
                return null;
        }

        public void DeleteBy(DateTime NgayTinh, Guid NguonId, String NghiepVu)
        {
            String nQuery = "Delete VnsDuLuongDauKy where NguonId = :NguonId and NghiepVu = :NghiepVu and NgayTinh > :NgayTinh";

            IQuery query = Session.CreateQuery(nQuery);

            query.SetParameter("NgayTinh", NgayTinh);
            query.SetParameter("NguonId", NguonId);
            query.SetParameter("NghiepVu", NghiepVu);

            query.ExecuteUpdate();
        }              
           
	}
}
