using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;

//*********************************************************************
//
// Null Class
//
// Class for dealing with the translation of database null values. 
//
//*********************************************************************

public class Null
{
	public static short NullShort {
		get { return short.MinValue; }
	}
	public static int NullInteger {
		get { return int.MinValue; }
	}

	public static long NullLong {
		get { return long.MinValue; }
	}

	public static float NullSingle {
		get { return float.MinValue; }
	}
	public static double NullDouble {
		get { return double.MinValue; }
	}
	public static decimal NullDecimal {
		get { return decimal.MinValue; }
	}
	public static System.DateTime NullDate {
		get { return new DateTime(1900,1,1); }
	}
    public static System.DateTime MaxDate
    {
        get { return DateTime.MaxValue; }
    }
	public static string NullString {
		get { return ""; }
	}
	public static bool NullBoolean {
		get { return false; }
	}
	public static Guid NullGuid {
		get { return Guid.Empty; }
	}
	public static string NullGuidString {
		get { return "00000000000000000000000000000000"; }
	}


}

public class LimitValue
{
	public const decimal VNDcurrency = 999999999999999999L;
	public const decimal Fcurrency = 99999999999999L;
	public const decimal quantity = 99999999999999L;

	public const decimal TyGia = 9999999999L;
	/// <summary>
	/// Kiem tra gia tri ty gia ngoai te trong khoang hop le
	/// </summary>
	/// <param name="number"></param>
	/// <returns></returns>
	/// <remarks></remarks>
	public static bool CheckTyGia(decimal number)
	{
		if ((number > TyGia) | (number <= 0)) {
			return false;
		}
		return true;
	}

	/// <summary>
	/// Kiem tra gia tri khong am va trong khoan hop le
	/// </summary>
	/// <param name="number"></param>
	/// <returns></returns>
	/// <remarks></remarks>
	public static bool CheckCurrency(decimal number)
	{
		if ((number > VNDcurrency) | (number <= 0)) {
			return false;
		}
		return true;
	}

	/// <summary>
	/// Kiem tra tien VND trong khoang hop le
	/// </summary>
	/// <param name="number"></param>
	/// <returns></returns>
	/// <remarks></remarks>
	public static bool CheckVNDCurrency(decimal number)
	{
		if ((number > VNDcurrency) | (number < 0)) {
			return false;
		}
		return true;
	}

	/// <summary>
	/// Kiem tra tien Ngoai trong khoang hop le
	/// </summary>
	/// <param name="number"></param>
	/// <returns></returns>
	/// <remarks></remarks>
	public static bool CheckFCurrency(decimal number)
	{
		if ((number > Fcurrency) | (number < 0)) {
			return false;
		}
		return true;
	}

	/// <summary>
	/// Kiem tra tien Ngoai trong khoang hop le
	/// </summary>
	/// <param name="number"></param>
	/// <returns></returns>
	/// <remarks></remarks>
	public static bool CheckQuantity(decimal number)
	{
		if ((number > quantity) | (number < 0)) {
			return false;
		}
		return true;
	}
	/// <summary>
	/// Kiem tra ty le thue trong khoang hop le
	/// </summary>
	/// <param name="number"></param>
	/// <returns></returns>
	/// <remarks></remarks>
	public static bool CheckTaxRate(decimal number)
	{
		if ((number >= 1000) | (number < 0)) {
			return false;
		}
		return true;
	}

	/// <summary>
	/// Kiem tra do dai truong ki tu co qua 256 khong
	/// </summary>
	/// <param name="Text"></param>
	/// <returns></returns>
	/// <remarks></remarks>
	public static bool CheckLengthString(string Text)
	{
		if (Text.Length >= 256) {
			return false;
		}
		return true;
	}
}

public class VnsConvert
{
	public static Guid CGuid(string svalue)
	{
		if (string.IsNullOrEmpty(svalue)) {
			return Null.NullGuid;
		} else {
			return new Guid(svalue);
		}
	}

	public static Guid CGuid(object svalue)
	{
		if (svalue == null) {
			return Null.NullGuid;
		} else {
			string s = svalue.ToString();
			if (string.IsNullOrEmpty(s)) {
				return Null.NullGuid;
			}

			try {
				return new Guid(svalue.ToString());
			} catch (Exception ex) {
				return Null.NullGuid;
			}
		}
	}

	public static decimal CDecimal(string svalue)
	{
		if ((string.IsNullOrEmpty(svalue))) {
			return 0;
		} else {
			return decimal.Parse(svalue);
		}
	}

	public static decimal CDecimal(bool bvalue)
	{
		if (!bvalue) {
			return 0;
		} else {
			return 1;
		}
	}

	public static bool CBoolean(decimal value)
	{
		if (value != 0) {
			return true;
		} else {
			return false;
		}
	}

	public static System.DateTime CStartOfDate(System.DateTime value)
	{
		System.DateTime dt = new System.DateTime(value.Year, value.Month, value.Day, 0, 0, 0, 0);
		return dt;
	}

	public static System.DateTime CEndOfDate(System.DateTime value)
	{
		System.DateTime dt = new System.DateTime(value.Year, value.Month, value.Day, 23, 59, 59, 999);
		return dt;
	}
}

public class VnsCheck
{
	public static bool IsNullGuid(Guid svalue)
	{
        if (svalue == null) return true;

		if (svalue == Null.NullGuid) {
			return true;
		} else {
			return false;
		}
	}

	public static bool IsNullGuid(string svalue)
	{
		Guid guidvalue = VnsConvert.CGuid(svalue);
		if (guidvalue == Null.NullGuid) {
			return true;
		} else {
			return false;
		}
	}

	public static bool IsNullGuid(object svalue)
	{
		Guid guidvalue = VnsConvert.CGuid(svalue);
		if (guidvalue == Null.NullGuid) {
			return true;
		} else {
			return false;
		}
	}

	public static bool IsNullDate(DateTime tmpDate)
	{
		if (tmpDate == System.DateTime.MinValue | tmpDate == System.DateTime.MaxValue) {
			return true;
		} else {
			return false;
		}
	}

}