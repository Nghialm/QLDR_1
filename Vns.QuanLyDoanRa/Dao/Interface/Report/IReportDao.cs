using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Dao;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Domain;

namespace Vns.QuanLyDoanRa.Dao
{
    public interface IReportDao : IDao<RP_BC04DR, Guid>
    {
        IList<VnsGiaoDich> GetLstGiaoDich(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_loaiDoanRaNoId, Guid p_loaiDoanRaCoId, Guid p_DoanRaNoId, Guid p_DoanRaCoId, string p_TkNoId, string p_TkCoId, decimal p_TrangThaiPhieu, decimal p_TrangThaiDoanCt);
        IList<VnsGiaoDich> GetLstGiaoDichGroupByLoaiDr(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_loaiDoanRaId, string p_TkNoId, string p_TkCoId, decimal p_TrangThaiPhieu, decimal p_TrangThaiDoanCt);
        List<RP_SoDuTaiKhoan> GetSoDuTaiKhoan(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo, string p_TrangThaiCt);
        List<RP_SoDuTaiKhoan> GetBangKeQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo, string p_TrangThaiCt);
        IList<RP_Doan_CongNo> GetLstDoanRaTheoCongNo(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_loaiDoanRaNoId, Guid p_loaiDoanRaCoId, Guid p_DoanRaNoId, Guid p_DoanRaCoId, string p_TkNoId, string p_TkCoId, decimal p_TrangThaiDoanCt);

        IList<RP_Doan_CongNo> GetLstDoanRaTheoTamUngConLai(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_loaiDoanRaNoId, Guid p_loaiDoanRaCoId, Guid p_DoanRaNoId, Guid p_DoanRaCoId, string pTk, string pTkDu, decimal p_TrangThaiDoanCt);
        IList<VnsGiaoDich> GetSoTienTUChuaQuyetToan(DateTime p_TuNgay, DateTime p_DenNgay, Guid LoaiDoanRa, string p_TkNo, string p_TkCo, decimal p_TrangThaiPhieu, bool isThangTruoc);
        IList<VnsDoanCongTac> GetListDoanRa(DateTime p_TuNgay, DateTime p_DenNgay, Guid LoaiDoanRa);

        IList<RP_Doan_CongNo> GetListSoDu(String pTk, DateTime p_TuNgay, DateTime p_DenNgay, Guid p_loaiDoanRaNoId, Guid p_loaiDoanRaCoId, Guid p_GiaoDichId);
    }
}
