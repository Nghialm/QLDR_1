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
using Spring.Transaction.Interceptor;
namespace Vns.QuanLyDoanRa.Service
{
    /// <summary>
    ///	Generated by MyGeneration using the NHibernate Object Mapping adapted by Gustavo
    /// </summary>	
    //,IVnsQuyetToanDoanService
    public class VnsQuyetToanDoanService : GenericService<VnsQuyetToanDoan, Guid>, IVnsQuyetToanDoanService
    {
        public IVnsQuyetToanDoanDao VnsQuyetToanDoanDao
        {
            get { return (IVnsQuyetToanDoanDao)Dao; }
            set { Dao = value; }
        }

        public IVnsDoanCongTacDao VnsDoanCongTacDao;
        public IVnsChungTuDao VnsChungTuDao;
        public IVnsGiaoDichDao VnsGiaoDichDao;
        public IVnsNghiepVuDao VnsNghiepVuDao;

        public IList<VnsQuyetToanDoan> GetByDoanCongTac(Guid CongTacId)
        {
            return VnsQuyetToanDoanDao.GetByDoanCongTac(CongTacId);
        }

        public IList<VnsQuyetToanDoan> GetByDoanCongTac(Guid CongTacId, Decimal LanQuyetToan)
        {
            return VnsQuyetToanDoanDao.GetByDoanCongTac(CongTacId, LanQuyetToan);
        }

        public void MaintainDoanRa(VnsDoanCongTac objDoanCongTac)
        {
            VnsChungTu objChungTu = null;
            Guid chungtuid = Null.NullGuid;
            int lanqt = 0;
            if (objDoanCongTac.DanhSachQuyetToanDoan == null || objDoanCongTac.DanhSachQuyetToanDoan.Count == 0)
                return;
            else
            {
                lanqt = Convert.ToInt32(objDoanCongTac.DanhSachQuyetToanDoan[0].LanQuyetToan);
                chungtuid = objDoanCongTac.DanhSachQuyetToanDoan[0].ChungTuId;
            }
            if (!VnsCheck.IsNullGuid(chungtuid))
            {
                VnsChungTu tmp  = VnsChungTuDao.Get(chungtuid);

                if (tmp != null)
                {
                    objChungTu = tmp.Clone();
                    objChungTu.LstGiaoDich = null;
                    objChungTu.Id = new Guid();
                }
            }
            if (objChungTu == null) return;

            IList<VnsGiaoDich> lsttmp = VnsGiaoDichDao.GetByChungTu(chungtuid);
            IList<VnsGiaoDich> lstGiaoDich = new List<VnsGiaoDich>();
            for (int i = lsttmp.Count - 1; i >= 0; i--)
            {
                if (lsttmp[i].MaTkCo == Globals.TkTamUng)
                {
                    VnsGiaoDich tmp = lsttmp[i].Clone();
                    tmp.Id = new Guid();
                    lstGiaoDich.Add(tmp);
                }
            }

            SaveQuyetToanDoan(objDoanCongTac, objChungTu, lstGiaoDich, lanqt);
        }

        [Transaction]
        public void SaveQuyetToanDoan(VnsDoanCongTac objDoanCongTac, VnsChungTu objChungTu, IList<VnsGiaoDich> lstGiaoDich, int lanqt)
        {
            //Lay danh sach tai khoan
            IList<VnsNghiepVu> lstNghiepVu = VnsNghiepVuDao.GetAll();

            //Xoa du lieu chung tu, giao dich
            Guid chungtuId = new Guid();

            //Xoa du lieu bi sai tu truoc, neu ChungTuId trong DoanCongTac = Null.Guid thi khong xoa
            Guid chungtucu = objDoanCongTac.ChungTuId;
            if (chungtucu != new Guid())
            {
                //VnsChungTu tmp = VnsChungTuDao.Get(chungtucu);
                //VnsChungTuDao.Delete(tmp);
                //VnsGiaoDichDao.DeleteByChungTu(chungtucu);
                VnsChungTuDao.Delete_By_Id(chungtucu);
            }

            //Lay ra chung tu id can xoa
            foreach (VnsQuyetToanDoan objqt in objDoanCongTac.DanhSachQuyetToanDoan)
            {
                if (objqt.LanQuyetToan == lanqt)
                {
                    if (!VnsCheck.IsNullGuid(objqt.ChungTuId))
                    {
                        chungtuId = objqt.ChungTuId;
                        break;
                    }
                }
            }

            if (chungtuId != new Guid())
            {
                //VnsChungTu tmp = VnsChungTuDao.Get(chungtuId);
                //VnsChungTuDao.Delete(tmp);
                //VnsGiaoDichDao.DeleteByChungTu(chungtuId);
                VnsChungTuDao.Delete_By_Id(chungtuId);
            }
            //Insert chung tu, giao dich

            //Xoa vet du toan cu
            if (objDoanCongTac.Id != new Guid())
            {
                VnsQuyetToanDoanDao.DeleteByDoanCtId(objDoanCongTac.Id);
            }
            
            VnsChungTuDao.Save(objChungTu);

            //Lay ra so tien can quyet toan
            decimal qt_tm_usd = 0;
            decimal qt_tm_usd_dk = 0;
            decimal qt_ck_usd = 0;
            decimal qt_ck_usd_dk = 0;

            decimal qt_tm_vnd =0;
            decimal qt_ck_vnd =0;
            foreach (VnsGiaoDich qt in lstGiaoDich)
            {
                if (qt.MaTkNo == Globals.TkThanhToanTienMat)
                {
                    qt_tm_usd += qt.SoTienNt;
                    qt_tm_usd_dk += qt.SoTienNt;
                }
                else if (qt.MaTkNo == Globals.TkThanhToanChuyenKhoan)
                {
                    qt_ck_usd += qt.SoTienNt;
                    qt_ck_usd_dk += qt.SoTienNt;
                }
            }

            //Phan bo so tien can quyet toan voi ty qia
            IList<VnsGiaoDich> lstTu = VnsGiaoDichDao.GetTUByDoanRaIdGroupByTyGia(objDoanCongTac.Id);
            decimal tu_tm_usd = 0;
            decimal tu_tm_vnd = 0;
            decimal tu_ck_usd = 0;
            decimal tu_ck_vnd = 0;


            /*
             * Dung de check ty gia khi quyet toan
             * Neu tam ung co nhieu ty gia se sinh ra nghiep vu quyet toan co nhieu ty gia
             * flg = 0 => 1 ty gia
             * flg > 0 => nhieu ty gia
             */
            int flg_tm_mul_tygia = -1;
            int flg_ck_mul_tygia = -1;

            #region Tinh so tien da tam ung
            foreach (VnsGiaoDich tu in lstTu)
            {
                if (tu.MaTkCo == Globals.TkTienMat)
                {
                    flg_tm_mul_tygia++;

                    tu_tm_usd += tu.SoTienNt;
                    tu_tm_vnd += tu.SoTien;

                    if (tu_tm_usd == qt_tm_usd)
                    {
                        qt_tm_vnd = tu_tm_vnd;
                    }
                    else if (tu_tm_usd > qt_tm_usd)
                    {
                        qt_tm_vnd = tu_tm_vnd - (tu_tm_usd - qt_tm_usd) * tu.TyGia;
                    }
                    else
                    {
                        qt_tm_vnd = -1;
                    }
                }
                else if (tu.MaTkCo == Globals.TkTienChuyenKhoan)
                {
                    flg_ck_mul_tygia++;

                    tu_ck_usd += tu.SoTienNt;
                    tu_ck_vnd += tu.SoTien;

                    if (tu_ck_usd == qt_ck_usd)
                    {
                        qt_ck_vnd = tu_ck_vnd;
                    }
                    else if (tu_ck_usd > qt_ck_usd)
                    {
                        qt_ck_vnd = tu_ck_vnd - (tu_ck_usd - qt_ck_usd) * tu.TyGia;
                    }
                    else
                    {
                        qt_ck_vnd = -1;
                    }
                }
            }
            #endregion
            
            decimal ty_gia_tb = 0; //Tinh ty gia binh quan
            //Khi quyet toan, chuong trinh tao ra nghiep vu 
            //ghi no Thanh toan voi khach hang - ghi co tai khoan tam ung
            //Dong thoi ghi nhan but toan quyet toan doan (Co 2 truong hop xay ra
            //1. Truong hop tam ung du hoac thua cho doan ra:
            //Tao ra but toan: No tai khoan quyet toan - co tai khoan phai tra khach hang voi so tien bang chinh so quyet toan
            //2. Tam ung thieu phai bu them:
            //Tao ra but toan: No tai khoan quyet toan - co tai khoan phai tra khach hang voi so tien bang chi so tam ung
            #region Ghi nhan cong no cua doan
            //Gan so tien VND vao quyet toan tien mat
            if (qt_tm_vnd > 0)
            {
                ty_gia_tb = qt_tm_vnd / qt_tm_usd;
                foreach (VnsGiaoDich qt in lstGiaoDich)
                {
                    if (qt.MaTkNo == Globals.TkThanhToanTienMat)
                    {
                        qt_tm_usd -= qt.SoTienNt;
                        if (qt_tm_usd == 0)
                        {
                            qt.SoTien = qt_tm_vnd;
                            qt.TyGia = qt.SoTien / qt.SoTienNt;
                        }
                        else
                        {
                            qt.SoTien = ty_gia_tb * qt.SoTienNt;
                            qt.TyGia = ty_gia_tb;
                            qt_tm_vnd -= qt.SoTien;
                        }
                    }
                }
            }

            /*Tinh ty gia tien quyet toan
             * Neu co nhieu ty gia tam ung se xuat ty gia nho truoc
            */
            //foreach (VnsGiaoDich tu in lstTu)
            //{
            //    if (tu.MaTkCo == Globals.TkTienMat)
            //    {

            //    }
            //    else if (tu.MaTkCo == Globals.TkTienChuyenKhoan)
            //    {
            //    }
            //}

            //Tao nghiep vu quyet toan tien mat
            if (qt_tm_usd_dk != 0 && tu_tm_usd != 0)
            {
                VnsGiaoDich btQuyetToanTm = new VnsGiaoDich();

                if (tu_tm_usd >= qt_tm_usd_dk)
                {
                    flg_tm_mul_tygia = -1;
                    foreach (VnsGiaoDich tu in lstTu)
                    {
                        flg_tm_mul_tygia++;
                        if (qt_tm_usd_dk == 0) break;
                        if (tu.MaTkCo == Globals.TkTienMat)
                        {
                            if (tu.SoTienNt <= qt_tm_usd_dk)
                            {
                                btQuyetToanTm.SoTienNt += tu.SoTienNt;
                                btQuyetToanTm.SoTien += tu.SoTien;

                                qt_tm_usd_dk -= tu.SoTienNt;
                            }
                            else
                            {
                                btQuyetToanTm.SoTienNt += qt_tm_usd_dk;
                                btQuyetToanTm.SoTien += qt_tm_usd_dk * tu.TyGia;

                                qt_tm_usd_dk = 0;
                            }
                        }
                    }

                    //btQuyetToanTm.SoTienNt = qt_tm_usd_dk;
                    btQuyetToanTm.TyGia = tu_tm_vnd / tu_tm_usd;

                    btQuyetToanTm.TyGiaTuDong = flg_tm_mul_tygia;

                    //btQuyetToanTm.SoTien = btQuyetToanTm.SoTienNt * btQuyetToanTm.TyGia;
                }
                else
                {
                    /*Dung ty gia tu dong de luu thong tin quyet toan
                     * Ty gia tu dong = 0 => 1 loai ty gia
                     * Ty gia tu dong = 1 => nhieu loai ty gia
                    */
                    btQuyetToanTm.TyGiaTuDong = flg_tm_mul_tygia;

                    btQuyetToanTm.SoTienNt = tu_tm_usd;
                    btQuyetToanTm.TyGia = tu_tm_vnd / tu_tm_usd;
                    btQuyetToanTm.SoTien = tu_tm_vnd;
                }

                VnsNghiepVu tkqt = GetNghiepVuByMa(Globals.TkNghiepVuChiHoatDong, lstNghiepVu);
                VnsNghiepVu tkthanhtoanTm = GetNghiepVuByMa(Globals.TkThanhToanTienMat, lstNghiepVu);

                btQuyetToanTm.DoanRaNoId = objDoanCongTac.Id;
                btQuyetToanTm.DoanRaCoId = objDoanCongTac.Id;
                btQuyetToanTm.LoaiDoanRaNoId = objDoanCongTac.LoaiDoanRaId;
                btQuyetToanTm.LoaiDoanRaCoId = objDoanCongTac.LoaiDoanRaId;
                btQuyetToanTm.TkNoId = tkqt.NghiepVuId; btQuyetToanTm.MaTkNo = tkqt.MaNghiepVu; btQuyetToanTm.TenTkNo = tkqt.TenNghiepVu;
                btQuyetToanTm.TkCoId = tkthanhtoanTm.NghiepVuId; btQuyetToanTm.MaTkCo = tkthanhtoanTm.MaNghiepVu; btQuyetToanTm.TenTkCo = tkthanhtoanTm.TenNghiepVu;
                if (btQuyetToanTm.SoTienNt != 0)
                    btQuyetToanTm.TyGia = btQuyetToanTm.SoTien / btQuyetToanTm.SoTienNt;
                lstGiaoDich.Add(btQuyetToanTm);
            }
            

            //Gan so tien VND cho quyet toan chuyen tien
            if (qt_ck_vnd > 0)
            {
                ty_gia_tb = qt_ck_vnd / qt_ck_usd;
                foreach (VnsGiaoDich qt in lstGiaoDich)
                {
                    if (qt.MaTkNo == Globals.TkThanhToanChuyenKhoan)
                    {
                        qt_ck_usd -= qt.SoTienNt;
                        if (qt_tm_usd == 0)
                        {
                            qt.SoTien = qt_ck_vnd;
                            qt.TyGia = qt.SoTien / qt.SoTienNt;
                        }
                        else
                        {
                            qt.SoTien = ty_gia_tb * qt.SoTienNt;
                            qt.TyGia = ty_gia_tb;
                            qt_ck_vnd -= qt.SoTien;
                        }
                    }
                }
            }

            //Tao nghiep vu quyet toan tien mat
            if (qt_ck_usd_dk != 0 && tu_ck_usd != 0)
            {
                VnsGiaoDich btQuyetToanCk = new VnsGiaoDich();
                if (tu_ck_usd >= qt_ck_usd_dk)
                {
                    flg_ck_mul_tygia = -1;
                    foreach (VnsGiaoDich tu in lstTu)
                    {
                        flg_ck_mul_tygia++;
                        if (qt_ck_usd_dk == 0) break;
                        if (tu.MaTkCo == Globals.TkTienChuyenKhoan)
                        {
                            if (tu.SoTienNt <= qt_ck_usd_dk)
                            {
                                btQuyetToanCk.SoTienNt += tu.SoTienNt;
                                btQuyetToanCk.SoTien += tu.SoTien;

                                qt_ck_usd_dk -= tu.SoTienNt;
                            }
                            else
                            {
                                btQuyetToanCk.SoTienNt += qt_ck_usd_dk;
                                btQuyetToanCk.SoTien += qt_ck_usd_dk * tu.TyGia;

                                qt_ck_usd_dk = 0;
                            }
                        }
                    }

                    //btQuyetToanCk.SoTienNt = qt_ck_usd_dk;
                    btQuyetToanCk.TyGiaTuDong = flg_ck_mul_tygia;

                    btQuyetToanCk.TyGia = tu_ck_vnd / tu_ck_usd;
                    //btQuyetToanCk.SoTien = btQuyetToanCk.SoTienNt * btQuyetToanCk.TyGia;
                }
                else
                {
                    /*Dung ty gia tu dong de luu thong tin quyet toan
                     * Ty gia tu dong = 0 => 1 loai ty gia
                     * Ty gia tu dong = 1 => nhieu loai ty gia
                    */
                    btQuyetToanCk.TyGiaTuDong = flg_ck_mul_tygia;

                    btQuyetToanCk.SoTienNt = tu_ck_usd;
                    btQuyetToanCk.TyGia = tu_ck_vnd / tu_ck_usd;
                    btQuyetToanCk.SoTien = tu_ck_vnd;
                }
                VnsNghiepVu tkqt = GetNghiepVuByMa(Globals.TkNghiepVuChiHoatDong, lstNghiepVu);
                VnsNghiepVu tkthanhtoanCk = GetNghiepVuByMa(Globals.TkThanhToanChuyenKhoan, lstNghiepVu);

                btQuyetToanCk.DoanRaNoId = objDoanCongTac.Id;
                btQuyetToanCk.DoanRaCoId = objDoanCongTac.Id;
                btQuyetToanCk.LoaiDoanRaNoId = objDoanCongTac.LoaiDoanRaId;
                btQuyetToanCk.LoaiDoanRaCoId = objDoanCongTac.LoaiDoanRaId;
                btQuyetToanCk.TkNoId = tkqt.NghiepVuId; btQuyetToanCk.MaTkNo = tkqt.MaNghiepVu; btQuyetToanCk.TenTkNo = tkqt.TenNghiepVu;
                btQuyetToanCk.TkCoId = tkthanhtoanCk.NghiepVuId; btQuyetToanCk.MaTkCo = tkthanhtoanCk.MaNghiepVu; btQuyetToanCk.TenTkCo = tkthanhtoanCk.TenNghiepVu;

                if (btQuyetToanCk.SoTienNt != 0)
                    btQuyetToanCk.TyGia = btQuyetToanCk.SoTien / btQuyetToanCk.SoTienNt;

                lstGiaoDich.Add(btQuyetToanCk);
            }
            #endregion
            
            decimal sumSoTienQtNT = 0;
            foreach (VnsGiaoDich obj in lstGiaoDich)
            {
                sumSoTienQtNT += obj.SoTienNt;
                obj.ChungTuId = objChungTu.Id;
                VnsGiaoDichDao.Save(obj);
            }

            //Update lai chung tu id cho quyet toan doan
            foreach (VnsQuyetToanDoan objqt in objDoanCongTac.DanhSachQuyetToanDoan)
            {
                if (objqt.LanQuyetToan == lanqt)
                {
                    objqt.ChungTuId = objChungTu.Id;
                    objqt.CongTacId = objDoanCongTac.Id;
                }
            }
            //objDoanCongTac.NgayQuyetToan = objChungTu.NgayCt;
            VnsDoanCongTacDao.Merge(objDoanCongTac);
       }

        private VnsNghiepVu GetNghiepVuByMa(String Ma, IList<VnsNghiepVu> lstNv)
        {
            foreach (VnsNghiepVu tmp in lstNv)
            {
                if (tmp.MaNghiepVu == Ma) return tmp;
            }
            return null;
        }

        public void DeleteQuyetToanDoan(VnsDoanCongTac objDoanCongTac, decimal lanqt)
        {
            Guid chungtucu = objDoanCongTac.ChungTuId;
            //Xoa du lieu chung tu, giao dich
            Guid chungtuId = new Guid();

            if (chungtucu != new Guid())
            {
                //VnsChungTu tmp = VnsChungTuDao.Get(chungtucu);
                //VnsChungTuDao.Delete(tmp);
                //VnsGiaoDichDao.DeleteByChungTu(chungtucu);
                VnsChungTuDao.Delete_By_Id(chungtucu);
            }

            //Lay ra chung tu id can xoa
            foreach (VnsQuyetToanDoan objqt in objDoanCongTac.DanhSachQuyetToanDoan)
            {
                if (objqt.LanQuyetToan == lanqt)
                {
                    chungtuId = objqt.ChungTuId;
                    break;
                }
            }

            if (chungtuId != new Guid())
            {
                //VnsChungTu tmp = VnsChungTuDao.Get(chungtuId);
                //VnsChungTuDao.Delete(tmp);
                //VnsGiaoDichDao.DeleteByChungTu(chungtuId);
                VnsChungTuDao.Delete_By_Id(chungtuId);
            }

            if (lanqt > 0)
            {
                //VnsQuyetToanDoanDao.DeleteByDoanCtId(objDoanCongTac.Id);
                VnsDoanCongTacDao.Delete(objDoanCongTac);
            }
            else
            {
                VnsQuyetToanDoanDao.DeleteByDoanCtId(objDoanCongTac.Id);
            }
        }
        public IList<VnsInQtTu> GetDataInQt(Guid CongTacId)
        {
            return VnsQuyetToanDoanDao.GetDataInQt(CongTacId);
        }
        public IList<VnsInQtTu> GetDataInQTbyDoanCtac(Guid CongTacId, Decimal LanQuyetToan)
        {
            return VnsQuyetToanDoanDao.GetDataInQTbyDoanCtac(CongTacId, LanQuyetToan);
        }
    }
}
