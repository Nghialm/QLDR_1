using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.Erp.Core.Service;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Dao;

namespace Vns.QuanLyDoanRa.Service.Report
{
    public class RP_BC04DRService : GenericService<RP_BC04DR, Guid>, IRP_BC04DRService
    {
        public IRP_BC04DRDao RP_BC04DRDao;
        public IReportDao ReportDao;
        public IVnsDoanCongTacDao VnsDoanCongTacDao;
        Guid GuidEmpty = new Guid();
        //Dong 1
        public RP_BC04DR GetSoTienChuaQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId)
        {            
            IList<VnsGiaoDich> lstGiaoDichTamUng = new List<VnsGiaoDich>();
            lstGiaoDichTamUng = ReportDao.GetLstGiaoDich(Null.NullDate, p_TuNgay.AddDays(-1), p_LoaiDoanRaId,GuidEmpty, GuidEmpty, GuidEmpty, Globals.TkTamUng, Globals.TkTienLike, 0,1);
            RP_BC04DR obj04DR = new RP_BC04DR();
            obj04DR.NoiDung = "Số tiền chưa quyết toán kỳ trước";
            foreach (VnsGiaoDich objGiaoDich in lstGiaoDichTamUng)
            {
                if (objGiaoDich.MaTkCo.StartsWith(Globals.TkTienMat))
                {
                    obj04DR.TienMatUSD += objGiaoDich.SoTienNt;
                    obj04DR.TienMatVND += objGiaoDich.SoTien;
                }
                else if (objGiaoDich.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan))
                {
                    obj04DR.ChuyenKhoanUSD += objGiaoDich.SoTienNt;
                    obj04DR.ChuyenKhoanVND += objGiaoDich.SoTien;
                }
            }

            obj04DR.TongUSD = obj04DR.TienMatUSD + obj04DR.ChuyenKhoanUSD;
            obj04DR.TongVND = obj04DR.TienMatVND + obj04DR.ChuyenKhoanVND;

            return obj04DR;
        }

        //DOng 2 Tam ung no = 141, co = 11
        public RP_BC04DR GetSoTienTamUng(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId)
        {
           // RP_BC04DR SoTienDaThu = 

            IList<VnsGiaoDich> lstGiaoDichTamUng = new List<VnsGiaoDich>();
            lstGiaoDichTamUng = ReportDao.GetLstGiaoDich(p_TuNgay, p_DenNgay, p_LoaiDoanRaId,GuidEmpty,GuidEmpty, GuidEmpty, Globals.TkTamUng, Globals.LikeTkTienMat, 0, 0);
            RP_BC04DR obj04DR = new RP_BC04DR();
            //obj04DR.NoiDung = "Số tiền tạm ứng tháng " + p_TuNgay.Month.ToString();
            obj04DR.NoiDung = "Số tiền tạm ứng trong kỳ";
            foreach (VnsGiaoDich objGiaoDich in lstGiaoDichTamUng)
            {
                if (objGiaoDich.MaTkCo.StartsWith(Globals.TkTienMat))
                {
                    obj04DR.TienMatUSD += objGiaoDich.SoTienNt;
                    obj04DR.TienMatVND += objGiaoDich.SoTien;
                }
                else if (objGiaoDich.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan))
                {
                    obj04DR.ChuyenKhoanUSD += objGiaoDich.SoTienNt;
                    obj04DR.ChuyenKhoanVND += objGiaoDich.SoTien;
                }
            }

            obj04DR.TongUSD = obj04DR.TienMatUSD + obj04DR.ChuyenKhoanUSD;
            obj04DR.TongVND = obj04DR.TienMatVND + obj04DR.ChuyenKhoanVND;

            return obj04DR;
        }

        //Dong 3  So tien quyet toan: So tien da thực chi cho doan ra = TU + tra lai - HU
        //Tam ung: Co 141, no 11
        //Hoan ung : No 141, co 11
        public RP_BC04DR GetSoTienQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId)
        {                        
            IList<VnsGiaoDich> lstGiaoDichQt = new List<VnsGiaoDich>();
            IList<VnsGiaoDich> lstGiaoDichHU = new List<VnsGiaoDich>();
            //Lay so tien tam ung + tra lai doan ra(ko xet trang thai phieu)
            lstGiaoDichQt = ReportDao.GetLstGiaoDich(p_TuNgay, p_DenNgay, p_LoaiDoanRaId,GuidEmpty, GuidEmpty, GuidEmpty, Globals.TkTamUng, Globals.TkTienLike,-1, 2);
            //Lay so tien hoan ung
            lstGiaoDichHU = ReportDao.GetLstGiaoDich(p_TuNgay, p_DenNgay, p_LoaiDoanRaId,GuidEmpty, GuidEmpty, GuidEmpty, Globals.LikeTkTienMat, Globals.TkTamUng, -1, 2);

            RP_BC04DR obj04DR = new RP_BC04DR();
            //obj04DR.NoiDung = "Quyết toán tháng " + p_TuNgay.Month.ToString();
            obj04DR.NoiDung = "Quyết toán trong kỳ";
            foreach (VnsGiaoDich objGiaoDich in lstGiaoDichQt)
            {
                if (objGiaoDich.MaTkNo.StartsWith(Globals.TkTienMat) || objGiaoDich.MaTkCo.StartsWith(Globals.TkTienMat))
                {
                    obj04DR.TienMatUSD += objGiaoDich.SoTienNt;
                    obj04DR.TienMatVND += objGiaoDich.SoTien;
                }
                if (objGiaoDich.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan) || objGiaoDich.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan))
                {
                    obj04DR.ChuyenKhoanUSD += objGiaoDich.SoTienNt;
                    obj04DR.ChuyenKhoanVND += objGiaoDich.SoTien;
                }
            }

            foreach (VnsGiaoDich obj in lstGiaoDichHU)
            {
                if (obj.MaTkNo.StartsWith(Globals.TkTienMat) || obj.MaTkCo.StartsWith(Globals.TkTienMat))
                {
                    obj04DR.TienMatUSD -= obj.SoTienNt;
                    obj04DR.TienMatVND -= obj.SoTien;
                }
                if (obj.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan) || obj.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan))
                {
                    obj04DR.ChuyenKhoanUSD -= obj.SoTienNt;
                    obj04DR.ChuyenKhoanVND -= obj.SoTien;
                }
            }

            obj04DR.TongUSD = obj04DR.TienMatUSD + obj04DR.ChuyenKhoanUSD;
            obj04DR.TongVND = obj04DR.TienMatVND + obj04DR.ChuyenKhoanVND;
            return obj04DR;
        }

        //Dong 4
        //tien chi quyet toan là so tien da thực chi cho đoàn ra sau khi cong tac ve
        // =no 141 co 11 (phan biet voi tam ung bang trang thai)
        public RP_BC04DR GetSoTienChiQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId)
        {
            List<VnsGiaoDich> lstGiaoDichQt = new List<VnsGiaoDich>();
            lstGiaoDichQt.AddRange(ReportDao.GetLstGiaoDich(p_TuNgay, p_DenNgay, p_LoaiDoanRaId,GuidEmpty, GuidEmpty, GuidEmpty, Globals.TkTamUng, Globals.LikeTkTienMat, 1, 2));
            lstGiaoDichQt.AddRange(ReportDao.GetLstGiaoDich(p_TuNgay, p_DenNgay, p_LoaiDoanRaId,GuidEmpty, GuidEmpty, GuidEmpty, Globals.TkTamUng, Globals.LikeTkTienMat, 2, 2));
            RP_BC04DR obj04DR = new RP_BC04DR();
            foreach (VnsGiaoDich objGiaoDich in lstGiaoDichQt)
            {
                if (objGiaoDich.MaTkCo.StartsWith(Globals.TkTienMat) )
                {
                    obj04DR.TienMatUSD += objGiaoDich.SoTienNt;
                    obj04DR.TienMatVND += objGiaoDich.SoTien;
                }
                if (objGiaoDich.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan))
                {
                    obj04DR.ChuyenKhoanUSD += objGiaoDich.SoTienNt;
                    obj04DR.ChuyenKhoanVND += objGiaoDich.SoTien;
                }
            }

            obj04DR.TongUSD = obj04DR.ChuyenKhoanUSD + obj04DR.TienMatUSD;
            obj04DR.TongVND = obj04DR.ChuyenKhoanVND + obj04DR.TienMatVND;
            obj04DR.NoiDung = "Chi quyết toán trong kỳ";
            
            return obj04DR;
        }
        
        //Dong 5: chi tinh doan ra trong thang va thu hoan ngay trong thang
        // No 11 co 141
        public RP_BC04DR GetSoTienThuHoanTamUng(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId)
        {
            IList<VnsGiaoDich> lstGiaoDichTamUng = new List<VnsGiaoDich>();
            lstGiaoDichTamUng = ReportDao.GetLstGiaoDich(p_TuNgay, p_DenNgay, p_LoaiDoanRaId,GuidEmpty, GuidEmpty, GuidEmpty, Globals.LikeTkTienMat, Globals.TkTamUng, 2, 2);
            RP_BC04DR obj04DR = new RP_BC04DR();
            obj04DR.NoiDung = "Thu hoàn tạm ứng trong kỳ";
            foreach (VnsGiaoDich objGiaoDich in lstGiaoDichTamUng)
            {
                if (objGiaoDich.MaTkNo.StartsWith(Globals.TkTienMat))
                {
                    obj04DR.TienMatUSD += objGiaoDich.SoTienNt;
                    obj04DR.TienMatVND += objGiaoDich.SoTien;
                }
                else if (objGiaoDich.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan))
                {
                    obj04DR.ChuyenKhoanUSD += objGiaoDich.SoTienNt;
                    obj04DR.ChuyenKhoanVND += objGiaoDich.SoTien;
                }
            }

            obj04DR.TongUSD = obj04DR.TienMatUSD + obj04DR.ChuyenKhoanUSD;
            obj04DR.TongVND = obj04DR.TienMatVND + obj04DR.ChuyenKhoanVND;
            obj04DR.NoiDung = "Thu hoàn tạm ứng trong kỳ";
            return obj04DR;
        }
        //Dong 6: so phai thu la so tien da qt nhung chua thu cua thang truoc
        // = TU - QT - HU - DT >0
        public RP_BC04DR GetSoTienPhaiThu(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId)
        {
            DateTime TuNgay = Null.NullDate;
            DateTime DenNgay = p_TuNgay.AddDays(-1);

            //Get so tien đã chi
            RP_BC04DR objTU = GetSoTienTamUng(TuNgay, DenNgay, p_LoaiDoanRaId);
            RP_BC04DR objChiQt = GetSoTienChiQuyetToan(TuNgay, DenNgay, p_LoaiDoanRaId);
            RP_BC04DR objChi = new RP_BC04DR();
            objChi.TongVND = objTU.TongVND + objChiQt.TongVND;
            objChi.TongUSD = objTU.TongUSD + objChiQt.TongUSD;
            objChi.ChuyenKhoanUSD = objTU.ChuyenKhoanUSD + objChiQt.ChuyenKhoanUSD;
            objChi.ChuyenKhoanVND = objTU.ChuyenKhoanVND + objChiQt.ChuyenKhoanVND;
            objChi.TienMatUSD = objTU.TienMatUSD + objChiQt.TienMatUSD;
            objChi.TienMatVND = objTU.TienMatVND + objChiQt.TienMatVND;
            
            //Get so tien quyet toan
            IList<VnsGiaoDich> lstQt = ReportDao.GetLstGiaoDich(TuNgay, DenNgay, p_LoaiDoanRaId,GuidEmpty, GuidEmpty, GuidEmpty, Globals.LikeTkQt, Globals.TkTamUng, 0, 2);
            RP_BC04DR objQt = new RP_BC04DR();

            foreach (VnsGiaoDich objGiaoDich in lstQt)
            {
                if (objGiaoDich.MaTkNo.StartsWith(Globals.TkThanhToanTienMat))
                {
                    objQt.TienMatUSD += objGiaoDich.SoTienNt;
                    objQt.TienMatVND += objGiaoDich.SoTien;
                }
                else if (objGiaoDich.MaTkNo.StartsWith(Globals.TkThanhToanChuyenKhoan))
                {
                    objQt.ChuyenKhoanUSD += objGiaoDich.SoTienNt;
                    objQt.ChuyenKhoanVND += objGiaoDich.SoTien;
                }
            }
            objQt.TongUSD = objQt.TienMatUSD + objQt.ChuyenKhoanUSD;
            objQt.TongVND = objQt.TienMatVND + objQt.ChuyenKhoanVND;

            //Get so tien HU
            RP_BC04DR objHu = GetSoTienThuHoanTamUng(TuNgay, DenNgay, p_LoaiDoanRaId);

            RP_BC04DR objQT_HU = new RP_BC04DR();
            objQT_HU.TongVND = objQt.TongVND + objHu.TongVND;
            objQT_HU.TongUSD = objQt.TongUSD + objHu.TongUSD;
            objQT_HU.ChuyenKhoanUSD = objQt.ChuyenKhoanUSD + objHu.ChuyenKhoanUSD;
            objQT_HU.ChuyenKhoanVND = objQt.ChuyenKhoanVND + objHu.ChuyenKhoanVND;
            objQT_HU.TienMatUSD = objQt.TienMatUSD + objHu.TienMatUSD;
            objQT_HU.TienMatVND = objQt.TienMatVND + objHu.TienMatVND;

            //So tien phai thu
            RP_BC04DR ObjTienPhaiThu = new RP_BC04DR();

            decimal ChuyenKhoanVND = objChi.ChuyenKhoanVND - objQT_HU.ChuyenKhoanVND;
            decimal ChuyenKhoanUSD = objChi.ChuyenKhoanUSD - objQT_HU.ChuyenKhoanUSD;
            decimal TienMatUSD = objChi.TienMatUSD - objQT_HU.TienMatUSD;
            decimal TienMatVND = objChi.TienMatVND - objQT_HU.TienMatVND;

            ObjTienPhaiThu.NoiDung = "Số tiền phải thu kỳ trước";
            ObjTienPhaiThu.ChuyenKhoanUSD = ChuyenKhoanUSD < 0 ? 0: ChuyenKhoanUSD;
            ObjTienPhaiThu.ChuyenKhoanVND = ChuyenKhoanVND < 0 ? 0: ChuyenKhoanVND;
            ObjTienPhaiThu.TienMatUSD = TienMatUSD < 0 ? 0 : TienMatUSD;
            ObjTienPhaiThu.TienMatVND = TienMatVND < 0 ? 0 : TienMatVND ;

            ObjTienPhaiThu.TongVND = ObjTienPhaiThu.TienMatVND + ObjTienPhaiThu.ChuyenKhoanVND;
            ObjTienPhaiThu.TongUSD = ObjTienPhaiThu.TienMatUSD + ObjTienPhaiThu.ChuyenKhoanUSD;
            
            return ObjTienPhaiThu;
        }
        
        public IList<RP_BC04DR> GetDataRp04Dr(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId)
        {
            IList<RP_BC04DR> lstRp04Dr = new List<RP_BC04DR>();
            RP_BC04DR objRp04Dr = new RP_BC04DR();
            DateTime m_TuNgay = p_TuNgay;
            DateTime m_DenNgay = p_DenNgay;

            lstRp04Dr.Add(GetSoTienChuaQuyetToan(Null.NullDate,m_TuNgay.AddDays(-1),p_LoaiDoanRaId));
            lstRp04Dr.Add(GetSoTienTamUng(m_TuNgay,m_DenNgay,p_LoaiDoanRaId));
            lstRp04Dr.Add(GetSoTienQuyetToan(m_TuNgay, m_DenNgay, p_LoaiDoanRaId));
            lstRp04Dr.Add(GetSoTienChiQuyetToan(m_TuNgay, m_DenNgay, p_LoaiDoanRaId));
            lstRp04Dr.Add(GetSoTienThuHoanTamUng(m_TuNgay, m_DenNgay, p_LoaiDoanRaId));
            lstRp04Dr.Add(GetSoTienPhaiThu(m_TuNgay, m_DenNgay, p_LoaiDoanRaId));

            //Dong 7
            //objRp04Dr.NoiDung = "Tổng tiền chưa quyết toán chuyển tháng " + m_TuNgay.AddMonths(1).Month.ToString() + "-" + m_TuNgay.AddMonths(1).Year.ToString();
            objRp04Dr.NoiDung = "Tổng tiền chưa quyết toán kỳ trước ";
            objRp04Dr.TongUSD = lstRp04Dr[0].TongUSD + lstRp04Dr[1].TongUSD - lstRp04Dr[2].TongUSD + lstRp04Dr[3].TongUSD - lstRp04Dr[4].TongUSD - lstRp04Dr[5].TongUSD;
            objRp04Dr.TongVND = lstRp04Dr[0].TongVND + lstRp04Dr[1].TongVND - lstRp04Dr[2].TongVND + lstRp04Dr[3].TongVND - lstRp04Dr[4].TongVND - lstRp04Dr[5].TongVND;
            objRp04Dr.TienMatUSD = lstRp04Dr[0].TienMatUSD + lstRp04Dr[1].TienMatUSD - lstRp04Dr[2].TienMatUSD + lstRp04Dr[3].TienMatUSD - lstRp04Dr[4].TienMatUSD - lstRp04Dr[5].TienMatUSD;
            objRp04Dr.TienMatVND = lstRp04Dr[0].TienMatVND + lstRp04Dr[1].TienMatVND - lstRp04Dr[2].TienMatVND + lstRp04Dr[3].TienMatVND - lstRp04Dr[4].TienMatVND - lstRp04Dr[5].TienMatVND;
            objRp04Dr.ChuyenKhoanUSD = lstRp04Dr[0].ChuyenKhoanUSD + lstRp04Dr[1].ChuyenKhoanUSD - lstRp04Dr[2].ChuyenKhoanUSD + lstRp04Dr[3].ChuyenKhoanUSD - lstRp04Dr[4].ChuyenKhoanUSD - lstRp04Dr[5].ChuyenKhoanUSD;
            objRp04Dr.ChuyenKhoanVND = lstRp04Dr[0].ChuyenKhoanVND + lstRp04Dr[1].ChuyenKhoanVND - lstRp04Dr[2].ChuyenKhoanVND + lstRp04Dr[3].ChuyenKhoanVND - lstRp04Dr[4].ChuyenKhoanVND - lstRp04Dr[5].ChuyenKhoanVND;
            lstRp04Dr.Add(objRp04Dr);

            return lstRp04Dr;
        }
       
        //Bang ke chung tu ghi so
        public List<RP_SoDuTaiKhoan> GetSoDuTaiKhoan(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo, string p_TrangThaiCt)
        {
            return ReportDao.GetSoDuTaiKhoan(p_TuNgay, p_DenNgay, p_TkCo, p_TkNo, p_TrangThaiCt);
        }

        public List<RP_SoDuTaiKhoan> GetBangKeQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo, string p_TrangThaiCt)
        {
            return ReportDao.GetBangKeQuyetToan(p_TuNgay, p_DenNgay, p_TkCo, p_TkNo, p_TrangThaiCt);
        }
    }
}
