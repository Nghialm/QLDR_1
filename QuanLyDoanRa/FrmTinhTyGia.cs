using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.QuanLyDoanRa.Domain;

namespace QuanLyDoanRa
{
    public partial class FrmTinhTyGia : Form
    {
        public FrmTinhTyGia()
        {
            InitializeComponent();
        }

        #region Properties
        public IVnsLoaiDoanRaService VnsLoaiDoanRaService;
        public IVnsDuLuongDauKyService VnsDuLuongDauKyService;
        #endregion

        #region Function
        private void BindDataToCbo()
        {
            IList<int> lstNam = new List<int>();
            for (int i = 2010; i <= 2020; i++)
            {
                lstNam.Add(i);
            }
            cboNam.Properties.DataSource = lstNam;
            cboNam.EditValue = DateTime.Now.Year;

            IList<int> lstThang = new List<int>();
            for (int i = 1; i <= 12; i++)
                lstThang.Add(i);

            cboThang.Properties.DataSource = lstThang;
            cboThang.EditValue = DateTime.Now.Month;

            List<VnsLoaiDoanRa> lstLoaiDoanRa = new List<VnsLoaiDoanRa>();
            //lstLoaiDoanRa.Add(new VnsLoaiDoanRa());
            lstLoaiDoanRa.AddRange(VnsLoaiDoanRaService.GetAll());
            cboLoaiDoanRa.Properties.DataSource = lstLoaiDoanRa;
            cboLoaiDoanRa.Properties.ValueMember = "Id";
            cboLoaiDoanRa.Properties.DisplayMember = "TenLoaiDoanRa";
        }
        #endregion

        private void FrmTinhTyGia_Load(object sender, EventArgs e)
        {
            BindDataToCbo();
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            IList<DateTime> lstNgay = Commons.Commons.GetTuNgayDenNgayTrongThang(Int32.Parse(cboThang.Text), Int32.Parse(cboNam.Text));
            DateTime TuNgay = lstNgay[0];
            DateTime DenNgay = lstNgay[1];

            VnsLoaiDoanRa loaidoanra = (VnsLoaiDoanRa)Commons.ComboHelper.GetSelectData(cboLoaiDoanRa);

            VnsDuLuongDauKyService.TinhTyGiaFIFO(TuNgay, DenNgay, txtNghiepVu.Text, loaidoanra.Id);

            Commons.Commons.Message_Information("Đã thực hiện xong");
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
