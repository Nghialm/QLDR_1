﻿/*
insert license info here
*/
using System;
using System.ComponentModel;
using Vns.Erp.Core.Domain;
using System.Runtime.Serialization;
namespace Vns.QuanLyDoanRa.Domain
{
	/// <summary>
	///	Generated by MyGeneration using the NHibernate Object Mapping adapted by Gustavo And Modified By Hoang Quoc Dung
	/// </summary>

	public partial class VnsDuToanDoan : DomainObject<Guid>
	{
        private VnsDmMucTieuMuc _Muc;
        public Vns.QuanLyDoanRa.Domain.VnsDmMucTieuMuc Muc
        {
            get { return _Muc; }
            set { _Muc = value; }
        }

        public String TenMuc
        {
            get
            {
                if (_Muc != null)
                {
                    return _Muc.TenMuc;
                }
                return null;
            }
        }

        public VnsQuyetToanDoan GenQuyetToanDoan()
        {
            VnsQuyetToanDoan objQuyetToan = new VnsQuyetToanDoan();
            objQuyetToan.LichCongTacId = _lichcongtacid;
            objQuyetToan.CongTacId = _congtacid;
            objQuyetToan.MucId = _mucid;
            objQuyetToan.TenKhoanChi = _tenkhoanchi;
            objQuyetToan.SoTien = _sotiendutoan;
            objQuyetToan.SoTienVND = _SoTienDuToanVND;
            objQuyetToan.NgoaiTeId = _NgoaiTeId;
            objQuyetToan.DienGiai = _diengiai;

            return objQuyetToan;
        }

        public String DienGiaiDuToan
        {
            get
            {
                if (_LanDuToan == 0) return "Ban đầu";
                else return "Bổ sung";
            }
        }
	}
}
