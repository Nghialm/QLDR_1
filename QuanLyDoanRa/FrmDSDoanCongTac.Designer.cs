namespace QuanLyDoanRa
{
    partial class FrmDSDoanCongTac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDSDoanCongTac));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemMoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gctDoanRa = new DevExpress.XtraGrid.GridControl();
            this.gvDoanRa = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTruongDoan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTBDuToan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTBQT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoTa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayDi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayVe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiDoanRa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCongTacId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayDuToan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayQuyetToan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnChiTiet = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnInQT = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctDoanRa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDoanRa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
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
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSua.ImageIndex = 2;
            this.btnSua.ImageList = this.imageCollection1;
            this.btnSua.Location = new System.Drawing.Point(88, 6);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 23);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "&Sửa";
            this.btnSua.ToolTip = "Ctrl + E";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemMoi.ImageIndex = 16;
            this.btnThemMoi.ImageList = this.imageCollection1;
            this.btnThemMoi.Location = new System.Drawing.Point(2, 6);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(80, 23);
            this.btnThemMoi.TabIndex = 10;
            this.btnThemMoi.Text = "&Thêm mới";
            this.btnThemMoi.ToolTip = "Ctr + N";
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoa.ImageIndex = 8;
            this.btnXoa.ImageList = this.imageCollection1;
            this.btnXoa.Location = new System.Drawing.Point(174, 6);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 23);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "&Xóa";
            this.btnXoa.ToolTip = "Ctrl + D";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gctDoanRa);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1000, 564);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Danh sách đoàn ra";
            // 
            // gctDoanRa
            // 
            this.gctDoanRa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gctDoanRa.Location = new System.Drawing.Point(2, 22);
            this.gctDoanRa.MainView = this.gvDoanRa;
            this.gctDoanRa.Name = "gctDoanRa";
            this.gctDoanRa.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnChiTiet,
            this.repositoryItemTextEdit1});
            this.gctDoanRa.Size = new System.Drawing.Size(996, 540);
            this.gctDoanRa.TabIndex = 0;
            this.gctDoanRa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDoanRa});
            // 
            // gvDoanRa
            // 
            this.gvDoanRa.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.STT,
            this.gridColumn2,
            this.gridColumn3,
            this.colTenDon,
            this.colTruongDoan,
            this.colSoTBDuToan,
            this.colSoTBQT,
            this.colMoTa,
            this.colNgayDi,
            this.colNgayVe,
            this.colLoaiDoanRa,
            this.colCongTacId,
            this.gridColumn1,
            this.colNgayDuToan,
            this.colNgayQuyetToan});
            this.gvDoanRa.GridControl = this.gctDoanRa;
            this.gvDoanRa.GroupCount = 2;
            this.gvDoanRa.Name = "gvDoanRa";
            this.gvDoanRa.OptionsBehavior.AutoExpandAllGroups = true;
            this.gvDoanRa.OptionsView.ShowAutoFilterRow = true;
            this.gvDoanRa.OptionsView.ShowGroupPanel = false;
            this.gvDoanRa.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn3, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvDoanRa.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvDoanRa_CustomDrawCell);
            this.gvDoanRa.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDoanRa_FocusedRowChanged);
            // 
            // STT
            // 
            this.STT.Caption = "STT";
            this.STT.Name = "STT";
            this.STT.OptionsColumn.AllowFocus = false;
            this.STT.OptionsColumn.ReadOnly = true;
            this.STT.Visible = true;
            this.STT.VisibleIndex = 0;
            this.STT.Width = 62;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Năm đi công tác";
            this.gridColumn2.FieldName = "NamDiCT";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tháng đi công tác";
            this.gridColumn3.FieldName = "ThangDiCT";
            this.gridColumn3.Name = "gridColumn3";
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
            this.colTenDon.Width = 159;
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
            this.colTruongDoan.Width = 87;
            // 
            // colSoTBDuToan
            // 
            this.colSoTBDuToan.Caption = "Số TB dự toán";
            this.colSoTBDuToan.FieldName = "SoThongBaoDuToan";
            this.colSoTBDuToan.Name = "colSoTBDuToan";
            this.colSoTBDuToan.OptionsColumn.AllowEdit = false;
            this.colSoTBDuToan.OptionsColumn.ReadOnly = true;
            this.colSoTBDuToan.Visible = true;
            this.colSoTBDuToan.VisibleIndex = 3;
            this.colSoTBDuToan.Width = 70;
            // 
            // colSoTBQT
            // 
            this.colSoTBQT.Caption = "Số TB QT";
            this.colSoTBQT.FieldName = "SoThongBaoQuyetToan";
            this.colSoTBQT.Name = "colSoTBQT";
            this.colSoTBQT.OptionsColumn.AllowEdit = false;
            this.colSoTBQT.OptionsColumn.ReadOnly = true;
            this.colSoTBQT.Visible = true;
            this.colSoTBQT.VisibleIndex = 4;
            this.colSoTBQT.Width = 54;
            // 
            // colMoTa
            // 
            this.colMoTa.Caption = "Mô tả";
            this.colMoTa.FieldName = "MoTa";
            this.colMoTa.Name = "colMoTa";
            this.colMoTa.OptionsColumn.AllowEdit = false;
            this.colMoTa.OptionsColumn.ReadOnly = true;
            this.colMoTa.Visible = true;
            this.colMoTa.VisibleIndex = 5;
            this.colMoTa.Width = 70;
            // 
            // colNgayDi
            // 
            this.colNgayDi.Caption = "Ngày đi";
            this.colNgayDi.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayDi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colNgayDi.FieldName = "NgayDi";
            this.colNgayDi.Name = "colNgayDi";
            this.colNgayDi.OptionsColumn.AllowEdit = false;
            this.colNgayDi.OptionsColumn.ReadOnly = true;
            this.colNgayDi.Visible = true;
            this.colNgayDi.VisibleIndex = 6;
            this.colNgayDi.Width = 57;
            // 
            // colNgayVe
            // 
            this.colNgayVe.Caption = "Ngày về";
            this.colNgayVe.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayVe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colNgayVe.FieldName = "NgayVe";
            this.colNgayVe.Name = "colNgayVe";
            this.colNgayVe.OptionsColumn.AllowEdit = false;
            this.colNgayVe.OptionsColumn.ReadOnly = true;
            this.colNgayVe.Visible = true;
            this.colNgayVe.VisibleIndex = 7;
            this.colNgayVe.Width = 69;
            // 
            // colLoaiDoanRa
            // 
            this.colLoaiDoanRa.Caption = "Loại đoàn ra";
            this.colLoaiDoanRa.FieldName = "TenLoaiDoanRa";
            this.colLoaiDoanRa.Name = "colLoaiDoanRa";
            this.colLoaiDoanRa.OptionsColumn.AllowEdit = false;
            this.colLoaiDoanRa.OptionsColumn.ReadOnly = true;
            this.colLoaiDoanRa.Visible = true;
            this.colLoaiDoanRa.VisibleIndex = 8;
            this.colLoaiDoanRa.Width = 101;
            // 
            // colCongTacId
            // 
            this.colCongTacId.Caption = "gridColumn1";
            this.colCongTacId.FieldName = "Id";
            this.colCongTacId.Name = "colCongTacId";
            this.colCongTacId.OptionsColumn.AllowEdit = false;
            this.colCongTacId.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Trạng thái QT";
            this.gridColumn1.FieldName = "TrangThai";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 9;
            this.gridColumn1.Width = 80;
            // 
            // colNgayDuToan
            // 
            this.colNgayDuToan.Caption = "Ngày dự toán";
            this.colNgayDuToan.FieldName = "strNgayDuToan";
            this.colNgayDuToan.Name = "colNgayDuToan";
            this.colNgayDuToan.Visible = true;
            this.colNgayDuToan.VisibleIndex = 10;
            this.colNgayDuToan.Width = 88;
            // 
            // colNgayQuyetToan
            // 
            this.colNgayQuyetToan.Caption = "Ngày quyết toán";
            this.colNgayQuyetToan.FieldName = "strNgayQuyetToan";
            this.colNgayQuyetToan.Name = "colNgayQuyetToan";
            this.colNgayQuyetToan.Visible = true;
            this.colNgayQuyetToan.VisibleIndex = 11;
            this.colNgayQuyetToan.Width = 83;
            // 
            // btnChiTiet
            // 
            this.btnChiTiet.AutoHeight = false;
            this.btnChiTiet.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnChiTiet.Name = "btnChiTiet";
            this.btnChiTiet.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.EditMask = "dd/MM/yyyy";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.btnInQT);
            this.panelControl3.Controls.Add(this.btnDong);
            this.panelControl3.Controls.Add(this.btnSua);
            this.panelControl3.Controls.Add(this.btnThemMoi);
            this.panelControl3.Controls.Add(this.btnXoa);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(4, 568);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1000, 40);
            this.panelControl3.TabIndex = 2;
            // 
            // btnInQT
            // 
            this.btnInQT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInQT.ImageIndex = 14;
            this.btnInQT.ImageList = this.imageCollection1;
            this.btnInQT.Location = new System.Drawing.Point(260, 6);
            this.btnInQT.Name = "btnInQT";
            this.btnInQT.Size = new System.Drawing.Size(80, 23);
            this.btnInQT.TabIndex = 26;
            this.btnInQT.Text = "&In QT";
            this.btnInQT.ToolTip = "Ctrl + P";
            this.btnInQT.Click += new System.EventHandler(this.btnInQT_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.ImageIndex = 17;
            this.btnDong.ImageList = this.imageCollection1;
            this.btnDong.Location = new System.Drawing.Point(346, 6);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(80, 23);
            this.btnDong.TabIndex = 25;
            this.btnDong.Text = "&Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmDSDoanCongTac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(1008, 612);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl3);
            this.KeyPreview = true;
            this.Name = "FrmDSDoanCongTac";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách đoàn công tác";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDSDoanCongTac_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDSDoanCongTac_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctDoanRa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDoanRa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
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
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThemMoi;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraGrid.Columns.GridColumn STT;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTBDuToan;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton btnInQT;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTBQT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayDuToan;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayQuyetToan;
    }
}