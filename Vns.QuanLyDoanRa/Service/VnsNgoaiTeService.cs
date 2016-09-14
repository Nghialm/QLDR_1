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
	public class VnsNgoaiTeService:GenericService<VnsNgoaiTe,System.Guid>, IVnsNgoaiTeService
	{
	    public IVnsNgoaiTeDao VnsNgoaiTeDao
        {
            get { return (IVnsNgoaiTeDao)Dao; }
            set { Dao = value; }
        }
	}
}