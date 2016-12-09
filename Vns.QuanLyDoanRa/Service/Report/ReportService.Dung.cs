using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Service;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Dao;
using Vns.QuanLyDoanRa.Dao.Interface.Report;
using System.ComponentModel;
using System.Data;

namespace Vns.QuanLyDoanRa.Service.Report
{
    public partial class ReportService : GenericService<VnsReport, Guid>, IReportService
    {
        public IList<VnsReport> BaoCaoTongHopDoanRa(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId, Guid p_DoanRaId)
        {
            DateTime MinValueDate = Null.NullDate;
            VnsReport objReport;
            Guid GuidEmpty = new Guid();

            IList<VnsReport> lstReport = new List<VnsReport>();
            IList<VnsGiaoDich> lstTamUng = new List<VnsGiaoDich>();
            IList<VnsGiaoDich> lstQuyetToan = new List<VnsGiaoDich>();
            IList<VnsGiaoDich> lstDaThuThangTruoc = new List<VnsGiaoDich>();
            IList<VnsGiaoDich> lstDaThuThangNay = new List<VnsGiaoDich>();
            IList<VnsGiaoDich> lstDaTraThangTruoc = new List<VnsGiaoDich>();
            IList<VnsGiaoDich> lstDaTraThangNay = new List<VnsGiaoDich>();
            IList<VnsDoanCongTac> lstDoanCongTac = new List<VnsDoanCongTac>();
            VnsDoanCongTac objDoanCongTactemp = VnsDoanCongTacDao.GetByKey("Id", p_DoanRaId);
            if (objDoanCongTactemp != null)
                lstDoanCongTac.Add(objDoanCongTactemp);

            // IList<VnsDoanCongTac> lstDoanCongTacTemp = VnsDoanCongTacDao.GetByNgayQT(2, DateTime.MinValue, p_DenNgay, p_LoaiDoanRaId);
            //IList<RP_Doan_CongNo> LstDoanRaTheoCongNo = ReportDao.GetLstDoanRaTheoCongNo(MinValueDate, p_DenNgay, p_LoaiDoanRaId, p_LoaiDoanRaId,p_DoanRaId,p_DoanRaId, Globals.TkTamUng, Globals.TkTamUng, 2);

            //foreach (VnsDoanCongTac objDoanCongTac in lstDoanCongTacTemp)
            //{
            //    foreach (RP_Doan_CongNo objCongNo in LstDoanRaTheoCongNo)
            //    {
            //        if (objCongNo.DoanRaCoId == objDoanCongTac.Id)
            //        {
            //            lstDoanCongTac.Add(objDoanCongTac);
            //            break;
            //        }
            //    }
            //}

            //Khong hien thi
            //đoàn chưa qt
            //đoàn đã qt rồi nhưng qt không phải trong tháng đấy 
            //công nợ =0

            lstTamUng = ReportDao.GetLstGiaoDich(MinValueDate, p_DenNgay, p_LoaiDoanRaId, GuidEmpty, p_DoanRaId, p_DoanRaId, Globals.TkTamUng, Globals.TkTienLike, 0, 2);
            lstQuyetToan = ReportDao.GetLstGiaoDich(MinValueDate, p_DenNgay, p_LoaiDoanRaId, GuidEmpty, p_DoanRaId, p_DoanRaId, Globals.LikeTkQt, Globals.TkTamUng, -1, 2);

            // thang truoc trang thai =1, thang nay trang thai =2, chi xet doan ra da quyet toan
            lstDaThuThangTruoc = ReportDao.GetLstGiaoDich(MinValueDate, p_DenNgay, GuidEmpty, p_LoaiDoanRaId, p_DoanRaId, p_DoanRaId, Globals.TkTienLike, Globals.TkTamUng, 1, 2);
            lstDaThuThangNay = ReportDao.GetLstGiaoDich(MinValueDate, p_DenNgay, GuidEmpty, p_LoaiDoanRaId, p_DoanRaId, p_DoanRaId, Globals.TkTienLike, Globals.TkTamUng, 2, 2);
            lstDaTraThangTruoc = ReportDao.GetLstGiaoDich(MinValueDate, p_DenNgay, p_LoaiDoanRaId, GuidEmpty, p_DoanRaId, p_DoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, 1, 2);
            lstDaTraThangNay = ReportDao.GetLstGiaoDich(MinValueDate, p_DenNgay, p_LoaiDoanRaId, GuidEmpty, p_DoanRaId, p_DoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, 2, 2);

            //Get doan cong tac
            foreach (VnsDoanCongTac objDoanCongTac in lstDoanCongTac)
            {
                objReport = new VnsReport(objDoanCongTac, p_TuNgay, p_DenNgay);

                foreach (VnsGiaoDich objTamUng in lstTamUng)
                {
                    if (objTamUng.DoanRaCoId == objDoanCongTac.Id)
                    {
                        if (objTamUng.NgoaiTeId == Globals.NgoaiTeId)
                        {
                            if (objTamUng.MaTkCo == Globals.TkTienMat)
                            {
                                objReport.TU_TM_VND += objTamUng.SoTien;
                                objReport.TU_TM_USD += objTamUng.SoTienNt;
                            }
                            else if (objTamUng.MaTkCo == Globals.TkTienChuyenKhoan)
                            {
                                objReport.TU_CK_VND += objTamUng.SoTien;
                                objReport.TU_CK_USD += objTamUng.SoTienNt;
                            }
                        }
                        else if (objTamUng.NgoaiTeId == Globals.NoiTeId)
                        {
                            if (objTamUng.MaTkCo == Globals.TkTienMatVND)
                            {
                                objReport.TU_VND_TM += objTamUng.SoTien;
                            }
                            else if (objTamUng.MaTkCo == Globals.TkTienChuyenKhoanVND)
                            {
                                objReport.TU_VND_CK += objTamUng.SoTien;
                            }
                        }
                    }
                }

                //So tien quyet toan
                //foreach (VnsGiaoDich objQuyetToan in lstQuyetToan)
                //{
                //    if (objQuyetToan.DoanRaCoId == objDoanCongTac.Id)
                //    {
                //        if (objQuyetToan.MaTkNo.Equals(Globals.TkThanhToanTienMat))
                //        {
                //            objReport.QT_TM_VND += objQuyetToan.SoTien;
                //            objReport.QT_TM_USD += objQuyetToan.SoTienNt;
                //        }
                //        else
                //        {
                //            objReport.QT_CK_VND += objQuyetToan.SoTien;
                //            objReport.QT_CK_USD += objQuyetToan.SoTienNt;
                //        }
                //    }
                //}

                //So tien da thu thang truóc
                //foreach (VnsGiaoDich objDathuTT in lstDaThuThangTruoc)
                //{
                //    if (objDathuTT.DoanRaCoId == objDoanCongTac.Id)
                //    {
                //        objReport.TH_USD += objDathuTT.SoTienNt;
                //        objReport.TH_VND += objDathuTT.SoTien;
                //    }
                //}

                //So tien da thu thang nay
                //foreach (VnsGiaoDich objDathuTN in lstDaThuThangNay)
                //{
                //    if (objDathuTN.DoanRaCoId == objDoanCongTac.Id)
                //    {
                //        objReport.TH_USD += objDathuTN.SoTienNt;
                //        objReport.TH_VND += objDathuTN.SoTien;

                //        if (objDathuTN.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan))
                //        {
                //            objReport.HU_TrongThang_CK_USD += objDathuTN.SoTienNt;
                //            objReport.HU_TrongThang_CK_VND += objDathuTN.SoTien;
                //        }
                //        else
                //        {
                //            objReport.HU_TrongThang_TM_USD += objDathuTN.SoTienNt;
                //            objReport.HU_TrongThang_TM_VND += objDathuTN.SoTien;
                //        }
                //    }
                //}

                //So tien chi quyet toan thang truoc
                //foreach (VnsGiaoDich objDaTraTT in lstDaTraThangTruoc)
                //{
                //    if (objDaTraTT.DoanRaCoId == objDoanCongTac.Id)
                //    {
                //        if (objDaTraTT.MaTkCo.Equals(Globals.TkTienMat))
                //        {
                //            objReport.QT_DT_TM_VND += objDaTraTT.SoTien;
                //            objReport.QT_DT_TM_USD += objDaTraTT.SoTienNt;
                //        }
                //        else
                //        {
                //            objReport.QT_DT_CK_VND += objDaTraTT.SoTien;
                //            objReport.QT_DT_CK_USD += objDaTraTT.SoTienNt;
                //        }
                //    }
                //}

                //So tien Chi quyet toan thang nay
                //foreach (VnsGiaoDich objDaTraTN in lstDaTraThangNay)
                //{
                //    if (objDaTraTN.DoanRaCoId == objDoanCongTac.Id)
                //    {
                //        if (objDaTraTN.MaTkCo.Equals(Globals.TkTienMat))
                //        {
                //            objReport.QT_DT_TM_VND += objDaTraTN.SoTien;
                //            objReport.QT_DT_TM_USD += objDaTraTN.SoTienNt;
                //        }
                //        else
                //        {
                //            objReport.QT_DT_CK_VND += objDaTraTN.SoTien;
                //            objReport.QT_DT_CK_USD += objDaTraTN.SoTienNt;
                //        }
                //    }
                //}

                lstReport.Add(objReport);
            }


            return lstReport;
        }
    }
}
