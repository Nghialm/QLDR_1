using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Domain.Report;

namespace QuanLyDoanRa.Reports
{
    public partial class ChungTuGhiSoDetail_V2 : DevExpress.XtraReports.UI.XtraReport
    {
        public ChungTuGhiSoDetail_V2()
        {
            InitializeComponent();
        }
        public IList<RP_ChungTuGhiSo> GetData(IList<RP_ChungTuGhiSo> lstData)
        {
            return lstData;
        }
    }
}
