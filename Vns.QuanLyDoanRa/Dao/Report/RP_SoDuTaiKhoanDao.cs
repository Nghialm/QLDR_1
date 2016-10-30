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
        public IList<RP_SoDuTaiKhoan> GetSoDuNoTaiKhoan(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo)
        {
            //Guid newGuid =new Guid("B664E661-61CA-42A1-A907-9AA194BB65AC");
            string sql = "select ct.NgayHt as NgayHt, ct.NgayCt as NgayCt,ct.SoCt as SoCt, gd.NoiDung as DienGiai, " +
                         "gd.TyGia as TyGia,gd.SoTien as PsTangVND, gd.SoTienNt as PsTangUSD, " +
                         "gd.DoanRaNoId as DoanRaId,gd.LoaiDoanRaNoId as LoaiDoanRaId, gd.MaTkCo as MaTkCo, gd.MaTkNo as MaTkNo, " +
                         "gd.NgoaiTeId  as NgoaiTeId, " +
                         "gd.MoTa as MoTa " + 
                         "from VnsGiaoDich gd " +
                         "inner join gd.objChungTu ct " +
                         "where ct.NgayCt >=: p_TuNgay AND ct.NgayCt <=: p_DenNgay " +
                         (String.IsNullOrEmpty(p_TkCo) ? "" : "AND MaTkCo like :p_TkCo ") +
                         (String.IsNullOrEmpty(p_TkNo) ? "" : "AND MaTkNo like :p_TkNo ") +
                         //"AND gd.DoanRaNoId =: newGuid " +
                         "ORDER BY ct.NgayCt ASC,ct.SoCt ASC ";
            IQuery q = NHibernateSession.CreateQuery(sql);
            q.SetParameter("p_TuNgay", p_TuNgay);
            q.SetParameter("p_DenNgay", p_DenNgay);
            //q.SetParameter("newGuid", newGuid);
            if (!String.IsNullOrEmpty(p_TkCo)) q.SetParameter("p_TkCo", p_TkCo + "%");
            if (!String.IsNullOrEmpty(p_TkNo)) q.SetParameter("p_TkNo", p_TkNo + "%");
            q.SetResultTransformer(Transformers.AliasToBean<RP_SoDuTaiKhoan>());
            return q.List<RP_SoDuTaiKhoan>();
        }

        public IList<RP_SoDuTaiKhoan> GetSoDuCoTaiKhoan(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo)
        {
            //Guid newGuid = new Guid("B664E661-61CA-42A1-A907-9AA194BB65AC");
            string sql = "select ct.NgayHt as NgayHt, ct.NgayCt as NgayCt,ct.SoCt as SoCt, gd.NoiDung as DienGiai, " +
                         "gd.TyGia as TyGia,gd.SoTien as PsGiamVND, gd.SoTienNt as PsGiamUSD, " +
                         "gd.DoanRaCoId as DoanRaId,gd.LoaiDoanRaCoId as LoaiDoanRaId , gd.MaTkCo as MaTkCo, gd.MaTkNo as MaTkNo, " +
                         "gd.NgoaiTeId  as NgoaiTeId, " +
                         "gd.MoTa as MoTa " + 
                         "from VnsGiaoDich gd " +
                         "inner join gd.objChungTu ct " +
                         "where ct.NgayCt >=: p_TuNgay AND ct.NgayCt <=: p_DenNgay " +
                         (String.IsNullOrEmpty(p_TkCo) ? "" : "AND MaTkCo like :p_TkCo ") +
                         (String.IsNullOrEmpty(p_TkNo) ? "" : "AND MaTkNo like :p_TkNo ") +
                         //"AND gd.DoanRaCoId =: newGuid " +
                         "ORDER BY ct.NgayCt ASC ,ct.SoCt ASC ";
            IQuery q = NHibernateSession.CreateQuery(sql);
            q.SetParameter("p_TuNgay", p_TuNgay);
            q.SetParameter("p_DenNgay", p_DenNgay);
            //q.SetParameter("newGuid", newGuid);
            if (!String.IsNullOrEmpty(p_TkCo)) q.SetParameter("p_TkCo", p_TkCo + "%");
            if (!String.IsNullOrEmpty(p_TkNo)) q.SetParameter("p_TkNo", p_TkNo + "%");
            q.SetResultTransformer(Transformers.AliasToBean<RP_SoDuTaiKhoan>());
            return q.List<RP_SoDuTaiKhoan>();
        }

        public IList<RP_SoDuTaiKhoan> GetSoDuNoGroupByLoaiDoanRa(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo)
        {
            string sql = "select Sum(gd.SoTien) as PsTangVND, Sum(gd.SoTienNt) as PsTangUSD, " +
                         "gd.LoaiDoanRaNoId as LoaiDoanRaId, gd.TyGia as TyGia " +
                         "from VnsGiaoDich gd " +
                         "inner join gd.objChungTu ct " +
                         "where ct.NgayCt >=: p_TuNgay AND ct.NgayCt <=: p_DenNgay " +
                         (String.IsNullOrEmpty(p_TkCo) ? "" : "AND MaTkCo like :p_TkCo ") +
                         (String.IsNullOrEmpty(p_TkNo) ? "" : "AND MaTkNo like :p_TkNo ") +
                         "GROUP BY gd.LoaiDoanRaNoId, gd.TyGia ";
                         //"ORDER BY ct.NgayCt ASC,ct.SoCt ASC ";
            IQuery q = NHibernateSession.CreateQuery(sql);
            q.SetParameter("p_TuNgay", p_TuNgay);
            q.SetParameter("p_DenNgay", p_DenNgay);
            if (!String.IsNullOrEmpty(p_TkCo)) q.SetParameter("p_TkCo", p_TkCo + "%");
            if (!String.IsNullOrEmpty(p_TkNo)) q.SetParameter("p_TkNo", p_TkNo + "%");
            q.SetResultTransformer(Transformers.AliasToBean<RP_SoDuTaiKhoan>());
            return q.List<RP_SoDuTaiKhoan>();
        }

        public IList<RP_SoDuTaiKhoan> GetSoDuCoGroupByLoaiDoanRa(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo)
        {
            string sql = "select Sum(gd.SoTien) as PsGiamVND, Sum(gd.SoTienNt) as PsGiamUSD, " +
                         "gd.LoaiDoanRaCoId as LoaiDoanRaId ,gd.TyGia as TyGia " +
                         "from VnsGiaoDich gd " +
                         "inner join gd.objChungTu ct " +
                         "where ct.NgayCt >=: p_TuNgay AND ct.NgayCt <=: p_DenNgay " +
                         (String.IsNullOrEmpty(p_TkCo) ? "" : "AND MaTkCo like :p_TkCo ") +
                         (String.IsNullOrEmpty(p_TkNo) ? "" : "AND MaTkNo like :p_TkNo ") +
                         "GROUP BY gd.LoaiDoanRaCoId, gd.TyGia "; 
                         //"ORDER BY ct.NgayCt ASC ,ct.SoCt ASC";
            IQuery q = NHibernateSession.CreateQuery(sql);
            q.SetParameter("p_TuNgay", p_TuNgay);
            q.SetParameter("p_DenNgay", p_DenNgay);
            if (!String.IsNullOrEmpty(p_TkCo)) q.SetParameter("p_TkCo", p_TkCo + "%");
            if (!String.IsNullOrEmpty(p_TkNo)) q.SetParameter("p_TkNo", p_TkNo + "%");
            q.SetResultTransformer(Transformers.AliasToBean<RP_SoDuTaiKhoan>());
            return q.List<RP_SoDuTaiKhoan>();
        }
    }
}
