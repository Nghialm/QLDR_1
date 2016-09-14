namespace QuanLyDoanRa.Reports
{
    partial class FrmThamSoBaoCao
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
            this.label2 = new System.Windows.Forms.Label();
            this.dNgayIn = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.mmCanCuCongVan = new DevExpress.XtraEditors.MemoEdit();
            this.dNgayCanCuHoSo = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkInKem = new DevExpress.XtraEditors.CheckEdit();
            this.txtSoThongBao = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoCanCuHoSo = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDtBs = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dNgayIn.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dNgayIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmCanCuCongVan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dNgayCanCuHoSo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dNgayCanCuHoSo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkInKem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoThongBao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCanCuHoSo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDtBs.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày in";
            // 
            // dNgayIn
            // 
            this.dNgayIn.EditValue = null;
            this.dNgayIn.EnterMoveNextControl = true;
            this.dNgayIn.Location = new System.Drawing.Point(126, 14);
            this.dNgayIn.Name = "dNgayIn";
            this.dNgayIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dNgayIn.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dNgayIn.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dNgayIn.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dNgayIn.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dNgayIn.Size = new System.Drawing.Size(132, 20);
            this.dNgayIn.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Căn cứ công văn";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(349, 234);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(80, 23);
            this.btnIn.TabIndex = 5;
            this.btnIn.Text = "&In báo cáo";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnDong
            // 
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Location = new System.Drawing.Point(435, 234);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(80, 23);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "&Đóng lại";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // mmCanCuCongVan
            // 
            this.mmCanCuCongVan.EnterMoveNextControl = true;
            this.mmCanCuCongVan.Location = new System.Drawing.Point(126, 126);
            this.mmCanCuCongVan.Name = "mmCanCuCongVan";
            this.mmCanCuCongVan.Size = new System.Drawing.Size(389, 96);
            this.mmCanCuCongVan.TabIndex = 4;
            // 
            // dNgayCanCuHoSo
            // 
            this.dNgayCanCuHoSo.EditValue = null;
            this.dNgayCanCuHoSo.EnterMoveNextControl = true;
            this.dNgayCanCuHoSo.Location = new System.Drawing.Point(126, 67);
            this.dNgayCanCuHoSo.Name = "dNgayCanCuHoSo";
            this.dNgayCanCuHoSo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dNgayCanCuHoSo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dNgayCanCuHoSo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dNgayCanCuHoSo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dNgayCanCuHoSo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dNgayCanCuHoSo.Size = new System.Drawing.Size(132, 20);
            this.dNgayCanCuHoSo.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Căn cứ hồ sơ ngày";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkDtBs);
            this.panelControl1.Controls.Add(this.chkInKem);
            this.panelControl1.Controls.Add(this.txtSoThongBao);
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.txtSoCanCuHoSo);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.dNgayIn);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.dNgayCanCuHoSo);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.btnIn);
            this.panelControl1.Controls.Add(this.mmCanCuCongVan);
            this.panelControl1.Controls.Add(this.btnDong);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(4, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(525, 284);
            this.panelControl1.TabIndex = 0;
            // 
            // chkInKem
            // 
            this.chkInKem.Location = new System.Drawing.Point(124, 232);
            this.chkInKem.Name = "chkInKem";
            this.chkInKem.Properties.Caption = "In kèm số thông báo";
            this.chkInKem.Size = new System.Drawing.Size(134, 19);
            this.chkInKem.TabIndex = 14;
            // 
            // txtSoThongBao
            // 
            this.txtSoThongBao.EnterMoveNextControl = true;
            this.txtSoThongBao.Location = new System.Drawing.Point(126, 40);
            this.txtSoThongBao.Name = "txtSoThongBao";
            this.txtSoThongBao.Size = new System.Drawing.Size(195, 20);
            this.txtSoThongBao.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Số thông báo";
            // 
            // txtSoCanCuHoSo
            // 
            this.txtSoCanCuHoSo.EnterMoveNextControl = true;
            this.txtSoCanCuHoSo.Location = new System.Drawing.Point(126, 93);
            this.txtSoCanCuHoSo.Name = "txtSoCanCuHoSo";
            this.txtSoCanCuHoSo.Size = new System.Drawing.Size(195, 20);
            this.txtSoCanCuHoSo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Số căn cứ hồ sơ";
            // 
            // chkDtBs
            // 
            this.chkDtBs.Location = new System.Drawing.Point(327, 41);
            this.chkDtBs.Name = "chkDtBs";
            this.chkDtBs.Properties.Caption = "Dự toán bổ sung";
            this.chkDtBs.Size = new System.Drawing.Size(102, 19);
            this.chkDtBs.TabIndex = 15;
            this.chkDtBs.CheckedChanged += new System.EventHandler(this.chkDtBs_CheckedChanged);
            // 
            // FrmThamSoBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.panelControl1);
            this.KeyPreview = true;
            this.Name = "FrmThamSoBaoCao";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tham số báo cáo";
            this.Load += new System.EventHandler(this.FrmThamSoBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dNgayIn.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dNgayIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmCanCuCongVan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dNgayCanCuHoSo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dNgayCanCuHoSo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkInKem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoThongBao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoCanCuHoSo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDtBs.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit dNgayIn;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.MemoEdit mmCanCuCongVan;
        private DevExpress.XtraEditors.DateEdit dNgayCanCuHoSo;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtSoCanCuHoSo;
        private DevExpress.XtraEditors.TextEdit txtSoThongBao;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.CheckEdit chkInKem;
        private DevExpress.XtraEditors.CheckEdit chkDtBs;
    }
}