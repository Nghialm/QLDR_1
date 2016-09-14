namespace QuanLyDoanRa.Reports
{
    partial class frmReportByLoaiDR
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkCheckZero = new DevExpress.XtraEditors.CheckEdit();
            this.dateTimeInput1 = new QuanLyDoanRa.Controls.DateTimeInput();
            this.cboLoaiDoanRa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboNam = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboThang = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ucExports1 = new QuanLyDoanRa.Controls.ucExports();
            this.btnHuyBo = new DevExpress.XtraEditors.SimpleButton();
            this.btnNhan = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCheckZero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiDoanRa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkCheckZero);
            this.groupControl1.Controls.Add(this.dateTimeInput1);
            this.groupControl1.Controls.Add(this.cboLoaiDoanRa);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.cboNam);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.cboThang);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(474, 72);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // chkCheckZero
            // 
            this.chkCheckZero.EditValue = true;
            this.chkCheckZero.Location = new System.Drawing.Point(331, 45);
            this.chkCheckZero.Name = "chkCheckZero";
            this.chkCheckZero.Properties.Caption = "Hiển thị QT đã hết";
            this.chkCheckZero.Size = new System.Drawing.Size(138, 19);
            this.chkCheckZero.TabIndex = 3;
            // 
            // dateTimeInput1
            // 
            this.dateTimeInput1.ChonDkNam = 0;
            this.dateTimeInput1.EndDate = new System.DateTime(((long)(0)));
            this.dateTimeInput1.IsNgay = false;
            this.dateTimeInput1.IsThang = false;
            this.dateTimeInput1.Location = new System.Drawing.Point(9, 13);
            this.dateTimeInput1.Name = "dateTimeInput1";
            this.dateTimeInput1.Size = new System.Drawing.Size(427, 25);
            this.dateTimeInput1.StartDate = new System.DateTime(((long)(0)));
            this.dateTimeInput1.TabIndex = 2;
            // 
            // cboLoaiDoanRa
            // 
            this.cboLoaiDoanRa.EnterMoveNextControl = true;
            this.cboLoaiDoanRa.Location = new System.Drawing.Point(130, 44);
            this.cboLoaiDoanRa.Name = "cboLoaiDoanRa";
            this.cboLoaiDoanRa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiDoanRa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaLoaiDoanRa", "Mã loại đoàn ra"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLoaiDoanRa", "Tên loại đoàn ra")});
            this.cboLoaiDoanRa.Properties.NullText = "";
            this.cboLoaiDoanRa.Size = new System.Drawing.Size(182, 20);
            this.cboLoaiDoanRa.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 47);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(59, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Loại đoàn ra";
            // 
            // cboNam
            // 
            this.cboNam.EnterMoveNextControl = true;
            this.cboNam.Location = new System.Drawing.Point(130, 117);
            this.cboNam.Name = "cboNam";
            this.cboNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNam.Properties.NullText = "";
            this.cboNam.Size = new System.Drawing.Size(123, 20);
            this.cboNam.TabIndex = 1;
            this.cboNam.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 120);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Chọn năm";
            this.labelControl2.Visible = false;
            // 
            // cboThang
            // 
            this.cboThang.EnterMoveNextControl = true;
            this.cboThang.Location = new System.Drawing.Point(130, 78);
            this.cboThang.Name = "cboThang";
            this.cboThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboThang.Properties.NullText = "";
            this.cboThang.Size = new System.Drawing.Size(123, 20);
            this.cboThang.TabIndex = 0;
            this.cboThang.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 81);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Chọn tháng";
            this.labelControl1.Visible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.ucExports1);
            this.panelControl1.Controls.Add(this.btnHuyBo);
            this.panelControl1.Controls.Add(this.btnNhan);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(4, 76);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(474, 40);
            this.panelControl1.TabIndex = 1;
            // 
            // ucExports1
            // 
            this.ucExports1.ButtonText = null;
            this.ucExports1.DefaultFileName = null;
            this.ucExports1.DisplayCol = null;
            this.ucExports1.DoExport = true;
            this.ucExports1.ExportData = null;
            this.ucExports1.ExportType = 0;
            this.ucExports1.Filenamedefault = "";
            this.ucExports1.Location = new System.Drawing.Point(315, 6);
            this.ucExports1.MustHasDataSource = true;
            this.ucExports1.Name = "ucExports1";
            this.ucExports1.PrintAfterExport = false;
            this.ucExports1.Size = new System.Drawing.Size(91, 23);
            this.ucExports1.StartCol = 0;
            this.ucExports1.StartRow = 0;
            this.ucExports1.TabIndex = 2;
            this.ucExports1.TemplateFileName = null;
            this.ucExports1.TemplateSheet = null;
            this.ucExports1.BeforExport += new System.EventHandler(this.ucExports1_BeforExport);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuyBo.Location = new System.Drawing.Point(224, 6);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(80, 23);
            this.btnHuyBo.TabIndex = 1;
            this.btnHuyBo.Text = "&Hủy bỏ";
            this.btnHuyBo.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btnNhan
            // 
            this.btnNhan.Location = new System.Drawing.Point(130, 6);
            this.btnNhan.Name = "btnNhan";
            this.btnNhan.Size = new System.Drawing.Size(80, 23);
            this.btnNhan.TabIndex = 0;
            this.btnNhan.Text = "&Nhận";
            this.btnNhan.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // frmReportByLoaiDR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnHuyBo;
            this.ClientSize = new System.Drawing.Size(482, 120);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportByLoaiDR";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều kiện tìm kiếm";
            this.Load += new System.EventHandler(this.frmReportByLoaiDR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCheckZero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiDoanRa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnHuyBo;
        private DevExpress.XtraEditors.SimpleButton btnNhan;
        private DevExpress.XtraEditors.LookUpEdit cboNam;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit cboThang;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboLoaiDoanRa;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private Controls.ucExports ucExports1;
        private Controls.DateTimeInput dateTimeInput1;
        private DevExpress.XtraEditors.CheckEdit chkCheckZero;
    }
}