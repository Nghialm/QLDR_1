using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Service.Report;
using Vns.QuanLyDoanRa.Domain.Report;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa;

namespace QuanLyDoanRa.Reports
{
    public partial class PhuLuc_TongHopQuyetToanDoanRa : DevExpress.XtraReports.UI.XtraReport
    {
        public IReportService ReportService;
        public IRP_BC04DRService RP_BC04DRService;
        public IVnsLoaiDoanRaService VnsLoaiDoanRaService;

        public PhuLuc_TongHopQuyetToanDoanRa()
        {
            InitializeComponent();
        }

        private IList<VnsLoaiDoanRa> lstLoaiDoanRa = new List<VnsLoaiDoanRa>();
        private DateTime m_TuNgay;
        private DateTime m_DenNgay;
        string m_Time;

        public PhuLuc_TongHopQuyetToanDoanRa(DateTime p_TuNgay, DateTime p_DenNgay, string time)
        {
            InitializeComponent();
            m_TuNgay = p_TuNgay;
            m_DenNgay = p_DenNgay;
            m_Time = time;
            ReportService = (IReportService)ObjectFactory.GetObject("ReportService");
            VnsLoaiDoanRaService = (IVnsLoaiDoanRaService)ObjectFactory.GetObject("VnsLoaiDoanRaService");
            lstLoaiDoanRa = VnsLoaiDoanRaService.GetAll();
         
            lblPhan.Text = string.Format("Các cơ quan Đảng, Đề án 165 {0} (mục 6800)", m_Time.ToLower());
        }

        private VnsLoaiDoanRa GetLoaiDoanRaByMa(string Ma)
        {
            foreach (VnsLoaiDoanRa obj in lstLoaiDoanRa)
            {
                if (obj.MaLoaiDoanRa == Ma)
                {
                    return obj;
                }
            }

            return null;
        }

        private void B06DR_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            IList<PhuLucTongHopQuyetToanDr> lstSource = InitData();
            lstSource = BindData(lstSource);
            this.DataSource = lstSource;
        }

        private RP_BC04DR GetPhiChuyenTien(DateTime p_tuNgay, DateTime p_DenNgay)
        {
            RP_BC04DR objRT = new RP_BC04DR();
            objRT.NoiDung = "- Phí chuyển tiền";
            objRT.MaNoiDung = "";
            List<RP_SoDuTaiKhoan> lstSoDuTk = RP_BC04DRService.GetSoDuTaiKhoan(p_tuNgay, p_DenNgay, Vns.QuanLyDoanRa.Globals.TkThuNganSach, "661", "-1");

            foreach (RP_SoDuTaiKhoan obj in lstSoDuTk)
            {
                objRT.TongUSD += obj.PsTangUSD;
                objRT.TongVND += obj.PsTangVND;

                objRT.TienMatUSD += obj.PsTangUSD;
                objRT.TienMatVND_QD += obj.PsTangVND;
            }

            return objRT;
        }

        private IList<PhuLucTongHopQuyetToanDr> BindData(IList<PhuLucTongHopQuyetToanDr> lstData)
        {
            #region "PHAN THU"
            IList<RP_SoDuTaiKhoan> lstTienMat = ReportService.GetListSoDuTaiKhoan(Vns.QuanLyDoanRa.Globals.TkTienMat, Null.NullDate, m_TuNgay.AddDays(-1), Null.NullGuid, Null.NullGuid);
            VnsLoaiDoanRa objCacBanDang = GetLoaiDoanRaByMa(Vns.QuanLyDoanRa.Globals.CacBanDang);
            VnsLoaiDoanRa objDeAn = GetLoaiDoanRaByMa(Vns.QuanLyDoanRa.Globals.DeAn);
            if (objCacBanDang == null || objDeAn == null) return lstData;
            foreach (RP_SoDuTaiKhoan obj in lstTienMat)
            {
                //Tien mat tong
                lstData[2].QuyNayUSD += obj.SoDuUSD;
                lstData[2].QuyNayVND += obj.SoDuVND;
                //Tien mat cac ban dang
                if (objCacBanDang.Id == obj.LoaiDoanRaId)
                {
                    lstData[8].QuyNayUSD += obj.SoDuUSD;
                    lstData[8].QuyNayVND += obj.SoDuVND;
                }

                if (objDeAn.Id == obj.LoaiDoanRaId)
                {
                    lstData[13].QuyNayUSD += obj.SoDuUSD;
                    lstData[13].QuyNayVND += obj.SoDuVND;
                }
            }

            //tien chuyen khoan
            IList<RP_SoDuTaiKhoan> lstTienCk = ReportService.GetListSoDuTaiKhoan(Vns.QuanLyDoanRa.Globals.TkTienChuyenKhoan, Null.NullDate, m_TuNgay.AddDays(-1), Null.NullGuid, Null.NullGuid);
            foreach (RP_SoDuTaiKhoan obj in lstTienCk)
            {
                //Tien mat tong
                lstData[3].QuyNayUSD += obj.SoDuUSD;
                lstData[3].QuyNayVND += obj.SoDuVND;

                //chuyen khoan cac ban dang
                if (objCacBanDang.Id == obj.LoaiDoanRaId)
                {
                    lstData[9].QuyNayUSD += obj.SoDuUSD;
                    lstData[9].QuyNayVND += obj.SoDuVND;
                }

                //chuyen khoan cac de an
                if (objDeAn.Id == obj.LoaiDoanRaId)
                {
                    lstData[14].QuyNayUSD += obj.SoDuUSD;
                    lstData[14].QuyNayVND += obj.SoDuVND;
                }
            }

            //So tien tam ung chua quyet toan 09
            IList<BC03DR> lstTamUngChuaQt = ReportService.ReportBc03Dr(m_TuNgay.AddYears(-100), m_TuNgay.AddDays(-1), Null.NullGuid);

            foreach (BC03DR obj in lstTamUngChuaQt)
            {
                //Tong
                lstData[4].QuyNayUSD += obj.TongUSD;
                lstData[4].QuyNayVND += obj.TongVND;

                //Cac ban dang
                if (objCacBanDang.Id == obj.LoaiDoanRaId)
                {
                    lstData[10].QuyNayUSD += obj.TongUSD;
                    lstData[10].QuyNayVND += obj.TongVND;
                }

                //De an
                if (objDeAn.Id == obj.LoaiDoanRaId)
                {
                    lstData[15].QuyNayUSD += obj.TongUSD;
                    lstData[15].QuyNayVND += obj.TongVND;
                }
            }

            //So thu chenh lenh QT/TU
            IList<VnsReportTongHop> lstBaoCaoTongHop = ReportService.BaoCaoTongHopDoanRa(Null.NullDate, m_TuNgay.AddDays(-1), Null.NullGuid, 2, ReportType.RP02);
            foreach (VnsReportTongHop obj in lstBaoCaoTongHop)
            {
                //Tong
                lstData[5].QuyNayUSD += obj.CN_QT_PhaiThu_USD;
                lstData[5].QuyNayVND += obj.CN_QT_PhaiThu_VND;

                //Cac ban dang
                if (objCacBanDang.Id == obj.LoaiDoanRaId)
                {
                    lstData[11].QuyNayUSD += obj.CN_QT_PhaiThu_USD;
                    lstData[11].QuyNayVND += obj.CN_QT_PhaiThu_VND;
                }

                //De an
                if (objDeAn.Id == obj.LoaiDoanRaId)
                {
                    lstData[16].QuyNayUSD += obj.CN_QT_PhaiThu_USD;
                    lstData[16].QuyNayVND += obj.CN_QT_PhaiThu_VND;
                }
            }

            //Tinh tong
            lstData[1].QuyNayUSD = lstData[2].QuyNayUSD + lstData[3].QuyNayUSD + lstData[4].QuyNayUSD + lstData[5].QuyNayUSD;
            lstData[1].QuyNayVND = lstData[2].QuyNayVND + lstData[3].QuyNayVND + lstData[4].QuyNayVND + lstData[5].QuyNayVND;

            lstData[7].QuyNayUSD = lstData[8].QuyNayUSD + lstData[9].QuyNayUSD;
            lstData[7].QuyNayVND = lstData[8].QuyNayVND + lstData[9].QuyNayVND;

            lstData[7].QuyNayUSD = lstData[8].QuyNayUSD + lstData[9].QuyNayUSD + lstData[10].QuyNayUSD + lstData[11].QuyNayUSD;
            lstData[7].QuyNayVND = lstData[8].QuyNayVND + lstData[9].QuyNayVND + lstData[10].QuyNayVND + lstData[11].QuyNayVND;

            lstData[12].QuyNayUSD = lstData[13].QuyNayUSD + lstData[14].QuyNayUSD + lstData[15].QuyNayUSD + lstData[16].QuyNayUSD;
            lstData[12].QuyNayVND = lstData[13].QuyNayVND + lstData[14].QuyNayVND + lstData[15].QuyNayVND + lstData[16].QuyNayVND;

            //Bo tai chinh cap
            RP_BC04DRService = (IRP_BC04DRService)ObjectFactory.GetObject("RP_BC04DRService");
            List<RP_SoDuTaiKhoan> lstSoDuTk = RP_BC04DRService.GetSoDuTaiKhoan(m_TuNgay, m_DenNgay, Vns.QuanLyDoanRa.Globals.TkThuNganSach, Vns.QuanLyDoanRa.Globals.TkNghieVuNhanTienBtc, "-1");

            foreach (RP_SoDuTaiKhoan obj in lstSoDuTk)
            {
                //Tong
                if (obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkTienMat || obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkNghiepVuChiHoatDong)
                {
                    lstData[18].QuyNayUSD += obj.PsTangUSD;
                    lstData[18].QuyNayVND += obj.PsTangVND;
                }
                else if (obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkTienChuyenKhoan)
                {
                    lstData[19].QuyNayUSD += obj.PsTangUSD;
                    lstData[19].QuyNayVND += obj.PsTangVND;
                }

                //Cac ban dang
                if (objCacBanDang.Id == obj.LoaiDoanRaId)
                {
                    if (obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkTienMat || obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkNghiepVuChiHoatDong)
                    {
                        lstData[21].QuyNayUSD += obj.PsTangUSD;
                        lstData[21].QuyNayVND += obj.PsTangVND;
                    }
                    else if (obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkTienChuyenKhoan)
                    {
                        lstData[22].QuyNayUSD += obj.PsTangUSD;
                        lstData[22].QuyNayVND += obj.PsTangVND;
                    }
                }

                //De an
                if (objDeAn.Id == obj.LoaiDoanRaId)
                {
                    if (obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkTienMat || obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkNghiepVuChiHoatDong)
                    {
                        lstData[24].QuyNayUSD += obj.PsTangUSD;
                        lstData[24].QuyNayVND += obj.PsTangVND;
                    }
                    else if (obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkTienChuyenKhoan)
                    {
                        lstData[25].QuyNayUSD += obj.PsTangUSD;
                        lstData[25].QuyNayVND += obj.PsTangVND;
                    }
                }
            }

            DateTime dauNam = new DateTime(m_DenNgay.Year, 2, 1);
            List<RP_SoDuTaiKhoan> lstSoDuTkLuyKe = RP_BC04DRService.GetSoDuTaiKhoan(dauNam, m_DenNgay, Vns.QuanLyDoanRa.Globals.TkThuNganSach, Vns.QuanLyDoanRa.Globals.TkNghieVuNhanTienBtc, "-1");
            foreach (RP_SoDuTaiKhoan obj in lstSoDuTkLuyKe)
            {
                //Tong
                if (obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkTienMat || obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkNghiepVuChiHoatDong)
                {
                    lstData[18].LuyKeUSD += obj.PsTangUSD;
                    lstData[18].LuyKeVND += obj.PsTangVND;
                }
                else if (obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkTienChuyenKhoan)
                {
                    lstData[19].LuyKeUSD += obj.PsTangUSD;
                    lstData[19].LuyKeVND += obj.PsTangVND;
                }

                //Cac ban dang
                if (objCacBanDang.Id == obj.LoaiDoanRaId)
                {
                    if (obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkTienMat || obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkNghiepVuChiHoatDong)
                    {
                        lstData[21].LuyKeUSD += obj.PsTangUSD;
                        lstData[21].LuyKeVND += obj.PsTangVND;
                    }
                    else if (obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkTienChuyenKhoan)
                    {
                        lstData[22].LuyKeUSD += obj.PsTangUSD;
                        lstData[22].LuyKeVND += obj.PsTangVND;
                    }
                }

                //De an
                if (objDeAn.Id == obj.LoaiDoanRaId)
                {
                    if (obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkTienMat)
                    {
                        lstData[24].LuyKeUSD += obj.PsTangUSD;
                        lstData[24].LuyKeVND += obj.PsTangVND;
                    }
                    else if (obj.MaTkNo == Vns.QuanLyDoanRa.Globals.TkTienChuyenKhoan)
                    {
                        lstData[25].LuyKeUSD += obj.PsTangUSD;
                        lstData[25].LuyKeVND += obj.PsTangVND;
                    }
                }
            }

            lstData[17].QuyNayUSD = lstData[18].QuyNayUSD + lstData[19].QuyNayUSD;
            lstData[17].QuyNayVND = lstData[18].QuyNayVND + lstData[19].QuyNayVND;
            lstData[17].LuyKeUSD = lstData[18].LuyKeUSD + lstData[19].LuyKeUSD;
            lstData[17].LuyKeVND = lstData[18].LuyKeVND + lstData[19].LuyKeVND;

            lstData[20].QuyNayUSD = lstData[21].QuyNayUSD + lstData[22].QuyNayUSD;
            lstData[20].QuyNayVND = lstData[21].QuyNayVND + lstData[22].QuyNayVND;
            lstData[20].LuyKeUSD = lstData[21].LuyKeUSD + lstData[22].LuyKeUSD;
            lstData[20].LuyKeVND = lstData[21].LuyKeVND + lstData[22].LuyKeVND;

            lstData[23].QuyNayUSD = lstData[24].QuyNayUSD + lstData[25].QuyNayUSD;
            lstData[23].QuyNayVND = lstData[24].QuyNayVND + lstData[25].QuyNayVND;
            lstData[23].LuyKeUSD = lstData[24].LuyKeUSD + lstData[25].LuyKeUSD;
            lstData[23].LuyKeVND = lstData[24].LuyKeVND + lstData[25].LuyKeVND;
            #endregion

            #region "PHAN CHI"
            // PHAN CHI
            //So thu chenh lenh QT/TU 
            IList<VnsReportTongHop> lstPhanChi = ReportService.BaoCaoTongHopDoanRa(m_TuNgay, m_DenNgay, Null.NullGuid, 2, ReportType.RP02);

            RP_BC04DR phichuyentientk = GetPhiChuyenTien(m_TuNgay, m_DenNgay);

            foreach (VnsReportTongHop obj in lstPhanChi)
            {

                lstData[28].QuyNayUSD += obj.So_QT_TM_USD;
                lstData[28].QuyNayVND += obj.So_QT_TM_VND;

                lstData[29].QuyNayUSD += obj.So_QT_CK_USD;
                lstData[29].QuyNayVND += obj.So_QT_CK_VND;

                //Cac ban dang
                if (objCacBanDang.Id == obj.LoaiDoanRaId)
                {
                    lstData[33].QuyNayUSD += obj.So_QT_TM_USD;
                    lstData[33].QuyNayVND += obj.So_QT_TM_VND;

                    lstData[34].QuyNayUSD += obj.So_QT_CK_USD;
                    lstData[34].QuyNayVND += obj.So_QT_CK_VND;
                }

                //De an
                if (objDeAn.Id == obj.LoaiDoanRaId)
                {
                    lstData[37].QuyNayUSD += obj.So_QT_TM_USD;
                    lstData[37].QuyNayVND += obj.So_QT_TM_VND;

                    lstData[38].QuyNayUSD += obj.So_QT_CK_USD;
                    lstData[38].QuyNayVND += obj.So_QT_CK_VND;
                }
            }

            //Bo sung them phi chuyen tien
            lstData[28].QuyNayUSD += phichuyentientk.TongUSD;
            lstData[28].QuyNayVND += phichuyentientk.TongVND;
            //Bo sung cho ban dang   phichuyentientk
            lstData[33].QuyNayUSD += phichuyentientk.TongUSD;
            lstData[33].QuyNayVND += phichuyentientk.TongVND;

            //Lay so luy ke
            RP_BC04DR phichuyentienlk = GetPhiChuyenTien(dauNam, m_DenNgay);
            IList<VnsReportTongHop> lstPhanChiLuyKe = ReportService.BaoCaoTongHopDoanRa(dauNam, m_DenNgay, Null.NullGuid, 2, ReportType.RP02);
            foreach (VnsReportTongHop obj in lstPhanChiLuyKe)
            {
                lstData[28].LuyKeUSD += obj.So_QT_TM_USD;
                lstData[28].LuyKeVND += obj.So_QT_TM_VND;

                lstData[29].LuyKeUSD += obj.So_QT_CK_USD;
                lstData[29].LuyKeVND += obj.So_QT_CK_VND;

                //Cac ban dang
                if (objCacBanDang.Id == obj.LoaiDoanRaId)
                {
                    lstData[33].LuyKeUSD += obj.So_QT_TM_USD;
                    lstData[33].LuyKeVND += obj.So_QT_TM_VND;

                    lstData[34].LuyKeUSD += obj.So_QT_CK_USD;
                    lstData[34].LuyKeVND += obj.So_QT_CK_VND;
                }

                //De an
                if (objDeAn.Id == obj.LoaiDoanRaId)
                {
                    lstData[37].LuyKeUSD += obj.So_QT_TM_USD;
                    lstData[37].LuyKeVND += obj.So_QT_TM_VND;

                    lstData[38].LuyKeUSD += obj.So_QT_CK_USD;
                    lstData[38].LuyKeVND += obj.So_QT_CK_VND;
                }
            }

            //Bo sung them phi chuyen tien dong luy ke
            lstData[28].LuyKeUSD += phichuyentienlk.TongUSD;
            lstData[28].LuyKeVND += phichuyentienlk.TongVND;
            //Bo sung cho ban dang   phichuyentientk
            lstData[33].LuyKeUSD += phichuyentienlk.TongUSD;
            lstData[33].LuyKeVND += phichuyentienlk.TongVND;
            //

            lstData[27].QuyNayUSD = lstData[28].QuyNayUSD + lstData[29].QuyNayUSD + lstData[30].QuyNayUSD;
            lstData[27].QuyNayVND = lstData[28].QuyNayVND + lstData[29].QuyNayVND + lstData[30].QuyNayVND;
            lstData[27].LuyKeUSD = lstData[28].LuyKeUSD + lstData[29].LuyKeUSD + lstData[30].LuyKeUSD;
            lstData[27].LuyKeVND = lstData[28].LuyKeVND + lstData[29].LuyKeVND + lstData[30].LuyKeVND;

            lstData[32].QuyNayUSD = lstData[33].QuyNayUSD + lstData[34].QuyNayUSD + lstData[35].QuyNayUSD;
            lstData[32].QuyNayVND = lstData[33].QuyNayVND + lstData[34].QuyNayVND + lstData[35].QuyNayVND;
            lstData[32].LuyKeUSD = lstData[33].LuyKeUSD + lstData[34].LuyKeUSD + lstData[35].LuyKeUSD;
            lstData[32].LuyKeVND = lstData[33].LuyKeVND + lstData[34].LuyKeVND + lstData[35].LuyKeVND;

            lstData[36].QuyNayUSD = lstData[37].QuyNayUSD + lstData[38].QuyNayUSD;
            lstData[36].QuyNayVND = lstData[37].QuyNayVND + lstData[38].QuyNayVND;
            lstData[36].LuyKeUSD = lstData[37].LuyKeUSD + lstData[38].LuyKeUSD;
            lstData[36].LuyKeVND = lstData[37].LuyKeVND + lstData[38].LuyKeVND;
            #endregion

            #region "KINH PHI CHUYEN TIEP"
            //KINH PHI CHUYEN TIEP
            IList<RP_SoDuTaiKhoan> lstTienMatCt = ReportService.GetListSoDuTaiKhoan(Vns.QuanLyDoanRa.Globals.TkTienMat, Null.NullDate, m_DenNgay, Null.NullGuid, Null.NullGuid);

            foreach (RP_SoDuTaiKhoan obj in lstTienMatCt)
            {
                //Tien mat tong
                lstData[41].QuyNayUSD += obj.SoDuUSD;
                lstData[41].QuyNayVND += obj.SoDuVND;
                //Tien mat cac ban dang
                if (objCacBanDang.Id == obj.LoaiDoanRaId)
                {
                    lstData[47].QuyNayUSD += obj.SoDuUSD;
                    lstData[47].QuyNayVND += obj.SoDuVND;
                }

                if (objDeAn.Id == obj.LoaiDoanRaId)
                {
                    lstData[52].QuyNayUSD += obj.SoDuUSD;
                    lstData[52].QuyNayVND += obj.SoDuVND;
                }
            }


            IList<RP_SoDuTaiKhoan> lstTienCkCt = ReportService.GetListSoDuTaiKhoan(Vns.QuanLyDoanRa.Globals.TkTienChuyenKhoan, Null.NullDate, m_DenNgay, Null.NullGuid, Null.NullGuid);
            foreach (RP_SoDuTaiKhoan obj in lstTienCkCt)
            {
                //Tien mat tong
                lstData[42].QuyNayUSD += obj.SoDuUSD;
                lstData[42].QuyNayVND += obj.SoDuVND;

                //chuyen khoan cac ban dang
                if (objCacBanDang.Id == obj.LoaiDoanRaId)
                {
                    lstData[48].QuyNayUSD += obj.SoDuUSD;
                    lstData[48].QuyNayVND += obj.SoDuVND;
                }

                //chuyen khoan cac de an
                if (objDeAn.Id == obj.LoaiDoanRaId)
                {
                    lstData[53].QuyNayUSD += obj.SoDuUSD;
                    lstData[53].QuyNayVND += obj.SoDuVND;
                }
            }

            //So tien tam ung chua quyet toan 09
            IList<BC03DR> lstTamUngChuaQtCt = ReportService.ReportBc03Dr(m_TuNgay.AddYears(-100), m_DenNgay, Null.NullGuid);

            foreach (BC03DR obj in lstTamUngChuaQtCt)
            {
                //Tong
                lstData[43].QuyNayUSD += obj.TongUSD;
                lstData[43].QuyNayVND += obj.TongVND;

                //Cac ban dang
                if (objCacBanDang.Id == obj.LoaiDoanRaId)
                {
                    lstData[49].QuyNayUSD += obj.TongUSD;
                    lstData[49].QuyNayVND += obj.TongVND;
                }

                //De an
                if (objDeAn.Id == obj.LoaiDoanRaId)
                {
                    lstData[54].QuyNayUSD += obj.TongUSD;
                    lstData[54].QuyNayVND += obj.TongVND;
                }
            }

            //So thu chenh lenh QT/TU
            IList<VnsReportTongHop> lstBaoCaoTongHopCt = ReportService.BaoCaoTongHopDoanRa(Null.NullDate, m_DenNgay, Null.NullGuid, 2, ReportType.RP02);
            foreach (VnsReportTongHop obj in lstBaoCaoTongHopCt)
            {
                //Tong
                lstData[44].QuyNayUSD += obj.CN_QT_PhaiThu_USD;
                lstData[44].QuyNayVND += obj.CN_QT_PhaiThu_VND;

                //Cac ban dang
                if (objCacBanDang.Id == obj.LoaiDoanRaId)
                {
                    lstData[50].QuyNayUSD += obj.CN_QT_PhaiThu_USD;
                    lstData[50].QuyNayVND += obj.CN_QT_PhaiThu_VND;
                }

                //De an
                if (objDeAn.Id == obj.LoaiDoanRaId)
                {
                    lstData[55].QuyNayUSD += obj.CN_QT_PhaiThu_USD;
                    lstData[55].QuyNayVND += obj.CN_QT_PhaiThu_VND;
                }
            }

            lstData[40].QuyNayUSD = lstData[41].QuyNayUSD + lstData[42].QuyNayUSD + lstData[43].QuyNayUSD + lstData[44].QuyNayUSD;
            lstData[40].QuyNayVND = lstData[41].QuyNayVND + lstData[42].QuyNayVND + lstData[43].QuyNayVND + lstData[44].QuyNayVND;

            lstData[46].QuyNayUSD = lstData[47].QuyNayUSD + lstData[48].QuyNayUSD + lstData[49].QuyNayUSD + lstData[50].QuyNayUSD;
            lstData[46].QuyNayVND = lstData[47].QuyNayVND + lstData[48].QuyNayVND + lstData[49].QuyNayVND + lstData[50].QuyNayVND;

            lstData[51].QuyNayUSD = lstData[52].QuyNayUSD + lstData[53].QuyNayUSD + lstData[54].QuyNayUSD + lstData[55].QuyNayUSD;
            lstData[51].QuyNayVND = lstData[52].QuyNayVND + lstData[53].QuyNayVND + lstData[54].QuyNayVND + lstData[55].QuyNayVND;
            #endregion

            return lstData;
        }

        private IList<PhuLucTongHopQuyetToanDr> InitData()
        {
            //Style = 0 : Thường
            //Style = 1 : In đậm
            //Style = 2 : In đậm + Nghiêng

            IList<PhuLucTongHopQuyetToanDr> lstSource = new List<PhuLucTongHopQuyetToanDr>();

            PhuLucTongHopQuyetToanDr dong01 = new PhuLucTongHopQuyetToanDr("A", "PHẦN THU", 0, 0, 0, 0, 1);
            PhuLucTongHopQuyetToanDr dong02 = new PhuLucTongHopQuyetToanDr("1", "Kinh phí chuyển tiếp kỳ trước", 0, 0, 0, 0, 1);
            PhuLucTongHopQuyetToanDr dong03 = new PhuLucTongHopQuyetToanDr("", "    - Tiền mặt", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong04 = new PhuLucTongHopQuyetToanDr("", "    - Kho bạc trung ương", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong05 = new PhuLucTongHopQuyetToanDr("", "Thu tạm ứng -Chưa quyết toán", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong06 = new PhuLucTongHopQuyetToanDr("", "           -Số thu chênh lệch QT/TU", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong07 = new PhuLucTongHopQuyetToanDr("", "Trong đó:", 0, 0, 0, 0, 2);
            PhuLucTongHopQuyetToanDr dong08 = new PhuLucTongHopQuyetToanDr("", "Các ban Đảng", 0, 0, 0, 0, 1);
            PhuLucTongHopQuyetToanDr dong09 = new PhuLucTongHopQuyetToanDr("", "    - Tiền mặt", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong10 = new PhuLucTongHopQuyetToanDr("", "    - Kho bạc trung ương", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong11 = new PhuLucTongHopQuyetToanDr("", "Thu tạm ứng -Chưa quyết toán", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong12 = new PhuLucTongHopQuyetToanDr("", "            -Số thu chênh lệch QT/TU", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong13 = new PhuLucTongHopQuyetToanDr("", "Đề án 165", 0, 0, 0, 0, 1);
            PhuLucTongHopQuyetToanDr dong14 = new PhuLucTongHopQuyetToanDr("", "    - Tiền mặt", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong15 = new PhuLucTongHopQuyetToanDr("", "    - Kho bạc trung ương", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong16 = new PhuLucTongHopQuyetToanDr("", "Thu tạm ứng -Chưa quyết toán", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong17 = new PhuLucTongHopQuyetToanDr("", "            -Số thu chênh lệch QT/TU", 0, 0, 0, 0, 0);

            PhuLucTongHopQuyetToanDr dong18 = new PhuLucTongHopQuyetToanDr("2", "Bộ Tài chính cấp", 0, 0, 0, 0, 1);
            PhuLucTongHopQuyetToanDr dong19 = new PhuLucTongHopQuyetToanDr("", "    - Tiền mặt", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong20 = new PhuLucTongHopQuyetToanDr("", "    - Kho bạc trung ương", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong21 = new PhuLucTongHopQuyetToanDr("", "Kinh phí đoàn ra các ban Đảng", 0, 0, 0, 0, 1);
            PhuLucTongHopQuyetToanDr dong22 = new PhuLucTongHopQuyetToanDr("", "    - Tiền mặt", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong23 = new PhuLucTongHopQuyetToanDr("", "    - Kho bạc trung ương", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong24 = new PhuLucTongHopQuyetToanDr("", "Kinh phí Đề án 165", 0, 0, 0, 0, 1);
            PhuLucTongHopQuyetToanDr dong25 = new PhuLucTongHopQuyetToanDr("", "    - Tiền mặt", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong26 = new PhuLucTongHopQuyetToanDr("", "    - Kho bạc trung ương", 0, 0, 0, 0, 0);


            PhuLucTongHopQuyetToanDr dong27 = new PhuLucTongHopQuyetToanDr("B", "PHẦN CHI", 0, 0, 0, 0, 1);
            PhuLucTongHopQuyetToanDr dong28 = new PhuLucTongHopQuyetToanDr("", "Tổng hợp kinh phí được quyết toán", 0, 0, 0, 0, 1);
            PhuLucTongHopQuyetToanDr dong29 = new PhuLucTongHopQuyetToanDr("", "    - Tiền mặt", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong30 = new PhuLucTongHopQuyetToanDr("", "    - Kho bạc trung ương", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong31 = new PhuLucTongHopQuyetToanDr("", "    - Chênh lệch tỷ giá tiền gửi kho bạc", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong32 = new PhuLucTongHopQuyetToanDr("", "Trong đó:", 0, 0, 0, 0, 2);
            PhuLucTongHopQuyetToanDr dong33 = new PhuLucTongHopQuyetToanDr("", "Các ban Đảng:", 0, 0, 0, 0, 1);
            PhuLucTongHopQuyetToanDr dong34 = new PhuLucTongHopQuyetToanDr("", "    - Tiền mặt", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong35 = new PhuLucTongHopQuyetToanDr("", "    - Kho bạc trung ương", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong36 = new PhuLucTongHopQuyetToanDr("", "    - Chênh lệch tỷ giá tiền gửi kho bạc", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong37 = new PhuLucTongHopQuyetToanDr("", "Đề án 165:", 0, 0, 0, 0, 1);
            PhuLucTongHopQuyetToanDr dong38 = new PhuLucTongHopQuyetToanDr("", "    - Tiền mặt", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong39 = new PhuLucTongHopQuyetToanDr("", "    - Kho bạc trung ương", 0, 0, 0, 0, 0);


            PhuLucTongHopQuyetToanDr dong40 = new PhuLucTongHopQuyetToanDr("C", "PHẦN KINH PHÍ CHUYỂN TIẾP KỲ SAU", 0, 0, 0, 0, 1);
            PhuLucTongHopQuyetToanDr dong41 = new PhuLucTongHopQuyetToanDr("", "Tổng kinh phí chuyển tiếp", 0, 0, 0, 0, 1);
            PhuLucTongHopQuyetToanDr dong42 = new PhuLucTongHopQuyetToanDr("", "    - Tiền mặt", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong43 = new PhuLucTongHopQuyetToanDr("", "    - Kho bạc trung ương", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong44 = new PhuLucTongHopQuyetToanDr("", "Thu tạm ứng -Chưa quyết toán", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong45 = new PhuLucTongHopQuyetToanDr("", "            -Số thu chênh lệch QT/TU", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong46 = new PhuLucTongHopQuyetToanDr("", "Trong đó:", 0, 0, 0, 0, 2);
            PhuLucTongHopQuyetToanDr dong47 = new PhuLucTongHopQuyetToanDr("", "Các ban Đảng", 0, 0, 0, 0, 1);
            PhuLucTongHopQuyetToanDr dong48 = new PhuLucTongHopQuyetToanDr("", "    - Tiền mặt", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong49 = new PhuLucTongHopQuyetToanDr("", "    - Kho bạc trung ương", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong50 = new PhuLucTongHopQuyetToanDr("", "Thu tạm ứng -Chưa quyết toán", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong51 = new PhuLucTongHopQuyetToanDr("", "            -Số thu chênh lệch QT/TU", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong52 = new PhuLucTongHopQuyetToanDr("", "Đề án 165", 0, 0, 0, 0, 1);
            PhuLucTongHopQuyetToanDr dong53 = new PhuLucTongHopQuyetToanDr("", "    - Tiền mặt", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong54 = new PhuLucTongHopQuyetToanDr("", "    - Kho bạc trung ương", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong55 = new PhuLucTongHopQuyetToanDr("", "Thu tạm ứng -Chưa quyết toán", 0, 0, 0, 0, 0);
            PhuLucTongHopQuyetToanDr dong56 = new PhuLucTongHopQuyetToanDr("", "            -Số thu chênh lệch QT/TU", 0, 0, 0, 0, 0);

            lstSource.Add(dong01);
            lstSource.Add(dong02);
            lstSource.Add(dong03);
            lstSource.Add(dong04);
            lstSource.Add(dong05);
            lstSource.Add(dong06);
            lstSource.Add(dong07);
            lstSource.Add(dong08);
            lstSource.Add(dong09);
            lstSource.Add(dong10);
            lstSource.Add(dong11);
            lstSource.Add(dong12);
            lstSource.Add(dong13);
            lstSource.Add(dong14);
            lstSource.Add(dong15);
            lstSource.Add(dong16);
            lstSource.Add(dong17);
            lstSource.Add(dong18);
            lstSource.Add(dong19);
            lstSource.Add(dong20);
            lstSource.Add(dong21);
            lstSource.Add(dong22);
            lstSource.Add(dong23);
            lstSource.Add(dong24);
            lstSource.Add(dong25);
            lstSource.Add(dong26);
            lstSource.Add(dong27);
            lstSource.Add(dong28);
            lstSource.Add(dong29);
            lstSource.Add(dong30);
            lstSource.Add(dong31);
            lstSource.Add(dong32);
            lstSource.Add(dong33);
            lstSource.Add(dong34);
            lstSource.Add(dong35);
            lstSource.Add(dong36);
            lstSource.Add(dong37);
            lstSource.Add(dong38);
            lstSource.Add(dong39);
            lstSource.Add(dong40);
            lstSource.Add(dong41);
            lstSource.Add(dong42);
            lstSource.Add(dong43);
            lstSource.Add(dong44);
            lstSource.Add(dong45);
            lstSource.Add(dong46);
            lstSource.Add(dong47);
            lstSource.Add(dong48);
            lstSource.Add(dong49);
            lstSource.Add(dong50);
            lstSource.Add(dong51);
            lstSource.Add(dong52);
            lstSource.Add(dong53);
            lstSource.Add(dong54);
            lstSource.Add(dong55);
            lstSource.Add(dong56);
            
            return lstSource;
        }

        int i = 0;
        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            i++;
            if (i == 1)
                e.Cancel = true;
        }
    }
}
