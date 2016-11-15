using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vns.QuanLyDoanRa.Service;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.QuanLyDoanRa.Domain;
using Vns.Erp.Core;
using System.Reflection;

namespace QuanLyDoanRa
{
    public partial class frmSearchChungTu : DevExpress.XtraEditors.XtraForm
    {
        public frmSearchChungTu()
        {
            InitializeComponent();
        }

        #region"Public properties"

        public IVnsLoaiChungTuService VnsLoaiChungTuService;
        public IVnsDoanCongTacService VnsDoanCongTacService;
        public IVnsLoaiDoanRaService VnsLoaiDoanRaService;
        public IVnsChungTuService VnsChungTuService;
        public IVnsGiaoDichService VnsGiaoDichService;
        public IVnsNghiepVuService VnsNghiepVuService;
        public IVnsNgoaiTeService VnsNgoaiTeService;
        #endregion

        #region"Variables"

        #endregion

        #region"Functions"

        private void BindDataToCbo()
        { 
            //Bind loai ct
            List<VnsLoaiChungTu> lstLoaiCt = new List<VnsLoaiChungTu>();
            VnsLoaiChungTu objChungTu = new VnsLoaiChungTu();
            lstLoaiCt.Add(objChungTu);
            lstLoaiCt.AddRange(VnsLoaiChungTuService.GetAll());
            cboLoaiCt.Properties.DataSource = lstLoaiCt;
            cboLoaiCt.Properties.DisplayMember = "Ten";
            cboLoaiCt.Properties.ValueMember = "MaLoaiChungTu";

            //Bind DoanCtac
            List<VnsDoanCongTac> lstDoanCongTac = new List<VnsDoanCongTac>();
            lstDoanCongTac.Add(new VnsDoanCongTac());
            lstDoanCongTac.AddRange(VnsDoanCongTacService.GetAll());
            cboDoanRa.Properties.DataSource = lstDoanCongTac;
            cboDoanRa.Properties.ValueMember = "Id";
            cboDoanRa.Properties.DisplayMember = "Ten";

            List<VnsLoaiDoanRa> lstLoaiDoanRa = new List<VnsLoaiDoanRa>();// VnsLoaiDoanRaService.GetAll();
            lstLoaiDoanRa.Add(new VnsLoaiDoanRa());
            lstLoaiDoanRa.AddRange(VnsLoaiDoanRaService.GetAll());
            cboLoaiDoanRa.Properties.DataSource = lstLoaiDoanRa;
            cboLoaiDoanRa.Properties.ValueMember = "Id";
            cboLoaiDoanRa.Properties.DisplayMember = "TenLoaiDoanRa";

            List<VnsNgoaiTe> lstNgoaiTe = new List<VnsNgoaiTe>();
            lstNgoaiTe.Add(new VnsNgoaiTe());
            lstNgoaiTe.AddRange(VnsNgoaiTeService.GetAll());
            cboNgoaiTe.DataSource = lstNgoaiTe;

            ////_GridView.Columns
            IList<VnsNghiepVu> lstNghiepVu = VnsNghiepVuService.GetAll();
            cboNghiepVuNo.DataSource = lstNghiepVu;
            CboNghiepVuCo.DataSource = lstNghiepVu;

            //IList<VnsDoanCongTac> lstDoanCongTac = VnsDoanCongTacService.GetAll();
            cboDoanRaNoId.DataSource = lstDoanCongTac;
            cboDoanRaCoId.DataSource = lstDoanCongTac;

            cboLoaiDoanRaCoId.DataSource = lstLoaiDoanRa;
            cboLoaiDoanRaNoId.DataSource = lstLoaiDoanRa;

            cboNgoaiTeId.Properties.DataSource = lstNgoaiTe;
            cboNgoaiTeId.Properties.DisplayMember = "MaNgoaiTe";
            cboNgoaiTeId.Properties.ValueMember = "Id";

        }

        private void Search()
        {
            string pMaLoaiCt =(cboLoaiCt.EditValue == null ? "": cboLoaiCt.EditValue.ToString());
            DateTime pTuNgay = dteTuNgay.DateTime ;
            DateTime pDenNgay = dteDenNgay.DateTime;
            Guid pDoanRaId =(cboDoanRa.EditValue == null ? new Guid() : new Guid(cboDoanRa.EditValue.ToString()));
            Guid pLoaiDoanRaId =(cboLoaiDoanRa.EditValue == null ? new Guid() : new Guid(cboLoaiDoanRa.EditValue.ToString()));
            Guid pNgoaiTeId = (cboNgoaiTeId.EditValue == null ? new Guid() : new Guid(cboNgoaiTeId.EditValue.ToString()));

            Decimal pSoTienTu;
            if (txtSoTienTu.Text.Trim ()== "")
                pSoTienTu=0;
            else
                pSoTienTu = decimal.Parse(txtSoTienTu.Text);

            Decimal pSoTienDen;

            if(txtSoTienDen.Text.Trim()=="")
                pSoTienDen=0;
            else
                pSoTienDen= decimal.Parse(txtSoTienDen.Text);

            Decimal pSoTienVNDTu;
            if (txtSoTienVNDTu.Text.Trim() == "")
                pSoTienVNDTu = 0;
            else
                pSoTienVNDTu = decimal.Parse(txtSoTienVNDTu.Text);

            Decimal pSoTienVNDDen;

            if (txtSoTienVNDDen.Text.Trim() == "")
                pSoTienVNDDen = 0;
            else
                pSoTienVNDDen = decimal.Parse(txtSoTienVNDDen.Text);

            String pNguoiTamUng = txtNguoiTamUng.Text;
            String pNoiDung = txtNoiDung.Text;
            String pMaTkCo = txtMaTkCo.Text.Trim();
            String pMaTkNo = txtMaTkNo.Text.Trim();
            IList<VnsChungTu> lstChungTu = VnsChungTuService.SearchChungTu(pMaLoaiCt, pTuNgay, pDenNgay,pMaTkNo,pMaTkCo, pDoanRaId, pLoaiDoanRaId, 
                pNgoaiTeId, 
                pSoTienTu, pSoTienDen, 
                pSoTienVNDTu, pSoTienVNDDen,
                pNguoiTamUng, pNoiDung);
            grcDanhSach.DataSource = lstChungTu;

            if (lstChungTu.Count == 0)
            {
                grcChiTiet.DataSource = new List<VnsGiaoDich>();
            }
        }


        private MethodInfo GetMethodByName(Form frmContainer, string methodName)
        {
            try
            {
                Type type = frmContainer.GetType();
                MethodInfo methodReturn = type.GetMethod(methodName);
                return methodReturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void setFocusGridview(Guid CtId)
        {
            List<VnsChungTu> lst = new List<VnsChungTu>();
            lst = (List<VnsChungTu>)grvDanhSach.DataSource;
            for (int i = 0; i < grvDanhSach.RowCount; i++)
            {
                if (lst[i].Id == CtId)
                {
                    grvDanhSach.FocusedRowHandle = i;
                    return;
                }
            }
        }

        #endregion

        #region"Events"

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }

        }

        private void grvDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (grvDanhSach.FocusedRowHandle < 0) return;

                VnsChungTu ObjChungTu = (VnsChungTu)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
                if (ObjChungTu != null)
                {
                    IList<VnsGiaoDich> lstGiaoDich = VnsGiaoDichService.GetByChungTu(ObjChungTu.Id);
                    grcChiTiet.DataSource = lstGiaoDich;
                }
                
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }

        }

        private void frmSearchChungTu_Load(object sender, EventArgs e)
        {
            try
            {
                dteTuNgay.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dteDenNgay.DateTime = dteTuNgay.DateTime.AddMonths(1).AddDays(-1);

                BindDataToCbo();
                Search();
            }
            catch(Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grvDanhSach.FocusedRowHandle < 0) return;
                VnsChungTu ObjChungTu = (VnsChungTu)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
                VnsLoaiChungTu objLoaiChungTu = VnsLoaiChungTuService.GetByMa(ObjChungTu.MaLoaiChungTu);
                Type formType = Type.GetType(objLoaiChungTu.DuongDan);
                Form frm = (Form)ObjectFactory.GetObject(objLoaiChungTu.DuongDan);
                String FormName = frm.Name;
                MethodInfo method_show_form = null;

                object[] arrParam = new object[] { ObjChungTu, FormUpdate.Update, objLoaiChungTu.MaDmCha};

                method_show_form = GetMethodByName(frm, "Show_Form");
                method_show_form.Invoke(frm, arrParam);

                btnTimKiem_Click(btnTimKiem, null);
                //grvDanhSach_FocusedRowChanged(grvDanhSach, null);
                setFocusGridview(ObjChungTu.Id);
                
            }
            catch
            {
                Commons.Commons.Message_Information("Không có form chi tiết");
            }
        }

        #endregion

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvDanhSach.FocusedRowHandle < 0) return;

            if (Commons.Commons.Message_Confirm("Bạn có chắc chắn xóa bản ghi?", false))
            {
                VnsChungTu ObjChungTu = (VnsChungTu)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
                VnsChungTuService.DeleteChungTu(ObjChungTu);

                Search();
            }
            //if (ObjChungTu != null)
            //{
            //    IList<VnsGiaoDich> lstGiaoDich = VnsGiaoDichService.GetByChungTu(ObjChungTu.Id);
            //    grcChiTiet.DataSource = lstGiaoDich;
            //}
        }
    }
}