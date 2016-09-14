using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Service;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Dao;

namespace Vns.QuanLyDoanRa.Service.Report
{
    public class RP_BangKeQTService : GenericService<RP_BangKeQT, Guid>, IRP_BangKeQTService
    {
        public IRP_BC04DRDao RP_BC04DRDao;
        public IReportDao ReportDao;
        public IVnsLoaiDoanRaDao VnsLoaiDoanRaDao;
        public IList<RP_BangKeQT> GetDataBangkeQuyetToan(DateTime p_TuNgay,DateTime p_DenNgay)
        {
            DateTime TuNgay = p_TuNgay;
            DateTime DenNgay = p_DenNgay;
            RP_BangKeQT objBangKe;
            VnsLoaiDoanRa objLoaiDoanRa;
            IList<VnsGiaoDich> lstGiaoDich = ReportDao.GetLstGiaoDich(TuNgay, DenNgay, new Guid(), new Guid(), new Guid(), new Guid(), Globals.LikeTkQt, Globals.TkTamUng, 0, 2);
                //RP_BC04DRDao.GetLstGiaoDichByLoaiCt(TuNgay, DenNgay, new Guid(), "QT", 0);
            IList<RP_BangKeQT> lstBangKe = new List<RP_BangKeQT>();
            foreach (VnsGiaoDich objGiaoDich in lstGiaoDich)
            {
                objLoaiDoanRa = new VnsLoaiDoanRa();
                objBangKe = new RP_BangKeQT();

                objLoaiDoanRa = VnsLoaiDoanRaDao.Get(objGiaoDich.LoaiDoanRaCoId);
                objBangKe.TenLoaiDoanRa = objLoaiDoanRa.TenLoaiDoanRa;
                objBangKe.LoaiDoanRaId = objLoaiDoanRa.Id;
                objBangKe.DoanRaId = objGiaoDich.DoanRaCoId;
                objBangKe.TienMatTG = objGiaoDich.TyGia;
                objBangKe.TienMatUSD = objGiaoDich.SoTienNt;
                objBangKe.TienMatVND = objGiaoDich.SoTien;
                objBangKe.ChuyenKhoanTG = 0;
                objBangKe.ChuyenKhoanUSD = 0;
                objBangKe.ChuyenKhoanVND = 0;
                objBangKe.NoiDung = objGiaoDich.NoiDung;

                objBangKe.TongUSD = objBangKe.TienMatUSD + objBangKe.ChuyenKhoanUSD;
                objBangKe.TongVND = objBangKe.TienMatVND + objBangKe.ChuyenKhoanVND;
                lstBangKe.Add(objBangKe);
            }

            return lstBangKe;
        }
    }
}
