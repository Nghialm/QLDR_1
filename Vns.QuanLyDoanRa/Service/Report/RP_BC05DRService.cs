using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.Erp.Core.Service;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Dao;
using Vns.QuanLyDoanRa.Dao.Interface.Report;

namespace Vns.QuanLyDoanRa.Service.Report
{
    public class RP_BC05DRService : GenericService<RP_BC05DR, Guid>, IRP_BC05DRService
    {
        public IRP_SoDuDao  RP_SoDuDao;
        public IReportDao ReportDao;
        public IVnsLoaiDoanRaDao VnsLoaiDoanRaDao;
        public IVnsDoanCongTacDao VnsDoanCongTacDao; 
        public List<RP_BC05DR> GetSoTienPhaiThu(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId)
        {
            //DateTime TuNgay = Null.NullDate;
            //DateTime DenNgay = p_TuNgay.AddDays(-1);
            //IList<VnsGiaoDich> lstDaChi = new List<VnsGiaoDich>();
            //IList<VnsGiaoDich> lstDaThu = new List<VnsGiaoDich>();
            ////Get so tien đã chi
            //IList<VnsGiaoDich> lstGiaoDichTu = ReportDao.GetLstGiaoDichGroupByLoaiDr(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, 0, 0);
            //List<VnsGiaoDich> lstGiaoDichChiQt = new List<VnsGiaoDich>();
            //lstGiaoDichChiQt.AddRange(ReportDao.GetLstGiaoDichGroupByLoaiDr(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, 1, 2));
            //lstGiaoDichChiQt.AddRange(ReportDao.GetLstGiaoDichGroupByLoaiDr(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, 2, 2));

            //foreach (VnsGiaoDich objTu in lstGiaoDichTu)
            //{
            //    VnsGiaoDich objChi = new VnsGiaoDich();
            //    objChi = objTu;
            //    foreach (VnsGiaoDich objChiQt in lstGiaoDichChiQt)
            //    {
            //        if (objChi.DoanRaCoId == objChiQt.DoanRaCoId && objChi.DoanRaNoId == objChiQt.DoanRaCoId)
            //        {
            //            objChi.SoTien += objChiQt.SoTien;
            //            objChi.SoTienNt = objChiQt.SoTienNt;
            //        }
            //    }
            //    lstDaChi.Add(objChi);
            //}
            
            ////Get so tien quyet toan
            //IList<VnsGiaoDich> lstGiaoDichQt = ReportDao.GetLstGiaoDichGroupByLoaiDr(TuNgay, DenNgay, p_LoaiDoanRaId, Globals.LikeTkQt, Globals.TkTamUng, 0, 2);
            ////Get so tien HU
            //IList<VnsGiaoDich> lstGiaoDichHu = ReportDao.GetLstGiaoDichGroupByLoaiDr(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, Globals.LikeTkTienMat, Globals.TkTamUng, 2, 2);
            //foreach (VnsGiaoDich objQt in lstGiaoDichQt)
            //{
            //    VnsGiaoDich objThu = new VnsGiaoDich();
            //    objThu = objQt;
            //    foreach (VnsGiaoDich objChiHu in lstGiaoDichHu)
            //    {
            //        if (objThu.DoanRaCoId == objChiHu.DoanRaCoId && objThu.DoanRaNoId == objChiHu.DoanRaCoId)
            //        {
            //            objThu.SoTien += objChiHu.SoTien;
            //            objThu.SoTienNt = objChiHu.SoTienNt;
            //        }
            //    }

            //    lstDaThu.Add(objThu);
            //}          
            

            return new List<RP_BC05DR>();
        }

        // tien thu chenh lech = so tien Da thu quyet toan cua thang truoc chuyen sang
        public List<RP_BC05DR> GetSoTienThuChenhLech(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId)
        {
            List<RP_BC05DR> lst05 = new List<RP_BC05DR>();
            //RP_BC05DR obj05;
            //IList<VnsGiaoDich> lstGiaoDichHu = ReportDao.GetLstGiaoDichGroupByLoaiDr(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, Globals.LikeTkTienMat, Globals.TkTamUng, 1,2);

            //foreach (VnsGiaoDich obj in lstGiaoDichHu)
            //{
            //    obj05 = new RP_BC05DR();
            //    obj05.SoThuChenhLechUSD = obj.SoTienNt;
            //    obj05.SoThuChenhLechVND = obj.SoTien;
            //    obj05.NoiDung = "Chưa QT tháng trước";
            //    obj05.GroupByTime = 1;
            //    obj05.LoaiDoanRaId = (obj.LoaiDoanRaCoId == new Guid() ? obj.LoaiDoanRaNoId : obj.LoaiDoanRaCoId);
            //    lst05.Add(obj05);                
            //}

            return lst05;
        }

        public List<RP_BC05DR> GetLstTamUng(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId)
        {
            List<RP_BC05DR> lst05 = new List<RP_BC05DR>();
            //RP_BC05DR obj05;
            //IList<VnsGiaoDich> lstGiaoDichTu = ReportDao.GetLstGiaoDichGroupByLoaiDr(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, 0, 0);

            //foreach (VnsGiaoDich obj in lstGiaoDichTu)
            //{
            //    obj05 = new RP_BC05DR();
            //    obj05.SoTamUngUSD = obj.SoTienNt;
            //    obj05.SoTamUngVND = obj.SoTien;
            //    obj05.NoiDung = "Chưa QT tháng này";
            //    obj05.GroupByTime =2;
            //    obj05.LoaiDoanRaId = (obj.LoaiDoanRaCoId == new Guid() ? obj.LoaiDoanRaNoId : obj.LoaiDoanRaCoId);
            //    lst05.Add(obj05);
            //}

            return lst05;
        }


        public List<RP_BC05DR> GetLstChiQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId) 
        {
            List<RP_BC05DR> lst05 = new List<RP_BC05DR>();
            //RP_BC05DR obj05;
            //List<VnsGiaoDich> lstGiaoDichQt = new List<VnsGiaoDich>();
            //lstGiaoDichQt.AddRange(ReportDao.GetLstGiaoDichGroupByLoaiDr(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, 1, 2));
            //lstGiaoDichQt.AddRange(ReportDao.GetLstGiaoDichGroupByLoaiDr(p_TuNgay, p_DenNgay, p_LoaiDoanRaId,Globals.TkTamUng, Globals.LikeTkTienMat, 2, 2));

            //foreach (VnsGiaoDich obj in lstGiaoDichQt)
            //{
            //    obj05 = new RP_BC05DR();
            //    obj05.SoChiQuyetToanUSD = obj.SoTienNt;
            //    obj05.SoChiQuyetToanVND = obj.SoTien;
            //    obj05.NoiDung = "Chưa QT tháng này";
            //    obj05.GroupByTime = 2;
            //    obj05.LoaiDoanRaId = (obj.LoaiDoanRaCoId == new Guid() ? obj.LoaiDoanRaNoId : obj.LoaiDoanRaCoId);
            //    lst05.Add(obj05);
            //}

            return lst05;
        }

        public List<RP_BC05DR> GetListData(DateTime p_TuNgay, DateTime p_DenNgay)
        {
            List<RP_BC05DR> lst05 = new List<RP_BC05DR>();

            IList<VnsLoaiDoanRa> lstLoaiDoanRa = VnsLoaiDoanRaDao.GetAll();
            foreach (VnsLoaiDoanRa objLoaiDoanRa in lstLoaiDoanRa)
            {

                //RP_BC05DR objThangTruoc = new RP_BC05DR();

                //DateTime TuNgay = Null.NullDate;
                //DateTime DenNgay = p_TuNgay.AddDays(-1);
                //// get giao dich tam ung thang truoc
                //decimal dSoTamUngUSDThangTruoc = 0;
                //decimal dSoTamUngVNSThangTruoc = 0;
                //IList<VnsGiaoDich> lstGiaoDichTu_thangtruoc = ReportDao.GetLstGiaoDichGroupByLoaiDr(TuNgay, DenNgay, objLoaiDoanRa.Id, Globals.TkTamUng, Globals.LikeTkTienMat, 0, 0);
                //foreach (VnsGiaoDich obj in lstGiaoDichTu_thangtruoc)
                //{
                //    dSoTamUngUSDThangTruoc += obj.SoTienNt;
                //    dSoTamUngVNSThangTruoc += obj.SoTien;
                //}
                //// get giao dich quyet toan thang truoc
                //decimal dSoQuyetToanUSDThangTruoc = 0;
                //decimal dSoQuyetToanVNDThangTruoc = 0;
                //IList<VnsGiaoDich> lstGiaoDichQTThangTruoc = ReportDao.GetLstGiaoDichGroupByLoaiDr(TuNgay, DenNgay, objLoaiDoanRa.Id, Globals.LikeTkQt, Globals.TkTamUng, 0, 2);
                //foreach (VnsGiaoDich objQT in lstGiaoDichQTThangTruoc)
                //{
                //    dSoQuyetToanUSDThangTruoc += objQT.SoTienNt;
                //    dSoQuyetToanVNDThangTruoc += objQT.SoTien;
                //}

                //// get giao dich hoan ung thang truoc
                //decimal dHoanUngUSDThangTruoc = 0;
                //decimal dHoanUngVNDThangTruoc = 0;

                //IList<VnsGiaoDich> lstGiaoDichHuThangTruoc = ReportDao.GetLstGiaoDichGroupByLoaiDr(TuNgay, DenNgay, objLoaiDoanRa.Id, Globals.LikeTkTienMat, Globals.TkTamUng, 1, 2);
                //foreach (VnsGiaoDich objHU in lstGiaoDichHuThangTruoc)
                //{
                //    dHoanUngUSDThangTruoc += objHU.SoTienNt;
                //    dHoanUngVNDThangTruoc += objHU.SoTien;
                //}
                //// get list giao dich chi quyet toan
                //decimal dChiQTUSDThangTruoc = 0;
                //decimal dChiQTVNDThangTruoc = 0;
                //List<VnsGiaoDich> lstGiaoDichChiQtThangTruoc = new List<VnsGiaoDich>();
                //lstGiaoDichChiQtThangTruoc.AddRange(ReportDao.GetLstGiaoDichGroupByLoaiDr(TuNgay, DenNgay, objLoaiDoanRa.Id, Globals.TkTamUng, Globals.LikeTkTienMat, 1, 2));
                //lstGiaoDichChiQtThangTruoc.AddRange(ReportDao.GetLstGiaoDichGroupByLoaiDr(TuNgay, DenNgay, objLoaiDoanRa.Id, Globals.TkTamUng, Globals.LikeTkTienMat, 2, 2));

                //foreach (VnsGiaoDich objChiQT in lstGiaoDichChiQtThangTruoc)
                //{
                //    dChiQTUSDThangTruoc += objChiQT.SoTienNt;
                //    dChiQTVNDThangTruoc += objChiQT.SoTien;
                //}

                //decimal dSoUSDPhaiThuThangTruoc = 0;
                //decimal dSoVNDPhaiThuThangTruoc = 0;
                //dSoUSDPhaiThuThangTruoc =(dSoTamUngUSDThangTruoc + dChiQTUSDThangTruoc)- (dSoQuyetToanUSDThangTruoc + dHoanUngUSDThangTruoc);
                //dSoVNDPhaiThuThangTruoc = (dSoTamUngVNSThangTruoc + dChiQTVNDThangTruoc)-(dSoQuyetToanVNDThangTruoc + dHoanUngVNDThangTruoc);

                //// get du lieu trong thang
                //// get giao dich tam ung trong thang
                //decimal dSoTamUngUSDTrongThang = 0;
                //decimal dSoTamUngVNSTrongThang = 0;
                //IList<VnsGiaoDich> lstGiaoDichTu = ReportDao.GetLstGiaoDichGroupByLoaiDr(p_TuNgay, p_DenNgay, objLoaiDoanRa.Id, Globals.TkTamUng, Globals.LikeTkTienMat, 0, 0);
                //foreach (VnsGiaoDich obj in lstGiaoDichTu)
                //{
                //    dSoTamUngUSDTrongThang += obj.SoTienNt;
                //    dSoTamUngVNSTrongThang += obj.SoTien;
                //}

                //// get giao dich quyet toan trong thang
                //decimal dSoQuyetToanUSDTrongThang = 0;
                //decimal dSoQuyetToanVNDTrongThang = 0;
                //IList<VnsGiaoDich> lstGiaoDichQT = ReportDao.GetLstGiaoDichGroupByLoaiDr(p_TuNgay, p_DenNgay, objLoaiDoanRa.Id, Globals.LikeTkQt, Globals.TkTamUng, 0, 2);
                //foreach (VnsGiaoDich objQT in lstGiaoDichQT)
                //{
                //    dSoQuyetToanUSDTrongThang += objQT.SoTienNt;
                //    dSoQuyetToanVNDTrongThang += objQT.SoTien;
                //}

                //// get giao dich hoan ung trong thang
                //decimal dHoanUngUSDTrongThang = 0;
                //decimal dHoanUngVNDTrongThang = 0;

                //IList<VnsGiaoDich> lstGiaoDichHu = ReportDao.GetLstGiaoDichGroupByLoaiDr(p_TuNgay, p_DenNgay, objLoaiDoanRa.Id, Globals.LikeTkTienMat, Globals.TkTamUng, 1, 2);
                //foreach (VnsGiaoDich objHU in lstGiaoDichHu)
                //{
                //    dHoanUngUSDTrongThang += objHU.SoTienNt;
                //    dHoanUngVNDTrongThang += objHU.SoTien;
                //}
                //// get list giao dich chi quyet toan
                //decimal dChiQTUSDTrongThang = 0;
                //decimal dChiQTVNDTrongThang = 0;
                //List<VnsGiaoDich> lstGiaoDichChiQt = new List<VnsGiaoDich>();
                //lstGiaoDichChiQt.AddRange(ReportDao.GetLstGiaoDichGroupByLoaiDr(p_TuNgay, p_DenNgay, objLoaiDoanRa.Id, Globals.TkTamUng, Globals.LikeTkTienMat, 1, 2));
                //lstGiaoDichChiQt.AddRange(ReportDao.GetLstGiaoDichGroupByLoaiDr(p_TuNgay, p_DenNgay, objLoaiDoanRa.Id, Globals.TkTamUng, Globals.LikeTkTienMat, 2, 2));

                //foreach (VnsGiaoDich objChiQT in lstGiaoDichChiQt)
                //{
                //    dChiQTUSDTrongThang += objChiQT.SoTienNt;
                //    dChiQTVNDTrongThang += objChiQT.SoTien;
                //}


                //// tong hop du lieu thang truoc
                //objThangTruoc.SoTamUngUSD = dSoTamUngUSDThangTruoc;
                //objThangTruoc.SoTamUngVND = dSoTamUngVNSThangTruoc;

                //objThangTruoc.SoQtTrongThangUSD = dSoQuyetToanUSDThangTruoc;
                //objThangTruoc.SoQtTrongThangVND = dSoQuyetToanVNDThangTruoc;

                //objThangTruoc.SoChiQuyetToanUSD = dChiQTUSDThangTruoc;
                //objThangTruoc.SoChiQuyetToanVND = dChiQTVNDThangTruoc;

                //objThangTruoc.SoThuChenhLechUSD = dHoanUngUSDThangTruoc;
                //objThangTruoc.SoThuChenhLechVND = dHoanUngVNDThangTruoc;

                //objThangTruoc.SoBuTruHtUSD = dSoUSDPhaiThuThangTruoc;
                //objThangTruoc.SoBuTruHtVND = dSoVNDPhaiThuThangTruoc;
                //objThangTruoc.SoBuTruTsUSD = dSoUSDPhaiThuThangTruoc - dHoanUngUSDTrongThang ;
                //objThangTruoc.SoBuTruTsVND = dSoVNDPhaiThuThangTruoc - dHoanUngVNDTrongThang ;

                //objThangTruoc.SoChuaThuTsUSD = 0;
                //objThangTruoc.SoChuaThuTsVND = 0;
                //objThangTruoc.GroupByTime = 1;
                //objThangTruoc.NoiDung = "Chưa QT tháng trước";
                //objThangTruoc.LoaiDoanRaId = objLoaiDoanRa.Id;
                //objThangTruoc.TenLoaiDoanRa = objLoaiDoanRa.TenLoaiDoanRa;
                //lst05.Add(objThangTruoc);


                //RP_BC05DR objTUChuaQTTrongThang = new RP_BC05DR();
                
                
                //objTUChuaQTTrongThang.SoTamUngUSD = dSoTamUngUSDTrongThang;
                //objTUChuaQTTrongThang.SoTamUngVND = dSoTamUngVNSTrongThang;

                //objTUChuaQTTrongThang.SoQtTrongThangUSD = dSoQuyetToanUSDTrongThang;
                //objTUChuaQTTrongThang.SoQtTrongThangVND = dSoQuyetToanVNDTrongThang;

                //objTUChuaQTTrongThang.SoChiQuyetToanUSD = dChiQTUSDTrongThang;
                //objTUChuaQTTrongThang.SoChiQuyetToanVND = dChiQTVNDTrongThang;

                //objTUChuaQTTrongThang.SoThuChenhLechUSD = dHoanUngUSDTrongThang;
                //objTUChuaQTTrongThang.SoThuChenhLechVND = dHoanUngVNDTrongThang;

                //objTUChuaQTTrongThang.SoBuTruTsUSD = 0;
                //objTUChuaQTTrongThang.SoBuTruTsVND = 0;
                //objTUChuaQTTrongThang.SoChuaThuTsUSD = dSoTamUngUSDTrongThang+ dSoTamUngUSDThangTruoc - dSoQuyetToanUSDTrongThang - dSoQuyetToanUSDThangTruoc;
                //objTUChuaQTTrongThang.SoChuaThuTsVND = dSoTamUngVNSTrongThang + dSoTamUngVNSThangTruoc - dSoQuyetToanVNDTrongThang - dSoQuyetToanVNDThangTruoc;
                //objTUChuaQTTrongThang.SoBuTruHtUSD = 0;
                //objTUChuaQTTrongThang.SoBuTruHtVND = 0;

                //objTUChuaQTTrongThang.GroupByTime = 2;
                //objTUChuaQTTrongThang.NoiDung = "Chưa QT tháng này";
                //objTUChuaQTTrongThang.LoaiDoanRaId = objLoaiDoanRa.Id;
                //objTUChuaQTTrongThang.TenLoaiDoanRa = objLoaiDoanRa.TenLoaiDoanRa;

                //lst05.Add(objTUChuaQTTrongThang);


            }
            return lst05;
        }
        //public List<RP_BC05DR> GetLstChiE(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId)
        //{
        //    List<RP_BC05DR> lst05 = new List<RP_BC05DR>();
        //    RP_BC05DR obj05;
        //    List<VnsGiaoDich> lstGiaoDichQt = new List<VnsGiaoDich>();
        //    lstGiaoDichQt.AddRange(ReportDao.GetLstGiaoDichGroupByLoaiDr(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, 1, 2));
        //    lstGiaoDichQt.AddRange(ReportDao.GetLstGiaoDichGroupByLoaiDr(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, 2, 2));

        //    foreach (VnsGiaoDich obj in lstGiaoDichQt)
        //    {
        //        obj05 = new RP_BC05DR();
        //        obj05.SoChiQuyetToanUSD = obj.SoTienNt;
        //        obj05.SoChiQuyetToanVND = obj.SoTien;
        //        obj05.NoiDung = "Chưa QT tháng này";
        //        obj05.GroupByTime = 2;
        //        obj05.LoaiDoanRaId = (obj.LoaiDoanRaCoId == new Guid() ? obj.LoaiDoanRaNoId : obj.LoaiDoanRaCoId);
        //        lst05.Add(obj05);
        //    }

        //    return lst05;
        //}
        
    }
}
