using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.Erp.Core;
using System.Collections;

namespace QuanLyDoanRa
{
    public partial class FrmDuToanDoanRa : Form
    {
        private IVnsDuToanDoanService _VnsDuToanDoanService;

        public IVnsDuToanDoanService VnsDuToanDoanService 
        {
            get { return _VnsDuToanDoanService; }
            set { _VnsDuToanDoanService = value; }
        }

        private IVnsDmQuocGiaService _VnsDmQuocGiaService;
        public IVnsDmQuocGiaService VnsDmQuocGiaService
        {
            get { return _VnsDmQuocGiaService; }
            set { _VnsDmQuocGiaService = value; }
        }

        private IVnsDmMucTieuMucService _VnsDmMucTieuMucService;
        public IVnsDmMucTieuMucService VnsDmMucTieuMucService
        {
            get { return _VnsDmMucTieuMucService; }
            set { _VnsDmMucTieuMucService = value; }
        }
        public FrmDuToanDoanRa()
        {
            InitializeComponent();
        }
        private void BindDmQuocGia()
        {
            this.lueNuocDen.Properties.DataSource = this.VnsDmQuocGiaService.List(-1, -1, null, null, null);
            this.lueNuocDen.Properties.DisplayMember = "TenNuoc";
            this.lueNuocDen.Properties.ValueMember = "MaNuoc";
        }
        private void BindDmMuc()
        {
            this.lueTenMuc.Properties.DataSource = this.VnsDmMucTieuMucService.List(-1, -1, null, null, null);
            this.lueTenMuc.Properties.DisplayMember = "TenMuc";
            this.lueTenMuc.Properties.ValueMember = "MaMuc";
        }
        private void FrmDuToanDoanRa_Load(object sender, EventArgs e)
        {
            BindDmQuocGia();
            BindDmMuc();
        }

        private void btnDuToan_Click(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            FrmThanhToan frmThanhToan = (FrmThanhToan)ObjectFactory.GetObject("frmThanhToan");
            frmThanhToan.Show();
        }

    }
}
