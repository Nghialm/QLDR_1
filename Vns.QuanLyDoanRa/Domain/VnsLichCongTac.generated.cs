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
    public partial class VnsLichCongTac : DomainObject<Guid>, INotifyPropertyChanged
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
        private Guid _lichcongtacid;
        private Guid _congtacid;
        private Guid _nuocid;
        private string _diadiem;
        private DateTime _ngaydi;
        private DateTime _ngayve;
        private decimal _ngaycongtac;
        private int _trangthai;
        private string _mota;
        private int _LoaiQuocGia;
        #endregion

        #region Default ( Empty ) Class Constuctor
        /// <summary>
        /// default constructor
        /// </summary>
        public VnsLichCongTac()
        {
            _lichcongtacid = new Guid();
            _congtacid = new Guid();
            _nuocid = new Guid();
            _diadiem = String.Empty;
            _ngaydi = DateTime.MaxValue;
            _ngayve = DateTime.MaxValue;
            _trangthai = 0;
            _ngaycongtac = 0;
            _mota = String.Empty;
        }
        #endregion // End of Default ( Empty ) Class Constuctor

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public Guid LichCongTacId
        {
            get { return _lichcongtacid; }
            set { _isChanged |= (_lichcongtacid != value); _lichcongtacid = value; }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public Guid CongTacId
        {
            get { return _congtacid; }
            set { _isChanged |= (_congtacid != value); _congtacid = value; }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public Guid NuocId
        {
            get { return _nuocid; }
            set { _isChanged |= (_nuocid != value); _nuocid = value; }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public string DiaDiem
        {
            get { return _diadiem; }
            set
            {
                if (value != null)
                    if (value.Length > 128)
                        throw new ArgumentOutOfRangeException("Invalid value for DiaDiem", value, value.ToString());

                _isChanged |= (_diadiem != value); _diadiem = value;
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
        /// 
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
        public decimal NgayCongTac
        {
            get { return Decimal.Round(_ngaycongtac, 0); }
            set { _isChanged |= (_ngaycongtac != value); _ngaycongtac = value; }
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
        public int LoaiQuocGia
        {
            get { return _LoaiQuocGia; }
            set { _isChanged |= (_LoaiQuocGia != value); _LoaiQuocGia = value; }
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
            VnsLichCongTac castObj = (VnsLichCongTac)obj;
            return (castObj != null) &&
                (this._lichcongtacid == castObj.LichCongTacId);
        }

        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {

            int hash = 57;
            hash = 27 * hash * _lichcongtacid.GetHashCode();
            return hash;
        }
        #endregion

    }
}
