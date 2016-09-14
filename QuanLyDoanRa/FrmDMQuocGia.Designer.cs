namespace QuanLyDoanRa
{
    partial class FrmDMQuocGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDMQuocGia));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.luePhanLoai = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenNuoc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaNuoc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gctQuocGia = new DevExpress.XtraGrid.GridControl();
            this.gvQuocGia = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNuocId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaNuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhanLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnTrangTruoc = new DevExpress.XtraEditors.SimpleButton();
            this.txtSoTrang = new DevExpress.XtraEditors.TextEdit();
            this.btnTrangSau = new DevExpress.XtraEditors.SimpleButton();
            this.btnTrangDau = new DevExpress.XtraEditors.SimpleButton();
            this.btnTrangCuoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luePhanLoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNuoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNuoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctQuocGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuocGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTrang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnHuy);
            this.panelControl1.Controls.Add(this.btnSua);
            this.panelControl1.Controls.Add(this.btnXoa);
            this.panelControl1.Controls.Add(this.btnThem);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(691, 163);
            this.panelControl1.TabIndex = 2;
            // 
            // btnHuy
            // 
            this.btnHuy.ImageIndex = 20;
            this.btnHuy.ImageList = this.imageCollection1;
            this.btnHuy.Location = new System.Drawing.Point(270, 120);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(80, 30);
            this.btnHuy.TabIndex = 23;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.ToolTip = "Phím tắt Ctrl + H ";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
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
            this.btnSua.ImageIndex = 2;
            this.btnSua.ImageList = this.imageCollection1;
            this.btnSua.Location = new System.Drawing.Point(184, 120);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 30);
            this.btnSua.TabIndex = 20;
            this.btnSua.Text = "Lưu";
            this.btnSua.ToolTip = "Phím tắt Ctrl + U";
            this.btnSua.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.ImageIndex = 8;
            this.btnXoa.ImageList = this.imageCollection1;
            this.btnXoa.Location = new System.Drawing.Point(98, 120);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 30);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.ToolTip = "Phím tắt Ctrl + D";
            this.btnXoa.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.ImageIndex = 16;
            this.btnThem.ImageList = this.imageCollection1;
            this.btnThem.Location = new System.Drawing.Point(12, 120);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 30);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.ToolTip = "Phím tắt Ctrl + I";
            this.btnThem.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.luePhanLoai);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.txtTenNuoc);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.txtMaNuoc);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(12, 12);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(551, 91);
            this.panelControl2.TabIndex = 6;
            // 
            // luePhanLoai
            // 
            this.luePhanLoai.EnterMoveNextControl = true;
            this.luePhanLoai.Location = new System.Drawing.Point(66, 55);
            this.luePhanLoai.Name = "luePhanLoai";
            this.luePhanLoai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePhanLoai.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DoiTuong", "Đối Tượng", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten", "Tên")});
            this.luePhanLoai.Properties.NullText = "Chọn Giá Trị";
            this.luePhanLoai.Size = new System.Drawing.Size(185, 20);
            this.luePhanLoai.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 58);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Phân Loại";
            // 
            // txtTenNuoc
            // 
            this.txtTenNuoc.EnterMoveNextControl = true;
            this.txtTenNuoc.Location = new System.Drawing.Point(336, 14);
            this.txtTenNuoc.Name = "txtTenNuoc";
            this.txtTenNuoc.Size = new System.Drawing.Size(185, 20);
            this.txtTenNuoc.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(281, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Tên Nước";
            // 
            // txtMaNuoc
            // 
            this.txtMaNuoc.EnterMoveNextControl = true;
            this.txtMaNuoc.Location = new System.Drawing.Point(66, 14);
            this.txtMaNuoc.Name = "txtMaNuoc";
            this.txtMaNuoc.Size = new System.Drawing.Size(185, 20);
            this.txtMaNuoc.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã Nước";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gctQuocGia);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(4, 167);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(691, 405);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Danh mục quốc gia";
            // 
            // gctQuocGia
            // 
            this.gctQuocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gctQuocGia.Location = new System.Drawing.Point(2, 22);
            this.gctQuocGia.MainView = this.gvQuocGia;
            this.gctQuocGia.Name = "gctQuocGia";
            this.gctQuocGia.Size = new System.Drawing.Size(687, 381);
            this.gctQuocGia.TabIndex = 1;
            this.gctQuocGia.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvQuocGia});
            this.gctQuocGia.Click += new System.EventHandler(this.gctQuocGia_Click);
            this.gctQuocGia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gctQuocGia_KeyDown);
            // 
            // gvQuocGia
            // 
            this.gvQuocGia.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNuocId,
            this.colMaNuoc,
            this.colTenNuoc,
            this.colPhanLoai});
            this.gvQuocGia.GridControl = this.gctQuocGia;
            this.gvQuocGia.Name = "gvQuocGia";
            this.gvQuocGia.OptionsBehavior.ReadOnly = true;
            this.gvQuocGia.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvQuocGia.OptionsView.ColumnAutoWidth = false;
            this.gvQuocGia.OptionsView.ShowAutoFilterRow = true;
            this.gvQuocGia.OptionsView.ShowGroupPanel = false;
            this.gvQuocGia.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvQuocGia_FocusedRowChanged);
            this.gvQuocGia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvQuocGia_KeyDown);
            // 
            // colNuocId
            // 
            this.colNuocId.Caption = "Nước ID";
            this.colNuocId.FieldName = "Id";
            this.colNuocId.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colNuocId.Name = "colNuocId";
            this.colNuocId.OptionsColumn.FixedWidth = true;
            this.colNuocId.OptionsColumn.ReadOnly = true;
            // 
            // colMaNuoc
            // 
            this.colMaNuoc.Caption = "Mã nước";
            this.colMaNuoc.FieldName = "MaNuoc";
            this.colMaNuoc.Name = "colMaNuoc";
            this.colMaNuoc.OptionsColumn.FixedWidth = true;
            this.colMaNuoc.OptionsColumn.ReadOnly = true;
            this.colMaNuoc.Visible = true;
            this.colMaNuoc.VisibleIndex = 0;
            this.colMaNuoc.Width = 174;
            // 
            // colTenNuoc
            // 
            this.colTenNuoc.Caption = "Tên nước";
            this.colTenNuoc.FieldName = "TenNuoc";
            this.colTenNuoc.Name = "colTenNuoc";
            this.colTenNuoc.OptionsColumn.FixedWidth = true;
            this.colTenNuoc.OptionsColumn.ReadOnly = true;
            this.colTenNuoc.Visible = true;
            this.colTenNuoc.VisibleIndex = 1;
            this.colTenNuoc.Width = 188;
            // 
            // colPhanLoai
            // 
            this.colPhanLoai.Caption = "Phân loại";
            this.colPhanLoai.FieldName = "PhanLoai";
            this.colPhanLoai.Name = "colPhanLoai";
            this.colPhanLoai.OptionsColumn.FixedWidth = true;
            this.colPhanLoai.OptionsColumn.ReadOnly = true;
            this.colPhanLoai.Visible = true;
            this.colPhanLoai.VisibleIndex = 2;
            this.colPhanLoai.Width = 238;
            // 
            // btnTrangTruoc
            // 
            this.btnTrangTruoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTrangTruoc.Location = new System.Drawing.Point(87, 9);
            this.btnTrangTruoc.Name = "btnTrangTruoc";
            this.btnTrangTruoc.Size = new System.Drawing.Size(75, 23);
            this.btnTrangTruoc.TabIndex = 11;
            this.btnTrangTruoc.Text = "Trang trước";
            this.btnTrangTruoc.Click += new System.EventHandler(this.btnTrangTruoc_Click);
            // 
            // txtSoTrang
            // 
            this.txtSoTrang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSoTrang.Location = new System.Drawing.Point(168, 10);
            this.txtSoTrang.Name = "txtSoTrang";
            this.txtSoTrang.Size = new System.Drawing.Size(78, 20);
            this.txtSoTrang.TabIndex = 6;
            // 
            // btnTrangSau
            // 
            this.btnTrangSau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTrangSau.Location = new System.Drawing.Point(252, 9);
            this.btnTrangSau.Name = "btnTrangSau";
            this.btnTrangSau.Size = new System.Drawing.Size(75, 23);
            this.btnTrangSau.TabIndex = 12;
            this.btnTrangSau.Text = "Trang sau";
            this.btnTrangSau.Click += new System.EventHandler(this.btnTrangSau_Click);
            // 
            // btnTrangDau
            // 
            this.btnTrangDau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTrangDau.Location = new System.Drawing.Point(6, 9);
            this.btnTrangDau.Name = "btnTrangDau";
            this.btnTrangDau.Size = new System.Drawing.Size(75, 23);
            this.btnTrangDau.TabIndex = 13;
            this.btnTrangDau.Text = "Trang đầu";
            this.btnTrangDau.Click += new System.EventHandler(this.btnTrangDau_Click);
            // 
            // btnTrangCuoi
            // 
            this.btnTrangCuoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTrangCuoi.Location = new System.Drawing.Point(333, 9);
            this.btnTrangCuoi.Name = "btnTrangCuoi";
            this.btnTrangCuoi.Size = new System.Drawing.Size(75, 23);
            this.btnTrangCuoi.TabIndex = 14;
            this.btnTrangCuoi.Text = "Trang cuối";
            this.btnTrangCuoi.Click += new System.EventHandler(this.btnTrangCuoi_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ImageIndex = 18;
            this.btnClose.ImageList = this.imageCollection1;
            this.btnClose.Location = new System.Drawing.Point(608, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Đóng";
            this.btnClose.ToolTip = "Phím tắt Ctrl + C";
            this.btnClose.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.btnTrangSau);
            this.panelControl3.Controls.Add(this.btnClose);
            this.panelControl3.Controls.Add(this.btnTrangTruoc);
            this.panelControl3.Controls.Add(this.btnTrangCuoi);
            this.panelControl3.Controls.Add(this.txtSoTrang);
            this.panelControl3.Controls.Add(this.btnTrangDau);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(4, 572);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(691, 40);
            this.panelControl3.TabIndex = 16;
            // 
            // FrmDMQuocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 616);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmDMQuocGia";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "MaNuoc";
            this.Text = "Danh Mục Quốc Gia";
            this.Load += new System.EventHandler(this.FrmDMQuocGia_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDMQuocGia_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luePhanLoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNuoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNuoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctQuocGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQuocGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTrang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LookUpEdit luePhanLoai;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtTenNuoc;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtMaNuoc;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gctQuocGia;
        private DevExpress.XtraGrid.Views.Grid.GridView gvQuocGia;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNuoc;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNuoc;
        private DevExpress.XtraGrid.Columns.GridColumn colPhanLoai;
        private DevExpress.XtraEditors.SimpleButton btnTrangTruoc;
        private DevExpress.XtraEditors.TextEdit txtSoTrang;
        private DevExpress.XtraEditors.SimpleButton btnTrangSau;
        private DevExpress.XtraEditors.SimpleButton btnTrangDau;
        private DevExpress.XtraEditors.SimpleButton btnTrangCuoi;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraGrid.Columns.GridColumn colNuocId;
        private DevExpress.XtraEditors.PanelControl panelControl3;

    }
}

