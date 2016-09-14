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

namespace QuanLyDoanRa
{
    public partial class FrmLichCongTac : Form
    {
        private IVnsDoanCongTacService _VnsDoanCongTacService;

        public IVnsDoanCongTacService VnsDoanCongTacService
        {
            get { return _VnsDoanCongTacService; }
            set { _VnsDoanCongTacService = value; }
        }
        private IVnsLichCongTacService _VnsLichCongTacService;

        public IVnsLichCongTacService VnsLichCongTacService
        {
            get { return _VnsLichCongTacService; }
            set { _VnsLichCongTacService = value; }
        }
        public FrmLichCongTac()
        {
            InitializeComponent();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            FrmThanhVienDoanRa frmThanhVienDoanRa = (FrmThanhVienDoanRa)ObjectFactory.GetObject("frmThanhVienDoanRa");
            frmThanhVienDoanRa.ShowDialog();
        }
    }
}
