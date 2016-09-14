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
    public partial class PhuBieuTongHopKinhPhiDoanRa : DevExpress.XtraReports.UI.XtraReport
    {
        public IReportService ReportService;
        public IRP_BC04DRService RP_BC04DRService;
        private DateTime m_TuNgay;
        private DateTime m_DenNgay;
        private Guid m_LoaiDoanRaId;
        private string m_TenLoaiDoanRa;
        string m_time;
        public PhuBieuTongHopKinhPhiDoanRa()
        {
            InitializeComponent();
        }

        public PhuBieuTongHopKinhPhiDoanRa(DateTime p_TuNgay, DateTime p_DenNgay, Guid p_LoaiDoanRaId, string p_TenLoaiDoanRa, string Time)
        {
            InitializeComponent();
            m_TuNgay = p_TuNgay;
            m_DenNgay = p_DenNgay;
            m_LoaiDoanRaId = p_LoaiDoanRaId;
            m_TenLoaiDoanRa = p_TenLoaiDoanRa;
            m_time = Time;
        }

        private void B04DR_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (m_TenLoaiDoanRa == "")
                lblTenBc.Text = "BẢNG TỔNG HỢP KINH PHÍ ĐOÀN RA";
            else
                lblTenBc.Text = string.Format("{0} {1}", "BẢNG TỔNG HỢP KINH PHÍ ĐOÀN RA", m_TenLoaiDoanRa.ToUpper());

            lblTime.Text = m_time;
            ReportService = (IReportService)ObjectFactory.GetObject("ReportService");
            RP_BC04DRService = (IRP_BC04DRService)ObjectFactory.GetObject("RP_BC04DRService");
            lblChucDanhNguoiKiBangBieu.Text = General.ChucDanhNguoiKyBangBieu;
            lblChucDanhNguoiLapBieu.Text = General.ChucDanhNguoiLapBieu;
            lblTenNguoiKiBangBieu.Text = General.TenNguoiKyBangBieu;
            lblTenNguoiLapBieu.Text = General.TenNguoiLapBieu;
            lblSignDate.Text = General.GenSignDate(m_DenNgay);
            this.DataSource = getDataSource(m_TuNgay, m_LoaiDoanRaId);
        }

        private IList<RP_BC04DR> getDataSource(DateTime p_TuNgay, Guid m_loaiDoanRaId)
        {
            IList<RP_BC04DR> lstDataSource = new List<RP_BC04DR>();
            DateTime dt_01_Start = p_TuNgay;
            DateTime dt_01_End = dt_01_Start.AddMonths(1).AddDays(-1);

            DateTime dt_02_Start = p_TuNgay.AddMonths(1);
            DateTime dt_02_End = dt_02_Start.AddMonths(1).AddDays(-1);

            DateTime dt_03_Start = dt_02_Start.AddMonths(1);
            DateTime dt_03_End = dt_03_Start.AddMonths(1).AddDays(-1);

            DateTime dt_04_Start = dt_03_Start.AddMonths(1);
            DateTime dt_04_End = dt_04_Start.AddMonths(1).AddDays(-1);
            
            string temp = "- Tháng {0}";

            List<RP_BC04DR> lstNhom = new List<RP_BC04DR>();

            if (p_TuNgay.Month == 2)
            {
                IList<RP_BC04DR> lst01 = ReportService.ReportBc04Dr(dt_01_Start, dt_01_End, m_loaiDoanRaId, true);
                IList<RP_BC04DR> lst02 = ReportService.ReportBc04Dr(dt_02_Start, dt_02_End, m_loaiDoanRaId, true);
                RP_BC04DR phiChuyenTien = GetPhiChuyenTien(dt_01_Start, dt_02_End, m_loaiDoanRaId);
                //Chi tieu 01
                RP_BC04DR Dong1 = lst01[0];
                Dong1.NoiDung = string.Format(Dong1.NoiDung, GetQuyTruoc(p_TuNgay));
                lstDataSource.Add(Dong1);

                //Chi tieu 02
                //RP_BC04DR Dong2 = SumQuy01(lst01[1], lst02[1]);
                lstNhom = new List<RP_BC04DR>();
                lstNhom.Add(lst01[1]); lstNhom.Add(lst02[1]);
                RP_BC04DR Dong2 = SumQuy(lstNhom);
                Dong2.NoiDung = string.Format("Số tiền tạm ứng {0} ", GetQuy(p_TuNgay));
                Dong2.MaNoiDung = "2";
                lstDataSource.Add(Dong2);
                RP_BC04DR dong02_01 = lst01[1];
                dong02_01.NoiDung = string.Format(temp, dt_01_Start.Month);
                dong02_01.MaNoiDung = "";
                lstDataSource.Add(dong02_01);
                RP_BC04DR dong02_02 = lst02[1];
                dong02_02.NoiDung = string.Format(temp, dt_02_Start.Month);
                dong02_02.MaNoiDung = "";
                lstDataSource.Add(dong02_02);

                //Chi tieu 03
                //RP_BC04DR Dong3 = SumQuy01(lst01[2], lst02[2]);
                lstNhom = new List<RP_BC04DR>();
                lstNhom.Add(lst01[2]); lstNhom.Add(lst02[2]); lstNhom.Add(phiChuyenTien);
                RP_BC04DR Dong3 = SumQuy(lstNhom);
                Dong3.NoiDung = string.Format("Số quyết toán {0} ", GetQuy(p_TuNgay));
                Dong3.MaNoiDung = "3";
                lstDataSource.Add(Dong3);
                lstDataSource.Add(phiChuyenTien);

                RP_BC04DR dong03_01 = lst01[2];
                dong03_01.NoiDung = string.Format(temp, dt_01_Start.Month);
                dong03_01.MaNoiDung = "";
                lstDataSource.Add(dong03_01);
                RP_BC04DR dong03_02 = lst02[2];
                dong03_02.NoiDung = string.Format(temp, dt_02_Start.Month);
                dong03_02.MaNoiDung = "";
                lstDataSource.Add(dong03_02);

                //Chi tieu 04
                //RP_BC04DR Dong4 = SumQuy01(lst01[3], lst02[3]);
                lstNhom = new List<RP_BC04DR>();
                lstNhom.Add(lst01[3]); lstNhom.Add(lst02[3]); lstNhom.Add(phiChuyenTien);
                RP_BC04DR Dong4 = SumQuy(lstNhom);

                Dong4.NoiDung = string.Format("Số chi quyết toán {0}  ", GetQuy(p_TuNgay));
                Dong4.MaNoiDung = "4";
                lstDataSource.Add(Dong4);
                lstDataSource.Add(phiChuyenTien);

                RP_BC04DR dong04_01 = lst01[3];
                dong04_01.NoiDung = string.Format(temp, dt_01_Start.Month);
                dong04_01.MaNoiDung = "";
                lstDataSource.Add(dong04_01);
                RP_BC04DR dong04_02 = lst02[3];
                dong04_02.NoiDung = string.Format(temp, dt_02_Start.Month);
                dong04_02.MaNoiDung = "";
                lstDataSource.Add(dong04_02);

                //Chi tieu 05
                RP_BC04DR Dong5 = SumQuy01(lst01[4], lst02[4]);
                Dong5.NoiDung = string.Format("Số thu hoàn tạm ứng {0} ", GetQuy(p_TuNgay));
                Dong5.MaNoiDung = "5";
                lstDataSource.Add(Dong5);
                RP_BC04DR dong05_01 = lst01[4];
                dong05_01.NoiDung = string.Format(temp, dt_01_Start.Month);
                dong05_01.MaNoiDung = "";
                lstDataSource.Add(dong05_01);
                RP_BC04DR dong05_02 = lst02[4];
                dong05_02.NoiDung = string.Format(temp, dt_02_Start.Month);
                dong05_02.MaNoiDung = "";
                lstDataSource.Add(dong05_02);

                //Chi tieu 06
                RP_BC04DR Dong6 = SumQuy01(lst01[5], lst02[5]);
                Dong6.NoiDung = string.Format("Số phải thu trong {0} ", GetQuy(p_TuNgay));
                Dong6.MaNoiDung = "6";
                lstDataSource.Add(Dong6);
                RP_BC04DR dong06_01 = lst01[5];
                dong06_01.NoiDung = string.Format(temp, dt_01_Start.Month);
                dong06_01.MaNoiDung = "";
                lstDataSource.Add(dong06_01);
                RP_BC04DR dong06_02 = lst02[5];
                dong06_02.NoiDung = string.Format(temp, dt_02_Start.Month);
                dong06_02.MaNoiDung = "";
                lstDataSource.Add(dong06_02);

                //Chi tieu 06
                RP_BC04DR Dong7 = lst02[6];
                Dong7.MaNoiDung = "7";
                Dong7.NoiDung = string.Format("Số tiền chưa quyết toán chuyển sang {0}", GetQuy(dt_02_Start.AddMonths(1)));
                lstDataSource.Add(Dong7);

            }
            else if (p_TuNgay.Month == 10)
            {
                IList<RP_BC04DR> lst01 = ReportService.ReportBc04Dr(dt_01_Start, dt_01_End, m_loaiDoanRaId, true);
                IList<RP_BC04DR> lst02 = ReportService.ReportBc04Dr(dt_02_Start, dt_02_End, m_loaiDoanRaId, true);
                IList<RP_BC04DR> lst03 = ReportService.ReportBc04Dr(dt_03_Start, dt_03_End, m_loaiDoanRaId, true);
                IList<RP_BC04DR> lst04 = ReportService.ReportBc04Dr(dt_04_Start, dt_04_End, m_loaiDoanRaId, true);
                RP_BC04DR phiChuyenTien = GetPhiChuyenTien(dt_01_Start, dt_04_End, m_loaiDoanRaId);
                //Chi tieu 01
                RP_BC04DR Dong1 = lst01[0];
                Dong1.NoiDung = string.Format(Dong1.NoiDung, GetQuyTruoc(p_TuNgay));
                lstDataSource.Add(Dong1);

                //Chi tieu 02
                RP_BC04DR Dong2 = SumQuy04(lst01[1], lst02[1], lst03[1], lst04[1]);
                Dong2.NoiDung = string.Format("Số tiền tạm ứng {0} ", GetQuy(p_TuNgay));
                Dong2.MaNoiDung = "2";
                lstDataSource.Add(Dong2);
                RP_BC04DR dong02_01 = lst01[1];
                dong02_01.NoiDung = string.Format(temp, dt_01_Start.Month);
                dong02_01.MaNoiDung = "";
                lstDataSource.Add(dong02_01);
                RP_BC04DR dong02_02 = lst02[1];
                dong02_02.NoiDung = string.Format(temp, dt_02_Start.Month);
                dong02_02.MaNoiDung = "";
                lstDataSource.Add(dong02_02);
                RP_BC04DR dong02_03 = lst03[1];
                dong02_03.NoiDung = string.Format(temp, dt_03_Start.Month);
                dong02_03.MaNoiDung = "";
                lstDataSource.Add(dong02_03);
                RP_BC04DR dong02_04 = lst04[1];
                dong02_04.NoiDung = string.Format(temp, dt_04_Start.Month);
                dong02_04.MaNoiDung = "";
                lstDataSource.Add(dong02_04);

                //Chi tieu 03
                //RP_BC04DR Dong3 = SumQuy04(lst01[2], lst02[2], lst03[2], lst04[2]);

                lstNhom = new List<RP_BC04DR>();
                lstNhom.Add(lst01[2]); lstNhom.Add(lst02[2]); lstNhom.Add(lst03[2]); lstNhom.Add(lst04[2]); lstNhom.Add(phiChuyenTien);
                RP_BC04DR Dong3 = SumQuy(lstNhom);

                Dong3.NoiDung = string.Format("Số quyết toán {0} ", GetQuy(p_TuNgay));
                Dong3.MaNoiDung = "3";
                lstDataSource.Add(Dong3);
                lstDataSource.Add(phiChuyenTien);
                RP_BC04DR dong03_01 = lst01[2];
                dong03_01.NoiDung = string.Format(temp, dt_01_Start.Month);
                dong03_01.MaNoiDung = "";
                lstDataSource.Add(dong03_01);
                RP_BC04DR dong03_02 = lst02[2];
                dong03_02.NoiDung = string.Format(temp, dt_02_Start.Month);
                dong03_02.MaNoiDung = "";
                lstDataSource.Add(dong03_02);
                RP_BC04DR dong03_03 = lst03[2];
                dong03_03.NoiDung = string.Format(temp, dt_03_Start.Month);
                dong03_03.MaNoiDung = "";
                lstDataSource.Add(dong03_03);
                RP_BC04DR dong03_04 = lst04[2];
                dong03_04.NoiDung = string.Format(temp, dt_04_Start.Month);
                dong03_04.MaNoiDung = "";
                lstDataSource.Add(dong03_04);

                //Chi tieu 04
                //RP_BC04DR Dong4 = SumQuy04(lst01[3], lst02[3], lst03[3], lst04[3]);

                lstNhom = new List<RP_BC04DR>();
                lstNhom.Add(lst01[3]); lstNhom.Add(lst02[3]); lstNhom.Add(lst03[3]); lstNhom.Add(lst04[3]); lstNhom.Add(phiChuyenTien);
                RP_BC04DR Dong4 = SumQuy(lstNhom);

                Dong4.NoiDung = string.Format("Số chi quyết toán {0}  ", GetQuy(p_TuNgay));
                Dong4.MaNoiDung = "4";
                lstDataSource.Add(Dong4);
                lstDataSource.Add(phiChuyenTien);
                RP_BC04DR dong04_01 = lst01[3];
                dong04_01.NoiDung = string.Format(temp, dt_01_Start.Month);
                dong04_01.MaNoiDung = "";
                lstDataSource.Add(dong04_01);
                RP_BC04DR dong04_02 = lst02[3];
                dong04_02.NoiDung = string.Format(temp, dt_02_Start.Month);
                dong04_02.MaNoiDung = "";
                lstDataSource.Add(dong04_02);
                RP_BC04DR dong04_03 = lst03[3];
                dong04_03.NoiDung = string.Format(temp, dt_03_Start.Month);
                dong04_03.MaNoiDung = "";
                lstDataSource.Add(dong04_03);
                RP_BC04DR dong04_04 = lst04[3];
                dong04_04.NoiDung = string.Format(temp, dt_04_Start.Month);
                dong04_04.MaNoiDung = "";
                lstDataSource.Add(dong04_04);

                //Chi tieu 05
                RP_BC04DR Dong5 = SumQuy04(lst01[4], lst02[4], lst03[4], lst04[4]);
                Dong5.NoiDung = string.Format("Số thu hoàn tạm ứng {0} ", GetQuy(p_TuNgay));
                Dong5.MaNoiDung = "5";
                lstDataSource.Add(Dong5);
                RP_BC04DR dong05_01 = lst01[4];
                dong05_01.NoiDung = string.Format(temp, dt_01_Start.Month);
                dong05_01.MaNoiDung = "";
                lstDataSource.Add(dong05_01);
                RP_BC04DR dong05_02 = lst02[4];
                dong05_02.NoiDung = string.Format(temp, dt_02_Start.Month);
                dong05_02.MaNoiDung = "";
                lstDataSource.Add(dong05_02);
                RP_BC04DR dong05_03 = lst03[4];
                dong05_03.NoiDung = string.Format(temp, dt_03_Start.Month);
                dong05_03.MaNoiDung = "";
                lstDataSource.Add(dong05_03);
                RP_BC04DR dong05_04 = lst04[4];
                dong05_04.NoiDung = string.Format(temp, dt_04_Start.Month);
                dong05_04.MaNoiDung = "";
                lstDataSource.Add(dong05_04);

                //Chi tieu 06
                RP_BC04DR Dong6 = SumQuy04(lst01[5], lst02[5], lst03[5], lst04[5]);
                Dong6.NoiDung = string.Format("Số phải thu trong kỳ {0} ", GetQuy(p_TuNgay));
                Dong6.MaNoiDung = "6";
                lstDataSource.Add(Dong6);
                RP_BC04DR dong06_01 = lst01[5];
                dong06_01.NoiDung = string.Format(temp, dt_01_Start.Month);
                dong06_01.MaNoiDung = "";
                lstDataSource.Add(dong06_01);
                RP_BC04DR dong06_02 = lst02[5];
                dong06_02.NoiDung = string.Format(temp, dt_02_Start.Month);
                dong06_02.MaNoiDung = "";
                lstDataSource.Add(dong06_02);
                RP_BC04DR dong06_03 = lst03[5];
                dong06_03.NoiDung = string.Format(temp, dt_03_Start.Month);
                dong06_03.MaNoiDung = "";
                lstDataSource.Add(dong06_03);
                RP_BC04DR dong06_04 = lst04[5];
                dong06_04.NoiDung = string.Format(temp, dt_04_Start.Month);
                dong06_04.MaNoiDung = "";
                lstDataSource.Add(dong06_04);

                //Chi tieu 06
                RP_BC04DR Dong7 = lst04[6];
                Dong7.MaNoiDung = "7";
                Dong7.NoiDung = string.Format("Số tiền chưa quyết toán chuyển sang {0}", GetQuy(dt_04_Start.AddMonths(1)));
                lstDataSource.Add(Dong7);
            }
            else
            {
                IList<RP_BC04DR> lst01 = ReportService.ReportBc04Dr(dt_01_Start, dt_01_End, m_loaiDoanRaId, true);
                IList<RP_BC04DR> lst02 = ReportService.ReportBc04Dr(dt_02_Start, dt_02_End, m_loaiDoanRaId, true);
                IList<RP_BC04DR> lst03 = ReportService.ReportBc04Dr(dt_03_Start, dt_03_End, m_loaiDoanRaId, true);
                RP_BC04DR phiChuyenTien = GetPhiChuyenTien(dt_01_Start, dt_03_End, m_loaiDoanRaId);
                //Chi tieu 01
                RP_BC04DR Dong1 = lst01[0];
                Dong1.NoiDung = string.Format(Dong1.NoiDung, GetQuyTruoc(p_TuNgay));
                lstDataSource.Add(Dong1);

                //Chi tieu 02
                RP_BC04DR Dong2 = SumQuy023(lst01[1], lst02[1], lst03[1]);
                Dong2.NoiDung = string.Format("Số tiền tạm ứng {0} ", GetQuy(p_TuNgay));
                Dong2.MaNoiDung = "2";
                lstDataSource.Add(Dong2);
                RP_BC04DR dong02_01 = lst01[1];
                dong02_01.NoiDung = string.Format(temp, dt_01_Start.Month);
                dong02_01.MaNoiDung = "";
                lstDataSource.Add(dong02_01);
                RP_BC04DR dong02_02 = lst02[1];
                dong02_02.NoiDung = string.Format(temp, dt_02_Start.Month);
                dong02_02.MaNoiDung = "";
                lstDataSource.Add(dong02_02);
                RP_BC04DR dong02_03 = lst03[1];
                dong02_03.NoiDung = string.Format(temp, dt_03_Start.Month);
                dong02_03.MaNoiDung = "";
                lstDataSource.Add(dong02_03);

                //Chi tieu 03
                //RP_BC04DR Dong3 = SumQuy023(lst01[2], lst02[2], lst03[2]);

                lstNhom = new List<RP_BC04DR>();
                lstNhom.Add(lst01[2]); lstNhom.Add(lst02[2]); lstNhom.Add(lst03[2]); lstNhom.Add(phiChuyenTien);
                RP_BC04DR Dong3 = SumQuy(lstNhom);

                Dong3.NoiDung = string.Format("Số quyết toán {0} ", GetQuy(p_TuNgay));
                Dong3.MaNoiDung = "3";
                
                //Dong3.TienMatUSD += phiChuyenTien.TienMatUSD;

                lstDataSource.Add(Dong3);
                lstDataSource.Add(phiChuyenTien);
                RP_BC04DR dong03_01 = lst01[2];
                dong03_01.NoiDung = string.Format(temp, dt_01_Start.Month);
                dong03_01.MaNoiDung = "";
                lstDataSource.Add(dong03_01);
                RP_BC04DR dong03_02 = lst02[2];
                dong03_02.NoiDung = string.Format(temp, dt_02_Start.Month);
                dong03_02.MaNoiDung = "";
                lstDataSource.Add(dong03_02);
                RP_BC04DR dong03_03 = lst03[2];
                dong03_03.NoiDung = string.Format(temp, dt_03_Start.Month);
                dong03_03.MaNoiDung = "";
                lstDataSource.Add(dong03_03);

                //Chi tieu 04
                //RP_BC04DR Dong4 = SumQuy023(lst01[3], lst02[3], lst03[3]);

                lstNhom = new List<RP_BC04DR>();
                lstNhom.Add(lst01[3]); lstNhom.Add(lst02[3]); lstNhom.Add(lst03[3]); lstNhom.Add(phiChuyenTien);
                RP_BC04DR Dong4 = SumQuy(lstNhom);

                Dong4.NoiDung = string.Format("Số chi quyết toán {0}  ", GetQuy(p_TuNgay));
                Dong4.MaNoiDung = "4";
                lstDataSource.Add(Dong4);
                lstDataSource.Add(phiChuyenTien);
                RP_BC04DR dong04_01 = lst01[3];
                dong04_01.NoiDung = string.Format(temp, dt_01_Start.Month);
                dong04_01.MaNoiDung = "";
                lstDataSource.Add(dong04_01);
                RP_BC04DR dong04_02 = lst02[3];
                dong04_02.NoiDung = string.Format(temp, dt_02_Start.Month);
                dong04_02.MaNoiDung = "";
                lstDataSource.Add(dong04_02);
                RP_BC04DR dong04_03 = lst03[3];
                dong04_03.NoiDung = string.Format(temp, dt_03_Start.Month);
                dong04_03.MaNoiDung = "";
                lstDataSource.Add(dong04_03);

                //Chi tieu 05
                RP_BC04DR Dong5 = SumQuy023(lst01[4], lst02[4], lst03[4]);
                Dong5.NoiDung = string.Format("Số thu hoàn tạm ứng {0} ", GetQuy(p_TuNgay));
                Dong5.MaNoiDung = "5";
                lstDataSource.Add(Dong5);
                RP_BC04DR dong05_01 = lst01[4];
                dong05_01.NoiDung = string.Format(temp, dt_01_Start.Month);
                dong05_01.MaNoiDung = "";
                lstDataSource.Add(dong05_01);
                RP_BC04DR dong05_02 = lst02[4];
                dong05_02.NoiDung = string.Format(temp, dt_02_Start.Month);
                dong05_02.MaNoiDung = "";
                lstDataSource.Add(dong05_02);
                RP_BC04DR dong05_03 = lst03[4];
                dong05_03.NoiDung = string.Format(temp, dt_03_Start.Month);
                dong05_03.MaNoiDung = "";
                lstDataSource.Add(dong05_03);

                //Chi tieu 06
                RP_BC04DR Dong6 = SumQuy023(lst01[5], lst02[5], lst03[5]);
                Dong6.NoiDung = string.Format("Số phải thu trong kỳ {0} ", GetQuy(p_TuNgay));
                Dong6.MaNoiDung = "6";
                lstDataSource.Add(Dong6);
                RP_BC04DR dong06_01 = lst01[5];
                dong06_01.NoiDung = string.Format(temp, dt_01_Start.Month);
                dong06_01.MaNoiDung = "";
                lstDataSource.Add(dong06_01);
                RP_BC04DR dong06_02 = lst02[5];
                dong06_02.NoiDung = string.Format(temp, dt_02_Start.Month);
                dong06_02.MaNoiDung = "";
                lstDataSource.Add(dong06_02);
                RP_BC04DR dong06_03 = lst03[5];
                dong06_03.NoiDung = string.Format(temp, dt_03_Start.Month);
                dong06_03.MaNoiDung = "";
                lstDataSource.Add(dong06_03);

                //Chi tieu 06
                RP_BC04DR Dong7 = lst03[6];
                Dong7.MaNoiDung = "7";
                Dong7.NoiDung = string.Format("Số tiền chưa quyết toán chuyển sang {0}", GetQuy(dt_03_Start.AddMonths(1)));
                lstDataSource.Add(Dong7);
            }

            return lstDataSource;
        }

        private RP_BC04DR GetPhiChuyenTien(DateTime p_tuNgay, DateTime p_DenNgay, Guid LoaiDoanRa)
        {
            RP_BC04DR objRT = new RP_BC04DR();
            objRT.NoiDung = "- Phí chuyển tiền";
            objRT.MaNoiDung = "";
            List<RP_SoDuTaiKhoan> lstSoDuTk = RP_BC04DRService.GetSoDuTaiKhoan(p_tuNgay, p_DenNgay, Vns.QuanLyDoanRa.Globals.TkThuNganSach, "661", "-1");

            foreach (RP_SoDuTaiKhoan obj in lstSoDuTk)
            {
                if (VnsCheck.IsNullGuid(LoaiDoanRa) || obj.LoaiDoanRaId == LoaiDoanRa)
                {
                    objRT.TongUSD += obj.PsTangUSD;
                    objRT.TongVND += obj.PsTangVND;

                    objRT.TienMatUSD += obj.PsTangUSD;
                    objRT.TienMatVND += obj.PsTangVND;
                }
            }

            return objRT;
        }

        private string GetQuy(DateTime dt)
        {
            if (dt.Month == 2)
                return "Quý I năm " + dt.Year;
            if (dt.Month == 4)
                return "Quý II năm " + dt.Year;
            if (dt.Month == 7)
                return "Quý III năm " + dt.Year;
            if (dt.Month == 10)
                return "Quý IV năm " + dt.Year;
            return string.Empty;
        }

        private string GetQuyTruoc(DateTime dt)
        {
            if (dt.Month == 2)
                return "Quý IV năm " + (dt.Year - 1);
            if (dt.Month == 4)
                return "Quý I năm " + dt.Year;
            if (dt.Month == 7)
                return "Quý II năm " + dt.Year;
            if (dt.Month == 10)
                return "Quý III năm " + dt.Year;
            return string.Empty;
        }

        private RP_BC04DR SumQuy01(RP_BC04DR so1, RP_BC04DR so2)
        {
            RP_BC04DR sum = new RP_BC04DR();
            sum.TongUSD = so1.TongUSD + so2.TongUSD;
            sum.TongVND = so1.TongVND + so2.TongVND;
            sum.TienMatUSD = so1.TienMatUSD + so2.TienMatUSD;
            sum.TienMatVND = so1.TienMatVND + so2.TienMatVND;
            sum.ChuyenKhoanUSD = so1.ChuyenKhoanUSD + so2.ChuyenKhoanUSD;
            sum.ChuyenKhoanVND = so1.ChuyenKhoanVND + so2.ChuyenKhoanVND;
            return sum;
        }

        private RP_BC04DR SumQuy04(RP_BC04DR so1, RP_BC04DR so2, RP_BC04DR so3, RP_BC04DR so4)
        {
            RP_BC04DR sum = new RP_BC04DR();
            sum.TongUSD = so1.TongUSD + so2.TongUSD + so3.TongUSD + so4.TongUSD;
            sum.TongVND = so1.TongVND + so2.TongVND + so3.TongVND + so4.TongVND;
            sum.TienMatUSD = so1.TienMatUSD + so2.TienMatUSD + so3.TienMatUSD + so4.TienMatUSD;
            sum.TienMatVND = so1.TienMatVND + so2.TienMatVND + so3.TienMatVND + so4.TienMatVND;
            sum.ChuyenKhoanUSD = so1.ChuyenKhoanUSD + so2.ChuyenKhoanUSD + so3.ChuyenKhoanUSD + so4.ChuyenKhoanUSD;
            sum.ChuyenKhoanVND = so1.ChuyenKhoanVND + so2.ChuyenKhoanVND + so3.ChuyenKhoanVND + so4.ChuyenKhoanVND;
            return sum;
        }

        private RP_BC04DR SumQuy023(RP_BC04DR so1, RP_BC04DR so2, RP_BC04DR so3)
        {
            RP_BC04DR sum = new RP_BC04DR();
            sum.TongUSD = so1.TongUSD + so2.TongUSD + so3.TongUSD;
            sum.TongVND = so1.TongVND + so2.TongVND + so3.TongVND;
            sum.TienMatUSD = so1.TienMatUSD + so2.TienMatUSD + so3.TienMatUSD;
            sum.TienMatVND = so1.TienMatVND + so2.TienMatVND + so3.TienMatVND;
            sum.ChuyenKhoanUSD = so1.ChuyenKhoanUSD + so2.ChuyenKhoanUSD + so3.ChuyenKhoanUSD;
            sum.ChuyenKhoanVND = so1.ChuyenKhoanVND + so2.ChuyenKhoanVND + so3.ChuyenKhoanVND;
            return sum;
        }

        private RP_BC04DR SumQuy(List<RP_BC04DR> lst)
        {
            RP_BC04DR sum = new RP_BC04DR();

            foreach (RP_BC04DR tmp in lst)
            {
                sum.TongUSD += tmp.TongUSD;
                sum.TongVND += tmp.TongVND;

                sum.TienMatUSD += tmp.TienMatUSD;
                sum.TienMatVND += tmp.TienMatVND;

                sum.ChuyenKhoanUSD += tmp.ChuyenKhoanUSD;
                sum.ChuyenKhoanVND += tmp.ChuyenKhoanVND;
            }

            return sum;
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
