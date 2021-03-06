/*
insert license info here
*/
using System;
using System.ComponentModel;
using Vns.Erp.Core.Domain;
using System.Runtime.Serialization;
namespace Vns.QuanLyDoanRa.Domain
{
    /// <summary>
    ///	Generated by MyGeneration using the NHibernate Object Mapping adapted by Gustavo And Modified By Hoang Quoc Dung
    /// </summary>


    [Serializable]
    [DataContract(Namespace = "http://Vns.QuanLyDoanRa", IsReference = true)]
    public partial class VnsDoanCongTac : DomainObject<Guid>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #region Private Members
        private bool _isChanged;
        private bool _isDeleted;
        private Guid _congtacid;
        private Guid _IdBanDau;
        private Int32 _LanQuyetToan;
        private Guid _donviid;
        private string _truongdoan;
        private Guid _chucvutruongdoanid;
        private string _ten;
        private string _tenviettat;
        private string _nguoigiaodich;
        private string _nguoigiaodichviettat;
        private string _mota;
        private DateTime _ngaydi;
        private DateTime _ngayve;
        private int _trangthai;
        private Guid _loaidoanraid;
        private Guid _ChungTuId;
        private DateTime _NgayQuyetToan;
        private DateTime _ngayduyetdutoan;
        private string _SoTbDuToan;
        private DateTime _ngayin;
        private DateTime _ngaycancu;
        private string _cancucongvan;
        private string _socancuhoso;
        private string _tentruongdoan;
        private string _sothongbaoqt;
        private string _sothongbaodt;
        #endregion

        #region Default ( Empty ) Class Constuctor
        /// <summary>
        /// default constructor
        /// </summary>
        public VnsDoanCongTac()
        {
            _congtacid = new Guid();
            _truongdoan = String.Empty;
            _chucvutruongdoanid = new Guid();
            _ten = String.Empty;
            _mota = String.Empty;
            _ngaydi = DateTime.MaxValue;
            _ngayve = DateTime.MaxValue;
            _trangthai = 0;
            _loaidoanraid = new Guid();
            _donviid = new Guid();
            _NgayQuyetToan = DateTime.MaxValue;
            _SoTbDuToan = String.Empty;
            _ngayin = DateTime.MaxValue;
            _ngaycancu = DateTime.MaxValue;
            _cancucongvan = string.Empty;
            _socancuhoso = string.Empty;
            _tentruongdoan = string.Empty;
            _sothongbaodt = string.Empty;
            _sothongbaoqt = string.Empty;

            _tenviettat = string.Empty;
            _nguoigiaodich = string.Empty;
            _nguoigiaodichviettat = string.Empty;
            _ngayduyetdutoan = DateTime.MaxValue;


        }
        #endregion // End of Default ( Empty ) Class Constuctor

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public Guid CongTacId
        {
            get { return _congtacid; }
            set { _isChanged |= (_congtacid != value); _congtacid = value; }
        }

        [DataMember]
        public Guid IdBanDau
        {
            get { return _IdBanDau; }
            set { _isChanged |= (_IdBanDau != value); _IdBanDau = value; }
        }

        [DataMember]
        public Int32 LanQuyetToan
        {
            get { return _LanQuyetToan; }
            set { _isChanged |= (_LanQuyetToan != value); _LanQuyetToan = value; }
        }
        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public Guid DonViId
        {
            get { return _donviid; }
            set { _isChanged |= (_donviid != value); _donviid = value; }
        }

        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public string TruongDoan
        {
            get { return _truongdoan; }
            set
            {
                if (value != null)
                    if (value.Length > 128)
                        throw new ArgumentOutOfRangeException("Invalid value for TruongDoan", value, value.ToString());

                _isChanged |= (_truongdoan != value); _truongdoan = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public Guid ChucVuTruongDoanId
        {
            get { return _chucvutruongdoanid; }
            set { _isChanged |= (_chucvutruongdoanid != value); _chucvutruongdoanid = value; }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public string Ten
        {
            get { return _ten; }
            set
            {
                if (value != null)
                    if (value.Length > 128)
                        throw new ArgumentOutOfRangeException("Invalid value for Ten", value, value.ToString());

                _isChanged |= (_ten != value); _ten = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public string MoTa
        {
            get { return _mota; }
            set
            {
                if (value != null)
                    if (value.Length > 512)
                        throw new ArgumentOutOfRangeException("Invalid value for MoTa", value, value.ToString());

                _isChanged |= (_mota != value); _mota = value;
            }
        }

        [DataMember]
        public string SoTbDuToan
        {
            get { return _SoTbDuToan; }
            set
            {
                if (value != null)
                    if (value.Length > 32)
                        throw new ArgumentOutOfRangeException("Invalid value for SoTbDuToan", value, value.ToString());

                _isChanged |= (_SoTbDuToan != value); _SoTbDuToan = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public DateTime NgayDi
        {
            get { return _ngaydi; }
            set { _isChanged |= (_ngaydi != value); _ngaydi = value; }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public DateTime NgayVe
        {
            get { return _ngayve; }
            set { _isChanged |= (_ngayve != value); _ngayve = value; }
        }


        /// <summary>
        /// TRANGTHAI_DOANRA
        /// </summary>		

        [DataMember]
        public int TrangThai
        {
            get { return _trangthai; }
            set { _isChanged |= (_trangthai != value); _trangthai = value; }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public Guid LoaiDoanRaId
        {
            get { return _loaidoanraid; }
            set { _isChanged |= (_loaidoanraid != value); _loaidoanraid = value; }
        }


        [DataMember]
        public DateTime NgayQuyetToan
        {
            get { return _NgayQuyetToan; }
            set { _isChanged |= (_NgayQuyetToan != value); _NgayQuyetToan = value; }
        }

        [DataMember]
        public Guid ChungTuId
        {
            get { return _ChungTuId; }
            set { _isChanged |= (_ChungTuId != value); _ChungTuId = value; }
        }

        /// <summary>
        /// 
        /// </summary>		
        [DataMember]
        public DateTime NgayIn
        {
            get { return _ngayin; }
            set { _isChanged |= (_ngayin != value); _ngayin = value; }
        }

        /// <summary>
        /// 
        /// </summary>		
        [DataMember]
        public DateTime NgayCanCu
        {
            get { return _ngaycancu; }
            set { _isChanged |= (_ngaycancu != value); _ngaycancu = value; }
        }

        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public string CanCuCongVan
        {
            get { return _cancucongvan; }
            set
            {
                if (value != null)
                    if (value.Length > 512)
                        throw new ArgumentOutOfRangeException("Invalid value for CanCuCongVan", value, value.ToString());

                _isChanged |= (_cancucongvan != value); _cancucongvan = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public string SoCanCuHoSo
        {
            get { return _socancuhoso; }
            set
            {
                if (value != null)
                    if (value.Length > 512)
                        throw new ArgumentOutOfRangeException("Invalid value for SoCanCuHoSo", value, value.ToString());

                _isChanged |= (_socancuhoso != value); _socancuhoso = value;
            }
        }/// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public string TenTruongDoan
        {
            get { return _tentruongdoan; }
            set
            {
                if (value != null)
                    if (value.Length > 255)
                        throw new ArgumentOutOfRangeException("Invalid value for TenTruongDoan", value, value.ToString());

                _isChanged |= (_tentruongdoan != value); _tentruongdoan = value;
            }
        }

        /// 
        /// </summary>		

        [DataMember]
        public string SoThongBaoDuToan
        {
            get { return _sothongbaodt; }
            set
            {
                if (value != null)
                    if (value.Length > 255)
                        throw new ArgumentOutOfRangeException("Invalid value for SoThongBaoDuToan", value, value.ToString());

                _isChanged |= (_sothongbaodt != value); _sothongbaodt = value;
            }
        }

        /// 
        /// </summary>		

        [DataMember]
        public string SoThongBaoQuyetToan
        {
            get { return _sothongbaoqt; }
            set
            {
                if (value != null)
                    if (value.Length > 255)
                        throw new ArgumentOutOfRangeException("Invalid value for SoThongBaoQuyetToan", value, value.ToString());

                _isChanged |= (_sothongbaoqt != value); _sothongbaoqt = value;
            }
        }


        [DataMember]
        public string TenVietTat
        {
            get { return _tenviettat; }
            set
            {
                if (value != null)
                    if (value.Length > 255)
                        throw new ArgumentOutOfRangeException("Invalid value for TenVietTat", value, value.ToString());

                _isChanged |= (_tenviettat != value); _tenviettat = value;
            }
        }


        [DataMember]
        public string NguoiGiaoDich
        {
            get { return _nguoigiaodich; }
            set
            {
                if (value != null)
                    if (value.Length > 255)
                        throw new ArgumentOutOfRangeException("Invalid value for NguoiGiaoDich", value, value.ToString());

                _isChanged |= (_nguoigiaodich != value); _nguoigiaodich = value;
            }
        }


        [DataMember]
        public string NguoiGiaoDichVietTat
        {
            get { return _nguoigiaodichviettat; }
            set
            {
                if (value != null)
                    if (value.Length > 255)
                        throw new ArgumentOutOfRangeException("Invalid value for NguoiGiaoDichVietTat", value, value.ToString());

                _isChanged |= (_nguoigiaodichviettat != value); _nguoigiaodichviettat = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>		
        [DataMember]
        public DateTime NgayDuyetDuToan
        {
            get { return _ngayduyetdutoan; }
            set { _isChanged |= (_ngayduyetdutoan != value); _ngayduyetdutoan = value; }
        }

        /// 
        /// </summary>		

        [DataMember]
        public string TenHienThi
        {
            get
            {
                string str = Ten;
                if (SoTbDuToan != string.Empty)
                    str = str + "-" + SoThongBaoDuToan;
                if (SoThongBaoQuyetToan != string.Empty)
                    str = str + "-" + SoThongBaoQuyetToan;
                return str;
            }

        }

        /// <summary>
        /// Returns whether or not the object has changed it's values.
        /// </summary>
        public string NgayQt
        {
            get;
            set;
        }

        /// <summary>
        /// Returns whether or not the object has changed it's values.
        /// </summary>
        public string NgayDt
        {
            get;
            set;
        }

        /// <summary>
        /// Returns whether or not the object has changed it's values.
        /// </summary>
        public bool IsChanged
        {
            get { return _isChanged; }
        }

        /// <summary>
        /// Returns whether or not the object has changed it's values.
        /// </summary>
        public bool IsDeleted
        {
            get { return _isDeleted; }
        }

        #endregion


        #region Public Functions

        /// <summary>
        /// mark the item as deleted
        /// </summary>
        public void MarkAsDeleted()
        {
            _isDeleted = true;
            _isChanged = true;
        }


        #endregion


        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            VnsDoanCongTac castObj = (VnsDoanCongTac)obj;
            return (castObj != null) &&
                (this._congtacid == castObj.CongTacId);
        }

        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {

            int hash = 57;
            hash = 27 * hash * _congtacid.GetHashCode();
            return hash;
        }
        #endregion

    }
}
