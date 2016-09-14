using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain.Report;

namespace QuanLyDoanRa.Reports
{
    public partial class SoChiTietTK_P2 : DevExpress.XtraReports.UI.XtraReport
    {
        public SoChiTietTK_P2()
        {
            InitializeComponent();
        }

        public DataTable GetData(IList<RP_SoDuTaiKhoan> lstData)
        {
            return Commons.Commons.ToDataTable<RP_SoDuTaiKhoan>(lstData);
        }

    }
}
