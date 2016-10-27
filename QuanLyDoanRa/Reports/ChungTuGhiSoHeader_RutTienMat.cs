using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Domain.Report;

namespace QuanLyDoanRa.Reports
{
    public partial class ChungTuGhiSoHeader_RutTienMat : DevExpress.XtraReports.UI.XtraReport
    {
        public ChungTuGhiSoHeader_RutTienMat()
        {
            InitializeComponent();
        }
        public IList<RP_ChungTuGhiSo> GetData(IList<RP_ChungTuGhiSo> lstData,int type)
        {
            for (int i = 0; i < this.Parameters.Count; i++)
            {
                if (this.Parameters[i].Name == "Type")
                {
                    this.Parameters[i].Value = type;
                }
            }
            return lstData;
        }
    }
}
