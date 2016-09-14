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
    public class VnsDuLuongDauKyService : GenericService<VnsDuLuongDauKy, System.Guid>, IVnsDuLuongDauKyService
    {
        public IVnsDuLuongDauKyDao VnsDuLuongDauKyDao
        {
            get { return (IVnsDuLuongDauKyDao)Dao; }
            set { Dao = value; }
        }

        public IVnsGiaoDichDao VnsGiaoDichDao;
        public IVnsSoDuCuoiKyDao VnsSoDuCuoiKyDao;
        public IReportDao ReportDao;

        public void QuyetToanDoanRa(DateTime DenNgay, Guid DoanRaId, String NghiepVu, ref VnsGiaoDich nhap)
        {
            IList<RP_Doan_CongNo> tmp = ReportDao.GetLstDoanRaTheoTamUngConLai(Null.NullDate, DenNgay, Null.NullGuid, Null.NullGuid, DoanRaId, DoanRaId, NghiepVu, Globals.TkTamUng, 0);

            if (tmp.Count <= 0) return;

            RP_Doan_CongNo rpCongNo = tmp[0];
            tmp[0].TinhToanDuLuong();

            IList<VnsGiaoDich> lstNhap = VnsGiaoDichDao.GetByDoanRa(DoanRaId, NghiepVu, Globals.TkTamUng);

            foreach (VnsGiaoDich tmpnhap in lstNhap)
            {
                if (tmpnhap.SoTienNt < rpCongNo.DuLuong)
                {
                    tmpnhap.TyGia = rpCongNo.DuLuongVND / rpCongNo.DuLuong;
                    tmpnhap.SoTien = tmpnhap.TyGia * tmpnhap.SoTienNt;

                    rpCongNo.DuLuong = rpCongNo.DuLuong - tmpnhap.SoTienNt;
                    rpCongNo.DuLuongVND = rpCongNo.DuLuongVND - tmpnhap.SoTien;

                    VnsGiaoDichDao.Update(tmpnhap);
                }
                else
                {
                    tmpnhap.TyGia = rpCongNo.DuLuongVND / rpCongNo.DuLuong;
                    tmpnhap.SoTien = rpCongNo.DuLuongVND;

                    VnsGiaoDichDao.Update(tmpnhap);
                }

                if (tmpnhap.Id == nhap.Id)
                {
                    nhap.TyGia = tmpnhap.TyGia;
                    nhap.SoTien = tmpnhap.SoTien;
                }
            }


        }

        public void TinhTyGiaFIFO(DateTime TuNgay, DateTime DenNgay, String NghiepVu, Guid NguonId)
        {
            VnsDuLuongDauKy tmpdlck = null;
            VnsDuLuongDauKy tmpdldk = VnsDuLuongDauKyDao.GetBy(TuNgay, NguonId, NghiepVu);

            IList<VnsGiaoDich> lstNhap = new List<VnsGiaoDich>();

            Boolean UpdateFlg = false;
            if (tmpdldk == null)
                lstNhap = VnsGiaoDichDao.GetNhap4FIFO(Null.NullDate, DenNgay, NguonId, NghiepVu);
            else
                lstNhap = VnsGiaoDichDao.GetNhap4FIFO(tmpdldk.NgayCt, DenNgay, NguonId, NghiepVu);

            if (tmpdldk == null)
            {
                tmpdldk = new VnsDuLuongDauKy();
                //foreach (VnsGiaoDich tmpNhap in lstNhap)
                //{
                //    tmpNhap.DuLuong = tmpNhap.SoTienNt;
                //    tmpNhap.SoTienConLai = tmpNhap.SoTien;
                //}
            }
            else
                foreach (VnsGiaoDich tmpNhap in lstNhap)
                {
                    if (tmpNhap.GiaoDichId == tmpdldk.GiaoDichId)
                    {
                        tmpNhap.DuLuong = tmpdldk.DuLuong;
                        tmpNhap.SoTienConLai = tmpdldk.SoTienTon;
                        UpdateFlg = true;
                    }
                    else
                    {
                        if (UpdateFlg)
                        {
                            tmpNhap.DuLuong = tmpNhap.SoTienNt;
                            tmpNhap.SoTienConLai = tmpNhap.SoTien;
                        }
                    }


                }

            //Save KtDuluongDauky
            if (lstNhap.Count > 0)
            {
                tmpdldk.NguonId = NguonId;
                tmpdldk.NgayTinh = TuNgay;
                tmpdldk.GiaoDichId = lstNhap[0].GiaoDichId;
                tmpdldk.DuLuong = lstNhap[0].DuLuong;
                tmpdldk.NghiepVu = NghiepVu;
                tmpdldk.NgayCt = lstNhap[0].objChungTu.NgayCt;
                if (lstNhap[0].DuLuong == lstNhap[0].SoTienNt)
                    tmpdldk.SoTienTon = lstNhap[0].SoTien;
                else
                    tmpdldk.SoTienTon = lstNhap[0].SoTien - lstNhap[0].TyGia * (lstNhap[0].SoTienNt - lstNhap[0].DuLuong);

                //VnsDuLuongDauKyDao.SaveOrUpdate(tmpdldk);
                //VnsDuLuongDauKyDao.DeleteBy(TuNgay, NguonId, NghiepVu);
            }

            IList<VnsGiaoDich> lstXuat = VnsGiaoDichDao.GetBy(TuNgay, DenNgay, NguonId, NghiepVu);

            foreach (VnsGiaoDich tmpnhap in lstNhap)
            {
                //Nghiep vu tra tien tam ung cua doan ra
                if (tmpnhap.MaTkNo == Globals.TkTienMat && tmpnhap.MaTkCo == Globals.TkTamUng &&
                    tmpnhap.objChungTu.NgayCt >= TuNgay && tmpnhap.objChungTu.NgayCt<= DenNgay)
                {
                    //Kiem tra nghiem vu nay da duoc tinh chua: Du luong = so tien => Phai tinh
                    if (tmpnhap.DuLuong != tmpnhap.SoTien)
                    {

                    }

                    //Kiem tra nghiep vu cua doan ra co trong khoang thoi gian quyet toan khong
                    //Neu ngay quyet toan trong khoang thoi gian xem bao cao => tinh lai
                    //Neu khong phai, khong phai tinh
                    VnsGiaoDich tmpnhap1 = tmpnhap;
                    QuyetToanDoanRa(DateTime.MaxValue, tmpnhap.DoanRaNoId, tmpnhap.MaTkNo, ref tmpnhap1);

                    tmpnhap.TyGia = tmpnhap1.TyGia;
                    tmpnhap.SoTien = tmpnhap1.SoTien;
                }
            }

            foreach (VnsGiaoDich tmpxuat in lstXuat)
            {
                Decimal SoLuongChuaTinh = tmpxuat.SoTienNt;
                tmpxuat.SoTien = 0;

                VnsGiaoDich cur = new VnsGiaoDich();
                foreach (VnsGiaoDich tmpnhap in lstNhap)
                {
                    

                    if (tmpnhap.DuLuong < 0) continue;

                    if (SoLuongChuaTinh < tmpnhap.DuLuong)
                    {
                        if (tmpnhap.DuLuong == tmpnhap.SoTienNt)
                            tmpnhap.SoTienConLai = tmpnhap.SoTien - SoLuongChuaTinh * tmpnhap.TyGia;
                        else
                            tmpnhap.SoTienConLai = tmpnhap.SoTienConLai - SoLuongChuaTinh * tmpnhap.TyGia;

                        tmpnhap.DuLuong = tmpnhap.DuLuong - SoLuongChuaTinh;
                        //Don gia xuat tuong ung

                        tmpxuat.SoTien = tmpxuat.SoTien + SoLuongChuaTinh * tmpnhap.TyGia;
                        tmpxuat.TyGia = tmpxuat.SoTien / tmpxuat.SoTienNt;
                        cur = tmpnhap;
                        break;
                    }
                    else
                        if (SoLuongChuaTinh == tmpnhap.DuLuong)
                        {
                            tmpxuat.SoTien = tmpxuat.SoTien + tmpnhap.SoTienConLai;

                            tmpnhap.DuLuong = 0;
                            tmpnhap.SoTienConLai = 0;

                            cur = tmpnhap;
                            break;
                        }
                        else
                        {
                            tmpxuat.SoTien = tmpxuat.SoTien + tmpnhap.SoTienConLai;
                            SoLuongChuaTinh = SoLuongChuaTinh - tmpnhap.DuLuong;

                            tmpnhap.DuLuong = 0;
                            tmpnhap.SoTienConLai = 0;
                        }
                }

                tmpdlck = new VnsDuLuongDauKy();
                tmpdlck.NguonId = NguonId;
                tmpdlck.NgayTinh = DenNgay.AddDays(1);
                tmpdlck.GiaoDichId = cur.GiaoDichId;
                tmpdlck.DuLuong = cur.DuLuong;
                tmpdlck.NghiepVu = NghiepVu;
                tmpdlck.NgayCt = cur.objChungTu.NgayCt;
                if (cur.DuLuong == cur.SoTienNt)
                    tmpdlck.SoTienTon = cur.SoTien;
                else
                    tmpdlck.SoTienTon = cur.SoTien - cur.TyGia * (cur.SoTienNt - cur.DuLuong);
            }

            //Xoa du dau ky cac thang ke tiep
            VnsDuLuongDauKyDao.DeleteBy(TuNgay, NguonId, NghiepVu);
            if (tmpdlck != null)
                VnsDuLuongDauKyDao.SaveOrUpdate(tmpdlck);
            else
            {
                tmpdlck = new VnsDuLuongDauKy();
                tmpdlck.NguonId = NguonId;
                tmpdlck.NgayTinh = DenNgay.AddDays(1);
                tmpdlck.GiaoDichId = tmpdldk.GiaoDichId;
                tmpdlck.DuLuong = tmpdldk.DuLuong;
                tmpdlck.NghiepVu = NghiepVu;
                tmpdlck.NgayCt = tmpdldk.NgayCt;
                tmpdldk.NgayTinh = DenNgay.AddDays(1);
                VnsDuLuongDauKyDao.SaveOrUpdate(tmpdlck);
            }
            //VnsDuLuongDauKyDao.DeleteBy(TuNgay, NguonId, NghiepVu);

            //Update nhap kho
            foreach (VnsGiaoDich tmpNhap in lstNhap)
            {
                if (tmpNhap.DuLuong == 0) VnsGiaoDichDao.SaveOrUpdate(tmpNhap);
                if (tmpNhap.DuLuong != tmpNhap.SoTienNt)
                {
                    VnsGiaoDichDao.SaveOrUpdate(tmpNhap);
                }
            }

            List<VnsSoDuCuoiKy> lstSoDu = new List<VnsSoDuCuoiKy>();
            foreach (VnsGiaoDich tmpNhap in lstNhap)
            {

                Boolean hasExist = false;
                foreach (VnsSoDuCuoiKy tmpSoDu in lstSoDu)
                {
                    if (tmpSoDu.TyGia == tmpNhap.TyGia &&
                        tmpSoDu.NghiepVu == tmpNhap.MaTkNo &&
                        tmpSoDu.NguonId == tmpNhap.LoaiDoanRaNoId)
                    {
                        tmpSoDu.SoTien += tmpNhap.SoTienConLai;
                        tmpSoDu.SoTienNte += tmpNhap.DuLuong;

                        hasExist = true;
                        break;
                    }
                }

                if (!hasExist)
                {
                    VnsSoDuCuoiKy tmpSoDu = new VnsSoDuCuoiKy();
                    if (tmpNhap.DuLuong == tmpNhap.SoTienNt) tmpSoDu.SoTien = tmpNhap.SoTien;
                    else tmpSoDu.SoTien = tmpNhap.SoTienConLai;
                    tmpSoDu.TyGia = tmpNhap.TyGia;
                    tmpSoDu.SoTienNte = tmpNhap.DuLuong;
                    tmpSoDu.NgayTinh = DenNgay;
                    tmpSoDu.NguonId = tmpNhap.LoaiDoanRaNoId;
                    tmpSoDu.NghiepVu = tmpNhap.MaTkNo;

                    lstSoDu.Add(tmpSoDu);
                }
            }

            //Update Xuat kho
            foreach (VnsGiaoDich tmpXuat in lstXuat)
            {
                VnsGiaoDichDao.SaveOrUpdate(tmpXuat);
            }

            VnsSoDuCuoiKyDao.DeleteBy(TuNgay, NguonId, NghiepVu);
            foreach (VnsSoDuCuoiKy tmpsodu in lstSoDu)
            {
                VnsSoDuCuoiKyDao.SaveOrUpdate(tmpsodu);
            }

            //Update So tien Quyet toan doan ra
            //IList<RP_Doan_CongNo> LstDoanRaTheoCongNo = ReportDao.GetLstDoanRaTheoCongNo(Null.NullDate, DenNgay, Null.NullGuid, Null.NullGuid, Null.NullGuid, Null.NullGuid, Globals.TkTamUng, Globals.TkTienMat, 1);
            //IList<VnsGiaoDich> lstNhapTienDoanRa = VnsGiaoDichDao.GetNhap4FIFO(tmpdldk.NgayCt, DenNgay, NguonId, Globals.TkTamUng, Globals.TkTienMat);
            //foreach (VnsGiaoDich tmpGiaoDich in lstNhapTienDoanRa)
            //{
            //    foreach (RP_Doan_CongNo tmpCongNo in LstDoanRaTheoCongNo)
            //    {
            //        if (tmpGiaoDich.DoanRaNoId == tmpCongNo.DoanRaNoId)
            //        {
            //            if (tmpGiaoDich.SoTienNt < tmpCongNo.DuLuong)
            //            {
            //                Decimal tygia = tmpCongNo.DuLuongVND / tmpCongNo.DuLuong;
            //                tmpGiaoDich.SoTien = tygia * tmpGiaoDich.SoTienNt;

            //                tmpCongNo.DuLuong = tmpCongNo.DuLuong - tmpGiaoDich.SoTienNt;
            //                tmpCongNo.DuLuongVND = tmpCongNo.DuLuongVND - tmpGiaoDich.SoTien;
            //            }
            //            else
            //            {
            //                tmpCongNo.DuLuong = 0;
            //                tmpGiaoDich.SoTien = tmpCongNo.DuLuongVND;
            //            }
            //        }
            //    }

            //    VnsGiaoDichDao.SaveOrUpdate(tmpGiaoDich);
            //}


        }
    }
}