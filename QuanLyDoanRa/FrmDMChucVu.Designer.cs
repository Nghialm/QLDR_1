namespace QuanLyDoanRa
{
    partial class FrmDMChucVu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDMChucVu));
            this.groupControl = new DevExpress.XtraEditors.GroupControl();
            this.gctChucVu = new DevExpress.XtraGrid.GridControl();
            this.gvDmChucVu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTenChucVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeSoA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeSoB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChucVuId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.gcDmChucVu = new DevExpress.XtraEditors.GroupControl();
            this.btnTatCa = new DevExpress.XtraEditors.SimpleButton();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtHeSoB = new DevExpress.XtraEditors.TextEdit();
            this.txtHeSoA = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenChucVu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnTrangTruoc = new DevExpress.XtraEditors.SimpleButton();
            this.btnTrangSau = new DevExpress.XtraEditors.SimpleButton();
            this.txtSoTrang = new DevExpress.XtraEditors.TextEdit();
            this.btnTrangDau = new DevExpress.XtraEditors.SimpleButton();
            this.btnTrangCuoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).BeginInit();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctChucVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDmChucVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDmChucVu)).BeginInit();
            this.gcDmChucVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeSoB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeSoA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenChucVu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTrang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.gctChucVu);
            this.groupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl.Location = new System.Drawing.Point(4, 174);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(1010, 408);
            this.groupControl.TabIndex = 1;
            this.groupControl.Text = "Danh Sách Chức Vụ";
            // 
            // gctChucVu
            // 
            this.gctChucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gctChucVu.Location = new System.Drawing.Point(2, 22);
            this.gctChucVu.MainView = this.gvDmChucVu;
            this.gctChucVu.Name = "gctChucVu";
            this.gctChucVu.Size = new System.Drawing.Size(1006, 384);
            this.gctChucVu.TabIndex = 0;
            this.gctChucVu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDmChucVu});
            // 
            // gvDmChucVu
            // 
            this.gvDmChucVu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTenChucVu,
            this.colHeSoA,
            this.colHeSoB,
            this.colChucVuId});
            this.gvDmChucVu.GridControl = this.gctChucVu;
            this.gvDmChucVu.Name = "gvDmChucVu";
            this.gvDmChucVu.OptionsBehavior.ReadOnly = true;
            this.gvDmChucVu.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvDmChucVu.OptionsView.ShowAutoFilterRow = true;
            this.gvDmChucVu.OptionsView.ShowGroupPanel = false;
            this.gvDmChucVu.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDmChucVu_FocusedRowChanged);
            // 
            // colTenChucVu
            // 
            this.colTenChucVu.Caption = "Tên Chức Vụ";
            this.colTenChucVu.FieldName = "TenChucVu";
            this.colTenChucVu.Name = "colTenChucVu";
            this.colTenChucVu.OptionsColumn.ReadOnly = true;
            this.colTenChucVu.Visible = true;
            this.colTenChucVu.VisibleIndex = 0;
            // 
            // colHeSoA
            // 
            this.colHeSoA.Caption = "Hệ Số A";
            this.colHeSoA.FieldName = "HeSoa";
            this.colHeSoA.Name = "colHeSoA";
            this.colHeSoA.OptionsColumn.ReadOnly = true;
            this.colHeSoA.Visible = true;
            this.colHeSoA.VisibleIndex = 1;
            // 
            // colHeSoB
            // 
            this.colHeSoB.Caption = "Hệ Số B";
            this.colHeSoB.FieldName = "HeSob";
            this.colHeSoB.Name = "colHeSoB";
            this.colHeSoB.OptionsColumn.ReadOnly = true;
            this.colHeSoB.Visible = true;
            this.colHeSoB.VisibleIndex = 2;
            // 
            // colChucVuId
            // 
            this.colChucVuId.Caption = "Chức Vụ ID";
            this.colChucVuId.FieldName = "ChucVuId";
            this.colChucVuId.Name = "colChucVuId";
            this.colChucVuId.OptionsColumn.ReadOnly = true;
            // 
            // btnSua
            // 
            this.btnSua.ImageIndex = 2;
            this.btnSua.ImageList = this.imageCollection1;
            this.btnSua.Location = new System.Drawing.Point(184, 126);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(80, 30);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "&Lưu";
            this.btnSua.ToolTip = "Ctrl + S";
            this.btnSua.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
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
            // gcDmChucVu
            // 
            this.gcDmChucVu.Controls.Add(this.btnTatCa);
            this.gcDmChucVu.Controls.Add(this.btnTimKiem);
            this.gcDmChucVu.Controls.Add(this.btnHuy);
            this.gcDmChucVu.Controls.Add(this.panelControl2);
            this.gcDmChucVu.Controls.Add(this.btnSua);
            this.gcDmChucVu.Controls.Add(this.btnThem);
            this.gcDmChucVu.Controls.Add(this.btnXoa);
            this.gcDmChucVu.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcDmChucVu.Location = new System.Drawing.Point(4, 4);
            this.gcDmChucVu.Name = "gcDmChucVu";
            this.gcDmChucVu.Size = new System.Drawing.Size(1010, 170);
            this.gcDmChucVu.TabIndex = 0;
            this.gcDmChucVu.Text = "Thông Tin Chức Vụ";
            // 
            // btnTatCa
            // 
            this.btnTatCa.ImageList = this.imageCollection1;
            this.btnTatCa.Location = new System.Drawing.Point(522, 84);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(80, 30);
            this.btnTatCa.TabIndex = 7;
            this.btnTatCa.Text = "Tất &cả";
            this.btnTatCa.ToolTip = "Phím tắt Ctrl + T";
            this.btnTatCa.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.ImageIndex = 9;
            this.btnTimKiem.ImageList = this.imageCollection1;
            this.btnTimKiem.Location = new System.Drawing.Point(522, 47);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(80, 30);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "&Tìm kiếm";
            this.btnTimKiem.ToolTip = "Phím tắt Ctrl + S";
            this.btnTimKiem.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.ImageIndex = 20;
            this.btnHuy.ImageList = this.imageCollection1;
            this.btnHuy.Location = new System.Drawing.Point(270, 126);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(80, 30);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "&Hủy";
            this.btnHuy.ToolTip = "Phím tắt Ctrl + H ";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtHeSoB);
            this.panelControl2.Controls.Add(this.txtHeSoA);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.txtTenChucVu);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(12, 33);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(486, 81);
            this.panelControl2.TabIndex = 0;
            // 
            // txtHeSoB
            // 
            this.txtHeSoB.EditValue = "0";
            this.txtHeSoB.EnterMoveNextControl = true;
            this.txtHeSoB.Location = new System.Drawing.Point(311, 48);
            this.txtHeSoB.Name = "txtHeSoB";
            this.txtHeSoB.Properties.Appearance.Options.UseTextOptions = true;
            this.txtHeSoB.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtHeSoB.Properties.Mask.EditMask = "n2";
            this.txtHeSoB.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtHeSoB.Size = new System.Drawing.Size(130, 20);
            this.txtHeSoB.TabIndex = 2;
            // 
            // txtHeSoA
            // 
            this.txtHeSoA.EditValue = "0";
            this.txtHeSoA.EnterMoveNextControl = true;
            this.txtHeSoA.Location = new System.Drawing.Point(95, 48);
            this.txtHeSoA.Name = "txtHeSoA";
            this.txtHeSoA.Properties.Appearance.Options.UseTextOptions = true;
            this.txtHeSoA.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtHeSoA.Properties.Mask.EditMask = "n2";
            this.txtHeSoA.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtHeSoA.Size = new System.Drawing.Size(130, 20);
            this.txtHeSoA.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(253, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Hệ Số B";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(37, 51);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(38, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Hệ Số A";
            // 
            // txtTenChucVu
            // 
            this.txtTenChucVu.EnterMoveNextControl = true;
            this.txtTenChucVu.Location = new System.Drawing.Point(95, 12);
            this.txtTenChucVu.Name = "txtTenChucVu";
            this.txtTenChucVu.Size = new System.Drawing.Size(346, 20);
            this.txtTenChucVu.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên Chức Vụ";
            // 
            // btnThem
            // 
            this.btnThem.ImageIndex = 16;
            this.btnThem.ImageList = this.imageCollection1;
            this.btnThem.Location = new System.Drawing.Point(12, 126);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(80, 30);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "&Thêm";
            this.btnThem.ToolTip = "Ctrl + N";
            this.btnThem.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.ImageIndex = 8;
            this.btnXoa.ImageList = this.imageCollection1;
            this.btnXoa.Location = new System.Drawing.Point(98, 126);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 30);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "&Xóa";
            this.btnXoa.ToolTip = "Ctrl + D";
            this.btnXoa.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnTrangTruoc
            // 
            this.btnTrangTruoc.Location = new System.Drawing.Point(93, 9);
            this.btnTrangTruoc.Name = "btnTrangTruoc";
            this.btnTrangTruoc.Size = new System.Drawing.Size(75, 23);
            this.btnTrangTruoc.TabIndex = 1;
            this.btnTrangTruoc.Text = "Trang trước";
            this.btnTrangTruoc.Click += new System.EventHandler(this.btnTrangTruoc_Click);
            // 
            // btnTrangSau
            // 
            this.btnTrangSau.Location = new System.Drawing.Point(258, 9);
            this.btnTrangSau.Name = "btnTrangSau";
            this.btnTrangSau.Size = new System.Drawing.Size(75, 23);
            this.btnTrangSau.TabIndex = 3;
            this.btnTrangSau.Text = "Trang sau";
            this.btnTrangSau.Click += new System.EventHandler(this.btnTrangSau_Click);
            // 
            // txtSoTrang
            // 
            this.txtSoTrang.Location = new System.Drawing.Point(174, 12);
            this.txtSoTrang.Name = "txtSoTrang";
            this.txtSoTrang.Size = new System.Drawing.Size(78, 20);
            this.txtSoTrang.TabIndex = 2;
            // 
            // btnTrangDau
            // 
            this.btnTrangDau.Location = new System.Drawing.Point(12, 9);
            this.btnTrangDau.Name = "btnTrangDau";
            this.btnTrangDau.Size = new System.Drawing.Size(75, 23);
            this.btnTrangDau.TabIndex = 0;
            this.btnTrangDau.Text = "Trang đầu";
            this.btnTrangDau.Click += new System.EventHandler(this.btnTrangDau_Click);
            // 
            // btnTrangCuoi
            // 
            this.btnTrangCuoi.Location = new System.Drawing.Point(339, 9);
            this.btnTrangCuoi.Name = "btnTrangCuoi";
            this.btnTrangCuoi.Size = new System.Drawing.Size(75, 23);
            this.btnTrangCuoi.TabIndex = 4;
            this.btnTrangCuoi.Text = "Trang cuối";
            this.btnTrangCuoi.Click += new System.EventHandler(this.btnTrangCuoi_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImageIndex = 18;
            this.btnClose.ImageList = this.imageCollection1;
            this.btnClose.Location = new System.Drawing.Point(927, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "&Đóng";
            this.btnClose.ToolTip = "Phím tắt Ctrl + C";
            this.btnClose.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.btnTrangSau);
            this.panelControl3.Controls.Add(this.btnClose);
            this.panelControl3.Controls.Add(this.btnTrangCuoi);
            this.panelControl3.Controls.Add(this.btnTrangTruoc);
            this.panelControl3.Controls.Add(this.btnTrangDau);
            this.panelControl3.Controls.Add(this.txtSoTrang);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(4, 582);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1010, 40);
            this.panelControl3.TabIndex = 2;
            // 
            // FrmDMChucVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1018, 626);
            this.Controls.Add(this.groupControl);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.gcDmChucVu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDMChucVu";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục chức vụ";
            this.Load += new System.EventHandler(this.FrmDMChucVu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDMChucVu_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctChucVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDmChucVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDmChucVu)).EndInit();
            this.gcDmChucVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeSoB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeSoA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenChucVu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTrang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl;
        private DevExpress.XtraGrid.GridControl gctChucVu;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDmChucVu;
        private DevExpress.XtraGrid.Columns.GridColumn colTenChucVu;
        private DevExpress.XtraGrid.Columns.GridColumn colHeSoA;
        private DevExpress.XtraGrid.Columns.GridColumn colHeSoB;
        private DevExpress.XtraGrid.Columns.GridColumn colChucVuId;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.GroupControl gcDmChucVu;
        private DevExpress.XtraEditors.SimpleButton btnTatCa;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtHeSoB;
        private DevExpress.XtraEditors.TextEdit txtHeSoA;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtTenChucVu;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnTrangTruoc;
        private DevExpress.XtraEditors.SimpleButton btnTrangSau;
        private DevExpress.XtraEditors.TextEdit txtSoTrang;
        private DevExpress.XtraEditors.SimpleButton btnTrangDau;
        private DevExpress.XtraEditors.SimpleButton btnTrangCuoi;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.PanelControl panelControl3;
    }
}