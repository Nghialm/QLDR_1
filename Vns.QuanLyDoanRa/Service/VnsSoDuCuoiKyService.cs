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
    public class VnsSoDuCuoiKyService : GenericService<VnsSoDuCuoiKy, System.Guid>, IVnsSoDuCuoiKyService
    {
        public IVnsSoDuCuoiKyDao VnsSoDuCuoiKyDao
        {
            get { return (IVnsSoDuCuoiKyDao)Dao; }
            set { Dao = value; }
        }

        public IList<RP_SoDuTaiKhoan> GetLstSoDu(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_NguonId, string p_NghiepVu)
        {
            return VnsSoDuCuoiKyDao.GetLstSoDu(p_TuNgay, p_DenNgay, p_NguonId, p_NghiepVu);      
        }
    }
}