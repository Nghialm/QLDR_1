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
    public partial class VnsChungTu : DomainObject<Guid>, INotifyPropertyChanged
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
        private Guid _chungtuid;
        private DateTime _ngayct;
        private DateTime _ngayht;
        private string _soct;
        private Guid _loaichungtutid;
        private string _maloaichungtu;
        private string _noidung;
        private string _NguoiLapPhieu;
        private string _NguoiGiaoDich;
        private string _DiaChi;
        private int _TrangThai;
        private string _NhomCt;
        private string _nguoigiaodichviettat;
        #endregion

        #region Default ( Empty ) Class Constuctor
        /// <summary>
        /// default constructor
        /// </summary>
        public VnsChungTu()
        {
            _chungtuid = new Guid();
            _ngayct = DateTime.MaxValue;
            _ngayht = DateTime.MaxValue;
            _soct = String.Empty;
            _loaichungtutid = new Guid();
            _maloaichungtu = String.Empty;
            _noidung = String.Empty;
            _DiaChi = String.Empty;
            _TrangThai = 0;
            _NhomCt = String.Empty;
            _nguoigiaodichviettat = string.Empty;
        }
        #endregion // End of Default ( Empty ) Class Constuctor

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public Guid ChungTuId
        {
            get { return _chungtuid; }
            set { _isChanged |= (_chungtuid != value); _chungtuid = value; }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public DateTime NgayCt
        {
            get { return _ngayct; }
            set { _isChanged |= (_ngayct != value); _ngayct = value; }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public DateTime NgayHt
        {
            get { return _ngayht; }
            set { _isChanged |= (_ngayht != value); _ngayht = value; }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public string SoCt
        {
            get { return _soct; }
            set
            {
                if (value != null)
                    if (value.Length > 32)
                        throw new ArgumentOutOfRangeException("Invalid value for SoCt", value, value.ToString());

                _isChanged |= (_soct != value); _soct = value;
            }
        }

        [DataMember]
        public int TrangThai
        {
            get { return _TrangThai; }
            set{    _isChanged |= (_TrangThai != value); _TrangThai = value;}
        }
        [DataMember]
        public string NhomCt
        {
            get { return _NhomCt; }
            set
            {
                if (value != null)
                    if (value.Length > 32)
                        throw new ArgumentOutOfRangeException("Invalid value for trangthai", value, value.ToString());

                _isChanged |= (_NhomCt != value); _NhomCt = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public Guid LoaiChungTutId
        {
            get { return _loaichungtutid; }
            set { _isChanged |= (_loaichungtutid != value); _loaichungtutid = value; }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public string MaLoaiChungTu
        {
            get { return _maloaichungtu; }
            set
            {
                if (value != null)
                    if (value.Length > 32)
                        throw new ArgumentOutOfRangeException("Invalid value for MaLoaiChungTu", value, value.ToString());

                _isChanged |= (_maloaichungtu != value); _maloaichungtu = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public string NoiDung
        {
            get { return _noidung; }
            set
            {
                if (value != null)
                    if (value.Length > 512)
                        throw new ArgumentOutOfRangeException("Invalid value for NoiDung", value, value.ToString());

                _isChanged |= (_noidung != value); _noidung = value;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>		

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
        
        [DataMember]
        public string DiaChi
        {
            get { return _DiaChi; }
            set
            {
                if (value != null)
                    if (value.Length > 512)
                        throw new ArgumentOutOfRangeException("Invalid value for DiaChi", value, value.ToString());

                _isChanged |= (_DiaChi != value); _DiaChi = value;
            }
        }

        [DataMember]
        public string NguoiLapPhieu
        {
            get { return _NguoiLapPhieu; }
            set
            {
                if (value != null)
                    if (value.Length > 128)
                        throw new ArgumentOutOfRangeException("Invalid value for NoiDung", value, value.ToString());

                _isChanged |= (_NguoiLapPhieu != value); _NguoiLapPhieu = value;
            }
        }

        [DataMember]
        public string NguoiGiaoDich
        {
            get { return _NguoiGiaoDich; }
            set
            {
                if (value != null)
                    if (value.Length > 128)
                        throw new ArgumentOutOfRangeException("Invalid value for NoiDung", value, value.ToString());

                _isChanged |= (_NguoiGiaoDich != value); _NguoiGiaoDich = value;
            }
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
            VnsChungTu castObj = (VnsChungTu)obj;
            return (castObj != null) &&
                (this._chungtuid == castObj.ChungTuId);
        }

        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {

            int hash = 57;
            hash = 27 * hash * _chungtuid.GetHashCode();
            return hash;
        }
        #endregion

    }
}
