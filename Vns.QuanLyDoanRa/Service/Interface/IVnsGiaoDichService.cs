
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
    public interface IVnsGiaoDichService : IErpService<VnsGiaoDich, Guid>
    {
        IList<VnsGiaoDich> GetByChungTu(Guid ChungTuId);        
        IList<VnsGiaoDich> GetByDoanRaCoId(Guid DoanRaCoId);
        IList<VnsGiaoDich> GetByDoanRaNoId(Guid DoanRaNoId);
        IList<VnsGiaoDich> GetByMaTKNo(String strMaTKNo);
        IList<VnsGiaoDich> GetByMaTKCo(string strMaTKCo);
        IList<VnsGiaoDich> ListGiaoDichTuNgayDenNgay(DateTime dTuNgay, DateTime dDenNgay, string MaLoaiChungTu);
        Boolean DeleteByChungTu(Guid ChungTuId);
        IList<decimal> GetSoDuNo(string MaTKNo, string MaTKCo, Guid guidDoanRaNoId, Guid guidDoanRaCoId, DateTime NgayChungTu);
        IList<VnsGiaoDich> GetTUByDoanRaId(Guid p_DoanRaId);
        IList<ViewQuyetToan> ListViewQuyetToan(DateTime dTuNgay, DateTime dDenNgay, Guid LoaiDoanRaId);
        IList<ViewTamUngDoanRa> ListViewTamUng(DateTime dTuNgay, DateTime dDenNgay);
        IList<ViewQuyetToan> listHoanThuQuyetToan(DateTime dTuNgay, DateTime dDenNgay, Guid LoaiDoanRaId);
        IList<VnsGiaoDich> GetGiaoDich(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_loaiDoanRaId, Guid p_DoanRaNoId, Guid p_DoanRaCoId, string p_TkNoId, string p_TkCoId, decimal p_TrangThaiPhieu, decimal p_TrangThaiDoanCt);
    }
}
