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
    //[ServiceContract(Namespace = "http://SpringSample.Core.Service")]
    public interface IVnsHtSoCtMaxService : IErpService<VnsHtSoCtMax, System.Guid>
	{
        VnsHtSoCtMax GetByThangNamEtc(Guid LoaichungtuId, int Thang, int Nam);
	}
}
