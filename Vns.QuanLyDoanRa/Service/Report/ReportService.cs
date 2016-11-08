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
        public IVnsLichCongTacDao VnsLichCongTacDao;
        public IVnsDoanCongTacDao VnsDoanCongTacDao;
        public IVnsGiaoDichDao VnsGiaoDichDao;
        public IReportDao ReportDao;
        public IVnsLoaiDoanRaDao VnsLoaiDoanRaDao;
        public IRP_SoDuTaiKhoanDao RP_SoDuTaiKhoanDao;
        public IRP_BC04DRDao RP_BC04DRDao;
        public IRP_BC04DRService RP_BC04DRService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_TuNgay"></param>
        /// <param name="p_DenNgay"></param>
        /// <param name="p_LoaiDoanRaId"></param>
        /// <param name="p_TrangThaiDct">-1: Tat ca. 1. Chua quyet toan, 2.Da quyet toan</param>
        /// <param name="TYPE">Luon lay mac dinh ReportType.RP02</param>
        /// <returns></returns>
        public IList<VnsReportTongHop> BaoCaoTongHopDoanRa(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId, decimal p_TrangThaiDct, ReportType TYPE)
        {
            DateTime MinValueDate = p_TuNgay;
            VnsReportTongHop objReport;
            Guid GuidEmpty = new Guid();

            IList<VnsReportTongHop> lstReport = new List<VnsReportTongHop>();
            IList<VnsGiaoDich> lstTamUng = new List<VnsGiaoDich>();
            IList<VnsGiaoDich> lstTamUng_trongky = new List<VnsGiaoDich>();

            IList<VnsGiaoDich> lstQuyetToan = new List<VnsGiaoDich>();
            IList<VnsGiaoDich> lstQuyetToan_trongky = new List<VnsGiaoDich>();

            IList<VnsGiaoDich> lstDaThuThangTruoc = new List<VnsGiaoDich>();
            IList<VnsGiaoDich> lstDaThuThangNay = new List<VnsGiaoDich>();
            IList<VnsGiaoDich> lstDaTraThangTruoc = new List<VnsGiaoDich>();
            IList<VnsGiaoDich> lstDaTraThangNay = new List<VnsGiaoDich>();
            IList<VnsDoanCongTac> lstDoanCongTac = new List<VnsDoanCongTac>();
            IList<VnsGiaoDich> lstThuKhiChuaQuyetToan = new List<VnsGiaoDich>();
            IList<VnsGiaoDich> lstQuyetToan_661_331 = new List<VnsGiaoDich>();

            IList<VnsDoanCongTac> lstDoanCongTacTemp = VnsDoanCongTacDao.GetByNgayQT(p_TrangThaiDct, Null.NullDate, p_DenNgay, p_LoaiDoanRaId);
            IList<VnsDoanCongTac> lstDoanCongTacQtBsTemp = new List<VnsDoanCongTac>();// VnsDoanCongTacDao.GetByNgayQTBoSung(p_TrangThaiDct, Null.NullDate, p_DenNgay, p_LoaiDoanRaId);



            //if (lstDoanCongTacQtBsTemp == null || lstDoanCongTacQtBsTemp.Count =0)

            foreach (VnsDoanCongTac tmpbs in lstDoanCongTacQtBsTemp)
            {
                Boolean flg = false;
                foreach (VnsDoanCongTac tmp in lstDoanCongTacTemp)
                {
                    if (tmp.Id == tmpbs.Id)
                    {
                        flg = true;
                        break;
                    }
                }
                if (!flg)
                    lstDoanCongTacTemp.Add(tmpbs);
            }

            IList<RP_Doan_CongNo> LstDoanRaTheoCongNo = ReportDao.GetLstDoanRaTheoCongNo(MinValueDate, p_DenNgay, p_LoaiDoanRaId, p_LoaiDoanRaId, GuidEmpty, GuidEmpty, Globals.TkTamUng, Globals.TkTamUng, p_TrangThaiDct);

            foreach (VnsDoanCongTac objDoanCongTac in lstDoanCongTacTemp)
            {
                foreach (RP_Doan_CongNo objCongNo in LstDoanRaTheoCongNo)
                {
                    if (objCongNo.DoanRaCoId == objDoanCongTac.Id)
                    {
                        lstDoanCongTac.Add(objDoanCongTac);

                        if (objDoanCongTac.Id != objDoanCongTac.IdBanDau)
                        {
                            objDoanCongTac.DanhSachLichCongTac = VnsLichCongTacDao.GetByDoanCongTac(objDoanCongTac.IdBanDau);
                        }
                        break;
                    }
                }
            }

            //Khong hien thi
            //đoàn chưa qt
            //đoàn đã qt rồi nhưng qt không phải trong tháng đấy 
            //công nợ =0
            if (TYPE == ReportType.RP02 || TYPE == ReportType.RP04)
            {
                lstTamUng = ReportDao.GetLstGiaoDich(Null.NullDate, p_DenNgay, p_LoaiDoanRaId, GuidEmpty, GuidEmpty, GuidEmpty, Globals.TkTamUng, Globals.TkTienLike, 0, p_TrangThaiDct);
                lstTamUng_trongky = ReportDao.GetLstGiaoDich(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, GuidEmpty, GuidEmpty, GuidEmpty, Globals.TkTamUng, Globals.TkTienLike, 0, p_TrangThaiDct);
            }
            else
            {
                lstTamUng = ReportDao.GetLstGiaoDich(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, GuidEmpty, GuidEmpty, GuidEmpty, Globals.TkTamUng, Globals.TkTienLike, 0, p_TrangThaiDct);
            }

            lstQuyetToan = ReportDao.GetLstGiaoDich(MinValueDate, p_DenNgay, p_LoaiDoanRaId, GuidEmpty, GuidEmpty, GuidEmpty, Globals.LikeTkQt, Globals.TkTamUng, -1, p_TrangThaiDct);
            lstQuyetToan_trongky = ReportDao.GetLstGiaoDich(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, GuidEmpty, GuidEmpty, GuidEmpty, Globals.LikeTkQt, Globals.TkTamUng, -1, p_TrangThaiDct);

            // thang truoc trang thai =1, thang nay trang thai =2, chi xet doan ra da quyet toan
            lstDaThuThangTruoc = ReportDao.GetLstGiaoDich(MinValueDate, p_DenNgay, GuidEmpty, p_LoaiDoanRaId, GuidEmpty, GuidEmpty, Globals.TkTienLike, Globals.TkTamUng, 1, p_TrangThaiDct);
            lstDaThuThangNay = ReportDao.GetLstGiaoDich(MinValueDate, p_DenNgay, GuidEmpty, p_LoaiDoanRaId, GuidEmpty, GuidEmpty, Globals.TkTienLike, Globals.TkTamUng, 2, 2);
            lstDaTraThangTruoc = ReportDao.GetLstGiaoDich(MinValueDate, p_DenNgay, p_LoaiDoanRaId, GuidEmpty, GuidEmpty, GuidEmpty, Globals.TkTamUng, Globals.LikeTkTienMat, 1, p_TrangThaiDct);
            lstDaTraThangNay = ReportDao.GetLstGiaoDich(MinValueDate, p_DenNgay, p_LoaiDoanRaId, GuidEmpty, GuidEmpty, GuidEmpty, Globals.TkTamUng, Globals.LikeTkTienMat, 2, p_TrangThaiDct);

            /*Lay danh sach quyet toan duoc tao ra khi quyet toan doan
             * Nghiep vu nay phat sinh khi so tien tam ung cho doan co
             * Th1: Doan ra duoc tam ung it hon so quyet toan => So tien bang so tien tam ung
             * Th2: Doan ra duoc tam ung nhieu hon so quyet toan => So tien bang so quyet toan
             */
            lstQuyetToan_661_331 = ReportDao.GetLstGiaoDich(MinValueDate, p_DenNgay, p_LoaiDoanRaId, GuidEmpty, GuidEmpty, GuidEmpty, Globals.TkNghiepVuChiHoatDong, Globals.TkThanhToanNguoiBan, -1, 0);


            lstThuKhiChuaQuyetToan = ReportDao.GetLstGiaoDich(MinValueDate, p_DenNgay, GuidEmpty, p_LoaiDoanRaId, GuidEmpty, GuidEmpty, Globals.TkTienLike, Globals.TkTamUng, 0, p_TrangThaiDct);

            IList<RP_SoDuTaiKhoan> DuNo141 = RP_SoDuTaiKhoanDao.GetSoDuNoTaiKhoan(Null.NullDate, p_DenNgay, "", Globals.TkTamUng);
            IList<RP_SoDuTaiKhoan> DuCo141 = RP_SoDuTaiKhoanDao.GetSoDuCoTaiKhoan(Null.NullDate, p_DenNgay, Globals.TkTamUng, "");

            //Get doan cong tac
            foreach (VnsDoanCongTac objDoanCongTac in lstDoanCongTac)
            {
                Guid id = objDoanCongTac.Id;
                objReport = new VnsReportTongHop(objDoanCongTac, p_TuNgay, p_DenNgay);


                #region Tinh so tam ung
                /*Truong hop ngay quuyet toan trong ky, so tien tam ung se lay gia tri tu truoc den gio cong vao
                  Truong hop ngay quyet toan nho hon khoang thoi gian xem bao cao, so tam ung se lay tong cac nghiep vu tam ung sinh trong ky*/
                if (objDoanCongTac.NgayQuyetToan < p_TuNgay)
                {
                    foreach (VnsGiaoDich objTamUng in lstTamUng_trongky)
                    {
                        if (objTamUng.DoanRaCoId == objDoanCongTac.Id)
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
                            else if (objTamUng.MaTkCo == Globals.TkTienMatVND)
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
                else
                {
                    foreach (VnsGiaoDich objTamUng in lstTamUng)
                    {
                        if (objTamUng.DoanRaCoId == objDoanCongTac.Id)
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
                            else if (objTamUng.MaTkCo == Globals.TkTienMatVND)
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

                //Tam ung trong ky
                foreach (VnsGiaoDich objTamUng in lstTamUng_trongky)
                {
                    if (objTamUng.DoanRaCoId == objDoanCongTac.Id)
                    {
                        if (objTamUng.MaTkCo == Globals.TkTienMat)
                        {
                            objReport.TU_TK_TM_USD += objTamUng.SoTienNt;
                            objReport.TU_TK_TM_VND += objTamUng.SoTien;
                        }
                        else if (objTamUng.MaTkCo == Globals.TkTienChuyenKhoan)
                        {
                            objReport.TU_TK_CK_USD += objTamUng.SoTienNt;
                            objReport.TU_TK_CK_VND += objTamUng.SoTien;
                        }
                        else if (objTamUng.MaTkCo == Globals.TkTienMatVND)
                        {
                            objReport.TU_VND_TK_TM += objTamUng.SoTien;
                        }
                        else if (objTamUng.MaTkCo == Globals.TkTienChuyenKhoanVND)
                        {
                            objReport.TU_VND_TK_CK += objTamUng.SoTien;
                        }
                    }
                }
                #endregion

                #region Tinh so quyet toan
                //So thông báo quyet toan
                if (objDoanCongTac.NgayQuyetToan < p_TuNgay)
                {
                    foreach (VnsGiaoDich objQuyetToan in lstQuyetToan_trongky)
                    {
                        if (objQuyetToan.DoanRaCoId == objDoanCongTac.Id)
                        {
                            if (objQuyetToan.NgoaiTeId == Globals.NgoaiTeId)
                            {
                                if (objQuyetToan.MaTkNo == Globals.TkThanhToanTienMat)
                                {
                                    objReport.QT_TM_VND += objQuyetToan.SoTien;
                                    objReport.QT_TM_USD += objQuyetToan.SoTienNt;
                                }
                                else if (objQuyetToan.MaTkNo == Globals.TkThanhToanChuyenKhoan)
                                {
                                    objReport.QT_CK_VND += objQuyetToan.SoTien;
                                    objReport.QT_CK_USD += objQuyetToan.SoTienNt;
                                }
                            }
                            else if (objQuyetToan.NgoaiTeId == Globals.NoiTeId)
                            {
                                if (objQuyetToan.MaTkNo == Globals.TkThanhToanTienMat)
                                {
                                    objReport.QT_VND_TM += objQuyetToan.SoTien;
                                }
                                else if (objQuyetToan.MaTkNo == Globals.TkThanhToanChuyenKhoan)
                                {
                                    objReport.QT_VND_CK += objQuyetToan.SoTien;
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (VnsGiaoDich objQuyetToan in lstQuyetToan)
                    {
                        if (objQuyetToan.DoanRaCoId == objDoanCongTac.Id)
                        {
                            if (objQuyetToan.NgoaiTeId == Globals.NgoaiTeId)
                            {
                                if (objQuyetToan.MaTkNo == Globals.TkThanhToanTienMat)
                                {
                                    objReport.QT_TM_VND += objQuyetToan.SoTien;
                                    objReport.QT_TM_USD += objQuyetToan.SoTienNt;
                                }
                                else if (objQuyetToan.MaTkNo == Globals.TkThanhToanChuyenKhoan)
                                {
                                    objReport.QT_CK_VND += objQuyetToan.SoTien;
                                    objReport.QT_CK_USD += objQuyetToan.SoTienNt;
                                }
                            }
                            else if (objQuyetToan.NgoaiTeId == Globals.NoiTeId)
                            {
                                if (objQuyetToan.MaTkNo == Globals.TkThanhToanTienMat)
                                {
                                    objReport.QT_VND_TM += objQuyetToan.SoTien;
                                }
                                else if (objQuyetToan.MaTkNo == Globals.TkThanhToanChuyenKhoan)
                                {
                                    objReport.QT_VND_CK += objQuyetToan.SoTien;
                                }
                            }
                        }
                    }
                }
                #endregion

                #region Tinh so thu hoan tam ung
                //So tien da thu thang truóc
                foreach (VnsGiaoDich objDathuTT in lstDaThuThangTruoc)
                {
                    if (objDathuTT.DoanRaCoId == objDoanCongTac.Id)
                    {
                        if (objDathuTT.NgoaiTeId == Globals.NgoaiTeId)
                        {
                            if (objDathuTT.MaTkNo == Globals.TkThanhToanChuyenKhoan)
                            {
                                objReport.TH_CK_USD += objDathuTT.SoTienNt;
                                objReport.TH_CK_VND += objDathuTT.SoTien;
                            }
                            else if (objDathuTT.MaTkNo == Globals.TkThanhToanTienMat)
                            {
                                objReport.TH_TM_USD += objDathuTT.SoTienNt;
                                objReport.TH_TM_VND += objDathuTT.SoTien;
                            }
                        }
                        else if (objDathuTT.NgoaiTeId == Globals.NoiTeId)
                        {
                            if (objDathuTT.MaTkNo == Globals.TkThanhToanChuyenKhoan)
                            {
                                objReport.TH_VND_CK += objDathuTT.SoTien;
                            }
                            else if (objDathuTT.MaTkNo == Globals.TkThanhToanTienMat)
                            {
                                objReport.TH_VND_TM += objDathuTT.SoTien;
                            }
                        }
                    }
                }

                //So tien da thu thang nay
                foreach (VnsGiaoDich objDathuTN in lstDaThuThangNay)
                {
                    if (objDathuTN.DoanRaCoId == objDoanCongTac.Id)
                    {
                        if (objDathuTN.NgoaiTeId == Globals.NgoaiTeId)
                        {
                            if (objDathuTN.MaTkNo == Globals.TkTienChuyenKhoan)
                            {
                                objReport.TH_CK_USD += objDathuTN.SoTienNt;
                                objReport.TH_CK_VND += objDathuTN.SoTien;
                                objReport.HU_TRONGTHANG_CK_USD += objDathuTN.SoTienNt;
                                objReport.HU_TRONGTHANG_CK_VND += objDathuTN.SoTien;
                            }
                            else if (objDathuTN.MaTkNo == Globals.TkTienMat)
                            {
                                objReport.TH_TM_USD += objDathuTN.SoTienNt;
                                objReport.TH_TM_VND += objDathuTN.SoTien;
                                objReport.HU_TRONGTHANG_TM_USD += objDathuTN.SoTienNt;
                                objReport.HU_TRONGTHANG_TM_VND += objDathuTN.SoTien;
                            }
                        }
                        else if (objDathuTN.NgoaiTeId == Globals.NoiTeId)
                        {
                            if (objDathuTN.MaTkNo == Globals.TkTienChuyenKhoan)
                            {
                                objReport.TH_VND_CK += objDathuTN.SoTien;
                                objReport.HU_VND_TRONGTHANG_CK += objDathuTN.SoTien;
                            }
                            else if (objDathuTN.MaTkNo == Globals.TkTienMat)
                            {
                                objReport.TH_VND_TM += objDathuTN.SoTien;
                                objReport.HU_VND_TRONGTHANG_TM += objDathuTN.SoTien;
                            }
                        }
                    }
                }
                #endregion

                #region Tinh so tien thu chua quyet toan
                //So tien thu chua quyet toan
                foreach (VnsGiaoDich objThuChuaQt in lstThuKhiChuaQuyetToan)
                {
                    if (objThuChuaQt.DoanRaCoId == objDoanCongTac.Id)
                    {
                        if (objThuChuaQt.NgoaiTeId == Globals.NgoaiTeId)
                        {
                            if (objThuChuaQt.MaTkNo == Globals.TkTienChuyenKhoan)
                            {
                                objReport.TH_CK_USD += objThuChuaQt.SoTienNt;
                                objReport.TH_CK_VND += objThuChuaQt.SoTien;

                                objReport.TH_CHUA_QT_CK_USD += objThuChuaQt.SoTienNt;
                                objReport.TH_CHUA_QT_CK_VND += objThuChuaQt.SoTien;
                            }
                            else if (objThuChuaQt.MaTkNo == Globals.TkTienMat)
                            {
                                objReport.TH_TM_USD += objThuChuaQt.SoTienNt;
                                objReport.TH_TM_VND += objThuChuaQt.SoTien;

                                objReport.TH_CHUA_QT_TM_USD += objThuChuaQt.SoTienNt;
                                objReport.TH_CHUA_QT_TM_VND += objThuChuaQt.SoTien;
                            }
                        }
                        else if (objThuChuaQt.NgoaiTeId == Globals.NoiTeId)
                        {
                            if (objThuChuaQt.MaTkNo == Globals.TkTienChuyenKhoanVND)
                            {
                                objReport.TH_VND_CK += objThuChuaQt.SoTien;

                                objReport.TH_VND_CHUA_QT_CK += objThuChuaQt.SoTien;
                            }
                            else if (objThuChuaQt.MaTkNo == Globals.TkTienMatVND)
                            {
                                objReport.TH_VND_TM += objThuChuaQt.SoTien;

                                objReport.TH_VND_CHUA_QT_TM += objThuChuaQt.SoTien;
                            }
                        }
                    }
                }
                #endregion

                #region Tinh so tien chi quyet toan
                //So tien chi quyet toan thang truoc
                foreach (VnsGiaoDich objDaTraTT in lstDaTraThangTruoc)
                {
                    if (objDaTraTT.DoanRaCoId == objDoanCongTac.Id)
                    {
                        if (objDaTraTT.NgoaiTeId == Globals.NgoaiTeId)
                        {
                            if (objDaTraTT.MaTkCo == Globals.TkTienMat)
                            {
                                objReport.Chi_QT_TM_VND += objDaTraTT.SoTien;
                                objReport.Chi_QT_TM_USD += objDaTraTT.SoTienNt;
                            }
                            else if (objDaTraTT.MaTkCo == Globals.TkTienChuyenKhoan)
                            {
                                objReport.Chi_QT_CK_VND += objDaTraTT.SoTien;
                                objReport.Chi_QT_CK_USD += objDaTraTT.SoTienNt;
                            }
                        }
                        else if (objDaTraTT.NgoaiTeId == Globals.NoiTeId)
                        {
                            if (objDaTraTT.MaTkCo == Globals.TkTienMatVND)
                            {
                                objReport.Chi_VND_QT_TM += objDaTraTT.SoTien;
                            }
                            else if (objDaTraTT.MaTkCo == Globals.TkTienChuyenKhoanVND)
                            {
                                objReport.Chi_VND_QT_CK += objDaTraTT.SoTien;
                            }
                        }
                    }
                }

                //So tien Chi quyet toan thang nay
                foreach (VnsGiaoDich objDaTraTN in lstDaTraThangNay)
                {
                    if (objDaTraTN.DoanRaCoId == objDoanCongTac.Id)
                    {
                        if (objDaTraTN.NgoaiTeId == Globals.NgoaiTeId)
                        {
                            if (objDaTraTN.MaTkCo == Globals.TkTienMat)
                            {
                                objReport.Chi_QT_TM_VND += objDaTraTN.SoTien;
                                objReport.Chi_QT_TM_USD += objDaTraTN.SoTienNt;
                            }
                            else if (objDaTraTN.MaTkCo == Globals.TkTienChuyenKhoan)
                            {
                                objReport.Chi_QT_CK_VND += objDaTraTN.SoTien;
                                objReport.Chi_QT_CK_USD += objDaTraTN.SoTienNt;
                            }
                        }
                        else if (objDaTraTN.NgoaiTeId == Globals.NoiTeId)
                        {
                            if (objDaTraTN.MaTkCo == Globals.TkTienMatVND)
                            {
                                objReport.Chi_VND_QT_TM += objDaTraTN.SoTien;
                            }
                            else if (objDaTraTN.MaTkCo == Globals.TkTienChuyenKhoanVND)
                            {
                                objReport.Chi_VND_QT_CK += objDaTraTN.SoTien;
                            }
                        }
                    }
                }
                #endregion

                #region Tinh cong no
                foreach (RP_SoDuTaiKhoan objDuNo in DuNo141)
                {
                    if (objReport.DoanRaId == objDuNo.DoanRaId)
                    {
                        if (objDuNo.NgoaiTeId == Globals.NgoaiTeId)
                        {
                            objReport.DuNo141_VND += objDuNo.PsTangVND;
                            objReport.DuNo141_USD += objDuNo.PsTangUSD;
                            if (objDuNo.MaTkCo.StartsWith(Globals.TkTienMat) || objDuNo.MaTkCo.StartsWith(Globals.TkThanhToanTienMat))
                            {
                                objReport.DuNo141_TM_VND += objDuNo.PsTangVND;
                                objReport.DuNo141_TM_USD += objDuNo.PsTangUSD;
                            }
                            if (objDuNo.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan) || objDuNo.MaTkCo.StartsWith(Globals.TkThanhToanChuyenKhoan))
                            {
                                objReport.DuNo141_CK_VND += objDuNo.PsTangVND;
                                objReport.DuNo141_CK_USD += objDuNo.PsTangUSD;
                            }
                        }
                        else if (objDuNo.NgoaiTeId == Globals.NoiTeId)
                        {
                            if (objDuNo.MaTkCo == Globals.TkTienMatVND || objDuNo.MaTkCo == Globals.TkThanhToanTienMat)
                            {
                                objReport.DuNo141_VND_TM += objDuNo.PsTangVND;
                            }
                            if (objDuNo.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan) || objDuNo.MaTkCo.StartsWith(Globals.TkThanhToanChuyenKhoan))
                            {
                                objReport.DuNo141_VND_CK += objDuNo.PsTangVND;
                            }
                        }
                    }
                }

                //Du co tai khoan tam ung 
                foreach (RP_SoDuTaiKhoan objDuCo in DuCo141)
                {
                    if (objReport.DoanRaId == objDuCo.DoanRaId)
                    {
                        if (objDuCo.NgoaiTeId == Globals.NgoaiTeId)
                        {
                            objReport.DuCo141_VND += objDuCo.PsGiamVND;
                            objReport.DuCo141_USD += objDuCo.PsGiamUSD;

                            if (objDuCo.MaTkNo.StartsWith(Globals.TkTienMat) || objDuCo.MaTkNo.StartsWith(Globals.TkThanhToanTienMat))
                            {
                                objReport.DuCo141_TM_VND += objDuCo.PsGiamVND;
                                objReport.DuCo141_TM_USD += objDuCo.PsGiamUSD;
                            }
                            if (objDuCo.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan) || objDuCo.MaTkNo.StartsWith(Globals.TkThanhToanChuyenKhoan))
                            {
                                objReport.DuCo141_CK_VND += objDuCo.PsGiamVND;
                                objReport.DuCo141_CK_USD += objDuCo.PsGiamUSD;
                            }
                        }
                        else if (objDuCo.NgoaiTeId == Globals.NoiTeId)
                        {
                            if (objDuCo.MaTkNo == Globals.TkTienMatVND || objDuCo.MaTkNo == Globals.TkThanhToanTienMat)
                            {
                                objReport.DuCo141_VND_TM += objDuCo.PsGiamVND;
                            }
                            if (objDuCo.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan) || objDuCo.MaTkNo.StartsWith(Globals.TkThanhToanChuyenKhoan))
                            {
                                objReport.DuCo141_VND_CK += objDuCo.PsGiamVND;
                            }
                        }
                    }
                }
                #endregion

                #region Tinh so tien quyet toan 661 - 331
                foreach (VnsGiaoDich objgdqt in lstQuyetToan_661_331)
                {
                    if (objReport.DoanRaId == objgdqt.DoanRaNoId)
                    {
                        if (objgdqt.NgoaiTeId == Globals.NgoaiTeId)
                        {
                            if (objgdqt.MaTkCo == Globals.TkThanhToanTienMat)
                            {
                                objReport.Tk_Qt_Tm_Usd += objgdqt.SoTienNt;
                                objReport.Tk_Qt_Tm_Vnd += objgdqt.SoTien;
                            }
                            else if (objgdqt.MaTkCo == Globals.TkThanhToanChuyenKhoan)
                            {
                                objReport.Tk_Qt_Ck_Usd += objgdqt.SoTienNt;
                                objReport.Tk_Qt_Ck_Vnd += objgdqt.SoTien;
                            }
                        }
                        else if (objgdqt.NgoaiTeId == Globals.NoiTeId)
                        {
                            if (objgdqt.MaTkCo == Globals.TkThanhToanTienMat)
                            {
                                objReport.Tk_VND_Qt_Tm += objgdqt.SoTien;
                            }
                            else if (objgdqt.MaTkCo == Globals.TkThanhToanChuyenKhoan)
                            {
                                objReport.Tk_VND_Qt_CK += objgdqt.SoTien;
                            }
                        }
                    }
                }
                #endregion

                objReport.TYPE = TYPE;

                lstReport.Add(objReport);
            }

            System.Data.DataTable dt = ToDataTable<VnsReportTongHop>(lstReport);

            return lstReport;
        }

        public System.Data.DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            System.Data.DataTable dt = new System.Data.DataTable();
            for (int i = 0; i <= properties.Count - 1; i++)
            {
                PropertyDescriptor property = properties[i];
                try
                {
                    dt.Columns.Add(property.Name, property.PropertyType);
                }
                catch (Exception ex)
                {
                    dt.Columns.Add(property.Name, typeof(DateTime));
                }

            }
            object[] values = new object[properties.Count];
            foreach (T item in data)
            {
                for (int i = 0; i <= values.Length - 1; i++)
                {
                    if (object.ReferenceEquals(properties[i].PropertyType, typeof(DateTime)))
                    {
                        DateTime tmp = (DateTime)properties[i].GetValue(item);
                        values[i] = tmp <= DateTime.MinValue ? null : properties[i].GetValue(item);
                    }
                    else if (object.ReferenceEquals(properties[i].PropertyType, typeof(decimal)))
                    {
                        decimal tmp = (decimal)properties[i].GetValue(item);
                        values[i] = tmp <= Int32.MinValue ? null : properties[i].GetValue(item);
                    }
                    else
                    {
                        values[i] = properties[i].GetValue(item);
                    }
                }
                dt.Rows.Add(values);
            }
            return dt;
        }

        


        public IList<VnsReport> BaoCaoTongHopDoanRaChungTuGhiSo(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId, Guid p_DoanRaId)
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
            // DUng Add
            if (p_DoanRaId == new Guid())
                lstDoanCongTac = VnsDoanCongTacDao.GetByLoaiDoanRa(p_LoaiDoanRaId);
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

            lstTamUng = ReportDao.GetLstGiaoDich(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, GuidEmpty, p_DoanRaId, p_DoanRaId, Globals.TkTamUng, Globals.TkTienLike, 0, 2);
            lstQuyetToan = ReportDao.GetLstGiaoDich(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, GuidEmpty, p_DoanRaId, p_DoanRaId, Globals.LikeTkQt, Globals.TkTamUng, -1, 2);

            // thang truoc trang thai =1, thang nay trang thai =2, chi xet doan ra da quyet toan
            lstDaThuThangTruoc = ReportDao.GetLstGiaoDich(p_TuNgay, p_DenNgay, GuidEmpty, p_LoaiDoanRaId, p_DoanRaId, p_DoanRaId, Globals.TkTienLike, Globals.TkTamUng, 1, 2);
            lstDaThuThangNay = ReportDao.GetLstGiaoDich(p_TuNgay, p_DenNgay, GuidEmpty, p_LoaiDoanRaId, p_DoanRaId, p_DoanRaId, Globals.TkTienLike, Globals.TkTamUng, 2, 2);
            lstDaTraThangTruoc = ReportDao.GetLstGiaoDich(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, GuidEmpty, p_DoanRaId, p_DoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, 1, 2);
            lstDaTraThangNay = ReportDao.GetLstGiaoDich(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, GuidEmpty, p_DoanRaId, p_DoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, 2, 2);

            //Get doan cong tac
            foreach (VnsDoanCongTac objDoanCongTac in lstDoanCongTac)
            {
                objReport = new VnsReport(objDoanCongTac, p_TuNgay, p_DenNgay);

                foreach (VnsGiaoDich objTamUng in lstTamUng)
                {
                    if (objTamUng.DoanRaCoId == objDoanCongTac.Id)
                    {
                        if (objTamUng.MaTkCo.Equals(Globals.TkTienMat))
                        {
                            objReport.TU_TM_VND += objTamUng.SoTien;
                            objReport.TU_TM_USD += objTamUng.SoTienNt;
                        }
                        else
                        {
                            objReport.TU_CK_VND += objTamUng.SoTien;
                            objReport.TU_CK_USD += objTamUng.SoTienNt;
                        }
                    }
                }

                //So tien quyet toan
                foreach (VnsGiaoDich objQuyetToan in lstQuyetToan)
                {
                    if (objQuyetToan.DoanRaCoId == objDoanCongTac.Id)
                    {
                        if (objQuyetToan.MaTkNo.Equals(Globals.TkThanhToanTienMat))
                        {
                            objReport.QT_TM_VND += objQuyetToan.SoTien;
                            objReport.QT_TM_USD += objQuyetToan.SoTienNt;
                        }
                        else
                        {
                            objReport.QT_CK_VND += objQuyetToan.SoTien;
                            objReport.QT_CK_USD += objQuyetToan.SoTienNt;
                        }
                    }
                }

                //So tien da thu thang truóc
                foreach (VnsGiaoDich objDathuTT in lstDaThuThangTruoc)
                {
                    if (objDathuTT.DoanRaCoId == objDoanCongTac.Id)
                    {
                        objReport.TH_USD += objDathuTT.SoTienNt;
                        objReport.TH_VND += objDathuTT.SoTien;
                    }
                }

                //So tien da thu thang nay
                foreach (VnsGiaoDich objDathuTN in lstDaThuThangNay)
                {
                    if (objDathuTN.DoanRaCoId == objDoanCongTac.Id)
                    {
                        objReport.TH_USD += objDathuTN.SoTienNt;
                        objReport.TH_VND += objDathuTN.SoTien;

                        if (objDathuTN.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan))
                        {
                            objReport.HU_TrongThang_CK_USD += objDathuTN.SoTienNt;
                            objReport.HU_TrongThang_CK_VND += objDathuTN.SoTien;
                        }
                        else
                        {
                            objReport.HU_TrongThang_TM_USD += objDathuTN.SoTienNt;
                            objReport.HU_TrongThang_TM_VND += objDathuTN.SoTien;
                        }
                    }
                }

                //So tien chi quyet toan thang truoc
                foreach (VnsGiaoDich objDaTraTT in lstDaTraThangTruoc)
                {
                    if (objDaTraTT.DoanRaCoId == objDoanCongTac.Id)
                    {
                        if (objDaTraTT.MaTkCo.Equals(Globals.TkTienMat))
                        {
                            objReport.QT_DT_TM_VND += objDaTraTT.SoTien;
                            objReport.QT_DT_TM_USD += objDaTraTT.SoTienNt;
                        }
                        else
                        {
                            objReport.QT_DT_CK_VND += objDaTraTT.SoTien;
                            objReport.QT_DT_CK_USD += objDaTraTT.SoTienNt;
                        }
                    }
                }

                //So tien Chi quyet toan thang nay
                foreach (VnsGiaoDich objDaTraTN in lstDaTraThangNay)
                {
                    if (objDaTraTN.DoanRaCoId == objDoanCongTac.Id)
                    {
                        if (objDaTraTN.MaTkCo.Equals(Globals.TkTienMat))
                        {
                            objReport.QT_DT_TM_VND += objDaTraTN.SoTien;
                            objReport.QT_DT_TM_USD += objDaTraTN.SoTienNt;
                        }
                        else
                        {
                            objReport.QT_DT_CK_VND += objDaTraTN.SoTien;
                            objReport.QT_DT_CK_USD += objDaTraTN.SoTienNt;
                        }
                    }
                }

                //CongNoPhaiThu = objReport.TamUngTienMat + objReport.TamUngChuyenKhoan - objReport.QuyetToan - objReport.ThuThangTruoc - objReport.ThuThangTruoc;
                //CongNoPhaiTra = objReport.QuyetToan - objReport.TamUngTienMat - objReport.TamUngChuyenKhoan  - objReport.TraThangNay - objReport.TraThangTruoc;

                lstReport.Add(objReport);
            }


            return lstReport;
        }

        public IList<VnsReportChuaQt> GetSoTienChuaQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay, Guid LoaiDoanRa, string p_TkNo, string p_TkCo, bool isThangTruoc)
        {
            return GetSoTienChuaQuyetToan(DateTime.MaxValue, p_TuNgay, p_DenNgay, LoaiDoanRa, p_TkNo, p_TkCo, isThangTruoc);
        }

        public IList<VnsReportChuaQt> GetSoTienChuaQuyetToan(DateTime NgayBaoCao, DateTime p_TuNgay, DateTime p_DenNgay, Guid LoaiDoanRa, string p_TkNo, string p_TkCo, bool isThangTruoc)
        {
            IList<VnsDoanCongTac> lstDoanRa = VnsDoanCongTacDao.GetAll();
            IList<VnsReportChuaQt> lstChuaQt = new List<VnsReportChuaQt>();
            IList<VnsGiaoDich> lstTamUng = new List<VnsGiaoDich>();
            VnsReportChuaQt objReport;
            lstTamUng = ReportDao.GetSoTienTUChuaQuyetToan(p_TuNgay, p_DenNgay, LoaiDoanRa, p_TkNo, p_TkCo, -1, isThangTruoc);

            //Loai bo cac doan ra da quyet toan toi thoi dien den ngay di
            if (NgayBaoCao != DateTime.MaxValue)
            {
                for (int i = lstDoanRa.Count - 1; i >= 0; i--)
                {
                    if (lstDoanRa[i].NgayQuyetToan < NgayBaoCao || //Ngay quyet toan
                        (!VnsCheck.IsNullGuid(LoaiDoanRa) && lstDoanRa[i].LoaiDoanRaId == LoaiDoanRa)) //Loc theo loai doan ra
                        lstDoanRa.RemoveAt(i);
                }
            }

            foreach (VnsDoanCongTac objDoanRa in lstDoanRa)
            {
                objReport = new VnsReportChuaQt(objDoanRa);

                foreach (VnsGiaoDich objGiaoDich in lstTamUng)
                    if (objGiaoDich.DoanRaCoId == objDoanRa.Id)
                    {
                        if (objGiaoDich.NgoaiTeId == Globals.NgoaiTeId)
                        {
                            if (objGiaoDich.MaTkCo.StartsWith(Globals.TkTienMat) ||
                            objGiaoDich.MaTkNo.StartsWith(Globals.TkTienMat))
                            {
                                objReport.TienMatUSD += objGiaoDich.SoTienNt;
                                objReport.TienMatVND += objGiaoDich.SoTien;
                            }
                            else if (objGiaoDich.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan) ||
                                objGiaoDich.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan))
                            {
                                objReport.ChuyenKhoanUSD += objGiaoDich.SoTienNt;
                                objReport.ChuyenKhoanVND += objGiaoDich.SoTien;
                            }
                        }
                        else if (objGiaoDich.NgoaiTeId == Globals.NoiTeId)
                        {
                            if (objGiaoDich.MaTkCo.StartsWith(Globals.TkTienMatVND) ||
                                                       objGiaoDich.MaTkNo.StartsWith(Globals.TkTienMatVND))
                            {
                                objReport.TienTamUngVND += objGiaoDich.SoTien;
                            }
                            else if (objGiaoDich.MaTkCo.StartsWith(Globals.TkTienChuyenKhoanVND) ||
                                objGiaoDich.MaTkNo.StartsWith(Globals.TkTienChuyenKhoanVND))
                            {
                                objReport.ChuyenKhoanVND += objGiaoDich.SoTien;
                            }
                        }

                        
                    }
                //if (objReport.TienMatUSD != 0 || objReport.TienMatVND != 0
                //    || objReport.ChuyenKhoanUSD != 0 || objReport.ChuyenKhoanVND != 0)
                lstChuaQt.Add(objReport);
            }

            return lstChuaQt;
        }

        #region B04 Detail
        private RP_BC04DR GetSoDuDauKy(IList<RP_BC04DR> lst, Guid DoanId)
        {
            foreach (RP_BC04DR tmp in lst)
            {
                if (tmp.DoanRaId == DoanId)
                    return tmp;
            }
            return new RP_BC04DR();
        }

        private IList<RP_BC04DR> ReportBc04Dr_DauKy_Detail(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaid, Boolean HienThiQtZero)
        {
            IList<RP_BC04DR> lstData = new List<RP_BC04DR>();
            IList<VnsReportTongHop> lstDataTemp = BaoCaoTongHopDoanRa(p_TuNgay, p_DenNgay, p_LoaiDoanRaid, 0, ReportType.RP04);
            List<VnsReportTongHop> lstrp = new List<VnsReportTongHop>(lstDataTemp);
            lstrp.Sort(VnsReportTongHop.CompareDoanRa);

            RP_BC04DR obj04D1 = null;
            RP_BC04DR obj04D2 = null;
            RP_BC04DR obj04D3 = null;
            RP_BC04DR obj04D4 = null;
            RP_BC04DR obj04D5 = null;
            RP_BC04DR obj04D6 = null;
            RP_BC04DR obj04D7 = null;

            Guid id = Null.NullGuid;
            foreach (VnsReportTongHop obj in lstDataTemp)
            {
                if (id != obj.DoanRaId)
                {
                    id = obj.DoanRaId;


                    if (obj04D2 != null)
                    {
                        obj04D2.TongVND = obj04D2.TienMatVND_QD + obj04D2.TienMatVND + obj04D2.ChuyenKhoanVND;
                        obj04D2.MaNoiDung = "2";
                        obj04D2.NoiDung = "Số tiền tạm ứng trong kỳ";

                        obj04D3.TongVND = obj04D3.TienMatVND_QD + obj04D3.TienMatVND + obj04D3.ChuyenKhoanVND;
                        obj04D3.MaNoiDung = "3";
                        obj04D3.NoiDung = "Số tiền quyết toán trong kỳ";

                        obj04D4.TongVND = obj04D4.TienMatVND_QD + obj04D4.TienMatVND + obj04D4.ChuyenKhoanVND;
                        obj04D4.MaNoiDung = "4";
                        obj04D4.NoiDung = "Chi quyết toán trong kỳ";

                        obj04D5.TongVND = obj04D5.TienMatVND_QD + obj04D5.TienMatVND + obj04D5.ChuyenKhoanVND;
                        obj04D5.MaNoiDung = "5";
                        obj04D5.NoiDung = "Thu hoàn tạm ứng trong kỳ";

                        obj04D6.TongVND = obj04D6.TienMatVND_QD + obj04D6.TienMatVND + obj04D6.ChuyenKhoanVND;
                        obj04D6.MaNoiDung = "6";
                        obj04D6.NoiDung = "Phải thu trong kỳ";

                        obj04D7.TienMatVND_QD = obj04D1.TienMatVND_QD + obj04D2.TienMatVND_QD - obj04D3.TienMatVND_QD + obj04D4.TienMatVND_QD - obj04D5.TienMatVND_QD - obj04D6.TienMatVND_QD;
                        obj04D7.TienMatUSD = obj04D1.TienMatUSD + obj04D2.TienMatUSD - obj04D3.TienMatUSD + obj04D4.TienMatUSD - obj04D5.TienMatUSD - obj04D6.TienMatUSD;
                        obj04D7.ChuyenKhoanVND = obj04D1.ChuyenKhoanVND + obj04D2.ChuyenKhoanVND - obj04D3.ChuyenKhoanVND + obj04D4.ChuyenKhoanVND - obj04D5.ChuyenKhoanVND - obj04D6.ChuyenKhoanVND;
                        obj04D7.TienMatVND = obj04D1.TienMatVND + obj04D2.TienMatVND - obj04D3.TienMatVND + obj04D4.TienMatVND - obj04D5.TienMatVND - obj04D6.TienMatVND;

                        obj04D7.TongVND = obj04D7.TienMatVND_QD + obj04D7.TienMatVND + obj04D7.ChuyenKhoanVND;
                        obj04D7.MaNoiDung = "6";
                        obj04D7.NoiDung = "Số tiền chưa quyết toán kỳ trước chuyển sang";

                        if (!HienThiQtZero && obj04D7.TongUSD == 0)
                        { }
                        else
                        {
                            //lstData.Add(obj04D1);
                            lstData.Add(obj04D2);
                            lstData.Add(obj04D3);
                            lstData.Add(obj04D4);
                            lstData.Add(obj04D5);
                            lstData.Add(obj04D6);
                            lstData.Add(obj04D7);
                        }
                    }

                    obj04D1 = new RP_BC04DR();
                    obj04D2 = new RP_BC04DR();
                    obj04D3 = new RP_BC04DR();
                    obj04D4 = new RP_BC04DR();
                    obj04D5 = new RP_BC04DR();
                    obj04D6 = new RP_BC04DR();
                    obj04D7 = new RP_BC04DR();

                    obj04D1.TenDoanRa = String.Format("{0} - DT: {1} - QT:{2}", obj.TenDoanRa, obj.SoTbDt, obj.SoTbQt);
                    obj04D2.TenDoanRa = String.Format("{0} - DT: {1} - QT:{2}", obj.TenDoanRa, obj.SoTbDt, obj.SoTbQt);
                    obj04D3.TenDoanRa = String.Format("{0} - DT: {1} - QT:{2}", obj.TenDoanRa, obj.SoTbDt, obj.SoTbQt);
                    obj04D4.TenDoanRa = String.Format("{0} - DT: {1} - QT:{2}", obj.TenDoanRa, obj.SoTbDt, obj.SoTbQt);
                    obj04D5.TenDoanRa = String.Format("{0} - DT: {1} - QT:{2}", obj.TenDoanRa, obj.SoTbDt, obj.SoTbQt);
                    obj04D6.TenDoanRa = String.Format("{0} - DT: {1} - QT:{2}", obj.TenDoanRa, obj.SoTbDt, obj.SoTbQt);
                    obj04D7.TenDoanRa = String.Format("{0} - DT: {1} - QT:{2}", obj.TenDoanRa, obj.SoTbDt, obj.SoTbQt);

                    //obj04D1.DoanRaId = id;
                    //obj04D2.DoanRaId = id;
                    //obj04D3.DoanRaId = id;
                    //obj04D4.DoanRaId = id;
                    //obj04D5.DoanRaId = id;
                    //obj04D6.DoanRaId = id;
                    obj04D7.DoanRaId = id;

                }
                //DOng 2: tam  ung
                obj04D2.TienMatVND_QD += obj.TU_TK_TM_VND; /*obj.TU_TM_VND_MR;*/
                obj04D2.TienMatUSD += obj.TU_TK_TM_USD; /*obj.TU_TM_USD_MR;*/
                obj04D2.TienMatVND += obj.TU_VND_TK_TM;
                obj04D2.ChuyenKhoanVND += obj.TU_VND_TK_CK; /*obj.TU_CK_VND_MR;*/

                //Dong 3 tien quyet toan
                obj04D3.TienMatVND_QD += obj.So_QT_TM_VND;
                obj04D3.TienMatUSD += obj.So_QT_TM_USD;
                obj04D3.TienMatVND += obj.So_QT_VND_TM;
                obj04D3.ChuyenKhoanVND += obj.So_QT_VND_CK;

                //Dong 4 Chi quyet toan
                obj04D4.TienMatVND_QD += obj.Chi_QT_TM_VND;
                obj04D4.TienMatUSD += obj.Chi_QT_TM_USD;
                obj04D4.ChuyenKhoanVND += obj.Chi_VND_QT_CK;
                obj04D4.TienMatVND += obj.Chi_VND_QT_TM;

                //Dong 5 thu hoan tam ung (= thu hoan trong thang + thu hoan tam ung chua qt trong thang
                obj04D5.TienMatVND_QD += obj.TH_TM_VND;  //obj.HU_TRONGTHANG_TM_VND + obj.TH_CHUA_QT_TM_VND;
                obj04D5.TienMatUSD += obj.TH_TM_USD;  //obj.HU_TRONGTHANG_TM_USD + obj.TH_CHUA_QT_TM_USD;
                obj04D5.ChuyenKhoanVND += obj.TH_VND_CK; //obj.HU_TRONGTHANG_CK_VND + obj.TH_CHUA_QT_CK_VND;
                obj04D5.TienMatVND += obj.TH_VND_TM; //obj.HU_TRONGTHANG_CK_USD + obj.TH_CHUA_QT_CK_USD;

                //Dong 6 : Phai thu trong ky
                obj04D6.TienMatVND_QD += obj.CN_QT_PhaiThu_TM_VND;
                obj04D6.TienMatUSD += obj.CN_QT_PhaiThu_TM_USD;
                obj04D6.TienMatVND += obj.CN_QT_VND_TM_PhaiThu;
                obj04D6.ChuyenKhoanVND += obj.CN_QT_VND_CK_PhaiThu;
            }

            if (obj04D1 != null)
            {
                obj04D1.TongVND = obj04D1.TienMatVND_QD + obj04D1.TienMatVND + obj04D1.ChuyenKhoanVND;
                obj04D1.MaNoiDung = "1";
                obj04D1.NoiDung = "Số tiền chưa quyết toán kỳ trước chuyển sang";

                obj04D2.TongVND = obj04D2.TienMatVND_QD + obj04D2.TienMatVND + obj04D2.ChuyenKhoanVND;
                obj04D2.MaNoiDung = "2";
                obj04D2.NoiDung = "Số tiền tạm ứng trong kỳ";

                obj04D3.TongVND = obj04D3.TienMatVND_QD + obj04D3.TienMatVND + obj04D3.ChuyenKhoanVND;
                obj04D3.MaNoiDung = "3";
                obj04D3.NoiDung = "Số tiền tạm ứng trong kỳ";

                obj04D4.TongVND = obj04D4.TienMatVND_QD + obj04D4.TienMatVND + obj04D4.ChuyenKhoanVND;
                obj04D4.MaNoiDung = "4";
                obj04D4.NoiDung = "Số quyết toán trong kỳ";

                obj04D5.TongVND = obj04D5.TienMatVND_QD + obj04D5.TienMatVND + obj04D5.ChuyenKhoanVND;
                obj04D5.MaNoiDung = "5";
                obj04D5.NoiDung = "Chi quyết toán trong kỳ";

                obj04D6.TongVND = obj04D6.TienMatVND_QD + obj04D6.TienMatVND + obj04D6.ChuyenKhoanVND;
                obj04D6.MaNoiDung = "6";
                obj04D6.NoiDung = "Thu hoàn tạm ứng trong kỳ";

                obj04D7.TienMatVND_QD = obj04D1.TienMatVND_QD + obj04D2.TienMatVND_QD - obj04D3.TienMatVND_QD + obj04D4.TienMatVND_QD - obj04D5.TienMatVND_QD - obj04D6.TienMatVND_QD;
                obj04D7.TienMatUSD = obj04D1.TienMatUSD + obj04D2.TienMatUSD - obj04D3.TienMatUSD + obj04D4.TienMatUSD - obj04D5.TienMatUSD - obj04D6.TienMatUSD;
                obj04D7.ChuyenKhoanVND = obj04D1.ChuyenKhoanVND + obj04D2.ChuyenKhoanVND - obj04D3.ChuyenKhoanVND + obj04D4.ChuyenKhoanVND - obj04D5.ChuyenKhoanVND - obj04D6.ChuyenKhoanVND;
                obj04D7.TienMatVND = obj04D1.TienMatVND + obj04D2.TienMatVND - obj04D3.TienMatVND + obj04D4.TienMatVND - obj04D5.TienMatVND - obj04D6.TienMatVND;

                obj04D7.TongVND = obj04D7.TienMatVND_QD + obj04D7.TienMatVND + obj04D7.ChuyenKhoanVND;
                obj04D7.MaNoiDung = "7";
                obj04D7.NoiDung = "Số tiền chưa quyết toán cuối kỳ";

                lstData.Add(obj04D7);
            }

            return lstData;
        }

        public IList<RP_BC04DR> ReportBc04Dr_Detail(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaid, Boolean HienThiQtZero)
        {
            IList<RP_BC04DR> lstData = new List<RP_BC04DR>();
            //Dau ky
            DateTime datehold = new DateTime(2001, 1, 1);
            IList<RP_BC04DR> lstDataDauKy = new List<RP_BC04DR>();
            if (p_TuNgay > datehold)
                lstDataDauKy = ReportBc04Dr_DauKy_Detail(Null.NullDate, p_TuNgay.AddDays(-1), p_LoaiDoanRaid, HienThiQtZero);

            //Trong ky
            IList<VnsReportTongHop> lstDataTemp = BaoCaoTongHopDoanRa(p_TuNgay, p_DenNgay, p_LoaiDoanRaid, 0, ReportType.RP04);
            List<VnsReportTongHop> lstrp = new List<VnsReportTongHop>(lstDataTemp);

            DataTable dt = ToDataTable<VnsReportTongHop>(lstDataTemp);

            lstrp.Sort(VnsReportTongHop.CompareDoanRa);

            RP_BC04DR obj04D1 = null;
            RP_BC04DR obj04D2 = null;
            RP_BC04DR obj04D3 = null;
            RP_BC04DR obj04D4 = null;
            RP_BC04DR obj04D5 = null;
            RP_BC04DR obj04D6 = null;
            RP_BC04DR obj04D7 = null;

            Guid id = Null.NullGuid;
            foreach (VnsReportTongHop obj in lstDataTemp)
            {
                if (id != obj.DoanRaId)
                {
                    id = obj.DoanRaId;


                    if (obj04D2 != null)
                    {
                        obj04D1.TongVND = obj04D1.TienMatVND_QD + obj04D1.TienMatVND + obj04D1.ChuyenKhoanVND;
                        obj04D1.MaNoiDung = "1";
                        obj04D1.NoiDung = "Số tiền chưa quyết toán kỳ trước chuyển sang";

                        obj04D2.TongVND = obj04D2.TienMatVND_QD + obj04D2.TienMatVND + obj04D2.ChuyenKhoanVND;
                        obj04D2.MaNoiDung = "2";
                        obj04D2.NoiDung = "Số tiền tạm ứng trong kỳ";

                        obj04D3.TongVND = obj04D3.TienMatVND_QD + obj04D3.TienMatVND + obj04D3.ChuyenKhoanVND;
                        obj04D3.MaNoiDung = "3";
                        obj04D3.NoiDung = "Số tiền quyết toán trong kỳ";

                        obj04D4.TongVND = obj04D4.TienMatVND_QD + obj04D4.TienMatVND + obj04D4.ChuyenKhoanVND;
                        obj04D4.MaNoiDung = "4";
                        obj04D4.NoiDung = "Chi quyết toán trong kỳ";

                        obj04D5.TongVND = obj04D5.TienMatVND_QD + obj04D5.TienMatVND + obj04D5.ChuyenKhoanVND;
                        obj04D5.MaNoiDung = "5";
                        obj04D5.NoiDung = "Thu hoàn tạm ứng trong kỳ";

                        obj04D6.TongVND = obj04D6.TienMatVND_QD + obj04D6.TienMatVND + obj04D6.ChuyenKhoanVND;
                        obj04D6.MaNoiDung = "6";
                        obj04D6.NoiDung = "Phải thu trong kỳ";

                        obj04D7.TienMatVND_QD = obj04D1.TienMatVND_QD + obj04D2.TienMatVND_QD - obj04D3.TienMatVND_QD + obj04D4.TienMatVND_QD - obj04D5.TienMatVND_QD - obj04D6.TienMatVND_QD;
                        obj04D7.TienMatUSD = obj04D1.TienMatUSD + obj04D2.TienMatUSD - obj04D3.TienMatUSD + obj04D4.TienMatUSD - obj04D5.TienMatUSD - obj04D6.TienMatUSD;

                        obj04D7.ChuyenKhoanVND = obj04D1.ChuyenKhoanVND + obj04D2.ChuyenKhoanVND - obj04D3.ChuyenKhoanVND + obj04D4.ChuyenKhoanVND - obj04D5.ChuyenKhoanVND - obj04D6.ChuyenKhoanVND;
                        obj04D7.TienMatVND = obj04D1.TienMatVND + obj04D2.TienMatVND - obj04D3.TienMatVND + obj04D4.TienMatVND - obj04D5.TienMatVND - obj04D6.TienMatVND;

                        obj04D7.TongVND = obj04D7.TienMatVND_QD + obj04D7.TienMatVND + obj04D7.ChuyenKhoanVND;
                        obj04D7.MaNoiDung = "7";
                        obj04D7.NoiDung = "Số tiền chưa quyết toán cuối kỳ";

                        if (!HienThiQtZero && obj04D7.TongUSD == 0)
                        { }
                        else
                        {
                            lstData.Add(obj04D1);
                            lstData.Add(obj04D2);
                            lstData.Add(obj04D3);
                            lstData.Add(obj04D4);
                            lstData.Add(obj04D5);
                            lstData.Add(obj04D6);
                            lstData.Add(obj04D7);
                        }
                    }

                    obj04D1 = GetSoDuDauKy(lstDataDauKy, id);
                    obj04D2 = new RP_BC04DR();
                    obj04D3 = new RP_BC04DR();
                    obj04D4 = new RP_BC04DR();
                    obj04D5 = new RP_BC04DR();
                    obj04D6 = new RP_BC04DR();
                    obj04D7 = new RP_BC04DR();

                    obj04D1.TenDoanRa = String.Format("{0} - DT: {1} - QT:{2}", obj.TenDoanRa, obj.SoTbDt, obj.SoTbQt);
                    obj04D2.TenDoanRa = String.Format("{0} - DT: {1} - QT:{2}", obj.TenDoanRa, obj.SoTbDt, obj.SoTbQt);
                    obj04D3.TenDoanRa = String.Format("{0} - DT: {1} - QT:{2}", obj.TenDoanRa, obj.SoTbDt, obj.SoTbQt);
                    obj04D4.TenDoanRa = String.Format("{0} - DT: {1} - QT:{2}", obj.TenDoanRa, obj.SoTbDt, obj.SoTbQt);
                    obj04D5.TenDoanRa = String.Format("{0} - DT: {1} - QT:{2}", obj.TenDoanRa, obj.SoTbDt, obj.SoTbQt);
                    obj04D6.TenDoanRa = String.Format("{0} - DT: {1} - QT:{2}", obj.TenDoanRa, obj.SoTbDt, obj.SoTbQt);
                    obj04D7.TenDoanRa = String.Format("{0} - DT: {1} - QT:{2}", obj.TenDoanRa, obj.SoTbDt, obj.SoTbQt);

                    obj04D1.DoanRaId = id;
                    obj04D2.DoanRaId = id;
                    obj04D3.DoanRaId = id;
                    obj04D4.DoanRaId = id;
                    obj04D5.DoanRaId = id;
                    obj04D6.DoanRaId = id;
                    obj04D7.DoanRaId = id;

                }
                //DOng 2: tam  ung
                obj04D2.TienMatVND_QD += obj.TU_TK_TM_VND; /*obj.TU_TM_VND_MR;*/
                obj04D2.TienMatUSD += obj.TU_TK_TM_USD; /*obj.TU_TM_USD_MR;*/
                obj04D2.TienMatVND += obj.TU_VND_TK_TM;
                obj04D2.ChuyenKhoanVND += obj.TU_VND_TK_CK; /*obj.TU_CK_VND_MR;*/

                //Dong 3 tien quyet toan
                obj04D3.TienMatVND_QD += obj.So_QT_TM_VND;
                obj04D3.TienMatUSD += obj.So_QT_TM_USD;
                obj04D3.TienMatVND += obj.So_QT_VND_TM;
                obj04D3.ChuyenKhoanVND += obj.So_QT_VND_CK;

                //Dong 4 Chi quyet toan
                obj04D4.TienMatVND_QD += obj.Chi_QT_TM_VND;
                obj04D4.TienMatUSD += obj.Chi_QT_TM_USD;
                obj04D4.ChuyenKhoanVND += obj.Chi_VND_QT_CK;
                obj04D4.TienMatVND += obj.Chi_VND_QT_TM;

                //Dong 5 thu hoan tam ung (= thu hoan trong thang + thu hoan tam ung chua qt trong thang
                obj04D5.TienMatVND_QD += obj.TH_TM_VND;  //obj.HU_TRONGTHANG_TM_VND + obj.TH_CHUA_QT_TM_VND;
                obj04D5.TienMatUSD += obj.TH_TM_USD;  //obj.HU_TRONGTHANG_TM_USD + obj.TH_CHUA_QT_TM_USD;
                obj04D5.ChuyenKhoanVND += obj.TH_VND_CK; //obj.HU_TRONGTHANG_CK_VND + obj.TH_CHUA_QT_CK_VND;
                obj04D5.TienMatVND += obj.TH_VND_TM; //obj.HU_TRONGTHANG_CK_USD + obj.TH_CHUA_QT_CK_USD;

                //Dong 6 : Phai thu trong ky
                obj04D6.TienMatVND_QD += obj.CN_QT_PhaiThu_TM_VND;
                obj04D6.TienMatUSD += obj.CN_QT_PhaiThu_TM_USD;
                obj04D6.TienMatVND += obj.CN_QT_VND_TM_PhaiThu;
                obj04D6.ChuyenKhoanVND += obj.CN_QT_VND_CK_PhaiThu;
            }

            if (obj04D1 != null)
            {
                obj04D1.TongVND = obj04D1.TienMatVND_QD + obj04D1.TienMatVND + obj04D1.ChuyenKhoanVND;
                obj04D1.MaNoiDung = "1";
                obj04D1.NoiDung = "Số tiền chưa quyết toán kỳ trước chuyển sang";

                obj04D2.TongVND = obj04D2.TienMatVND_QD + obj04D2.TienMatVND + obj04D2.ChuyenKhoanVND;
                obj04D2.MaNoiDung = "2";
                obj04D2.NoiDung = "Số tiền tạm ứng trong kỳ";

                obj04D3.TongVND = obj04D3.TienMatVND_QD + obj04D3.TienMatVND + obj04D3.ChuyenKhoanVND;
                obj04D3.MaNoiDung = "3";
                obj04D3.NoiDung = "Số tiền tạm ứng trong kỳ";

                obj04D4.TongVND = obj04D4.TienMatVND_QD + obj04D4.TienMatVND + obj04D4.ChuyenKhoanVND;
                obj04D4.MaNoiDung = "4";
                obj04D4.NoiDung = "Số quyết toán trong kỳ";

                obj04D5.TongVND = obj04D5.TienMatVND_QD + obj04D5.TienMatVND + obj04D5.ChuyenKhoanVND;
                obj04D5.MaNoiDung = "5";
                obj04D5.NoiDung = "Chi quyết toán trong kỳ";

                obj04D6.TongVND = obj04D6.TienMatVND_QD + obj04D6.TienMatVND + obj04D6.ChuyenKhoanVND;
                obj04D6.MaNoiDung = "6";
                obj04D6.NoiDung = "Thu hoàn tạm ứng trong kỳ";

                obj04D7.TienMatVND_QD = obj04D1.TienMatVND_QD + obj04D2.TienMatVND_QD - obj04D3.TienMatVND_QD + obj04D4.TienMatVND_QD - obj04D5.TienMatVND_QD - obj04D6.TienMatVND_QD;
                obj04D7.TienMatUSD = obj04D1.TienMatUSD + obj04D2.TienMatUSD - obj04D3.TienMatUSD + obj04D4.TienMatUSD - obj04D5.TienMatUSD - obj04D6.TienMatUSD;
                obj04D7.ChuyenKhoanVND = obj04D1.ChuyenKhoanVND + obj04D2.ChuyenKhoanVND - obj04D3.ChuyenKhoanVND + obj04D4.ChuyenKhoanVND - obj04D5.ChuyenKhoanVND - obj04D6.ChuyenKhoanVND;
                obj04D7.TienMatVND = obj04D1.TienMatVND + obj04D2.TienMatVND - obj04D3.TienMatVND + obj04D4.TienMatVND - obj04D5.TienMatVND - obj04D6.TienMatVND;

                obj04D7.TongVND = obj04D7.TienMatVND_QD + obj04D7.TienMatVND + obj04D7.ChuyenKhoanVND;
                obj04D7.MaNoiDung = "7";
                obj04D7.NoiDung = "Số tiền chưa quyết toán cuối kỳ";

                lstData.Add(obj04D1);
                lstData.Add(obj04D2);
                lstData.Add(obj04D3);
                lstData.Add(obj04D4);
                lstData.Add(obj04D5);
                lstData.Add(obj04D6);
                lstData.Add(obj04D7);
            }

            return lstData;
        }
        #endregion

        #region B04 All
        private RP_BC04DR ReportBc04Dr_DauKy(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaid)
        {
            IList<RP_BC04DR> lstData = new List<RP_BC04DR>();
            IList<VnsReportTongHop> lstDataTemp = BaoCaoTongHopDoanRa(p_TuNgay, p_DenNgay, p_LoaiDoanRaid, 0, ReportType.RP04);
            RP_BC04DR obj04D1 = new RP_BC04DR();
            RP_BC04DR obj04D2 = new RP_BC04DR();
            RP_BC04DR obj04D3 = new RP_BC04DR();
            RP_BC04DR obj04D4 = new RP_BC04DR();
            RP_BC04DR obj04D5 = new RP_BC04DR();
            RP_BC04DR obj04D6 = new RP_BC04DR();
            RP_BC04DR obj04D7 = new RP_BC04DR();

            foreach (VnsReportTongHop obj in lstDataTemp)
            {
                //DOng 2: tam  ung
                obj04D2.TienMatVND_QD += obj.TU_TK_TM_VND; /*obj.TU_TM_VND_MR;*/
                obj04D2.TienMatUSD += obj.TU_TK_TM_USD; /*obj.TU_TM_USD_MR;*/
                obj04D2.TienMatVND += obj.TU_VND_TK_TM;
                obj04D2.ChuyenKhoanVND += obj.TU_VND_TK_CK; /*obj.TU_CK_VND_MR;*/

                //Dong 3 tien quyet toan
                obj04D3.TienMatVND_QD += obj.So_QT_TM_VND;
                obj04D3.TienMatUSD += obj.So_QT_TM_USD;
                obj04D3.TienMatVND += obj.So_QT_VND_TM;
                obj04D3.ChuyenKhoanVND += obj.So_QT_VND_CK;

                //Dong 4 Chi quyet toan
                obj04D4.TienMatVND_QD += obj.Chi_QT_TM_VND;
                obj04D4.TienMatUSD += obj.Chi_QT_TM_USD;
                obj04D4.TienMatVND += obj.Chi_VND_QT_TM;
                obj04D4.ChuyenKhoanUSD += obj.Chi_VND_QT_CK;

                //Dong 5 thu hoan tam ung (= thu hoan trong thang + thu hoan tam ung chua qt trong thang
                obj04D5.TienMatVND_QD += obj.TH_TM_VND; //obj.HU_TRONGTHANG_TM_VND + obj.TH_CHUA_QT_TM_VND;
                obj04D5.TienMatUSD += obj.TH_TM_USD; //obj.HU_TRONGTHANG_TM_USD + obj.TH_CHUA_QT_TM_USD;
                obj04D5.TienMatVND += obj.TH_VND_TM;
                obj04D5.ChuyenKhoanVND += obj.TH_VND_TM; //obj.HU_TRONGTHANG_CK_VND + obj.TH_CHUA_QT_CK_VND;

                //Dong 6 :
                obj04D6.TienMatVND_QD += obj.CN_QT_PhaiThu_TM_VND;
                obj04D6.TienMatUSD += obj.CN_QT_PhaiThu_TM_USD;
                obj04D6.TienMatVND += obj.CN_QT_VND_TM_PhaiThu;
                obj04D6.ChuyenKhoanVND += obj.CN_QT_VND_CK_PhaiThu;
            }

            obj04D2.TongVND = obj04D2.TienMatVND_QD + obj04D2.TienMatVND + obj04D2.ChuyenKhoanVND;
            obj04D2.MaNoiDung = "2";
            obj04D2.NoiDung = "Số tiền tạm ứng trong kỳ";

            obj04D3.TongVND = obj04D3.TienMatVND_QD + obj04D3.TienMatVND + obj04D3.ChuyenKhoanVND;
            obj04D3.MaNoiDung = "3";
            obj04D3.NoiDung = "Số quyết toán trong kỳ";

            obj04D4.TongVND = obj04D4.TienMatVND_QD + obj04D4.TienMatVND + obj04D4.ChuyenKhoanVND;
            obj04D4.MaNoiDung = "4";
            obj04D4.NoiDung = "Chi quyết toán trong kỳ";

            obj04D5.TongVND = obj04D5.TienMatVND_QD + obj04D5.TienMatVND + obj04D5.ChuyenKhoanVND;
            obj04D5.MaNoiDung = "5";
            obj04D5.NoiDung = "Thu hoàn tạm ứng trong kỳ";

            obj04D6.TongVND = obj04D6.TienMatVND_QD + obj04D6.TienMatVND + obj04D6.ChuyenKhoanVND;
            obj04D6.MaNoiDung = "6";
            obj04D6.NoiDung = "Phải thu trong kỳ";

            obj04D7.TienMatVND_QD = obj04D1.TienMatVND_QD + obj04D2.TienMatVND_QD - obj04D3.TienMatVND_QD + obj04D4.TienMatVND_QD - obj04D5.TienMatVND_QD - obj04D6.TienMatVND_QD;
            obj04D7.TienMatUSD = obj04D1.TienMatUSD + obj04D2.TienMatUSD - obj04D3.TienMatUSD + obj04D4.TienMatUSD - obj04D5.TienMatUSD - obj04D6.TienMatUSD;

            obj04D7.ChuyenKhoanVND = obj04D1.ChuyenKhoanVND + obj04D2.ChuyenKhoanVND - obj04D3.ChuyenKhoanVND + obj04D4.ChuyenKhoanVND - obj04D5.ChuyenKhoanVND - obj04D6.ChuyenKhoanVND;
            obj04D7.TienMatVND = obj04D1.TienMatVND + obj04D2.TienMatVND - obj04D3.TienMatVND + obj04D4.TienMatVND - obj04D5.TienMatVND - obj04D6.TienMatVND;

            obj04D7.TongVND = obj04D7.TienMatVND_QD + obj04D7.TienMatVND + obj04D7.ChuyenKhoanVND;
            obj04D7.MaNoiDung = "1";
            obj04D7.NoiDung = "Số tiền chưa quyết toán tháng trước chuyển sang";

            //lstData.Add(obj04D1);
            //lstData.Add(obj04D2);
            //lstData.Add(obj04D3);
            //lstData.Add(obj04D4);
            //lstData.Add(obj04D5);
            //lstData.Add(obj04D6);
            //lstData.Add(obj04D7);

            return obj04D7;
        }

        public IList<RP_BC04DR> ReportBc04Dr(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId, bool isQuy = false)
        {
            IList<RP_BC04DR> lstData = new List<RP_BC04DR>();
            IList<VnsReportTongHop> lstDataTemp = BaoCaoTongHopDoanRa(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, 0, ReportType.RP04);
            RP_BC04DR obj04D1 = ReportBc04Dr_DauKy(Null.NullDate, p_TuNgay.AddDays(-1), p_LoaiDoanRaId);
            if (isQuy)
                obj04D1.NoiDung = "Số tiền chưa quyết toán {0} chuyển sang";
            RP_BC04DR obj04D2 = new RP_BC04DR();
            RP_BC04DR obj04D3 = new RP_BC04DR();
            RP_BC04DR obj04D4 = new RP_BC04DR();
            RP_BC04DR obj04D5 = new RP_BC04DR();
            RP_BC04DR obj04D6 = new RP_BC04DR();
            RP_BC04DR obj04D7 = new RP_BC04DR();
            foreach (VnsReportTongHop obj in lstDataTemp)
            {
                //DOng 2: tam  ung
                obj04D2.TienMatVND_QD += obj.TU_TK_TM_VND; /*obj.TU_TM_VND_MR;*/
                obj04D2.TienMatUSD += obj.TU_TK_TM_USD; /*obj.TU_TM_USD_MR;*/

                obj04D2.TienMatVND += obj.TU_VND_TK_TM;
                obj04D2.ChuyenKhoanVND += obj.TU_VND_TK_CK;

                //Dong 3 tien quyet toan
                obj04D3.TienMatVND_QD += obj.So_QT_TM_VND;
                obj04D3.TienMatUSD += obj.So_QT_TM_USD;

                obj04D3.TienMatVND += obj.So_QT_VND_TM;
                obj04D3.ChuyenKhoanVND += obj.So_QT_VND_CK;

                //Dong 4 Chi quyet toan
                obj04D4.TienMatVND_QD += obj.Chi_QT_TM_VND;
                obj04D4.TienMatUSD += obj.Chi_QT_TM_USD;

                obj04D4.TienMatVND += obj.Chi_VND_QT_TM;
                obj04D4.ChuyenKhoanVND += obj.Chi_VND_QT_CK;

                //Dong 5 thu hoan tam ung (= thu hoan trong thang + thu hoan tam ung chua qt trong thang
                obj04D5.TienMatVND_QD += obj.HU_TRONGTHANG_TM_VND + obj.TH_CHUA_QT_TM_VND;
                obj04D5.TienMatUSD += obj.HU_TRONGTHANG_TM_USD + obj.TH_CHUA_QT_TM_USD;

                obj04D5.TienMatVND += obj.HU_VND_TRONGTHANG_TM + obj.TH_VND_CHUA_QT_TM;
                obj04D5.ChuyenKhoanVND += obj.HU_VND_TRONGTHANG_CK + obj.TH_VND_CHUA_QT_CK;

                //Dong 6 :phai thu thang tiep theo
                obj04D6.TienMatVND_QD += obj.CN_QT_PhaiThu_TM_VND;
                obj04D6.TienMatUSD += obj.CN_QT_PhaiThu_TM_USD;

                obj04D6.TienMatVND += obj.CN_QT_VND_TM_PhaiThu;
                obj04D6.ChuyenKhoanVND += obj.CN_QT_VND_CK_PhaiThu;

            }

            obj04D2.TongVND = obj04D2.TienMatVND_QD + obj04D2.TienMatVND + obj04D2.ChuyenKhoanVND;
            obj04D2.MaNoiDung = "2";
            obj04D2.NoiDung = "Số tiền tạm ứng trong tháng";
            if (isQuy)
                obj04D2.NoiDung = "Số tiền tạm ứng {0}";

            obj04D3.TongVND = obj04D3.TienMatVND_QD + obj04D3.TienMatVND + obj04D3.ChuyenKhoanVND;
            obj04D3.MaNoiDung = "3";
            obj04D3.NoiDung = "Số quyết toán trong tháng";
            if (isQuy)
                obj04D3.NoiDung = "Số tiền quyết toán {0}";
            obj04D4.TongVND = obj04D4.TienMatVND_QD + obj04D4.TienMatVND + obj04D4.ChuyenKhoanVND;
            obj04D4.MaNoiDung = "4";
            obj04D4.NoiDung = "Chi quyết toán trong tháng";
            if (isQuy)
                obj04D4.NoiDung = "Số tiền chi quyết toán {0}";
            obj04D5.TongVND = obj04D5.TienMatVND_QD + obj04D5.TienMatVND + obj04D5.ChuyenKhoanVND;
            obj04D5.MaNoiDung = "5";
            obj04D5.NoiDung = "Thu hoàn tạm ứng trong tháng";
            if (isQuy)
                obj04D5.NoiDung = "Số tiền thu hoàn tạm ứng {0}";

            obj04D6.TongVND = obj04D6.TienMatVND_QD + obj04D6.TienMatVND + obj04D6.ChuyenKhoanVND;
            obj04D6.MaNoiDung = "6";
            obj04D6.NoiDung = "Phải thu trong tháng tiếp theo";
            if (isQuy)
                obj04D6.NoiDung = "Số phải thu chênh lệch tạm ứng quyết toán {0}";

            obj04D7.TienMatVND_QD = obj04D1.TienMatVND_QD + obj04D2.TienMatVND_QD - obj04D3.TienMatVND_QD + obj04D4.TienMatVND_QD - obj04D5.TienMatVND_QD - obj04D6.TienMatVND_QD;
            obj04D7.TienMatUSD = obj04D1.TienMatUSD + obj04D2.TienMatUSD - obj04D3.TienMatUSD + obj04D4.TienMatUSD - obj04D5.TienMatUSD - obj04D6.TienMatUSD;
            obj04D7.TienMatVND = obj04D1.TienMatVND + obj04D2.TienMatVND - obj04D3.TienMatVND + obj04D4.TienMatVND - obj04D5.TienMatVND - obj04D6.TienMatVND;
            obj04D7.ChuyenKhoanVND = obj04D1.ChuyenKhoanVND + obj04D2.ChuyenKhoanVND - obj04D3.ChuyenKhoanVND + obj04D4.ChuyenKhoanVND - obj04D5.ChuyenKhoanVND - obj04D6.ChuyenKhoanVND;

            obj04D7.TongVND = obj04D7.TienMatVND_QD + obj04D7.TienMatVND + obj04D7.ChuyenKhoanVND;
            obj04D7.MaNoiDung = "7";
            obj04D7.NoiDung = "Tổng số tiền chưa quyết toán chuyển sang tháng sau";
            if (isQuy)
                obj04D6.NoiDung = "Tổng số tiền chưa quyết toán chuyển sang {0}";

            lstData.Add(obj04D1);
            lstData.Add(obj04D2);
            lstData.Add(obj04D3);
            lstData.Add(obj04D4);
            lstData.Add(obj04D5);
            lstData.Add(obj04D6);
            lstData.Add(obj04D7);

            return lstData;
        }
        #endregion

        private RP_BC04DR RP_04GetSoTienChuaQtThangTruoc(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId)
        {
            RP_BC04DR obj04D1 = new RP_BC04DR();
            IList<VnsReportChuaQt> lstChuaQt = GetSoTienChuaQuyetToan(Null.NullDate, p_TuNgay.AddDays(-1), p_LoaiDoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, false);
            foreach (VnsReportChuaQt obj in lstChuaQt)
            {
                //DOng 2: tam  ung
                obj04D1.TienMatVND_QD += obj.TienMatVND;
                obj04D1.TienMatUSD += obj.TienMatUSD;

                obj04D1.ChuyenKhoanVND += obj.ChuyenKhoanVND;
                obj04D1.ChuyenKhoanUSD += obj.ChuyenKhoanUSD;
            }

            obj04D1.TongUSD = obj04D1.TienMatUSD + obj04D1.ChuyenKhoanUSD;
            obj04D1.TongVND = obj04D1.TienMatVND_QD + obj04D1.ChuyenKhoanVND;
            obj04D1.NoiDung = "Số tiền chưa quyết toán kỳ trước chuyển sang";

            return obj04D1;
        }

        /*Lay du lieu cua chung tu ghi so*/
        #region Chung tu ghi so
        public IList<RP_ChungTuGhiSo> RPChungTuGhiSo(DateTime p_TuNgay, DateTime p_DenNgay, string str_TKCo, string str_TKNo, string str_TrangThaiCt, int GiaTri, string TimeTile)
        {
            IList<VnsLoaiDoanRa> lstLoaiDoanRa = VnsLoaiDoanRaDao.GetAll();
            IList<VnsDoanCongTac> lstDoanCt = VnsDoanCongTacDao.GetAll();
            IList<RP_ChungTuGhiSo> lstData = new List<RP_ChungTuGhiSo>();
            List<VnsGiaoDich> lstGiaoDich = new List<VnsGiaoDich>();
            RP_BC04DRService = (IRP_BC04DRService)Vns.Erp.Core.ObjectFactory.GetObject("RP_BC04DRService");
            List<RP_SoDuTaiKhoan> lstSoDuTk = RP_BC04DRService.GetSoDuTaiKhoan(p_TuNgay, p_DenNgay, str_TKCo, str_TKNo, str_TrangThaiCt);

            lstSoDuTk.Sort(VnsReportTongHop.CompareDoanRaCtGs);
            int CountDR = 0;
            Guid DrId = new Guid();
            foreach (RP_SoDuTaiKhoan obj in lstSoDuTk)
            {
                if (DrId != obj.DoanRaId)
                {
                    CountDR++;
                    DrId = obj.DoanRaId;
                }
            }
            int countCt = 0;
            string Soct = "";
            lstSoDuTk.Sort(VnsReportTongHop.CompareSoCtu);

            countCt = lstSoDuTk.GroupBy(e => e.CtId).Count();

            //foreach (RP_SoDuTaiKhoan obj in lstSoDuTk)
            //{
            //    if (Soct != obj.SoCt)
            //    {
            //        countCt++;
            //        Soct = obj.SoCt;
            //    }
            //}

            foreach (RP_SoDuTaiKhoan objGD in lstSoDuTk)
            {
                VnsDoanCongTac objDCT = GetDoanRaById(objGD.DoanRaId, lstDoanCt);
                VnsLoaiDoanRa objLoaiDR = GetLoaiDoanRa(objGD.LoaiDoanRaId, lstLoaiDoanRa);
                string strDoanCt = "";
                string strLoaiDoanRa = "";
                if (objDCT != null)
                    strDoanCt = objDCT.Ten;
                if (objLoaiDR != null)
                    strLoaiDoanRa = objLoaiDR.TenLoaiDoanRa;

                RP_ChungTuGhiSo objChungTu = new RP_ChungTuGhiSo(objGD, GiaTri, TimeTile, strLoaiDoanRa, strDoanCt, CountDR, countCt);

                if (GiaTri == 1 &&
                        (objGD.MaTkNo == Globals.TkTienMat || objGD.MaTkCo == Globals.TkTienChuyenKhoan))
                    objChungTu.TrichYeu = objGD.DienGiai;

                lstData.Add(objChungTu);
            }

            foreach (VnsLoaiDoanRa ldr in lstLoaiDoanRa)
            {
                RP_ChungTuGhiSo objblank = new RP_ChungTuGhiSo(ldr, GiaTri, TimeTile, CountDR, countCt);
                lstData.Add(objblank);
            }
            return lstData;
        }

        public IList<RP_ChungTuGhiSo> RPChungTuGhiSo_QT(DateTime p_TuNgay, DateTime p_DenNgay, string str_TKCo, string str_TKNo, string str_TrangThaiCt, int GiaTri, string TimeTile)
        {
            IList<VnsReportTongHop> lst = BaoCaoTongHopDoanRa(p_TuNgay, p_DenNgay, Null.NullGuid, 2, Vns.QuanLyDoanRa.ReportType.RP02);
            IList<RP_ChungTuGhiSo> lstctgs = new List<RP_ChungTuGhiSo>();
            IList<VnsLoaiDoanRa> lstLoaiDoanRa = VnsLoaiDoanRaDao.GetAll();
            int CountDR = 0;
            CountDR = lst.Count;
            int countCt = 0;
            countCt = lst.Count;

            List<RP_BangKeCtGhiSo> lstBangKe = new List<RP_BangKeCtGhiSo>();
            RP_BangKeCtGhiSo objBangke;
            RP_SoDuTaiKhoan objSoDu;
            RP_ChungTuGhiSo objctgs;
            //string trichyeucholoai1 = "";
            foreach (VnsReportTongHop tmp in lst)
            {
                objBangke = new RP_BangKeCtGhiSo();
                objSoDu = new RP_SoDuTaiKhoan();
                //objctgs = new RP_ChungTuGhiSo();
                VnsLoaiDoanRa objLoaiDR = GetLoaiDoanRa(tmp.LoaiDoanRaId, lstLoaiDoanRa);

                objBangke.DoanRaId = tmp.DoanRaId;
                objBangke.TenDoanRa = tmp.TenDoanRa;
                objBangke.LoaiDoanRaId = tmp.LoaiDoanRaId;
                objBangke.TenLoaiDoanRa = tmp.TenLoaiDoanRa;

                objBangke.SoTBDT = tmp.SoTbDt;
                objBangke.SoTBQT = tmp.SoTbQt;

                objBangke.NgayHt = p_TuNgay;
                objBangke.NgayCt = p_TuNgay;
                //objBangke.
                objBangke.DienGiai = String.Format("Quyết toán đoàn: {0} - DT: {1} - QT: {2}",
                    tmp.TenDoanRaVietTat, tmp.SoTbDt, tmp.SoTbQt);
                objBangke.TmTyGia = tmp.So_QT_TM_TG;
                objBangke.TmUSD = tmp.So_QT_TM_USD - tmp.Chi_QT_TM_USD;
                objBangke.TmVND = tmp.So_QT_TM_VND - tmp.Chi_QT_TM_VND;


                objBangke.CkTyGia = tmp.So_QT_CK_TG;
                objBangke.CkUSD = tmp.So_QT_CK_USD - tmp.Chi_QT_CK_USD;
                objBangke.CkVND = tmp.So_QT_CK_VND - tmp.Chi_QT_CK_VND;

                objBangke.TongUSD = objBangke.TmUSD + objBangke.CkUSD;
                objBangke.TongVND = objBangke.TmVND + objBangke.CkVND;

                if (objBangke.TongUSD != 0)
                {
                    objctgs = new RP_ChungTuGhiSo(objLoaiDR, GiaTri, TimeTile, CountDR, countCt);


                    objctgs.TM_USD = 0;// objBangke.TmUSD;
                    objctgs.TM_VND = tmp.So_QT_VND_TM - tmp.Chi_VND_QT_TM;// objBangke.TmVND;

                    objctgs.CPK_USD = tmp.So_QT_TM_USD - tmp.Chi_QT_TM_USD;
                    objctgs.CPK_VND = tmp.So_QT_TM_VND - tmp.Chi_QT_TM_VND;
                    objctgs.CPK_TyGia = tmp.So_QT_TM_TG;

                    objctgs.CK_USD = 0;// objBangke.CkUSD;
                    objctgs.CK_VND = tmp.So_QT_VND_CK - tmp.Chi_VND_QT_CK;// objBangke.CkVND;
                    lstctgs.Add(objctgs);
                }
            }

            foreach (VnsLoaiDoanRa ldr in lstLoaiDoanRa)
            {
                RP_ChungTuGhiSo objblank = new RP_ChungTuGhiSo(ldr, GiaTri, TimeTile, CountDR, countCt);
                lstctgs.Add(objblank);
            }

            return lstctgs;
        }
        #endregion 
        private VnsDoanCongTac GetDoanRaById(Guid _id, IList<VnsDoanCongTac> lstDoanRa)
        {
            foreach (VnsDoanCongTac obj in lstDoanRa)
            {
                if (obj.Id == _id)
                    return obj;
            }
            return null;
        }

        private VnsLoaiDoanRa GetLoaiDoanRa(Guid id, IList<VnsLoaiDoanRa> lst)
        {
            foreach (VnsLoaiDoanRa tmp in lst)
            {
                if (tmp.Id == id) return tmp;
            }

            return new VnsLoaiDoanRa();
        }

        public IList<RP_BC05DR> ReportBc05Dr(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId)
        {
            IList<VnsLoaiDoanRa> lstLoaiDoanRa = VnsLoaiDoanRaDao.GetAll();


            DateTime p_TuNgay_KyTruoc = p_TuNgay.AddMonths(-1);
            DateTime p_DenNgay_KyTruoc = p_TuNgay.AddDays(-1);

            List<RP_BC05DR> lstData = new List<RP_BC05DR>();

            /*lay tat ca cac doan ra den ngay quyet toan*/

            IList<VnsReportTongHop> lstDataThangNay = BaoCaoTongHopDoanRa(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, 2, ReportType.RP02); //Lay tat ca cac doan ra
            IList<VnsReportTongHop> lstDataThuHoan = BaoCaoTongHopDoanRa(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, 0, ReportType.RP02); //Lay tat ca cac doan ra



            RP_BC05DR obj;
            RP_BC05DR obj_Blank;

            #region Xu ly du lieu cong no - phai thu ky truoc
            IList<VnsReportTongHop> lstDataCnAll_KyTruoc_dk = new List<VnsReportTongHop>(); //BaoCaoTongHopDoanRa(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, 0, ReportType.RP02); //Lay tat ca cac doan ra
            IList<VnsReportTongHop> lstDataCnTn_dk = BaoCaoTongHopDoanRa(Null.NullDate, p_DenNgay_KyTruoc, p_LoaiDoanRaId, 2, ReportType.RP02);
            for (int i = lstDataCnTn_dk.Count - 1; i >= 0; i--)
            {
                if (lstDataCnTn_dk[i].ThangDuyetQt < p_TuNgay_KyTruoc)
                {
                    lstDataCnAll_KyTruoc_dk.Add(lstDataCnTn_dk[i]);
                    lstDataCnTn_dk.RemoveAt(i);
                }
            }

            foreach (VnsReportTongHop objrp in lstDataCnAll_KyTruoc_dk)
            {
                obj = new RP_BC05DR(objrp, "Kỳ trước", 1);

                obj.THU_CL_USD = 0;
                obj.THU_CL_VND = 0;

                obj.CHI_QT_USD = 0;
                obj.CHI_QT_VND = 0;

                obj.TU_USD = 0;
                obj.TU_VND = 0;

                obj.PT_KT_VND = 0;
                obj.PT_KT_USD = 0;

                obj.PT_KT_USD = objrp.CN_QT_PhaiThu_USD;
                obj.PT_KT_VND = objrp.CN_QT_PhaiThu_VND;

                obj.PT_TK_USD = 0;
                obj.PT_TK_VND = 0;

                obj.QT_TrongThang_USD = 0;
                obj.QT_TrongThang_VND = 0;

                lstData.Add(obj);
            }

            foreach (VnsReportTongHop objrp in lstDataCnTn_dk)
            {
                obj = new RP_BC05DR(objrp, "Kỳ này", 2);

                obj.THU_CL_USD = 0;
                obj.THU_CL_VND = 0;

                obj.TU_USD = 0;
                obj.TU_VND = 0;

                obj.CHI_QT_USD = 0;
                obj.CHI_QT_VND = 0;

                obj.PT_KT_VND = 0;
                obj.PT_KT_USD = 0;

                obj.PT_KT_USD = objrp.CN_QT_PhaiThu_USD;
                obj.PT_KT_VND = objrp.CN_QT_PhaiThu_VND;

                obj.PT_TK_USD = 0;
                obj.PT_TK_VND = 0;

                obj.QT_TrongThang_USD = 0;
                obj.QT_TrongThang_VND = 0;

                lstData.Add(obj);
            }
            #endregion

            #region Xu ly du lieu cong no - phai thu trong ky
            IList<VnsReportTongHop> lstDataCnAll_KyTruoc = new List<VnsReportTongHop>(); //BaoCaoTongHopDoanRa(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, 0, ReportType.RP02); //Lay tat ca cac doan ra
            IList<VnsReportTongHop> lstDataCnTn = BaoCaoTongHopDoanRa(Null.NullDate, p_DenNgay, p_LoaiDoanRaId, 2, ReportType.RP02);
            for (int i = lstDataCnTn.Count - 1; i >= 0; i--)
            {
                if (lstDataCnTn[i].ThangDuyetQt < p_TuNgay)
                {
                    lstDataCnAll_KyTruoc.Add(lstDataCnTn[i]);
                    lstDataCnTn.RemoveAt(i);
                }
            }

            foreach (VnsReportTongHop objrp in lstDataCnAll_KyTruoc)
            {
                obj = new RP_BC05DR(objrp, "Kỳ trước", 1);

                obj.THU_CL_USD = 0;
                obj.THU_CL_VND = 0;

                obj.CHI_QT_USD = 0;
                obj.CHI_QT_VND = 0;

                obj.TU_USD = 0;
                obj.TU_VND = 0;

                obj.PT_KT_VND = 0;
                obj.PT_KT_USD = 0;

                obj.PT_TK_USD = objrp.CN_QT_PhaiThu_USD;
                obj.PT_TK_VND = objrp.CN_QT_PhaiThu_VND;

                obj.QT_TrongThang_USD = 0;
                obj.QT_TrongThang_VND = 0;

                lstData.Add(obj);
            }

            foreach (VnsReportTongHop objrp in lstDataCnTn)
            {
                obj = new RP_BC05DR(objrp, "Kỳ này", 2);

                obj.THU_CL_USD = 0;
                obj.THU_CL_VND = 0;

                obj.CHI_QT_USD = 0;
                obj.CHI_QT_VND = 0;

                obj.TU_USD = 0;
                obj.TU_VND = 0;

                obj.PT_KT_VND = 0;
                obj.PT_KT_USD = 0;

                obj.PT_TK_USD = objrp.CN_QT_PhaiThu_USD;
                obj.PT_TK_VND = objrp.CN_QT_PhaiThu_VND;

                obj.QT_TrongThang_USD = 0;
                obj.QT_TrongThang_VND = 0;

                lstData.Add(obj);
            }
            #endregion


            /*Lay so tien thu hoan, tam ung trong ky
             Su dung lstDataThuHoan */
            #region Thu hoan
            foreach (VnsReportTongHop tmp in lstDataThuHoan)
            {
                if (tmp.ThangDuyetQt < p_TuNgay)
                {
                    obj = new RP_BC05DR(tmp, "Kỳ trước", 1);

                    //obj.TU_USD = tmp.TU_TK_TONG_USD;
                    //obj.TU_VND = tmp.TU_TK_TONG_VND;
                    obj.TU_USD = 0;
                    obj.TU_VND = 0;

                    //obj.CHI_QT_USD = tmp.Chi_QT_TONG_USD;
                    //obj.CHI_QT_VND = tmp.Chi_QT_TONG_VND;

                    obj.QT_TrongThang_USD = 0;
                    obj.QT_TrongThang_VND = 0;

                    //if (tmp.ThangDuyetQt >= p_TuNgay && tmp.ThangDuyetQt <= p_DenNgay)
                    //{
                    //    obj.QT_TrongThang_USD = 0;
                    //    obj.QT_TrongThang_VND = 0;
                    //}
                    //else if (tmp.ThangDuyetQt < p_TuNgay)
                    //{
                    //    obj.QT_TrongThang_USD = tmp.So_QT_USD_Tong;
                    //    obj.QT_TrongThang_VND = tmp.So_QT_VND_Tong;
                    //}
                }
                else
                {
                    //
                    obj = new RP_BC05DR(tmp, "Kỳ này", 2);

                    obj.TU_USD = tmp.TU_TK_TONG_USD;
                    obj.TU_VND = tmp.TU_TK_TONG_VND;

                    //if (tmp.ThangDuyetDt <= p_DenNgay && tmp.ThangDuyetQt >= p_DenNgay)
                    //{
                    //    obj.TU_USD = tmp.TU_TK_TONG_USD;
                    //    obj.TU_VND = tmp.TU_TK_TONG_VND;
                    //}
                    //else
                    //{
                    //    obj.TU_USD = 0;
                    //    obj.TU_VND = 0;
                    //}
                    //obj.THU_CL_USD = tmp.TH_TONG_USD;
                    //obj.THU_CL_VND = tmp.TH_TONG_VND;
                        
                    //obj.THU_CL_USD = 

                    //obj.CHI_QT_USD = tmp.Chi_QT_TONG_USD;
                    //obj.CHI_QT_VND = tmp.Chi_QT_TONG_VND;

                    obj.QT_TrongThang_USD = 0;
                    obj.QT_TrongThang_VND = 0;
                    
                    //if (tmp.ThangDuyetQt >= p_TuNgay && tmp.ThangDuyetQt <= p_DenNgay)
                    //{
                    //    obj.QT_TrongThang_USD = tmp.So_QT_USD_Tong;
                    //    obj.QT_TrongThang_VND = tmp.So_QT_VND_Tong;
                    //}
                    //else if (tmp.ThangDuyetQt < p_TuNgay)
                    //{
                    //    obj.QT_TrongThang_USD = 0;
                    //    obj.QT_TrongThang_VND = 0;
                    //}
                }

                //obj.CHI_QT_USD = tmp.Chi_QT_TONG_USD;
                //obj.CHI_QT_VND = tmp.Chi_QT_TONG_VND;
                obj.CHI_QT_USD = 0;
                obj.CHI_QT_VND = 0;

                obj.PT_KT_VND = 0;
                obj.PT_KT_USD = 0;

                obj.PT_TK_VND = 0;
                obj.PT_TK_USD = 0;

                lstData.Add(obj);
            }
            #endregion

            /*Lay so tien o giua*/
            #region Lay so tien o giua
            foreach (VnsReportTongHop tmp in lstDataThangNay)
            {
                if (tmp.ThangDuyetQt < p_TuNgay)
                {
                    obj = new RP_BC05DR(tmp, "Kỳ trước", 1);

                    obj.TU_USD = 0;
                    obj.TU_VND = 0;

                    obj.QT_TrongThang_USD = 0;
                    obj.QT_TrongThang_VND = 0;

                    if (tmp.ThangDuyetQt >= p_TuNgay && tmp.ThangDuyetQt <= p_DenNgay)
                    {
                        obj.QT_TrongThang_USD = 0;
                        obj.QT_TrongThang_VND = 0;

                        obj.CHI_QT_USD = 0;
                        obj.CHI_QT_VND = 0;
                    }
                    else if (tmp.ThangDuyetQt < p_TuNgay)
                    {
                        obj.QT_TrongThang_USD = tmp.So_QT_USD_Tong;
                        obj.QT_TrongThang_VND = tmp.So_QT_VND_Tong;

                        obj.CHI_QT_USD = tmp.Chi_QT_TONG_USD;
                        obj.CHI_QT_VND = tmp.Chi_QT_TONG_VND;
                    }
                }
                else
                {
                    obj = new RP_BC05DR(tmp, "Kỳ này", 2);

                    obj.TU_USD = 0;
                    obj.TU_VND = 0;

                    obj.QT_TrongThang_USD = 0;
                    obj.QT_TrongThang_VND = 0;

                    if (tmp.ThangDuyetQt >= p_TuNgay && tmp.ThangDuyetQt <= p_DenNgay)
                    {
                        obj.CHI_QT_USD = tmp.Chi_QT_TONG_USD;
                        obj.CHI_QT_VND = tmp.Chi_QT_TONG_VND;

                        obj.QT_TrongThang_USD = tmp.So_QT_USD_Tong;
                        obj.QT_TrongThang_VND = tmp.So_QT_VND_Tong;
                    }
                    else if (tmp.ThangDuyetQt < p_TuNgay)
                    {
                        obj.CHI_QT_USD = 0;
                        obj.CHI_QT_VND = 0;

                        obj.QT_TrongThang_USD = 0;
                        obj.QT_TrongThang_VND = 0;
                    }
                }

                obj.THU_CL_USD = 0;
                obj.THU_CL_VND = 0;

                obj.PT_KT_VND = 0;
                obj.PT_KT_USD = 0;

                obj.PT_TK_VND = 0;
                obj.PT_TK_USD = 0;

                lstData.Add(obj);
            }

            foreach (VnsReportTongHop objThangTruoc in lstDataThangNay) //lstDataThangTruoc
            {
                //if (objThangTruoc.ThangDuyetDt
                obj = new RP_BC05DR(objThangTruoc, "Kỳ trước", 1);

                obj.THU_CL_USD = 0;
                obj.THU_CL_VND = 0;

                obj.TU_USD = 0;
                obj.TU_VND = 0;

                obj.PT_KT_VND = 0;
                obj.PT_KT_USD = 0;

                obj.PT_TK_USD = 0;
                obj.PT_TK_VND = 0;

                obj.CHI_QT_USD = 0;
                obj.CHI_QT_VND = 0;

                obj.QT_TrongThang_USD = 0;
                obj.QT_TrongThang_VND = 0;

                obj_Blank = new RP_BC05DR();
                obj_Blank.LoaiDoanRaId = objThangTruoc.LoaiDoanRaId;
                obj_Blank.TenLoaiDoanRa = objThangTruoc.TenLoaiDoanRa;
                obj_Blank.NoiDung = "Kỳ này";
                obj_Blank.GroupByTime = 2;
                lstData.Add(obj);
                lstData.Add(obj_Blank);
            }

            foreach (VnsReportTongHop objThangNay in lstDataThangNay)
            {

                obj = new RP_BC05DR(objThangNay, "Kỳ này", 2);

                obj.THU_CL_USD = 0;
                obj.THU_CL_VND = 0;

                obj.TU_USD = 0;
                obj.TU_VND = 0;

                obj.PT_KT_VND = 0;
                obj.PT_KT_USD = 0;

                obj.PT_TK_USD = 0;
                obj.PT_TK_VND = 0;

                obj.CHI_QT_USD = 0;
                obj.CHI_QT_VND = 0;

                obj.QT_TrongThang_USD = 0;
                obj.QT_TrongThang_VND = 0;

                obj_Blank = new RP_BC05DR();
                obj_Blank.LoaiDoanRaId = objThangNay.LoaiDoanRaId;
                obj_Blank.TenLoaiDoanRa = objThangNay.TenLoaiDoanRa;
                obj_Blank.GroupByTime = 1;
                obj_Blank.NoiDung = "Kỳ trước";
                lstData.Add(obj);
                lstData.Add(obj_Blank);
            }
            #endregion

            /*Lay so quyet toan ky truoc, ky nay
             Su dung: lstTuChuaQtKyNay, lstTuChuaQtKyTruoc*/
            #region So tien chua quyet toan trong ky
            IList<VnsReportChuaQt> lstTuChuaQtKyNay_dk = GetSoTienChuaQuyetToan(p_DenNgay_KyTruoc, p_TuNgay_KyTruoc, p_DenNgay_KyTruoc, p_LoaiDoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, false); //GetSoTienChuaQuyetToan(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, Globals.TkTamUng, Globals.TkTienLike, true);
            IList<VnsReportChuaQt> lstTuChuaQtKyTruoc_dk = GetSoTienChuaQuyetToan(p_DenNgay_KyTruoc, Null.NullDate, p_TuNgay_KyTruoc.AddDays(-1), p_LoaiDoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, true); ; //GetSoTienChuaQuyetToan(DateTime.MinValue, p_TuNgay.AddDays(-1), p_LoaiDoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, false);

            foreach (VnsReportChuaQt objChuaQt in lstTuChuaQtKyNay_dk)
            {
                if ((objChuaQt.NgayDt <= p_DenNgay_KyTruoc && objChuaQt.NgayDt >= p_TuNgay_KyTruoc) || (objChuaQt.TongUSD != 0))
                {
                    obj = new RP_BC05DR(objChuaQt, "Kỳ này", 2);
                    VnsLoaiDoanRa objLoaiDr = GetLoaiDoanRa(obj.LoaiDoanRaId, lstLoaiDoanRa);// VnsLoaiDoanRaDao.GetByKey("Id", obj.LoaiDoanRaId);

                    obj.TU_Chua_QT_VND = 0;
                    obj.TU_Chua_QT_USD = 0;
                    obj.TU_Chua_QT_KT_USD = objChuaQt.TongUSD;
                    obj.TU_Chua_QT_KT_VND = objChuaQt.TongVND;

                    obj.TenLoaiDoanRa = objLoaiDr != null ? objLoaiDr.TenLoaiDoanRa : "";
                    obj_Blank = new RP_BC05DR();
                    obj_Blank.LoaiDoanRaId = obj.LoaiDoanRaId;
                    obj_Blank.TenLoaiDoanRa = obj.TenLoaiDoanRa;
                    obj_Blank.GroupByTime = 2;
                    obj_Blank.NoiDung = "Kỳ này";

                    lstData.Add(obj);
                    lstData.Add(obj_Blank);
                }
            }

            foreach (VnsReportChuaQt objChuaQt in lstTuChuaQtKyTruoc_dk)
            {
                if ((objChuaQt.NgayDt <= p_TuNgay_KyTruoc.AddDays(-1)) ||
                    (objChuaQt.NgayDt > p_TuNgay_KyTruoc.AddDays(-1) && objChuaQt.TongUSD != 0))
                {
                    obj = new RP_BC05DR(objChuaQt, "Kỳ trước", 1);
                    VnsLoaiDoanRa objLoaiDr = GetLoaiDoanRa(obj.LoaiDoanRaId, lstLoaiDoanRa);

                    obj.TU_Chua_QT_VND = 0;
                    obj.TU_Chua_QT_USD = 0;
                    obj.TU_Chua_QT_KT_USD = objChuaQt.TongUSD;
                    obj.TU_Chua_QT_KT_VND = objChuaQt.TongVND;

                    obj.TenLoaiDoanRa = objLoaiDr != null ? objLoaiDr.TenLoaiDoanRa : "";
                    obj_Blank = new RP_BC05DR();
                    obj_Blank.LoaiDoanRaId = obj.LoaiDoanRaId;
                    obj_Blank.TenLoaiDoanRa = obj.TenLoaiDoanRa;
                    obj_Blank.GroupByTime = 2;
                    obj_Blank.NoiDung = "Kỳ này";
                    lstData.Add(obj);
                    lstData.Add(obj_Blank);
                }
            }
            #endregion

            /*Lay so quyet toan ky truoc, ky nay
             Su dung: lstTuChuaQtKyNay, lstTuChuaQtKyTruoc*/
            #region So tien chua quyet toan trong ky
            IList<VnsReportChuaQt> lstTuChuaQtKyNay = GetSoTienChuaQuyetToan(p_DenNgay, p_TuNgay, p_DenNgay, p_LoaiDoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, false); //GetSoTienChuaQuyetToan(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, Globals.TkTamUng, Globals.TkTienLike, true);
            IList<VnsReportChuaQt> lstTuChuaQtKyTruoc = GetSoTienChuaQuyetToan(p_DenNgay, Null.NullDate, p_TuNgay.AddDays(-1), p_LoaiDoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, true); ; //GetSoTienChuaQuyetToan(DateTime.MinValue, p_TuNgay.AddDays(-1), p_LoaiDoanRaId, Globals.TkTamUng, Globals.LikeTkTienMat, false);

            foreach (VnsReportChuaQt objChuaQt in lstTuChuaQtKyNay)
            {
                if ((objChuaQt.NgayDt <= p_DenNgay && objChuaQt.NgayDt >= p_TuNgay) || (objChuaQt.TongUSD != 0))
                {
                    obj = new RP_BC05DR(objChuaQt, "Kỳ này", 2);
                    VnsLoaiDoanRa objLoaiDr = GetLoaiDoanRa(obj.LoaiDoanRaId, lstLoaiDoanRa);
                    obj.TenLoaiDoanRa = objLoaiDr != null ? objLoaiDr.TenLoaiDoanRa : "";
                    obj_Blank = new RP_BC05DR();
                    obj_Blank.LoaiDoanRaId = obj.LoaiDoanRaId;
                    obj_Blank.TenLoaiDoanRa = obj.TenLoaiDoanRa;
                    obj_Blank.GroupByTime = 2;
                    obj_Blank.NoiDung = "Kỳ này";

                    lstData.Add(obj);
                    lstData.Add(obj_Blank);
                }
            }

            foreach (VnsReportChuaQt objChuaQt in lstTuChuaQtKyTruoc)
            {
                if ((objChuaQt.NgayDt <= p_TuNgay.AddDays(-1)) ||
                    (objChuaQt.NgayDt > p_TuNgay.AddDays(-1) && objChuaQt.TongUSD != 0))
                {
                    obj = new RP_BC05DR(objChuaQt, "Kỳ trước", 1);
                    VnsLoaiDoanRa objLoaiDr = GetLoaiDoanRa(obj.LoaiDoanRaId, lstLoaiDoanRa);
                    obj.TenLoaiDoanRa = objLoaiDr != null ? objLoaiDr.TenLoaiDoanRa : "";
                    obj_Blank = new RP_BC05DR();
                    obj_Blank.LoaiDoanRaId = obj.LoaiDoanRaId;
                    obj_Blank.TenLoaiDoanRa = obj.TenLoaiDoanRa;
                    obj_Blank.GroupByTime = 2;
                    obj_Blank.NoiDung = "Kỳ này";
                    lstData.Add(obj);
                    lstData.Add(obj_Blank);
                }
            }
            #endregion



            /*Lay so cong no dau ky*/
            return lstData;
        }


        public IList<RP_BC06DR> ReportBc06Dr(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId, int type)
        {
            List<RP_BC06DR> lstData = new List<RP_BC06DR>();

            IList<VnsReportTongHop> lstDataThangTruoc = new List<VnsReportTongHop>(); //BaoCaoTongHopDoanRa(DateTime.MinValue, p_TuNgay.AddDays(-1), p_LoaiDoanRaId, 2, ReportType.RP02);
            IList<VnsReportTongHop> lstDataThangNay = new List<VnsReportTongHop>();
            if (type == 1)
                lstDataThangNay = BaoCaoTongHopDoanRa(Null.NullDate, p_DenNgay, p_LoaiDoanRaId, 2, ReportType.RP02); //BaoCaoTongHopDoanRa(p_TuNgay, p_DenNgay, p_LoaiDoanRaId, 2, ReportType.RP02);
            else
                lstDataThangNay = BaoCaoTongHopDoanRa(Null.NullDate, p_DenNgay, p_LoaiDoanRaId, 2, ReportType.RP02);

                for (int i = lstDataThangNay.Count - 1; i >= 0; i--)
                {
                    if (lstDataThangNay[i].ThangDuyetQt < p_TuNgay)
                    {
                        lstDataThangTruoc.Add(lstDataThangNay[i]);
                        lstDataThangNay.RemoveAt(i);
                    }
                }

            //RP_BC06DR obj;

            foreach (VnsReportTongHop objrp in lstDataThangTruoc)
            {
                RP_BC06DR objThangTruoc = new RP_BC06DR(objrp, objrp.LoaiDoanRaId, objrp.DoanRaId, objrp.TenLoaiDoanRa, objrp.TenDoanRaVietTat, objrp.TruongDoanFullName,
                    objrp.NuocCongTac, objrp.ThangDuyetQt,
                    objrp.CN_QT_PhaiThu_USD, objrp.CN_QT_PhaiThu_VND, objrp.CN_QT_PhaiThu_TG, objrp.CN_QT_VND_PhaiThu,
                    objrp.CN_PhaiTra_TM_USD, objrp.CN_VND_PhaiTra_TM,
                    //objrp.Chi_QT_TM_USD, objrp.Chi_QT_CK_USD, objrp.Chi_QT_TONG_USD,
                    "Kỳ trước chuyển sang", 1, type);

                objThangTruoc.NguoiTamUng = objrp.TenNguoiGiaoDich;
                objThangTruoc.SoTbDuToan = objrp.SoTbDt;
                objThangTruoc.SoTbQuyetToan = objrp.SoTbQt;

                if ((objThangTruoc.Tong != 0 && type == 2) ||
                    (objThangTruoc.USD != 0 && type == 1))
                {
                    lstData.Add(objThangTruoc);
                }
            }

            foreach (VnsReportTongHop objrp in lstDataThangNay)
            {
                RP_BC06DR objThangNay = new RP_BC06DR(objrp, objrp.LoaiDoanRaId, objrp.DoanRaId, objrp.TenLoaiDoanRa, objrp.TenDoanRaVietTat, objrp.TruongDoanFullName,
                    objrp.NuocCongTac, objrp.ThangDuyetQt,
                    objrp.CN_QT_PhaiThu_USD, objrp.CN_QT_PhaiThu_VND, objrp.CN_QT_PhaiThu_TG, objrp.CN_QT_VND_PhaiThu,
                    objrp.CN_PhaiTra_TM_USD, objrp.CN_VND_PhaiTra_TM,
                    //objrp.Chi_QT_TM_USD, objrp.Chi_QT_CK_USD, objrp.Chi_QT_TONG_USD,
                    "Kỳ này", 2, type);

                objThangNay.NguoiTamUng = objrp.TenNguoiGiaoDich;
                objThangNay.SoTbDuToan = objrp.SoTbDt;
                objThangNay.SoTbQuyetToan = objrp.SoTbQt;

                if ((objThangNay.Tong != 0 && type == 2) ||
                    (objThangNay.USD != 0 && type == 1))
                {
                    lstData.Add(objThangNay);
                }
            }

            return lstData;
        }


        public IList<BC03DR> ReportBc03Dr(DateTime p_TuNgay, DateTime p_DenNgay, Guid LoaiDoanRa)
        {
            IList<VnsReportChuaQt> lstThangTruocTemp = new List<VnsReportChuaQt>();
            IList<VnsReportChuaQt> lstThangNayTemp = new List<VnsReportChuaQt>();
            IList<BC03DR> lstData03 = new List<BC03DR>();
            BC03DR objBC03DR;

            //Loc doan ra quyet toan den ngay ve truoc, ham khac thang nay
            lstThangTruocTemp = GetSoTienChuaQuyetToan(p_DenNgay, Null.NullDate, p_TuNgay.AddDays(-1), LoaiDoanRa, Globals.TkTamUng, Globals.LikeTkTienMat, true);

            lstThangNayTemp = GetSoTienChuaQuyetToan(p_DenNgay, p_TuNgay, p_DenNgay, LoaiDoanRa, Globals.TkTamUng, Globals.LikeTkTienMat, false);

            foreach (VnsReportChuaQt objThangTruoc in lstThangTruocTemp)
            {
                if ((objThangTruoc.NgayDt <= p_TuNgay.AddDays(-1)) ||
                    (objThangTruoc.NgayDt > p_TuNgay.AddDays(-1) && objThangTruoc.TongUSD != 0))
                {
                    objBC03DR = new BC03DR(objThangTruoc, 1);
                    //if (objBC03DR.TongUSD != 0 || objBC03DR.TongVND != 0)
                    lstData03.Add(objBC03DR);
                }
            }

            foreach (VnsReportChuaQt objThangNay in lstThangNayTemp)
            {
                if ((objThangNay.NgayDt <= p_DenNgay && objThangNay.NgayDt >= p_TuNgay) || (objThangNay.TongUSD != 0))
                {
                    objBC03DR = new BC03DR(objThangNay, 2);
                    //if (objBC03DR.TongUSD != 0 || objBC03DR.TongVND != 0)
                    lstData03.Add(objBC03DR);
                }
            }

            return lstData03;
        }

        public IList<RP_Doan_CongNo> GetListSoDu(String pTk, DateTime p_TuNgay, DateTime p_DenNgay, Guid p_loaiDoanRaNoId, Guid p_loaiDoanRaCoId,
            Guid p_GiaoDichId)
        {
            IList<RP_Doan_CongNo> danhsachsodu = new List<RP_Doan_CongNo>();
            danhsachsodu = ReportDao.GetListSoDu(pTk, p_TuNgay, p_DenNgay, p_loaiDoanRaCoId, p_loaiDoanRaCoId, p_GiaoDichId);

            return danhsachsodu;
        }

        public IList<RP_SoDuTaiKhoan> GetListSoDuTaiKhoan(String pTk, DateTime p_TuNgay, DateTime p_DenNgay, Guid p_loaiDoanRaNoId, Guid p_loaiDoanRaCoId)
        {
            IList<VnsLoaiDoanRa> lstLoaiDoanRa = new List<VnsLoaiDoanRa>();
            lstLoaiDoanRa = VnsLoaiDoanRaDao.GetAll();

            IList<RP_Doan_CongNo> danhsachsodu = new List<RP_Doan_CongNo>();
            danhsachsodu = ReportDao.GetListSoDu(pTk, p_TuNgay, p_DenNgay, p_loaiDoanRaCoId, p_loaiDoanRaCoId, new Guid());

            //RP_SoDuTaiKhoan 
            IList<RP_SoDuTaiKhoan> lst = new List<RP_SoDuTaiKhoan>();
            foreach (RP_Doan_CongNo tmp in danhsachsodu)
            {
                RP_SoDuTaiKhoan tmpsodu = new RP_SoDuTaiKhoan();

                tmpsodu.LoaiDoanRaId = tmp.LoaiDoanRaNoId;

                foreach (VnsLoaiDoanRa tmpldr in lstLoaiDoanRa)
                {
                    if (tmpsodu.LoaiDoanRaId == tmpldr.Id)
                    {
                        tmpsodu.TenLoaiDoanRa = tmpldr.TenLoaiDoanRa;
                        break;
                    }
                }

                tmpsodu.SoDuUSD = tmp.PsNo - tmp.PsCo;
                tmpsodu.TyGia = tmp.TyGia;
                tmpsodu.SoDuVND = tmp.PsNoVND - tmp.PsCoVND;
                lst.Add(tmpsodu);
            }
            return lst;
        }

        public IList<PhuBieuChiQT> PhuBieuChiQt(DateTime p_TuNgay, DateTime p_DenNgay, out IList<PhuBieuChiQt_Dem> lst_dem)
        {
            IList<PhuBieuChiQT> lstPhuBieu = new List<PhuBieuChiQT>();
            PhuBieuChiQT objPhuBieu;
            IList<VnsDoanCongTac> lstDoanCongTacTemp = VnsDoanCongTacDao.GetByNgayQT(2, p_TuNgay, p_DenNgay, new Guid());
            IList<VnsLoaiDoanRa> lstLoaiDoanRa = VnsLoaiDoanRaDao.GetAll();

            PhuBieuChiQt_Dem doan_qt = new PhuBieuChiQt_Dem();
            PhuBieuChiQt_Dem doan_tu = new PhuBieuChiQt_Dem();
            PhuBieuChiQt_Dem nuoc_ct = new PhuBieuChiQt_Dem();
            PhuBieuChiQt_Dem songuoidi = new PhuBieuChiQt_Dem();

            lst_dem = new List<PhuBieuChiQt_Dem>();
            lst_dem.Add(doan_qt);
            lst_dem.Add(doan_tu);
            lst_dem.Add(nuoc_ct);
            lst_dem.Add(songuoidi);

            foreach (VnsDoanCongTac obj in lstDoanCongTacTemp)
            {
                VnsLoaiDoanRa objLoaiDoanRa = GetLoaiDoanRa(obj.LoaiDoanRaId, lstLoaiDoanRa);
                foreach (VnsQuyetToanDoan objqt in obj.DanhSachQuyetToanDoan)
                {
                    if (!objqt.objMucTieuMuc.MaMuc.Equals("6800"))
                    {
                        objPhuBieu = new PhuBieuChiQT(objqt, objLoaiDoanRa);
                        objPhuBieu.DoanRaId = obj.Id;
                        objPhuBieu.TenDoanRa = obj.TenHienThi;
                        lstPhuBieu.Add(objPhuBieu);
                    }                    
                }

                //dem
                if (obj.NgayQuyetToan >= p_TuNgay && obj.NgayQuyetToan <= p_DenNgay)
                {
                    if (obj.LoaiDoanRa.MaLoaiDoanRa == "1")
                    {
                        doan_qt.CacBanDang++;
                    }
                    else if (obj.LoaiDoanRa.MaLoaiDoanRa == "2")
                    {
                        doan_qt.DeAn165++;
                    }
                }

                if (obj.LoaiDoanRa.MaLoaiDoanRa == "1")
                {
                    doan_tu.CacBanDang++;
                }
                else if (obj.LoaiDoanRa.MaLoaiDoanRa == "2")
                {
                    doan_tu.DeAn165++;
                }

                PhuBieuChiQT objPhuBieuTemp1 = new PhuBieuChiQT();
                objPhuBieuTemp1.TieuMuc = "6801";
                objPhuBieuTemp1.STT = 1;
                foreach (VnsThanhVien objtv in obj.DanhSachThanhVien)
                {
                    if (obj.LoaiDoanRa.MaLoaiDoanRa == "1")
                    {
                        //doan_tu.CacBanDang++;
                        songuoidi.CacBanDang += objtv.SoLuong;
                    }
                    else if (obj.LoaiDoanRa.MaLoaiDoanRa == "2")
                    {
                        songuoidi.DeAn165 += objtv.SoLuong;
                        //doan_tu.DeAn165++;
                    }
                    //objPhuBieuTemp1.SoThanhVien += objtv.SoLuong;
                }

                foreach (VnsLichCongTac objtv in obj.DanhSachLichCongTac)
                {
                    if (obj.LoaiDoanRa.MaLoaiDoanRa == "1")
                    {
                        //doan_tu.CacBanDang++;
                        nuoc_ct.CacBanDang += 1;
                    }
                    else if (obj.LoaiDoanRa.MaLoaiDoanRa == "2")
                    {
                        nuoc_ct.DeAn165 += 1;
                        //doan_tu.DeAn165++;
                    }
                    //objPhuBieuTemp1.SoNuocCtac += 1;
                }

                objPhuBieuTemp1.TuNgay = p_TuNgay;
                objPhuBieuTemp1.DenNgay = p_DenNgay;
                objPhuBieuTemp1.NgayQuyetToan = obj.NgayQuyetToan;

                lstPhuBieu.Add(objPhuBieuTemp1);
            }

            return lstPhuBieu;
        }
    }
}
