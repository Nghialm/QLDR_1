namespace QuanLyDoanRa
{
    partial class FrmDonVi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDonVi));
            this.btnTrangTruoc = new DevExpress.XtraEditors.SimpleButton();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtSoTrang = new DevExpress.XtraEditors.TextEdit();
            this.btnTrangSau = new DevExpress.XtraEditors.SimpleButton();
            this.btnTrangDau = new DevExpress.XtraEditors.SimpleButton();
            this.btnTrangCuoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cboLoaiDonVi = new DevExpress.XtraEditors.LookUpEdit();
            this.txtMaDonVi = new DevExpress.XtraEditors.TextEdit();
            this.txtTenDonVi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gctDonVi = new DevExpress.XtraGrid.GridControl();
            this.gvDonVi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoaiDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDonViId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTrang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTrangTruoc
            // 
            this.btnTrangTruoc.Location = new System.Drawing.Point(91, 9);
            this.btnTrangTruoc.Name = "btnTrangTruoc";
            this.btnTrangTruoc.Size = new System.Drawing.Size(75, 23);
            this.btnTrangTruoc.TabIndex = 39;
            this.btnTrangTruoc.Text = "Trang trước";
            this.btnTrangTruoc.Click += new System.EventHandler(this.btnTrangTruoc_Click);
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // txtSoTrang
            // 
            this.txtSoTrang.Location = new System.Drawing.Point(172, 10);
            this.txtSoTrang.Name = "txtSoTrang";
            this.txtSoTrang.Size = new System.Drawing.Size(78, 20);
            this.txtSoTrang.TabIndex = 38;
            // 
            // btnTrangSau
            // 
            this.btnTrangSau.Location = new System.Drawing.Point(256, 9);
            this.btnTrangSau.Name = "btnTrangSau";
            this.btnTrangSau.Size = new System.Drawing.Size(75, 23);
            this.btnTrangSau.TabIndex = 40;
            this.btnTrangSau.Text = "Trang sau";
            this.btnTrangSau.Click += new System.EventHandler(this.btnTrangSau_Click);
            // 
            // btnTrangDau
            // 
            this.btnTrangDau.Location = new System.Drawing.Point(10, 9);
            this.btnTrangDau.Name = "btnTrangDau";
            this.btnTrangDau.Size = new System.Drawing.Size(75, 23);
            this.btnTrangDau.TabIndex = 41;
            this.btnTrangDau.Text = "Trang đầu";
            this.btnTrangDau.Click += new System.EventHandler(this.btnTrangDau_Click);
            // 
            // btnTrangCuoi
            // 
            this.btnTrangCuoi.Location = new System.Drawing.Point(337, 9);
            this.btnTrangCuoi.Name = "btnTrangCuoi";
            this.btnTrangCuoi.Size = new System.Drawing.Size(75, 23);
            this.btnTrangCuoi.TabIndex = 42;
            this.btnTrangCuoi.Text = "Trang cuối";
            this.btnTrangCuoi.Click += new System.EventHandler(this.btnTrangCuoi_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImageIndex = 18;
            this.btnClose.ImageList = this.imageCollection1;
            this.btnClose.Location = new System.Drawing.Point(602, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 43;
            this.btnClose.Text = "&Đóng";
            this.btnClose.ToolTip = "Phím tắt Ctrl + C";
            this.btnClose.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cboLoaiDonVi);
            this.panelControl1.Controls.Add(this.txtMaDonVi);
            this.panelControl1.Controls.Add(this.txtTenDonVi);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(9, 30);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(652, 95);
            this.panelControl1.TabIndex = 0;
            // 
            // cboLoaiDonVi
            // 
            this.cboLoaiDonVi.EnterMoveNextControl = true;
            this.cboLoaiDonVi.Location = new System.Drawing.Point(490, 15);
            this.cboLoaiDonVi.Name = "cboLoaiDonVi";
            this.cboLoaiDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiDonVi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GiaTri", "Giá Trị"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten", "Tên")});
            this.cboLoaiDonVi.Properties.NullText = "Chọn Giá Trị";
            this.cboLoaiDonVi.Size = new System.Drawing.Size(146, 20);
            this.cboLoaiDonVi.TabIndex = 2;
            // 
            // txtMaDonVi
            // 
            this.txtMaDonVi.EnterMoveNextControl = true;
            this.txtMaDonVi.Location = new System.Drawing.Point(74, 15);
            this.txtMaDonVi.Name = "txtMaDonVi";
            this.txtMaDonVi.Size = new System.Drawing.Size(212, 20);
            this.txtMaDonVi.TabIndex = 0;
            // 
            // txtTenDonVi
            // 
            this.txtTenDonVi.EnterMoveNextControl = true;
            this.txtTenDonVi.Location = new System.Drawing.Point(74, 56);
            this.txtTenDonVi.Name = "txtTenDonVi";
            this.txtTenDonVi.Size = new System.Drawing.Size(298, 20);
            this.txtTenDonVi.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(415, 18);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(53, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Loại Đơn Vị";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 18);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Mã Đơn Vị";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 59);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên Đơn Vị";
            // 
            // btnThem
            // 
            this.btnThem.ImageIndex = 16;
            this.btnThem.ImageList = this.imageCollection1;
            this.btnThem.Location = new System.Drawing.Point(9, 140);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 30);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "&Thêm";
            this.btnThem.ToolTip = "Ctrl + N";
            this.btnThem.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.ImageIndex = 2;
            this.btnSua.ImageList = this.imageCollection1;
            this.btnSua.Location = new System.Drawing.Point(181, 140);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 30);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "&Lưu";
            this.btnSua.ToolTip = "Ctrl + S";
            this.btnSua.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.ImageIndex = 20;
            this.btnHuy.ImageList = this.imageCollection1;
            this.btnHuy.Location = new System.Drawing.Point(267, 140);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(80, 30);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "&Hủy";
            this.btnHuy.ToolTip = "Phím tắt Ctrl + H ";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnHuy);
            this.groupControl1.Controls.Add(this.btnSua);
            this.groupControl1.Controls.Add(this.btnThem);
            this.groupControl1.Controls.Add(this.btnXoa);
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(687, 187);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông Tin Đơn Vị";
            // 
            // btnXoa
            // 
            this.btnXoa.ImageIndex = 8;
            this.btnXoa.ImageList = this.imageCollection1;
            this.btnXoa.Location = new System.Drawing.Point(95, 140);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 30);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "&Xóa";
            this.btnXoa.ToolTip = "Ctrl + D";
            this.btnXoa.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gctDonVi);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(4, 191);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(687, 391);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Danh Sách Đơn Vị";
            // 
            // gctDonVi
            // 
            this.gctDonVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gctDonVi.Location = new System.Drawing.Point(2, 22);
            this.gctDonVi.MainView = this.gvDonVi;
            this.gctDonVi.Name = "gctDonVi";
            this.gctDonVi.Size = new System.Drawing.Size(683, 367);
            this.gctDonVi.TabIndex = 3;
            this.gctDonVi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDonVi});
            this.gctDonVi.Click += new System.EventHandler(this.gctDonVi_Click);
            // 
            // gvDonVi
            // 
            this.gvDonVi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaDonVi,
            this.colTenDonVi,
            this.colLoaiDonVi,
            this.colDonViId});
            this.gvDonVi.GridControl = this.gctDonVi;
            this.gvDonVi.Name = "gvDonVi";
            this.gvDonVi.OptionsBehavior.ReadOnly = true;
            this.gvDonVi.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvDonVi.OptionsView.ShowAutoFilterRow = true;
            this.gvDonVi.OptionsView.ShowGroupPanel = false;
            this.gvDonVi.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDonVi_FocusedRowChanged);
            // 
            // colMaDonVi
            // 
            this.colMaDonVi.Caption = "Mã Đơn Vị";
            this.colMaDonVi.FieldName = "MaDonVi";
            this.colMaDonVi.Name = "colMaDonVi";
            this.colMaDonVi.OptionsColumn.ReadOnly = true;
            this.colMaDonVi.Visible = true;
            this.colMaDonVi.VisibleIndex = 0;
            this.colMaDonVi.Width = 200;
            // 
            // colTenDonVi
            // 
            this.colTenDonVi.Caption = "Tên Đơn Vị";
            this.colTenDonVi.FieldName = "TenDonVi";
            this.colTenDonVi.Name = "colTenDonVi";
            this.colTenDonVi.OptionsColumn.ReadOnly = true;
            this.colTenDonVi.Visible = true;
            this.colTenDonVi.VisibleIndex = 1;
            this.colTenDonVi.Width = 380;
            // 
            // colLoaiDonVi
            // 
            this.colLoaiDonVi.Caption = "Loại Đơn Vị";
            this.colLoaiDonVi.FieldName = "LoaiDonVi";
            this.colLoaiDonVi.Name = "colLoaiDonVi";
            this.colLoaiDonVi.OptionsColumn.ReadOnly = true;
            this.colLoaiDonVi.Visible = true;
            this.colLoaiDonVi.VisibleIndex = 2;
            this.colLoaiDonVi.Width = 87;
            // 
            // colDonViId
            // 
            this.colDonViId.Caption = "Đơn Vị ID";
            this.colDonViId.FieldName = "DonViId";
            this.colDonViId.Name = "colDonViId";
            this.colDonViId.OptionsColumn.ReadOnly = true;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btnTrangSau);
            this.panelControl2.Controls.Add(this.btnTrangTruoc);
            this.panelControl2.Controls.Add(this.txtSoTrang);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnTrangDau);
            this.panelControl2.Controls.Add(this.btnTrangCuoi);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(4, 582);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(687, 40);
            this.panelControl2.TabIndex = 2;
            // 
            // FrmDonVi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(695, 626);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDonVi";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục đơn vị";
            this.Load += new System.EventHandler(this.FrmDonVi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDonVi_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTrang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnTrangTruoc;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.TextEdit txtSoTrang;
        private DevExpress.XtraEditors.SimpleButton btnTrangSau;
        private DevExpress.XtraEditors.SimpleButton btnTrangDau;
        private DevExpress.XtraEditors.SimpleButton btnTrangCuoi;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboLoaiDonVi;
        private DevExpress.XtraEditors.TextEdit txtMaDonVi;
        private DevExpress.XtraEditors.TextEdit txtTenDonVi;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gctDonVi;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn colMaDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn colDonViId;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
    }
}