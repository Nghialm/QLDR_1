/*
insert license info here
*/
using System.Collections;
using System.ComponentModel;
using System.Data;
using System;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Dao;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.Erp.Core.Service;
using Vns.Erp.Core.Service.Interface;
using System.Collections.Generic;
namespace Vns.QuanLyDoanRa.Service
{
    /// <summary>
    ///	Generated by MyGeneration using the NHibernate Object Mapping adapted by Gustavo
    /// </summary>	
    //,IVnsDinhMucService
    public class VnsDinhMucService : GenericService<VnsDinhMuc, Guid>, IVnsDinhMucService
    {
        public IVnsDinhMucDao VnsDinhMucDao
        {
            get { return (IVnsDinhMucDao)Dao; }
            set { Dao = value; }
        }

        public IList<VnsDinhMuc> GetByNgayApDung(DateTime NgayApDung, Decimal DinhMuc, bool flag)
        {
            return VnsDinhMucDao.GetByNgayApDung(NgayApDung,DinhMuc,flag);
        }
    }
}
