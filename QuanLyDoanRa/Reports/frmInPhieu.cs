using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Parameters;
using System.IO;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.Erp.Core;

namespace QuanLyDoanRa.Reports
{
    public partial class frmInPhieu : DevExpress.XtraEditors.XtraForm
    {
        private VnsChungTu m_objChungTu;
        private IList<VnsGiaoDich> m_lstGiaoDich;
        private VnsLoaiChungTu m_objLoaiChungTu;
        public IVnsLoaiDoanRaService VnsLoaiDoanRaService;
        public IVnsLoaiChungTuService VnsLoaiChungTuService;

        public frmInPhieu()
        {
            InitializeComponent();
        }

        public frmInPhieu(VnsChungTu p_objChungTu, IList<VnsGiaoDich> p_lstGiaoDich, VnsLoaiChungTu p_objLoaiChungTu)
        {
            InitializeComponent();
            m_lstGiaoDich = p_lstGiaoDich;
            m_objChungTu = p_objChungTu;

            m_objLoaiChungTu = p_objLoaiChungTu;
            txtTenBaoCao.Text = m_objLoaiChungTu.Ten;

            if (m_objLoaiChungTu.MaLoaiChungTu.EndsWith("VND")) cboVND.Checked = true;
            else cboUSD.Checked = true;
        }

        public void tempVi()
        {
            List<string> lst = new List<string>();
            if (m_objLoaiChungTu.MaLoaiChungTu.StartsWith("PT") || m_objLoaiChungTu.MaLoaiChungTu == "HU" || m_objLoaiChungTu.MaLoaiChungTu == "GBC")
            {
                //Load template phieu chi
                lst.Add("thu.repx");
                lkeTemplate.Properties.DataSource = lst;
                lkeTemplate.ItemIndex = 0;
            }
            else if (m_objLoaiChungTu.MaLoaiChungTu.StartsWith("PC") || m_objLoaiChungTu.MaLoaiChungTu == "TU" || m_objLoaiChungTu.MaLoaiChungTu == "GBN")
            {
                //Load template phieu thu
                lst.Add("chi.repx");
                lkeTemplate.Properties.DataSource = lst;
                lkeTemplate.ItemIndex = 0;
            }
            else
            {
                lst.Add("thu.repx");
                lst.Add("chi.repx");
                lkeTemplate.Properties.DataSource = lst;
                lkeTemplate.ItemIndex = 0;
            }
        }

        private String getTemplate(LookUpEdit contrl)
        {
            String root_dir = Application.StartupPath + "\\TempReport\\";
            return root_dir + contrl.EditValue;
        }

        private IList<Info> getParamValue()
        {
            String strSoTien = "";
            decimal sotien = 0;
            if (cboUSD.Checked)
            {
                sotien = GetSoTien(m_lstGiaoDich);
                strSoTien = Commons.Commons.DocTienBangChu((long)sotien, " đô la Mỹ");
            }
            else
            {
                sotien = GetSoTienVND(m_lstGiaoDich);
                strSoTien = Commons.Commons.DocTienBangChu((long)sotien, " đồng");
            }
            IList<Info> lst = General.lstThamSo;

            Info objThamSo = new Info();
            objThamSo.Ma = "p_SoTienBangChu";
            objThamSo.GiaTri = strSoTien +")";
            lst.Add(objThamSo);

            objThamSo = new Info();
            objThamSo.Ma = "p_TieuDe";
            objThamSo.GiaTri = txtTenBaoCao.Text.ToUpper();
            lst.Add(objThamSo);

            objThamSo = new Info();
            objThamSo.Ma = "p_KemTheo";
            objThamSo.GiaTri = txtKemTheo.Text;
            lst.Add(objThamSo);

            objThamSo = new Info();
            objThamSo.Ma = "p_CtGoc";
            objThamSo.GiaTri = txtCtGoc.Text;
            lst.Add(objThamSo);

            string[] lstDonVi = txtCty.Text.Trim().Replace("  ", " ").Split(' ');
            string dv1 = "";
            string dv2 = "";
            for (int i = 0; i < lstDonVi.Length; i++)
            {
                if (i < 3)
                {
                    dv1 += " " + lstDonVi[i];
                }
                else
                {
                    dv2 += " " + lstDonVi[i];
                }
            }

            objThamSo = new Info();
            objThamSo.Ma = "p_DonVi1";
            objThamSo.GiaTri = dv1.Trim();
            lst.Add(objThamSo);

            objThamSo = new Info();
            objThamSo.Ma = "p_DonVi2";
            objThamSo.GiaTri = dv2.Trim();
            lst.Add(objThamSo);
            foreach (Info obj in lst)
            {
                if (obj.Ma == "p_DonVi")
                {
                    obj.GiaTri = txtCty.Text;
                }
                if (obj.Ma == "p_DiaChi")
                {
                    obj.GiaTri = txtDCcty.Text;
                }

                if (obj.Ma == "p_ThuTruongDonVi")
                {
                    obj.GiaTri = txtThutruong.Text;
                }

                if (obj.Ma == "p_ThuQuy")
                {
                    obj.GiaTri = txtThuquy.Text;
                }

                if (obj.Ma == "p_TenKeToanTruong")
                {
                    obj.GiaTri = txtKetoan.Text;
                }

                if (obj.Ma == "p_TenNguoiLapBieu")
                {
                    obj.GiaTri = txtNguoiLap.Text;
                }
            }

            return lst;
        }

        public void callReport()
        {
            DataTable dt = GetDataSource();
            InChungTu rp = new InChungTu(getParamValue(),dt);
            if (File.Exists(getTemplate(lkeTemplate)))
            {
                rp.LoadLayout(getTemplate(lkeTemplate));
            }
            else
            {
                Commons.Commons.Message_Information("Không thấy mẫu báo cáo");
                return;
            }
            rp.ShowPreviewDialog();
        }

        private DataTable CreateDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("CtSo", typeof(string));
            table.Columns.Add("MaTkNo", typeof(string));
            table.Columns.Add("MaTkCo", typeof(string));
            table.Columns.Add("NguoiNhanNopTien", typeof(string));

            table.Columns.Add("DiaChi", typeof(string));
            table.Columns.Add("DienGiai", typeof(string));
            table.Columns.Add("SoTien", typeof(decimal));
            table.Columns.Add("SoTienNte", typeof(decimal));
            table.Columns.Add("TenKhHang", typeof(string));
            table.Columns.Add("NgayCt", typeof(string));

            table.Columns.Add("KemTheo", typeof(string));
            table.Columns.Add("CtGoc", typeof(string));

            table.Columns.Add("LoaiTien", typeof(string));

            return table;
        }

        private decimal GetSoTien(IList<VnsGiaoDich> lstGiaoDich)
        {
            decimal sotien=0;
            foreach(VnsGiaoDich obj in lstGiaoDich)
            {
                sotien += obj.SoTienNt;
            }
            return sotien;
        }

        private decimal GetSoTienVND(IList<VnsGiaoDich> lstGiaoDich)
        {
            decimal sotienVND = 0;
            foreach (VnsGiaoDich obj in lstGiaoDich)
            {
                sotienVND += obj.SoTien;
            }
            return sotienVND;
        }

        private DataTable GetDataSource()
        {
            VnsLoaiDoanRa objLoaiDoanRa = new VnsLoaiDoanRa();
            if (m_lstGiaoDich.Count > 0)
            {
                if (VnsLoaiDoanRaService == null)
                {
                    VnsLoaiDoanRaService = (IVnsLoaiDoanRaService)ObjectFactory.GetObject("VnsLoaiDoanRaService");
                }
                if (m_lstGiaoDich[0].LoaiDoanRaCoId != new Guid())
                {
                    objLoaiDoanRa = VnsLoaiDoanRaService.GetById(m_lstGiaoDich[0].LoaiDoanRaCoId);
                }
                else
                {
                    objLoaiDoanRa = VnsLoaiDoanRaService.GetById(m_lstGiaoDich[0].LoaiDoanRaNoId);
                }
            }

            DataTable dtSource = CreateDataTable();
            DataRow dr = dtSource.NewRow();
            dr["CtSo"] = m_objChungTu.SoCt;
            dr["NguoiNhanNopTien"] = m_objChungTu.NguoiGiaoDich;
            dr["DienGiai"] = m_objChungTu.NoiDung;
            dr["MaTkNo"] = m_objLoaiChungTu.MaTkNo;
            dr["MaTkCo"] =m_objLoaiChungTu.MaTkCo;
            //dr["SoTienNte"] = GetSoTien(m_lstGiaoDich);
            //dr["SoTien"] = GetSoTienVND(m_lstGiaoDich);
            dr["NgayCt"] = String.Format("Ngày {0} tháng {1} năm {2}", m_objChungTu.NgayCt.Day, m_objChungTu.NgayCt.Month, m_objChungTu.NgayCt.Year);
            dr["DiaChi"] = m_objChungTu.DiaChi;
            //if (objLoaiDoanRa != null)
            //{
            //    dr["DiaChi"] = "Ban " + objLoaiDoanRa.TenLoaiDoanRa;
            //}
            dr["KemTheo"] = txtKemTheo.Text;
            dr["CtGoc"] = txtCtGoc.Text;

            if (cboVND.Checked)
            {
                dr["LoaiTien"] = "VNĐ";
                dr["SoTienNte"] = GetSoTienVND(m_lstGiaoDich);
            }
            else
            {
                dr["LoaiTien"] = "USD";
                dr["SoTienNte"] = GetSoTien(m_lstGiaoDich);
            }

            dtSource.Rows.Add(dr);
            return dtSource;
        }

        private string GetTenThamSo(string Ma)
        {
            foreach (Info obj in General.lstThamSo)
            {
                if (obj.Ma == Ma)
                {
                    return obj.GiaTri;
                }
            }
            return "";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                callReport();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void frmInPhieu_Load(object sender, EventArgs e)
        {
            try
            {
                tempVi();
                if (m_objLoaiChungTu.LoaiPhieu == 1)
                {
                    txtTenBaoCao.Text = "Phiếu chi";
                }
                else 
                {
                    txtTenBaoCao.Text = "Phiếu thu";
                }
                
                txtCty.Text = GetTenThamSo("p_DonVi");
                txtDCcty.Text = m_objChungTu.DiaChi;
                txtThutruong.Text = GetTenThamSo("p_ThuTruongDonVi");
                txtThuquy.Text = GetTenThamSo("p_ThuQuy");
                txtKetoan.Text = GetTenThamSo("p_TenKeToanTruong");
                txtNguoiLap.Text = GetTenThamSo("p_TenNguoiLapBieu");                
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void frmInPhieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}