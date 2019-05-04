using System.Collections;
using System.ComponentModel;
using System.Data;
using System;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Dao;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.Erp.Core.Service;
using Vns.Erp.Core.Service.Interface;
namespace Vns.QuanLyDoanRa.Service
{
	public class VnsBangKeService:GenericService<VnsBangKe,System.Guid>, IVnsBangKeService
	{
	    public IVnsBangKeDao VnsBangKeDao
        {
            get { return (IVnsBangKeDao)Dao; }
            set { Dao = value; }
        }
	}
}