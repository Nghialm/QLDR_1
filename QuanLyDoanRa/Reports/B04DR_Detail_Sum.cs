using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Domain.Report;
using System.Collections.Generic;
using System.Data;

namespace QuanLyDoanRa.Reports
{
    public partial class B04DR_Detail_Sum : DevExpress.XtraReports.UI.XtraReport
    {
        public DataTable GetData(IList<RP_BC04DR> lstData)
        {
            return Commons.Commons.ToDataTable<RP_BC04DR>(lstData);
        }
    }
}
