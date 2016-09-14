using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.Erp.Core.Domain;
using Vns.QuanLyDoanRa.Domain;
using Vns.Erp.Core;
using Vns.QuanLyDoanRa.Domain.Report;
using QuanLyDoanRa.Reports;
using System.Collections;

namespace QuanLyDoanRa
{
    public partial class FrmQuyetToanDoan : Form
    {
        #region Service
        public IVnsDoanCongTacService VnsDoanCongTacService;
        public IVnsDuToanDoanService VnsDuToanDoanService;

        private IVnsQuyetToanDoanService _VnsQuyetToanDoanService;
        public IVnsQuyetToanDoanService VnsQuyetToanDoanService
        {
            get { return _VnsQuyetToanDoanService; }
            set { _VnsQuyetToanDoanService = value; }
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
        public IVnsDmHeThongService VnsDmHeThongService;

        private Vns.QuanLyDoanRa.Domain.VnsQuyetToanDoan _QuyetToan;
        public Vns.QuanLyDoanRa.Domain.VnsQuyetToanDoan QuyetToan
        {
            get { return _QuyetToan; }
            set { _QuyetToan = value; }
        }

        public IVnsLoaiChungTuService VnsLoaiChungTuService;
        public IVnsNghiepVuService VnsNghiepVuService;
        public IVnsChungTuService VnsChungTuService;
        #endregion

        #region Property
        private VnsDoanCongTac objDoanCongTac;
        #endregion


        public FrmQuyetToanDoan()
        {
            InitializeComponent();
        }
        private int PgSize = General.NumberOfPage;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;

        private IList<VnsDoanCongTac> lstDoanCongTac = new List<VnsDoanCongTac>();
        private List<VnsQuyetToanDoan> lstQuyetToanDoanRa = new List<VnsQuyetToanDoan>();
        private IList<VnsQuyetToanDoan> lstDelQuyetToanDoanRa = new List<VnsQuyetToanDoan>();
        IList<VnsDuToanDoan> lstDuToanDoanRa = new List<VnsDuToanDoan>();

        private void TongSoTrang()
        {
            int rowCount = this.VnsDoanCongTacService.GetCount();
            TotalPage = rowCount / PgSize;
            if (rowCount % PgSize > 0)
                TotalPage += 1;
        }

        private void BindingData(int CurrentPageIndex)
        {
            this.grcDoanRa.DataSource = this.VnsDoanCongTacService.ListLike(-1, -1, null, null, null, null, null);
        }

        private void BindData()
        {
            lstDoanCongTac = this.VnsDoanCongTacService.GetDoanRaTongHopQT(0);

            foreach (VnsDoanCongTac obj in lstDoanCongTac)
            {
                obj.NgayDt = obj.DanhSachDuToanDoan.Count == 0 ? "" : obj.DanhSachDuToanDoan[0].NgayDuToan.ToString("dd/MM/yyyy");
                obj.NgayQt = obj.NgayQuyetToan.Year == DateTime.MaxValue.Year ? "" : obj.NgayQuyetToan.ToString("dd/MM/yyyy");
            }

            grcDoanRa.DataSource = lstDoanCongTac;
            grvDoanRa.RefreshData();
            if (lstDoanCongTac.Count > 0)
                grvDoanRa.FocusedRowHandle = 0;
        }

        private void BindCombo()
        {
            cboMucId.DataSource = VnsDmMucTieuMucService.GetAll();
        }
        private void FrmQuyetToanDoan_Load(object sender, EventArgs e)
        {
            BindCombo();
            BindData();
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDoanRa_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grvDoanRa.FocusedRowHandle < 0) return;
            objDoanCongTac = (VnsDoanCongTac)grvDoanRa.GetRow(grvDoanRa.FocusedRowHandle);
            if (objDoanCongTac == null)
                return;
            LoadGridDetail(objDoanCongTac.Id);
        }

        private void LoadGridDetail(Guid DoanRaId)
        {
            lstQuyetToanDoanRa = new List<VnsQuyetToanDoan>();

            IList<VnsDoanCongTac> lstDoanCongTac = VnsDoanCongTacService.GetDoanRaByDoanRaBanDau(DoanRaId);
            foreach (VnsDoanCongTac obj in lstDoanCongTac)
            {
                lstQuyetToanDoanRa.AddRange(obj.DanhSachQuyetToanDoan);
            }

            grcQuyetToan.DataSource = lstQuyetToanDoanRa;
            grvQuyetToan.RefreshData();
        }

        private void setFocusGridview(Guid DoanRaId)
        {
            List<VnsDoanCongTac> lst = new List<VnsDoanCongTac>();
            lst = (List<VnsDoanCongTac>)grvDoanRa.DataSource;
            for (int i = 0; i < grvDoanRa.RowCount; i++)
            {
                if (lst[i].Id == DoanRaId)
                {
                    grvDoanRa.FocusedRowHandle = i;
                    return;
                }
            }
        }

        private void btnInQt_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDoanRa.RowCount == 0)
                {
                    Commons.Commons.Message_Warning("Không có bản ghi nào được lựa chọn");
                    return;
                }
                if (objDoanCongTac == null)
                    objDoanCongTac = (VnsDoanCongTac)grvDoanRa.GetRow(grvDoanRa.FocusedRowHandle);
                if (objDoanCongTac.TrangThai == 2)
                {
                    VnsQuyetToanDoan objQt = (VnsQuyetToanDoan)grvQuyetToan.GetRow(grvQuyetToan.FocusedRowHandle);
                    if (objQt == null)
                    {
                        Commons.Commons.Message_Warning("Chưa chọn lần quyết toán");
                        return;
                    }

                    if (objQt.LanQuyetToan == 0)
                    {
                        IList<VnsInQtTu> lstIn = VnsQuyetToanDoanService.GetDataInQt(objDoanCongTac.Id);
                        foreach (VnsInQtTu obj in lstIn)
                        {
                            obj.MaMucCha = GetMaMucTieuMucById(obj.IdMucCha);
                        }
                        Reports.FrmThamSoBaoCao frm = (FrmThamSoBaoCao)ObjectFactory.GetObject("FrmThamSoBaoCao");
                        frm.LoaiBaoCao = true;
                        frm.KieuBaoCao = true;
                        frm.lstIn = lstIn;
                        frm.objDoanCongTac = objDoanCongTac;
                        frm.Show();
                    }
                    else
                    {
                        IList<VnsInQtTu> lstIn = VnsQuyetToanDoanService.GetDataInQTbyDoanCtac(objQt.CongTacId, -1);
                        VnsDoanCongTac tmp = VnsDoanCongTacService.Get(objQt.CongTacId);
                        foreach (VnsInQtTu obj in lstIn)
                        {
                            obj.MaMucCha = GetMaMucTieuMucById(obj.IdMucCha);
                        }
                        Reports.FrmThamSoBaoCao frm = (FrmThamSoBaoCao)ObjectFactory.GetObject("FrmThamSoBaoCao");
                        frm.LoaiBaoCao = true;
                        frm.KieuBaoCao = false;
                        frm.lstIn = lstIn;
                        frm.objDoanCongTac = tmp;
                        frm.Show();

                    }
                }
                else
                    Commons.Commons.Message_Warning("Đoàn ra chưa được quyết toán");
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

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmQuyetToanDoanEdit frm = (FrmQuyetToanDoanEdit)ObjectFactory.GetObject("FrmQuyetToanDoanEdit");
            VnsDoanCongTac obj = (VnsDoanCongTac)grvDoanRa.GetRow(grvDoanRa.FocusedRowHandle);
            if (obj == null)
            {
                Commons.Commons.Message_Warning("Bạn chưa chọn đoàn ra cần lập quyết toán");
                return;
            }
            if (obj.DanhSachQuyetToanDoan != null && obj.DanhSachQuyetToanDoan.Count > 0)
            {
                Commons.Commons.Message_Warning("Đoàn ra đã đươc quyết toán, chọn 'Sửa quyết toán' nếu muốn sửa quyết toán đã lập!");
                return;
            }

            Guid DoanRaId = frm.Show_Form(FormUpdate.Insert, obj.IdBanDau, this.AccessibleDescription, 0);
            if (DoanRaId != new Guid())
            {
                //this.BindData();
                loadDataAfterAddOrEdit(DoanRaId);
                this.LoadGridDetail(DoanRaId);
                setFocusGridview(DoanRaId);
            }
        }

        private void loadDataAfterAddOrEdit(Guid DoanRaId)
        {
            if (DoanRaId != new Guid())
            {
                int index = 0;
                for (int i = 0; i <= lstDoanCongTac.Count; i++)
                {
                    VnsDoanCongTac objTem = lstDoanCongTac[i];
                    if (objTem.IdBanDau == DoanRaId || objTem.CongTacId == DoanRaId)
                    {
                        lstDoanCongTac.RemoveAt(i);
                        index = i;
                        break;
                    }
                }

                VnsDoanCongTac obj = this.VnsDoanCongTacService.GetById(DoanRaId);
                obj.NgayDt = obj.DanhSachDuToanDoan.Count == 0 ? "" : obj.DanhSachDuToanDoan[0].NgayDuToan.ToString("dd/MM/yyyy");
                obj.NgayQt = obj.NgayQuyetToan.Year == DateTime.MaxValue.Year ? "" : obj.NgayQuyetToan.ToString("dd/MM/yyyy");
                lstDoanCongTac.Insert(index, obj);
                grvDoanRa.RefreshData();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDoanRa.RowCount == 0)
                {
                    Commons.Commons.Message_Warning("Không có bản ghi nào được lựa chọn");
                    return;
                }
                int i = grvDoanRa.FocusedRowHandle;
                VnsDoanCongTac obj = (VnsDoanCongTac)grvDoanRa.GetRow(grvDoanRa.FocusedRowHandle);
                VnsQuyetToanDoan objQt = (VnsQuyetToanDoan)grvQuyetToan.GetRow(grvQuyetToan.FocusedRowHandle);
                if (objQt != null)
                {
                    FrmQuyetToanDoanEdit frm = (FrmQuyetToanDoanEdit)ObjectFactory.GetObject("FrmQuyetToanDoanEdit");
                    Guid DoanRaId = frm.Show_Form(FormUpdate.Update, objQt.CongTacId, this.AccessibleDescription, objQt.LanQuyetToan);
                    if (DoanRaId != new Guid())
                    {
                        //this.BindData();
                        loadDataAfterAddOrEdit(DoanRaId);
                        this.LoadGridDetail(DoanRaId);
                        grvDoanRa.FocusedRowHandle = i;
                    }
                }
                else
                {
                    Commons.Commons.Message_Warning("Bạn chưa chọn lần quyết toán (quyết toán thường hay quyết toán bổ sung)");
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void FrmQuyetToanDoan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
                {
                    btnAddNew_Click(btnAddNew, null);
                }
                else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
                {
                    btnModify_Click(btnModify, null);
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }


        private void btnLapBoXung_Click(object sender, EventArgs e)
        {
            FrmQuyetToanDoanEdit frm = (FrmQuyetToanDoanEdit)ObjectFactory.GetObject("FrmQuyetToanDoanEdit");
            VnsDoanCongTac obj = (VnsDoanCongTac)grvDoanRa.GetRow(grvDoanRa.FocusedRowHandle);
            if (obj == null)
            {
                Commons.Commons.Message_Warning("Bạn chưa chọn đoàn ra cần lập quyết toán");
                return;
            }
            if (obj.DanhSachQuyetToanDoan != null && obj.DanhSachQuyetToanDoan.Count == 0)
            {
                Commons.Commons.Message_Warning("Đoàn ra chưa được quyết toán lần đầu, chọn 'Lập quyết toán' để lập quyết toán lần đầu!");
                return;
            }

            Guid DoanRaId = frm.Show_Form(FormUpdate.Insert, obj.IdBanDau, this.AccessibleDescription, 1);
            if (DoanRaId != new Guid())
            {
                this.BindData();
                this.LoadGridDetail(DoanRaId);
                setFocusGridview(DoanRaId);
            }
        }

        private void btnInQtBoSung_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDoanRa.RowCount == 0)
                {
                    Commons.Commons.Message_Warning("Không có bản ghi nào được lựa chọn");
                    return;
                }
                if (objDoanCongTac == null)
                    objDoanCongTac = (VnsDoanCongTac)grvDoanRa.GetRow(grvDoanRa.FocusedRowHandle);

                VnsQuyetToanDoan objQt = (VnsQuyetToanDoan)grvQuyetToan.GetRow(grvQuyetToan.FocusedRowHandle);
                if (objQt != null)
                {
                    IList<VnsInQtTu> lstIn = VnsQuyetToanDoanService.GetDataInQTbyDoanCtac(objQt.CongTacId, -1);

                    VnsDoanCongTac tmp = VnsDoanCongTacService.Get(objQt.CongTacId);

                    foreach (VnsInQtTu obj in lstIn)
                    {
                        obj.MaMucCha = GetMaMucTieuMucById(obj.IdMucCha);
                    }
                    Reports.FrmThamSoBaoCao frm = (FrmThamSoBaoCao)ObjectFactory.GetObject("FrmThamSoBaoCao");
                    frm.LoaiBaoCao = true;
                    frm.KieuBaoCao = false;
                    frm.lstIn = lstIn;
                    frm.objDoanCongTac = tmp;
                    frm.Show();
                }
                else
                {
                    Commons.Commons.Message_Warning("Bạn chưa chọn lần quyết toán (quyết toán thường hay quyết toán bổ sung)");
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void grvDoanRa_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column.Name == "STT")
                {
                    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
        }

        private void btnHuyQuyetToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDoanRa.RowCount == 0)
                {
                    Commons.Commons.Message_Warning("Không có bản ghi nào được lựa chọn");
                    return;
                }

                int i = grvDoanRa.FocusedRowHandle;
                VnsDoanCongTac obj = (VnsDoanCongTac)grvDoanRa.GetRow(grvDoanRa.FocusedRowHandle);

                VnsQuyetToanDoan objQt = (VnsQuyetToanDoan)grvQuyetToan.GetRow(grvQuyetToan.FocusedRowHandle);
                //VnsDoanCongTac crObj = VnsDoanCongTacService.GetById(objQt.CongTacId);
                if (objQt != null)
                {
                    if (Commons.Commons.Message_Confirm("Bạn có chắc chắn muốn hủy quyết toán"))
                    {
                        Guid DoanRaId = objQt.CongTacId;
                        decimal lanqt = objQt.LanQuyetToan;

                        VnsDoanCongTac objDoanCT = VnsDoanCongTacService.Get(DoanRaId);
                        if (lanqt > 0)
                        {
                            VnsDoanCongTacService.DeleteDoanCongTac(objDoanCT);
                        }
                        else
                        {
                            VnsQuyetToanDoanService.DeleteQuyetToanDoan(objDoanCT, lanqt);
                        }

                        if (DoanRaId != new Guid())
                        {
                            //this.BindData();
                            loadDataAfterAddOrEdit(DoanRaId);
                            this.LoadGridDetail(DoanRaId);
                            grvDoanRa.FocusedRowHandle = i;
                        }
                    }
                }
                else
                {
                    Commons.Commons.Message_Warning("Bạn chưa chọn lần quyết toán (quyết toán thường hay quyết toán bổ sung)");
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void btnDuToan_Click(object sender, EventArgs e)
        {
            IList<VnsDoanCongTac> lstdct = VnsDoanCongTacService.GetAll();
            //VnsDoanCongTac obj = (VnsDoanCongTac)grvDoanRa.GetRow(grvDoanRa.FocusedRowHandle);
            //if (obj == null) return;
            foreach (VnsDoanCongTac obj in lstdct)
            {
                VnsQuyetToanDoanService.MaintainDoanRa(obj);
            }

            MessageBox.Show("Đã thực hiện thành công");
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
