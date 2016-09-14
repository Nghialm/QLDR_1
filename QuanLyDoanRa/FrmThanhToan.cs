using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vns.QuanLyDoanRa.Service.Interface;

namespace QuanLyDoanRa
{
    public partial class FrmThanhToan : Form
    {
        private IVnsDuToanDoanService _VnsDuToanDoanService;

        public IVnsDuToanDoanService VnsDuToanDoanService
        {
            get { return _VnsDuToanDoanService; }
            set { _VnsDuToanDoanService = value; }
        }

        public FrmThanhToan()
        {
            InitializeComponent();
        }

    }
}
