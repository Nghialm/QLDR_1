/*
insert license info here
*/
using System.Collections;
using System.ComponentModel;
using System.Data;
using System;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Dao;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.Erp.Core.Service;
using Vns.Erp.Core.Service.Interface;
using Spring.Transaction.Interceptor;
using System.Collections.Generic;
using Vns.Erp.Core.Admin.Dao;
using Vns.QuanLyDoanRa.Dao.NHibernate;
namespace Vns.QuanLyDoanRa.Service
{
    /// <summary>
    ///	Generated by MyGeneration using the NHibernate Object Mapping adapted by Gustavo
    /// </summary>	
    //,IVnsLoaiChungTuService
    public class VnsLoaiChungTuService : GenericService<VnsLoaiChungTu, Guid>, IVnsLoaiChungTuService
    {
        public IVnsLoaiChungTuDao VnsLoaiChungTuDao
        {
            get { return (IVnsLoaiChungTuDao)Dao; }
            set { Dao = value; }
        }
        public IVnsHtSoCtMaxDao VnsHtSoCtMaxDao;
        
        public VnsLoaiChungTu GetByMa(String MaLoaiChungTu)
        {
            return VnsLoaiChungTuDao.GetByMa(MaLoaiChungTu);
        }

        [Transaction]
        public List<string> GetSoCT_prefix(Guid LOAICHUNGTU_ID, int THANG, int NAM)
        {
            List<string> lst_str = new List<string>();
            string Prefix = "";
            string So_CT = "";
            decimal m_SoCT_old = VnsHtSoCtMaxDao.GetByNamEtc(LOAICHUNGTU_ID,THANG, NAM).SoChungtuMax;
            VnsLoaiChungTu obj = Get(LOAICHUNGTU_ID);
            string m_prefix_old;
            if (obj == null)
                m_prefix_old = "";
            else
            {
                m_prefix_old = obj.MauSoCt;                
            }

            Prefix = GetPrefix(m_prefix_old, NAM, THANG);

            So_CT = GetSoCT(m_SoCT_old, 3);
            lst_str.Add(Prefix);
            lst_str.Add(So_CT);
            return lst_str;
        }

        private string GetPrefix(string p_prefix, decimal p_Nam, decimal p_Thang)
        {
            string m_Prefix = "";

            string p_thang_temp = "";
            if (p_Thang < 10)
            {
                p_thang_temp = "0" + p_Thang.ToString();
            }
            else
            {
                p_thang_temp = p_Thang.ToString();
            }

            switch (p_prefix)
            {
                case "[YYMM]":
                    m_Prefix = p_Nam.ToString().Substring(2, 2) + p_thang_temp;
                    break;
                case "[YYYYMM]":
                    m_Prefix = p_Nam.ToString() + p_thang_temp;
                    break;
                case "[YYYYMM-]":
                    m_Prefix = p_Nam.ToString() + p_thang_temp + "-";
                    break;
                case "[YYYY/MM]":
                    m_Prefix = p_Nam.ToString() + "/" + p_thang_temp;
                    break;
                case "[YYYY/MM-]":
                    m_Prefix = p_Nam.ToString() + "/" + p_thang_temp + "-";
                    break;
                case "[MM/YYYY-]":
                    m_Prefix = p_thang_temp + "/" + p_Nam.ToString() + "-";
                    break;
                default:
                    m_Prefix = p_prefix;
                    break;
            }

            return m_Prefix;
        }

        private string GetSoCT(decimal p_old, decimal So_kt)
        {
            string m_SoCT = "";

            if (p_old.ToString().Length >= So_kt)
            {
                m_SoCT = p_old.ToString();
            }
            else
            {
                decimal perleng = So_kt - p_old.ToString().Length;
                m_SoCT = str(So_kt).Substring(0, Convert.ToInt32(perleng)) + p_old.ToString();
            }

            return m_SoCT;
        }

        private string str(decimal kt)
        {
            string r_str = "";
            for (int i = 1; i <= kt; i++)
            {
                r_str = r_str + "0";
            }
            return r_str;
        }

        public IList<VnsLoaiChungTu> GetByGroup(string MaDmCha)
        {
            return VnsLoaiChungTuDao.GetByGroup(MaDmCha);
        }

    }
}
