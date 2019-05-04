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
	public class VnsBangKeChiTietService:GenericService<VnsBangKeChiTiet,System.Guid>, IVnsBangKeChiTietService
	{
	    public IVnsBangKeChiTietDao VnsBangKeChiTietDao
        {
            get { return (IVnsBangKeChiTietDao)Dao; }
            set { Dao = value; }
        }
	}
}