
/*
insert license info here
*/
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
    public interface IVnsThanhVienService : IErpService<VnsThanhVien, Guid>
    {
        IList<VnsThanhVien> GetByDoanCongTac(Guid CongTacId);
        Boolean DeleteByDoanCongTac(Guid CongTacId);
        IList<VnsThanhVien> GetThanhVienByLichCongTacDoanRa(Guid LichCongTacId, Guid DoanRaId);
        IList<VnsThanhVien> GetThanhVienByLichCongTacDoanRa(Guid LichCongTacId, Guid DoanRaId, int LoaiThanhVien);
    }
}
