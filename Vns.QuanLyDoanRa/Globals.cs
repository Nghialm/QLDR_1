//Test Github
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vns.Erp.Core;
using System.Globalization;
using System.Threading;

namespace Vns.QuanLyDoanRa
{
    public class Globals
    {
        public static Guid NoiTeId = new Guid();
        public static Guid NgoaiTeId = new Guid();

        public string DisplayTk(string s)
        {
            if (s == TkTienMat) return "111";
            if (s == TkTienChuyenKhoan) return "112";
            if (s == TkTamUng) return "312";

            return "";
        }

        /// <summary>
        /// Tien mat VND - 111.1
        /// </summary>
        public static string TkTienMatVND = "111.1";

        /// <summary>
        /// Tai khoan 111.2 Tien mat Ngoai te
        /// </summary>
        public static string TkTienMat = "111.2"; //"1121";
        public static string TkTienMat_Rp = "111";

        /// <summary>
        /// Tien chuyen khoan VND - 112.1
        /// </summary>
        public static string TkTienChuyenKhoanVND = "112.1";

        /// <summary>
        /// Tai khoan 1122
        /// </summary>
        public static string TkTienChuyenKhoan = "112.2";
        public static string TkTienChuyenKhoan_Rp = "112";

        /// <summary>
        /// Tai khoan 141
        /// </summary>
        public static string TkTamUng = "312";// "141";
        public static string TkTamUng_Rp = "312";

        /// <summary>
        /// Tai khoan 331
        /// </summary>
        public static string TkThanhToanNguoiBan = "331"; 

        /// <summary>
        /// Tai khoan 461
        /// </summary>
        public static string TkThuNganSach = "461";

        /// <summary>
        /// Tai khaon 3311
        /// </summary>
        public static string TkThanhToanTienMat = "3311";
        public static string TkThanhToanTienMat_Rp = "3121";

        /// <summary>
        /// Tai khoan 3312
        /// </summary>
        public static string TkThanhToanChuyenKhoan = "3312";
        public static string TkThanhToanChuyenKhoan_Rp = "3122";

        /// <summary>
        /// Tai khoan 11
        /// </summary>
        public static string TkTienLike = "11";

        /// <summary>
        /// Tai khoan 11
        /// </summary>
        public static string LikeTkTienMat = "11";


        /// <summary>
        /// Tai khaon 33
        /// </summary>
        public static string LikeTkQt = "33";

        /// <summary>
        /// 1121;1122;661
        /// </summary>
        public static string TkNghieVuNhanTienBtc = "111.2;112.2;661"; //"1121;1122;661";

        /// <summary>
        /// 1121;1122
        /// </summary>
        public static string TkNghiepVuTienMatvaChuyenKhoan = "111.2;112.2";//"1121;1122";

        /// <summary>
        /// 661
        /// </summary>
        public static string TkNghiepVuChiHoatDong = "661";

        public static string CacBanDang = "1";
        public static string DeAn = "2";
    }

    public class CultureHelper
    {
        public static void SetCulture2()
        {
            CultureManagement objData = new CultureManagement();
            CultureSettingInfo info = objData.GetInfo_2();
            CultureInfo culInfo = new CultureInfo(info.Code);
            culInfo.DateTimeFormat.ShortDatePattern = info.DateFormat;
            culInfo.DateTimeFormat.ShortTimePattern = info.TimeFormat;
            culInfo.DateTimeFormat.DateSeparator = info.DateSeparator;
            culInfo.DateTimeFormat.TimeSeparator = info.TimeSeparator;
            culInfo.NumberFormat.NumberDecimalSeparator = info.DecimalSeparator;
            if (info.GroupSeparator.Equals("space"))
            {
                culInfo.NumberFormat.NumberGroupSeparator = " ";
            }
            else
            {
                culInfo.NumberFormat.NumberGroupSeparator = info.GroupSeparator;
            }
            Thread.CurrentThread.CurrentCulture = culInfo;
        }
    }

    public enum ReportType
    {
        RP01,
        RP02, 
        RP03,
        RP04,
        RP05,
        RP06
    }
    
}
