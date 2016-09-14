
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
    public interface IVnsQuyetToanDoanService : IErpService<VnsQuyetToanDoan, Guid>
    {
        IList<VnsQuyetToanDoan> GetByDoanCongTac(Guid CongTacId);
        IList<VnsQuyetToanDoan> GetByDoanCongTac(Guid CongTacId, Decimal LanQuyetToan);
        void SaveQuyetToanDoan(VnsDoanCongTac objDoanCongTac, VnsChungTu objChungTu, IList<VnsGiaoDich> lstGiaoDich,int lanqt);
        void DeleteQuyetToanDoan(VnsDoanCongTac objDoanCongTac, decimal lanqt);
        IList<VnsInQtTu> GetDataInQt(Guid CongTacId);
        IList<VnsInQtTu> GetDataInQTbyDoanCtac(Guid CongTacId, Decimal LanQuyetToan);
        void MaintainDoanRa(VnsDoanCongTac objDoanCongTac);
    }
}
