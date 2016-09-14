using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Service.Interface;
using Vns.QuanLyDoanRa.Domain.Report;

namespace Vns.QuanLyDoanRa.Service.Interface.Report
{
    public interface IReportService : IErpService<VnsReport, Guid>
    {
        IList<VnsReportTongHop> BaoCaoTongHopDoanRa(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId, decimal p_TrangThaiDct, ReportType TYPE);
        IList<VnsReport> BaoCaoTongHopDoanRa(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId, Guid p_DoanRaId);
        IList<RP_BC04DR> ReportBc04Dr_Detail(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaid, Boolean HienThiQtZero);
        IList<RP_BC04DR> ReportBc04Dr(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId, bool isQuy = false);
        IList<RP_BC05DR> ReportBc05Dr(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId);
        IList<RP_BC06DR> ReportBc06Dr(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId, int type);
        IList<BC03DR> ReportBc03Dr(DateTime p_TuNgay, DateTime p_DenNgay, Guid LoaiDoanRa);

        IList<RP_Doan_CongNo> GetListSoDu(String pTk, DateTime p_TuNgay, DateTime p_DenNgay, Guid p_loaiDoanRaNoId, Guid p_loaiDoanRaCoId, Guid p_GiaoDichId);
        IList<RP_SoDuTaiKhoan> GetListSoDuTaiKhoan(String pTk, DateTime p_TuNgay, DateTime p_DenNgay, Guid p_loaiDoanRaNoId, Guid p_loaiDoanRaCoId);        

        IList<RP_ChungTuGhiSo> RPChungTuGhiSo(DateTime p_TuNgay, DateTime p_DenNgay, string str_TKCo, string str_TKNo, string str_TrangThaiCt, int GiaTri, string TimeTile);
        IList<RP_ChungTuGhiSo> RPChungTuGhiSo_QT(DateTime p_TuNgay, DateTime p_DenNgay, string str_TKCo, string str_TKNo, string str_TrangThaiCt, int GiaTri, string TimeTile);

        IList<VnsReport> BaoCaoTongHopDoanRaChungTuGhiSo(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId, Guid p_DoanRaId);
        IList<PhuBieuChiQT> PhuBieuChiQt(DateTime p_TuNgay, DateTime p_DenNgay, out IList<PhuBieuChiQt_Dem> lst_dem);
        
    }
}
