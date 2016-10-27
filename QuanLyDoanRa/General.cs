using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.QuanLyDoanRa.Domain;
using System.Xml;
using Vns.Erp.Core;
using System.Windows.Forms;

namespace QuanLyDoanRa
{
    public class General
    {
        public static int NamKeToan = 2013;
        static public int NumberOfPage = 50;
        static public string FileDataBase = string.Format("{0}\\{1}", Application.StartupPath, "App_Data\\QuanLyDoanRa.db");
        static public string CurrReport = string.Format("{0}\\{1}", Application.StartupPath, "Reports\\");

        public static string ChucDanhNguoiLapBieu = "";
        public static string TenNguoiLapBieu = "";
        public static string ChucDanhKeToanTruong = "";
        public static string TenKeToanTruong = "";
        public static string ChucDanhNguoiKyBangBieu = "";
        public static string TenNguoiKyBangBieu = "";
        public static string TheoCongVan = "";
        public static string NgayCanCu = "";
        public static DateTime NgayIn;
        public static string SoCanCuHoSo = "";
        public static string SoThongBaoDuToan = "";
        public static string SoThongBaoQuyetToan = "";
        public static string NguoiPheDuyetDuToan = "";
        public static string NguoiPheDuyetQuyetToan = "";
        public static string ChucDanhDuyetDuToan = "";
        public static string ChucDanhDuyetQuyetToan = ""; 
        public static IList<Info> lstThamSo = new List<Info>();

        

        public static string GenSignDate(DateTime pdate)
        {
            pdate = pdate.AddMonths(1);
            DateTime signdate = new DateTime(pdate.Year, pdate.Month, 3);

            return String.Format("Hà Nội, ngày {0} tháng {1} năm {2}",
                signdate.ToString("dd"), signdate.ToString("MM"), signdate.ToString("yyyy"));
        }

        public static string GenSignDate_EndMonth(DateTime pdate)
        {
            //pdate = pdate;
            DateTime signdate = new DateTime(pdate.Year, pdate.Month, 1);
            signdate = signdate.AddMonths(1).AddDays(-1);

            return String.Format("Hà Nội, ngày {0} tháng {1} năm {2}",
                signdate.ToString("dd"), signdate.ToString("MM"), signdate.ToString("yyyy"));
        }
    }

    public class GetXmlInfo
    {

        public static int GetNamKeToan()
        {
            XmlDocument doc = XMLConfig.XmlReader("KTConfig.xml");
            XmlElement root = doc.DocumentElement;
            XmlNode serverNode = root.SelectSingleNode("nam_ke_toan_info");
            string nam_kt = serverNode.SelectSingleNode("nam_kt").InnerText;
            int namketoan = 0;
            if (nam_kt.Equals(""))
            {
                namketoan = DateTime.Now.Year;
            }
            else
            {
                try
                {
                    namketoan = int.Parse(nam_kt);
                }
                catch
                {
                    namketoan = DateTime.Now.Year;
                }

            }
            return namketoan;
        }


        public static List<string> GetServerInfo()
        {
            List<string> lstResult = new List<string>();
            XmlDocument doc = XMLConfig.XmlReader("KTConfig.xml");
            XmlElement root = doc.DocumentElement;
            XmlNode serverNode = root.SelectSingleNode("server_info");
            string server_name = serverNode.SelectSingleNode("server_name").InnerText;
            string strDataBase = serverNode.SelectSingleNode("server_database").InnerText;
            string str_user = serverNode.SelectSingleNode("data_user").InnerText;
            string server_pass = serverNode.SelectSingleNode("server_pass").InnerText;
            
            lstResult.Insert(0, server_name);
            lstResult.Insert(1, strDataBase);
            lstResult.Insert(2, str_user);
            lstResult.Insert(3, server_pass);
            
            return lstResult;
        }
        public static void WriteInfo(string nam_ke_toan)
        {
            try
            {
                //Get Document
                XmlDocument doc = XMLConfig.XmlReader("KTConfig.xml");
                //Get Root Element
                XmlElement root = doc.DocumentElement;
                //Get element named "database_info", that include info about server setting
                XmlNode serverNode = root.SelectSingleNode("nam_ke_toan_info");
                //Write to file
                serverNode.SelectSingleNode("nam_kt").InnerText = nam_ke_toan;

                //Save info
                doc.Save("KTConfig.xml");

                //Add Lock
                //AddLock()
            }
            catch
            {
            }
        }
    }


    public enum FormUpdate
    {
        Insert, Update, Edit, Delete, View
    }
}
