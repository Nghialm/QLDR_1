using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
    public class RP_BC06DR
    {
        private String _SoTbDuToan = String.Empty;
        public String SoTbDuToan
        {
            get { return _SoTbDuToan; }
            set { _SoTbDuToan = value; }
        }
        private String _SoTbQuyetToan = String.Empty;

        public String SoTbQuyetToan
        {
            get { return _SoTbQuyetToan; }
            set { _SoTbQuyetToan = value; }
        }

        private Guid _LoaiDoanRaId;

        public Guid LoaiDoanRaId
        {
            get { return _LoaiDoanRaId; }
            set { _LoaiDoanRaId = value; }
        }
        private Guid _DoanRaId;

        public Guid DoanRaId
        {
            get { return _DoanRaId; }
            set { _DoanRaId = value; }
        }
        private String _TenLoaiDoanRa;

        public String TenLoaiDoanRa
        {
            get { return _TenLoaiDoanRa; }
            set { _TenLoaiDoanRa = value; }
        }
        private String _TenDoanRa;

        public String TenDoanRa
        {
            get { return _TenDoanRa; }
            set { _TenDoanRa = value; }
        }
        private decimal _USD;

        public decimal USD
        {
            get { return _USD; }
            set { _USD = value; }
        }
        private decimal _TG;

        public decimal TG
        {
            get { return _TG; }
            set { _TG = value; }
        }
        private decimal _VND;

        public decimal VND
        {
            get { return _VND; }
            set { _VND = value; }
        }

        private decimal _Tong;

        public decimal Tong
        {
            get { return _Tong; }
            set { _Tong = value; }
        }

        private String _NguoiTamUng;

        public String NguoiTamUng
        {
            get { return _NguoiTamUng; }
            set { _NguoiTamUng = value; }
        }
        private int _GroupByTime;

        public int GroupByTime
        {
            get { return _GroupByTime; }
            set { _GroupByTime = value; }
        }
        private String _Note;

        public String Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        private int _STT;

        public int STT
        {
            get { return _STT; }
            set { _STT = value; }
        }

        public RP_BC06DR()
        {
        }

        //Type = 1: thu hoan tam ung
        //Type = 2: Chi quyet toan
        public RP_BC06DR(VnsReportTongHop obj, string p_Note, int group, int type)
        {
            _LoaiDoanRaId = obj.LoaiDoanRaId;
            _DoanRaId = obj.DoanRaId;
            _TenLoaiDoanRa = obj.TenLoaiDoanRa;
            _TenDoanRa = string.Format("{0} - đ/c {1} - đi {2} - QT {3}", obj.TenDoanRa, obj.TruongDoan, obj.NuocCongTac, obj.ThangDuyetQt.ToString("MM/yyyy"));
            _Note = p_Note;
            _GroupByTime = group;
            _STT = 1;

            if (type == 1)
            {
                _USD = obj.CN_PhaiThu_USD;
                _VND = obj.CN_PhaiThu_VND;
                _TG = obj.CN_PhaiThu_TG;
            }
            else
            {

                _USD = obj.CN_PhaiTra_TM_USD;
                _VND = obj.CN_PhaiTra_CK_VND;
                _Tong = obj.CN_PhaiTra_USD;
                _TG = obj.CN_PhaiTra_TG;
            }
        }

        public RP_BC06DR(VnsReportTongHop objrp, Guid loaidoanra, Guid doanraid, string tenloaidoanra, string tendoanra,
            string truongdoan, string nuoccongtac, DateTime thangduyetqt,
            decimal cnphaithuusd, decimal cnphaithuvnd, decimal cnphaithutg,
            decimal cnphaitrausd_TM, decimal cnphaitrausd_CK, decimal cnphaitratong,
            string p_Note, int group, int type)
        {
            _LoaiDoanRaId = loaidoanra;
            _DoanRaId = doanraid;
            _TenLoaiDoanRa = tenloaidoanra;
            _TenDoanRa = string.Format("{0} - đ/c {1} - đi {2} -TBQT:{3} - QT {4}", tendoanra, objrp.TruongDoan, nuoccongtac, objrp.SoTbQt, thangduyetqt.ToString("MM/yyyy"));
            _Note = p_Note;
            _GroupByTime = group;
            _STT = 1;

            if (type == 1)
            {
                _USD = cnphaithuusd;
                _VND = cnphaithuvnd;
                _TG = cnphaithutg;
            }
            else
            {
                _USD = cnphaitrausd_TM;
                _VND = cnphaitrausd_CK;
                _Tong = cnphaitratong;
            }
        }

    }
}
