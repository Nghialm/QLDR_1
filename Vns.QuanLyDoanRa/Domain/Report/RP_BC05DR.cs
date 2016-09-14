using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
    public class RP_BC05DR
    {
        public virtual Guid LoaiDoanRaId { get; set; }
        public virtual String TenLoaiDoanRa { get; set; }
        public virtual String NoiDung { get; set; }
        public virtual decimal PT_KT_VND { get; set; }//Phai thu kì trước
        public virtual decimal PT_KT_USD { get; set; }
        
        public virtual decimal TU_Chua_QT_KT_VND { get; set; }//So tam ung chua quyet toan ky truoc
        public virtual decimal TU_Chua_QT_KT_USD { get; set; }

        public virtual decimal THU_CL_VND { get; set; }//Thu chenh lech
        public virtual decimal THU_CL_USD { get; set; }
        public virtual decimal TU_VND { get; set; }//Tam ung
        public virtual decimal TU_USD { get; set; }
        public virtual decimal CHI_QT_VND { get; set; }//Chi qt
        public virtual decimal CHI_QT_USD { get; set; }
        public virtual decimal QT_TrongThang_VND { get; set; }//Qt trong thang
        public virtual decimal QT_TrongThang_USD { get; set; }
        public virtual decimal PT_TK_VND { get; set; }//Phai thu trong ky
        public virtual decimal PT_TK_USD { get; set; }
        public virtual decimal TU_Chua_QT_VND { get; set; }//Tam ung chua qt
        public virtual decimal TU_Chua_QT_USD { get; set; }
        public virtual int GroupByTime { get; set; }

        //pGroupByTime = 1 thang truoc
        //pGroupByTime = 2 thang nay
        public RP_BC05DR(VnsReportTongHop obj, string pNoidung, int pGroupByTime)
        {
            LoaiDoanRaId = obj.LoaiDoanRaId;
            TenLoaiDoanRa = obj.TenLoaiDoanRa;
            NoiDung = pNoidung;
            GroupByTime = pGroupByTime;

            if (pGroupByTime == 1)
            {
                PT_KT_VND = obj.CN_QT_PhaiThu_VND; //CN_PhaiThu_VND;
                PT_KT_USD = obj.CN_QT_PhaiThu_USD;
                THU_CL_USD = obj.TH_TONG_USD;
                THU_CL_VND = obj.TH_TONG_VND;

                TU_USD = 0;
                TU_VND = 0;
                CHI_QT_USD = 0;
                CHI_QT_VND = 0;
                QT_TrongThang_USD = 0;
                QT_TrongThang_VND = 0;
                PT_TK_VND=0;
                PT_TK_USD =0;
            }
            else
            {
                PT_KT_VND = 0;
                PT_KT_USD = 0;
                THU_CL_USD = 0;
                THU_CL_VND = 0;

                //TU_USD = obj.TU_CK_USD_MR + obj.TU_TM_USD_MR;
                //TU_VND = obj.TU_CK_VND_MR + obj.TU_TM_VND_MR;

                CHI_QT_USD = obj.Chi_QT_CK_USD + obj.Chi_QT_TM_USD;
                CHI_QT_VND = obj.Chi_QT_CK_VND + obj.Chi_QT_TM_VND;
                QT_TrongThang_USD = obj.So_QT_USD_Tong; //obj.TienQt;//
                QT_TrongThang_VND = obj.So_QT_VND_Tong;
                PT_TK_VND = obj.CN_QT_PhaiThu_VND;
                PT_TK_USD = obj.CN_QT_PhaiThu_USD;
            }
        }

        public RP_BC05DR(VnsReportChuaQt obj, string pNoidung, int pGroupByTime)
        {
            LoaiDoanRaId = obj.LoaiDoanRaId;
            NoiDung = pNoidung;
            GroupByTime = pGroupByTime;
            PT_KT_VND = 0;
            PT_KT_USD = 0;
            THU_CL_USD = 0;
            THU_CL_VND = 0;

            TU_USD = 0;
            TU_VND = 0;
            CHI_QT_USD = 0;
            CHI_QT_VND = 0;
            QT_TrongThang_USD = 0;
            QT_TrongThang_VND = 0;
            PT_TK_VND = 0;
            PT_TK_USD = 0;
            TU_Chua_QT_VND = obj.TongVND;
            TU_Chua_QT_USD = obj.TongUSD;
        }

        public RP_BC05DR()
        { 
            
        }
    }
}
