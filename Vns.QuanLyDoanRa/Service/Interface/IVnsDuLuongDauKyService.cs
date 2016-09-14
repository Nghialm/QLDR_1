using System.Collections;
using System.ComponentModel;
using System.Data;
using System;
using Vns.QuanLyDoanRa.Service;
using Vns.QuanLyDoanRa.Domain;
using Vns.Erp.Core.Service.Interface;
namespace Vns.QuanLyDoanRa.Service.Interface
{
    public interface IVnsDuLuongDauKyService : IErpService<VnsDuLuongDauKy, Guid>
	{
        void TinhTyGiaFIFO(DateTime TuNgay, DateTime DenNgay, String NghiepVu, Guid NguonId);
	}
}
