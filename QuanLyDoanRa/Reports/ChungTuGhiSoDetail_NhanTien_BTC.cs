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
    public partial class ChungTuGhiSoDetail_NhanTien_BTC : DevExpress.XtraReports.UI.XtraReport
    {
        public ChungTuGhiSoDetail_NhanTien_BTC()
        {
            InitializeComponent();
        }
        public IList<RP_ChungTuGhiSo> GetData(IList<RP_ChungTuGhiSo> lstData)
        {
            return lstData;
        }
    }
}
