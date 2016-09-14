using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Vns.QuanLyDoanRa.Domain.Report;
using Vns.QuanLyDoanRa.Domain;
using Vns.QuanLyDoanRa.Service;
using System.Data;
using Vns.QuanLyDoanRa.Service.Interface.Report;
using Vns.QuanLyDoanRa.Service.Interface;
using Vns.Erp.Core;
namespace QuanLyDoanRa.Reports
{
    public partial class BangKeQuyetToanTong : DevExpress.XtraReports.UI.XtraReport
    {
        public IRP_BC04DRService RP_BC04DRService;
        public IVnsDoanCongTacService VnsDoanCongTacService;
        DataTable dt;
        public BangKeQuyetToanTong()
        {
            InitializeComponent();
        }

      
        public DataTable GetData(DataTable data)//DateTime p_TuNgay, DateTime p_DenNgay, String p_TkCo, String p_TkNo, string p_TrangThaiCt, string TenCt, string p_Time, int GiaTri)
        {
           // InitializeComponent();


            //RP_BC04DRService = (IRP_BC04DRService)ObjectFactory.GetObject("RP_BC04DRService");
            //VnsDoanCongTacService = (IVnsDoanCongTacService)ObjectFactory.GetObject("VnsDoanCongTacService");
            //List<RP_SoDuTaiKhoan> lstSoDuTk;
            //if (GiaTri == 2)
            //{
            //    lstSoDuTk = RP_BC04DRService.GetSoDuTaiKhoan(p_TuNgay, p_DenNgay, p_TkCo, p_TkNo, p_TrangThaiCt);
            //}
            //else
            //{
            //    lstSoDuTk = RP_BC04DRService.GetBangKeQuyetToan(p_TuNgay, p_DenNgay, p_TkCo, p_TkNo, p_TrangThaiCt);
            //}

            //List<RP_BangKeCtGhiSo> lstBangKe = new List<RP_BangKeCtGhiSo>();
            //RP_BangKeCtGhiSo objBangke;
            //foreach (RP_SoDuTaiKhoan objSoDu in lstSoDuTk)
            //{
            //    objBangke = new RP_BangKeCtGhiSo();
            //    if (objSoDu.DoanRaId != new Guid())
            //    {
            //        VnsDoanCongTac objDct = new VnsDoanCongTac();
            //        objDct = VnsDoanCongTacService.GetById(objSoDu.DoanRaId);
            //        if (objDct != null)
            //        {
            //            objSoDu.TenDoanRa = objDct.Ten;
            //            objSoDu.TenLoaiDoanRa = objDct.TenLoaiDoanRa;
            //        }
            //    }
            //    objBangke = objBangke.GetData(objSoDu, GiaTri);
            //    lstBangKe.Add(objBangke);
            //}

            //dt = Commons.Commons.ToDataTable<RP_BangKeCtGhiSo>(lstBangKe);
            return data;
        }

    }
}
