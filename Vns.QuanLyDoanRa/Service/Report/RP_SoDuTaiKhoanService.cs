using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.Erp.Core.Service;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Dao.Interface.Report;
using Vns.QuanLyDoanRa.Dao;

namespace Vns.QuanLyDoanRa.Service.Report
{
    public class RP_SoDuTaiKhoanService : GenericService<RP_SoDuTaiKhoan, Guid>, IRP_SoDuTaiKhoanService
    {
        public IRP_SoDuTaiKhoanDao RP_SoDuTaiKhoanDao;
        public IVnsLoaiDoanRaDao VnsLoaiDoanRaDao;
        public IList<RP_SoDuTaiKhoan> lstGetDuNoCtTk112(DateTime p_TuNgay, DateTime p_DenNgay, string MaTk, string MaTkDu)
        {
            List<RP_SoDuTaiKhoan> lstDuNo = new List<RP_SoDuTaiKhoan>();
            lstDuNo.AddRange(RP_SoDuTaiKhoanDao.GetSoDuNoTaiKhoan(p_TuNgay, p_DenNgay, MaTkDu, MaTk));
            return lstDuNo;
        }

        public IList<RP_SoDuTaiKhoan> lstGetDuCoCtTk112(DateTime p_TuNgay, DateTime p_DenNgay, string MaTk, string MaTkDu)
        {
            List<RP_SoDuTaiKhoan> lstDuCo = new List<RP_SoDuTaiKhoan>();
            lstDuCo.AddRange(RP_SoDuTaiKhoanDao.GetSoDuCoTaiKhoan(p_TuNgay, p_DenNgay, MaTk, MaTkDu));
            return lstDuCo;
        }

        public IList<RP_SoDuTaiKhoan> lstGetDuCoCtTk112ThangTruocChuyenSang(DateTime p_TuNgay, DateTime p_DenNgay, string MaTk, string MaTkDu)
        {
            DateTime TuNgay = p_TuNgay;
            DateTime DenNgay = p_DenNgay;
            List<RP_SoDuTaiKhoan> lstDuCo = new List<RP_SoDuTaiKhoan>();
            lstDuCo.AddRange(RP_SoDuTaiKhoanDao.GetSoDuCoGroupByLoaiDoanRa(TuNgay, DenNgay, MaTk, MaTkDu));
            
            List<RP_SoDuTaiKhoan> lstDuNo = new List<RP_SoDuTaiKhoan>();
            lstDuNo.AddRange(RP_SoDuTaiKhoanDao.GetSoDuNoGroupByLoaiDoanRa(TuNgay, DenNgay, MaTkDu,MaTk));

            IList<RP_SoDuTaiKhoan> lstSoDuThangTruoc = new List<RP_SoDuTaiKhoan>();
            IList<RP_SoDuTaiKhoan> lstSoDuThangTruocTemp = new List<RP_SoDuTaiKhoan>();
            RP_SoDuTaiKhoan objSoDu = new RP_SoDuTaiKhoan();
            VnsLoaiDoanRa objDoanRa = new VnsLoaiDoanRa(); 

            IList<VnsLoaiDoanRa> lstLoaiDoanRa = VnsLoaiDoanRaDao.GetAll();

            foreach (VnsLoaiDoanRa obj in lstLoaiDoanRa)
            {
                bool flag = false;
                objSoDu = new RP_SoDuTaiKhoan();
                objSoDu.LoaiDoanRaId = obj.Id;
                objSoDu.TenLoaiDoanRa = obj.TenLoaiDoanRa;
                foreach (RP_SoDuTaiKhoan objDuNo in lstDuNo)
                {
                    if (objDuNo.LoaiDoanRaId == obj.Id)
                    {
                        flag = true;
                        objSoDu.SoDuUSD = objDuNo.PsTangUSD;
                        objSoDu.SoDuVND = objDuNo.PsTangVND;
                        if (objDuNo.PsTangUSD != 0)
                        {
                            objSoDu.TyGia = objDuNo.PsTangVND / objDuNo.PsTangUSD;
                        }
                        else
                            objSoDu.TyGia = 0;

                        lstSoDuThangTruocTemp.Add(objSoDu);
                    }
                }

                if (flag == false)
                {
                    lstSoDuThangTruocTemp.Add(objSoDu);
                }                            
            }

            foreach (RP_SoDuTaiKhoan obj in lstSoDuThangTruocTemp)
            {
                bool flag = false;
                foreach (RP_SoDuTaiKhoan objDuCo in lstDuCo)
                {                    
                    if (obj.LoaiDoanRaId == objDuCo.LoaiDoanRaId)
                    {
                        flag = true;
                        obj.SoDuUSD -= objDuCo.PsGiamUSD;
                        obj.SoDuVND -= objDuCo.PsGiamVND;

                        if (obj.SoDuUSD != 0)
                        {
                            obj.TyGia = obj.SoDuVND / obj.SoDuUSD;
                        }
                        else
                            obj.TyGia = 0;

                        lstSoDuThangTruoc.Add(obj);
                    }
                }

                if (!flag)
                    lstSoDuThangTruoc.Add(obj);
            }            
            return lstSoDuThangTruoc;
        }

        public List<RP_SoDuTaiKhoan> lstPhatSinhTrongThang(DateTime p_TuNgay, DateTime p_DenNgay, string MaTk, string MaTkDu)
        {
            List<RP_SoDuTaiKhoan> lstPhatSinh = new List<RP_SoDuTaiKhoan>();
            lstPhatSinh.AddRange(lstGetDuCoCtTk112(p_TuNgay,p_DenNgay, MaTk, MaTkDu));
            lstPhatSinh.AddRange(lstGetDuNoCtTk112(p_TuNgay, p_DenNgay,MaTk,MaTkDu));
            foreach (RP_SoDuTaiKhoan obj in lstPhatSinh)
            {
                if (MaTk == Globals.TkTienChuyenKhoan ||
                    MaTk == Globals.TkTienChuyenKhoanVND)
                {
                    obj.DisplayMoTa = obj.MoTa;
                }
                else
                {
                    obj.DisplayMoTa = obj.NgayCt.ToString("dd/MM");
                }
            }
            VnsLoaiDoanRa objDoanRa = new VnsLoaiDoanRa();
            foreach (RP_SoDuTaiKhoan obj in lstPhatSinh)
            {
                objDoanRa = VnsLoaiDoanRaDao.GetByKey("Id", obj.LoaiDoanRaId);
                if (objDoanRa != null)
                    obj.TenLoaiDoanRa = objDoanRa.TenLoaiDoanRa;
            }
            lstPhatSinh.Sort(CompareReport);
            return lstPhatSinh;
        }


        private int CompareReport(RP_SoDuTaiKhoan x, RP_SoDuTaiKhoan y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retvalDoanDienID = 0;
                    int revalSoChungTu = 0;
                    retvalDoanDienID = x.NgayHt.CompareTo(y.NgayHt);
                    if (retvalDoanDienID == 0)
                    {
                        return revalSoChungTu = x.SoCt.CompareTo(y.SoCt);
                    }
                    else
                        return retvalDoanDienID;
                }
            }
        }
    }
}
