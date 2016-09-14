using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Domain;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Service.Interface;
namespace QuanLyDoanRa.Reports
{
    public partial class FrmThamSoBaoCao : Form
    {
        private IVnsDoanCongTacService _VnsDoanCongTacService;
        public IVnsDoanCongTacService VnsDoanCongTacService
        {
            get { return _VnsDoanCongTacService; }
            set { _VnsDoanCongTacService = value; }
        }
        /// <summary>
        /// True: bao cao Quyet toan
        /// False: bao cao du toan
        /// </summary>
        public bool LoaiBaoCao = false;
        public bool KieuBaoCao = false;
        public IList<VnsInQtTu> lstIn;
        public VnsDoanCongTac objDoanCongTac;
        public FrmThamSoBaoCao()
        {
            InitializeComponent();
        }

        private void FrmThamSoBaoCao_Load(object sender, EventArgs e)
        {
            if (objDoanCongTac != null)
            {
                if (objDoanCongTac.NgayIn.ToString() == DateTime.MaxValue.ToString())
                    dNgayIn.EditValue = DateTime.Now;
                else
                    dNgayIn.EditValue = objDoanCongTac.NgayIn;
                if (objDoanCongTac.NgayCanCu.ToString() == DateTime.MaxValue.ToString())
                    dNgayCanCuHoSo.EditValue = DateTime.Now;                    
                else
                    dNgayCanCuHoSo.EditValue = objDoanCongTac.NgayCanCu;
                mmCanCuCongVan.Text = objDoanCongTac.CanCuCongVan;
                txtSoCanCuHoSo.Text = objDoanCongTac.SoCanCuHoSo;
                if (LoaiBaoCao)
                {
                    txtSoThongBao.Text = objDoanCongTac.SoThongBaoQuyetToan;
                    chkDtBs.Visible = false;
                }
                else
                {
                    txtSoThongBao.Text = objDoanCongTac.SoThongBaoDuToan;
                    //Kiem tra, neu co du toan bo sung thi hien thi check lua chon
                    bool flg = false;
                    foreach (VnsInQtTu tmp in lstIn)
                    {
                        if (tmp.LanDuToan == 1)
                        {
                            flg = true;
                            break;
                        }
                    }
                    chkDtBs.Visible = flg;
                }
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (this.objDoanCongTac != null)
            {
                General.NgayCanCu = dNgayCanCuHoSo.DateTime.ToString("dd-MM-yyyy");
                General.TheoCongVan = mmCanCuCongVan.Text;
                General.NgayIn = dNgayIn.DateTime;
                General.SoCanCuHoSo = txtSoCanCuHoSo.Text;
                General.SoThongBaoDuToan = txtSoCanCuHoSo.Text;

                objDoanCongTac.CanCuCongVan = mmCanCuCongVan.Text;
                objDoanCongTac.NgayCanCu = (DateTime)dNgayCanCuHoSo.EditValue;
                objDoanCongTac.NgayIn = (DateTime)dNgayIn.EditValue;
                objDoanCongTac.SoCanCuHoSo = txtSoCanCuHoSo.Text;
                
                if (LoaiBaoCao)
                {
                    General.SoThongBaoQuyetToan = txtSoThongBao.Text;
                    objDoanCongTac.SoThongBaoQuyetToan = txtSoThongBao.Text;
                    Reports.frmTabInQuyetToan frm = new frmTabInQuyetToan(lstIn, objDoanCongTac, "QT",KieuBaoCao);
                    frm.InKemThongBao = chkInKem.Checked;
                    frm.ShowDialog();
                }
                else
                {
                    General.SoThongBaoDuToan = txtSoThongBao.Text;
                    int flg = 0;
                    IList<VnsInQtTu> lsttmp = new List<VnsInQtTu>();
                    if (chkDtBs.Checked) flg = 1;
                    foreach (VnsInQtTu tmp in lstIn)
                    {
                        if (tmp.LanDuToan == flg) lsttmp.Add(tmp);
                    }
                   // objDoanCongTac.SoThongBaoDuToan = txtSoThongBao.Text;
                    Reports.frmTabInQuyetToan frm = new frmTabInQuyetToan(lsttmp, objDoanCongTac, "DT", KieuBaoCao);
                    frm.InKemThongBao = chkInKem.Checked;
                    frm.ShowDialog();
                }

                this.VnsDoanCongTacService.Merge(this.objDoanCongTac);
            }
        }

        private void chkDtBs_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
