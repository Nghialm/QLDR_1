
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
    public interface IVnsNghiepVuService : IErpService<VnsNghiepVu, Guid>
    {
        IList<VnsNghiepVu> GetDatasourceByLoaiCt(IList<VnsNghiepVu> lstNghiepVu, VnsLoaiChungTu objLoaiChungTu);
        IList<VnsNghiepVu> GetNghiepVuKtk(IList<VnsNghiepVu> lstNghiepVu, bool Flag, VnsLoaiChungTu objLoaiChungTu);
    }
}
