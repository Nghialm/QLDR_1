/*
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

	public partial class VnsDanhMucChucVu : DomainObject<Guid>
	{
        public static int CompareTenChucVu(VnsDanhMucChucVu x, VnsDanhMucChucVu y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retvalSoQuyetToan = 0;
                    //int revalSoChungTu = 0;
                    retvalSoQuyetToan = x.TenChucVu.CompareTo(y.TenChucVu);
                    return retvalSoQuyetToan;
                }
            }
        }
	}
}
