/*
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
    //,IVnsGiaoDichService
    public class VnsGiaoDichService : GenericService<VnsGiaoDich, Guid>, IVnsGiaoDichService
    {
        public IVnsChungTuDao VnsChungTuDao;
        public IVnsDoanCongTacDao VnsDoanCongTacDao;
        public IVnsDmQuocGiaDao VnsDmQuocGiaDao;
        public IVnsLoaiDoanRaDao VnsLoaiDoanRaDao;
        public IVnsDmMucTieuMucDao VnsDmMucTieuMucDao;
        public IVnsDuToanDoanDao VnsDuToanDoanDao; 
        public IRP_BC04DRDao RP_BC04DRDao;
        public IReportDao ReportDao;
        public IVnsDanhMucChucVuDao VnsDanhMucChucVuDao;
        public IVnsGiaoDichDao VnsGiaoDichDao
        {
            get { return (IVnsGiaoDichDao)Dao; }
            set { Dao = value; }
        }

        public IList<VnsGiaoDich> GetByChungTu(Guid ChungTuId)
        {
            return VnsGiaoDichDao.GetByChungTu(ChungTuId);
        }
       
        public Boolean DeleteByChungTu(Guid ChungTuId)
        {
            return VnsGiaoDichDao.DeleteByChungTu(ChungTuId);
        }

        public IList<VnsGiaoDich> GetByDoanRaNoId(Guid DoanRaNoId)
        {
            return VnsGiaoDichDao.GetByDoanRaNoId(DoanRaNoId);
        }
        public IList<VnsGiaoDich> GetByDoanRaCoId(Guid DoanRaCoId)
        {
            return VnsGiaoDichDao.GetByDoanRaCoId(DoanRaCoId);
        }

        public IList<VnsGiaoDich> GetByMaTKNo(String strMaTKNo)
        {
            return VnsGiaoDichDao.GetByMaTKNo(strMaTKNo);
        }
        public IList<VnsGiaoDich> GetByMaTKCo(string strMaTKCo)
        {
            return VnsGiaoDichDao.GetByMaTKCo(strMaTKCo);
        }

        public IList<VnsGiaoDich> GetTUByDoanRaId(Guid p_DoanRaId)
        {
            return VnsGiaoDichDao.GetTUByDoanRaId(p_DoanRaId);
        }

        public IList<decimal> GetSoDuNo(string MaTKNo, string MaTKCo, Guid guidDoanRaNoId, Guid guidDoanRaCoId, DateTime NgayChungTu)
        {
            // get all ChungTu <= ngay chung tu
            //Get all giao dich theo MaTKNo, MaTKCo, DoanRaNo, DoanRaCo
            // SoSanh neu chungtuId = giaodich.ChungTuId thi cong tat ca so tien tai khoan co, so tien tai khoan no
            // lay hieu TKCo - TKNo
            // return hieu            
            IList<VnsChungTu>lstChungTu= VnsChungTuDao.ListChungTuDenNgay(NgayChungTu);
            IList<VnsGiaoDich> lstGiaoDichDoanRaTKNo = new List<VnsGiaoDich>();
            IList<VnsGiaoDich> lstGiaoDichDoanRaTKCo = new List<VnsGiaoDich>();
            IList<VnsGiaoDich> lstGiaoDichCoId = new List<VnsGiaoDich>();
            IList<VnsGiaoDich> lstGiaoDichNoId = new List<VnsGiaoDich>();
            decimal TongNo = 0;
            decimal TongCo = 0;
            decimal SoDuNo = 0;
            decimal TongNoNgoaiTe = 0;
            decimal TongCoNgoaiTe = 0;
            decimal SoDuNoNgoaiTe = 0;
            IList<decimal> lstKetQua = new List<decimal>();
            if (MaTKNo != string.Empty)
            {
                lstGiaoDichDoanRaTKNo = GetByMaTKNo(MaTKNo);
            }
            if (MaTKCo != string.Empty)
            {
                lstGiaoDichDoanRaTKCo = GetByMaTKCo(MaTKCo);
            }
            if (guidDoanRaCoId != new Guid())
            {
                lstGiaoDichCoId = GetByDoanRaCoId(guidDoanRaCoId);
            }
            if (guidDoanRaNoId != new Guid())
            {
                lstGiaoDichNoId = GetByDoanRaNoId(guidDoanRaNoId);
            }
            foreach (VnsChungTu objChungTu in lstChungTu)
            {
                foreach (VnsGiaoDich objCo in lstGiaoDichCoId)
                {
                    if (objCo.ChungTuId == objChungTu.Id)
                    {
                        TongCo += objCo.SoTien;
                        TongCoNgoaiTe += objCo.SoTienNt;
                    }
                }
                foreach (VnsGiaoDich objNo in lstGiaoDichNoId)
                {
                    if (objNo.ChungTuId == objChungTu.Id)
                    {
                        TongNo += objNo.SoTien;
                        TongNoNgoaiTe += objNo.SoTienNt;
                    }
                }
            }
            SoDuNo = TongCo - TongNo;
            SoDuNoNgoaiTe = TongCoNgoaiTe - TongNoNgoaiTe;
            lstKetQua.Add(SoDuNo);
            lstKetQua.Add(SoDuNoNgoaiTe);
            return lstKetQua;
        }

        public IList<VnsGiaoDich> ListGiaoDichTuNgayDenNgay(DateTime dTuNgay, DateTime dDenNgay, string MaLoaiChungTu)
        {
            IList<VnsGiaoDich> lstReturn = new List<VnsGiaoDich>();
            IList<VnsChungTu> lstChungTu = VnsChungTuDao.ListChungTuTuNgayDenNgay(dTuNgay, dDenNgay, MaLoaiChungTu);
            foreach (VnsChungTu objChungTu in lstChungTu)
            {

                IList<VnsGiaoDich> lstGD = this.VnsGiaoDichDao.GetByChungTu(objChungTu.Id);
                foreach (VnsGiaoDich objtemp in lstGD)
                    lstReturn.Add(objtemp);
            }

            return lstReturn;
        }

        public IList<ViewQuyetToan> ListViewQuyetToan(DateTime dTuNgay, DateTime dDenNgay, Guid LoaiDoanRaId)
        {
            IList<ViewQuyetToan> lstReturn = new List<ViewQuyetToan>();
            IList<VnsGiaoDich> lstGiaoDichQT = new List<VnsGiaoDich>();
            IList<VnsDoanCongTac> lstDoanCongtac = VnsDoanCongTacDao.GetByLoaiDoanRa(LoaiDoanRaId) ; //ListDoanCongTacTuNgayDenNgay(dTuNgay, dDenNgay);
             foreach (VnsDoanCongTac objDCT in lstDoanCongtac)
             {
                 ViewQuyetToan view = new ViewQuyetToan();
                 view.TenDoan = objDCT.Ten;
                 view.TenDoanVietTat = objDCT.TenVietTat;
                 VnsLoaiDoanRa objLoaiDoanRa = VnsLoaiDoanRaDao.GetByKey("Id", objDCT.LoaiDoanRaId);
                 if (objLoaiDoanRa != null)
                     view.NguonKinhPhi = objDCT.TenLoaiDoanRa;
                 string strNuocCongTac = "";
                 VnsDanhMucChucVu objChucVu = VnsDanhMucChucVuDao.GetByKey("ChucVuId",objDCT.ChucVuTruongDoanId);
                 if (objChucVu != null)
                     view.TruongDoan = objDCT.TenTruongDoan;
                 foreach (VnsLichCongTac objLichCT in objDCT.DanhSachLichCongTac)
                 {
                     VnsDmQuocGia objQG = VnsDmQuocGiaDao.GetByKey("Id", objLichCT.NuocId);
                     if (objQG != null)
                     {
                         if (strNuocCongTac == "")
                         {
                             strNuocCongTac = objQG.TenNuoc;
                         }
                        else
                         {
                            strNuocCongTac += ", " + objQG.TenNuoc ;
                         }
                     }
                 }
                 if (strNuocCongTac != string.Empty)
                 {
                     view.CongTacTaiNuoc = strNuocCongTac;
                 }
                 // Get So Tien Quyet Toan Theo Doan Cong Tac  TkThanhToanTienMat
                 decimal TienQuyetToan = 0;
                 IList<VnsGiaoDich> lstQuyetToan = ReportDao.GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(),new Guid(), (Guid)objDCT.Id, (Guid)objDCT.Id, Globals.LikeTkQt, Globals.TkTamUng, 0, 2);
                     //GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(), Globals.LikeTkQt, Globals.TkTamUng, 0, 2);
                     //RP_BC04DRDao.GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(), new Guid(), (Guid)objDCT.Id, (Guid)objDCT.Id,Globals.TkThanhToanTienMat , Globals.TkTamUng, "QT");
                 foreach (VnsGiaoDich objQT in lstQuyetToan)
                 {
                     TienQuyetToan += objQT.SoTienNt;
                 }
                 // Get Hoan Ung theo doan cong tac
                 IList<VnsGiaoDich> lstTU = ReportDao.GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(), new Guid(), (Guid)objDCT.Id, (Guid)objDCT.Id, Globals.TkTamUng, Globals.TkTienLike, 0, 0);
                     //RP_BC04DRDao.GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(), new Guid(), new Guid(), (Guid)objDCT.Id, string.Empty, string.Empty, "TU");
                 decimal TienMatVND = 0;
                 decimal TienMatUSD = 0;
                 decimal TyGiaTienMat = 0;

                 decimal ChuyenKhoanVND = 0;
                 decimal ChuyenKhoanUSD = 0;
                 decimal TyGiaChuyenKhoan = 0;
                 view.TienQuyetToan = TienQuyetToan;
                 foreach (VnsGiaoDich objTU in lstTU)
                 {
                     if (objTU.MaTkCo.StartsWith(Globals.TkTienMat))
                     {
                         TienMatVND += objTU.SoTien;
                         TienMatUSD += objTU.SoTienNt;
                         TyGiaTienMat = objTU.TyGia;
                     }
                     if (objTU.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan))
                     {
                         ChuyenKhoanVND += objTU.SoTien;
                         ChuyenKhoanUSD += objTU.SoTienNt;
                         TyGiaChuyenKhoan = objTU.TyGia;
                     }
                 }
                 view.TienMatVND = TienMatVND;
                 view.TienMatUSD = TienMatUSD;
                 view.TyGiaTienMat = TyGiaTienMat;
                 view.ChuyenKhoanVND = ChuyenKhoanVND;
                 view.ChuyenKhoanUSD = ChuyenKhoanUSD;
                 view.TyGiaChuyenKhoan = TyGiaChuyenKhoan;

                 view.TongSoVND = TienMatVND + ChuyenKhoanVND;
                 view.TongUSD = TienMatUSD + ChuyenKhoanUSD;

                 lstReturn.Add(view);
                 #region comment
                 ////////////////////////////////////////
                 //IList<VnsChungTu> lstChungTu = VnsChungTuDao.ListChungTuTuNgayDenNgay(dTuNgay, dDenNgay, "TU");            

                 //foreach (VnsChungTu objChungTu in lstChungTu)
                 //{
                 //    IList<VnsGiaoDich> lstGD = this.VnsGiaoDichDao.GetByChungTu(objChungTu.Id);
                 //    foreach (VnsGiaoDich objtemp in lstGD)
                 //        lstGiaoDichQT.Add(objtemp);
                 //}
                 ////List All giao dich tam ung
                 //foreach (VnsGiaoDich objGDich in lstGiaoDichQT)
                 //{
                 //    ViewQuyetToan view = new ViewQuyetToan();                
                 //    VnsDoanCongTac objDoanCongTac = VnsDoanCongTacDao.GetByKey("Id", objGDich.DoanRaCoId);


                 //    #region
                 //    decimal TongTienQT = 0;
                 //    if (objDoanCongTac != null)
                 //    {
                 //        //Get Tong So Tien da dc quyet toan cua Doan Ra
                 //        IList Props = new ArrayList();
                 //        IList Values = new ArrayList();
                 //        Props.Add("DoanRaCoId");
                 //        Values.Add(objDoanCongTac.Id);
                 //        IList<VnsGiaoDich> lstGDQuyetToanDoan = VnsGiaoDichDao.List(-1, -1, Props, Values, null);

                 //        foreach (VnsGiaoDich objTemGD in lstGDQuyetToanDoan)
                 //        {
                 //            TongTienQT = objTemGD.SoTienNt;
                 //        }
                 //        view.TenDoan = objDoanCongTac.Ten;
                 //        view.TruongDoan = objDoanCongTac.TruongDoan;
                 //        string strNuocCongTac = "";

                 //        foreach (VnsLichCongTac objLichCT in objDoanCongTac.DanhSachLichCongTac)
                 //        {
                 //            VnsDmQuocGia objQG = VnsDmQuocGiaDao.GetByKey("Id",objLichCT.NuocId);
                 //            if (objQG != null)
                 //                strNuocCongTac += objQG.TenNuoc + " ,";
                 //        }
                 //        if (strNuocCongTac != string.Empty)
                 //        {
                 //            view.CongTacTaiNuoc = strNuocCongTac;
                 //        }

                 //        VnsLoaiDoanRa objLoaiDoanRa = VnsLoaiDoanRaDao.GetByKey("Id", objDoanCongTac.LoaiDoanRaId);
                 //        if (objLoaiDoanRa != null)
                 //            view.NguonKinhPhi = objLoaiDoanRa.TenLoaiDoanRa;
                 //    }
                 //    VnsChungTu objChungTu = VnsChungTuDao.GetByKey("Id",objGDich.ChungTuId);
                 //    if (objChungTu != null)
                 //    {   
                 //        view.NguoiThanhToan = objChungTu.NguoiGiaoDich;                   
                 //    }

                 //    if (objGDich.MaTkCo.StartsWith(Globals.TkTienMat))
                 //    {
                 //        view.TienMatVND = objGDich.SoTien;
                 //        view.TienMatUSD = objGDich.SoTienNt;
                 //        view.TyGiaTienMat = objGDich.TyGia;
                 //    }
                 //    if (objGDich.MaTkCo.StartsWith( Globals.TkTienChuyenKhoan))
                 //    {
                 //        view.ChuyenKhoanVND  = objGDich.SoTien;
                 //        view.ChuyenKhoanUSD = objGDich.SoTienNt;
                 //        view.TyGiaChuyenKhoan = objGDich.TyGia;

                 //    }
                 //    view.TongSoVND = objGDich.SoTien;
                 //    view.ThoiGianDuyetDuToan = dTuNgay.Month.ToString() + "/" + dTuNgay.Month.ToString();

                 //    view.TongUSD = objGDich.SoTienNt;
                 //    view.TienQuyetToan = TongTienQT;//Get Du Toan 

                 //    #endregion
                 //    lstReturn.Add(view);
                 //}
#endregion comment
             }
            return lstReturn;
        }

        public IList<ViewTamUngDoanRa> ListViewTamUng(DateTime dTuNgay, DateTime dDenNgay)
        {
            List<ViewTamUngDoanRa> lstTamUng = new List<ViewTamUngDoanRa>();
          
            IList<VnsGiaoDich> lstGiaoDich = ReportDao.GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(),new Guid(),new Guid(), new Guid(), Globals.TkTamUng, Globals.TkTienLike, 0, 0);
            foreach (VnsGiaoDich objGDich in lstGiaoDich)
            {
                ViewTamUngDoanRa view = new ViewTamUngDoanRa();

                view.GiaoDichId = objGDich.GiaoDichId;

                VnsDoanCongTac objDoanCongTac = VnsDoanCongTacDao.GetByKey("Id",objGDich.DoanRaCoId);
                decimal dDuToanDoan = 0; decimal dDuToanDoanVND = 0;
                IList<VnsDuToanDoan> lstDuToan = new List<VnsDuToanDoan>();
                if (objDoanCongTac != null)
                {
                    view.DoanRaId = objDoanCongTac.Id;
                    view.TenDoan = objDoanCongTac.Ten; //
                    view.TenDoanVietTat = objDoanCongTac.TenVietTat;
                    view.TruongDoan = objDoanCongTac.TenTruongDoan;
                    view.SoTBDuToan = objDoanCongTac.SoThongBaoDuToan;
                    //view.ThoiGianDuyetDuToan = objDoanCongTac.S
                    //view.ThoiGianDuyetDuToan = objDoanCongTac.NgayDi.Day.ToString() + "/" + objDoanCongTac.NgayDi.Month.ToString() + "-" + objDoanCongTac.NgayVe.ToString("dd/MM/yyyy");

                    string strNuocCongTac = "";
                    lstDuToan = VnsDuToanDoanDao.GetByDoanCongTac(objDoanCongTac.Id);
                    foreach (VnsLichCongTac objLichCT in objDoanCongTac.DanhSachLichCongTac)
                    {
                        VnsDmQuocGia objQG = VnsDmQuocGiaDao.GetByKey("Id",objLichCT.NuocId);
                        if (objQG != null)
                        {
                            if (strNuocCongTac == "")
                            {
                                strNuocCongTac = objQG.TenNuoc;
                            }
                            else
                            {
                                strNuocCongTac += ", " + objQG.TenNuoc;
                            }
                        }
                    }
                    if (strNuocCongTac != string.Empty)
                    {
                        view.CongTacTaiNuoc = strNuocCongTac;
                    }
                    VnsLoaiDoanRa objLoaiDoanRa = this.VnsLoaiDoanRaDao.GetByKey("Id", objDoanCongTac.LoaiDoanRaId);
                    if (objLoaiDoanRa != null)
                    {
                        view.MaNguonKinhPhi = objLoaiDoanRa.MaLoaiDoanRa;
                        view.NguonKinhPhi = objLoaiDoanRa.TenLoaiDoanRa;
                    }
                }
               
                VnsChungTu objChungTu = this.VnsChungTuDao.GetByKey("Id",objGDich.ChungTuId);
                if (objChungTu != null)
                {
                    view.PhieuChiSo = "";
                    view.NguoiTamUngTien = objChungTu.NguoiGiaoDichVietTat;//.NguoiGiaoDich;
                    view.NgayCt = objChungTu.NgayCt;
                }
                //view.SoTBDuToan = objDoanCongTac.SoTbDuToan;
                if (objGDich.MaTkCo == Globals.TkTienMat)
                {
                    view.PhieuChiSo = objChungTu.SoCt;
                    view.TienMatVND = objGDich.SoTien;
                    view.TienMatUSD = objGDich.SoTienNt;
                    view.TyGiaTienMat = objGDich.TyGia;
                }
                if (objGDich.MaTkCo == Globals.TkTienChuyenKhoanVND)
                {
                    view.UNCSo = objChungTu.SoCt;
                    view.ChuyenKhoanVND = objGDich.SoTien;
                    view.ChuyenKhoanUSD = objGDich.SoTienNt;
                    view.TyGiaChuyenKhoan = objGDich.TyGia;
                }

                if (objGDich.MaTkCo == Globals.TkTienMatVND)
                {
                    view.TienTamUngVND = objGDich.SoTien;
                }

                view.TongSoVND = objGDich.SoTien;
                view.TongUSD = objGDich.SoTienNt;
                //view.ThoiGianDuyetDuToan = dTuNgay.Month.ToString() + "/" + dDenNgay.Month.ToString();

                foreach (VnsDuToanDoan objDuToan in lstDuToan)
                {
                    if (objDuToan.NgoaiTeId == Globals.NgoaiTeId)
                        dDuToanDoan += objDuToan.SoTienDuToan;
                    else if (objDuToan.NgoaiTeId == Globals.NoiTeId)
                        dDuToanDoanVND += objDuToan.SoTienDuToanVND;

                    view.ThoiGianDuyetDuToan = (objDuToan.NgayDuToan.Month.ToString() + "/" + objDuToan.NgayDuToan.Year.ToString());

                }
                view.DuToanDuocDuyet = dDuToanDoan;//Get Du Toan
                view.DuToanDuocDuyetVND = dDuToanDoanVND;
                
                lstTamUng.Add(view);
            }
            lstTamUng.Sort(CompareReport);
            return lstTamUng;
        }

        public IList<ViewQuyetToan> listHoanThuQuyetToan(DateTime dTuNgay, DateTime dDenNgay, Guid LoaiDoanRaId)
        {
            IList<ViewQuyetToan> lstReturn = new List<ViewQuyetToan>();
            IList<VnsDoanCongTac> lstDoanCongtac;
            IList props = new ArrayList();
            IList values = new ArrayList();
            IList expressions = new ArrayList();
            if (LoaiDoanRaId != new Guid())
            {
                props.Add("LoaiDoanRaId");

                values.Add(LoaiDoanRaId);
                expressions.Add("=");
                //lstDoanCongtac = VnsDoanCongTacDao.GetAll(); //ListDoanCongTacTuNgayDenNgay(dTuNgay, dDenNgay);
            }
            props.Add("TrangThai"); // list doan da quyet toan
            values.Add(2);
            expressions.Add("=");
            lstDoanCongtac = VnsDoanCongTacDao.List(-1, -1, props, values, expressions, null);
            foreach (VnsDoanCongTac objDCT in lstDoanCongtac)
            {
                ViewQuyetToan view = new ViewQuyetToan();
                view.CoPhatSinh = 0;
                view.TenDoan = objDCT.Ten;
                view.TenDoanVietTat = objDCT.TenVietTat;
                view.ThoiGianDuyetDuToan = objDCT.NgayDi.Day.ToString() + "/" + objDCT.NgayDi.Month.ToString() + "-" + objDCT.NgayVe.ToShortDateString();
                VnsLoaiDoanRa objLoaiDoanRa = VnsLoaiDoanRaDao.GetByKey("Id", objDCT.LoaiDoanRaId);
                if (objLoaiDoanRa != null)
                    view.NguonKinhPhi = objDCT.TenLoaiDoanRa;
                VnsDanhMucChucVu objChucVu = VnsDanhMucChucVuDao.GetByKey("ChucVuId", objDCT.ChucVuTruongDoanId);
                if (objChucVu != null)
                    view.TruongDoan = objDCT.TenTruongDoan;
                string strNuocCongTac = "";
                int SoNguoiDi = 0;
                dTuNgay = objDCT.NgayDi; // Lay tu dau ngay di cua doan cong tac
                foreach (VnsLichCongTac objLichCT in objDCT.DanhSachLichCongTac)
                {
                    VnsDmQuocGia objQG = VnsDmQuocGiaDao.GetByKey("Id", objLichCT.NuocId);
                    if (objQG != null)
                    {
                        if (strNuocCongTac == "")
                        {
                            strNuocCongTac = objQG.TenNuoc;
                        }
                        else
                        {
                            strNuocCongTac += ", " + objQG.TenNuoc;
                        }
                    }
                }
                if (strNuocCongTac != string.Empty)
                {
                    view.CongTacTaiNuoc = strNuocCongTac;
                }
                view.SoNguoiDi = SoNguoiDi.ToString();
                view.SoTBQuyetToan = "";
                // Get So Tien Quyet Toan Theo Doan Cong Tac  TkThanhToanTienMat
                decimal TienQuyetToan = 0;
                decimal TienQuyetToanVND = 0;
                IList<VnsGiaoDich> lstQuyetToan = ReportDao.GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(), new Guid(), (Guid)objDCT.Id, (Guid)objDCT.Id, Globals.LikeTkQt, Globals.TkTamUng, 0, 2);
                //RP_BC04DRDao.GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(), new Guid(), (Guid)objDCT.Id, (Guid)objDCT.Id, Globals.TkThanhToanTienMat, Globals.TkTamUng, "QT");
                foreach (VnsGiaoDich objQT in lstQuyetToan)
                {
                    TienQuyetToan += objQT.SoTienNt;
                    TienQuyetToanVND += objQT.SoTien;
                }
                view.TienQuyetToan = TienQuyetToan;
                view.NguoiThanhToan = "";
                // Get Tam Ung Doan Ra
                decimal TU_TienMatVND = 0;
                decimal TU_TienMatUSD = 0;
                decimal TU_TyGiaTienMat = 0;

                decimal TU_ChuyenKhoanVND = 0;
                decimal TU_ChuyenKhoanUSD = 0;
                decimal TU_TyGiaChuyenKhoan = 0;
                //decimal TamUngTienMat = 0;
                //decimal TamUngChuyenKhoan = 0;
                IList<VnsGiaoDich> lstTamUng = ReportDao.GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(), new Guid(), (Guid)objDCT.Id, (Guid)objDCT.Id, Globals.TkTamUng, Globals.TkTienLike, 0, 0);
                foreach (VnsGiaoDich objTU in lstTamUng)
                {
                    if (objTU.MaTkCo.StartsWith(Globals.TkTienMat) && objTU.MaTkNo.StartsWith(Globals.TkTamUng))
                    {
                        TU_TienMatUSD += objTU.SoTienNt;
                        TU_TienMatVND += objTU.SoTien;
                        TU_TyGiaTienMat = objTU.TyGia;
                        view.CoPhatSinh = 1;
                    }
                    if (objTU.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan) && objTU.MaTkNo.StartsWith(Globals.TkTamUng))
                    {
                        TU_ChuyenKhoanUSD += objTU.SoTienNt;
                        TU_ChuyenKhoanVND += objTU.SoTien;
                        TU_TyGiaChuyenKhoan = objTU.TyGia;
                        view.CoPhatSinh = 1;
                    }
                }
                view.TienMatVND = TU_TienMatVND;
                view.TienMatUSD = TU_TienMatUSD;
                view.TyGiaTienMat = TU_TyGiaTienMat;
                view.ChuyenKhoanVND = TU_ChuyenKhoanVND;
                view.ChuyenKhoanUSD = TU_ChuyenKhoanUSD;
                view.TyGiaChuyenKhoan = TU_TyGiaChuyenKhoan;

                view.TongSoVND = TU_TienMatVND + TU_ChuyenKhoanVND;
                view.TongUSD = TU_TienMatUSD + TU_ChuyenKhoanUSD;

                // Get Hoan Ung theo doan cong tac
                //IList<VnsGiaoDich> lstHU = RP_BC04DRDao.GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(), new Guid(), (Guid)objDCT.Id, new Guid(), "", Globals.TkTamUng, "HU");
                IList<VnsGiaoDich> lstHU = ReportDao.GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(), new Guid(), (Guid)objDCT.Id, (Guid)objDCT.Id, Globals.LikeTkTienMat, Globals.TkTamUng, 2, 2);
                //GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(), new Guid(), (Guid)objDCT.Id, new Guid(), "", Globals.TkTamUng, "HU");
                decimal HoanUngUSD = 0;
                decimal HoanUngVND = 0;
                decimal HoanUngCKVND = 0;
                decimal HoanUngCKUSD = 0;
                foreach (VnsGiaoDich objHU in lstHU)
                {
                    if (objHU.MaTkNo.StartsWith(Globals.TkTienMat) && objHU.MaTkCo.StartsWith(Globals.TkTamUng))
                    {
                        HoanUngUSD += objHU.SoTienNt;
                        HoanUngVND += objHU.SoTien;
                        view.CoPhatSinh = 1;
                    }
                    if (objHU.MaTkNo.StartsWith(Globals.TkTienChuyenKhoan) && objHU.MaTkCo.StartsWith(Globals.TkTamUng))
                    {
                        HoanUngCKVND += objHU.SoTien;
                        HoanUngCKUSD += objHU.SoTienNt;
                        view.CoPhatSinh = 1;
                    }
                }
                view.ThuHoanTUQTTienMatVND = HoanUngVND;
                view.ThuHoanTUQTTienMatUSD = HoanUngUSD;
                if (HoanUngUSD > 0)
                    view.ThuHoanTUQTTienMatTyGia = HoanUngVND / HoanUngUSD;
                // Get so tien Thu hoan TU, QT thang truoc
                view.ThuHoanTUQTTienMatUSDThangTruoc = 0;
                view.ThuHoanTUQTTienMatVNDThangTruoc = 0;
                view.ThuHoanTUQTTyGiaThangTruoc = 0;
                // get so tien chi quyet toan cho doan ra
                //IList<VnsGiaoDich> lstChiQT = RP_BC04DRDao.GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(), new Guid(), (Guid)objDCT.Id, new Guid(), string.Empty, string.Empty, "PC");
                // IList<VnsGiaoDich> lstChiQT = ReportDao.GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(), new Guid(), new Guid(), new Guid(), Globals.TkTamUng, Globals.TkTienLike, 2, 2);
                decimal ChiQTTienMatVND = 0;
                decimal ChiQTTienMatUSD = 0;
                decimal ChiQTTChuyenKhoanVND = 0;
                decimal ChiQTTChuyenKhoanUSD = 0;

                List<VnsGiaoDich> lstChiQT = new List<VnsGiaoDich>();
                lstChiQT.AddRange(ReportDao.GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(), new Guid(), (Guid)objDCT.Id, (Guid)objDCT.Id, Globals.TkTamUng, Globals.LikeTkTienMat, 1, 2));
                lstChiQT.AddRange(ReportDao.GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(), new Guid(), (Guid)objDCT.Id, (Guid)objDCT.Id, Globals.TkTamUng, Globals.LikeTkTienMat, 2, 2));

                foreach (VnsGiaoDich objChiQT in lstChiQT)
                {
                    if (objChiQT.MaTkCo.StartsWith(Globals.TkTienMat) && objChiQT.MaTkNo.StartsWith(Globals.TkTamUng))
                    {
                        ChiQTTienMatUSD += objChiQT.SoTienNt;
                        ChiQTTienMatVND += objChiQT.SoTien;
                        view.CoPhatSinh = 1;
                    }
                    if (objChiQT.MaTkCo.StartsWith(Globals.TkTienChuyenKhoan))
                    {
                        ChiQTTChuyenKhoanUSD += objChiQT.SoTienNt;
                        ChiQTTChuyenKhoanVND += objChiQT.SoTien;
                        view.CoPhatSinh = 1;
                    }
                }

                decimal TongTienPhaiThuTienMat = TU_TienMatUSD - ChiQTTienMatUSD - TienQuyetToan + HoanUngUSD;
                decimal TongTienPhaiThuChuyenKhoan = TU_ChuyenKhoanUSD - ChiQTTChuyenKhoanUSD + HoanUngCKUSD;
                decimal SoTienThuTra = TienQuyetToan - (TU_ChuyenKhoanUSD + TU_TienMatUSD) - (ChiQTTChuyenKhoanUSD + ChiQTTienMatUSD);
                // Tong tien phai tra, phai thu: Tong Tien Tam Ung - Tong Chi Quyet Toan + Thu Hoan
                // Neu >0 thi phai thu hoan tu doan ra, 
                // Neu <0 Thi phai tra cho doan ra
                if (SoTienThuTra > 0)
                {
                    view.PhaiTraUSD = SoTienThuTra;

                }
                else
                {
                    view.PhaiThuUSD = Math.Abs(SoTienThuTra);
                    view.TyGiaPhaiThu = 0;
                    view.PhaiThuVND = 0;
                }

                view.CKChiQTUSD = ChiQTTChuyenKhoanUSD;
                view.CKChiQTVND = ChiQTTChuyenKhoanVND;
                if (ChiQTTChuyenKhoanUSD > 0 && ChiQTTChuyenKhoanVND > 0)
                    view.TyGiaCKChiQT = ChiQTTChuyenKhoanVND / ChiQTTChuyenKhoanUSD;

                view.TienMatChiQTUSD = ChiQTTienMatUSD;
                view.TienMatChiQTVND = ChiQTTienMatVND;
                if (ChiQTTChuyenKhoanUSD > 0)
                    view.TienMatTyGiaChiQT = ChiQTTienMatVND / ChiQTTienMatUSD;

                // // get so tien quyet toan cua doan ra
                IList<VnsGiaoDich> lstDaQT = ReportDao.GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(), new Guid(), (Guid)objDCT.Id, (Guid)objDCT.Id, Globals.LikeTkQt, Globals.TkTamUng, 0, 2);
                //RP_BC04DRDao.GetLstGiaoDich(dTuNgay, dDenNgay, new Guid(), new Guid(), new Guid(), (Guid)objDCT.Id,"", Globals.TkTamUng, "QT");
                decimal TongSoQTUSD = 0;
                decimal TongSoQTVND = 0;

                decimal TienMatUSD = 0;
                decimal TienMatVND = 0;
                decimal TyGiaTienMat = 0;

                decimal ChuyenKhoanUSD = 0;
                decimal ChuyenKhoanVND = 0;
                decimal TyGiaChuyenKhoan = 0;
                decimal d_6801 = 0;
                decimal d_6802 = 0;
                decimal d_6803 = 0;
                decimal d_6804 = 0;
                decimal d_6805 = 0;
                decimal d_6806 = 0;
                decimal d_6849 = 0;

                foreach (VnsGiaoDich objDaQT in lstDaQT)
                {
                    if (objDaQT.MaTkNo.StartsWith(Globals.TkThanhToanTienMat) && objDaQT.MaTkCo.StartsWith(Globals.TkTamUng))
                    {
                        TienMatUSD += objDaQT.SoTienNt;
                        TienMatVND += objDaQT.SoTien;
                        view.CoPhatSinh = 1;
                    }
                    if (objDaQT.MaTkNo.StartsWith(Globals.TkThanhToanChuyenKhoan) && objDaQT.MaTkCo.StartsWith(Globals.TkTamUng))
                    {
                        ChuyenKhoanUSD += objDaQT.SoTienNt;
                        ChuyenKhoanVND += objDaQT.SoTien;
                        view.CoPhatSinh = 1;
                    }

                    //data tieu muc
                    VnsDmMucTieuMuc objTM = VnsDmMucTieuMucDao.GetByKey("Id", objDaQT.MucTieuMucCoId);

                    if (objTM != null)
                    {
                        if (objTM.MaMuc.StartsWith("6801"))
                            d_6801 += objDaQT.SoTienNt;
                        if (objTM.MaMuc.StartsWith("6802"))
                            d_6802 += objDaQT.SoTienNt;
                        if (objTM.MaMuc.StartsWith("6803"))
                            d_6803 += objDaQT.SoTienNt;
                        if (objTM.MaMuc.StartsWith("6804"))
                            d_6804 += objDaQT.SoTienNt;
                        if (objTM.MaMuc.StartsWith("6805"))
                            d_6805 += objDaQT.SoTienNt;
                        if (objTM.MaMuc.StartsWith("6806"))
                            d_6806 += objDaQT.SoTienNt;
                        if (objTM.MaMuc.StartsWith("6849"))
                            d_6849 += objDaQT.SoTienNt;
                    }

                }
                if (TienMatUSD > 0)
                    TyGiaTienMat = TienMatVND / TienMatUSD;
                if (ChuyenKhoanUSD > 0)
                    TyGiaChuyenKhoan = ChuyenKhoanVND / ChuyenKhoanUSD;
                view.TienMatUSDSoQT = TienMatUSD;
                view.TienMatVNDSoQT = TienMatVND;
                view.TienMatTyGiaSoQT = TyGiaTienMat;

                view.ChuyenKhoanUSDSoQT = ChuyenKhoanUSD;
                view.ChuyenKhoanVNDSoQT = ChuyenKhoanVND;
                view.ChuyenKhoanTyGiaSoQT = TyGiaChuyenKhoan;

                TongSoQTUSD = ChuyenKhoanUSD + TienMatUSD;
                TongSoQTVND = TienMatVND + ChuyenKhoanVND;
                view.TongSoUSDSoQT = TongSoQTUSD;
                view.TongSoVNDSoQT = TongSoQTVND;
                if (ChuyenKhoanUSD > 0)
                    view.ChuyenKhoanTyGiaSoQT = ChuyenKhoanVND / ChuyenKhoanUSD;
                // data muc - tieu muc
                view.TM6801 = d_6801;
                view.TM6802 = d_6802;
                view.TM6803 = d_6803;
                view.TM6804 = d_6804;
                view.TM6805 = d_6805;
                view.TM6806 = d_6806;
                view.TM6849 = d_6849;
                lstReturn.Add(view);
            }

            IList<ViewQuyetToan> lstTemp = new List<ViewQuyetToan>();

            foreach (ViewQuyetToan objviewQt in lstReturn)
            {
                if (objviewQt.CoPhatSinh == 1)
                    lstTemp.Add(objviewQt);
            }

            return lstTemp;
        }

        public IList<ViewQuyetToan> lstThuHoanQuyetToan2(DateTime dTuNgay, DateTime dDenNgay, Guid LoaiDoanRaId)
        {
            IList<ViewQuyetToan> lstReturn = new List<ViewQuyetToan>();


            return lstReturn;
        }

        public IList<VnsGiaoDich> GetGiaoDich(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_loaiDoanRaId, Guid p_DoanRaNoId, Guid p_DoanRaCoId, string p_TkNoId, string p_TkCoId, decimal p_TrangThaiPhieu, decimal p_TrangThaiDoanCt)
        {
            return ReportDao.GetLstGiaoDich( p_TuNgay,  p_DenNgay,  p_loaiDoanRaId, new Guid(),  p_DoanRaNoId,  p_DoanRaCoId,  p_TkNoId,  p_TkCoId,  p_TrangThaiPhieu,  p_TrangThaiDoanCt);
        }


        private int CompareReport(ViewTamUngDoanRa x, ViewTamUngDoanRa y)
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
                    retvalDoanDienID = x.PhieuChiSo.CompareTo(y.PhieuChiSo);
                    if (retvalDoanDienID == 0)
                    {
                        return revalSoChungTu = x.SoTBDuToan.CompareTo(y.SoTBDuToan);
                    }
                    else
                        return retvalDoanDienID;
                }
            }
        }
    }
}
