
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
    public interface IVnsChungTuService : IErpService<VnsChungTu, Guid>
    {
        IList<VnsChungTu> LoadByChungTu(String MaLoaiChungTu);
        IList<VnsChungTu> ListChungTuDenNgay(DateTime dNgayChungTu);
        IList<VnsChungTu> ListChungTuTuNgayDenNgay(DateTime dTuNgay, DateTime dDenNgay, string strMaLoaiChungTu);
        void SaveChungTu(Boolean InsertFlg, VnsChungTu objChungTu, IList<VnsGiaoDich> lstGiaoDich, IList<VnsGiaoDich> lstDeleteGiaoDich);
        IList<VnsChungTu> SearchChungTu(String p_MaLoaiCt, DateTime p_TuNgay, DateTime p_DenNgay, String p_MaTkNo, String p_MaTkCo, Guid p_DoanRaId, Guid p_LoaiDoanRaId, Decimal p_SoTienTu, Decimal p_SoTienDen, String p_NguoiTamUng, String p_NoiDung);
        Int32 GetRowCount(string p_maLoaiCt);
        void DeleteChungTu(VnsChungTu objChungTu);
    }
}
