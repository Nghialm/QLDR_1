
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
		public interface IVnsLoaiChungTuService:IErpService<VnsLoaiChungTu, Guid>
		{
            VnsLoaiChungTu GetByMa(String MaLoaiChungTu);
            List<string> GetSoCT_prefix(Guid LOAICHUNGTU_ID, int THANG, int NAM);
            IList<VnsLoaiChungTu> GetByGroup(string MaDmCha);
		}


	}
	