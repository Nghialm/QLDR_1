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
using Vns.QuanLyDoanRa.Dao.NHibernate;

namespace Vns.QuanLyDoanRa.Service
{
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class VnsHtSoCtMaxService : GenericService<VnsHtSoCtMax, System.Guid>, IVnsHtSoCtMaxService
	{
        public IVnsHtSoCtMaxDao VnsHtSoCtMaxDao
        {
            get { return (IVnsHtSoCtMaxDao)Dao; }
            set { Dao = value; }
        }

        public VnsHtSoCtMax GetByThangNamEtc(Guid LoaichungtuId, int Thang, int Nam)
        {
            return VnsHtSoCtMaxDao.GetByThangNamEtc(LoaichungtuId, Thang, Nam);
        }
	}
}
