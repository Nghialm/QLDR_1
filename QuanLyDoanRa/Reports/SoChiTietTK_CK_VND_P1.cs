using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Vns.QuanLyDoanRa.Domain.Report;
using System.Data;
using System.Collections.Generic;
using Vns.Erp.Core;

namespace QuanLyDoanRa.Reports
{
    public partial class SoChiTietTK_CK_VND_P1 : DevExpress.XtraReports.UI.XtraReport
    {
        public SoChiTietTK_CK_VND_P1()
        {
            InitializeComponent();
        }

        public DataTable GetData(IList<RP_SoDuTaiKhoan> lstData, string sTk)
        {
            if (sTk == Vns.QuanLyDoanRa.Globals.TkTienChuyenKhoan)
            {
                xrTableCell4.Text = "Số QT TD QT";
            }
            else
            {
                //xrTableCell4.Text = "Ngày tháng ghi sổ";
            }
            return Commons.Commons.ToDataTable<RP_SoDuTaiKhoan>(lstData);
        }

    }
}
