using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Vns.Erp.Core.Admin.Domain;
using System.Drawing;
using Vns.Erp.Core;
using DevExpress.XtraEditors.Controls;

namespace QuanLyDoanRa.Controls
{
    public partial class DateTimeInput : DevExpress.XtraEditors.XtraUserControl
    {

        #region "Variables"
        private System.DateTime _StartDate;
        private System.DateTime _EndDate;
        private System.DateTime StartTemp;
        public ValueInfo Value_info = new ValueInfo();
        #endregion
        private System.DateTime EndTemp;

        public String TitleTime
        {
            get
            {
                if (Value_info == null) return "";
                else
                    SetValue();
                return Value_info.Ten;
            }
        }

        #region "Properties"
        public System.DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }

        private bool _isNgay;
        public bool IsNgay
        {
            get { return _isNgay; }
            set { _isNgay = value; }
        }

        private bool _isThang;
        public bool IsThang
        {
            get { return _isThang; }
            set { _isThang = value; }
        }

        private int _ChonDkNam = 0;
        public int ChonDkNam
        {
            get { return _ChonDkNam; }
            set { _ChonDkNam = value; }
        }



        public System.DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }


        #endregion

        #region "Common Functions"
        private void BindYear()
        {
            for (int i = DateTime.Now.Year + 2; i >= 1995; i += -1)
            {
                cmbYear.Properties.Items.Add(i);
                cmbYearMonth.Properties.Items.Add(i);
                cmbYearTerm.Properties.Items.Add(i);
            }
            cmbYear.SelectedItem = DateTime.Now.Year;
            cmbYearMonth.SelectedItem = DateTime.Now.Year;
            cmbYearTerm.SelectedItem = DateTime.Now.Year;
        }

        private void BindType()
        {
            List<string> lst = new List<string>();
            if (!_isNgay)
            {
                lst.Add("Ngày");
            }
            lst.Add("Tháng");
            lst.Add("Quý");
            lst.Add("Năm");
            cmbSelectMode.Properties.Items.AddRange(lst);
        }

        public void SetValue()
        {
            StartDate = StartTemp;
            EndDate = EndTemp;
            string strMode = "";
            if (!_isNgay)
            {
                if (cmbSelectMode.SelectedIndex == 0)
                {
                    Value_info.Tu_Ngay = StartDate;
                    Value_info.Den_Ngay = EndDate;
                    Value_info.ParameterValue = "-1";
                    Value_info.Ten = "Từ ngày: " + StartDate.Day.ToString() + "/" + StartDate.Month.ToString() + "/" + StartDate.Year.ToString();
                    Value_info.Ten += "   " + "Đến ngày: " + EndDate.Day.ToString() + "/" + EndDate.Month.ToString() + "/" + EndDate.Year.ToString();
                }
                else if (cmbSelectMode.SelectedIndex == 1)
                {
                    Value_info.Tu_Ngay = StartDate;
                    Value_info.Den_Ngay = EndDate;
                    Value_info.ParameterValue = "-1";
                    string s = cmbMonth.SelectedItem.ToString();
                    if (s.Length == 1) s = "0" + cmbMonth.SelectedItem.ToString();
                    
                    Value_info.Ten = "Tháng: " + s + "   " + "Năm: " + cmbYearMonth.SelectedItem.ToString();
                }
                else if (cmbSelectMode.SelectedIndex == 2)
                {
                    Value_info.Tu_Ngay = StartDate;
                    Value_info.Den_Ngay = EndDate;
                    Value_info.ParameterValue = "-1";
                    Value_info.Ten = "Quý: 0" + cmbTerm.SelectedItem.ToString() + "   " + "Năm: " + cmbYearTerm.SelectedItem.ToString();
                }
                else if (cmbSelectMode.SelectedIndex == 3)
                {
                    Value_info.Tu_Ngay = StartDate;
                    Value_info.Den_Ngay = EndDate;
                    Value_info.ParameterValue = "-1";
                    Value_info.Ten = "Năm: " + cmbYear.SelectedItem.ToString();
                }
            }
            else
            {
                if (cmbSelectMode.SelectedIndex == 0)
                {
                    Value_info.Tu_Ngay = StartDate;
                    Value_info.Den_Ngay = EndDate;
                    Value_info.ParameterValue = "-1";
                    Value_info.Ten = "Tháng: " + cmbMonth.SelectedItem.ToString() + "   " + "Năm: " + cmbYearMonth.SelectedItem.ToString();
                }
                else if (cmbSelectMode.SelectedIndex == 1)
                {
                    Value_info.Tu_Ngay = StartDate;
                    Value_info.Den_Ngay = EndDate;
                    Value_info.ParameterValue = "-1";
                    Value_info.Ten = "Quý: " + cmbTerm.SelectedItem.ToString() + "   " + "Năm: " + cmbYearTerm.SelectedItem.ToString();
                }
                else if (cmbSelectMode.SelectedIndex == 2)
                {
                    Value_info.Tu_Ngay = StartDate;
                    Value_info.Den_Ngay = EndDate;
                    Value_info.ParameterValue = "-1";
                    Value_info.Ten = "Năm: " + cmbYear.SelectedItem.ToString();
                }
            }
            Value_info.Tu_Ngay = VnsConvert.CStartOfDate((DateTime)Value_info.Tu_Ngay);
            Value_info.Den_Ngay = VnsConvert.CEndOfDate((DateTime)Value_info.Den_Ngay);
        }
        #endregion

        #region "Event Handles"
        public DateTimeInput()
        {

            InitializeComponent();
            Load += DateTimeInput_Load;
            cmbSelectMode.SelectedIndexChanged += cmbSelectMode_SelectedIndexChanged;
        }

        private void DateTimeInput_Load(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (!this.DesignMode)
                {
                    try
                    {
                        BindType();
                        //Init temp
                        StartTemp = System.DateTime.Now;
                        EndTemp = System.DateTime.Now;
                        StartDate = System.DateTime.Now;
                        EndDate = System.DateTime.Now;

                        //Init value
                        deDayStart.EditValue = System.DateTime.Now;
                        deDayEnd.EditValue = System.DateTime.Now;

                        BindYear();
                        //
                        cmbSelectMode.SelectedIndex = 0;
                        SetValue();                        
                    }
                    catch (Exception ex)
                    {
                        Commons.Commons.Message_Error(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        public void SetDieuKienMacDinh()
        {
            if (_ChonDkNam < 4)
                cmbSelectMode.SelectedIndex = _ChonDkNam;
            else
            {
                cmbSelectMode.SelectedIndex = 0;

                deDayStart.DateTime = new DateTime(2000, 1, 1, 0, 0, 0);
                deDayEnd.DateTime = DateTime.Now;
            }
        }


        public void SetDefault()
        {
            if (IsThang)
            {
                if (!_isNgay)
                    cmbSelectMode.SelectedIndex = 1;
                else
                    cmbSelectMode.SelectedIndex = 0;
            }
            else
            {
                cmbSelectMode.SelectedIndex = 0;

                deDayStart.DateTime = new DateTime(2000, 1, 1, 0, 0, 0);
                deDayEnd.DateTime = DateTime.Now;
            }
        }

        private void cmbSelectMode_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (!_isNgay)
                {
                    //Day
                    if (cmbSelectMode.SelectedIndex == 0)
                    {
                        deDayStart.Visible = true;
                        //204, 3
                        deDayEnd.Visible = true;
                        //322, 3

                        cmbMonth.Visible = false;
                        cmbYearMonth.Visible = false;

                        cmbTerm.Visible = false;
                        cmbYearTerm.Visible = false;

                        cmbYear.Visible = false;

                        deDayStart.EditValueChanged += deDayStart_EditValueChanged;
                        deDayEnd.EditValueChanged += deDayEnd_EditValueChanged;
                        deDayStart_EditValueChanged(sender, e);
                        deDayEnd_EditValueChanged(sender, e);

                        //Month
                    }
                    else if (cmbSelectMode.SelectedIndex == 1)
                    {
                        deDayStart.Visible = false;
                        //204, 3
                        deDayEnd.Visible = false;
                        //322, 3

                        cmbTerm.Visible = false;
                        cmbYearTerm.Visible = false;

                        cmbMonth.Visible = true;
                        cmbMonth.Location = new Point(204, 3);
                        cmbYearMonth.Visible = true;
                        cmbYearMonth.Location = new Point(322, 3);

                        cmbYear.Visible = false;

                        cmbMonth.SelectedIndexChanged += cmbMonth_SelectedIndexChanged;
                        cmbYearMonth.SelectedIndexChanged += cmbYearMonth_SelectedIndexChanged;
                        cmbMonth_SelectedIndexChanged(sender, e);

                        //Term
                    }
                    else if (cmbSelectMode.SelectedIndex == 2)
                    {
                        deDayStart.Visible = false;
                        //204, 3
                        deDayEnd.Visible = false;
                        //322, 3

                        cmbMonth.Visible = false;
                        cmbYearMonth.Visible = false;

                        cmbTerm.Visible = true;
                        cmbTerm.Location = new Point(204, 3);
                        cmbYearTerm.Visible = true;
                        cmbYearTerm.Location = new Point(322, 3);

                        cmbYear.Visible = false;

                        cmbTerm.SelectedIndexChanged += cmbTerm_SelectedIndexChanged;
                        cmbYearTerm.SelectedIndexChanged += cmbYearTerm_SelectedIndexChanged;
                        cmbTerm_SelectedIndexChanged(sender, e);

                        //Year
                    }
                    else if (cmbSelectMode.SelectedIndex == 3)
                    {
                        deDayStart.Visible = false;
                        //204, 3
                        deDayEnd.Visible = false;
                        //322, 3

                        cmbMonth.Visible = false;
                        cmbYearMonth.Visible = false;

                        cmbTerm.Visible = false;
                        cmbYearTerm.Visible = false;

                        cmbYear.Visible = true;
                        cmbYear.Location = new Point(204, 3);

                        cmbYear.SelectedIndexChanged += cmbYear_SelectedIndexChanged;
                        cmbYear_SelectedIndexChanged(sender, e);
                    }
                }
                else
                {
                    if (cmbSelectMode.SelectedIndex == 0)
                    {
                        deDayStart.Visible = false;
                        //204, 3
                        deDayEnd.Visible = false;
                        //322, 3

                        cmbTerm.Visible = false;
                        cmbYearTerm.Visible = false;

                        cmbMonth.Visible = true;
                        cmbMonth.Location = new Point(204, 3);
                        cmbYearMonth.Visible = true;
                        cmbYearMonth.Location = new Point(322, 3);

                        cmbYear.Visible = false;

                        cmbMonth.SelectedIndexChanged += cmbMonth_SelectedIndexChanged;
                        cmbYearMonth.SelectedIndexChanged += cmbYearMonth_SelectedIndexChanged;
                        cmbMonth_SelectedIndexChanged(sender, e);

                        //Term
                    }
                    else if (cmbSelectMode.SelectedIndex == 1)
                    {
                        deDayStart.Visible = false;
                        //204, 3
                        deDayEnd.Visible = false;
                        //322, 3

                        cmbMonth.Visible = false;
                        cmbYearMonth.Visible = false;

                        cmbTerm.Visible = true;
                        cmbTerm.Location = new Point(204, 3);
                        cmbYearTerm.Visible = true;
                        cmbYearTerm.Location = new Point(322, 3);

                        cmbYear.Visible = false;

                        cmbTerm.SelectedIndexChanged += cmbTerm_SelectedIndexChanged;
                        cmbYearTerm.SelectedIndexChanged += cmbYearTerm_SelectedIndexChanged;
                        cmbTerm_SelectedIndexChanged(sender, e);

                        //Year
                    }
                    else if (cmbSelectMode.SelectedIndex == 2)
                    {
                        deDayStart.Visible = false;
                        //204, 3
                        deDayEnd.Visible = false;
                        //322, 3

                        cmbMonth.Visible = false;
                        cmbYearMonth.Visible = false;

                        cmbTerm.Visible = false;
                        cmbYearTerm.Visible = false;

                        cmbYear.Visible = true;
                        cmbYear.Location = new Point(204, 3);

                        cmbYear.SelectedIndexChanged += cmbYear_SelectedIndexChanged;
                        cmbYear_SelectedIndexChanged(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }
        #endregion

        #region "Set Value"
        //Day Mode
        private void deDayStart_EditValueChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                StartTemp = (DateTime)deDayStart.EditValue;
                SetValue();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void deDayEnd_EditValueChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                EndTemp = (DateTime)deDayEnd.EditValue;
                SetValue();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        //Month Mode
        private void cmbMonth_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                int year_selected = int.Parse(cmbYearMonth.SelectedItem.ToString());
                int month_selected = int.Parse(cmbMonth.SelectedItem.ToString());
                StartTemp = new System.DateTime(year_selected, month_selected, 1);
                EndTemp = StartTemp.AddMonths(1).AddDays(-1);
                SetValue();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void cmbYearMonth_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                int year_selected = int.Parse(cmbYearMonth.SelectedItem.ToString());
                int month_selected = StartTemp.Month;
                StartTemp = new System.DateTime(year_selected, month_selected, 1);
                EndTemp = StartTemp.AddMonths(1).AddDays(-1);
                SetValue();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        private void SetQuarterValue()
        {
            try
            {
                int year_selected = int.Parse(cmbYearTerm.SelectedItem.ToString());
                if (cmbTerm.SelectedIndex == 0)
                {
                    //Term 1 : Month 1, 2, 3 : 1/1 - 31/3
                    StartTemp = new System.DateTime(year_selected, 2, 1);
                    EndTemp = StartTemp.AddMonths(2).AddDays(-1);
                }
                else if (cmbTerm.SelectedIndex == 1)
                {
                    //Term 2 : Month 4, 5, 6 : 1/4 - 30/6
                    StartTemp = new System.DateTime(year_selected, 4, 1);
                    EndTemp = StartTemp.AddMonths(3).AddDays(-1);
                }
                else if (cmbTerm.SelectedIndex == 2)
                {
                    //Term 3 : Month 7, 8, 9 : 1/7 - 30/9
                    StartTemp = new System.DateTime(year_selected, 7, 1);
                    EndTemp = StartTemp.AddMonths(3).AddDays(-1);
                }
                else if (cmbTerm.SelectedIndex == 3)
                {
                    //Term 4 : Month 10, 11, 12 : 1/10 - 31/12
                    StartTemp = new System.DateTime(year_selected, 10, 1);
                    EndTemp = StartTemp.AddMonths(4).AddDays(-1);
                }
                SetValue();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        //Term Mode
        private void cmbTerm_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            SetQuarterValue();
        }

        private void cmbYearTerm_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            SetQuarterValue();
        }

        //Year Mode
        private void cmbYear_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                int year_selected = int.Parse(cmbYear.SelectedItem.ToString());
                StartTemp = new System.DateTime(year_selected, 1, 1);
                EndTemp = new System.DateTime(year_selected, 12, 31);
                SetValue();
            }
            catch (Exception ex)
            {
                Commons.Commons.Message_Error(ex);
            }
        }

        #endregion

        #region "Key Down Events"

        #endregion

    }
}
