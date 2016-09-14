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
using Vns.QuanLyDoanRa.Domain;
using System.Collections;
using Vns.Erp.Core.Domain;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.QuanLyDoanRa.Domain.Report;
using QuanLyDoanRa.Reports;

namespace QuanLyDoanRa
{
    public partial class FrmDSDoanCongTac : Form
    {

        #region Variables
        public IVnsLoaiDoanRaService VnsLoaiDoanRaService;
        public IVnsDoanCongTacService VnsDoanCongTacService;
        public IVnsLichCongTacService VnsLichCongTacService;
        public IVnsThanhVienService VnsThanhVienService;
        public IVnsChungTuService VnsChungTuService;
        public IVnsGiaoDichService VnsGiaoDichService;

        private VnsDoanCongTac DoanRa;
        private IList<VnsDoanCongTac> lstDoanct = new List<VnsDoanCongTac>();
        private int PgSize = General.NumberOfPage;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;
        #endregion

        #region Fucntions

        public FrmDSDoanCongTac()
        {
            InitializeComponent();
        }

        // tinh tong so trang
        //private void TongSoTrang()
        //{
        //    int rowCount = VnsDoanCongTacService.GetCount();
        //    TotalPage = rowCount / PgSize;
        //    if (rowCount % PgSize > 0)
        //        TotalPage += 1;
        //}

        //private void BindData(int CurrentPageIndex)
        //{
            
        //    TongSoTrang();
        //    // Hien thi du lieu len gridcontrol

        //    VnsOrder objNgayDi = new VnsOrder(false, "NgayDi");
        //    IList<VnsOrder> orders = new List<VnsOrder>();
        //    orders.Add(objNgayDi);

        //    txtTrangHienTai.Text = CurrentPageIndex.ToString() + "/" + TotalPage.ToString();
        //    lstDoanct = VnsDoanCongTacService.ListLike((CurrentPageIndex - 1) * PgSize, PgSize, null, null, null, null, orders);
        //    gctDoanRa.DataSource = lstDoanct;
        //}

        private void BindData()
        {
            lstDoanct = VnsDoanCongTacService.GetDoanRa(-1);
            gctDoanRa.DataSource = lstDoanct;
        }

        private void SetFocusGrid(Guid id)
        {
            for(int i =0 ; i<= lstDoanct.Count -1 ;i++)
            {
                if (lstDoanct[i].Id == id)
                {
                    gvDoanRa.FocusedRowHandle = i;                
                }
            }
        
        }
        #endregion

        #region Events

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            FrmEditDoanCT frmEditDoanCT = (FrmEditDoanCT)ObjectFactory.GetObject("frmEditDoanCT");
            frmEditDoanCT.FormStatus = FormUpdate.Insert;            
            frmEditDoanCT.ShowDialog();
            BindData();

            if (frmEditDoanCT.DoanRa == null) return;

            if(!VnsCheck.IsNullGuid(frmEditDoanCT.DoanRa.Id))
            {
                SetFocusGrid(frmEditDoanCT.DoanRa.Id);
            }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDSDoanCongTac_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDoanRa.RowCount == 0 || gvDoanRa.FocusedRowHandle < 0)
                {
                    Commons.Commons.Message_Warning("Không có bản ghi nào được lựa chọn");
                    return;
                }

                DoanRa = (VnsDoanCongTac)gvDoanRa.GetRow(gvDoanRa.FocusedRowHandle);

                if (Commons.Commons.Message_Confirm("Bạn có chắc chắn muốn xóa bản ghi này?"))
                {
                    IList<VnsDoanCongTac> lstdct = VnsDoanCongTacService.GetDoanRaByDoanRaBanDau(DoanRa.Id);

                    foreach (VnsDoanCongTac tmp in lstdct)
                    {
                        VnsDoanCongTacService.DeleteDoanCongTac(DoanRa);
                    }

                    Commons.Commons.Message_Information("Xóa thành công");
                    BindData();
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDoanRa.FocusedRowHandle < 0)
                {
                    Commons.Commons.Message_Warning("Không có bản ghi nào được lựa chọn");
                    return;
                }
                int i = gvDoanRa.FocusedRowHandle;
                DoanRa = (VnsDoanCongTac)gvDoanRa.GetRow(i);
                FrmEditDoanCT frmEditDoanCT = (FrmEditDoanCT)ObjectFactory.GetObject("frmEditDoanCT");
                frmEditDoanCT.FormStatus = FormUpdate.Update;
                frmEditDoanCT.DoanRa = DoanRa;
                frmEditDoanCT.ShowDialog();
                BindData();
                gvDoanRa.FocusedRowHandle = i;                
            }
            catch (System.Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }

        }

        private void gvDoanRa_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;
            VnsDoanCongTac objDoanRa = (VnsDoanCongTac)gvDoanRa.GetRow(e.FocusedRowHandle);
            //VnsDoanCongTac objDoanRa = VnsDoanCongTacService.GetById(objTemp.Id);
            if (objDoanRa == null) return;
        }

        private void FrmDSDoanCongTac_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == Keys.N && e.Modifiers == Keys.Control) || e.KeyCode == Keys.F4)
                {
                    btnThemMoi_Click(btnThemMoi, null);
                }
                else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control) 
                {
                    btnSua_Click(btnSua, null);
                }
                else if ((e.KeyCode == Keys.D && e.Modifiers == Keys.Control)|| e.KeyCode == Keys.F8)
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

        private void gvDoanRa_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column.Name == "STT")
                {
                    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
                if (e.Column.Name == "colNgayQuyetToan")
                {
                    if (e.DisplayText == "31/12/9999")
                    {
                        e.DisplayText = "";
                    }
                }
            }
        }

        private void btnInQT_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDoanRa.FocusedRowHandle < 0)
                {
                    Commons.Commons.Message_Warning("Không có bản ghi nào được lựa chọn");
                    return;
                }
                IReportService ReportService = (IReportService)ObjectFactory.GetObject("ReportService");
                int i = gvDoanRa.FocusedRowHandle;
                DoanRa = (VnsDoanCongTac)gvDoanRa.GetRow(i);
                if (DoanRa != null)
                {
                    //IReportService ReportService = (IReportService)ObjectFactory.GetObject("ReportService");
                    //IList<VnsReportTongHop> lstBaoCaoTongHop = ReportService.BaoCaoTongHopDoanRa(dTuNgay, dDenNgay, LoaiDoanRa, 2, ReportType.RP02);

                    IList<VnsReport> lstBaoCaoTongHop = ReportService.BaoCaoTongHopDoanRa(Null.NullDate, DateTime.Now, DoanRa.LoaiDoanRaId, DoanRa.Id);
                    BangKeQuyetToanDoanRa QT = new BangKeQuyetToanDoanRa();                    
                    QT.LoadData(lstBaoCaoTongHop);
                    QT.CreateDocument();
                    QT.ShowPreviewDialog();
                }
            }
            catch (System.Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

      
    }
}
