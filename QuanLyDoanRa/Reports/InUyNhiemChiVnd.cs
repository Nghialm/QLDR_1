using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Vns.QuanLyDoanRa.Domain;
using System.Collections.Generic;

namespace QuanLyDoanRa.Reports
{
    public partial class InUyNhiemChiVnd : DevExpress.XtraReports.UI.XtraReport
    {
        public InUyNhiemChiVnd()
        {
            InitializeComponent();
        }

        private VnsDmKhachHang m_KhachHang = new VnsDmKhachHang();
        private IList<VnsGiaoDich> m_lstGiaoDich = new List<VnsGiaoDich>();
        private VnsChungTu m_objChungTu;
        private Decimal m_SoTien =0 ;
        private DateTime m_NgayCt;
        public InUyNhiemChiVnd(VnsChungTu p_objChungTu, VnsDmKhachHang p_KhachHang, IList<VnsGiaoDich> p_lstGiaoDich, Decimal p_SoTien, DateTime p_NgayCt)
        {
            InitializeComponent();
            m_KhachHang = p_KhachHang;
            m_SoTien = p_SoTien;
            m_NgayCt = p_NgayCt;
            m_objChungTu = p_objChungTu;
 
            IList<VnsGiaoDich> p_lstTmp = new List<VnsGiaoDich>();
            VnsGiaoDich tmp1 = new VnsGiaoDich();
            foreach (VnsGiaoDich tmp in p_lstGiaoDich)
            {
                tmp1.NoiDung = tmp.NoiDung;
                tmp1.SoTien += tmp.SoTien;
            }
            p_lstTmp.Add(tmp1);
            m_lstGiaoDich = p_lstTmp;
        }

        private void InUyNhiemChi_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                lblSoCt.Text = m_objChungTu != null ? string.Format("Số : {0}", m_objChungTu.SoCt) : "Số :.....";
                lblDiaChi.Text = m_KhachHang.DiaChi;
                lblDonViNhanTien.Text = m_KhachHang.TenKhachHang;
                lblMaDv.Text = m_KhachHang.MaDvqhns;
                lblMaCTMT.Text = m_KhachHang.MaCTMT;
                lblNganHang.Text = m_KhachHang.GhiChu2;
                lblTaiKhoan.Text = m_KhachHang.SoTaiKhoan;
                lblTongTienBangChu.Text = Commons.Commons.DocTienBangChu((long)m_SoTien, " Việt Nam đồng.");
                lblSoTienNopThue.Text = "Số tiền nộp thuế (Ghi bằng chữ) :Không đồng";
                lblSoTienThanhToan.Text = lblTongTienBangChu.Text;
                lblNgay.Text="Lập ngày "+m_NgayCt.Day.ToString()+" Tháng "+m_NgayCt.Month.ToString()+" Năm "+m_NgayCt.Year.ToString();
                
                Commons.Report.SetParamValue(General.lstThamSo, this.Parameters);
                
                this.DataSource =Commons.Commons.ToDataTable<VnsGiaoDich>(m_lstGiaoDich);
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        
    }
}
