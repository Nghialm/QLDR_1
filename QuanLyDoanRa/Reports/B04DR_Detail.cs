using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Domain.Report;
using System.Collections.Generic;

namespace QuanLyDoanRa.Reports
{
    public partial class B04DR_Detail : DevExpress.XtraReports.UI.XtraReport
    {
        public IReportService ReportService;

        private DateTime m_TuNgay;
        private DateTime m_DenNgay;
        private Guid m_LoaiDoanRaId;
        private string m_TenLoaiDoanRa;
        string m_time;
        bool checkzero;
        IList<RP_BC04DR> lstData;
        public B04DR_Detail()
        {
            InitializeComponent();
        }

        public B04DR_Detail(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId, string p_TenLoaiDoanRa, string Time, Boolean _checkzero)
        {
            InitializeComponent();
            m_TuNgay = p_TuNgay;
            m_DenNgay = p_DenNgay;
            m_LoaiDoanRaId = p_LoaiDoanRaId;
            m_TenLoaiDoanRa = p_TenLoaiDoanRa;
            m_time = Time;
            checkzero = _checkzero;
            ReportService = (IReportService)ObjectFactory.GetObject("ReportService");
            lstData = ReportService.ReportBc04Dr_Detail(m_TuNgay, m_DenNgay, m_LoaiDoanRaId, checkzero);
        }

        private void B04DR_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (m_TenLoaiDoanRa =="")
                lblTenBc.Text = "BẢNG TỔNG HỢP KINH PHÍ ĐOÀN RA";
            else
                lblTenBc.Text = "BẢNG TỔNG HỢP KINH PHÍ ĐOÀN RA "+ m_TenLoaiDoanRa.ToUpper();

            lblTime.Text = m_time;
            
            lblChucDanhNguoiKiBangBieu.Text = General.ChucDanhNguoiKyBangBieu;
            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;
            lblTenNguoiKiBangBieu.Text = General.TenNguoiKyBangBieu;
            lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;
            this.DataSource = lstData;
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            IList<RP_BC04DR> lst = new List<RP_BC04DR>();
            RP_BC04DR obj1 = new RP_BC04DR();
            RP_BC04DR obj2 = new RP_BC04DR();
            RP_BC04DR obj3 = new RP_BC04DR();
            RP_BC04DR obj4 = new RP_BC04DR();
            RP_BC04DR obj5 = new RP_BC04DR();
            RP_BC04DR obj6 = new RP_BC04DR();
            RP_BC04DR obj7 = new RP_BC04DR();
            foreach (RP_BC04DR obj in lstData)
            {
                if (obj.MaNoiDung == "1")
                {
                    obj1.NoiDung = "01-Tổng";
                    obj1.TongUSD += obj.TongUSD;
                    obj1.TongVND += obj.TongVND;
                    obj1.TienMatUSD += obj.TienMatUSD;
                    obj1.TienMatVND_QD += obj.TienMatVND_QD;
                    obj1.ChuyenKhoanUSD += obj.ChuyenKhoanUSD;
                    obj1.ChuyenKhoanVND += obj.ChuyenKhoanVND;
                }

                if (obj.MaNoiDung == "2")
                {
                    obj2.NoiDung = "02-Tổng";
                    obj2.TongUSD += obj.TongUSD;
                    obj2.TongVND += obj.TongVND;
                    obj2.TienMatUSD += obj.TienMatUSD;
                    obj2.TienMatVND_QD += obj.TienMatVND_QD;
                    obj2.ChuyenKhoanUSD += obj.ChuyenKhoanUSD;
                    obj2.ChuyenKhoanVND += obj.ChuyenKhoanVND;
                }

                if (obj.MaNoiDung == "3")
                {
                    obj3.NoiDung = "03-Tổng";
                    obj3.TongUSD += obj.TongUSD;
                    obj3.TongVND += obj.TongVND;
                    obj3.TienMatUSD += obj.TienMatUSD;
                    obj3.TienMatVND_QD += obj.TienMatVND_QD;
                    obj3.ChuyenKhoanUSD += obj.ChuyenKhoanUSD;
                    obj3.ChuyenKhoanVND += obj.ChuyenKhoanVND;
                }

                if (obj.MaNoiDung == "4")
                {
                    obj4.NoiDung = "04-Tổng";
                    obj4.TongUSD += obj.TongUSD;
                    obj4.TongVND += obj.TongVND;
                    obj4.TienMatUSD += obj.TienMatUSD;
                    obj4.TienMatVND_QD += obj.TienMatVND_QD;
                    obj4.ChuyenKhoanUSD += obj.ChuyenKhoanUSD;
                    obj4.ChuyenKhoanVND += obj.ChuyenKhoanVND;
                }

                if (obj.MaNoiDung == "5")
                {
                    obj5.NoiDung = "05-Tổng";
                    obj5.TongUSD += obj.TongUSD;
                    obj5.TongVND += obj.TongVND;
                    obj5.TienMatUSD += obj.TienMatUSD;
                    obj5.TienMatVND_QD += obj.TienMatVND_QD;
                    obj5.ChuyenKhoanUSD += obj.ChuyenKhoanUSD;
                    obj5.ChuyenKhoanVND += obj.ChuyenKhoanVND;
                }

                if (obj.MaNoiDung == "6")
                {
                    obj6.NoiDung = "06-Tổng";
                    obj6.TongUSD += obj.TongUSD;
                    obj6.TongVND += obj.TongVND;
                    obj6.TienMatUSD += obj.TienMatUSD;
                    obj6.TienMatVND_QD += obj.TienMatVND_QD;
                    obj6.ChuyenKhoanUSD += obj.ChuyenKhoanUSD;
                    obj6.ChuyenKhoanVND += obj.ChuyenKhoanVND;
                }

                if (obj.MaNoiDung == "7")
                {
                    obj7.NoiDung = "07-Tổng";
                    obj7.TongUSD += obj.TongUSD;
                    obj7.TongVND += obj.TongVND;
                    obj7.TienMatUSD += obj.TienMatUSD;
                    obj7.TienMatVND_QD += obj.TienMatVND_QD;
                    obj7.ChuyenKhoanUSD += obj.ChuyenKhoanUSD;
                    obj7.ChuyenKhoanVND += obj.ChuyenKhoanVND;
                }
            }
            lst.Add(obj1);
            lst.Add(obj2);
            lst.Add(obj3);
            lst.Add(obj4);
            lst.Add(obj5);
            lst.Add(obj6);
            lst.Add(obj7);
            B04DR_Detail_Sum p2 = (B04DR_Detail_Sum)((XRSubreport)sender).ReportSource;
            p2.DataSource = p2.GetData(lst);
        }
        int i = 0;
        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            i++;
            if (i == 1)
                e.Cancel = true;
        }

    }
}
