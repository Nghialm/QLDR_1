/*
insert license info here
*/
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
using Vns.QuanLyDoanRa.Domain.Report;
using NHibernate.Transform;
namespace Vns.QuanLyDoanRa.Dao.NHibernate
{
	/// <summary>
	///	Generated by MyGeneration using the NHibernate Object Mapping adapted by Gustavo
	/// </summary>
	//[Serializable]
	public sealed class VnsDuToanDoanDao:GenericDao<VnsDuToanDoan,Guid>,IVnsDuToanDoanDao
	{
        public IList<VnsDuToanDoan> GetByDoanCongTac(Guid CongTacId)
        {
            //ICriteria isearch = NHibernateSession.CreateCriteria<VnsDuToanDoan>();
            //isearch.Add(Restrictions.Eq("CongTacId", CongTacId));

            //return isearch.List<VnsDuToanDoan>();

            String sql = "Select dt.id as id, dt.LichCongTacId as LichCongTacId, dt.CongTacId as CongTacId, " +
                        "dt.MucId as MucId, dt.TenKhoanChi as TenKhoanChi, " +
                        "dt.SoTienDuToan as SoTienDuToan, dt.SoTienDuToanVND as SoTienDuToanVND, " + 
                        "dt.DienGiai as DienGiai, " +
                        "dt.NgayDuToan as NgayDuToan " +
                        "from VnsDuToanDoan dt " +
                        "Inner Join dt.Muc m " +
                        "where dt.CongTacId =:CongTacId " +
                        "Order by m.MaMuc ASC";
            IQuery q = Session.CreateQuery(sql);
            q.SetParameter("CongTacId", CongTacId);
            q.SetResultTransformer(Transformers.AliasToBean<VnsDuToanDoan>());
            return q.List<VnsDuToanDoan>();
        }

        public IList<VnsInQtTu> GetDataInDt(Guid CongTacId)
        {
            IList<VnsInQtTu> lst = new List<VnsInQtTu>();
            string sql = "select " +
                            "m.IdMucCha as IdMucCha,' ' as MaMucCha , m.MaMuc as MaMuc,m.TenMuc as TenMuc, " +
                            "dt.DienGiai as DienGiai, " +
                            "dt.SoTienDuToan as SoTien, dt.SoTienDuToanVND as SoTienVND, " + 
                            "dt.TenKhoanChi as TenKhoanChi, " +
                            "dt.LanDuToan as LanDuToan " +
                         "from VnsDuToanDoan dt " +
                         "inner join dt.Muc m " +
                         "where dt.CongTacId =:CongTacId ";
            IQuery q = NHibernateSession.CreateQuery(sql);
            q.SetParameter("CongTacId", CongTacId);
            q.SetResultTransformer(Transformers.AliasToBean<VnsInQtTu>());
            lst = q.List<VnsInQtTu>();
            return lst;
        }

        public List<BC03DR> ListChuaQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRa)
        {
            //IList<BC03DR> lst = new List<BC03DR>();//ct.DanhSachDuToanDoan
            //string sql = "select dt.CongTacId as DoanRaId,Sum(dt.SoTienDuToan) as DtDuocDuyet, dt.NgayDuToan as NgayDuyetDt " +
            //             "from VnsDoanCongTac ct " +
            //             "inner join ct.DanhSachDuToanDoan dt " +
            //             "inner join ct.DanhSachQuyetToanDoan qt " +
            //             "where ((dt.NgayDuToan >=: p_TuNgay and dt.NgayDuToan <=: p_DenNgay) and (qt.NgayCt >=: p_DenNgay) and (ct.TrangThai =:p_TrangThai2)) " +
            //             "or ((dt.NgayDuToan >=: p_TuNgay) and (dt.NgayDuToan <=: p_DenNgay) and (ct.TrangThai =: p_TrangThai)) ";
            //if (p_LoaiDoanRa != new Guid())
            //    sql += "and ct.LoaiDoanRaId =: p_LoaiDoanRa ";
            //sql += " Group by dt.CongTacId,dt.NgayDuToan ";
            //IQuery q = NHibernateSession.CreateQuery(sql);
            //q.SetParameter("p_TuNgay", p_TuNgay);
            //q.SetParameter("p_DenNgay", p_DenNgay);
            //q.SetParameter("p_TrangThai", 1);
            //q.SetParameter("p_TrangThai2", 2);
            //if (p_LoaiDoanRa != new Guid())
            //    q.SetParameter("p_LoaiDoanRa", p_LoaiDoanRa);

            List<BC03DR> lstReturn = new List<BC03DR>();
            IList<BC03DR> lst1 = new List<BC03DR>();//ct.DanhSachDuToanDoan
            string sql1 = "select dt.CongTacId as DoanRaId,Sum(dt.SoTienDuToan) as DtDuocDuyet, dt.NgayDuToan as NgayDuyetDt " +
                         "from VnsDoanCongTac ct " +
                         "inner join ct.DanhSachDuToanDoan dt " +                         
                         "where (dt.NgayDuToan >=: p_TuNgay and dt.NgayDuToan <=: p_DenNgay) "+
                         "and (ct.TrangThai =: p_TrangThai) ";
            if (p_LoaiDoanRa != new Guid())
                sql1 += "and ct.LoaiDoanRaId =: p_LoaiDoanRa ";
            sql1 += " Group by dt.CongTacId,dt.NgayDuToan ";
            IQuery q1 = NHibernateSession.CreateQuery(sql1);
            q1.SetParameter("p_TuNgay", p_TuNgay);
            q1.SetParameter("p_DenNgay", p_DenNgay);
            q1.SetParameter("p_TrangThai", 1);            
            if (p_LoaiDoanRa != new Guid())
                q1.SetParameter("p_LoaiDoanRa", p_LoaiDoanRa);

            q1.SetResultTransformer(Transformers.AliasToBean<BC03DR>());
            lst1 = q1.List<BC03DR>();
            //return lst;

            IList<BC03DR> lst = new List<BC03DR>();//ct.DanhSachDuToanDoan
            string sql = "select dt.CongTacId as DoanRaId,Sum(dt.SoTienDuToan) as DtDuocDuyet, dt.NgayDuToan as NgayDuyetDt " +
                         "from VnsDoanCongTac ct " +
                         "inner join ct.DanhSachDuToanDoan dt " +
                         "inner join ct.DanhSachQuyetToanDoan qt " +
                         "where dt.NgayDuToan >=: p_TuNgay and dt.NgayDuToan <=: p_DenNgay " +
                         "and qt.NgayCt >: p_DenNgay " +
                         "and ct.TrangThai =: p_TrangThai ";
            if (p_LoaiDoanRa != new Guid())
                sql += "and ct.LoaiDoanRaId =: p_LoaiDoanRa ";
            sql += " Group by dt.CongTacId,dt.NgayDuToan ";
            IQuery q = NHibernateSession.CreateQuery(sql);
            q.SetParameter("p_TuNgay", p_TuNgay);
            q.SetParameter("p_DenNgay", p_DenNgay);
            q.SetParameter("p_TrangThai", 2);
            if (p_LoaiDoanRa != new Guid())
                q.SetParameter("p_LoaiDoanRa", p_LoaiDoanRa);

            q.SetResultTransformer(Transformers.AliasToBean<BC03DR>());
            lst = q.List<BC03DR>();
            lstReturn.AddRange(lst);
            lstReturn.AddRange(lst1);
            return lstReturn;
        }

        public IList<VnsDuToanDoan> GetByDoanCongTac(Guid CongTacId, int LanDuToan)
        {
            string sql = "Select dt from VnsDuToanDoan dt " + 
                "where 1 = 1 " +
                "and dt.CongTacId =:CongTacId " +
                "and dt.LanDuToan = :LanDuToan";

            IQuery q = Session.CreateQuery(sql);
            q.SetParameter("CongTacId", CongTacId);
            q.SetParameter("LanDuToan", LanDuToan);

            return q.List<VnsDuToanDoan>();
        }

        public void DeleteByDoanCongTac(Guid CongTacId, int LanDuToan)
        {
            string sql = "Delete from VnsDuToanDoan dt " +
                "where 1 = 1 " +
                "and dt.CongTacId =:CongTacId " +
                (LanDuToan == -1 ? "" : "and dt.LanDuToan = :LanDuToan");

            IQuery q = Session.CreateQuery(sql);
            q.SetParameter("CongTacId", CongTacId);
            if (LanDuToan != -1) q.SetParameter("LanDuToan", LanDuToan);

            q.ExecuteUpdate();
        }
	}
}
