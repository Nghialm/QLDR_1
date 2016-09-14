using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.Erp.Core;

namespace QuanLyDoanRa.Controls
{
    public partial class ucSoChungTu : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSoChungTu()
        {
            InitializeComponent();
        }

        #region "Properties"
        private string _PREPIX;
        private string _SO_CHUNG_TU;
        #region "Property"
      
        #endregion

        public IVnsLoaiChungTuService VnsLoaiChungTuService;

        public string SO_CHUNG_TU
        {
            get { return _SO_CHUNG_TU; }
            set { _SO_CHUNG_TU = value; }
        }

        public string PREFIX
        {
            get { return _PREPIX; }
            set { _PREPIX = value; }
        }

        public override string Text
        {
            get { return txtSoCT.Text; }
            set { txtSoCT.Text = value; }
        }
       #endregion

        public void Soct(Guid LoaiCt, int thang, int nam)
        {
            if (VnsLoaiChungTuService == null)
            {
                VnsLoaiChungTuService = (IVnsLoaiChungTuService)ObjectFactory.GetObject("VnsLoaiChungTuService");
            }

            List<String> lst_str = new List<String>();

            lst_str.AddRange(this.VnsLoaiChungTuService.GetSoCT_prefix(LoaiCt, thang, nam));

            if (lst_str != null)
                SO_CHUNG_TU = lst_str[0] + lst_str[1];
        }

        private void ucSoChungTu_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
        }
      
    }
}
