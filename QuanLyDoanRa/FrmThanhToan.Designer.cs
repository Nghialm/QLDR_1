namespace QuanLyDoanRa
{
    partial class FrmThanhToan
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNuocDen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenMuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenKhoanChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTienDuToan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnBaoCao = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.txtThanhToan = new DevExpress.XtraEditors.TextEdit();
            this.txtTamTinh = new DevExpress.XtraEditors.TextEdit();
            this.txtNgayVe = new DevExpress.XtraEditors.TextEdit();
            this.txtNgayDi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenDoan = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThanhToan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTamTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayVe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayDi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDoan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtThanhToan);
            this.panelControl1.Controls.Add(this.txtTamTinh);
            this.panelControl1.Controls.Add(this.txtNgayVe);
            this.panelControl1.Controls.Add(this.txtNgayDi);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtTenDoan);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1000, 112);
            this.panelControl1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(4, 116);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1000, 452);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Thông tin các khoản";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 22);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(996, 428);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT,
            this.colNuocDen,
            this.colTenMuc,
            this.colTenKhoanChi,
            this.colSoTienDuToan});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colSTT
            // 
            this.colSTT.Caption = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            // 
            // colNuocDen
            // 
            this.colNuocDen.Caption = "Nước Đến";
            this.colNuocDen.Name = "colNuocDen";
            this.colNuocDen.Visible = true;
            this.colNuocDen.VisibleIndex = 1;
            // 
            // colTenMuc
            // 
            this.colTenMuc.Caption = "Tên Mục";
            this.colTenMuc.Name = "colTenMuc";
            this.colTenMuc.Visible = true;
            this.colTenMuc.VisibleIndex = 2;
            // 
            // colTenKhoanChi
            // 
            this.colTenKhoanChi.Caption = "Tên Khoản Chi";
            this.colTenKhoanChi.Name = "colTenKhoanChi";
            this.colTenKhoanChi.Visible = true;
            this.colTenKhoanChi.VisibleIndex = 3;
            // 
            // colSoTienDuToan
            // 
            this.colSoTienDuToan.Caption = "Số Tiền Dự Toán";
            this.colSoTienDuToan.Name = "colSoTienDuToan";
            this.colSoTienDuToan.Visible = true;
            this.colSoTienDuToan.VisibleIndex = 4;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(3, 5);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(80, 30);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "Lưu";
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(89, 5);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(93, 30);
            this.btnBaoCao.TabIndex = 6;
            this.btnBaoCao.Text = "Xuất báo cáo";
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(917, 5);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(80, 30);
            this.btnDong.TabIndex = 8;
            this.btnDong.Text = "Đóng";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.btnDong);
            this.panelControl3.Controls.Add(this.btnLuu);
            this.panelControl3.Controls.Add(this.btnBaoCao);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(4, 568);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1000, 40);
            this.panelControl3.TabIndex = 9;
            // 
            // txtThanhToan
            // 
            this.txtThanhToan.Location = new System.Drawing.Point(367, 69);
            this.txtThanhToan.Name = "txtThanhToan";
            this.txtThanhToan.Size = new System.Drawing.Size(152, 20);
            this.txtThanhToan.TabIndex = 30;
            // 
            // txtTamTinh
            // 
            this.txtTamTinh.Location = new System.Drawing.Point(367, 43);
            this.txtTamTinh.Name = "txtTamTinh";
            this.txtTamTinh.Size = new System.Drawing.Size(152, 20);
            this.txtTamTinh.TabIndex = 29;
            // 
            // txtNgayVe
            // 
            this.txtNgayVe.Location = new System.Drawing.Point(61, 69);
            this.txtNgayVe.Name = "txtNgayVe";
            this.txtNgayVe.Size = new System.Drawing.Size(152, 20);
            this.txtNgayVe.TabIndex = 28;
            // 
            // txtNgayDi
            // 
            this.txtNgayDi.Location = new System.Drawing.Point(61, 43);
            this.txtNgayDi.Name = "txtNgayDi";
            this.txtNgayDi.Size = new System.Drawing.Size(152, 20);
            this.txtNgayDi.TabIndex = 27;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(248, 73);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(113, 13);
            this.labelControl5.TabIndex = 26;
            this.labelControl5.Text = "Tổng chi phí thanh toán";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(262, 47);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(99, 13);
            this.labelControl4.TabIndex = 25;
            this.labelControl4.Text = "Tổng chi phí tạm tính";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 73);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 13);
            this.labelControl3.TabIndex = 24;
            this.labelControl3.Text = "Ngày về";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 23;
            this.labelControl2.Text = "Ngày đi";
            // 
            // txtTenDoan
            // 
            this.txtTenDoan.Location = new System.Drawing.Point(61, 17);
            this.txtTenDoan.Name = "txtTenDoan";
            this.txtTenDoan.Size = new System.Drawing.Size(152, 20);
            this.txtTenDoan.TabIndex = 22;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Tên đoàn";
            // 
            // FrmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 612);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmThanhToan";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "FrmThanhToan";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtThanhToan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTamTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayVe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayDi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDoan.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colNuocDen;
        private DevExpress.XtraGrid.Columns.GridColumn colTenMuc;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKhoanChi;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTienDuToan;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnBaoCao;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.TextEdit txtThanhToan;
        private DevExpress.XtraEditors.TextEdit txtTamTinh;
        private DevExpress.XtraEditors.TextEdit txtNgayVe;
        private DevExpress.XtraEditors.TextEdit txtNgayDi;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtTenDoan;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
    }
}