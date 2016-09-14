using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.QuanLyDoanRa.Dao;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.Erp.Core.Service;

namespace Vns.QuanLyDoanRa.Service.Report
{
    public class RP_BC03DRService : GenericService<BC03DR, Guid>, IRP_BC03DRService
   {
       #region"Properties"
       public IVnsDuToanDoanDao VnsDuToanDoanDao;
       public IVnsGiaoDichDao VnsGiaoDichDao;
       public IVnsDoanCongTacDao VnsDoanCongTacDao;
       public IVnsChungTuDao VnsChungTuDao;
       public IVnsLichCongTacDao VnsLichCongTacDao;
       #endregion

       public IList<BC03DR> GetData_BC03DR(String p_MaTk, DateTime m_TuNgay, DateTime m_DenNgay, Guid p_LoaiDoanRaId)
       {
           List<BC03DR> lstSourceThangTruoc = new List<BC03DR>();
           List<BC03DR> lstSourceThangNay = new List<BC03DR>();
           IList<BC03DR> lstChuaQTThangNay = new List<BC03DR>();
           List<BC03DR> lstDtSource = new List<BC03DR>();

           lstSourceThangTruoc = VnsDuToanDoanDao.ListChuaQuyetToan(Null.NullDate, m_TuNgay.AddDays(-1), p_LoaiDoanRaId);
           lstSourceThangNay = VnsDuToanDoanDao.ListChuaQuyetToan(m_TuNgay, m_DenNgay, p_LoaiDoanRaId);
         

           lstDtSource.AddRange(GetData_BC03DR(m_TuNgay, m_DenNgay, lstSourceThangTruoc, true));
           lstDtSource.AddRange(GetData_BC03DR(m_TuNgay, m_DenNgay, lstSourceThangNay, false));
         

           return lstDtSource;
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

       public IList<BC03DR> GetData_BC03DR(DateTime p_TuNgay, DateTime p_DenNgay, IList<BC03DR> lstDt, Boolean Fthang)
       {
           DateTime dt = p_TuNgay;
           foreach (BC03DR objBC03DR in lstDt)
           {
               if (Fthang)
               {
                   objBC03DR.GroupThang = dt.AddMonths(-1).Month ;
                   objBC03DR.TenGroupThang = "Kỳ trước chuyển sang";
               }
               else
               {
                   objBC03DR.GroupThang = dt.Month ;
                   objBC03DR.TenGroupThang = "Kỳ này";
               }

               objBC03DR.ThangDuyetDt = objBC03DR.NgayDuyetDt.ToString("MM/yyyy");
                            
               VnsDoanCongTac objDoanCongTac = VnsDoanCongTacDao.GetByKey("Id",objBC03DR.DoanRaId);
               if (objDoanCongTac != null)
               {
                   objBC03DR.TenDoan = objDoanCongTac.Ten;
                   objBC03DR.TruongDoan = objDoanCongTac.TenTruongDoan;
                   objBC03DR.LoaiDoanRaId = objDoanCongTac.LoaiDoanRaId;
                   objBC03DR.TenLoaiDoanRa = objDoanCongTac.TenLoaiDoanRa;
                   objBC03DR.SoTbDt = objDoanCongTac.SoTbDuToan;
                   objBC03DR.NuocCongTac = GetLichCongTac(objBC03DR.DoanRaId);
               }

               //Lay so tien tam ung theo doan cong tac
               IList<VnsGiaoDich> lstGiaoDich = VnsGiaoDichDao.GetTUByDoanRaId(objBC03DR.DoanRaId);

               foreach (VnsGiaoDich objGiaoDich in lstGiaoDich)
               {
                   if (objGiaoDich.MaTkCo.StartsWith(Globals.TkTienMat))
                   {
                       objBC03DR.TienMatUSD += objGiaoDich.SoTienNt;
                       objBC03DR.TienMatTG = objGiaoDich.TyGia;
                       objBC03DR.TienMatVND += objGiaoDich.SoTien;
                   }
                   else if (objGiaoDich.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan))
                   {
                       objBC03DR.ChuyenKhoanUSD += objGiaoDich.SoTienNt;
                       objBC03DR.ChuyenKhoanTG = objGiaoDich.TyGia;
                       objBC03DR.ChuyenKhoanVND += objGiaoDich.SoTien;
                   }
               }

               objBC03DR.TongUSD = objBC03DR.ChuyenKhoanUSD + objBC03DR.TienMatUSD;
               objBC03DR.TongVND = objBC03DR.ChuyenKhoanVND + objBC03DR.TienMatVND;

               if (lstGiaoDich.Count > 0)
               {
                   VnsChungTu objChungTu = VnsChungTuDao.Get(lstGiaoDich[0].ChungTuId);
                   if(objChungTu!=null)
                    objBC03DR.NguoiTamUng = objChungTu.NguoiGiaoDich;
               }
           }

           return lstDt;
       }
    }
}
