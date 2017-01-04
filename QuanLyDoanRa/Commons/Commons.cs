using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.ComponentModel;
using System.Data;
using DevExpress.XtraReports.Parameters;
using Vns.QuanLyDoanRa.Domain;
using System.Collections;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
namespace QuanLyDoanRa.Commons
{
    public class Commons
    {
        #region "Message"

        public static bool Message_Confirm(string sMessage, bool bShowRetry = false)
        {
            //Hàm hiện message confirm 
            if (bShowRetry)
            {
                return (MessageBox.Show(sMessage, System.Windows.Forms.Application.ProductName, MessageBoxButtons.RetryCancel, MessageBoxIcon.Question) == DialogResult.Retry);
            }
            else
            {
                return (MessageBox.Show(sMessage, System.Windows.Forms.Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
            }
        }

        public static DialogResult Message_YesNoCancel(string sMessage)
        {
            //Hàm hiện message YesNoCancel
            return MessageBox.Show(sMessage, System.Windows.Forms.Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        public static void Message_Information(string sMessage)
        {
            //Thủ tục hiện message information
            MessageBox.Show(sMessage, System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Message_Warning(string sMessage)
        {
            //Thủ tục hiện message warning
            MessageBox.Show(sMessage, System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Message_Error(Exception ex)
        {
            // Message_Error(ex, "");
            Message_Warning("Đã có lỗi xảy ra, vui lòng kiểm tra lại hệ thống." + ex.Message);

        }

        public static void Message_Error(Exception ex, string sDesc)
        {
            MessageBox.Show(ex.ToString(), System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static IList<DateTime> GetTuNgayDenNgayTrongThang(int Thang, int Nam)
        {
            DateTime TuNgay = new DateTime(Nam, Thang, 1);

            TuNgay = TuNgay.AddDays((-TuNgay.Day) + 1);

            DateTime DenNgay = new DateTime(Nam, Thang, 1);
            //DenNgay = DenNgay.AddMonths(1).AddDays(-1);
            DenNgay = DenNgay.AddMonths(1);
            DenNgay = DenNgay.AddDays(-(DenNgay.Day));
            IList<DateTime> lst = new List<DateTime>();
            lst.Add(TuNgay);
            lst.Add(DenNgay);
            // MessageBox.Show(TuNgay.ToString() + "---" + DenNgay.ToString());
            return lst;
        }
        #endregion

        #region "DataHelper"
        public static System.Data.DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            System.Data.DataTable dt = new System.Data.DataTable();
            for (int i = 0; i <= properties.Count - 1; i++)
            {
                PropertyDescriptor property = properties[i];
                try
                {
                    dt.Columns.Add(property.Name, property.PropertyType);
                }
                catch (Exception ex)
                {
                    dt.Columns.Add(property.Name, typeof(DateTime));
                }

            }
            object[] values = new object[properties.Count];
            foreach (T item in data)
            {
                for (int i = 0; i <= values.Length - 1; i++)
                {
                    if (object.ReferenceEquals(properties[i].PropertyType, typeof(DateTime)))
                    {
                        DateTime tmp = (DateTime)properties[i].GetValue(item);
                        values[i] = tmp <= DateTime.MinValue ? null : properties[i].GetValue(item);
                    }
                    else if (object.ReferenceEquals(properties[i].PropertyType, typeof(decimal)))
                    {
                        decimal tmp = (decimal)properties[i].GetValue(item);
                        values[i] = tmp <= Int32.MinValue ? null : properties[i].GetValue(item);
                    }
                    else
                    {
                        values[i] = properties[i].GetValue(item);
                    }
                }
                dt.Rows.Add(values);
            }
            return dt;
        }

        public static System.Data.DataTable ToDataTable<T>(List<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            System.Data.DataTable dt = new System.Data.DataTable();
            for (int i = 0; i <= properties.Count - 1; i++)
            {
                PropertyDescriptor property = properties[i];
                try
                {
                    dt.Columns.Add(property.Name, property.PropertyType);
                }
                catch (Exception ex)
                {
                    dt.Columns.Add(property.Name, typeof(DateTime));
                }

            }
            object[] values = new object[properties.Count];
            foreach (T item in data)
            {
                for (int i = 0; i <= values.Length - 1; i++)
                {
                    if (object.ReferenceEquals(properties[i].PropertyType, typeof(DateTime)))
                    {
                        DateTime tmp = (DateTime)properties[i].GetValue(item);
                        values[i] = tmp <= DateTime.MinValue ? null : properties[i].GetValue(item);
                    }
                    else if (object.ReferenceEquals(properties[i].PropertyType, typeof(decimal)))
                    {
                        decimal tmp = (decimal)properties[i].GetValue(item);
                        values[i] = tmp <= Int32.MinValue ? null : properties[i].GetValue(item);
                    }
                    else
                    {
                        values[i] = properties[i].GetValue(item);
                    }
                }
                dt.Rows.Add(values);
            }
            return dt;
        }
        #endregion

        #region "read string of number"
        private static string[] ChuSo = new string[10] { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bẩy", " tám", " chín" };
        private static string[] Tien = new string[6] { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };
        // Hàm đọc số thành chữ
        public static string DocTienBangChu(long SoTien, string strTail)
        {
            int lan, i;
            long so;
            string KetQua = "", tmp = "";
            int[] ViTri = new int[6];
            if (SoTien < 0) return "Số tiền âm !";
            if (SoTien == 0) return "Không đồng !";
            if (SoTien > 0)
            {
                so = SoTien;
            }
            else
            {
                so = -SoTien;
            }
            //Kiểm tra số quá lớn
            if (SoTien > 8999999999999999)
            {
                SoTien = 0;
                return "";
            }
            ViTri[5] = (int)(so / 1000000000000000);
            so = so - long.Parse(ViTri[5].ToString()) * 1000000000000000;
            ViTri[4] = (int)(so / 1000000000000);
            so = so - long.Parse(ViTri[4].ToString()) * +1000000000000;
            ViTri[3] = (int)(so / 1000000000);
            so = so - long.Parse(ViTri[3].ToString()) * 1000000000;
            ViTri[2] = (int)(so / 1000000);
            ViTri[1] = (int)((so % 1000000) / 1000);
            ViTri[0] = (int)(so % 1000);
            if (ViTri[5] > 0)
            {
                lan = 5;
            }
            else if (ViTri[4] > 0)
            {
                lan = 4;
            }
            else if (ViTri[3] > 0)
            {
                lan = 3;
            }
            else if (ViTri[2] > 0)
            {
                lan = 2;
            }
            else if (ViTri[1] > 0)
            {
                lan = 1;
            }
            else
            {
                lan = 0;
            }
            for (i = lan; i >= 0; i--)
            {
                tmp = DocSo3ChuSo(ViTri[i]);
                KetQua += tmp;
                if (ViTri[i] != 0) KetQua += Tien[i];
                if ((i > 0) && (!string.IsNullOrEmpty(tmp))) KetQua += ",";//&& (!string.IsNullOrEmpty(tmp))
            }
            if (KetQua.Substring(KetQua.Length - 1, 1) == ",") KetQua = KetQua.Substring(0, KetQua.Length - 1);
            KetQua = KetQua.Trim() + strTail;
            return KetQua.Substring(0, 1).ToUpper() + KetQua.Substring(1);
        }
        // Hàm đọc số có 3 chữ số
        public static string DocSo3ChuSo(int baso)
        {
            int tram, chuc, donvi;
            string KetQua = "";
            tram = (int)(baso / 100);
            chuc = (int)((baso % 100) / 10);
            donvi = baso % 10;
            if ((tram == 0) && (chuc == 0) && (donvi == 0)) return "";
            if (tram != 0)
            {
                KetQua += ChuSo[tram] + " trăm";
                if ((chuc == 0) && (donvi != 0)) KetQua += " linh";
            }
            if ((chuc != 0) && (chuc != 1))
            {
                KetQua += ChuSo[chuc] + " mươi";
                if ((chuc == 0) && (donvi != 0)) KetQua = KetQua + " linh";
            }
            if (chuc == 1) KetQua += " mười";
            switch (donvi)
            {
                case 1:
                    if ((chuc != 0) && (chuc != 1))
                    {
                        KetQua += " mốt";
                    }
                    else
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
                case 5:
                    if (chuc == 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    else
                    {
                        KetQua += " lăm";
                    }
                    break;
                default:
                    if (donvi != 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
            }
            return KetQua;
        }
        #endregion

        public static VnsDoanCongTac GetDoanRaById(Guid _id, IList<VnsDoanCongTac> lstDoanRa)
        {
            foreach (VnsDoanCongTac obj in lstDoanRa)
            {
                if (obj.Id == _id)
                    return obj;
            }
            return null;
        }

        public static List<String> Spilit(string s, int number)
        {
            string s1 = "";
            string s2 = "";

            List<String> lst = new List<string>();
            string[] arr;
            arr = s.Split(' ');

            string s1tmp = "";

            foreach (string tmp in arr)
            {
                s1tmp += tmp + " ";
                if (s1tmp.Length <= number)
                {
                    s1 += tmp + " ";
                }
                else
                {
                    s2 += tmp + " ";
                }
            }

            lst.Add(s1); lst.Add(s2);
            return lst;
        }
    }

    public class GridHelper
    {
        public static bool CheckAddNewRow(GridView _GridView)
        {
            return CheckAddNewRow(_GridView, true);
        }

        public static bool CheckAddNewRow(GridView _GridView, bool _ShowConfirm)
        {
            if ((_GridView.IsLastRow))
            {
                int i = 0;
                for (int j = 0; j <= _GridView.Columns.Count - 1; j++)
                {
                    if (_GridView.Columns[j].Visible)
                        i = i + 1;
                }

                if (_GridView.GetVisibleColumn(i - 1).Visible)
                {
                    if (_GridView.FocusedColumn.VisibleIndex == i - 1)
                    {
                        if ((_ShowConfirm))
                        {
                            DialogResult dr = MessageBox.Show("Bạn có muốn thêm dòng mới không?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (dr == DialogResult.Yes)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }

            }
            return false;
        }

        public static void SetFocusAfterAddRow(GridView _grv)
        {
            _grv.FocusedRowHandle = _grv.RowCount - 1;
            _grv.FocusedColumn = _grv.GetVisibleColumn(0);
        }
    }

    public class Report
    {
        public static List<DevExpress.XtraReports.Parameters.Parameter> getParamValue(IList<Info> lstThamSoHt)
        {
            List<DevExpress.XtraReports.Parameters.Parameter> lst = new List<DevExpress.XtraReports.Parameters.Parameter>();
            DevExpress.XtraReports.Parameters.Parameter obj;//= new Parameter();

            foreach (Info objThamSo in lstThamSoHt)
            {
                obj = new DevExpress.XtraReports.Parameters.Parameter();
                obj.Name = objThamSo.Ma;
                obj.Value = objThamSo.GiaTri;
                lst.Add(obj);
            }

            return lst;
        }

        public static void SetParamValue(IList<Info> lstThamSoHt, ParameterCollection lstParamReport)
        {
            List<DevExpress.XtraReports.Parameters.Parameter> lst = getParamValue(lstThamSoHt);
            int paramCount = lstParamReport.Count;
            foreach (DevExpress.XtraReports.Parameters.Parameter item in lst)
            {
                for (int i = 0; i < paramCount; i++)
                {
                    if (item.Name.ToUpper() == lstParamReport[i].Name.ToUpper())
                    {
                        lstParamReport[i].Value = item.Value;
                        lstParamReport[i].Description = item.Description;
                        lstParamReport[i].Visible = false;
                    }
                }
            }
        }

    }

    public class ComboHelper
    {
        public static object GetSelectData(DevExpress.XtraEditors.GridLookUpEdit grlLoaiTSCD)
        {
            return grlLoaiTSCD.Properties.GetRowByKeyValue(grlLoaiTSCD.EditValue);
        }

        public static object GetSelectData(DevExpress.XtraEditors.LookUpEdit grlLoaiTSCD)
        {
            return grlLoaiTSCD.Properties.GetDataSourceRowByKeyValue(grlLoaiTSCD.EditValue);
        }

        public static object GetSelectData(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit, object svalue)
        {
            return repositoryItemLookUpEdit.GetDataSourceRowByKeyValue(svalue);
        }

        public static object GetSelectData(DevExpress.XtraGrid.Views.Grid.GridView rp)
        {
            return rp.GetRow(rp.FocusedRowHandle);
        }
    }

    public class VnsExport
    {
        private static string _CustomSort = "";

        public static string CustomSort
        {
            get { return _CustomSort; }
            set { _CustomSort = value; }
        }
        public Boolean ExportToExcel(System.Data.DataTable source, string fileName)
        {

            try
            {
                StreamWriter excelDoc;
                //Dim excelDoc As System.IO.StreamWriter
                // vbCr = "\r"
                //vbLf = "\n"
                //vbCrLf = "\r\n"

                excelDoc = new StreamWriter(fileName);
                String startExcelXML = "<xml version>" + '\r' + '\n' + "<Workbook " + "xmlns=" + "'urn:schemas-microsoft-com:office:spreadsheet'" + '\r' + '\n' + " xmlns:o=" + "'urn:schemas-microsoft-com:office:office'" + '\r' + '\n' + " " + "xmlns:x=" + "'urn:schemas-    microsoft-com:office:'" + "excel" + '\r' + '\n' + " xmlns:ss=" + "'urn:schemas-microsoft-com:'" + "office:spreadsheet>" + '\r' + '\n' + " <Styles>" + '\r' + '\n' + " " + "<Style ss:ID=" + "'Default'" + " ss:Name=" + "'Normal'" + ">" + '\r' + '\n' + " " + "<Alignment ss:Vertical=" + "'Bottom'" + "/>" + '\r' + '\n' + " <Borders/>" + '\r' + '\n' + " <Font/>" + '\r' + '\n' + " <Interior/>" + '\r' + '\n' + " <NumberFormat/>" + '\r' + '\n' + " <Protection/>" + '\r' + '\n' + " </Style>" + '\r' + '\n' + " " + "<Style ss:ID=" + "'BoldColumn'" + ">" + '\r' + '\n' + " <Font " + "x:Family=" + "'Swiss'" + " ss:Bold=" + "'1'" + "/>" + '\r' + '\n' + " </Style>" + '\r' + '\n' + " " + "<Style     ss:ID=" + "'StringLiteral'" + ">" + '\r' + '\n' + " <NumberFormat" + " ss:Format=" + "'@'" + "/>" + '\r' + '\n' + " </Style>" + '\r' + '\n' + " <Style " + "ss:ID=" + "'Decimal'" + ">" + '\r' + '\n' + " <NumberFormat " + "ss:Format=" + "'0.0000'" + "/>" + '\r' + '\n' + " </Style>" + '\r' + '\n' + " " + "<Style ss:ID=" + "'Integer'" + ">" + '\r' + '\n' + " <NumberFormat " + "ss:Format=" + "'0'" + "/>" + '\r' + '\n' + " </Style>" + '\r' + '\n' + " <Style " + "ss:ID=" + "'DateLiteral'" + ">" + '\r' + '\n' + " <NumberFormat " + "ss:Format=" + "'mm/dd/yyyy;@'" + "/>" + '\r' + '\n' + " </Style>" + '\r' + '\n' + " " + "</Styles>" + '\r' + '\n' + " ";
                //Const startExcelXML As String = "<xml version>" & vbCr & vbLf & "<Workbook " & "xmlns=""urn:schemas-microsoft-com:office:spreadsheet""" & vbCr & vbLf & " xmlns:o=""urn:schemas-microsoft-com:office:office""" & vbCr & vbLf & " " & "xmlns:x=""urn:schemas-    microsoft-com:office:" & "excel""" & vbCr & vbLf & " xmlns:ss=""urn:schemas-microsoft-com:" & "office:spreadsheet"">" & vbCr & vbLf & " <Styles>" & vbCr & vbLf & " " & "<Style ss:ID=""Default"" ss:Name=""Normal"">" & vbCr & vbLf & " " & "<Alignment ss:Vertical=""Bottom""/>" & vbCr & vbLf & " <Borders/>" & vbCr & vbLf & " <Font/>" & vbCr & vbLf & " <Interior/>" & vbCr & vbLf & " <NumberFormat/>" & vbCr & vbLf & " <Protection/>" & vbCr & vbLf & " </Style>" & vbCr & vbLf & " " & "<Style ss:ID=""BoldColumn"">" & vbCr & vbLf & " <Font " & "x:Family=""Swiss"" ss:Bold=""1""/>" & vbCr & vbLf & " </Style>" & vbCr & vbLf & " " & "<Style     ss:ID=""StringLiteral"">" & vbCr & vbLf & " <NumberFormat" & " ss:Format=""@""/>" & vbCr & vbLf & " </Style>" & vbCr & vbLf & " <Style " & "ss:ID=""Decimal"">" & vbCr & vbLf & " <NumberFormat " & "ss:Format=""0.0000""/>" & vbCr & vbLf & " </Style>" & vbCr & vbLf & " " & "<Style ss:ID=""Integer"">" & vbCr & vbLf & " <NumberFormat " & "ss:Format=""0""/>" & vbCr & vbLf & " </Style>" & vbCr & vbLf & " <Style " & "ss:ID=""DateLiteral"">" & vbCr & vbLf & " <NumberFormat " & "ss:Format=""mm/dd/yyyy;@""/>" & vbCr & vbLf & " </Style>" & vbCr & vbLf & " " & "</Styles>" & vbCr & vbLf & " "

                //Const endExcelXML As String = "</Workbook>"
                String endExcelXML = "</Workbook>";
                //Dim rowCount As Integer = 0
                int rowCount = 0;

                //Dim sheetCount As Integer = 1
                int sheetCount = 1;
                excelDoc.Write(startExcelXML);
                //excelDoc.Write("<Worksheet ss:Name=""Sheet" + sheetCount + """>");
                excelDoc.Write("<Worksheet ss:Name=Sheet" + sheetCount + ">");
                excelDoc.Write("<Table>");
                excelDoc.Write("<Row>");
                for (int x = 0; x < source.Columns.Count - 1; x++)
                {
                    if (source.Columns[x] != null)
                    {
                        excelDoc.Write("<Cell ss:StyleID=" + "'BoldColumn'" + "><Data ss:Type=" + "'String'" + ">");
                        excelDoc.Write(source.Columns[x].ColumnName);
                        excelDoc.Write("</Data></Cell>");
                    }
                }
                excelDoc.Write("</Row>");
                foreach (DataRow x in source.Rows)
                {
                    rowCount += 1;
                    if (rowCount == 64000)
                    {
                        rowCount = 0;
                        sheetCount += 1;
                        excelDoc.Write("</Table>");
                        excelDoc.Write(" </Worksheet>");
                        excelDoc.Write("<Worksheet ss:Name=" + "'Sheet'" + sheetCount.ToString() + ">");
                        excelDoc.Write("<Table>");
                    }
                    excelDoc.Write("<Row>");
                    for (int y = 0; y < source.Columns.Count - 1; y++)
                    {
                        //'If source.Columns(y).Visible Then
                        //Dim rowType As System.Type;
                        Type rowType;
                        rowType = x[y].GetType();

                        //Dim XMLstring As String = x(y).ToString()
                        String XMLstring = x[y].ToString();
                        XMLstring = XMLstring.Trim();
                        XMLstring = XMLstring.Replace("&", "&");
                        XMLstring = XMLstring.Replace(">", ">");
                        XMLstring = XMLstring.Replace("<", "<");
                        excelDoc.Write("<Cell ss:StyleID=" + "'StringLiteral'" + ">" + "<Data ss:Type=" + "'String'" + ">");
                        excelDoc.Write(XMLstring);

                        excelDoc.Write("</Data></Cell>");
                        //'End If
                    }
                    excelDoc.Write("</Row>");

                }
            }
            catch (Exception e)
            {
            }
            return true;
        }
        public Boolean PrintExcelFile(String Filename, IList<String> lstSheet)
        {

            bool bRet = true;
            //Dim xlApp As Excel.Application
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook =null;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet =null;
            Microsoft.Office.Interop.Excel.Worksheet xlTemplateSheet =null;
            Object misValue = System.Reflection.Missing.Value;
            xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();

            try
            {
                //'xlWorkBook = xlApp.Workbooks.Open(Filename)
                xlWorkBook = xlApp.Workbooks.Open(Filename);
                foreach (string tmpSheet in lstSheet)
                {
                    xlWorkSheet = (Worksheet)xlWorkBook.Sheets[tmpSheet]; // Sheets(tmpSheet);
                    xlWorkBook.PrintOut(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                return bRet;
            }
            catch
            {
                return false;
            }
            finally
            {
                //'xlWorkBook.Save()
                xlWorkBook.Close();
                xlApp.Quit();

                releaseObject(xlApp);
                releaseObject(xlWorkBook);
                if (xlWorkSheet != null)
                {
                    releaseObject(xlWorkSheet);
                }
                //If Not (xlWorkSheet Is Nothing) Then
                //    releaseObject(xlWorkSheet)
                //End If
                if (xlTemplateSheet != null)
                {
                    releaseObject(xlTemplateSheet);
                }
                //If Not (xlTemplateSheet Is Nothing) Then
                //    releaseObject(xlTemplateSheet)
                //End If
            }
        }
        private static void releaseObject(Object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        private static void FormatCell(Microsoft.Office.Interop.Excel.Range ExcelRang, int FormatValue)
        {
            string tmp;
            if (ExcelRang.Value != null)
            {
                tmp = ExcelRang.Value.ToString();
            }
            else
                tmp = "";


            if (tmp == "NOT_FORMAT")
            {
                ExcelRang.Value = "";
                return;
            }

            switch (FormatValue)
            {
                case 1:
                    break;
                case 3:
                    ExcelRang.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble;
                    ExcelRang.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;
                    ExcelRang.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble;
                    ExcelRang.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;
                    break;
                case 2:
                    ExcelRang.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    ExcelRang.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                    ExcelRang.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    ExcelRang.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium;
                    break;
            }
        }
        public static bool ExportToExcelWithInterop(string Filename, string templateFile, DataSet ds, string templateSheet, List<VnsDoanRaParameter> lstParameter, int StartRow, int StartCol, string DisplayCol, bool PrintAfterExport)
        {

            bool HasDisplay = string.IsNullOrEmpty(DisplayCol);
            if (string.IsNullOrEmpty(DisplayCol))
            {
                DisplayCol = "";
            }
            string[] arrCol = DisplayCol.Split(';');
            System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Microsoft.Office.Interop.Excel.Application xlApp;//= new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook =null;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = null;
            Microsoft.Office.Interop.Excel.Worksheet xlTemplateSheet = null;
            Object misValue = System.Reflection.Missing.Value;
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlApp.DisplayAlerts = false;
            xlApp.UserControl = true;
            xlApp.Visible = true;


            try
            {
                //'xlWorkBook = xlApp.Workbooks.Open(Filename)
                xlWorkBook = xlApp.Workbooks.Open(templateFile);
                if (lstParameter == null)
                {
                    lstParameter = new List<VnsDoanRaParameter>();
                }
                if (string.IsNullOrEmpty(templateSheet))
                {
                    xlWorkSheet = (Worksheet)xlWorkBook.Sheets[ds.Tables[0].TableName];
                }

                else
                {
                    xlTemplateSheet = (Worksheet)xlWorkBook.Sheets[templateSheet];
                }
                foreach (System.Data.DataTable table in ds.Tables)
                {
                    if (string.IsNullOrEmpty(templateSheet))
                    {

                    }
                    else
                    {
                        xlTemplateSheet.Copy(xlWorkBook.Sheets[1], misValue);
                        xlWorkSheet = (Worksheet)xlWorkBook.Sheets[1];
                        string a = table.TableName;
                        xlWorkSheet.Name = table.TableName;
                    }
                    if (!string.IsNullOrEmpty(_CustomSort))
                    {
                        table.DefaultView.Sort = _CustomSort;
                    }
                    xlWorkSheet.Activate();
                    //xlWorkSheet = (Worksheet)xlWorkBook.ActiveSheet;
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        //'Dim insertPos As Excel.Range = xlWorkSheet.Cells(i + StartRow + 2, 1).EntireRow

                        bool HasFormat = table.Columns.Contains("vlFormat");
                        if (i < table.Rows.Count - 1)
                        {
                            //xlWorkSheet.Rows[i + StartRow].Copy();
                            Microsoft.Office.Interop.Excel.Range r = (Range)xlWorkSheet.Rows[i + StartRow];
                            r.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown, r);
                        }
                        Microsoft.Office.Interop.Excel.Range chartRange;
                        // insert copied rows
                        if (!HasDisplay)
                        {
                            for (int j = 0; j < arrCol.Length; j++)
                            {
                                if (string.IsNullOrEmpty(arrCol[j]))
                                {
                                    continue;
                                }
                                xlWorkSheet.Cells[i + StartRow, j + StartCol] = table.Rows[i][arrCol[j]].ToString(); //table.DefaultView.Item[i][arrCol[j]].ToString();
                                if (HasFormat)
                                {
                                    chartRange = (Range)xlWorkSheet.Cells[i + StartRow, j + StartCol];
                                    FormatCell(chartRange, Int32.Parse(table.Rows[i]["vlFormat"].ToString()));
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < table.Columns.Count; j++)
                            {
                                xlWorkSheet.Cells[i + StartRow, j + StartCol] = table.Rows[i][j].ToString();
                            }
                        }
                    }
                    foreach (VnsDoanRaParameter excelparameter in lstParameter)
                    {
                        if(excelparameter.SheetName == table.TableName)
                        {
                            xlWorkSheet.Cells[excelparameter.ERow, excelparameter.ECol] = excelparameter.Value;
                        }
                    }
                    Microsoft.Office.Interop.Excel.Range rg;
                    rg = (Range) xlWorkSheet.Cells[1, 1];
                    rg.Select();
                }
                 if( ! string.IsNullOrEmpty(templateSheet) && (ds.Tables.Count > 0))
                 {
                    releaseObject(xlTemplateSheet);
                    
                    xlTemplateSheet = (Worksheet) xlWorkBook.Worksheets[templateSheet];
                    xlTemplateSheet.Delete();                    
                    releaseObject(xlTemplateSheet);
                 }

                string typefile   = GetExtendFile(Filename);
                switch (typefile.ToUpper())
                {
                    case "XLS":
                        xlWorkBook.SaveAs(Filename, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        break;
                    case "XLSX":
                        xlWorkBook.SaveAs(Filename, Microsoft.Office.Interop.Excel.XlFileFormat.xlTemplate);
                        break;
                }
            }   
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                // 'xlWorkBook.Save()
                if (xlWorkBook != null)
                {
                    xlWorkBook.Close();                 
                    releaseObject(xlWorkBook);
                }
                if (xlApp != null)
                {
                    xlApp.Quit();
                    releaseObject(xlApp);
                }
                if (xlWorkSheet != null)
                    releaseObject(xlWorkSheet);
                if (xlTemplateSheet != null)
                    releaseObject(xlTemplateSheet);
            }
            return true;
        }
        public static string  GetExtendFile(string filename)
         {
            string[] tmp   = filename.Split('.');
            if (tmp.Length > 0)
                return tmp[tmp.Length - 1];
            else
                return "";
         }
    }

    public class VnsDoanRaParameter
    {
        private String _Value;

        public String Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        private String _SheetName;

        public String SheetName
        {
            get { return _SheetName; }
            set { _SheetName = value; }
        }
        private int _ERow;

        public int ERow
        {
            get { return _ERow; }
            set { _ERow = value; }
        }
        private int _ECol;

        public int ECol
        {
            get { return _ECol; }
            set { _ECol = value; }
        }
        public VnsDoanRaParameter()
        {
            _Value = "";
            _SheetName = "";
            _ERow = 0;
            _ECol = 0;
        }

        public VnsDoanRaParameter(String _value1, String _sheetname1, int _erow1, int _ecol1)
        {
            _Value = _value1;
            _SheetName = _sheetname1;
            _ERow = _erow1;
            _ECol = _ecol1;
        }
    }
}

