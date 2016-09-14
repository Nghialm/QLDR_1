using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Service.Interface;
using System.IO;
using System.Windows.Forms;


using System.Reflection;
//using Microsoft.Office.Interop.Word;
//using Microsoft.Office.Core;
//using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using Vns.Erp.Core;

namespace QuanLyDoanRa.Reports
{
    public partial class InBiaQuyetToan : DevExpress.XtraReports.UI.XtraReport
    {
        private Boolean _InKemThongBao = true;
        public Boolean InKemThongBao
        {
            get { return _InKemThongBao; }
            set { _InKemThongBao = value; }
        }

        public IVnsLichCongTacService VnsLichCongTacService;

        public IVnsThanhVienService VnsThanhVienService;
        public IVnsDmQuocGiaService VnsDmQuocGiaService;
        public IVnsDanhMucChucVuService VnsDanhMucChucVuService;
        String TenDoanRa="";
        String TruongDoan="";
        String ChucVu="";
        String NoiDen="";
        String NuocCongTac="Nơi đến : ";
        String TenBaoCao="";
        String DoanGom = "";
        String TuNgayDenNgay = "";
        String VanPhong = "";
        string CanCuHoSo = "";
        string SoThongBao = "Số ";
        IList<VnsInQtTu> lstQT = new List<VnsInQtTu>();
        public InBiaQuyetToan()
        {
            InitializeComponent();
        }
        public InBiaQuyetToan(IList<VnsInQtTu> lst, VnsDoanCongTac objDoanRa, string Flag)
        {
            InitializeComponent();
            
        }
        public void LoadData(IList<VnsInQtTu> lst, VnsDoanCongTac objDoanRa, string Flag,bool pKieuBaoCao)
        {

            VnsLichCongTacService = (IVnsLichCongTacService)ObjectFactory.GetObject("VnsLichCongTacService");
            VnsThanhVienService = (IVnsThanhVienService)ObjectFactory.GetObject("VnsThanhVienService");
            VnsDmQuocGiaService = (IVnsDmQuocGiaService)ObjectFactory.GetObject("VnsDmQuocGiaService");
            VnsDanhMucChucVuService = (IVnsDanhMucChucVuService)ObjectFactory.GetObject("VnsDanhMucChucVuService");
            if (Flag == "QT")
            {
                if (pKieuBaoCao)
                {
                    TenBaoCao = "phê duyệt quyết toán đoàn ra";
                }
                else
                    TenBaoCao = "phê duyệt quyết toán bổ sung đoàn ra";
                VanPhong += "Văn phòng Trung ương Đảng thông báo quyết toán chi đoàn đi công tác nước ngoài như sau: ";
                CanCuHoSo = "- Căn cứ hồ sơ quyết toán đoàn ra";
                SoThongBao += _InKemThongBao ? objDoanRa.SoThongBaoQuyetToan : "        "; //objDoanRa.SoThongBaoQuyetToan; //Trong in to trinh chua co so thong bao du toan
            }
            else
            {
                TenBaoCao = "phê duyệt dự toán đoàn ra";
                VanPhong += "Văn phòng Trung ương Đảng thông báo dự toán chi đoàn đi công tác nước ngoài như sau: ";
                CanCuHoSo = "- Căn cứ hồ sơ dự toán đoàn ra";
                SoThongBao += _InKemThongBao ? objDoanRa.SoThongBaoDuToan : "        ";  //objDoanRa.SoThongBaoDuToan; //Trong to trinh khong co so thong bao du toan
            }
            if (General.SoCanCuHoSo != string.Empty)
                CanCuHoSo += String.Format(" số {0}, ", General.SoCanCuHoSo);
            CanCuHoSo += " ngày "+General.NgayCanCu + " do " + objDoanRa.Ten + " lập,";
            TenDoanRa = "Đoàn đại biểu : " + objDoanRa.Ten;
            TruongDoan = "Trưởng đoàn : Đồng chí " + objDoanRa.TruongDoan;
            TuNgayDenNgay = ", đi từ ngày " + objDoanRa.NgayDi.ToString("dd-MM-yyyy") + " đến ngày " + objDoanRa.NgayVe.ToString("dd-MM-yyyy");
            SoThongBao += "-TB/VPTW/nb";
            IList<VnsLichCongTac> lstLCT = this.VnsLichCongTacService.GetByDoanCongTac(objDoanRa.IdBanDau);
            int songuoiA = 0;
            int songuoiB = 0;
            VnsDanhMucChucVu objChucVu = this.VnsDanhMucChucVuService.GetById(objDoanRa.ChucVuTruongDoanId);
            if (objChucVu != null) ChucVu = "Chức vụ : " + objChucVu.TenChucVu;
            for(int i=0;i<lstLCT.Count;i++)
            {
                VnsLichCongTac obj = lstLCT[i];
                NuocCongTac += obj.objNuocDen.TenNuoc;
                if(lstLCT.Count>1 && i <lstLCT.Count-1)
                    NuocCongTac += ", ";
                IList<VnsThanhVien> lstTV = this.VnsThanhVienService.GetThanhVienByLichCongTacDoanRa(obj.Id, obj.CongTacId);
                foreach (VnsThanhVien objTV in lstTV)
                {
                    if (objTV.PhanLoai == 1)
                        songuoiA = objTV.SoLuong;
                    if (objTV.PhanLoai == 2)
                        songuoiB = objTV.SoLuong;
                }
            }
            DoanGom = "Đoàn gồm : ";
            if (songuoiA > 0)
            {
                DoanGom += songuoiA.ToString() + "A";
            }
            if (!(songuoiA < 1 || songuoiB < 1))
            {
                DoanGom += " và ";
            }
            if (songuoiB > 0)
                DoanGom += songuoiB.ToString() + "B ";
            int SoNguoi= songuoiB+songuoiA;
            DoanGom += "(" + SoNguoi.ToString() + " người)" + TuNgayDenNgay;
            lstQT = lst;

            lblNgayIn.Text = String.Format("Hà Nội, ngày {0} tháng {1} năm {2}", 
                _InKemThongBao ? General.NgayIn.ToString("dd") : "  ", 
                _InKemThongBao ? General.NgayIn.ToString("MM") : "  ",
                _InKemThongBao ? General.NgayIn.ToString("yyyy") : "      ."); //"+General.NgayIn.Year.ToString()
        }

        private void InBiaQuyetToan_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string tab_daudong = "         ";
            xrDoanDaiBieu.Text = tab_daudong + TenDoanRa;
            xrTruongDoan.Text = tab_daudong + TruongDoan;
            lblThongBao.Text = TenBaoCao;
            xrChucVu.Text = tab_daudong + ChucVu;
            xrNoiDen.Text = tab_daudong + NuocCongTac + ".";
            xrVanPhong.Text = tab_daudong + VanPhong;
            xrDoanGom.Text = tab_daudong + DoanGom + ".";
            xrCanCu.Text = tab_daudong + CanCuHoSo;
            xrTheoCongVan.Text = tab_daudong + General.TheoCongVan;
            //lblNgayIn.Text= String.Format("Hà Nội, ngày {0} tháng {1} năm {2}", "  ", "  ", "    "); //"+General.NgayIn.Year.ToString()
            lblSoThongBao.Text = SoThongBao;
            //this.DataSource = Commons.Commons.ToDataTable<VnsInQtTu>(lstQT);
           
        }

    }
}
