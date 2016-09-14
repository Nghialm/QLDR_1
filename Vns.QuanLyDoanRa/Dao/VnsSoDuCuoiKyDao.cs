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
using Vns.QuanLyDoanRa.Domain.Report;
namespace Vns.QuanLyDoanRa.Dao.NHibernate
{
	[Serializable]
    public sealed class VnsSoDuCuoiKyDao : GenericDao<VnsSoDuCuoiKy, Guid>, IVnsSoDuCuoiKyDao
	{
        public void DeleteBy(DateTime NgayTinh, Guid NguonId, String NghiepVu)
        {
            String nQuery = "Delete VnsSoDuCuoiKy where NguonId = :NguonId and NghiepVu = :NghiepVu and NgayTinh >= :NgayTinh";

            IQuery query = Session.CreateQuery(nQuery);

            query.SetParameter("NgayTinh", NgayTinh);
            query.SetParameter("NguonId", NguonId);
            query.SetParameter("NghiepVu", NghiepVu);

            query.ExecuteUpdate();
        }

        public IList<RP_SoDuTaiKhoan> GetLstSoDu(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_NguonId, string p_NghiepVu)
        {
            string sql = "select sd.NguonId as LoaiDoanRaId,ldr.TenLoaiDoanRa as TenLoaiDoanRa, " +
                         "sd.SoTienNte as SoDuUSD, sd.TyGia as TyGia, sd.SoTien as SoDuVND  " +
                         "from VnsSoDuCuoiKy sd " +
                         "Inner join sd.objLoaiDoanRa ldr " +
                         "where sd.NgayTinh >=: p_TuNgay AND sd.NgayTinh <=: p_DenNgay " +
                         (p_NguonId == new Guid() ? "" : "AND sd.NguonId =: p_NguonId ") +
                         (String.IsNullOrEmpty(p_NghiepVu) ? "" : "AND sd.NghiepVu like :p_NghiepVu ");

            IQuery q = NHibernateSession.CreateQuery(sql);
            q.SetParameter("p_TuNgay", VnsConvert.CStartOfDate(p_TuNgay));
            q.SetParameter("p_DenNgay", VnsConvert.CEndOfDate(p_DenNgay));
            if (!String.IsNullOrEmpty(p_NghiepVu)) q.SetParameter("p_NghiepVu", p_NghiepVu + "%");
            if (!(p_NguonId == new Guid())) q.SetParameter("p_NguonId", p_NguonId);
            q.SetResultTransformer(Transformers.AliasToBean<RP_SoDuTaiKhoan>());

            return q.List<RP_SoDuTaiKhoan>();
        }
	}
}
