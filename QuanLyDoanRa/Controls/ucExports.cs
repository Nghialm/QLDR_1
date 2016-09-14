using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyDoanRa.Commons;
using System.IO;

namespace QuanLyDoanRa.Controls
{
    public partial class ucExports : UserControl
    {
        private List<VnsDoanRaParameter> _lstParameter = new List<VnsDoanRaParameter>();
        private DataSet _ExportData;
        public DataSet ExportData
        {
            get { return _ExportData; }
            set { _ExportData = value; }
        }
        private string _TemplateFileName;
        public string TemplateFileName
        {
            get { return _TemplateFileName; }
            set { _TemplateFileName = value; }
        }
        private string _TemplateSheet;
        public string TemplateSheet
        {
            get { return _TemplateSheet; }
            set { _TemplateSheet = value; }
        }
        private string _DefaultFileName;
        public string DefaultFileName
        {
            get { return _DefaultFileName; }
            set { _DefaultFileName = value; }
        }
        private string _ButtonText;
        public string ButtonText
        {
            get { return _ButtonText; }
            set { _ButtonText = value; }
        }
        private int _StartRow;
        public int StartRow
        {
            get { return _StartRow; }
            set { _StartRow = value; }
        }
        private int _StartCol;
        public int StartCol
        {
            get { return _StartCol; }
            set { _StartCol = value; }
        }
        private bool _PrintAfterExport = false;
        public bool PrintAfterExport
        {
            get { return _PrintAfterExport; }
            set { _PrintAfterExport = value; }
        }
        private bool _MustHasDataSource = true;
        public bool MustHasDataSource
        {
            get { return _MustHasDataSource; }
            set { _MustHasDataSource = value; }
        }
        private int _ExportType = 0;
        public int ExportType
        {
            get { return _ExportType; }
            set { _ExportType = value; }
        }
        private string _DisplayCol;
        public string DisplayCol
        {
            get { return _DisplayCol; }
            set { _DisplayCol = value; }
        }
        private bool _DoExport = true;

        private string _filenamedefault="";
        public string Filenamedefault
        {
            get { return _filenamedefault; }
            set { _filenamedefault = value; }
        }
        public bool DoExport
        {
            get { return _DoExport; }
            set { _DoExport = value; }
        }

        public void CleanParameter()
        {
            _lstParameter.Clear();
        }

        public void AddParameter(VnsDoanRaParameter parameter)
        {
            if (_lstParameter != null)
            {
                _lstParameter.Add(parameter);
            }
        }
        public ucExports()
        {

            InitializeComponent();
            ExcelSaveFile.FileName = this.Filenamedefault;
        }

        public event EventHandler  BeforExport;
        public event EventHandler AfterExport;

        private void btnExport_Click(object sender, EventArgs e)
        {
            if(ExcelSaveFile.ShowDialog() == DialogResult.Cancel)
                return;

            if (BeforExport != null)
                BeforExport(this, e);

            string filename = ExcelSaveFile.FileName;
           // MessageBox.Show(filename);
            Guid tmp = Guid.NewGuid();
            string templatefile = Directory.GetCurrentDirectory() + "\\TempReport\\" + TemplateFileName;
            string tmpfile = Directory.GetCurrentDirectory() + "\\" + tmp.ToString()+ TemplateFileName;
            string typefile = VnsExport.GetExtendFile(filename);            
            File.Copy(templatefile,tmpfile,true);
            VnsExport.ExportToExcelWithInterop(filename, tmpfile,ExportData, TemplateSheet, _lstParameter, StartRow, StartCol, DisplayCol, true);
            File.Delete(tmpfile);
            //if (MessageBox.Show("Xuất dữ liệu thành công, Bạn có muốn mở file không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            //{
            //    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //    Microsoft.Office.Interop.Excel.Workbook wb = excel.Workbooks.Open(filename);
            //}
        }
    }
}
