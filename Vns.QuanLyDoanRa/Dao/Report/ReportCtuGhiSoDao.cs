using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Dao.NHibernate;
using Vns.QuanLyDoanRa.Dao.Interface.Report;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Domain;
using NHibernate;
using NHibernate.Transform;

namespace Vns.QuanLyDoanRa.Dao.NHibernate
{
    public class RP_SoDuTaiKhoanDao : GenericDao<RP_SoDuTaiKhoan, Guid>, IRP_SoDuTaiKhoanDao 
    {
        public List<RP_SoDuTaiKhoan> GetSoDuTaiKhoan(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo)
        {
            List<RP_SoDuTaiKhoan> lst = new List<RP_SoDuTaiKhoan>();
            string sql = "select ct.NgayHt as NgayHt, ct.NgayCt as NgayCt,ct.SoCt as SoCt, ct.NoiDung as DienGiai, " +
                         "gd.TyGia as TyGia,gd.SoTien as Ps{0}VND, gd.SoTienNt as Ps{0}USD, " +
                         "gd.DoanRa{1}Id as DoanRaId,gd.LoaiDoanRa{1}Id as LoaiDoanRaId " +
                         "from VnsGiaoDich gd " +
                         "inner join gd.objChungTu ct " +
                         "where ct.NgayCt >=: p_TuNgay AND ct.NgayCt <=: p_DenNgay " +
                         (String.IsNullOrEmpty(p_TkCo) ? "" : "AND MaTkCo like :p_TkCo ") +
                         (String.IsNullOrEmpty(p_TkNo) ? "" : "AND MaTkNo like :p_TkNo ");
            
            IQuery q = NHibernateSession.CreateQuery(string.Format(sql,"Tang","Co"));
            q.SetParameter("p_TuNgay",VnsConvert.CStartOfDate(p_TuNgay));
            q.SetParameter("p_DenNgay",VnsConvert.CEndOfDate(p_DenNgay));
            if (!String.IsNullOrEmpty(p_TkCo)) q.SetParameter("p_TkCo",string.Format("{0}%", p_TkCo));
            if (!String.IsNullOrEmpty(p_TkNo)) q.SetParameter("p_TkNo",string.Format("{0}%", p_TkNo));
            q.SetResultTransformer(Transformers.AliasToBean<RP_SoDuTaiKhoan>());

            IList<RP_SoDuTaiKhoan> lstDuNo = q.List<RP_SoDuTaiKhoan>();
            lst.AddRange(lstDuNo);

            IQuery q = NHibernateSession.CreateQuery(string.Format(sql, "Giam", "No"));
            q.SetParameter("p_TuNgay", VnsConvert.CStartOfDate(p_TuNgay));
            q.SetParameter("p_DenNgay", VnsConvert.CEndOfDate(p_DenNgay));
            if (!String.IsNullOrEmpty(p_TkCo)) q.SetParameter("p_TkCo", string.Format("{0}%", p_TkCo));
            if (!String.IsNullOrEmpty(p_TkNo)) q.SetParameter("p_TkNo", string.Format("{0}%", p_TkNo));
            q.SetResultTransformer(Transformers.AliasToBean<RP_SoDuTaiKhoan>());

            IList<RP_SoDuTaiKhoan> lstDuCo = q.List<RP_SoDuTaiKhoan>(); 

            lst.AddRange(lstDuCo);

            return lst;
        }
    }
}
