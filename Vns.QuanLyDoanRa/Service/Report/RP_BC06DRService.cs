using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Service;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.QuanLyDoanRa.Dao.Interface.Report;
using Vns.QuanLyDoanRa.Dao;
using Vns.QuanLyDoanRa.Domain;

namespace Vns.QuanLyDoanRa.Service.Report
{
    public class RP_BC06DRService : GenericService<RP_BC06DR, Guid>, IRP_BC06DRService
    {
        public IRP_SoDuDao RP_SoDuDao;
        public IVnsDoanCongTacDao VnsDoanCongTacDao;
        public IVnsLichCongTacDao VnsLichCongTacDao;

        public IList<RP_BC06DR> GetLstHuThangTruocChuyenSang(DateTime p_TuNgay, DateTime p_DenNgay)
        {
            DateTime m_TuNgay = Null.NullDate;
            DateTime m_DenNgay = p_TuNgay.AddDays(-1);

            IList<RP_SoDuInfo> lstPhaiThu = RP_SoDuDao.GetSoTienPhaiThu(m_TuNgay, m_DenNgay);
            RP_BC06DR obj06Dr;
            IList<RP_BC06DR> lst06Dr = new List<RP_BC06DR>();
            foreach (RP_SoDuInfo objPhaiThu in lstPhaiThu)
            {
                VnsDoanCongTac objDoanCongTac = VnsDoanCongTacDao.GetByKey("Id", objPhaiThu.DoanRaId);
                obj06Dr = new RP_BC06DR();
                obj06Dr.LoaiDoanRaId = objPhaiThu.LoaiDoanRaId;
                obj06Dr.DoanRaId = objPhaiThu.DoanRaId;
                obj06Dr.TenLoaiDoanRa = objDoanCongTac.TenLoaiDoanRa;
                obj06Dr.TenDoanRa = objDoanCongTac.TenLoaiDoanRa + " đ/c " + objDoanCongTac.TruongDoan + " đi " + GetLichCongTac(objDoanCongTac.Id);
                obj06Dr.USD = objPhaiThu.SoTienNt;
                obj06Dr.VND = objPhaiThu.SoTienVND;
                if (obj06Dr.USD > 0)
                    obj06Dr.TG = obj06Dr.VND / obj06Dr.USD;
                obj06Dr.NguoiTamUng = "";
                obj06Dr.GroupByTime = 1;
                obj06Dr.Note = "Kỳ trước chuyển sang";
                lst06Dr.Add(obj06Dr);
            }

            return lst06Dr;
        }        

        public IList<RP_BC06DR> GetLstHuThangNay(DateTime p_TuNgay, DateTime p_DenNgay)
        {
            DateTime m_TuNgay = p_TuNgay;
            DateTime m_DenNgay = p_DenNgay;
            IList<RP_SoDuInfo> lstPhaiThu = RP_SoDuDao.GetSoTienPhaiThu(m_TuNgay, m_DenNgay);
            RP_BC06DR obj06Dr;
            IList<RP_BC06DR> lst06Dr = new List<RP_BC06DR>();
            foreach (RP_SoDuInfo objPhaiThu in lstPhaiThu)
            {
                VnsDoanCongTac objDoanCongTac = VnsDoanCongTacDao.GetByKey("Id", objPhaiThu.DoanRaId);
                obj06Dr = new RP_BC06DR();
                obj06Dr.LoaiDoanRaId = objPhaiThu.LoaiDoanRaId;
                obj06Dr.DoanRaId = objPhaiThu.DoanRaId;
                obj06Dr.TenLoaiDoanRa = objDoanCongTac.TenLoaiDoanRa;
                obj06Dr.TenDoanRa = objDoanCongTac.TenLoaiDoanRa + " đ/c " + objDoanCongTac.TruongDoan + " đi " + GetLichCongTac(objDoanCongTac.Id); 
                obj06Dr.USD = objPhaiThu.SoTienNt;
                obj06Dr.VND = objPhaiThu.SoTienVND;
                if (obj06Dr.USD > 0)
                    obj06Dr.TG = obj06Dr.VND / obj06Dr.USD;
                obj06Dr.NguoiTamUng = "";
                obj06Dr.GroupByTime = 2;
                obj06Dr.Note = "Kỳ này";

                lst06Dr.Add(obj06Dr);
            }

            return lst06Dr;
        }

        public List<RP_BC06DR> GetDataHoanUng(DateTime p_TuNgay, DateTime p_DenNgay)
        {
            DateTime TuNgay = p_TuNgay;
            DateTime DenNgay = p_DenNgay;
            List<RP_BC06DR> lstHoanUng = new List<RP_BC06DR>();
            lstHoanUng.AddRange(GetLstHuThangTruocChuyenSang(TuNgay, DenNgay));
            lstHoanUng.AddRange(GetLstHuThangNay(TuNgay, DenNgay));

            return lstHoanUng;
        }
        
        public IList<RP_BC06DR> GetLstChiQtThangTruocChuyenSang(DateTime p_TuNgay, DateTime p_DenNgay)
        {
            DateTime m_TuNgay = Null.NullDate;
            DateTime m_DenNgay = p_TuNgay.AddDays(-1);
            IList<RP_SoDuInfo> lstPhaiThu = RP_SoDuDao.GetSoTienChiQuyetToan(m_TuNgay, m_DenNgay);
            RP_BC06DR obj06Dr;
            IList<RP_BC06DR> lst06Dr = new List<RP_BC06DR>();
            foreach (RP_SoDuInfo objPhaiThu in lstPhaiThu)
            {
                VnsDoanCongTac objDoanCongTac = VnsDoanCongTacDao.GetByKey("Id", objPhaiThu.DoanRaId);
                obj06Dr = new RP_BC06DR();
                obj06Dr.LoaiDoanRaId = objPhaiThu.LoaiDoanRaId;
                obj06Dr.DoanRaId = objPhaiThu.DoanRaId;
                obj06Dr.TenLoaiDoanRa = objDoanCongTac.TenLoaiDoanRa;
                obj06Dr.TenDoanRa = objDoanCongTac.TenLoaiDoanRa + " đ/c " + objDoanCongTac.TruongDoan + " đi " + GetLichCongTac(objDoanCongTac.Id); 
                obj06Dr.USD = objPhaiThu.SoTienNt;
                obj06Dr.VND = objPhaiThu.SoTienVND;
                if (obj06Dr.USD > 0)
                    obj06Dr.TG = obj06Dr.VND / obj06Dr.USD;
                obj06Dr.NguoiTamUng = "";
                obj06Dr.GroupByTime = 1;
                obj06Dr.Note = "Kỳ trước chuyển sang";
                lst06Dr.Add(obj06Dr);
            }

            return lst06Dr;
        }

        public IList<RP_BC06DR> GetLstChiQtThangNay(DateTime p_TuNgay, DateTime p_DenNgay) 
        {
            DateTime m_TuNgay = p_TuNgay;
            DateTime m_DenNgay = p_DenNgay;
            IList<RP_SoDuInfo> lstPhaiThu = RP_SoDuDao.GetSoTienChiQuyetToan(m_TuNgay, m_DenNgay);
            RP_BC06DR obj06Dr;
            IList<RP_BC06DR> lst06Dr = new List<RP_BC06DR>();
            foreach (RP_SoDuInfo objPhaiThu in lstPhaiThu)
            {
                VnsDoanCongTac objDoanCongTac = VnsDoanCongTacDao.GetByKey("Id", objPhaiThu.DoanRaId);
                obj06Dr = new RP_BC06DR();
                obj06Dr.LoaiDoanRaId = objPhaiThu.LoaiDoanRaId;
                obj06Dr.DoanRaId = objPhaiThu.DoanRaId;
                obj06Dr.TenLoaiDoanRa = objDoanCongTac.TenLoaiDoanRa;
                obj06Dr.TenDoanRa = objDoanCongTac.TenLoaiDoanRa + " đ/c " + objDoanCongTac.TruongDoan + " đi " + GetLichCongTac(objDoanCongTac.Id); 
                obj06Dr.USD = objPhaiThu.SoTienNt;
                obj06Dr.VND = objPhaiThu.SoTienVND;
                if (obj06Dr.USD > 0)
                    obj06Dr.TG = obj06Dr.VND / obj06Dr.USD;
                obj06Dr.NguoiTamUng = "";
                obj06Dr.GroupByTime = 2;
                obj06Dr.Note = "Kỳ này";

                lst06Dr.Add(obj06Dr);
            }

            return lst06Dr;
        }

        public List<RP_BC06DR> GetDataChiQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay)
        {
            DateTime TuNgay =p_TuNgay;
            DateTime DenNgay = p_DenNgay;
            List<RP_BC06DR> lstChiQuyetToan = new List<RP_BC06DR>();
            lstChiQuyetToan.AddRange(GetLstChiQtThangTruocChuyenSang(TuNgay, DenNgay));
            lstChiQuyetToan.AddRange(GetLstChiQtThangNay(TuNgay, DenNgay));

            return lstChiQuyetToan;
        }

        private String GetLichCongTac(Guid DoanRaId)
        {
            String strNuocCongTac = "";
            IList<VnsLichCongTac> lstLichCongTac = VnsLichCongTacDao.GetNuocDen(DoanRaId);
            foreach (VnsLichCongTac obj in lstLichCongTac)
            {
                if (strNuocCongTac == "")
                    strNuocCongTac = obj.DiaDiem;
                else
                    strNuocCongTac = strNuocCongTac + ", " + obj.DiaDiem;
            }

            return strNuocCongTac;
        }
    }
}
