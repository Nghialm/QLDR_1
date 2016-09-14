using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Dao;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Domain;

namespace Vns.QuanLyDoanRa.Dao
{
    public interface IRP_BC04DRDao : IDao<RP_BC04DR, Guid>
    {
        //IList<VnsGiaoDich> GetLstGiaoDichByLoaiCt(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRa, string p_MaLoaiChungTu, int p_LoaiPhieu);
        //IList<VnsGiaoDich> GetLstGiaoDich(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaNoId, Guid p_LoaiDoanRaCoId, Guid p_DoanRaNoId, Guid p_DoanRaCoId, string p_TkNoId, string p_TkCoId, string p_MaLoaiChungTu);
        //IList<VnsGiaoDich> GetLstGiaoDich(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaNoId, Guid p_LoaiDoanRaCoId, string p_TkNoId, string p_TkCoId, string p_MaLoaiChungTu);
        //IList<VnsGiaoDich> GetLstGiaoDichByTrangThai(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaNoId, Guid p_LoaiDoanRaCoId, Guid p_DoanRaNoId, Guid p_DoanRaCoId, string p_TkNoId, string p_TkCoId, string p_MaLoaiChungTu, int p_TrangThai);
        //IList<VnsGiaoDich> GetLstGiaoDichByTrangThaiHU(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaNoId, Guid p_LoaiDoanRaCoId, Guid p_DoanRaNoId, Guid p_DoanRaCoId, string p_TkNoId, string p_TkCoId, string p_MaLoaiChungTu, decimal p_trangthai);
    }
}
