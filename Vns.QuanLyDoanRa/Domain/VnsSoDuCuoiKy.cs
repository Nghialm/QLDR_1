using System;
using System.ComponentModel;
using Vns.Erp.Core.Domain;
using System.Runtime.Serialization;
namespace Vns.QuanLyDoanRa.Domain
{
    public partial class VnsSoDuCuoiKy : DomainObject<Guid>
    {
        private VnsLoaiDoanRa _objLoaiDoanRa;
        [DataMember]
        public virtual VnsLoaiDoanRa objLoaiDoanRa
        {
            get { return _objLoaiDoanRa; }
            set { _objLoaiDoanRa = value; }
        }
	}
}