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
    public partial class rpInDuToanQuyetToan : DevExpress.XtraReports.UI.XtraReport
    {
        private IList<VnsInQtTu> m_lst;
        private VnsDoanCongTac m_objDoanRa;
        private String LoaiDoanRa = "";
        private bool KieuBaoCao = false;
        public rpInDuToanQuyetToan()
        {
            InitializeComponent();
        }
        public rpInDuToanQuyetToan(IList<VnsInQtTu> p_lst, VnsDoanCongTac p_objDoanRa, string Flag, bool p_KieuBaoCao)
        {
            InitializeComponent();
            m_lst = p_lst;
            m_objDoanRa = p_objDoanRa;
            LoaiDoanRa = Flag;
            KieuBaoCao = p_KieuBaoCao;
        }
        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            InBiaQuyetToan bia = (InBiaQuyetToan)((XRSubreport)sender).ReportSource;
            bia.LoadData(m_lst, m_objDoanRa, LoaiDoanRa, KieuBaoCao);//p1.GetData(lstData, 1);            
        }

        private void xrSubreport2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            InQuyetToan QT = (InQuyetToan)((XRSubreport)sender).ReportSource;
            QT.LoadData(m_lst, m_objDoanRa, LoaiDoanRa);
        }

    }
}
