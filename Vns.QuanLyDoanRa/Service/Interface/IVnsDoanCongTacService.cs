using System.Collections;
using System.ComponentModel;
using System.Data;	
using System;
using Vns.QuanLyDoanRa.Service;
using Vns.QuanLyDoanRa.Domain;	
using Vns.Erp.Core.Service.Interface;
using System.Collections.Generic;
namespace Vns.QuanLyDoanRa.Service.Interface
{
    public interface IVnsDoanCongTacService : IErpService<VnsDoanCongTac, Guid>
    {
        IList<VnsDoanCongTac> ListDoanCongTacTuNgayDenNgay(DateTime dTuNgay, DateTime dDenNgay);
        IList<VnsDoanCongTac> GetByTrangThai(int p_trangthai);
        void DeleteDoanCongTac(VnsDoanCongTac objDoanCongTac);
        IList<VnsDoanCongTac> GetByLoaiDoanRa(Guid LoaiDoanRaId);
        void SaveDoanCongTac(ref VnsDoanCongTac objDoanCongTac);
        IList<VnsDoanCongTac> GetAllOrderByNgayDi();
        IList<VnsDoanCongTac> GetDoanRaPhu(int Nam);
        IList<VnsDoanCongTac> GetDoanRa(int Nam);
        IList<VnsDoanCongTac> GetDoanRaByDoanRaBanDau(Guid DoanRaId);
        IList<VnsDoanCongTac> GetDoanRaTongHopQT(int Nam);
    }
}
	