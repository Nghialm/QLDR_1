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
using System.Collections;
using QuanLyDoanRa.Reports;

namespace QuanLyDoanRa
{
    public partial class FrmUyNhiemChi : Form
    {
        #region Variables

        public IVnsLoaiChungTuService VnsLoaiChungTuService;
        public IVnsGiaoDichService VnsGiaoDichService;
        public IVnsChungTuService VnsChungTuService;
        public IVnsNghiepVuService VnsNghiepVuService;
        public IVnsDoanCongTacService VnsDoanCongTacService;
        public IVnsLoaiDoanRaService VnsLoaiDoanRaService;
        public IVnsDmKhachHangService VnsDmKhachHangService;
        public IVnsNgoaiTeService VnsNgoaiTeService;
        private String NhomLoaiChungTu;
        //private VnsLoaiChungTu objLoaiChungTu;
        private VnsChungTu objChungTu = new VnsChungTu();
        private IList<VnsGiaoDich> lstGiaoDich = new List<VnsGiaoDich>();
        //Phan trang
        private int PgSize = General.NumberOfPage;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;

        #endregion

        #region Functions

        public FrmUyNhiemChi()
        {
            InitializeComponent();
        }

        private void addNew()
        {
            FrmUyNhiemChiEdit frmUyNhiemChi = (FrmUyNhiemChiEdit)ObjectFactory.GetObject("frmUyNhiemChiEdit");

            Guid IdReturn = frmUyNhiemChi.Show_Form(null, FormUpdate.Insert,this.AccessibleDescription);

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

            FrmUyNhiemChiEdit frmEditTamUng = (FrmUyNhiemChiEdit)ObjectFactory.GetObject("frmUyNhiemChiEdit");

            Guid IdReturn = frmEditTamUng.Show_Form(objChungTu, FormUpdate.Update, this.AccessibleDescription);

            if (IdReturn != new Guid())
            {
                LoadData(CurrentPageIndex);
                LoadDataDetail(IdReturn);
                grvDanhSach.FocusedRowHandle = i;
                if (i == 0)
                    grvDanhSach_FocusedRowChanged(grvDanhSach, null);
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

        private void TongSoTrang()
        {
            int rowCount = VnsChungTuService.GetRowCount(NhomLoaiChungTu);
            TotalPage = rowCount / PgSize;
            if (rowCount % PgSize > 0)
                TotalPage += 1;
        }

        private void LoadData(int CurrentPageIndex)
        {
            TongSoTrang();

            IList Props = new ArrayList();
            IList Values = new ArrayList();
            Props.Add("NhomCt");
            Values.Add(NhomLoaiChungTu);

            VnsOrder objNgayCt = new VnsOrder(false, "NgayCt");
            VnsOrder objSoCt = new VnsOrder(false, "SoCt");
            IList<VnsOrder> orders = new List<VnsOrder>();
            orders.Add(objNgayCt);
            orders.Add(objSoCt);

            txtTrangHienTai.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
            IList<VnsChungTu> lstLoaiChungTu = VnsChungTuService.ListLike((CurrentPageIndex - 1) * PgSize, PgSize, Props, Values, null, null, orders);
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
            cboNghiepVuNo.DataSource = lstNghiepVu;
            CboNghiepVuCo.DataSource = lstNghiepVu;

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

            List<VnsNgoaiTe> lstNgoaiTe = new List<VnsNgoaiTe>();
            //lstNgoaiTe.Add(new VnsNgoaiTe());
            lstNgoaiTe.AddRange(VnsNgoaiTeService.GetAll());
            cboNgoaiTe.DataSource = lstNgoaiTe;
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

        #endregion

        #region Events

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
            NhomLoaiChungTu = this.AccessibleDescription;

            //objLoaiChungTu = VnsLoaiChungTuService.GetByMa(MaLoaiChungTu);
            //if (objLoaiChungTu != null)
            //    this.Text = objLoaiChungTu.Ten;
            if (NhomLoaiChungTu == "NPT")
            {
                this.Text = "Phiếu thu";
            }
            else if(NhomLoaiChungTu =="NPC")
            {
                this.Text = "Phiếu chi";
            }
            else if (NhomLoaiChungTu == "KTK")
            {
                this.Text = "Phiếu kế toán khác";
            }
            else if (NhomLoaiChungTu == "GBN")
            {
                this.Text = "Giấy báo nợ";
            }
            else if (NhomLoaiChungTu == "GBC")
            {
                this.Text = "Giấy báo có";
            }
            
            BindCombo();
            LoadData(CurrentPageIndex);

            //groupControlDs.Text = "Danh sách " + objLoaiChungTu.Ten;
            //SetColumnByLoaiPhieu(objLoaiChungTu.LoaiPhieu);

            //if (objLoaiChungTu.MaLoaiChungTu == "UNC" || objLoaiChungTu.MaLoaiChungTu == "GBN")
            //{
            //    btnInUyNhiemChi.Visible = true;
            //}
            //else
            //{
            //    btnInUyNhiemChi.Visible = false;
            //}
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDanhSach.RowCount ==0 || grvDanhSach.FocusedRowHandle < 0)
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
            if (grvDanhSach.RowCount == 0 || grvDanhSach.FocusedRowHandle < 0)
            {
                Commons.Commons.Message_Warning("Không có bản ghi nào được lựa chọn");
                return;
            }

            objChungTu = (VnsChungTu)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
            if (this.objChungTu != null)
            {
                if (Commons.Commons.Message_Confirm("Bạn có muốn xóa bản ghi này không?"))
                {
                    this.VnsChungTuService.DeleteChungTu(objChungTu);
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
            if (objChungTu == null) return;
            LoadDataDetail(objChungTu.Id);
        }

        private void FrmUyNhiemChi_KeyDown(object sender, KeyEventArgs e)
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

        #endregion

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

        private void btnInCtu_Click(object sender, EventArgs e)
        {
            try
            {
                popView.ShowPopup(Control.MousePosition);
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }        

        private void barInCt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (grvDanhSach.RowCount == 0 || grvDanhSach.FocusedRowHandle < 0)
                {
                    Commons.Commons.Message_Warning("Không có bản ghi nào được lựa chọn");
                    return;
                }
                VnsLoaiChungTu objLoaiCt = VnsLoaiChungTuService.GetByMa(objChungTu.MaLoaiChungTu);
                frmInPhieu frm = new frmInPhieu(objChungTu, lstGiaoDich, objLoaiCt);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void barInUNC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (grvDanhSach.RowCount == 0 || grvDanhSach.FocusedRowHandle < 0)
                {
                    Commons.Commons.Message_Warning("Không có bản ghi nào được lựa chọn");
                    return;
                }

                VnsDmKhachHang objKhachHang = VnsDmKhachHangService.GetById(lstGiaoDich[0].KhachHangCoId);
                if (objKhachHang == null)
                    objKhachHang = new VnsDmKhachHang();
                Decimal SoTien = 0;
                foreach (VnsGiaoDich obj in lstGiaoDich)
                {
                    SoTien = SoTien + obj.SoTienNt;
                    obj.NoiDung = objChungTu.NoiDung;
                }
                InUyNhiemChi PrintUyNhiem = new InUyNhiemChi(objChungTu,objKhachHang, lstGiaoDich, SoTien, objChungTu.NgayCt);
                PrintUyNhiem.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }
    }
}
