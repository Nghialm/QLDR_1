
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
    public interface IVnsDinhMucService : IErpService<VnsDinhMuc, Guid>
    {
        IList<VnsDinhMuc> GetByNgayApDung(DateTime NgayApDung, Decimal DinhMuc, bool flag);
    }
}
