
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
using Vns.QuanLyDoanRa.Domain.Report;
namespace Vns.QuanLyDoanRa.Service.Interface
{
    public interface IVnsDuToanDoanService : IErpService<VnsDuToanDoan, Guid>
    {
        IList<VnsDuToanDoan> GetByDoanCongTac(Guid CongTacId);
        IList<VnsDuToanDoan> TinhDuToan(DateTime NgayTinh, VnsDoanCongTac objDoanRa);
        IList<VnsDuToanDoan> TinhDuToan444(DateTime NgayTinh, VnsDoanCongTac objDoanRa);
        IList<VnsInQtTu> GetDataInDt(Guid CongTacId);
        IList<BC03DR> ListChuaQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRa);
        IList<VnsDuToanDoan> GetByDoanCongTac(Guid CongTacId, int LanDuToan);
        void DeleteByDoanCongTac(Guid CongTacId, int LanDuToan);
    }
}
