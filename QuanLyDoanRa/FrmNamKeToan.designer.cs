namespace QuanLyDoanRa
{
    partial class FrmNamKeToan
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNam = new DevExpress.XtraEditors.TextEdit();
            this.btnThucHien = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(67, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(21, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Năm";
            // 
            // txtNam
            // 
            this.txtNam.EditValue = "";
            this.txtNam.EnterMoveNextControl = true;
            this.txtNam.Location = new System.Drawing.Point(94, 21);
            this.txtNam.Name = "txtNam";
            this.txtNam.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNam.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtNam.Properties.Mask.EditMask = "[0-9]{4}";
            this.txtNam.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtNam.Properties.Mask.ShowPlaceHolders = false;
            this.txtNam.Size = new System.Drawing.Size(83, 20);
            this.txtNam.TabIndex = 1;
            // 
            // btnThucHien
            // 
            this.btnThucHien.Location = new System.Drawing.Point(94, 48);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(75, 23);
            this.btnThucHien.TabIndex = 2;
            this.btnThucHien.Text = "Lưu";
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // FrmNamKeToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 85);
            this.Controls.Add(this.btnThucHien);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.labelControl1);
            this.KeyPreview = true;
            this.Name = "FrmNamKeToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Năm kế toán";
            this.Load += new System.EventHandler(this.FrmTongHopKinhPhi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmNamKeToan_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtNam.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNam;
        private DevExpress.XtraEditors.SimpleButton btnThucHien;
    }
}