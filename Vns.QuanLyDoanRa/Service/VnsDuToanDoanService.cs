﻿/*
insert license info here
*/
using System.Collections;
using System.ComponentModel;
using System.Data;
using System;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Dao;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.Erp.Core.Service;
using Vns.Erp.Core.Service.Interface;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain.Report;
namespace Vns.QuanLyDoanRa.Service
{
    /// <summary>
    ///	Generated by MyGeneration using the NHibernate Object Mapping adapted by Gustavo
    /// </summary>	
    //,IVnsDuToanDoanService
    public class VnsDuToanDoanService : GenericService<VnsDuToanDoan, Guid>, IVnsDuToanDoanService
    {
        public IVnsDuToanDoanDao VnsDuToanDoanDao
        {
            get { return (IVnsDuToanDoanDao)Dao; }
            set { Dao = value; }
        }
        public IVnsDanhMucChucVuDao VnsDanhMucChucVuDao; 
        public IVnsThanhVienDao VnsThanhVienDao;
        public IVnsLichCongTacDao VnsLichCongTacDao;
        public IVnsDinhMucDao VnsDinhMucDao;
        public IVnsDmMucTieuMucDao VnsDmMucTieuMucDao;
        public IList<VnsDuToanDoan> TinhDuToan(DateTime NgayTinh, VnsDoanCongTac objDoanRa)
        {
            decimal HeSoMucA = 1;
            decimal HeSoMucB = 1;
            int TongSoNuoc = 0;
            VnsDanhMucChucVu obj = VnsDanhMucChucVuDao.GetByKey("ChucVuId", objDoanRa.ChucVuTruongDoanId);
            if (obj != null)
            {
                HeSoMucA = (decimal) obj.HeSoa;
                HeSoMucB = (decimal) obj.HeSob;
            }
            //HeSoMucA= objDoanRa.c
            //Danh sach dinh muc
            IList<VnsDinhMuc> lstDinhMuc = VnsDinhMucDao.GetByNgayApDung(NgayTinh,0,false);
            //Danh sach cac dia diem di cua doan ra
            IList<VnsLichCongTac> lstLichCongTac = VnsLichCongTacDao.GetByDoanCongTac(objDoanRa.Id);
            TongSoNuoc = lstLichCongTac.Count;
            //Danh sach so thanh vien
            int l1 = 0;
            int l2 = 0;
            int l3 = 0;
            /* Dung commented
            IList<VnsThanhVien> lstThanhVienCongTac = VnsThanhVienDao.GetByDoanCongTac(objDoanRa.Id);

            foreach (VnsThanhVien tmp in lstThanhVienCongTac)
            {
                switch (tmp.PhanLoai)
                {
                    case 1:
                        l1 += tmp.SoLuong;
                        break;
                    case 2:
                        l2 += tmp.SoLuong;
                        break;
                    case 3:
                        l3 += tmp.SoLuong;
                        break;
                }
            }
            */
            
            List<DemNuoc> lstdem = new List<DemNuoc>();
            //Dem so ngay cong tac theo nuoc
            for (int i = 1; i <= 3; i++)
            {
                int SoLuongThanhVienA = 0;
                int SoLuongThanhVienB = 0;
                DemNuoc nuoc = new DemNuoc();
                nuoc.TongSoNuoc = TongSoNuoc;
                nuoc.LoaiNuoc = i;
                nuoc.SoNgay = 0;
                nuoc.SoNuoc = 0;
                nuoc.SoNguoiC = l3;
                foreach (VnsLichCongTac tmp in lstLichCongTac)
                {

                    //nuoc.SoNguoiA = l1;
                    //nuoc.SoNguoiB = l2;
                    if (tmp.LoaiQuocGia == i)
                    {
                        IList<VnsThanhVien> lstThanhVienTemp = VnsThanhVienDao.GetThanhVienByLichCongTacDoanRa(tmp.Id, tmp.CongTacId);
                        foreach (VnsThanhVien objTV in lstThanhVienTemp)
                        {
                            if (objTV.PhanLoai == 1)
                                SoLuongThanhVienA = objTV.SoLuong;
                            if (objTV.PhanLoai == 2)
                                SoLuongThanhVienB = objTV.SoLuong;
                        }
                        if (tmp.NgayCongTac == 0)
                        {
                            TimeSpan songay = tmp.NgayVe - tmp.NgayDi;
                            nuoc.SoNgay += songay.Days;
                        }
                        else
                            nuoc.SoNgay += tmp.NgayCongTac;
                        nuoc.SoNuoc++;
                    }
                }
                nuoc.SoNguoiA = SoLuongThanhVienA;
                nuoc.SoNguoiB = SoLuongThanhVienB;
                lstdem.Add(nuoc);
            }
            IList<VnsDuToanDoan> lstDutoanDoan = new List<VnsDuToanDoan>();
            foreach (VnsDinhMuc tmp in lstDinhMuc)
            {
                if (tmp.Muc.MaMuc != "6802")
                {
                    foreach (DemNuoc objNuoc in lstdem)
                    {
                        VnsDuToanDoan dtMucA = objNuoc.GenDinhMuc1(tmp, 1, 1);
                        if (dtMucA != null) lstDutoanDoan.Add(dtMucA);
                    }
                }
                else
                {
                    foreach (DemNuoc objNuoc in lstdem)
                    {
                        VnsDuToanDoan dtMucA = objNuoc.GenDinhMuc1(tmp, HeSoMucA, HeSoMucB);
                        if (dtMucA != null)
                        {
                            dtMucA.CongTacId = objDoanRa.Id;
                            lstDutoanDoan.Add(dtMucA);
                        }
                    }
                }
            }

            IList<VnsDinhMuc> lstDinhMuc2 = VnsDinhMucDao.GetByNgayApDung(NgayTinh, 0, true);
            foreach (VnsDinhMuc tmp in lstDinhMuc2)
            {
                VnsDuToanDoan objDuToan = new VnsDuToanDoan();
                objDuToan.DienGiai = "Tạm tính";
                objDuToan.TenKhoanChi = tmp.DienGiai;
                objDuToan.SoTienDuToan = 0;
                objDuToan.CongTacId = objDoanRa.Id;
                objDuToan.MucId = tmp.MucId;
                lstDutoanDoan.Add(objDuToan);
            }
            return lstDutoanDoan;
        }

        public IList<VnsDuToanDoan> TinhDuToan444(DateTime NgayTinh, VnsDoanCongTac objDoanRa)
        {
            decimal HeSoMucA = 1;
            decimal HeSoMucB = 1;
            int TongSoNuoc = 0;
            VnsDanhMucChucVu obj = VnsDanhMucChucVuDao.GetByKey("ChucVuId", objDoanRa.ChucVuTruongDoanId);
            if (obj != null)
            {
                HeSoMucA = (decimal)obj.HeSoa;
                if (HeSoMucA == 0) HeSoMucA = 1;
                HeSoMucB = (decimal)obj.HeSob;
                if (HeSoMucB == 0) HeSoMucB = 1;
            }
            //HeSoMucA= objDoanRa.c
            //Danh sach dinh muc
            IList<VnsDinhMuc> lstDinhMuc = VnsDinhMucDao.GetByNgayApDung(NgayTinh, 0, false);
            //Danh sach cac dia diem di cua doan ra
            //Get List Cong tac theo doan cong tac va nhom nuoc
            IList<VnsLichCongTac> lstLichCongTacNhom1 = VnsLichCongTacDao.GetByDoanCongTacAndNhomNuoc(objDoanRa.Id,1);
            IList<VnsLichCongTac> lstLichCongTacNhom2 = VnsLichCongTacDao.GetByDoanCongTacAndNhomNuoc(objDoanRa.Id, 2);
            IList<VnsLichCongTac> lstLichCongTacNhom3 = VnsLichCongTacDao.GetByDoanCongTacAndNhomNuoc(objDoanRa.Id, 3);

            List<VnsDuToanDoan> lstDutoanDoan = new List<VnsDuToanDoan>();
            IList<VnsDuToanDoan> lstDutoanDoan1 = new List<VnsDuToanDoan>();
            IList<VnsDuToanDoan> lstDutoanDoan2 = new List<VnsDuToanDoan>();
            IList<VnsDuToanDoan> lstDutoanDoan3 = new List<VnsDuToanDoan>();
            // Kiem tra so luong thanh vien cua moi nhom nuoc co thay doi hay ko, neu thay doi thi lap du toan rieng theo tung lich cong tac, 
            // Neu so luong thanh vien ko thay doi thi tinh tong so ngay cong tac

            if (CheckSoLuongThanhVien(lstLichCongTacNhom1)) // Neu so luong khong thay doi thi tinh tong so ngay roi tinh
            {
                lstDutoanDoan1 = TinhDuToanTheoNhomNuocVaLoaiNuoc(lstDinhMuc, lstLichCongTacNhom1, 1, HeSoMucA, HeSoMucB,objDoanRa);
            }
            else
            {
                // lap du toan theo tung lich cong tac
                lstDutoanDoan1 = TinhDuToanTheoTungLichCongTac(lstDinhMuc, lstLichCongTacNhom1, 1, HeSoMucA, HeSoMucB,objDoanRa);
            }

            if (CheckSoLuongThanhVien(lstLichCongTacNhom2)) // Neu so luong khong thay doi thi tinh tong so ngay roi tinh
            {
                lstDutoanDoan2 = TinhDuToanTheoNhomNuocVaLoaiNuoc(lstDinhMuc, lstLichCongTacNhom2, 2, HeSoMucA, HeSoMucB,objDoanRa);
            }
            else
            {
                // lap du toan theo tung lich cong tac
                lstDutoanDoan2 = TinhDuToanTheoTungLichCongTac(lstDinhMuc, lstLichCongTacNhom2, 2, HeSoMucA, HeSoMucB,objDoanRa);
            }

            if (CheckSoLuongThanhVien(lstLichCongTacNhom3)) // Neu so luong khong thay doi thi tinh tong so ngay roi tinh
            {
                lstDutoanDoan3 = TinhDuToanTheoNhomNuocVaLoaiNuoc(lstDinhMuc, lstLichCongTacNhom3, 3, HeSoMucA, HeSoMucB,objDoanRa);
            }
            else
            {
                // lap du toan theo tung lich cong tac
                lstDutoanDoan3 = TinhDuToanTheoTungLichCongTac(lstDinhMuc, lstLichCongTacNhom3, 3, HeSoMucA, HeSoMucB,objDoanRa);
            }
            if (lstDutoanDoan1.Count > 0)
                lstDutoanDoan.AddRange(lstDutoanDoan1);
            if (lstDutoanDoan2.Count > 0)
                lstDutoanDoan.AddRange(lstDutoanDoan2);
            if (lstDutoanDoan3.Count > 0)
                lstDutoanDoan.AddRange(lstDutoanDoan3);
            
            //IList<VnsDinhMuc> lstDinhMuc2 = VnsDinhMucDao.GetByNgayApDung(NgayTinh, 0, true);
            //foreach (VnsDinhMuc tmp in lstDinhMuc2)
            //{
            //    VnsDuToanDoan objDuToan = new VnsDuToanDoan();
            //    objDuToan.DienGiai = "Tạm tính";
            //    objDuToan.TenKhoanChi = tmp.DienGiai;
            //    objDuToan.SoTienDuToan = 0;
            //    objDuToan.CongTacId = objDoanRa.Id;
            //    objDuToan.MucId = tmp.MucId;
            //    lstDutoanDoan.Add(objDuToan);
            //}
            return lstDutoanDoan;
        }

        private IList<VnsDuToanDoan> TinhDuToanTheoNhomNuocVaLoaiNuoc(IList<VnsDinhMuc> lstDinhMuc,IList<VnsLichCongTac> lstLichCongTac, int LoaiNuoc, decimal HeSoA, decimal HeSoB, VnsDoanCongTac DoanRa)
        {   
            IList<VnsDuToanDoan> lstDuToanDoanTmp = new List<VnsDuToanDoan>();
            int l1 = 0;
            int l2 = 0;
            int l3 = 0;

            List<DemNuoc> lstdem = new List<DemNuoc>();
            int SoLuongThanhVienA = 0;
            int SoLuongThanhVienB = 0;
            IList<VnsThanhVien> lstThanhVienTemp = VnsThanhVienDao.GetThanhVienByLichCongTacDoanRa(lstLichCongTac[0].Id, lstLichCongTac[0].CongTacId);
            foreach (VnsThanhVien objTV in lstThanhVienTemp)
            {
                if (objTV.PhanLoai == 1)
                    SoLuongThanhVienA = objTV.SoLuong;
                if (objTV.PhanLoai == 2)
                    SoLuongThanhVienB = objTV.SoLuong;
            }
            DemNuoc nuoc = new DemNuoc();
            nuoc.LoaiNuoc = LoaiNuoc;
            nuoc.SoNgay = 0;
            nuoc.SoNuoc = 0;
            nuoc.SoNguoiC = l3;
            foreach (VnsLichCongTac tmp in lstLichCongTac)
            {
                nuoc.TongSoNuoc = lstLichCongTac.Count;
                
                if (tmp.NgayCongTac == 0)
                {
                    TimeSpan songay = tmp.NgayVe - tmp.NgayDi;
                    nuoc.SoNgay += songay.Days;
                }
                else
                    nuoc.SoNgay += tmp.NgayCongTac;


            }
            nuoc.SoNuoc = lstLichCongTac.Count;
            nuoc.SoNguoiA = SoLuongThanhVienA;
            nuoc.SoNguoiB = SoLuongThanhVienB;
            lstdem.Add(nuoc);
            foreach (VnsDinhMuc tmp in lstDinhMuc)
            {
                if (tmp.Muc.MaMuc != "6802")
                {
                    foreach (DemNuoc objNuoc in lstdem)
                    {  
                        VnsDuToanDoan dtMucA = objNuoc.GenDinhMuc1(tmp, 1, 1);
                        if (dtMucA != null)
                        {
                            dtMucA.CongTacId = DoanRa.Id;
                            lstDuToanDoanTmp.Add(dtMucA);
                        }
                    }
                }
                else
                {
                    foreach (DemNuoc objNuoc in lstdem)
                    {
                        if(tmp.Muc.MaMuc=="6803")
                            objNuoc.SoNgay = LamTronNgay(tmp.Muc.MaMuc, objNuoc.SoNgay);
                        VnsDuToanDoan dtMucA = objNuoc.GenDinhMuc1(tmp, HeSoA, HeSoB);                        
                        if (dtMucA != null)
                        {
                            //dtMucA.CongTacId = lstLichCongTac[0].CongTacId;
                            dtMucA.CongTacId = DoanRa.Id;
                            lstDuToanDoanTmp.Add(dtMucA);
                        }
                    }
                }
            }
            return lstDuToanDoanTmp;
        }

        private IList<VnsDuToanDoan> TinhDuToanTheoTungLichCongTac(IList<VnsDinhMuc> lstDinhMuc, IList<VnsLichCongTac> lstLichCongTac, int LoaiNuoc, decimal HeSoA, decimal HeSoB, VnsDoanCongTac DoanRa)
        {
            IList<VnsDuToanDoan> lstDuToanDoanTmp = new List<VnsDuToanDoan>();

            foreach (VnsLichCongTac tmp in lstLichCongTac)
            {
                int SoLuongThanhVienA = 0;
                int SoLuongThanhVienB = 0;
                IList<VnsThanhVien> lstThanhVienTemp = VnsThanhVienDao.GetThanhVienByLichCongTacDoanRa(lstLichCongTac[0].Id, lstLichCongTac[0].CongTacId);
                foreach (VnsThanhVien objTV in lstThanhVienTemp)
                {
                    if (objTV.PhanLoai == 1)
                        SoLuongThanhVienA = objTV.SoLuong;
                    if (objTV.PhanLoai == 2)
                        SoLuongThanhVienB = objTV.SoLuong;
                }
                DemNuoc nuoc = new DemNuoc();
                nuoc.LoaiNuoc = LoaiNuoc;
                nuoc.SoNgay = 0;
                nuoc.SoNuoc = 0;
                nuoc.SoNguoiC = 0;
                nuoc.TongSoNuoc = lstLichCongTac.Count;

                if (tmp.NgayCongTac == 0)
                {
                    TimeSpan songay = tmp.NgayVe - tmp.NgayDi;
                    nuoc.SoNgay += songay.Days;
                }
                else
                    nuoc.SoNgay += tmp.NgayCongTac;

                nuoc.SoNuoc = 1;
                nuoc.SoNguoiA = SoLuongThanhVienA;
                nuoc.SoNguoiB = SoLuongThanhVienB;

                foreach (VnsDinhMuc tmpDM in lstDinhMuc)
                {
                    if (tmpDM.Muc.MaMuc != "6802")
                    {
                        VnsDuToanDoan dtMucA = nuoc.GenDinhMuc1(tmpDM, 1, 1);
                        if (dtMucA != null)
                        {
                            dtMucA.CongTacId = DoanRa.Id;
                            lstDuToanDoanTmp.Add(dtMucA);
                        }
                    }
                    else
                    {
                        VnsDuToanDoan dtMucA = nuoc.GenDinhMuc1(tmpDM, HeSoA, HeSoB);
                        if (dtMucA != null)
                        {
                            dtMucA.CongTacId = DoanRa.Id;
                            //dtMucA.CongTacId = lstLichCongTac[0].CongTacId;
                            lstDuToanDoanTmp.Add(dtMucA);
                        }
                    }
                }
            }

            return lstDuToanDoanTmp;
        }
        private bool CheckSoLuongThanhVien(IList<VnsLichCongTac> lstLichCongTac)
        {
            bool tmp = true;
            if (lstLichCongTac.Count >= 2)
            {
                for (int i = 0; i < lstLichCongTac.Count - 1; i++)
                {
                    VnsLichCongTac temp1 = lstLichCongTac[i];
                    VnsLichCongTac temp2 = lstLichCongTac[i + 1];
                    IList<VnsThanhVien> lstThanhVienTemp1A = VnsThanhVienDao.GetThanhVienByLichCongTacDoanRa(temp1.Id, temp1.CongTacId, 1);
                    IList<VnsThanhVien> lstThanhVienTemp1B = VnsThanhVienDao.GetThanhVienByLichCongTacDoanRa(temp1.Id, temp1.CongTacId, 2);

                    IList<VnsThanhVien> lstThanhVienTemp2A = VnsThanhVienDao.GetThanhVienByLichCongTacDoanRa(temp2.Id, temp2.CongTacId, 1);
                    IList<VnsThanhVien> lstThanhVienTemp2B = VnsThanhVienDao.GetThanhVienByLichCongTacDoanRa(temp2.Id, temp2.CongTacId, 2);

                    if ((lstThanhVienTemp1A[0].SoLuong == lstThanhVienTemp2A[0].SoLuong) && (lstThanhVienTemp1B[0].SoLuong == lstThanhVienTemp2B[0].SoLuong))
                        tmp = true;
                    else
                        tmp = false;
                }
            }
            else
                tmp = false;
            return tmp;
        }

        private decimal LamTronNgay(string strMaMuc, decimal SoNgay)
        {
            switch (strMaMuc)
            {
                case "6803":
                    return Math.Round(SoNgay, MidpointRounding.ToEven);
                default:
                    return SoNgay;

            }

        }
        public IList<VnsDuToanDoan> GetByDoanCongTac(Guid CongTacId)
        {
            return VnsDuToanDoanDao.GetByDoanCongTac(CongTacId);
        }

        public IList<VnsInQtTu> GetDataInDt(Guid CongTacId)
        {
            return VnsDuToanDoanDao.GetDataInDt(CongTacId);
        }

        public IList<BC03DR> ListChuaQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRa)
        {
            return VnsDuToanDoanDao.ListChuaQuyetToan(p_TuNgay, p_DenNgay,p_LoaiDoanRa);
        }

        public IList<VnsDuToanDoan> GetByDoanCongTac(Guid CongTacId, int LanCongTac)
        {
            return VnsDuToanDoanDao.GetByDoanCongTac(CongTacId, LanCongTac);
        }

        public void DeleteByDoanCongTac(Guid CongTacId, int LanDuToan)
        {
            VnsDuToanDoanDao.DeleteByDoanCongTac(CongTacId, LanDuToan);
        }
    }

    public class DemNuoc
    {
        public decimal SoNgay;
        public int LoaiNuoc;
        public int SoNuoc;
        public int SoNguoiA;
        public int SoNguoiB;
        public int SoNguoiC;
        public int TongSoNuoc;
        public int SoNguoi
        {
            get { return SoNguoiA + SoNguoiB; }
        }
        public VnsDuToanDoan GenDinhMucByParam(VnsDinhMuc objDinhMuc, decimal HeSoA, decimal HeSoB, bool typeDinhMuc)
        {
            VnsDuToanDoan tmpDuToanDoan = new VnsDuToanDoan();

            return tmpDuToanDoan;
        }

        public VnsDuToanDoan GenDinhMuc1(VnsDinhMuc objDinhMuc, decimal HeSoA, decimal HeSoB)
        {
            if (SoNuoc == 0) return null;
            if (LoaiNuoc != objDinhMuc.NhomNuoc && objDinhMuc.NhomNuoc > 0) return null;

            VnsDuToanDoan tmpDuToanDoan = new VnsDuToanDoan();

            String MoTaCachTinh = "";
            switch (objDinhMuc.CachTinh)
            {
                case 1: //Tinh theo ngay
                    tmpDuToanDoan.SoTienDuToan = objDinhMuc.DinhMuc * SoNgay;
                    MoTaCachTinh = objDinhMuc.DinhMuc.ToString() + " USD x "+ SoNgay.ToString() + " ngày";//+", Nhóm nước "+ LoaiNuoc.ToString();;                    
                    break;
                case 2: //Tinh theo nuoc
                    if (objDinhMuc.LoaiCapVu == 0 && objDinhMuc.NhomNuoc == 0)// tien dien thoai
                    {
                        tmpDuToanDoan.SoTienDuToan = objDinhMuc.DinhMuc;
                        MoTaCachTinh = "Cả đoàn";
                    }
                    else
                    {
                        tmpDuToanDoan.SoTienDuToan = objDinhMuc.DinhMuc * SoNuoc;
                        MoTaCachTinh = objDinhMuc.DinhMuc.ToString() + " USD x " + SoNuoc.ToString() + " nước";//+", Nhóm nước "+ LoaiNuoc.ToString();;
                    }
                    
                    break;
            }

            String MoTaCapVu = "";
            switch (objDinhMuc.LoaiCapVu)
            {
                case 0: //Tat ca
                    if (objDinhMuc.NhomNuoc != 0)
                    {
                        tmpDuToanDoan.SoTienDuToan = tmpDuToanDoan.SoTienDuToan * SoNguoi;

                        MoTaCapVu = SoNguoi.ToString() + " người x ";
                    }
                    break;
                case 1: //Muc A
                    tmpDuToanDoan.SoTienDuToan = tmpDuToanDoan.SoTienDuToan * SoNguoiA * HeSoA;
                    MoTaCapVu = SoNguoiA.ToString() + " A x ";
                    if (HeSoA > 1)
                        MoTaCachTinh += " x " + HeSoA.ToString();
                    // +", Nhóm nước "+ LoaiNuoc.ToString();;
                    break;
                case 2: //Muc B
                    tmpDuToanDoan.SoTienDuToan = tmpDuToanDoan.SoTienDuToan * SoNguoiB * HeSoB;
                    MoTaCapVu = SoNguoiB.ToString() + " B x ";//+", Nhóm nước "+ LoaiNuoc.ToString();;
                    if (HeSoB > 1)
                        MoTaCachTinh += " x "+HeSoB.ToString();
                    break;
            }

            tmpDuToanDoan.DienGiai = MoTaCapVu+ MoTaCachTinh;
            //tmpDuToanDoan.SoTienDuToan = tmpDuToanDoan.SoTienDuToan * objDinhMuc.DinhMuc;

            //switch (objDinhMuc.CachTinh)
            //{
            //    case 1:
            //        //Tinh theo ngay
            //        tmpDuToanDoan.SoTienDuToan = objDinhMuc.DinhMuc * SoNgay * SoNguoiA;
            //        tmpDuToanDoan.DienGiai = SoNguoiA + " A x " + objDinhMuc.DinhMuc + " USD " + SoNgay + " ngày - Nước " + LoaiNuoc;
            //        break;
            //    case 2:
            //        //Tinh theo nuoc
            //        tmpDuToanDoan.SoTienDuToan = objDinhMuc.DinhMuc * SoNuoc * SoNguoiA;
            //        tmpDuToanDoan.DienGiai = SoNguoiA + " A x " + objDinhMuc.DinhMuc + " USD " + SoNuoc + " nước - Nước " + LoaiNuoc;
            //        break;
            //}
            tmpDuToanDoan.MucId = objDinhMuc.MucId;
            
            //tmpDuToanDoan.TenMuc = objDinhMuc.TenMuc;
            tmpDuToanDoan.TenKhoanChi = objDinhMuc.DienGiai;

            if (tmpDuToanDoan.SoTienDuToan == 0)
            {
              //  return null;
                //tmpDuToanDoan.DienGiai = TongSoNuoc.ToString() + " nước " + (SoNguoiA + SoNguoiB).ToString() + " người";
                tmpDuToanDoan.DienGiai = "Tạm tính";// Dung Sua 22/12
            }
            return tmpDuToanDoan;
        }

    }
}
