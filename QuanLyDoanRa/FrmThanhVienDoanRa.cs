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
    public partial class FrmThanhVienDoanRa : Form
    {
        private IVnsThanhVienService _VnsThanhVienService;

        public IVnsThanhVienService VnsThanhVienService
        {
            get { return _VnsThanhVienService; }
            set { _VnsThanhVienService = value; }
        }
        public FrmThanhVienDoanRa()
        {
            InitializeComponent();
        }


    }
}
