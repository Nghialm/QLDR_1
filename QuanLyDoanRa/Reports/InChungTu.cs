using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;
using System.Collections.Generic;
using System.Data;
using Vns.QuanLyDoanRa.Domain;

namespace QuanLyDoanRa.Reports
{
    public partial class InChungTu : DevExpress.XtraReports.UI.XtraReport
    {
        private IList<Info> m_lstParam;
        private DataTable m_DtSource;
        public InChungTu()
        {
            InitializeComponent();
        }

        public InChungTu(IList<Info> p_lstparam, DataTable p_dtSource)
        {
            InitializeComponent();
            m_lstParam = p_lstparam;
            m_DtSource = p_dtSource;
        }

        private void InChungTu_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                Commons.Report.SetParamValue(m_lstParam, this.Parameters);
                this.DataSource = m_DtSource;
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

    }
}
