using System.Collections;
using System.ComponentModel;
using System.Data;
using System;
using Vns.QuanLyDoanRa.Service;
using Vns.QuanLyDoanRa.Domain;
using Vns.Erp.Core.Service.Interface;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain.Report;
namespace Vns.QuanLyDoanRa.Service.Interface
{
    public interface IVnsSoDuCuoiKyService : IErpService<VnsSoDuCuoiKy, Guid>
	{
        IList<RP_SoDuTaiKhoan> GetLstSoDu(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_NguonId, string p_NghiepVu);
	}
}
