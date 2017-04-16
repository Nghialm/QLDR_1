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
        
        private decimal _QuyDoiVND;
        public decimal QuyDoiVND
        {
            get { return _QuyDoiVND; }
            set { _QuyDoiVND = value; }
        }

        private decimal _VND;
        public decimal VND
        { get { return _VND; } set { _VND = value; } }

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

        public bool HasData = false;

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
            _TenDoanRa = string.Format("{0} - đ/c {1} - đi {2} - QT {3}", obj.TenDoanRa, obj.TruongDoan, obj.NuocCongTac, obj.ThangDuyetQt.ToString("MM-yyyy"));
            _Note = p_Note;
            _GroupByTime = group;
            _STT = 1;

            if (type == 1)
            {
                _USD = obj.CN_PhaiThu_USD;
                _QuyDoiVND = obj.CN_PhaiThu_VND;
                _TG = obj.CN_PhaiThu_TG;
                HasData = true;
            }
            else
            {

                _USD = obj.CN_PhaiTra_TM_USD;
                _QuyDoiVND = obj.CN_PhaiTra_CK_VND;
                _Tong = obj.CN_PhaiTra_USD;
                _TG = obj.CN_PhaiTra_TG;
                HasData = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objrp"></param>
        /// <param name="loaidoanra"></param>
        /// <param name="doanraid"></param>
        /// <param name="tenloaidoanra"></param>
        /// <param name="tendoanra"></param>
        /// <param name="truongdoan"></param>
        /// <param name="nuoccongtac"></param>
        /// <param name="thangduyetqt"></param>
        /// <param name="cnphaithuusd"></param>
        /// <param name="cnphaithuvnd"></param>
        /// <param name="cnphaithutg"></param>
        /// <param name="cnphaitrausd_USD"></param>
        /// <param name="cnphaitrausd_VND"></param>
        /// <param name="cnphaitratong"></param>
        /// <param name="p_Note"></param>
        /// <param name="group"></param>
        /// <param name="type"></param>
        public RP_BC06DR(VnsReportTongHop objrp, Guid loaidoanra, Guid doanraid, string tenloaidoanra, string tendoanra,
            string truongdoan, string nuoccongtac, DateTime thangduyetqt,
            decimal cnphaithuusd, decimal cnphaithuvnd, decimal cnphaithutg, decimal cnphaithuVnd,
            decimal cnphaitrausd_USD, decimal cnphaitrausd_VND,
            string p_Note, int group, int type)
        {
            _LoaiDoanRaId = loaidoanra;
            _DoanRaId = doanraid;
            _TenLoaiDoanRa = tenloaidoanra;
            _TenDoanRa = string.Format("{0} - đ/c {1} - đi {2} -TBQT:{3} - QT {4}", tendoanra, objrp.TruongDoan, nuoccongtac, objrp.SoTbQt, thangduyetqt.ToString("MM-yyyy"));
            _Note = p_Note;
            _GroupByTime = group;
            _STT = 1;

            if (type == 1)
            {
                _USD = cnphaithuusd;
                _QuyDoiVND = cnphaithuvnd;
                _TG = cnphaithutg;
                _VND = cnphaithuVnd;

                if (_USD != 0 || _QuyDoiVND != 0 || _VND != 0)
                    HasData = true;
            }
            else
            {
                _USD = cnphaitrausd_USD;
                _VND = cnphaitrausd_VND;

                if (_USD != 0 || _VND != 0)
                    HasData = true;
            }
        }

    }
}
