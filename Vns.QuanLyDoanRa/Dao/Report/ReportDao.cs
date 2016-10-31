using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Dao.NHibernate;
using Vns.QuanLyDoanRa.Domain.Report;
using NHibernate;
using NHibernate.Transform;
using Vns.QuanLyDoanRa.Domain;

namespace Vns.QuanLyDoanRa.Dao.NHibernate
{
    public sealed class ReportDao : GenericDao<RP_BC04DR, Guid>, IReportDao
    {

        //Kiem tra lai thong tin sau
        public IList<RP_Doan_CongNo> GetLstDoanRaTheoTamUngConLai(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_loaiDoanRaNoId, Guid p_loaiDoanRaCoId, Guid p_DoanRaNoId, Guid p_DoanRaCoId, string pTk, string pTkDu, decimal p_TrangThaiDoanCt)
        {
            string tkThanhToan = Globals.TkThanhToanNguoiBan;
            string sql =
                        "select " +
                        "Sum(Case When MaTkNo Like '" + pTk + "%' Then gd.SoTienNt " +
                            "Else 0 End) as PsNo, " +
                        "Sum(Case When MaTkNo Like '" + pTk + "%' Then gd.SoTien " +
                            "Else 0 End) as PsNoVND, " +
                        "Sum(Case When MaTkCo Like '" + pTk + "%' Then gd.SoTienNt " +
                            "Else 0 End) as PsCo, " +
                        "Sum(Case When MaTkCo Like '" + pTk + "%' Then gd.SoTien " +
                            "Else 0 End) as PsCoVND, " +
                //"Sum(gd.SoTienNt) as SoTienNt, " +
                         "gd.DoanRaNoId as DoanRaNoId, " +
                         "gd.DoanRaCoId as DoanRaCoId , " +
                         "gd.LoaiDoanRaNoId as LoaiDoanRaNoId, " +
                         "gd.LoaiDoanRaCoId as LoaiDoanRaCoId " +
                         "from VnsGiaoDich gd " +
                         "inner join gd.objChungTu ct " +
                         "inner join gd.objDoanRa dr " +
                         "where ct.NgayCt >=: p_TuNgay AND ct.NgayCt <=: p_DenNgay " +
                         "AND (MaTkCo like :pTk AND MaTkNo like :pTkDu) " + //Tam ung cho doan ra
                         //"Or  (MaTkCo like :pTk AND MaTkNo like :pTkDu) " + //Truong hop 
                         "Or  (MaTkCo like :pTkDu AND MaTkNo like :tkThanhToan) " + //Truong hop thanh toan voi nguoi ban
                         ((p_DoanRaCoId == new Guid()) ? "" : "AND DoanRaCoId =: p_DoanRaCoId ") +
                         ((p_DoanRaNoId == new Guid()) ? "" : "AND DoanRaNoId =: p_DoanRaNoId ") +
                         ((p_loaiDoanRaNoId == new Guid()) ? "" : "AND gd.LoaiDoanRaNoId =:p_loaiDoanRaNoId ") +
                         ((p_loaiDoanRaCoId == new Guid()) ? "" : "AND gd.LoaiDoanRaCoId =:p_loaiDoanRaCoId ") +
                         ((p_TrangThaiDoanCt == 0) ? "" : "AND dr.TrangThai = :p_TrangThaiDoanCt ") +
                         "Group by DoanRaNoId, DoanRaCoId, LoaiDoanRaNoId, LoaiDoanRaCoId";

            IQuery q = NHibernateSession.CreateQuery(sql);
            q.SetParameter("p_TuNgay", VnsConvert.CStartOfDate(p_TuNgay));
            q.SetParameter("p_DenNgay", VnsConvert.CEndOfDate(p_DenNgay));
            if (!String.IsNullOrEmpty(pTk)) q.SetParameter("pTk", pTk + "%");
            if (!String.IsNullOrEmpty(pTkDu)) q.SetParameter("pTkDu", pTkDu + "%");
            if (!String.IsNullOrEmpty(tkThanhToan)) q.SetParameter("tkThanhToan", tkThanhToan + "%");
            if (!(p_loaiDoanRaNoId == new Guid())) q.SetParameter("p_loaiDoanRaNoId", p_loaiDoanRaNoId);
            if (!(p_loaiDoanRaCoId == new Guid())) q.SetParameter("p_loaiDoanRaCoId", p_loaiDoanRaCoId);
            if (p_DoanRaCoId != new Guid()) q.SetParameter("p_DoanRaCoId", p_DoanRaCoId);
            if (p_DoanRaNoId != new Guid()) q.SetParameter("p_DoanRaNoId", p_DoanRaNoId);
            if (p_TrangThaiDoanCt != 0) q.SetParameter("p_TrangThaiDoanCt", p_TrangThaiDoanCt);

            q.SetResultTransformer(Transformers.AliasToBean<RP_Doan_CongNo>());
            return q.List<RP_Doan_CongNo>();
        }

        public IList<RP_Doan_CongNo> GetLstDoanRaTheoCongNo(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_loaiDoanRaNoId, Guid p_loaiDoanRaCoId, Guid p_DoanRaNoId, Guid p_DoanRaCoId, string p_TkNoId, string p_TkCoId, decimal p_TrangThaiDoanCt)
        {
            string sql =
                        "select " +
                        "Sum(Case When MaTkNo Like '" + p_TkNoId + "%' Then gd.SoTienNt " +
                            "Else 0 End) as PsNo, " +
                        "Sum(Case When MaTkCo Like '" + p_TkCoId + "%' Then gd.SoTienNt " +
                            "Else 0 End) as PsCo, " +
                //"Sum(gd.SoTienNt) as SoTienNt, " +
                         "gd.DoanRaNoId as DoanRaNoId, " +
                         "gd.DoanRaCoId as DoanRaCoId , " +
                         "gd.LoaiDoanRaNoId as LoaiDoanRaNoId, " +
                         "gd.LoaiDoanRaCoId as LoaiDoanRaCoId " +
                         "from VnsGiaoDich gd " +
                         "inner join gd.objChungTu ct " +
                         "inner join gd.objDoanRa dr " +
                         "where ct.NgayCt >=: p_TuNgay AND ct.NgayCt <=: p_DenNgay " +
                         (String.IsNullOrEmpty(p_TkCoId) ? "" : "AND (MaTkCo like :p_TkCoId ") +
                         (String.IsNullOrEmpty(p_TkNoId) ? "" : "or MaTkNo like :p_TkNoId) ") +
                         ((p_DoanRaCoId == new Guid()) ? "" : "AND DoanRaCoId =: p_DoanRaCoId ") +
                         ((p_DoanRaNoId == new Guid()) ? "" : "AND DoanRaNoId =: p_DoanRaNoId ") +
                         ((p_loaiDoanRaNoId == new Guid()) ? "" : "AND gd.LoaiDoanRaNoId =:p_loaiDoanRaNoId ") +
                         ((p_loaiDoanRaCoId == new Guid()) ? "" : "AND gd.LoaiDoanRaCoId =:p_loaiDoanRaCoId ") +
                         ((p_TrangThaiDoanCt == 0) ? "" : "AND dr.TrangThai = :p_TrangThaiDoanCt ") +
                         "Group by DoanRaNoId, DoanRaCoId, LoaiDoanRaNoId, LoaiDoanRaCoId";
                         
            IQuery q = NHibernateSession.CreateQuery(sql);
            q.SetParameter("p_TuNgay", VnsConvert.CStartOfDate(p_TuNgay));
            q.SetParameter("p_DenNgay", VnsConvert.CEndOfDate(p_DenNgay));
            if (!String.IsNullOrEmpty(p_TkCoId)) q.SetParameter("p_TkCoId", p_TkCoId + "%");
            if (!String.IsNullOrEmpty(p_TkNoId)) q.SetParameter("p_TkNoId", p_TkNoId + "%");
            if (!(p_loaiDoanRaNoId == new Guid())) q.SetParameter("p_loaiDoanRaNoId", p_loaiDoanRaNoId);
            if (!(p_loaiDoanRaCoId == new Guid())) q.SetParameter("p_loaiDoanRaCoId", p_loaiDoanRaCoId);
            if (p_DoanRaCoId != new Guid()) q.SetParameter("p_DoanRaCoId", p_DoanRaCoId);
            if (p_DoanRaNoId != new Guid()) q.SetParameter("p_DoanRaNoId", p_DoanRaNoId);
            if (p_TrangThaiDoanCt != 0) q.SetParameter("p_TrangThaiDoanCt", p_TrangThaiDoanCt);

            q.SetResultTransformer(Transformers.AliasToBean<RP_Doan_CongNo>());
            return q.List<RP_Doan_CongNo>();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_TuNgay"></param>
        /// <param name="p_DenNgay"></param>
        /// <param name="p_TkNoId"></param>
        /// <param name="p_TkCoId"></param>
        /// <param name="p_TrangThaiPhieu">1:Thang truoc chuyen sang, 2: Thang nay, -1:khong xet </param>
        /// <param name="p_TrangThaiDoanCt">1: Chua qt, 2 : da qt, 3: huy, 0 khong xet</param>
        /// <returns></returns>
        public IList<VnsGiaoDich> GetLstGiaoDich(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_loaiDoanRaNoId, Guid p_loaiDoanRaCoId, Guid p_DoanRaNoId, Guid p_DoanRaCoId, string p_TkNoId, string p_TkCoId, decimal p_TrangThaiPhieu, decimal p_TrangThaiDoanCt)
        {
            string sql = "select " +
                         "gd.GiaoDichId as GiaoDichId, gd.MaTkNo as MaTkNo,gd.MaTkCo as MaTkCo, gd.SoTien as SoTien, " +
                         "gd.SoTienNt as SoTienNt,gd.NoiDung as NoiDung, gd.DoanRaNoId as DoanRaNoId," +
                         "gd.DoanRaCoId as DoanRaCoId ,gd.LoaiDoanRaNoId as LoaiDoanRaNoId,gd.LoaiDoanRaCoId as LoaiDoanRaCoId,gd.TyGia as TyGia, " +
                         "gd.NgoaiTeId as NgoaiTeId, " +
                         "gd.MucTieuMucNoId as MucTieuMucNoId ,gd.MucTieuMucCoId as MucTieuMucCoId,gd.ChungTuId as ChungTuId " +
                         "from VnsGiaoDich gd " +
                         "inner join gd.objChungTu ct " +
                          "inner join gd.objDoanRa dr " +
                         "where ct.NgayCt >=: p_TuNgay AND ct.NgayCt <=: p_DenNgay " +
                         (String.IsNullOrEmpty(p_TkCoId) ? "" : "AND MaTkCo like :p_TkCoId ") +
                         (String.IsNullOrEmpty(p_TkNoId) ? "" : "AND MaTkNo like :p_TkNoId ") +
                         ((p_DoanRaCoId == new Guid()) ? "" : "AND DoanRaCoId =: p_DoanRaCoId ") +
                         ((p_DoanRaNoId == new Guid()) ? "" : "AND DoanRaNoId =: p_DoanRaNoId ") +
                         ((p_TrangThaiDoanCt == 0) ? "" : "AND dr.TrangThai =:p_TrangThaiDoanCt ") +
                         ((p_TrangThaiPhieu == -1) ? "" : "AND ct.TrangThai =:p_TrangThaiPhieu ") +
                         ((p_loaiDoanRaNoId == new Guid()) ? "" : "AND gd.LoaiDoanRaNoId =:p_loaiDoanRaNoId ")+
                         ((p_loaiDoanRaCoId == new Guid()) ? "" : "AND gd.LoaiDoanRaCoId =:p_loaiDoanRaCoId ")+
                         "ORDER BY ct.NgayCt desc ";

            IQuery q = NHibernateSession.CreateQuery(sql);
            q.SetParameter("p_TuNgay", VnsConvert.CStartOfDate(p_TuNgay));
            q.SetParameter("p_DenNgay", VnsConvert.CEndOfDate(p_DenNgay));            
            if (!String.IsNullOrEmpty(p_TkCoId)) q.SetParameter("p_TkCoId", p_TkCoId + "%");
            if (!String.IsNullOrEmpty(p_TkNoId)) q.SetParameter("p_TkNoId", p_TkNoId + "%");
            if (!(p_loaiDoanRaNoId == new Guid())) q.SetParameter("p_loaiDoanRaNoId", p_loaiDoanRaNoId);
            if (!(p_loaiDoanRaCoId == new Guid())) q.SetParameter("p_loaiDoanRaCoId", p_loaiDoanRaCoId);
            if (p_DoanRaCoId != new Guid()) q.SetParameter("p_DoanRaCoId", p_DoanRaCoId);
            if (p_DoanRaNoId != new Guid()) q.SetParameter("p_DoanRaNoId", p_DoanRaNoId);
            if (!(p_TrangThaiDoanCt == 0)) q.SetParameter("p_TrangThaiDoanCt", p_TrangThaiDoanCt);
            if (!(p_TrangThaiPhieu == -1)) q.SetParameter("p_TrangThaiPhieu", p_TrangThaiPhieu);
            q.SetResultTransformer(Transformers.AliasToBean<VnsGiaoDich>());
            return q.List<VnsGiaoDich>();
        }

        public IList<VnsGiaoDich> GetLstGiaoDichGroupByLoaiDr(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_loaiDoanRaId, string p_TkNoId, string p_TkCoId, decimal p_TrangThaiPhieu, decimal p_TrangThaiDoanCt)
        {
            string sql = "select gd.MaTkNo as MaTkNo,gd.MaTkCo as MaTkCo, Sum(gd.SoTien) as SoTien, sum(gd.SoTienNt) as SoTienNt ," +
                         "gd.LoaiDoanRaNoId as LoaiDoanRaNoId,gd.LoaiDoanRaCoId as LoaiDoanRaCoId " +
                         "from VnsGiaoDich gd " +
                         "inner join gd.objChungTu ct " +
                         "inner join gd.objDoanRa dr " +
                         "where ct.NgayCt >=: p_TuNgay AND ct.NgayCt <=: p_DenNgay " +
                         (String.IsNullOrEmpty(p_TkCoId) ? "" : "AND MaTkCo like :p_TkCoId ") +
                         (String.IsNullOrEmpty(p_TkNoId) ? "" : "AND MaTkNo like :p_TkNoId ") +
                         ((p_TrangThaiDoanCt == 0) ? "" : "AND dr.TrangThai =:p_TrangThaiDoanCt ") +
                         ((p_TrangThaiPhieu == -1) ? "" : "AND ct.TrangThai =:p_TrangThaiPhieu ") +
                         ((p_loaiDoanRaId == new Guid()) ? "" : "AND dr.LoaiDoanRaId =:p_loaiDoanRaId ") +
                         "Group by gd.LoaiDoanRaNoId, gd.LoaiDoanRaCoId , gd.MaTkNo, gd.MaTkCo ";

            IQuery q = NHibernateSession.CreateQuery(sql);
            q.SetParameter("p_TuNgay", VnsConvert.CStartOfDate(p_TuNgay));
            q.SetParameter("p_DenNgay",VnsConvert.CEndOfDate(p_DenNgay));
            if (!String.IsNullOrEmpty(p_TkCoId)) q.SetParameter("p_TkCoId", p_TkCoId + "%");
            if (!String.IsNullOrEmpty(p_TkNoId)) q.SetParameter("p_TkNoId", p_TkNoId + "%");
            if (!(p_TrangThaiDoanCt == 0)) q.SetParameter("p_TrangThaiDoanCt", p_TrangThaiDoanCt);
            if (!(p_TrangThaiPhieu == -1)) q.SetParameter("p_TrangThaiPhieu", p_TrangThaiPhieu);
            if (!(p_loaiDoanRaId == new Guid())) q.SetParameter("p_loaiDoanRaId", p_loaiDoanRaId);

            q.SetResultTransformer(Transformers.AliasToBean<VnsGiaoDich>());
            return q.List<VnsGiaoDich>();
        }

        public List<RP_SoDuTaiKhoan> GetSoDuTaiKhoan(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo, string p_TrangThaiCt)
        {
            List<RP_SoDuTaiKhoan> lst = new List<RP_SoDuTaiKhoan>();
            string SqlTkNo = string.Format(GenSqlByMaTk(p_TkNo),"No");
            string SqlTkCo = string.Format(GenSqlByMaTk(p_TkCo),"Co");
            string SqlTT = GenSqlByTrangThai(p_TrangThaiCt);
            string sql = "select ct.Id as CtId, ct.NgayHt as NgayHt, ct.NgayCt as NgayCt,ct.SoCt as SoCt, ct.NoiDung as DienGiai, " +
                         "gd.TyGia as TyGia,gd.SoTien as Ps{0}VND, gd.SoTienNt as Ps{0}USD, " +
                         "gd.NgoaiTeId as NgoaiTeId, " +
                         "gd.DoanRa{1}Id as DoanRaId,gd.LoaiDoanRa{1}Id as LoaiDoanRaId, gd.MaTkCo as MaTkCo, gd.MaTkNo as MaTkNo " +
                         "from VnsGiaoDich gd " +
                         "inner join gd.objChungTu ct " +
                         "where ct.NgayCt >=: p_TuNgay AND ct.NgayCt <=: p_DenNgay " +
                         (String.IsNullOrEmpty(p_TkCo) ? "" : string.Format("AND {0} ",SqlTkCo)) +
                         (String.IsNullOrEmpty(p_TkNo) ? "" : string.Format("AND {0} ", SqlTkNo)) +
                         ((p_TrangThaiCt == "-1") ? "" : string.Format("AND {0} ",SqlTT)) +
                         "Order by ct.NgayCt DESC ";
            IQuery qNo = NHibernateSession.CreateQuery(string.Format(sql, "Tang", "Co"));
            qNo.SetParameter("p_TuNgay", VnsConvert.CStartOfDate(p_TuNgay));
            qNo.SetParameter("p_DenNgay", VnsConvert.CEndOfDate(p_DenNgay));
            qNo.SetResultTransformer(Transformers.AliasToBean<RP_SoDuTaiKhoan>());

            IList<RP_SoDuTaiKhoan> lstDuNo = qNo.List<RP_SoDuTaiKhoan>();
            lst.AddRange(lstDuNo);

            //IQuery qCo = NHibernateSession.CreateQuery(string.Format(sql, "Giam", "No"));
            //qCo.SetParameter("p_TuNgay", VnsConvert.CStartOfDate(p_TuNgay));
            //qCo.SetParameter("p_DenNgay", VnsConvert.CEndOfDate(p_DenNgay));
            //qCo.SetResultTransformer(Transformers.AliasToBean<RP_SoDuTaiKhoan>());

            //IList<RP_SoDuTaiKhoan> lstDuCo = qCo.List<RP_SoDuTaiKhoan>();

            //lst.AddRange(lstDuCo);

            return lst;
        }

        private string GenSqlByMaTk(string MaTk)
        {
            string str = "(";

            string[] lstTk = MaTk.Split(';');

            for(int i =0; i< lstTk.Length; i++)
            {
                if (i == lstTk.Length - 1)
                {
                    str += "gd.MaTk{0} like '" + lstTk[i] + "%' )";
                }
                else
                {
                    str += "gd.MaTk{0} like '" + lstTk[i] + "%' OR ";
                }
            }

            return str;
        }

        private string GenSqlByTrangThai(string TrangThai)
        {
            string str = "(";

            string[] lstTT = TrangThai.Split(';');

            for (int i = 0; i < lstTT.Length; i++)
            {
                if (i == lstTT.Length - 1)
                {
                    str += "ct.TrangThai =" + lstTT[i] + " )";
                }
                else
                {
                    str += "ct.TrangThai =" + lstTT[i] + " OR ";
                }
            }

            return str;
        }

        public List<RP_SoDuTaiKhoan> GetBangKeQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo, string p_TrangThaiCt)
        { 
           
            List<RP_SoDuTaiKhoan> lst = new List<RP_SoDuTaiKhoan>();
            string SqlTkNo = string.Format(GenSqlByMaTk(p_TkNo), "No");
            string SqlTkCo = string.Format(GenSqlByMaTk(p_TkCo), "Co");
            string SqlTT = GenSqlByTrangThai(p_TrangThaiCt);
            string sql = "select ct.NgayHt as NgayHt, ct.NgayCt as NgayCt,ct.SoCt as SoCt, ct.NoiDung as DienGiai, " +
                         "gd.TyGia as TyGia,sum(gd.SoTien) as Ps{0}VND, sum(gd.SoTienNt) as Ps{0}USD, " +
                         "gd.DoanRa{1}Id as DoanRaId,gd.LoaiDoanRa{1}Id as LoaiDoanRaId, gd.MaTkCo as MaTkCo, gd.MaTkNo as MaTkNo " +
                         "from VnsGiaoDich gd " +
                         "inner join gd.objChungTu ct " +
                         "where ct.NgayCt >=: p_TuNgay AND ct.NgayCt <=: p_DenNgay " +
                         (String.IsNullOrEmpty(p_TkCo) ? "" : string.Format("AND {0} ", SqlTkCo)) +
                         (String.IsNullOrEmpty(p_TkNo) ? "" : string.Format("AND {0} ", SqlTkNo)) +
                         ((p_TrangThaiCt == "-1") ? "" : string.Format("AND {0} ", SqlTT)) +
                         "GROUP BY ct.NgayHt,ct.NgayCt,ct.SoCt,ct.NoiDung,gd.TyGia,gd.DoanRa{1}Id,gd.LoaiDoanRa{1}Id,gd.MaTkCo,gd.MaTkNo Order by ct.NgayCt DESC";
            IQuery qNo = NHibernateSession.CreateQuery(string.Format(sql, "Tang", "Co"));
            qNo.SetParameter("p_TuNgay", VnsConvert.CStartOfDate(p_TuNgay));
            qNo.SetParameter("p_DenNgay", VnsConvert.CEndOfDate(p_DenNgay));
            qNo.SetResultTransformer(Transformers.AliasToBean<RP_SoDuTaiKhoan>());

            IList<RP_SoDuTaiKhoan> lstDuNo = qNo.List<RP_SoDuTaiKhoan>();
            lst.AddRange(lstDuNo);

            //IQuery qCo = NHibernateSession.CreateQuery(string.Format(sql, "Giam", "No"));
            //qCo.SetParameter("p_TuNgay", VnsConvert.CStartOfDate(p_TuNgay));
            //qCo.SetParameter("p_DenNgay", VnsConvert.CEndOfDate(p_DenNgay));
            //qCo.SetResultTransformer(Transformers.AliasToBean<RP_SoDuTaiKhoan>());

            //IList<RP_SoDuTaiKhoan> lstDuCo = qCo.List<RP_SoDuTaiKhoan>();

            //lst.AddRange(lstDuCo);

            return lst;
        }

        public IList<VnsGiaoDich> GetSoTienTUChuaQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay, Guid LoaiDoanRa, string p_TkNo, string p_TkCo, decimal p_TrangThaiPhieu,bool isThangTruoc)
        {
            DateTime maxValue = DateTime.MaxValue;
            if (isThangTruoc)
                maxValue = p_DenNgay.AddMonths(1);
            else //Code moi them vao
                maxValue = p_DenNgay;

            //Tam ung
            string sql_TU = "select gd.MaTkNo as MaTkNo,gd.MaTkCo as MaTkCo, gd.SoTien as SoTien, " +
                         "gd.SoTienNt as SoTienNt,gd.NoiDung as NoiDung, gd.DoanRaNoId as DoanRaNoId," +
                         "gd.DoanRaCoId as DoanRaCoId ,gd.LoaiDoanRaNoId as LoaiDoanRaNoId,gd.LoaiDoanRaCoId as LoaiDoanRaCoId, " +
                         "gd.MucTieuMucNoId as MucTieuMucNoId ,gd.MucTieuMucCoId as MucTieuMucCoId,gd.ChungTuId as ChungTuId " +
                         "from VnsGiaoDich gd " +
                         "inner join gd.objChungTu ct " +
                          "inner join gd.objDoanRa dr " +
                         "where ct.NgayCt >=:p_TuNgay " + 
                         "AND ct.NgayCt <=:p_DenNgay " +
                         //"AND ((dr.NgayQuyetToan > :p_DenNgay and dr.TrangThai = 2 and dr.NgayQuyetToan < :maxValue) or dr.TrangThai = 1) " + Code cu
                         "AND ((dr.TrangThai = 2 and dr.NgayQuyetToan > :maxValue) or dr.TrangThai = 1) " + //Code moi
                         (String.IsNullOrEmpty(p_TkCo) ? "" : "AND MaTkCo like :p_TkCo ") +
                         (String.IsNullOrEmpty(p_TkNo) ? "" : "AND MaTkNo like :p_TkNo ") +
                         ((LoaiDoanRa == new Guid()) ? "" : "AND gd.LoaiDoanRaNoId =:LoaiDoanRa ") +
                         ((LoaiDoanRa == new Guid()) ? "" : "AND gd.LoaiDoanRaCoId =:LoaiDoanRa ") +
                         ((p_TrangThaiPhieu == -1) ? "" : "AND ct.TrangThai =:p_TrangThaiPhieu ") +
                         "ORDER BY ct.NgayCt desc ";

            IQuery q = NHibernateSession.CreateQuery(sql_TU);
            q.SetParameter("p_TuNgay", VnsConvert.CStartOfDate(p_TuNgay));
            q.SetParameter("p_DenNgay", VnsConvert.CEndOfDate(p_DenNgay));
            q.SetParameter("maxValue", VnsConvert.CEndOfDate(maxValue));
            if (!String.IsNullOrEmpty(p_TkCo)) q.SetParameter("p_TkCo", p_TkCo + "%");
            if (!String.IsNullOrEmpty(p_TkNo)) q.SetParameter("p_TkNo", p_TkNo + "%");
            if (LoaiDoanRa != new Guid()) q.SetParameter("LoaiDoanRa", LoaiDoanRa);
            if (!(p_TrangThaiPhieu == -1)) q.SetParameter("p_TrangThaiPhieu", p_TrangThaiPhieu);
            q.SetResultTransformer(Transformers.AliasToBean<VnsGiaoDich>());
            IList<VnsGiaoDich> lstTu = q.List<VnsGiaoDich>();

            //Hoan ung khong qua quyet toan
            string sql_HU = "select gd.MaTkNo as MaTkNo,gd.MaTkCo as MaTkCo, gd.SoTien as SoTien, " +
                         "gd.SoTienNt as SoTienNt,gd.NoiDung as NoiDung, gd.DoanRaNoId as DoanRaNoId," +
                         "gd.DoanRaCoId as DoanRaCoId ,gd.LoaiDoanRaNoId as LoaiDoanRaNoId,gd.LoaiDoanRaCoId as LoaiDoanRaCoId, " +
                         "gd.MucTieuMucNoId as MucTieuMucNoId ,gd.MucTieuMucCoId as MucTieuMucCoId,gd.ChungTuId as ChungTuId " +
                         "from VnsGiaoDich gd " +
                         "inner join gd.objChungTu ct " +
                          "inner join gd.objDoanRa dr " +
                         "where ct.NgayCt >=:p_TuNgay " +
                         "AND ct.NgayCt <=:p_DenNgay " +
                //"AND ((dr.NgayQuyetToan > :p_DenNgay and dr.TrangThai = 2 and dr.NgayQuyetToan < :maxValue) or dr.TrangThai = 1) " + Code cu
                         "AND ((dr.TrangThai = 2 and dr.NgayQuyetToan > :maxValue) or dr.TrangThai = 1) " + //Code moi
                         (String.IsNullOrEmpty(p_TkCo) ? "" : "AND MaTkNo like :p_TkCo ") +
                         (String.IsNullOrEmpty(p_TkNo) ? "" : "AND MaTkCo like :p_TkNo ") +
                         ((LoaiDoanRa == new Guid()) ? "" : "AND gd.LoaiDoanRaNoId =:LoaiDoanRa ") +
                         ((LoaiDoanRa == new Guid()) ? "" : "AND gd.LoaiDoanRaCoId =:LoaiDoanRa ") +
                         ((p_TrangThaiPhieu == -1) ? "" : "AND ct.TrangThai =:p_TrangThaiPhieu ") +
                         "AND dr.NgayQuyetToan > ct.NgayCt " +
                         "ORDER BY ct.NgayCt desc ";

            IQuery q_HU = NHibernateSession.CreateQuery(sql_HU);
            q_HU.SetParameter("p_TuNgay", VnsConvert.CStartOfDate(p_TuNgay));
            q_HU.SetParameter("p_DenNgay", VnsConvert.CEndOfDate(p_DenNgay));
            q_HU.SetParameter("maxValue", VnsConvert.CEndOfDate(maxValue));
            if (!String.IsNullOrEmpty(p_TkCo)) q_HU.SetParameter("p_TkCo", p_TkCo + "%");
            if (!String.IsNullOrEmpty(p_TkNo)) q_HU.SetParameter("p_TkNo", p_TkNo + "%");
            if (LoaiDoanRa != new Guid()) q_HU.SetParameter("LoaiDoanRa", LoaiDoanRa);
            if (!(p_TrangThaiPhieu == -1)) q_HU.SetParameter("p_TrangThaiPhieu", p_TrangThaiPhieu);
            q_HU.SetResultTransformer(Transformers.AliasToBean<VnsGiaoDich>());

            IList<VnsGiaoDich> lstHU = q_HU.List<VnsGiaoDich>();

            foreach (VnsGiaoDich tmp in lstHU)
            {
                tmp.SoTien = tmp.SoTien * -1;
                tmp.SoTienNt = tmp.SoTienNt * -1;

                lstTu.Add(tmp);
            }

            return lstTu;
        }

        //Có dự toán và cái ngày dự toán < đến ngày
        //quyết toán > đến ngày
        public IList<VnsDoanCongTac> GetListDoanRa(DateTime p_TuNgay, DateTime p_DenNgay, Guid LoaiDoanRa)
        {
            string sql = "from VnsDoanCongTac dr " +
                         "where (dr.NgayQuyetToan > :p_DenNgay)";

            IQuery q = NHibernateSession.CreateQuery(sql);
            q.SetParameter("p_DenNgay", VnsConvert.CEndOfDate(p_DenNgay));
            q.SetResultTransformer(Transformers.AliasToBean<VnsDoanCongTac>());
            return q.List<VnsDoanCongTac>();
        }

        public IList<RP_Doan_CongNo> GetListSoDu(String pTk, DateTime p_TuNgay, DateTime p_DenNgay, Guid p_loaiDoanRaNoId, Guid p_loaiDoanRaCoId, 
            Guid p_GiaoDichId)
        {
            //Lay theo tai khoan no
            string sqlNo =
                        "select " +
                        "Sum(Case When MaTkNo Like '" + pTk + "%' Then gd.SoTienNt " +
                            "Else 0 End) as PsNo, " +
                        "Sum(Case When MaTkNo Like '" + pTk + "%' Then gd.SoTien " +
                            "Else 0 End) as PsNoVND, " +
                        //"0 as PsCo, " +
                        //"0 as PsCoVND, " +
                        "gd.TyGia as TyGia, " +
                         "gd.LoaiDoanRaNoId as LoaiDoanRaNoId " +
                         //"gd.LoaiDoanRaCoId as LoaiDoanRaCoId " +
                         "from VnsGiaoDich gd " +
                         "inner join gd.objChungTu ct " +
                         //"inner join gd.objDoanRa dr " +
                         "where ct.NgayCt >=: p_TuNgay AND ct.NgayCt <=: p_DenNgay " +
                         //"AND (MaTkNo like :pTk Or MaTkCo like :pTk) " +
                         "AND (MaTkNo like :pTk) " +
                         //"AND (MaTkCo like :pTk AND MaTkNo like :pTkDu) " + //Tam ung cho doan ra
                //"Or  (MaTkCo like :pTk AND MaTkNo like :pTkDu) " + //Truong hop 
                         //"Or  (MaTkCo like :pTkDu AND MaTkNo like :tkThanhToan) " + //Truong hop thanh toan voi nguoi ban
                         ((p_loaiDoanRaNoId == new Guid()) ? "" : "AND gd.LoaiDoanRaNoId =:p_loaiDoanRaNoId ") +
                         ((p_loaiDoanRaCoId == new Guid()) ? "" : "AND gd.LoaiDoanRaCoId =:p_loaiDoanRaCoId ") +
                         ((p_GiaoDichId == new Guid()) ? "" : "AND gd.ChungTuId <> :p_GiaoDichId ") +
                         "Group by LoaiDoanRaNoId, gd.TyGia";

            IQuery q = NHibernateSession.CreateQuery(sqlNo);
            q.SetParameter("p_TuNgay", VnsConvert.CStartOfDate(p_TuNgay));
            q.SetParameter("p_DenNgay", VnsConvert.CEndOfDate(p_DenNgay));
            if (!String.IsNullOrEmpty(pTk)) q.SetParameter("pTk", pTk + "%");
            if (!(p_loaiDoanRaNoId == new Guid())) q.SetParameter("p_loaiDoanRaNoId", p_loaiDoanRaNoId);
            if (!(p_loaiDoanRaCoId == new Guid())) q.SetParameter("p_loaiDoanRaCoId", p_loaiDoanRaCoId);
            if (!(p_GiaoDichId == new Guid())) q.SetParameter("p_GiaoDichId", p_GiaoDichId);

            q.SetResultTransformer(Transformers.AliasToBean<RP_Doan_CongNo>());
            IList<RP_Doan_CongNo> lstNo = q.List<RP_Doan_CongNo>();

            //Lay theo tai khoan co
            string sqlCo =
                        "select " +
                        //"0 as PsNo, " +
                        //"0 as PsNoVND, " +
                        "Sum(Case When MaTkCo Like '" + pTk + "%' Then gd.SoTienNt " +
                            "Else 0 End) as PsCo, " +
                        "Sum(Case When MaTkCo Like '" + pTk + "%' Then gd.SoTien " +
                            "Else 0 End) as PsCoVND, " +
                        "gd.TyGia as TyGia, " +
                         "gd.LoaiDoanRaCoId as LoaiDoanRaCoId " +
                //"gd.LoaiDoanRaCoId as LoaiDoanRaCoId " +
                         "from VnsGiaoDich gd " +
                         "inner join gd.objChungTu ct " +
                //"inner join gd.objDoanRa dr " +
                         "where ct.NgayCt >=: p_TuNgay AND ct.NgayCt <=: p_DenNgay " +
                //"AND (MaTkNo like :pTk Or MaTkCo like :pTk) " +
                         "AND (MaTkCo like :pTk) " +
                //"AND (MaTkCo like :pTk AND MaTkNo like :pTkDu) " + //Tam ung cho doan ra
                //"Or  (MaTkCo like :pTk AND MaTkNo like :pTkDu) " + //Truong hop 
                //"Or  (MaTkCo like :pTkDu AND MaTkNo like :tkThanhToan) " + //Truong hop thanh toan voi nguoi ban
                         ((p_loaiDoanRaNoId == new Guid()) ? "" : "AND gd.LoaiDoanRaNoId =:p_loaiDoanRaNoId ") +
                         ((p_loaiDoanRaCoId == new Guid()) ? "" : "AND gd.LoaiDoanRaCoId =:p_loaiDoanRaCoId ") +
                         ((p_GiaoDichId == new Guid()) ? "" : "AND gd.ChungTuId <> :p_GiaoDichId ") +
                         "Group by LoaiDoanRaCoId, gd.TyGia";

            IQuery qCo = NHibernateSession.CreateQuery(sqlCo);
            qCo.SetParameter("p_TuNgay", VnsConvert.CStartOfDate(p_TuNgay));
            qCo.SetParameter("p_DenNgay", VnsConvert.CEndOfDate(p_DenNgay));
            if (!String.IsNullOrEmpty(pTk)) qCo.SetParameter("pTk", pTk + "%");
            if (!(p_loaiDoanRaNoId == new Guid())) qCo.SetParameter("p_loaiDoanRaNoId", p_loaiDoanRaNoId);
            if (!(p_loaiDoanRaCoId == new Guid())) qCo.SetParameter("p_loaiDoanRaCoId", p_loaiDoanRaCoId);
            if (!(p_GiaoDichId == new Guid())) qCo.SetParameter("p_GiaoDichId", p_GiaoDichId);

            qCo.SetResultTransformer(Transformers.AliasToBean<RP_Doan_CongNo>());
            IList<RP_Doan_CongNo> lstCo = qCo.List<RP_Doan_CongNo>();

            IList<RP_Doan_CongNo> lstSoDu = new List<RP_Doan_CongNo>();
            foreach (RP_Doan_CongNo tmpNo in lstNo)
            {
                for (int i = lstCo.Count -1; i >= 0; i--)
                {
                    if ((tmpNo.LoaiDoanRaNoId == lstCo[i].LoaiDoanRaCoId) && (tmpNo.TyGia == lstCo[i].TyGia))
                    {
                        tmpNo.PsCo += lstCo[i].PsCo;
                        tmpNo.PsCoVND += lstCo[i].PsCoVND;

                        lstCo.RemoveAt(i);
                    }
                }

                tmpNo.LoaiDoanRaCoId = tmpNo.LoaiDoanRaNoId;
                lstSoDu.Add(tmpNo);
            }

            foreach (RP_Doan_CongNo tmpco in lstCo)
            {
                tmpco.LoaiDoanRaNoId = tmpco.LoaiDoanRaCoId;
                lstSoDu.Add(tmpco);
            }

            return lstSoDu;
        }
    }
}
