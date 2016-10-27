namespace QuanLyDoanRa
{
    partial class FrmDuToan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDuToan));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gctDoanRa = new DevExpress.XtraGrid.GridControl();
            this.gvDoanRa = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCongTacId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNamDuToan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTruongDoan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTBDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoThongBaoQT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoTa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayDi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayVe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiDoanRa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnChiTiet = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grvDuToan = new DevExpress.XtraGrid.GridControl();
            this.gvDuToan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaMuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboTenMuc = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cboDienGiai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.luegPhanLoai = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnDuToanBx = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnThemMoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnDuToan = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctDoanRa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDoanRa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDuToan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDuToan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTenMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luegPhanLoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gctDoanRa);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1000, 336);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Danh Sách Thông Tin Đoàn Ra";
            // 
            // gctDoanRa
            // 
            this.gctDoanRa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gctDoanRa.Location = new System.Drawing.Point(2, 22);
            this.gctDoanRa.MainView = this.gvDoanRa;
            this.gctDoanRa.Name = "gctDoanRa";
            this.gctDoanRa.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnChiTiet});
            this.gctDoanRa.Size = new System.Drawing.Size(996, 312);
            this.gctDoanRa.TabIndex = 1;
            this.gctDoanRa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDoanRa});
            // 
            // gvDoanRa
            // 
            this.gvDoanRa.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.STT,
            this.colCongTacId,
            this.colNamDuToan,
            this.colThang,
            this.colTenDon,
            this.colTruongDoan,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn3,
            this.colSoTBDT,
            this.colSoThongBaoQT,
            this.colMoTa,
            this.colNgayDi,
            this.colNgayVe,
            this.colLoaiDoanRa});
            this.gvDoanRa.GridControl = this.gctDoanRa;
            this.gvDoanRa.GroupCount = 2;
            this.gvDoanRa.Name = "gvDoanRa";
            this.gvDoanRa.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvDoanRa.OptionsView.ShowAutoFilterRow = true;
            this.gvDoanRa.OptionsView.ShowGroupPanel = false;
            this.gvDoanRa.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNamDuToan, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colThang, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvDoanRa.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvDoanRa_CustomDrawCell);
            this.gvDoanRa.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDoanRa_FocusedRowChanged);
            // 
            // STT
            // 
            this.STT.Caption = "STT";
            this.STT.Name = "STT";
            this.STT.OptionsColumn.ReadOnly = true;
            this.STT.Visible = true;
            this.STT.VisibleIndex = 0;
            this.STT.Width = 63;
            // 
            // colCongTacId
            // 
            this.colCongTacId.Caption = "gridColumn1";
            this.colCongTacId.FieldName = "Id";
            this.colCongTacId.Name = "colCongTacId";
            this.colCongTacId.OptionsColumn.ReadOnly = true;
            // 
            // colNamDuToan
            // 
            this.colNamDuToan.Caption = "Năm duyệt dự toán";
            this.colNamDuToan.FieldName = "NamCongTac";
            this.colNamDuToan.Name = "colNamDuToan";
            // 
            // colThang
            // 
            this.colThang.Caption = "Tháng duyệt dự toán";
            this.colThang.FieldName = "ThangCongTac";
            this.colThang.Name = "colThang";
            // 
            // colTenDon
            // 
            this.colTenDon.Caption = "Tên đoàn ";
            this.colTenDon.FieldName = "Ten";
            this.colTenDon.Name = "colTenDon";
            this.colTenDon.OptionsColumn.AllowEdit = false;
            this.colTenDon.OptionsColumn.ReadOnly = true;
            this.colTenDon.Visible = true;
            this.colTenDon.VisibleIndex = 1;
            this.colTenDon.Width = 138;
            // 
            // colTruongDoan
            // 
            this.colTruongDoan.Caption = "Trưởng đoàn";
            this.colTruongDoan.FieldName = "TruongDoan";
            this.colTruongDoan.Name = "colTruongDoan";
            this.colTruongDoan.OptionsColumn.AllowEdit = false;
            this.colTruongDoan.OptionsColumn.ReadOnly = true;
            this.colTruongDoan.Visible = true;
            this.colTruongDoan.VisibleIndex = 2;
            this.colTruongDoan.Width = 105;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ngày dự toán";
            this.gridColumn2.FieldName = "NgayDt";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            this.gridColumn2.Width = 111;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Ngày duyệt dự toán";
            this.gridColumn4.DisplayFormat.FormatString = "d";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "NgayDuyetDuToan";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 112;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Ngày quyết toán";
            this.gridColumn3.FieldName = "NgayQt";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 7;
            this.gridColumn3.Width = 95;
            // 
            // colSoTBDT
            // 
            this.colSoTBDT.Caption = "Số TB dự toán";
            this.colSoTBDT.FieldName = "SoThongBaoDuToan";
            this.colSoTBDT.Name = "colSoTBDT";
            this.colSoTBDT.OptionsColumn.AllowEdit = false;
            this.colSoTBDT.OptionsColumn.ReadOnly = true;
            this.colSoTBDT.Visible = true;
            this.colSoTBDT.VisibleIndex = 3;
            this.colSoTBDT.Width = 104;
            // 
            // colSoThongBaoQT
            // 
            this.colSoThongBaoQT.Caption = "Số TBQT";
            this.colSoThongBaoQT.FieldName = "SoThongBaoQuyetToan";
            this.colSoThongBaoQT.Name = "colSoThongBaoQT";
            this.colSoThongBaoQT.OptionsColumn.AllowEdit = false;
            this.colSoThongBaoQT.OptionsColumn.ReadOnly = true;
            this.colSoThongBaoQT.Visible = true;
            this.colSoThongBaoQT.VisibleIndex = 4;
            this.colSoThongBaoQT.Width = 76;
            // 
            // colMoTa
            // 
            this.colMoTa.Caption = "Mô tả";
            this.colMoTa.FieldName = "MoTa";
            this.colMoTa.Name = "colMoTa";
            this.colMoTa.OptionsColumn.AllowEdit = false;
            this.colMoTa.OptionsColumn.ReadOnly = true;
            this.colMoTa.Visible = true;
            this.colMoTa.VisibleIndex = 8;
            this.colMoTa.Width = 117;
            // 
            // colNgayDi
            // 
            this.colNgayDi.Caption = "Ngày đi";
            this.colNgayDi.FieldName = "NgayDi";
            this.colNgayDi.Name = "colNgayDi";
            this.colNgayDi.OptionsColumn.AllowEdit = false;
            this.colNgayDi.OptionsColumn.ReadOnly = true;
            this.colNgayDi.Visible = true;
            this.colNgayDi.VisibleIndex = 9;
            this.colNgayDi.Width = 68;
            // 
            // colNgayVe
            // 
            this.colNgayVe.Caption = "Ngày về";
            this.colNgayVe.FieldName = "NgayVe";
            this.colNgayVe.Name = "colNgayVe";
            this.colNgayVe.OptionsColumn.AllowEdit = false;
            this.colNgayVe.OptionsColumn.ReadOnly = true;
            this.colNgayVe.Visible = true;
            this.colNgayVe.VisibleIndex = 10;
            this.colNgayVe.Width = 70;
            // 
            // colLoaiDoanRa
            // 
            this.colLoaiDoanRa.Caption = "Loại đoàn ra";
            this.colLoaiDoanRa.FieldName = "TenLoaiDoanRa";
            this.colLoaiDoanRa.Name = "colLoaiDoanRa";
            this.colLoaiDoanRa.OptionsColumn.AllowEdit = false;
            this.colLoaiDoanRa.OptionsColumn.ReadOnly = true;
            this.colLoaiDoanRa.Visible = true;
            this.colLoaiDoanRa.VisibleIndex = 11;
            this.colLoaiDoanRa.Width = 118;
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.AutoHeight = false;
            this.btnChiTiet.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grvDuToan);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(4, 340);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1000, 228);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Bản Dự Toán Đoàn Ra";
            // 
            // grvDuToan
            // 
            this.grvDuToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvDuToan.Location = new System.Drawing.Point(2, 22);
            this.grvDuToan.MainView = this.gvDuToan;
            this.grvDuToan.Name = "grvDuToan";
            this.grvDuToan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboTenMuc,
            this.luegPhanLoai,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            this.grvDuToan.Size = new System.Drawing.Size(996, 204);
            this.grvDuToan.TabIndex = 1;
            this.grvDuToan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDuToan});
            this.grvDuToan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvDuToan_KeyDown);
            // 
            // gvDuToan
            // 
            this.gvDuToan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT,
            this.colMaMuc,
            this.gridColumn1,
            this.colTien,
            this.cboDienGiai,
            this.gridColumn5,
            this.gridColumn6});
            this.gvDuToan.GridControl = this.grvDuToan;
            this.gvDuToan.GroupCount = 1;
            this.gvDuToan.Name = "gvDuToan";
            this.gvDuToan.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvDuToan.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvDuToan.OptionsView.ShowAutoFilterRow = true;
            this.gvDuToan.OptionsView.ShowFooter = true;
            this.gvDuToan.OptionsView.ShowGroupPanel = false;
            this.gvDuToan.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn5, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMaMuc, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvDuToan.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvDuToan_CellValueChanged);
            this.gvDuToan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvDuToan_KeyDown);
            // 
            // colSTT
            // 
            this.colSTT.Caption = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.OptionsColumn.AllowEdit = false;
            // 
            // colMaMuc
            // 
            this.colMaMuc.Caption = "Mã mục";
            this.colMaMuc.ColumnEdit = this.cboTenMuc;
            this.colMaMuc.FieldName = "MucId";
            this.colMaMuc.Name = "colMaMuc";
            this.colMaMuc.OptionsColumn.AllowEdit = false;
            this.colMaMuc.OptionsColumn.ReadOnly = true;
            this.colMaMuc.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.colMaMuc.Visible = true;
            this.colMaMuc.VisibleIndex = 0;
            this.colMaMuc.Width = 91;
            // 
            // cboTenMuc
            // 
            this.cboTenMuc.AutoHeight = false;
            this.cboTenMuc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTenMuc.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MucId", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaMuc", "Mã mục"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenMuc", "Tên Mục")});
            this.cboTenMuc.DisplayMember = "MaMuc";
            this.cboTenMuc.Name = "cboTenMuc";
            this.cboTenMuc.NullText = "Chọn Tên Mục";
            this.cboTenMuc.ValueMember = "Id";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên mục";
            this.gridColumn1.FieldName = "TenKhoanChi";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 210;
            // 
            // colTien
            // 
            this.colTien.Caption = "Dự toán USD";
            this.colTien.ColumnEdit = this.repositoryItemTextEdit1;
            this.colTien.FieldName = "SoTienDuToan";
            this.colTien.Name = "colTien";
            this.colTien.OptionsColumn.AllowEdit = false;
            this.colTien.OptionsColumn.ReadOnly = true;
            this.colTien.SummaryItem.DisplayFormat = "{0:n0}";
            this.colTien.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colTien.Visible = true;
            this.colTien.VisibleIndex = 3;
            this.colTien.Width = 115;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemTextEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.EditMask = "n0";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // cboDienGiai
            // 
            this.cboDienGiai.Caption = "Diễn giải";
            this.cboDienGiai.FieldName = "DienGiai";
            this.cboDienGiai.Name = "cboDienGiai";
            this.cboDienGiai.OptionsColumn.AllowEdit = false;
            this.cboDienGiai.OptionsColumn.ReadOnly = true;
            this.cboDienGiai.Visible = true;
            this.cboDienGiai.VisibleIndex = 4;
            this.cboDienGiai.Width = 446;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Dự toán";
            this.gridColumn5.FieldName = "DienGiaiDuToan";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Dự toán VNĐ";
            this.gridColumn6.ColumnEdit = this.repositoryItemTextEdit2;
            this.gridColumn6.FieldName = "SoTienDuToanVND";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.SummaryItem.DisplayFormat = "{0:n0}";
            this.gridColumn6.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 118;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Mask.EditMask = "n0";
            this.repositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit2.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // luegPhanLoai
            // 
            this.luegPhanLoai.AutoHeight = false;
            this.luegPhanLoai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luegPhanLoai.Name = "luegPhanLoai";
            this.luegPhanLoai.NullText = "Chọn Giá Trị";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.btnDuToanBx);
            this.panelControl3.Controls.Add(this.btnThemMoi);
            this.panelControl3.Controls.Add(this.btnDuToan);
            this.panelControl3.Controls.Add(this.btnHuy);
            this.panelControl3.Controls.Add(this.simpleButton1);
            this.panelControl3.Controls.Add(this.btnLuu);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(4, 568);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1000, 40);
            this.panelControl3.TabIndex = 3;
            // 
            // btnDuToanBx
            // 
            this.btnDuToanBx.ImageIndex = 16;
            this.btnDuToanBx.ImageList = this.imageCollection1;
            this.btnDuToanBx.Location = new System.Drawing.Point(103, 7);
            this.btnDuToanBx.Name = "btnDuToanBx";
            this.btnDuToanBx.Size = new System.Drawing.Size(95, 23);
            this.btnDuToanBx.TabIndex = 5;
            this.btnDuToanBx.Text = "&Dự toán BX";
            this.btnDuToanBx.ToolTip = "Phím tắt Ctrl + C";
            this.btnDuToanBx.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnDuToanBx.Click += new System.EventHandler(this.btnDuToanBx_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "About.png");
            this.imageCollection1.Images.SetKeyName(1, "accept.png");
            this.imageCollection1.Images.SetKeyName(2, "application_edit.png");
            this.imageCollection1.Images.SetKeyName(3, "arrow_refresh.png");
            this.imageCollection1.Images.SetKeyName(4, "book_notebook.png");
            this.imageCollection1.Images.SetKeyName(5, "book_open.png");
            this.imageCollection1.Images.SetKeyName(6, "calendar_32.png");
            this.imageCollection1.Images.SetKeyName(7, "Close.png");
            this.imageCollection1.Images.SetKeyName(8, "cross_octagon.png");
            this.imageCollection1.Images.SetKeyName(9, "find.png");
            this.imageCollection1.Images.SetKeyName(10, "Go.png");
            this.imageCollection1.Images.SetKeyName(11, "group.png");
            this.imageCollection1.Images.SetKeyName(12, "Help.png");
            this.imageCollection1.Images.SetKeyName(13, "Home.png");
            this.imageCollection1.Images.SetKeyName(14, "nangcao.png");
            this.imageCollection1.Images.SetKeyName(15, "people-icon.png");
            this.imageCollection1.Images.SetKeyName(16, "plus_16.png");
            this.imageCollection1.Images.SetKeyName(17, "Shutdown.png");
            this.imageCollection1.Images.SetKeyName(18, "stop.png");
            this.imageCollection1.Images.SetKeyName(19, "tuychon.png");
            this.imageCollection1.Images.SetKeyName(20, "user_delete.png");
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.ImageIndex = 16;
            this.btnThemMoi.ImageList = this.imageCollection1;
            this.btnThemMoi.Location = new System.Drawing.Point(2, 7);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(95, 23);
            this.btnThemMoi.TabIndex = 4;
            this.btnThemMoi.Text = "&Lập dự toán";
            this.btnThemMoi.ToolTip = "Phím tắt Ctrl + C";
            this.btnThemMoi.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnDuToan
            // 
            this.btnDuToan.ImageIndex = 16;
            this.btnDuToan.ImageList = this.imageCollection1;
            this.btnDuToan.Location = new System.Drawing.Point(628, 7);
            this.btnDuToan.Name = "btnDuToan";
            this.btnDuToan.Size = new System.Drawing.Size(93, 23);
            this.btnDuToan.TabIndex = 0;
            this.btnDuToan.Text = "Lập &dự toán";
            this.btnDuToan.Visible = false;
            this.btnDuToan.Click += new System.EventHandler(this.btnDuToan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.ImageIndex = 18;
            this.btnHuy.ImageList = this.imageCollection1;
            this.btnHuy.Location = new System.Drawing.Point(292, 7);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(80, 23);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "&Hủy";
            this.btnHuy.ToolTip = "Phím tắt Ctrl + C";
            this.btnHuy.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageIndex = 4;
            this.simpleButton1.Location = new System.Drawing.Point(204, 7);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(80, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "&In dự toán";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.ImageIndex = 4;
            this.btnLuu.ImageList = this.imageCollection1;
            this.btnLuu.Location = new System.Drawing.Point(530, 7);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(80, 23);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.Visible = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // FrmDuToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 612);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmDuToan";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dự Toán";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDuToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctDoanRa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDoanRa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvDuToan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDuToan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTenMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luegPhanLoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gctDoanRa;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDoanRa;
        private DevExpress.XtraGrid.Columns.GridColumn colCongTacId;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDon;
        private DevExpress.XtraGrid.Columns.GridColumn colTruongDoan;
        private DevExpress.XtraGrid.Columns.GridColumn colMoTa;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayDi;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayVe;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiDoanRa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnChiTiet;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grvDuToan;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDuToan;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colMaMuc;
        private DevExpress.XtraGrid.Columns.GridColumn colTien;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboTenMuc;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luegPhanLoai;
        private DevExpress.XtraGrid.Columns.GridColumn cboDienGiai;
        private DevExpress.XtraEditors.SimpleButton btnDuToan;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnThemMoi;
        private DevExpress.XtraGrid.Columns.GridColumn STT;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTBDT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn colSoThongBaoQT;
        private DevExpress.XtraGrid.Columns.GridColumn colNamDuToan;
        private DevExpress.XtraGrid.Columns.GridColumn colThang;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnDuToanBx;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;

    }
}