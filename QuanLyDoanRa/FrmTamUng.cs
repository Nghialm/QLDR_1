using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vns.Erp.Core;
using Vns.Erp.Core.Domain;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.QuanLyDoanRa.Domain;
using QuanLyDoanRa.Reports;
using System.Collections;

namespace QuanLyDoanRa
{
    public partial class FrmTamUng : Form
    {

        #region Variables
        //Service
        public IVnsLoaiChungTuService VnsLoaiChungTuService;
        public IVnsGiaoDichService VnsGiaoDichService;
        public IVnsChungTuService VnsChungTuService;
        public IVnsNghiepVuService VnsNghiepVuService;
        public IVnsDoanCongTacService VnsDoanCongTacService;
        public IVnsLoaiDoanRaService VnsLoaiDoanRaService;

        private String MaLoaiChungTu;
        private VnsLoaiChungTu objLoaiChungTu;
        private VnsChungTu objChungTu = new VnsChungTu();
        private IList<VnsGiaoDich> lstGiaoDich;

        //Phan trang
        private int PgSize = General .NumberOfPage;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;
        #endregion

        #region Contructor

        public FrmTamUng()
        {
            InitializeComponent();
        }

        #endregion

        #region Function

        private void TongSoTrang()
        {
            int rowCount = VnsChungTuService.GetRowCount(MaLoaiChungTu);
            //int rowCount = VnsChungTuService.GetCount();
            TotalPage = rowCount / PgSize;
            if (rowCount % PgSize > 0)
                TotalPage += 1;
        }

        private void LoadData(int CurrentPageIndex)
        {
            TongSoTrang();

            IList Props = new ArrayList();
            IList Values = new ArrayList();
            Props.Add("MaLoaiChungTu");
            Values.Add(MaLoaiChungTu);
            
            txtTrangHienTai.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();

            //IList<VnsChungTu> lstLoaiChungTu = VnsChungTuService.LoadByChungTu(MaLoaiChungTu);
            IList<VnsChungTu> lstLoaiChungTu = VnsChungTuService.ListLike((CurrentPageIndex - 1) * PgSize, PgSize, Props, Values, null, null, null);
            grcDanhSach.DataSource = lstLoaiChungTu;
        }

        private void LoadDataDetail(Guid ChungTuId)
        {
            IList<VnsGiaoDich> lstDetail = VnsGiaoDichService.GetByChungTu(ChungTuId);
            lstGiaoDich = lstDetail;
            grcChiTiet.DataSource = lstDetail;
        }

        private void BindCombo()
        {
            //_GridView.Columns
            IList<VnsNghiepVu> lstNghiepVu = VnsNghiepVuService.GetAll();
            cboNghiepVuNo.DataSource = VnsNghiepVuService.GetDatasourceByLoaiCt(lstNghiepVu, objLoaiChungTu);
            CboNghiepVuCo.DataSource = VnsNghiepVuService.GetDatasourceByLoaiCt(lstNghiepVu, objLoaiChungTu);

            List<VnsDoanCongTac> lstDoanCongTac = new List<VnsDoanCongTac>();
            lstDoanCongTac.Add(new VnsDoanCongTac());
            lstDoanCongTac.AddRange(VnsDoanCongTacService.GetAll());
            cboDoanRaNoId.DataSource = lstDoanCongTac;
            cboDoanRaCoId.DataSource = lstDoanCongTac;

            List<VnsLoaiDoanRa> lstLoaiDoanRa = new List<VnsLoaiDoanRa>();
            lstLoaiDoanRa.Add(new VnsLoaiDoanRa());
            lstLoaiDoanRa.AddRange(VnsLoaiDoanRaService.GetAll());
            cboLoaiDoanRaCoId.DataSource = lstLoaiDoanRa;
            cboLoaiDoanRaNoId.DataSource = lstLoaiDoanRa;

        }

        private void SetColumnByLoaiPhieu(decimal _LoaiPhieu)
        {
            if (_LoaiPhieu == 1)
            {
                //Phieu chi(co tren no duoi)
                grvChiTiet.Columns["TkNoId"].Visible = true;
                grvChiTiet.Columns["TenTkNo"].Visible = true;
                grvChiTiet.Columns["DoanRaNoId"].Visible = true;
                grvChiTiet.Columns["LoaiDoanRaNoId"].Visible = true;
                //_GridView.Columns["MucTieuMucNoId"].Visible = true;

                grvChiTiet.Columns["TkCoId"].Visible = false;
                grvChiTiet.Columns["TenTkCo"].Visible = false;
                grvChiTiet.Columns["DoanRaCoId"].Visible = false;
                grvChiTiet.Columns["LoaiDoanRaCoId"].Visible = false;
                //_GridView.Columns["MucTieuMucCoId"].Visible = false;
            }
            else
            {
                grvChiTiet.Columns["TkCoId"].Visible = true;
                grvChiTiet.Columns["TenTkCo"].Visible = true;
                grvChiTiet.Columns["DoanRaCoId"].Visible = true;
                grvChiTiet.Columns["LoaiDoanRaCoId"].Visible = true;
                //_GridView.Columns["MucTieuMucCoId"].Visible = true;

                grvChiTiet.Columns["TkNoId"].Visible = false;
                grvChiTiet.Columns["TenTkNo"].Visible = false;
                grvChiTiet.Columns["DoanRaNoId"].Visible = false;
                grvChiTiet.Columns["LoaiDoanRaNoId"].Visible = false;
                // _GridView.Columns["MucTieuMucNoId"].Visible = false;
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

        private void addNew()
        {
            FrmEditTamUng frmEditTamUng = (FrmEditTamUng)ObjectFactory.GetObject("frmEditTamUng");

            Guid IdReturn = frmEditTamUng.Show_Form(objLoaiChungTu, null, FormUpdate.Insert);

            if (IdReturn != new Guid())
            {
                LoadData(CurrentPageIndex);
                LoadDataDetail(IdReturn);
                setFocusGridview(IdReturn);
            }
        }

        private void Edit()
        { 
            int i = grvDanhSach.FocusedRowHandle;

            objChungTu = (VnsChungTu)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);

            FrmEditTamUng frmEditTamUng = (FrmEditTamUng)ObjectFactory.GetObject("frmEditTamUng");

            Guid IdReturn = frmEditTamUng.Show_Form(objLoaiChungTu, objChungTu, FormUpdate.Update);

            if (IdReturn != new Guid())
            {
                LoadData(CurrentPageIndex);
                LoadDataDetail(IdReturn);
                grvDanhSach.FocusedRowHandle = i;
            }
        }

        #endregion

        #region Event

        private void btnPrint_Click(object sender, EventArgs e)
        {
            grcDanhSach.ShowPrintPreview();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                addNew();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void FrmTamUng_Load(object sender, EventArgs e)
        {
            MaLoaiChungTu = this.AccessibleDescription;

            objLoaiChungTu = VnsLoaiChungTuService.GetByMa(MaLoaiChungTu);
            if (objLoaiChungTu != null)
                this.Text = objLoaiChungTu.Ten;

            BindCombo();
            LoadData(CurrentPageIndex);

            //if (objLoaiChungTu.MaLoaiChungTu == "PT" || objLoaiChungTu.MaLoaiChungTu == "PC")
            //{
            //    btnInCtu.Visible = true;
            //}
            //else
            //{
            //    btnInCtu.Visible = false;
            //}

            groupControlDs.Text = "Danh sách " + objLoaiChungTu.Ten;
            SetColumnByLoaiPhieu(objLoaiChungTu.LoaiPhieu);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {            
            try
            {
                if (grvDanhSach.FocusedRowHandle < 0)
                {
                    Commons.Commons.Message_Warning("Không có bản ghi nào được lựa chọn");
                    return;
                }

                Edit();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData(CurrentPageIndex);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grvDanhSach.FocusedRowHandle < 0)
            {
                MessageBox.Show("Không có bản ghi nào được lựa chọn", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objChungTu = (VnsChungTu)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
            if (this.objChungTu != null)
            {
                if (MessageBox.Show("Bạn có muốn chứng từ " + objChungTu.SoCt, "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.VnsChungTuService.DeleteById(objChungTu.Id);
                    LoadData(CurrentPageIndex);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvDanhSach_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            objChungTu = (VnsChungTu)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
            if (objChungTu != null)
                LoadDataDetail(objChungTu.Id);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDanhSach.RowCount == 0)
                {
                    Commons.Commons.Message_Warning("Không có bản ghi nào được lựa chọn");
                    return;
                }

                frmInPhieu frm = new frmInPhieu(objChungTu, lstGiaoDich, objLoaiChungTu);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void FrmTamUng_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
                {
                    btnThem_Click(btnThem, null);
                }
                else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
                {
                    btnSua_Click(btnSua, null);
                }
                else if (e.KeyCode == Keys.D && e.Modifiers == Keys.Control)
                {
                    btnXoa_Click(btnXoa, null);
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void btnTrangDau_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = 1;
            LoadData(CurrentPageIndex);
            grvDanhSach_FocusedRowChanged(grvDanhSach, null);
        }

        private void btnTrangTruoc_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex > 1)
            {
                CurrentPageIndex = CurrentPageIndex - 1;
                LoadData(CurrentPageIndex);
                grvDanhSach_FocusedRowChanged(grvDanhSach, null);
            }
        }

        private void btnTrangSau_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex < TotalPage)
            {
                CurrentPageIndex = CurrentPageIndex + 1;
                LoadData(CurrentPageIndex);
                grvDanhSach_FocusedRowChanged(grvDanhSach, null);
            }
        }

        private void btnTrangCuoi_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = TotalPage;
            LoadData(CurrentPageIndex);
            grvDanhSach_FocusedRowChanged(grvDanhSach, null);
        }

        #endregion 
    }
}
