
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
    public interface IVnsDmHeThongService : IErpService<VnsDmHeThong, Guid>
    {
        IList<VnsDmHeThong> GetByDoiTuong(String DoiTuong);
        IList<VnsDmHeThong> GetByDoiTuongAndMa(String DoiTuong, String Ma);
    }
}
