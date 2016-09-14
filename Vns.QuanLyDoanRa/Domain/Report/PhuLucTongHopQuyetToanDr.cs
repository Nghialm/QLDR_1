using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{ 
    public class PhuLucTongHopQuyetToanDr
    {
        public virtual String Muc { get; set; }
        public virtual String NoiDung { get; set; }
        public virtual decimal QuyNayUSD { get; set; }
        public virtual decimal QuyNayVND { get; set; }
        public virtual decimal LuyKeVND { get; set; }
        public virtual decimal LuyKeUSD { get; set; }
        public virtual int Style { get; set; }
        public PhuLucTongHopQuyetToanDr(String _muc, String _noiDung, decimal _quyNayUSD, decimal _quyNayVND, decimal _luyKeVND, decimal _luyKeUSD, int _style)
        {
            Muc = _muc;
            NoiDung = _noiDung;
            QuyNayUSD = _quyNayUSD;
            QuyNayVND = _quyNayVND;
            LuyKeUSD = _luyKeUSD;
            LuyKeVND = _luyKeVND;
            Style = _style;
        }
    }    
}
