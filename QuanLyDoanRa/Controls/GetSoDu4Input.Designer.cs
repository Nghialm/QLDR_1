namespace QuanLyDoanRa.Controls
{
    partial class GetSoDu4Input
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbChuyenKhoan = new System.Windows.Forms.RadioButton();
            this.rbTienMat = new System.Windows.Forms.RadioButton();
            this.txtSoTien = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btLaySoLieu = new DevExpress.XtraEditors.SimpleButton();
            this.cboLoaiDoanRa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtNgayTinh = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gvSoTien = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNgoaiTe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTyGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVnD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXuatTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btTuDong = new DevExpress.XtraEditors.SimpleButton();
            this.btXacNhan = new DevExpress.XtraEditors.SimpleButton();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiDoanRa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayTinh.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayTinh.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSoTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(571, 269);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbChuyenKhoan);
            this.panel1.Controls.Add(this.rbTienMat);
            this.panel1.Controls.Add(this.txtSoTien);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.btLaySoLieu);
            this.panel1.Controls.Add(this.cboLoaiDoanRa);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.txtNgayTinh);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 64);
            this.panel1.TabIndex = 0;
            // 
            // rbChuyenKhoan
            // 
            this.rbChuyenKhoan.AutoSize = true;
            this.rbChuyenKhoan.Location = new System.Drawing.Point(357, 31);
            this.rbChuyenKhoan.Name = "rbChuyenKhoan";
            this.rbChuyenKhoan.Size = new System.Drawing.Size(94, 17);
            this.rbChuyenKhoan.TabIndex = 4;
            this.rbChuyenKhoan.Text = "Chuyển khoản";
            this.rbChuyenKhoan.UseVisualStyleBackColor = true;
            // 
            // rbTienMat
            // 
            this.rbTienMat.AutoSize = true;
            this.rbTienMat.Checked = true;
            this.rbTienMat.Location = new System.Drawing.Point(257, 31);
            this.rbTienMat.Name = "rbTienMat";
            this.rbTienMat.Size = new System.Drawing.Size(66, 17);
            this.rbTienMat.TabIndex = 3;
            this.rbTienMat.TabStop = true;
            this.rbTienMat.Text = "Tiền mặt";
            this.rbTienMat.UseVisualStyleBackColor = true;
            // 
            // txtSoTien
            // 
            this.txtSoTien.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSoTien.EnterMoveNextControl = true;
            this.txtSoTien.Location = new System.Drawing.Point(61, 32);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Properties.DisplayFormat.FormatString = "n0";
            this.txtSoTien.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSoTien.Properties.EditFormat.FormatString = "n0";
            this.txtSoTien.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSoTien.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSoTien.Size = new System.Drawing.Size(100, 20);
            this.txtSoTien.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 35);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Số tiền";
            // 
            // btLaySoLieu
            // 
            this.btLaySoLieu.Location = new System.Drawing.Point(481, 3);
            this.btLaySoLieu.Name = "btLaySoLieu";
            this.btLaySoLieu.Size = new System.Drawing.Size(75, 23);
            this.btLaySoLieu.TabIndex = 5;
            this.btLaySoLieu.Text = "Lấy số liệu";
            this.btLaySoLieu.Click += new System.EventHandler(this.btLaySoLieu_Click);
            // 
            // cboLoaiDoanRa
            // 
            this.cboLoaiDoanRa.EnterMoveNextControl = true;
            this.cboLoaiDoanRa.Location = new System.Drawing.Point(257, 6);
            this.cboLoaiDoanRa.Name = "cboLoaiDoanRa";
            this.cboLoaiDoanRa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiDoanRa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLoaiDoanRa", "Loại đoàn ra")});
            this.cboLoaiDoanRa.Properties.DisplayMember = "TenLoaiDoanRa";
            this.cboLoaiDoanRa.Properties.ValueMember = "Id";
            this.cboLoaiDoanRa.Size = new System.Drawing.Size(100, 20);
            this.cboLoaiDoanRa.TabIndex = 1;
            this.cboLoaiDoanRa.Validating += new System.ComponentModel.CancelEventHandler(this.cboLoaiDoanRa_Validating);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(192, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Loại đoàn ra";
            // 
            // txtNgayTinh
            // 
            this.txtNgayTinh.EditValue = null;
            this.txtNgayTinh.EnterMoveNextControl = true;
            this.txtNgayTinh.Location = new System.Drawing.Point(61, 6);
            this.txtNgayTinh.Name = "txtNgayTinh";
            this.txtNgayTinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNgayTinh.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.txtNgayTinh.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtNgayTinh.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtNgayTinh.Size = new System.Drawing.Size(100, 20);
            this.txtNgayTinh.TabIndex = 0;
            this.txtNgayTinh.Validating += new System.ComponentModel.CancelEventHandler(this.txtNgayTinh_Validating);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Ngày tính";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gvSoTien);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(565, 150);
            this.panel2.TabIndex = 1;
            // 
            // gvSoTien
            // 
            this.gvSoTien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvSoTien.Location = new System.Drawing.Point(0, 0);
            this.gvSoTien.MainView = this.gridView1;
            this.gvSoTien.Name = "gvSoTien";
            this.gvSoTien.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.gvSoTien.Size = new System.Drawing.Size(565, 150);
            this.gvSoTien.TabIndex = 0;
            this.gvSoTien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNgoaiTe,
            this.colTyGia,
            this.colVnD,
            this.colXuatTien});
            this.gridView1.GridControl = this.gvSoTien;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colNgoaiTe
            // 
            this.colNgoaiTe.Caption = "Số tiền $";
            this.colNgoaiTe.DisplayFormat.FormatString = "n0";
            this.colNgoaiTe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNgoaiTe.FieldName = "DuLuong";
            this.colNgoaiTe.Name = "colNgoaiTe";
            this.colNgoaiTe.OptionsColumn.AllowEdit = false;
            this.colNgoaiTe.OptionsColumn.ReadOnly = true;
            this.colNgoaiTe.Visible = true;
            this.colNgoaiTe.VisibleIndex = 0;
            // 
            // colTyGia
            // 
            this.colTyGia.Caption = "Tỷ giá";
            this.colTyGia.DisplayFormat.FormatString = "n0";
            this.colTyGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTyGia.FieldName = "TyGia";
            this.colTyGia.Name = "colTyGia";
            this.colTyGia.OptionsColumn.AllowEdit = false;
            this.colTyGia.OptionsColumn.ReadOnly = true;
            this.colTyGia.Visible = true;
            this.colTyGia.VisibleIndex = 1;
            // 
            // colVnD
            // 
            this.colVnD.Caption = "Số tiền VND";
            this.colVnD.DisplayFormat.FormatString = "n0";
            this.colVnD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVnD.FieldName = "DuLuongVND";
            this.colVnD.Name = "colVnD";
            this.colVnD.OptionsColumn.AllowEdit = false;
            this.colVnD.OptionsColumn.ReadOnly = true;
            this.colVnD.Visible = true;
            this.colVnD.VisibleIndex = 2;
            // 
            // colXuatTien
            // 
            this.colXuatTien.Caption = "Số tiền xuất";
            this.colXuatTien.ColumnEdit = this.repositoryItemTextEdit1;
            this.colXuatTien.DisplayFormat.FormatString = "n0";
            this.colXuatTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colXuatTien.FieldName = "SoTienXuat";
            this.colXuatTien.Name = "colXuatTien";
            this.colXuatTien.Visible = true;
            this.colXuatTien.VisibleIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btThoat);
            this.panel3.Controls.Add(this.btTuDong);
            this.panel3.Controls.Add(this.btXacNhan);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 229);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(565, 37);
            this.panel3.TabIndex = 2;
            // 
            // btThoat
            // 
            this.btThoat.Location = new System.Drawing.Point(338, 5);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(75, 23);
            this.btThoat.TabIndex = 2;
            this.btThoat.Text = "Đóng (Esc)";
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // btTuDong
            // 
            this.btTuDong.Location = new System.Drawing.Point(176, 5);
            this.btTuDong.Name = "btTuDong";
            this.btTuDong.Size = new System.Drawing.Size(75, 23);
            this.btTuDong.TabIndex = 0;
            this.btTuDong.Text = "&Tự động";
            this.btTuDong.Click += new System.EventHandler(this.btTuDong_Click);
            // 
            // btXacNhan
            // 
            this.btXacNhan.Location = new System.Drawing.Point(257, 5);
            this.btXacNhan.Name = "btXacNhan";
            this.btXacNhan.Size = new System.Drawing.Size(75, 23);
            this.btXacNhan.TabIndex = 1;
            this.btXacNhan.Text = "&Xác nhận";
            this.btXacNhan.Click += new System.EventHandler(this.btXacNhan_Click);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "n0";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "n0";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // GetSoDu4Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 269);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GetSoDu4Input";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Số tiền còn lại theo tỷ giá";
            this.Load += new System.EventHandler(this.GetSoDu4Input_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GetSoDu4Input_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiDoanRa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayTinh.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayTinh.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSoTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gvSoTien;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colNgoaiTe;
        private DevExpress.XtraGrid.Columns.GridColumn colTyGia;
        private DevExpress.XtraGrid.Columns.GridColumn colVnD;
        private DevExpress.XtraGrid.Columns.GridColumn colXuatTien;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton btThoat;
        private DevExpress.XtraEditors.SimpleButton btTuDong;
        private DevExpress.XtraEditors.SimpleButton btXacNhan;
        private DevExpress.XtraEditors.SimpleButton btLaySoLieu;
        private DevExpress.XtraEditors.LookUpEdit cboLoaiDoanRa;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit txtNgayTinh;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSoTien;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private System.Windows.Forms.RadioButton rbChuyenKhoan;
        private System.Windows.Forms.RadioButton rbTienMat;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}