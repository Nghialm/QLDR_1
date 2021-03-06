/*
insert license info here
*/
using System;
using System.ComponentModel;
using Vns.Erp.Core.Domain;
using System.Runtime.Serialization;
using System.Collections.Generic;
namespace Vns.QuanLyDoanRa.Domain
{
	/// <summary>
	///	Generated by MyGeneration using the NHibernate Object Mapping adapted by Gustavo And Modified By Hoang Quoc Dung
	/// </summary>

	public partial class VnsDmMucTieuMuc : DomainObject<Guid>
	{
        private VnsDmMucTieuMuc _MucCha;

        public VnsDmMucTieuMuc MucCha
        {
            get { return _MucCha; }
            set { _MucCha = value; }
        }

        public String TenMucCha
        {
            get
            {
                if (_MucCha != null)
                {
                    return _MucCha.TenMuc;
                }
                return null;
            }
        }

        #region Extends Property
        private IList<VnsQuyetToanDoan> _lstQuyetToanDoan;
        [DataMember]
        public IList<VnsQuyetToanDoan> lstQuyetToanDoan
        {
            get { return _lstQuyetToanDoan; }
            set { _lstQuyetToanDoan = value; }
        }
        #endregion
	}
}
