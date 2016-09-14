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
using Vns.Erp.Core.Domain;
using System.Collections;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Domain.Report;
using QuanLyDoanRa.Reports;

namespace QuanLyDoanRa
{
    public partial class FrmDuToan : Form
    {
        #region Property
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

        public IVnsDoanCongTacService VnsDoanCongTacService;
        public IVnsDmHeThongService VnsDmHeThongService;
        #endregion

        #region Variable
        private int PgSize = General.NumberOfPage;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;

        private Vns.QuanLyDoanRa.Domain.VnsDuToanDoan _DuToan;
        public Vns.QuanLyDoanRa.Domain.VnsDuToanDoan DuToan
        {
            get { return _DuToan; }
            set { _DuToan = value; }
        }


        private IList<VnsDoanCongTac> lstDoanCongTac = new List<VnsDoanCongTac>();
        private IList<VnsDoanCongTac> lstDelDoanCongTac = new List<VnsDoanCongTac>();
        private VnsDoanCongTac objDoanCongTac = new VnsDoanCongTac();
        #endregion

        public FrmDuToan()
        {
            InitializeComponent();
        }
        private IList<VnsDuToanDoan> lstDuToanDoanRa = new List<VnsDuToanDoan>();
        private IList<VnsDuToanDoan> lstDelDuToanDoanRa = new List<VnsDuToanDoan>();
        
        // tinh tong so trang
        private void TongSoTrang()
        {
            int rowCount = this.VnsDoanCongTacService.GetCount();
            TotalPage = rowCount / PgSize;
            if (rowCount % PgSize > 0)
                TotalPage += 1;
        }

        private void BindCombo()
        {
            int[] phanloai = new int[] { 1, 2 };
            this.luegPhanLoai.DataSource = phanloai;

            this.cboTenMuc.DataSource = this.VnsDmMucTieuMucService.GetAll();
        }

        private void BindData()
        {
            lstDoanCongTac = VnsDoanCongTacService.GetDoanRa(-1);
            gctDoanRa.DataSource = lstDoanCongTac;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Escape):
                    btnHuy_Click(null, null);
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FrmDuToan_Load(object sender, EventArgs e)
        {
            BindCombo();
            BindData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDuToan_Click(object sender, EventArgs e)
        {
            if (gvDoanRa.FocusedRowHandle < 0) return;

            VnsDoanCongTac objDoanCongTac = (VnsDoanCongTac)gvDoanRa.GetRow(gvDoanRa.FocusedRowHandle);
            lstDuToanDoanRa = new List<VnsDuToanDoan>();
            lstDuToanDoanRa = VnsDuToanDoanService.TinhDuToan(objDoanCongTac.NgayDi, objDoanCongTac);
            // SortDuToan(lstDuToanDoanRa);
            grvDuToan.DataSource = lstDuToanDoanRa;
            grvDuToan.RefreshDataSource();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            VnsDoanCongTac objDoanCongTac = (VnsDoanCongTac)gvDoanRa.GetRow(gvDoanRa.FocusedRowHandle);
            foreach (VnsDuToanDoan obj in lstDuToanDoanRa)
            {
                if (obj.Id == new Guid())
                    obj.NgayDuToan = DateTime.Now;

                //obj.NgayDuToan = DateTime.Now;
            }
            objDoanCongTac.DanhSachDuToanDoan = lstDuToanDoanRa;
            VnsDoanCongTacService.Merge(objDoanCongTac);
            //lstDelDuToanDoanRa = VnsDuToanDoanService.GetByDoanCongTac(objDoanCongTac.Id);
            //foreach (VnsDuToanDoan tmp in lstDelDuToanDoanRa)
            //{
            //    VnsDuToanDoanService.DeleteById(tmp.Id);
            //}

            //foreach (VnsDuToanDoan tmp in lstDuToanDoanRa)
            //{
            //    tmp.CongTacId = objDoanCongTac.Id;
            //    tmp.NgayDuToan = objDoanCongTac.NgayDi;                
            //    VnsDuToanDoanService.SaveOrUpdate(tmp);
            //}

            MessageBox.Show("Đã lưu dự toán thành công");
        }

        private void grvDuToan_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    ThemDong();
                    break;
                case Keys.F8:
                    XoaDong();
                    break;
            }
        }

        private void ThemDong()
        {
            if (lstDuToanDoanRa == null) lstDuToanDoanRa = new List<VnsDuToanDoan>();

            lstDuToanDoanRa.Add(new VnsDuToanDoan());

            gvDuToan.RefreshData();
            Commons.GridHelper.SetFocusAfterAddRow(gvDuToan);

        }

        private void XoaDong()
        {
            if (gvDuToan.FocusedRowHandle < 0) return;
            if (gvDuToan.FocusedRowHandle >= 0)
            {
                VnsDuToanDoan tmpdel = (VnsDuToanDoan)gvDuToan.GetRow(gvDuToan.FocusedRowHandle);
                //lstDuToanDoanRa.RemoveAt(gvDuToan.FocusedRowHandle);
                //lstDuToanDoanRa.Remove(tmpdel);
                //lstDelDuToanDoanRa.Add(tmpdel);
            }
            gvDuToan.DeleteSelectedRows();
            gvDuToan.RefreshData();
        }

        private void gvDoanRa_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadGridDetail();
        }

        private void LoadGridDetail()
        {
            if (gvDoanRa.FocusedRowHandle < 0) return;

            objDoanCongTac = (VnsDoanCongTac)gvDoanRa.GetRow(gvDoanRa.FocusedRowHandle);
            //lstDuToanDoanRa = new List<VnsDuToanDoan>();
            //lstDelDuToanDoanRa = new List<VnsDuToanDoan>();

            //lstDuToanDoanRa = VnsDuToanDoanService.GetByDoanCongTac(objDoanCongTac.Id);
            //if (objDoanCongTac.TrangThai == 2)
            //{
            //    grvDuToan.Enabled = false;
            //    btnDuToan.Enabled = false;
            //    btnLuu.Enabled = false;
            //}
            //else if (objDoanCongTac.TrangThai == 1)
            //{
            //    grvDuToan.Enabled = true;
            //    btnDuToan.Enabled = true;
            //    btnLuu.Enabled = true;
            //}

            //lstDuToanDoanRa = objDoanCongTac.DanhSachDuToanDoan;
            lstDuToanDoanRa = VnsDuToanDoanService.GetByDoanCongTac(objDoanCongTac.Id);

            if (lstDuToanDoanRa != null && lstDuToanDoanRa.Count > 0)
            {
                btnThemMoi.Text = "Sửa dự toán";
                btnThemMoi.ImageIndex = 2;
            }
            else
            {
                btnThemMoi.Text = "Lập dữ toán";
                btnThemMoi.ImageIndex = 1;
            }
            //   SortDuToan(lstDuToanDoanRa);
            grvDuToan.DataSource = lstDuToanDoanRa;
            grvDuToan.RefreshDataSource();
        }

        private void gvDuToan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gvDuToan.FocusedRowHandle < 0) return;
            VnsDuToanDoan tmp = (VnsDuToanDoan)gvDuToan.GetRow(gvDuToan.FocusedRowHandle);
            tmp.CongTacId = objDoanCongTac.Id;
            switch (e.Column.Name)
            {
                case "colMaMuc":
                    VnsDmMucTieuMuc tmpMuc = (VnsDmMucTieuMuc)cboTenMuc.GetDataSourceRowByKeyValue(tmp.MucId);
                    tmp.TenKhoanChi = tmpMuc.TenMuc;
                    break;
            }
        }

        private void gvDuToan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            if (Commons.GridHelper.CheckAddNewRow(gvDuToan))
            {
                ThemDong();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDuToan.RowCount > 0)
                {
                    IList<VnsInQtTu> lstIn = VnsDuToanDoanService.GetDataInDt(objDoanCongTac.Id);
                    foreach (VnsInQtTu obj in lstIn)
                    {
                        obj.MaMucCha = GetMaMucTieuMucById(obj.IdMucCha);
                    }
                    Reports.FrmThamSoBaoCao frm = (FrmThamSoBaoCao)ObjectFactory.GetObject("FrmThamSoBaoCao");
                    frm.LoaiBaoCao = false;
                    frm.lstIn = lstIn;
                    frm.objDoanCongTac = objDoanCongTac;
                    frm.Show();
                    //Reports.InBiaQuyetToan rptBia = (InBiaQuyetToan)ObjectFactory.GetObject("InBiaQuyetToan");// new Reports.InBiaQuyetToan(lstIn, objDoanCongTac, "DT");
                    //rptBia.LoadData(lstIn, objDoanCongTac, "DT");
                    //rptBia.ShowPreview();

                    //Reports.InQuyetToan rptInQt = new Reports.InQuyetToan(lstIn, objDoanCongTac, "DT");
                    //rptInQt.ShowPreview();
                }
                else
                {
                    Commons.Commons.Message_Warning("Đoàn ra chưa được dự toán");
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private String GetMaMucTieuMucById(Guid id)
        {
            IList<VnsDmMucTieuMuc> lstMtm = VnsDmMucTieuMucService.GetAll();
            foreach (VnsDmMucTieuMuc obj in lstMtm)
            {
                if (obj.Id == id)
                    return obj.MaMuc;
            }
            return "";
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDoanRa.FocusedRowHandle < 0) return;

                FrmEditDuToan frm = (FrmEditDuToan)ObjectFactory.GetObject("FrmEditDuToan");
                frm.DoanRa = objDoanCongTac;
                frm.LanDuToan = 0;
                frm.Show();
                LoadGridDetail();

            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void btnDuToanBx_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDoanRa.FocusedRowHandle < 0) return;

                FrmEditDuToan frm = (FrmEditDuToan)ObjectFactory.GetObject("FrmEditDuToan");
                frm.DoanRa = objDoanCongTac;
                frm.LanDuToan = 1;
                frm.Show();
                LoadGridDetail();

            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void gvDoanRa_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column.Name == "STT")
                {
                    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
        }

        


        //private void SortDuToan(IList<VnsDuToanDoan> lstDuToanTemp)
        //{
        //    for (int i = 0; i < lstDuToanTemp.Count - 1; i++)
        //    {
        //        for (int j=i+1;j<lstDuToanTemp.Count;j++)
        //        {
        //            Guid MucId = (Guid)lstDuToanTemp[i].MucId;
        //            Guid MucIdtemp = (Guid)lstDuToanTemp[j].MucId;
        //            VnsDmMucTieuMuc objMuc1 = this.VnsDmMucTieuMucService.GetById(MucId);
        //            VnsDmMucTieuMuc objMuc2 = this.VnsDmMucTieuMucService.GetById(MucIdtemp);
        //            if (objMuc1 != null && objMuc2 != null && objMuc1.ThuTu > objMuc2.ThuTu)
        //            {
        //                VnsDuToanDoan objDuToanTemp = lstDuToanTemp[i];
        //                lstDuToanTemp[i] = lstDuToanTemp[j];
        //                lstDuToanTemp[j] = objDuToanTemp;
        //            }
        //        }
        //    }
        //}
    }
}
