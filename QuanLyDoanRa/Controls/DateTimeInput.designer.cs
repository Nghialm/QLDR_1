using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace QuanLyDoanRa.Controls
{
    public partial class DateTimeInput : DevExpress.XtraEditors.XtraUserControl
    {

        //UserControl overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer

        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.cmbSelectMode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.deDayStart = new DevExpress.XtraEditors.DateEdit();
            this.deDayEnd = new DevExpress.XtraEditors.DateEdit();
            this.LabelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbTerm = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbYearMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbYearTerm = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSelectMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDayStart.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDayStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDayEnd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDayEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTerm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYearMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYearTerm.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSelectMode
            // 
            this.cmbSelectMode.EditValue = "Kiểu";
            this.cmbSelectMode.EnterMoveNextControl = true;
            this.cmbSelectMode.Location = new System.Drawing.Point(122, 3);
            this.cmbSelectMode.Name = "cmbSelectMode";
            this.cmbSelectMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSelectMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbSelectMode.Size = new System.Drawing.Size(64, 20);
            this.cmbSelectMode.TabIndex = 1;
            // 
            // deDayStart
            // 
            this.deDayStart.EditValue = null;
            this.deDayStart.EnterMoveNextControl = true;
            this.deDayStart.Location = new System.Drawing.Point(204, 3);
            this.deDayStart.Name = "deDayStart";
            this.deDayStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deDayStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDayStart.Properties.DisplayFormat.FormatString = "g";
            this.deDayStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDayStart.Properties.EditFormat.FormatString = "g";
            this.deDayStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDayStart.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deDayStart.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deDayStart.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.deDayStart.Properties.MaxValue = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.deDayStart.Properties.MinValue = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.deDayStart.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDayStart.Size = new System.Drawing.Size(100, 20);
            this.deDayStart.TabIndex = 2;
            // 
            // deDayEnd
            // 
            this.deDayEnd.EditValue = null;
            this.deDayEnd.EnterMoveNextControl = true;
            this.deDayEnd.Location = new System.Drawing.Point(322, 3);
            this.deDayEnd.Name = "deDayEnd";
            this.deDayEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deDayEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDayEnd.Properties.DisplayFormat.FormatString = "g";
            this.deDayEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDayEnd.Properties.EditFormat.FormatString = "g";
            this.deDayEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDayEnd.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deDayEnd.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deDayEnd.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.deDayEnd.Properties.MaxValue = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.deDayEnd.Properties.MinValue = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.deDayEnd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDayEnd.Size = new System.Drawing.Size(100, 20);
            this.deDayEnd.TabIndex = 3;
            // 
            // LabelControl1
            // 
            this.LabelControl1.Location = new System.Drawing.Point(3, 5);
            this.LabelControl1.Name = "LabelControl1";
            this.LabelControl1.Size = new System.Drawing.Size(32, 13);
            this.LabelControl1.TabIndex = 0;
            this.LabelControl1.Text = "Chọn :";
            // 
            // cmbMonth
            // 
            this.cmbMonth.EditValue = "1";
            this.cmbMonth.EnterMoveNextControl = true;
            this.cmbMonth.Location = new System.Drawing.Point(122, 40);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMonth.Properties.DropDownRows = 12;
            this.cmbMonth.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbMonth.Size = new System.Drawing.Size(100, 20);
            this.cmbMonth.TabIndex = 4;
            this.cmbMonth.Visible = false;
            // 
            // cmbTerm
            // 
            this.cmbTerm.EditValue = "1";
            this.cmbTerm.EnterMoveNextControl = true;
            this.cmbTerm.Location = new System.Drawing.Point(122, 78);
            this.cmbTerm.Name = "cmbTerm";
            this.cmbTerm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTerm.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbTerm.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTerm.Size = new System.Drawing.Size(100, 20);
            this.cmbTerm.TabIndex = 6;
            this.cmbTerm.Visible = false;
            // 
            // cmbYear
            // 
            this.cmbYear.EnterMoveNextControl = true;
            this.cmbYear.Location = new System.Drawing.Point(228, 114);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbYear.Size = new System.Drawing.Size(100, 20);
            this.cmbYear.TabIndex = 8;
            this.cmbYear.Visible = false;
            // 
            // cmbYearMonth
            // 
            this.cmbYearMonth.EnterMoveNextControl = true;
            this.cmbYearMonth.Location = new System.Drawing.Point(228, 40);
            this.cmbYearMonth.Name = "cmbYearMonth";
            this.cmbYearMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbYearMonth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbYearMonth.Size = new System.Drawing.Size(100, 20);
            this.cmbYearMonth.TabIndex = 5;
            this.cmbYearMonth.Visible = false;
            // 
            // cmbYearTerm
            // 
            this.cmbYearTerm.EnterMoveNextControl = true;
            this.cmbYearTerm.Location = new System.Drawing.Point(228, 78);
            this.cmbYearTerm.Name = "cmbYearTerm";
            this.cmbYearTerm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbYearTerm.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbYearTerm.Size = new System.Drawing.Size(100, 20);
            this.cmbYearTerm.TabIndex = 7;
            this.cmbYearTerm.Visible = false;
            // 
            // DateTimeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbYearTerm);
            this.Controls.Add(this.cmbYearMonth);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.cmbTerm);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.LabelControl1);
            this.Controls.Add(this.deDayEnd);
            this.Controls.Add(this.deDayStart);
            this.Controls.Add(this.cmbSelectMode);
            this.Name = "DateTimeInput";
            this.Size = new System.Drawing.Size(520, 25);
            ((System.ComponentModel.ISupportInitialize)(this.cmbSelectMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDayStart.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDayStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDayEnd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDayEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTerm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYearMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYearTerm.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal DevExpress.XtraEditors.ComboBoxEdit cmbSelectMode;
        internal DevExpress.XtraEditors.DateEdit deDayStart;
        internal DevExpress.XtraEditors.DateEdit deDayEnd;
        internal DevExpress.XtraEditors.LabelControl LabelControl1;
        internal DevExpress.XtraEditors.ComboBoxEdit cmbMonth;
        internal DevExpress.XtraEditors.ComboBoxEdit cmbTerm;
        internal DevExpress.XtraEditors.ComboBoxEdit cmbYear;
        internal DevExpress.XtraEditors.ComboBoxEdit cmbYearMonth;

        internal DevExpress.XtraEditors.ComboBoxEdit cmbYearTerm;
    }
}