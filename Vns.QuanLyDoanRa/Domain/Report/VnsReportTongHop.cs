using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vns.QuanLyDoanRa.Domain.Report
{
    public class VnsReportTongHop
    {
        #region Phan Chung
        public Guid DoanRaId { get; set; }
        public string TruongDoanFullName { get; set; }
        public string TenDoanRa { get; set; }
        public Guid LoaiDoanRaId { get; set; }
        public string TenLoaiDoanRa { get; set; }
        public string TenDoanRaVietTat { get; set; }
        public string NuocCongTac { get; set; }
        public string TruongDoan { get; set; }
        public int SoNguoiDi { get; set; }
        public DateTime ThangDuyetDt { get; set; }
        public DateTime ThangDuyetQt { get; set; }
        public string SoTbDt { get; set; }
        public string SoTbQt { get; set; }
        public decimal TienQt { get; set; }
        public decimal TienVNDQt { get; set; }
        public string NguoiQt { get; set; }
        public string NguoiQTVietTat { get; set; }

        /// <summary>
        /// So nuoc di cong tac, neu la quyet toan bo sung so nuoc = 0
        /// </summary>
        public int SoNuocCt { get; set; }

        /// <summary>
        /// So nguoi di cong tac, neu la quyet toan bo sung so nguoi = 0
        /// </summary>
        public int SoNguoiCt { get; set; }

        /// <summary>
        /// Ho ten day du nguoi giao dich
        /// </summary>
        public string NguoiGiaoDich { get; set; }

        /// <summary>
        /// Ten nguoi giao dich
        /// </summary>
        public string TenNguoiGiaoDich { get; set; }
        #endregion

        #region Tam ung theo ky bao cao
        public decimal TU_TK_TM_VND { get; set; }
        public decimal TU_TK_TM_USD { get; set; }

        /// <summary>
        /// /Số tiền VND tạm ứng cho đoàn ra
        /// </summary>
        public decimal TU_VND_TK_TM { get; set; }

        public decimal TU_TK_CK_VND { get; set; }
        public decimal TU_TK_CK_USD { get; set; }

        /// <summary>
        /// Số tiền VNĐ tạm ứng chuyển khoản cho đoàn ra
        /// </summary>
        public decimal TU_VND_TK_CK { get; set; }

        public decimal TU_VND_TONG_VND_USD
        {
            get {
                return TU_VND_TK_CK + TU_TK_CK_VND;
            }
        }

        public decimal TU_TK_TONG_USD
        {
            get { return TU_TK_TM_USD + TU_TK_CK_USD; }
        }
        public decimal TU_TK_TONG_VND
        {
            get { return TU_TK_TM_VND + TU_TK_CK_VND; }
        }
        #endregion

        #region TAM UNG Số tiền tạm ứng đi theo tháng quyết toán
        public decimal TU_TM_VND { get; set; }
        public decimal TU_TM_USD { get; set; }
        public decimal TU_TM_TG
        {
            get
            {
                if (TU_TM_USD == 0)
                    return 0;
                else
                    return TU_TM_VND / TU_TM_USD;
            }
        }
        public decimal TU_CK_VND { get; set; }
        public decimal TU_CK_USD { get; set; }
        public decimal TU_CK_TG
        {
            get
            {
                if (TU_CK_USD == 0)
                    return 0;
                else
                    return TU_CK_VND / TU_CK_USD;
            }
        }
        public decimal TU_TONG_USD
        {
            get { return TU_TM_USD + TU_CK_USD; }
        }
        public decimal TU_TONG_VND
        {
            get { return TU_TM_VND + TU_CK_VND; }
        }

        /// <summary>
        /// Tạm ứng bằng tiền mặt VNĐ 
        /// </summary>
        public decimal TU_VND_TM { get; set; }

        /// <summary>
        /// Tạm ứng chuyển khoản VNĐ
        /// </summary>
        public decimal TU_VND_CK { get; set; }
        #endregion

        #region THU HOAN = so tien đã thu sau khi quyet toan
        public decimal TH_TM_USD { get; set; }
        public decimal TH_TM_VND { get; set; }
        public decimal TH_TM_TG
        {
            get
            {
                if (TH_TM_USD == 0)
                    return 0;
                else
                    return TH_TM_VND / TH_TM_USD;
            }
        }

        /// <summary>
        /// Thu hoàn tiền mặt VNĐ
        /// </summary>
        public decimal TH_VND_TM { get; set; }

        public decimal TH_CK_USD { get; set; }
        public decimal TH_CK_VND { get; set; }
        public decimal TH_CK_TG
        {
            get
            {
                if (TH_CK_USD == 0)
                    return 0;
                else
                    return TH_CK_VND / TH_CK_USD;
            }
        }

        /// <summary>
        /// Thu hoàn chuyển khoản VNĐ
        /// </summary>
        public decimal TH_VND_CK { get; set; }

        public decimal TH_TONG_USD
        {
            get { return TH_TM_USD + TH_CK_USD; }
        }
        public decimal TH_TONG_VND
        {
            get { return TH_TM_VND + TH_CK_VND; }
        }
        public decimal TH_TONG_TG
        {
            get
            {
                if (TH_TONG_USD == 0) return 0;
                else return TH_TONG_VND / TH_TONG_USD;
            }
        }

        /// <summary>
        /// Thu hoàn Ck tổng VND CK và USD CK (theo tỷ giá)
        /// </summary>
        public decimal TH_TONG_CK_VND_USD
        {
            get
            {
                return TH_VND_CK + TH_CK_VND;
            }
        }
        #endregion

        /*Lay so tien tam ung thang truoc, thang nay dua theo ngay quyet toan cua doan ra
          Neu Ngay Quyet toan < tu_ngay => Thang truoc
          Neu ngay Quyet toan > tu_ngay  => Thang nay*/
        #region Thu hoan tam ung thang truoc, thang nay
        public decimal TH_Usd_Thang_Truoc
        {
            get
            {
                if (ThangDuyetQt < TU_NGAY) return TH_TONG_USD;
                else return 0;
            }
        }
        public decimal TH_Vnd_Thang_Truoc
        {
            get
            {
                if (ThangDuyetQt < TU_NGAY) return TH_TONG_VND;
                else return 0;
            }
        }
        public decimal TH_Tg_Thang_Truoc
        {
            get
            {
                if (ThangDuyetQt < TU_NGAY) return TH_TONG_TG;
                else return 0;
            }
        }

        public decimal TH_Vnd_TM_Thang_Truoc
        {
            get
            {
                if (ThangDuyetQt < TU_NGAY) return TH_VND_TM;
                else return 0;
            }
        }

        public decimal TH_Usd_Thang_Nay
        {
            get
            {
                if (ThangDuyetQt >= TU_NGAY && ThangDuyetQt <= DEN_NGAY) return TH_TONG_USD;
                else return 0;
            }
        }
        public decimal TH_Vnd_Thang_Nay
        {
            get
            {
                if (ThangDuyetQt >= TU_NGAY && ThangDuyetQt <= DEN_NGAY) return TH_TONG_VND;
                else return 0;
            }
        }
        public decimal TH_Tg_Thang_Nay
        {
            get
            {
                if (ThangDuyetQt >= TU_NGAY && ThangDuyetQt <= DEN_NGAY) return TH_TONG_TG;
                else return 0;
            }
        }

        public decimal TH_Vnd_TM_Thang_Nay
        {
            get
            {
                if (ThangDuyetQt >= TU_NGAY && ThangDuyetQt <= DEN_NGAY) return TH_VND_TM;
                else return 0;
            }
        }
        #endregion

        #region Thu hoan chua quyet toan
        public decimal TH_CHUA_QT_TM_USD { get; set; }
        public decimal TH_CHUA_QT_TM_VND { get; set; }
        public decimal TH_CHUA_QT_TM_TG
        {
            get
            {
                if (TH_CHUA_QT_TM_USD == 0) return 0;
                else return TH_CHUA_QT_TM_VND / TH_CHUA_QT_TM_USD;
            }
        }
        /// <summary>
        /// Thu hoàn chưa quyết toán tiền mặt
        /// </summary>
        public decimal TH_VND_CHUA_QT_TM { get; set; }

        public decimal TH_CHUA_QT_CK_USD { get; set; }
        public decimal TH_CHUA_QT_CK_VND { get; set; }
        public decimal TH_CHUA_QT_CK_TG
        {
            get
            {
                if (TH_CHUA_QT_CK_USD == 0) return 0;
                else return TH_CHUA_QT_CK_VND / TH_CHUA_QT_CK_USD;
            }
        }

        /// <summary>
        /// Thu hoàn chưa quyết toán chuyển khoản
        /// </summary>
        public decimal TH_VND_CHUA_QT_CK { get; set; }

        public decimal TH_VND_CHUA_QT_CK_VND_USD
        {
            get
            {
                return TH_VND_CHUA_QT_CK + TH_CHUA_QT_CK_VND;
            }
        }
        #endregion

        #region CHI QUYET TOAN = So tien phai tra sau khi quyet toan QT_TU >0
        public decimal Chi_QT_CK_USD { get; set; }
        public decimal Chi_QT_CK_TG
        {
            get
            {
                if (Chi_QT_CK_USD == 0)
                    return 0;
                else
                    return Chi_QT_CK_VND / Chi_QT_CK_USD;
            }
        }
        public decimal Chi_QT_CK_VND { get; set; }

        /// <summary>
        /// Chi quyết toán chuyển khoản VNĐ
        /// </summary>
        public decimal Chi_VND_QT_CK { get; set; }

        public decimal Chi_QT_TM_USD { get; set; }
        public decimal Chi_QT_TM_TG
        {
            get
            {
                if (Chi_QT_TM_USD == 0)
                    return 0;
                else
                    return Chi_QT_TM_VND / Chi_QT_TM_USD;
            }
        }
        public decimal Chi_QT_TM_VND { get; set; }

        /// <summary>
        /// Chi quyết toán tiền mặt VNĐ
        /// </summary>
        public decimal Chi_VND_QT_TM { get; set; }

        /// <summary>
        /// Chi quyết toán chuyển khoản VND tiền CK (VND) + tiền CK (USD theo tỷ giá)
        /// </summary>
        public decimal Chi_QT_CK_VND_USD
        {
            get
            {
                return Chi_QT_CK_VND + Chi_VND_QT_CK;
            }
        }


        public decimal Chi_QT_TONG_USD
        {
            get { return Chi_QT_TM_USD + Chi_QT_CK_USD; }
        }
        public decimal Chi_QT_TONG_VND
        {
            get { return Chi_QT_TM_VND + Chi_QT_CK_VND; }
        }
        #endregion

        #region SO TIEN DA TRA SAU KHI QT
        public decimal DT_QT_TM_VND { get; set; }
        public decimal DT_QT_TM_USD { get; set; }
        public decimal DT_QT_CK_VND { get; set; }
        public decimal DT_QT_CK_USD { get; set; }
        public decimal DT_QT_TM_TG
        {
            get
            {
                if (DT_QT_TM_USD == 0)
                    return 0;
                else
                    return DT_QT_TM_VND / DT_QT_TM_USD;
            }
        }
        public decimal DT_QT_CK_TG
        {
            get
            {
                if (DT_QT_CK_USD == 0)
                    return 0;
                else
                    return DT_QT_CK_VND / DT_QT_CK_USD;
            }
        }
        public decimal DT_QT_TONG_VND
        {
            get { return DT_QT_TM_VND + DT_QT_CK_VND; }
        }
        public decimal DT_QT_TONG_USD
        {
            get { return DT_QT_TM_USD + DT_QT_CK_USD; }
        }
        #endregion

        #region SO QUYẾT TOÁN = TU + Chi.QT - Phai.Thu - Thu hoan TU.QT
        public decimal So_QT_TM_USD
        {
            get
            {
                decimal temp = TU_TM_USD + Chi_QT_TM_USD - CN_PhaiThu_TM_USD - TH_TM_USD;
                if (temp > 0) return temp;
                return 0;
            }
        }
        public decimal So_QT_TM_TG
        {
            get
            {
                if (So_QT_TM_USD == 0)
                    return 0;
                else
                    return So_QT_TM_VND / So_QT_TM_USD;
            }
        }
        public decimal So_QT_TM_VND
        {
            get
            {
                decimal temp = TU_TM_VND + Chi_QT_TM_VND - CN_PhaiThu_TM_VND - TH_TM_VND;
                if (temp > 0) return temp;
                return 0;
            }
        }

        public decimal So_QT_CK_USD
        {
            get
            {
                decimal temp = TU_CK_USD + Chi_QT_CK_USD - CN_PhaiThu_CK_USD - TH_CK_USD;
                if (temp > 0) return temp;
                return 0;
            }
        }
        public decimal So_QT_CK_TG
        {
            get
            {
                if (So_QT_CK_USD == 0)
                    return 0;
                else
                    return So_QT_CK_VND / So_QT_CK_USD;
            }
        }
        public decimal So_QT_CK_VND
        {
            get
            {
                decimal temp = TU_CK_VND + Chi_QT_CK_VND - CN_PhaiThu_CK_VND - TH_CK_VND;
                if (temp > 0) return temp;
                return 0;
            }
        }

        public decimal So_QT_VND_TM
        {
            get
            {
                decimal temp = TU_VND_TM + Chi_VND_QT_TM - CN_VND_PhaiThu_TM - TH_VND_TM;
                if (temp > 0) return temp;
                return 0;
            }
        }

        public decimal So_QT_VND_CK
        {
            get
            {
                decimal temp = TU_VND_CK + Chi_VND_QT_CK - CN_VND_PhaiThu_CK - TH_VND_CK;
                if (temp > 0) return temp;
                return 0;
            }
        }

        /// <summary>
        /// Số tiền quyết toán chuyển khoản VND + CK ngoại tệ quy đổi ra VNĐ
        /// </summary>
        public decimal So_QT_TONG_VND_USD
        {
            get 
            {
                return So_QT_CK_VND + So_QT_VND_CK;
            }
        }

        public decimal So_QT_USD_Tong
        {
            get
            {
                return So_QT_TM_USD + So_QT_CK_USD;
            }
        }
        public decimal So_QT_VND_Tong
        {
            get
            {
                return So_QT_TM_VND + So_QT_CK_VND;
            }
        }

        public decimal So_QT_VND
        {
            get
            {
                return So_QT_TM_VND + So_QT_CK_VND + So_QT_VND_TM + So_QT_VND_CK;
            }
        }
        #endregion

        #region SO THONG BAO QUYET TOAN = Tien Trong Bang Qt
        public decimal QT_CK_USD { get; set; }
        public decimal QT_CK_TG
        {
            get
            {
                if (QT_CK_USD == 0)
                    return 0;
                else
                    return QT_CK_VND / QT_CK_USD;
            }
        }
        public decimal QT_CK_VND { get; set; }

        /// <summary>
        /// Số tiền quyết toán chuyển khoản VNĐ
        /// </summary>
        public decimal QT_VND_CK { get; set; }

        public decimal QT_TM_USD { get; set; }
        public decimal QT_TM_TG
        {
            get
            {
                if (QT_TM_USD == 0)
                    return 0;
                else
                    return QT_TM_VND / QT_TM_USD;
            }
        }
        public decimal QT_TM_VND { get; set; }

        /// <summary>
        /// Số tiền quyết toán tiền mặt VNĐ
        /// </summary>
        public decimal QT_VND_TM { get; set; }

        public decimal QT_TONG_VND
        {
            get { return QT_TM_VND + QT_CK_VND; }
        }
        public decimal QT_TONG_USD
        {
            get { return QT_TM_USD + QT_CK_USD; }
        }
        #endregion

        #region So tien quyet toan khi doan ra lam quyet toan
        /*
         * Truong hop doan ra di cong tac ve quyet toan: Khi quyet toan, chuong trinh se tao ra nghiep vu
         * 661-331 theo so tien da tam ung va so tien chi thuc cua doan ra
         * Co 2 truong hop
         * Th1: So tien tam ung < so tien quyet toan => lay so tien tam ung = so tien quyet toan
         * Th2: so tien tam ung >= so tien quyet toan => lay so tien quyet toan = so tien quyet toan
         */

        public decimal Tk_Qt_Ck_Usd { get; set; }
        public decimal Tk_Qt_Ck_Tg
        {
            get
            {
                if (Tk_Qt_Ck_Usd == 0) return 0;
                else
                    return Tk_Qt_Ck_Vnd / Tk_Qt_Ck_Usd;
            }
        }
        public decimal Tk_Qt_Ck_Vnd { get; set; }

        public decimal Tk_Qt_Tm_Usd { get; set; }
        public decimal Tk_Qt_Tm_Tg
        {
            get
            {
                if (Tk_Qt_Tm_Usd == 0) return 0;
                else
                    return Tk_Qt_Tm_Vnd / Tk_Qt_Tm_Usd;
            }
        }
        public decimal Tk_Qt_Tm_Vnd { get; set; }

        public decimal Tk_Qt_Usd { get; set; }
        public decimal Tk_Qt_Vnd { get; set; }

        public decimal Tk_VND_Qt_CK { get; set; }
        public decimal Tk_VND_Qt_Tm { get; set; }
        #endregion

        #region So Quyet toan lay theo tai khoan luy ke tu dau toi thoi diem bao cao
        public decimal Tk_Qt_Lk_Ck_Usd { get; set; }
        public decimal Tk_Qt_Lk_Ck_Tg { get; set; }
        public decimal Tk_Qt_Lk_Ck_Vnd { get; set; }

        public decimal Tk_Qt_Lk_Tm_Usd { get; set; }
        public decimal Tk_Qt_Lk_Tm_Tg { get; set; }
        public decimal Tk_Qt_Lk_Tm_Vnd { get; set; }

        public decimal Tk_Qt_Lk_Usd { get; set; }
        public decimal Tk_Qt_Lk_Vnd { get; set; }
        #endregion

        #region TACH SO QUYET TOAN
        public decimal M_6801 { get; set; }
        public decimal M_6802 { get; set; }
        public decimal M_6803 { get; set; }
        public decimal M_6804 { get; set; }
        public decimal M_6805 { get; set; }
        public decimal M_6806 { get; set; }
        public decimal M_6849 { get; set; }

        public decimal M_VND_6801 { get; set; }
        public decimal M_VND_6802 { get; set; }
        public decimal M_VND_6803 { get; set; }
        public decimal M_VND_6804 { get; set; }
        public decimal M_VND_6805 { get; set; }
        public decimal M_VND_6806 { get; set; }
        public decimal M_VND_6849 { get; set; }
        #endregion

        /*
         * Th1: Khi quyet toan tao ra nghiep vu 661-331(Thanh toan voi nguoi ban)
         * Th2: Khi Chi quyet toan: 141-111(Tien mat hoac chuyen khoan)-Tinh chat cua chung tu (Thang truoc || thang nay
         * Không thấy dùng hoặc gán ở đâu (2016-11-08)
         */
        #region So quyet toan lay theo nghiep vu
        public decimal Qt_Tm_Usd_Qt { get; set; }
        public decimal Qt_Tm_Tg_Qt { get; set; }
        public decimal Qt_Tm_Vnd_Qt { get; set; }

        public decimal Qt_Ck_Usd_Qt { get; set; }
        public decimal Qt_Ck_Tg_Qt { get; set; }
        public decimal Qt_Ck_Vnd_Qt { get; set; }

        public decimal Qt_Usd_Qt { get; set; }
        public decimal Qt_Tg_Qt { get; set; }
        public decimal Qt_Vnd_Qt { get; set; }
        #endregion

        #region SO PHAI THU, phai tra 141  - 141
        public decimal CN_PhaiThu_USD
        {
            get
            {
                return CN_PhaiThu_TM_USD + CN_PhaiThu_CK_USD;
            }
        }
        public decimal CN_PhaiThu_TM_USD
        {
            get
            {
                decimal phaiThu = DuNo141_TM_USD - DuCo141_TM_USD;
                if (phaiThu > 0)
                {
                    CN_PhaiTra_TM_USD = 0;
                    return phaiThu;
                }
                else
                {
                    CN_PhaiTra_TM_USD = Math.Abs(phaiThu);
                    return 0;
                }
            }
        }

        public decimal CN_VND_PhaiThu_TM
        {
            get
            {
                decimal phaiThu = DuNo141_VND_TM - DuCo141_VND_TM;
                if (phaiThu > 0)
                {
                    CN_VND_PhaiTra_TM = 0;
                    return phaiThu;
                }
                else
                {
                    CN_VND_PhaiTra_TM = Math.Abs(phaiThu);
                    return 0;
                }
            }
        }

        public decimal CN_PhaiThu_CK_USD
        {
            get
            {
                decimal phaiThu = DuNo141_CK_USD - DuCo141_CK_USD;
                if (phaiThu > 0)
                {
                    CN_PhaiTra_CK_USD = 0;
                    return phaiThu;
                }
                else
                {
                    CN_PhaiTra_CK_USD = Math.Abs(phaiThu);
                    return 0;
                }
            }
        }

        public decimal CN_VND_PhaiThu_CK
        {
            get
            {
                decimal phaiThu = DuNo141_VND_CK - DuCo141_VND_CK;
                if (phaiThu > 0)
                {
                    CN_VND_PhaiTra_CK = 0;
                    return phaiThu;
                }
                else
                {
                    CN_VND_PhaiTra_CK = Math.Abs(phaiThu);
                    return 0;
                }
            }
        }

        public decimal CN_PhaiThu_TG
        {
            get
            {
                if (CN_PhaiThu_USD == 0)
                    return CN_PhaiThu_USD;
                else
                    return CN_PhaiThu_VND / CN_PhaiThu_USD;
            }
        }

        public decimal CN_PhaiThu_VND
        {
            get
            {
                if (CN_PhaiThu_USD == 0)
                    return 0;
                else
                    return CN_PhaiThu_TM_VND + CN_PhaiThu_CK_VND;
            }

        }
        public decimal CN_PhaiThu_TM_VND
        {
            get
            {
                if (CN_PhaiThu_TM_USD == 0) return 0;
                decimal phaithu = DuNo141_TM_VND - DuCo141_TM_VND;
                //decimal phaithu = TU_TM_VND - TM DuNo141_TM_VND - DuCo141_TM_VND;
                if (phaithu > 0)
                {
                    CN_PhaiTra_TM_VND = 0;

                    //Trong truong hop phai thu lai doan ra
                    //Tinh so tien VND phai thu khac do so quyet toan lay ty gia binh quan
                    phaithu = TU_TM_VND - TH_CHUA_QT_TM_VND - Tk_Qt_Tm_Vnd - Chi_QT_TM_VND;
                    return phaithu;
                }
                else
                {
                    CN_PhaiTra_TM_VND = Math.Abs(phaithu);
                    return 0;
                }
            }

        }
        public decimal CN_PhaiThu_CK_VND
        {
            get
            {
                if (CN_PhaiThu_CK_USD == 0) return 0;
                decimal phaithu = DuNo141_CK_VND - DuCo141_CK_VND;
                if (phaithu > 0)
                {
                    CN_PhaiTra_CK_VND = 0;
                    return phaithu;
                }
                else
                {
                    CN_PhaiTra_CK_VND = Math.Abs(phaithu);
                    return 0;
                }
            }

        }

        public decimal CN_PhaiTra_USD
        {
            get
            {
                return CN_PhaiTra_TM_USD + CN_PhaiTra_CK_USD;
            }
        }
        public decimal CN_PhaiTra_TM_USD{get; set;}
        public decimal CN_PhaiTra_CK_USD { get; set; }

        public decimal CN_VND_PhaiTra_CK { get; set; }

        public decimal CN_PhaiTra_TG
        {
            get
            {
                if (CN_PhaiTra_USD == 0)
                    return 0;
                else
                    return CN_PhaiTra_VND / CN_PhaiTra_USD;
            }
        }
        public decimal CN_PhaiTra_VND
        {
            get
            {
                return CN_PhaiTra_TM_VND + CN_PhaiTra_CK_VND;
            }
        }
        public decimal CN_PhaiTra_TM_VND { get; set; }
        public decimal CN_PhaiTra_CK_VND { get; set; }
        public decimal CN_VND_PhaiTra_TM { get; set; }
        #endregion

        #region Số phải thu, phải trả dựa trên việc đoàn ra đã quyết toán
        /*Số phải thu, phải trả được chấp nhận khi đoàn ra đã quyết toán
         Nếu ngày quyết toán trong kỳ xem báo cáo: Đủ điều kiện để phát sinh công nợ
         Nếu không: Công nợ bằng 0*/
        public decimal CN_QT_PhaiThu_USD
        {
            get
            {
                if (ThangDuyetQt >= _TU_NGAY && ThangDuyetQt <= _DEN_NGAY)
                    return CN_PhaiThu_USD;
                else
                    return 0;
            }
        }
        public decimal CN_QT_PhaiThu_VND
        {
            get
            {
                if (ThangDuyetQt >= _TU_NGAY && ThangDuyetQt <= _DEN_NGAY)
                    return CN_PhaiThu_VND;
                else
                    return 0;
            }
        }
        public decimal CN_QT_PhaiThu_TG
        {
            get
            {
                if (ThangDuyetQt >= _TU_NGAY && ThangDuyetQt <= _DEN_NGAY)
                {
                    if (CN_PhaiThu_USD == 0) return 0;

                    return CN_PhaiThu_VND / CN_PhaiThu_USD;
                }
                else
                    return 0;
            }
        }
        public decimal CN_QT_PhaiThu_TM_USD
        {
            get
            {
                if (ThangDuyetQt >= _TU_NGAY && ThangDuyetQt <= _DEN_NGAY)
                    return CN_PhaiThu_TM_USD;
                else
                    return 0;
            }
        }
        public decimal CN_QT_PhaiThu_TM_VND
        {
            get
            {
                if (ThangDuyetQt >= _TU_NGAY && ThangDuyetQt <= _DEN_NGAY)
                    return CN_PhaiThu_TM_VND;
                else
                    return 0;
            }
        }
        public decimal CN_QT_PhaiThu_CK_USD
        {
            get
            {
                if (ThangDuyetQt >= _TU_NGAY && ThangDuyetQt <= _DEN_NGAY)
                    return CN_PhaiThu_CK_USD;
                else
                    return 0;
            }
        }
        public decimal CN_QT_PhaiThu_CK_VND
        {
            get
            {
                if (ThangDuyetQt >= _TU_NGAY && ThangDuyetQt <= _DEN_NGAY)
                    return CN_PhaiThu_CK_VND;
                else
                    return 0;
            }
        }

        public decimal CN_QT_VND_TM_PhaiThu
        {
            get
            {
                if (ThangDuyetQt >= _TU_NGAY && ThangDuyetQt <= _DEN_NGAY)
                    return CN_VND_PhaiThu_TM;
                else
                    return 0;
            }
        }

        public decimal CN_QT_VND_CK_PhaiThu
        {
            get
            {
                if (ThangDuyetQt >= _TU_NGAY && ThangDuyetQt <= _DEN_NGAY)
                    return CN_VND_PhaiThu_CK;
                else
                    return 0;
            }
        }

        public decimal CN_QT_VND_CK_PhaiThu_TONG_USD_VND
        {
            get
            {
                return CN_QT_VND_CK_PhaiThu + CN_QT_PhaiThu_CK_VND;
            }
        }

        public decimal CN_QT_VND_PhaiThu
        {
            get
            {
                if (ThangDuyetQt >= _TU_NGAY && ThangDuyetQt <= _DEN_NGAY)
                    return CN_VND_PhaiThu_TM + CN_VND_PhaiThu_CK;
                else
                    return 0;
            }
        }

        /// <summary>
        /// So CN phai tra trong ky,
        /// Neu trong ky => co so tien
        /// Neu ngoai ky => khong co so tien
        /// </summary>
        public decimal CN_QT_TK_PhaiTra_USD
        {
            get
            {
                if (ThangDuyetQt >= _TU_NGAY && ThangDuyetQt <= _DEN_NGAY)
                    return CN_PhaiTra_USD;
                else
                    return 0;
            }
        }

        /// <summary>
        /// So CN phai tra trong ky,
        /// Neu trong ky => co so tien
        /// Neu ngoai ky => khong co so tien
        /// </summary>
        public decimal CN_QT_TK_PhaiTra_VND
        {
            get
            {
                if (ThangDuyetQt >= _TU_NGAY && ThangDuyetQt <= _DEN_NGAY)
                    return CN_VND_PhaiTra_TM;
                else
                    return 0;
            }
        } 

        public decimal CN_QT_PhaiTra_USD
        {
            get
            {
                if (/*ThangDuyetQt >= _TU_NGAY &&*/ ThangDuyetQt <= _DEN_NGAY)
                    return CN_PhaiTra_USD;
                else
                    return 0;
            }
        }
        public decimal CN_QT_PhaiTra_VND
        {
            get
            {
                if (/*ThangDuyetQt >= _TU_NGAY &&*/ ThangDuyetQt <= _DEN_NGAY)
                    return CN_PhaiTra_VND;
                else
                    return 0;
            }
        }
        public decimal CN_QT_PhaiTra_TM_USD
        {
            get
            {
                if (/*ThangDuyetQt >= _TU_NGAY &&*/ ThangDuyetQt <= _DEN_NGAY)
                    return CN_PhaiTra_TM_USD;
                else
                    return 0;
            }
        }
        public decimal CN_QT_PhaiTra_TM_VND
        {
            get
            {
                if (/*ThangDuyetQt >= _TU_NGAY &&*/ ThangDuyetQt <= _DEN_NGAY)
                    return CN_PhaiTra_TM_VND;
                else
                    return 0;
            }
        }
        public decimal CN_QT_PhaiTra_CK_USD
        {
            get
            {
                if (/*ThangDuyetQt >= _TU_NGAY &&*/ ThangDuyetQt <= _DEN_NGAY)
                    return CN_PhaiTra_CK_USD;
                else
                    return 0;
            }
        }
        public decimal CN_QT_PhaiTra_CK_VND
        {
            get
            {
                if (/*ThangDuyetQt >= _TU_NGAY &&*/ ThangDuyetQt <= _DEN_NGAY)
                    return CN_PhaiTra_CK_VND;
                else
                    return 0;
            }
        }
        #endregion


        #region So tien tam ung chua quyet toan
        /*La so tien doan ra da tam ung - nhung vi doan chua quyet toan nen => So tien tam ung chua quyet toan
         Dieu kien => Ngay quyet toan > Den_Ngay*/

        /// <summary>
        /// So tien tam ung chua quyet toan usd
        /// </summary>
        public decimal Tu_Chua_Qt_Usd
        {
            get
            {
                if (ThangDuyetQt < _DEN_NGAY) return 0;
                else return TU_TONG_USD;
            }
        }

        /// <summary>
        /// So tien tam ung chua quyet toan VND
        /// </summary>
        public decimal Tu_Chua_Qt_Vnd
        {
            get
            {
                if (ThangDuyetQt < _DEN_NGAY) return 0;
                else return TU_TONG_VND;
            }
        }
        #endregion

        #region Ham tao

        public VnsReportTongHop(VnsDoanCongTac objDoanCongTac, DateTime tu_ngay, DateTime den_ngay)
        {
            _TU_NGAY = tu_ngay;
            _DEN_NGAY = den_ngay;
            DoanRaId = objDoanCongTac.Id;
            TenDoanRa = objDoanCongTac.Ten;
            TenDoanRaVietTat = objDoanCongTac.TenVietTat;
            LoaiDoanRaId = objDoanCongTac.LoaiDoanRaId;
            TenLoaiDoanRa = objDoanCongTac.TenLoaiDoanRa;
            TruongDoan = objDoanCongTac.TenTruongDoan;
            TruongDoanFullName = objDoanCongTac.TruongDoan;
            SoTbQt = objDoanCongTac.SoThongBaoQuyetToan;
            SoTbDt = objDoanCongTac.SoThongBaoDuToan;

            //if (objDoanCongTac.DanhSachDuToanDoan.Count > 0)
            if (objDoanCongTac.NgayDuyetDuToan > new DateTime(2020, 1, 1))
                ThangDuyetDt = objDoanCongTac.NgayDuyetDuToan;
            else
                ThangDuyetDt = objDoanCongTac.NgayDuyetDuToan;

            ThangDuyetQt = objDoanCongTac.NgayQuyetToan;

            NuocCongTac = GetLichCongTac(objDoanCongTac.DanhSachLichCongTac);
            SoNguoiDi = GetTongThanhVien(objDoanCongTac.DanhSachThanhVien);
            TienQt = GetSoTienQuyetToan(objDoanCongTac.DanhSachQuyetToanDoan);
            TienVNDQt = GetSoTienVNDQuyetToan(objDoanCongTac.DanhSachQuyetToanDoan);

            if (objDoanCongTac.Id == objDoanCongTac.IdBanDau)
            {
                SoNguoiCt = SoNguoiDi;
                if (objDoanCongTac.DanhSachLichCongTac != null)
                    SoNuocCt = objDoanCongTac.DanhSachLichCongTac.Count;
                else
                    SoNuocCt = 0;
            }
            else
            {
                SoNguoiCt = 0;
                SoNuocCt = 0;
            }

            NguoiGiaoDich = objDoanCongTac.NguoiGiaoDich;
            TenNguoiGiaoDich = objDoanCongTac.NguoiGiaoDichVietTat;

            
            if (objDoanCongTac.DanhSachQuyetToanDoan.Count > 0
                && ThangDuyetQt >= _TU_NGAY && ThangDuyetQt <= _DEN_NGAY) // DUng bo =0
            {
                //ThangDuyetQt = objDoanCongTac.DanhSachQuyetToanDoan[0].NgayCt;

                foreach (VnsQuyetToanDoan objQt in objDoanCongTac.DanhSachQuyetToanDoan)
                {
                    if (objQt.objMucTieuMuc != null)
                    {
                        if (objQt.NgoaiTeId == Globals.NgoaiTeId)
                        {
                            if (objQt.objMucTieuMuc.MaMuc.Equals("6801"))
                                M_6801 += objQt.SoTien;
                            else if (objQt.objMucTieuMuc.MaMuc.Equals("6802"))
                                M_6802 += objQt.SoTien;
                            else if (objQt.objMucTieuMuc.MaMuc.Equals("6803"))
                                M_6803 += objQt.SoTien;
                            else if (objQt.objMucTieuMuc.MaMuc.Equals("6804"))
                                M_6804 += objQt.SoTien;
                            else if (objQt.objMucTieuMuc.MaMuc.Equals("6805"))
                                M_6805 += objQt.SoTien;
                            else if (objQt.objMucTieuMuc.MaMuc.Equals("6806"))
                                M_6806 += objQt.SoTien;
                            else if (objQt.objMucTieuMuc.MaMuc.Equals("6849"))
                                M_6849 += objQt.SoTien;
                        }
                        else if (objQt.NgoaiTeId == Globals.NoiTeId)
                        {
                            if (objQt.objMucTieuMuc.MaMuc == "6801")
                                M_VND_6801 += objQt.SoTienVND;
                            else if (objQt.objMucTieuMuc.MaMuc == "6802")
                                M_VND_6802 += objQt.SoTienVND;
                            else if (objQt.objMucTieuMuc.MaMuc == "6803")
                                M_VND_6803 += objQt.SoTienVND;
                            else if (objQt.objMucTieuMuc.MaMuc == "6804")
                                M_VND_6804 += objQt.SoTienVND;
                            else if (objQt.objMucTieuMuc.MaMuc == "6805")
                                M_VND_6805 += objQt.SoTienVND;
                            else if (objQt.objMucTieuMuc.MaMuc == "6806")
                                M_VND_6806 += objQt.SoTienVND;
                            else if (objQt.objMucTieuMuc.MaMuc == "6849")
                                M_VND_6849 += objQt.SoTienVND;
                        }
                    }
                }
            }

            //else
            //    ThangDuyetDt = DateTime.MaxValue;


        }

        private decimal GetSoTienQuyetToan(IList<VnsQuyetToanDoan> lst)
        {
            decimal sotienQt = 0;
            if (ThangDuyetQt >= TU_NGAY && ThangDuyetQt <= DEN_NGAY)
            {
                foreach (VnsQuyetToanDoan objQt in lst)
                {
                    if (objQt.NgoaiTeId== Globals.NgoaiTeId)
                        sotienQt += objQt.SoTien;
                }
            }
            else
                sotienQt = 0;
            return sotienQt;
        }

        private decimal GetSoTienVNDQuyetToan(IList<VnsQuyetToanDoan> lst)
        {
            decimal sotienQt = 0;
            if (ThangDuyetQt >= TU_NGAY && ThangDuyetQt <= DEN_NGAY)
            {
                foreach (VnsQuyetToanDoan objQt in lst)
                {
                    if (objQt.NgoaiTeId == Globals.NoiTeId)
                        sotienQt += objQt.SoTienVND;
                }
            }
            else
                sotienQt = 0;
            return sotienQt;
        }

        private int GetTongThanhVien(IList<VnsThanhVien> lst)
        {
            int tv = 0;
            if (ThangDuyetQt >= TU_NGAY && ThangDuyetQt <= DEN_NGAY)
            {
                foreach (VnsThanhVien obj in lst)
                {
                    tv += obj.SoLuong;
                }
            }
            else
            {
                tv = 0;
            }
            return tv;
        }

        private string GetLichCongTac(IList<VnsLichCongTac> lst)
        {
            string lct = "";
            foreach (VnsLichCongTac obj in lst)
            {
                if (obj.objNuocDen != null)
                if (lct == "")
                {
                    lct = obj.objNuocDen.TenNuoc;
                }
                else
                    lct = string.Format("{0}, {1}", lct, obj.objNuocDen.TenNuoc);
            }
            return lct;
        }

        #endregion

        #region Property mo rong

        private DateTime _TU_NGAY;
        public DateTime TU_NGAY
        {
            get { return _TU_NGAY; }
            set { _TU_NGAY = value; }
        }

        private DateTime _DEN_NGAY;
        public DateTime DEN_NGAY
        {
            get { return _DEN_NGAY; }
            set { _DEN_NGAY = value; }
        }

        public decimal TU_TM_USD_MR
        {
            get
            {
                if (TYPE == ReportType.RP02)
                {
                    if (ThangDuyetQt >= VnsConvert.CStartOfDate(_TU_NGAY) && ThangDuyetQt <= VnsConvert.CEndOfDate(_DEN_NGAY))
                        return TU_TM_USD;
                    else
                        return 0;
                }
                else
                {
                    return TU_TM_USD;
                }
            }
        }

        public decimal TU_TM_VND_MR
        {
            get
            {
                if (TYPE == ReportType.RP02)
                {
                    if (ThangDuyetQt >= VnsConvert.CStartOfDate(_TU_NGAY) && ThangDuyetQt <= VnsConvert.CEndOfDate(_DEN_NGAY))
                        return TU_TM_VND;
                    else
                        return 0;
                }
                else
                    return TU_TM_VND;
            }
        }


        public decimal TU_CK_VND_MR
        {
            get
            {
                if (TYPE == ReportType.RP02)
                {
                    if (ThangDuyetQt >= VnsConvert.CStartOfDate(_TU_NGAY) && ThangDuyetQt <= VnsConvert.CEndOfDate(_DEN_NGAY))
                        return TU_CK_VND;
                    else
                        return 0;
                }
                else
                    return TU_CK_VND;
            }
        }

        public decimal TU_CK_USD_MR
        {
            get
            {
                if (TYPE == ReportType.RP02)
                {
                    if (ThangDuyetQt >= VnsConvert.CStartOfDate(_TU_NGAY) && ThangDuyetQt <= VnsConvert.CEndOfDate(_DEN_NGAY))
                        return TU_CK_USD;
                    else
                        return 0;
                }
                else
                    return TU_CK_USD;
            }
        }


        public decimal TU_CK_TG_MR
        {
            get
            {
                if (TU_CK_USD_MR == 0)
                    return 0;
                else
                    return TU_CK_VND_MR / TU_CK_USD_MR;

            }
        }

        public decimal TU_TM_TG_MR
        {
            get
            {
                if (TU_TM_USD_MR == 0)
                    return 0;
                else
                    return TU_TM_VND_MR / TU_TM_USD_MR;
            }
        }

        public decimal TU_VND_TM_MR
        {
            get
            {
                if (TYPE == ReportType.RP02)
                {
                    if (ThangDuyetQt >= VnsConvert.CStartOfDate(_TU_NGAY) && ThangDuyetQt <= VnsConvert.CEndOfDate(_DEN_NGAY))
                        return TU_VND_TM;
                    else
                        return 0;
                }
                else
                {
                    return TU_VND_TM;
                }
            }
        }

        public decimal TU_VND_CK_MR
        {
            get
            {
                if (TYPE == ReportType.RP02)
                {
                    if (ThangDuyetQt >= VnsConvert.CStartOfDate(_TU_NGAY) && ThangDuyetQt <= VnsConvert.CEndOfDate(_DEN_NGAY))
                        return TU_VND_CK;
                    else
                        return 0;
                }
                else
                {
                    return TU_VND_CK;
                }
            }
        }

        /// <summary>
        /// Tạm ứng CK VND + CK USD (Quy ra VNĐ)
        /// </summary>
        public decimal TU_VND_TONG_CK_VND_USD
        {
            get
            {
                return TU_VND_CK_MR + TU_CK_VND_MR;
            }
        }

        public decimal TongTamUngVND
        {
            get
            {
                return TU_TM_VND_MR + TU_CK_VND_MR;
            }
        }

        public decimal TongTamUngUSD
        {
            get
            {
                return TU_TM_USD_MR + TU_CK_USD_MR;
            }
        }

        public decimal TongTamUngDoanMR
        {
            get
            {
                return TU_TM_VND_MR + TU_VND_TM_MR + TU_VND_CK_MR;
            }
        }

        public ReportType TYPE { get; set; }

        public decimal DuCo141_VND { get; set; }
        public decimal DuCo141_TM_VND { get; set; }
        public decimal DuCo141_CK_VND { get; set; }

        /// <summary>
        /// Du co 141 bằng tiền VNĐ Tiền mặt
        /// </summary>
        public decimal DuCo141_VND_TM { get; set; }
        /// <summary>
        /// Du co 141 bằng VNĐ Chuyển khoản
        /// </summary>
        public decimal DuCo141_VND_CK { get; set; }

        /// <summary>
        /// Du no 141 bằng tiền VNĐ Tiền mặt
        /// </summary>
        public decimal DuNo141_VND_TM { get; set; }
        /// <summary>
        /// Du no 141 bằng VNĐ Chuyển khoản
        /// </summary>
        public decimal DuNo141_VND_CK { get; set; }

        public decimal DuCo141_USD { get; set; }
        public decimal DuCo141_TM_USD { get; set; }
        public decimal DuCo141_CK_USD { get; set; }

        public decimal DuNo141_VND { get; set; }
        public decimal DuNo141_TM_VND { get; set; }
        public decimal DuNo141_CK_VND { get; set; }

        public decimal DuNo141_USD { get; set; }
        public decimal DuNo141_TM_USD { get; set; }
        public decimal DuNo141_CK_USD { get; set; }

        public decimal HU_TRONGTHANG_TM_VND { get; set; }
        public decimal HU_TRONGTHANG_TM_USD { get; set; }
        /// <summary>
        /// Thu hoàn ứng trong tháng tiền mặt
        /// </summary>
        public decimal HU_VND_TRONGTHANG_TM { get; set; }

        public decimal HU_TRONGTHANG_CK_VND { get; set; }
        public decimal HU_TRONGTHANG_CK_USD { get; set; }
        /// <summary>
        /// Thu hoàn ứng trong tháng chuyển khoản
        /// </summary>
        public decimal HU_VND_TRONGTHANG_CK { get; set; }

        /// <summary>
        /// Hoàn ứng CK tổng trong tháng VNĐ + USD theo tỷ giá
        /// </summary>
        public decimal HU_TONG_TRONGTHANG_CK_VND_USD
        {
            get 
            {
                return HU_VND_TRONGTHANG_CK + HU_TRONGTHANG_CK_VND;
            }
        }

        #endregion

        #region Ham so sanh
        public static int CompareSoQuyetToan(VnsReportTongHop x, VnsReportTongHop y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retvalSoQuyetToan = 0;
                    //int revalSoChungTu = 0;
                    retvalSoQuyetToan = x.SoTbQt.CompareTo(y.SoTbQt);
                    return retvalSoQuyetToan;
                }
            }
        }

        public static int CompareDoanRa(VnsReportTongHop x, VnsReportTongHop y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retvalSoQuyetToan = 0;
                    //int revalSoChungTu = 0;
                    retvalSoQuyetToan = x.DoanRaId.CompareTo(y.DoanRaId);
                    return retvalSoQuyetToan;
                }
            }
        }

        public static int CompareDoanRaCtGs(RP_SoDuTaiKhoan x, RP_SoDuTaiKhoan y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retvalSoQuyetToan = 0;
                    //int revalSoChungTu = 0;
                    retvalSoQuyetToan = x.DoanRaId.CompareTo(y.DoanRaId);
                    return retvalSoQuyetToan;
                }
            }
        }

        public static int CompareSoCtu(RP_SoDuTaiKhoan x, RP_SoDuTaiKhoan y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retvalSoQuyetToan = 0;
                    //int revalSoChungTu = 0;
                    retvalSoQuyetToan = x.SoCt.CompareTo(y.SoCt);
                    return retvalSoQuyetToan;
                }
            }
        }
        #endregion
    }


}
