using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Dao.NHibernate;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Dao.Interface.Report;
using Vns.QuanLyDoanRa.Domain;
using NHibernate;
using NHibernate.Transform;

namespace Vns.QuanLyDoanRa.Dao.NHibernate
{
    public sealed class RP_SoDuDao : GenericDao<RP_SoDuInfo, Guid>, IRP_SoDuDao
    {
        public IList<VnsGiaoDich> GetLstGiaoDich(DateTime p_TuNgay, DateTime p_DenNgay,string p_TkNoId, string p_TkCoId, decimal p_TrangThaiPhieu, decimal p_TrangThaiDoanCt)
        {
            string sql = "select sum(gd.SoTien) as SoTien, " +
                         "sum(gd.SoTienNt) as SoTienNt, gd.DoanRaNoId as DoanRaNoId," +
                         "gd.DoanRaCoId as DoanRaCoId ,gd.LoaiDoanRaNoId as LoaiDoanRaNoId,gd.LoaiDoanRaCoId as LoaiDoanRaCoId " +
                         "from VnsGiaoDich gd " +
                         "inner join gd.objChungTu ct " +
                          "inner join gd.objDoanRa dr " +
                         "where ct.NgayCt >=: p_TuNgay AND ct.NgayCt <=: p_DenNgay " +
                         (String.IsNullOrEmpty(p_TkCoId) ? "" : "AND MaTkCo like :p_TkCoId ") +
                         (String.IsNullOrEmpty(p_TkNoId) ? "" : "AND MaTkNo like :p_TkNoId ") +
                         ((p_TrangThaiDoanCt == 0) ? "" : "AND dr.TrangThai =:p_TrangThaiDoanCt ") +
                         ((p_TrangThaiPhieu == -1) ? "" : "AND ct.TrangThai =:p_TrangThaiPhieu ") +
                         "GROUP BY gd.DoanRaNoId,gd.DoanRaCoId,gd.LoaiDoanRaNoId,gd.LoaiDoanRaCoId ";
                         
            IQuery q = NHibernateSession.CreateQuery(sql);
            q.SetParameter("p_TuNgay", VnsConvert.CStartOfDate(p_TuNgay));
            q.SetParameter("p_DenNgay", VnsConvert.CEndOfDate(p_DenNgay));
            if (!String.IsNullOrEmpty(p_TkCoId)) q.SetParameter("p_TkCoId", p_TkCoId + "%");
            if (!String.IsNullOrEmpty(p_TkNoId)) q.SetParameter("p_TkNoId", p_TkNoId + "%");
            if (!(p_TrangThaiDoanCt == 0)) q.SetParameter("p_TrangThaiDoanCt", p_TrangThaiDoanCt);
            if (!(p_TrangThaiPhieu == -1)) q.SetParameter("p_TrangThaiPhieu", p_TrangThaiPhieu);
            q.SetResultTransformer(Transformers.AliasToBean<VnsGiaoDich>());
            return q.List<VnsGiaoDich>();
        }

        //Hoan ung va quyet toan CO = 141
        public IList<VnsGiaoDich> GetLstQT_Hu(DateTime p_TuNgay, DateTime p_DenNgay)
        {
            return GetLstGiaoDich(p_TuNgay, p_DenNgay,"", Globals.TkTamUng,-1,2);
        }

        public IList<VnsGiaoDich> GetLstQT(DateTime p_TuNgay, DateTime p_DenNgay)
        {
            return GetLstGiaoDich(p_TuNgay, p_DenNgay, Globals.LikeTkQt, Globals.TkTamUng,-1,0);
        }

        //So tien tam ung cua cac doan ra da duoc quyet toan(trang thai =2)
        public IList<VnsGiaoDich> GetLstTamUngDoanRaDaQt(DateTime p_TuNgay, DateTime p_DenNgay)
        {
            return GetLstGiaoDich(p_TuNgay, p_DenNgay, Globals.TkTamUng,Globals.TkTienLike,0,2);
        }

        //Phai thu cua khach hang = TU - QT - HU
        public IList<RP_SoDuInfo> GetSoTienPhaiThu(DateTime p_TuNgay, DateTime p_DenNgay)
        {
            IList<RP_SoDuInfo> lstPhaiThu = new List<RP_SoDuInfo>();
            RP_SoDuInfo objPhaiThu;
            IList<VnsGiaoDich> lstQt_Hu = GetLstQT_Hu(p_TuNgay, p_DenNgay);
            IList<VnsGiaoDich> lstTu = GetLstTamUngDoanRaDaQt(p_TuNgay, p_DenNgay);
            Decimal SoTienNt;
            Decimal SoTienVND;
            foreach (VnsGiaoDich objQt in lstQt_Hu)
            {
                SoTienNt = 0;
                SoTienVND = 0;
                objPhaiThu = new RP_SoDuInfo();
                foreach (VnsGiaoDich objTu in lstTu)
                {
                    if (objTu.DoanRaCoId == objQt.DoanRaNoId)
                    {
                        SoTienNt = objQt.SoTienNt - objTu.SoTienNt;
                        SoTienVND = objQt.SoTien - objTu.SoTien;
                    }
                }

                if (SoTienNt < 0)
                {
                    objPhaiThu.SoTienNt = Math.Abs(SoTienNt);
                    objPhaiThu.SoTienVND =Math.Abs(SoTienVND);
                    objPhaiThu.DoanRaId = objQt.DoanRaNoId;
                    objPhaiThu.LoaiDoanRaId = objQt.LoaiDoanRaNoId;
                    lstPhaiThu.Add(objPhaiThu);
                }
            }
            return lstPhaiThu;
        }

        //Phai tra cho khach hang QT-TU-PC
        public IList<RP_SoDuInfo> GetSoTienChiQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay)
        {
            IList<RP_SoDuInfo> lstChiQuyetToan = new List<RP_SoDuInfo>();
            RP_SoDuInfo objChiQuyetToan;
            IList<VnsGiaoDich> lstQt = GetLstQT(p_TuNgay, p_DenNgay);
            IList<VnsGiaoDich> lstTu = GetLstTamUngDoanRaDaQt(p_TuNgay, p_DenNgay);
            IList<VnsGiaoDich> lstDaTra = GetLstGiaoDich(p_TuNgay, p_DenNgay,Globals.TkTienLike,Globals.TkTamUng,-1,2);
            Decimal SoTienNt;
            Decimal SoTienVND;
            foreach (VnsGiaoDich objQt in lstQt)
            {
                SoTienNt = 0;
                SoTienVND = 0;
                objChiQuyetToan = new RP_SoDuInfo();
                foreach (VnsGiaoDich objTu in lstTu)
                {
                    if (objTu.DoanRaCoId == objQt.DoanRaNoId)
                    {
                        SoTienNt = objQt.SoTienNt - objTu.SoTienNt;
                        SoTienVND = objQt.SoTien - objTu.SoTien;
                    }
                }

                foreach (VnsGiaoDich objdt in lstDaTra)
                {
                    if (objdt.DoanRaNoId == objQt.DoanRaCoId)
                    {
                        SoTienNt = objQt.SoTienNt - objdt.SoTienNt;
                        SoTienVND = objQt.SoTien - objdt.SoTien;
                    }
                }

                if (SoTienNt > 0)
                {
                    objChiQuyetToan.SoTienNt = SoTienNt;
                    objChiQuyetToan.SoTienVND = SoTienVND;
                    objChiQuyetToan.DoanRaId = objQt.DoanRaNoId;
                    objChiQuyetToan.LoaiDoanRaId = objQt.LoaiDoanRaNoId;
                    lstChiQuyetToan.Add(objChiQuyetToan);
                }

            }

            return lstChiQuyetToan;
        }
    }
}
