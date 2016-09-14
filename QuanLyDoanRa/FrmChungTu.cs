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
    public partial class FrmChungTu : Form
    {
        private IVnsChungTuService _VnsChungTuService;
        public IVnsChungTuService VnsChungTuService
        {
            get { return _VnsChungTuService; }
            set { _VnsChungTuService = value; }
        }
         
        public FrmChungTu()
        {
            InitializeComponent();
        }
        
    }
}
