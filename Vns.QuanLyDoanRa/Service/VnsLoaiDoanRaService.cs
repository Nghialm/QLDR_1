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
namespace Vns.QuanLyDoanRa.Service
{
	/// <summary>
	///	Generated by MyGeneration using the NHibernate Object Mapping adapted by Gustavo
	/// </summary>	
	//,IVnsLoaiDoanRaService
	public class VnsLoaiDoanRaService:GenericService<VnsLoaiDoanRa,Guid>, IVnsLoaiDoanRaService
	{
	     public IVnsLoaiDoanRaDao VnsLoaiDoanRaDao
        {
            get { return (IVnsLoaiDoanRaDao)Dao; }
            set { Dao = value; }
        }
	}
}
