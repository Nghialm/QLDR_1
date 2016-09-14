using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Vns.QuanLyDoanRa.Domain.Report;
using System.Data;
using System.Collections.Generic;

namespace QuanLyDoanRa.Reports
{
    public partial class SoChiTietTK_P3 : DevExpress.XtraReports.UI.XtraReport
    {
        public SoChiTietTK_P3()
        {
            InitializeComponent();
        }

        public DataTable GetData(IList<RP_SoDuTaiKhoan> lstData)
        {
            return Commons.Commons.ToDataTable<RP_SoDuTaiKhoan>(lstData);
        }

    }
}
