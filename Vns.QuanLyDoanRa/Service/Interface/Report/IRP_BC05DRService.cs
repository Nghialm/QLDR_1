﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core.Service.Interface;
using Vns.QuanLyDoanRa.Domain.Report;

namespace Vns.QuanLyDoanRa.Service.Interface.Report
{
    public interface IRP_BC05DRService : IErpService<RP_BC05DR, Guid>
    {
        List<RP_BC05DR> GetListData(DateTime p_TuNgay, DateTime p_DenNgay);
    }
}
