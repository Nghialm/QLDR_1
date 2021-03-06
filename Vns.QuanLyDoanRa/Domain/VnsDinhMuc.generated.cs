/*
insert license info here
*/
using System;
using System.ComponentModel;
using Vns.Erp.Core.Domain;
using System.Runtime.Serialization;
using Vns.QuanLyDoanRa.Dao.NHibernate;
namespace Vns.QuanLyDoanRa.Domain
{
    /// <summary>
    ///	Generated by MyGeneration using the NHibernate Object Mapping adapted by Gustavo And Modified By Hoang Quoc Dung
    /// </summary>


    [Serializable]
    [DataContract(Namespace = "http://Vns.QuanLyDoanRa", IsReference = true)]
    public partial class VnsDinhMuc : DomainObject<Guid>, INotifyPropertyChanged
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
        private Guid _dinhmucid;
        private DateTime _ngayapdung;
        private int _nhomnuoc;
        private int _loaicapvu;
        private Guid _mucid;
        private decimal _dinhmuc;
        private string _nuocid;
        private int _CachTinh;
        private string _diengiai;
        private int _thutu;
        #endregion

        #region Default ( Empty ) Class Constuctor
        /// <summary>
        /// default constructor
        /// </summary>
        public VnsDinhMuc()
        {
            _dinhmucid = new Guid();
            _ngayapdung = DateTime.MaxValue;
            _nhomnuoc = 0;
            _loaicapvu = 0;
            _mucid = new Guid();
            _dinhmuc = 0;
            _nuocid = String.Empty;
            _diengiai = string.Empty;
            _thutu = 0;
        }
        #endregion // End of Default ( Empty ) Class Constuctor

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public Guid DinhMucId
        {
            get { return _dinhmucid; }
            set { _isChanged |= (_dinhmucid != value); _dinhmucid = value; }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public DateTime NgayApDung
        {
            get { return _ngayapdung; }
            set { _isChanged |= (_ngayapdung != value); _ngayapdung = value; }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public int NhomNuoc
        {
            get { return _nhomnuoc; }
            set { _isChanged |= (_nhomnuoc != value); _nhomnuoc = value; }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public int LoaiCapVu
        {
            get { return _loaicapvu; }
            set { _isChanged |= (_loaicapvu != value); _loaicapvu = value; }
        }
        /// <summary>
        /// 
        /// </summary>		
        [DataMember]
        public int ThuTu
        {
            get { return _thutu; }
            set { _isChanged |= (_thutu != value); _thutu = value; }
        }

        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public Guid MucId
        {
            get { return _mucid; }
            set { _isChanged |= (_mucid != value); _mucid = value; }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public decimal DinhMuc
        {
            get { return Decimal.Round(_dinhmuc, 0); }
            set { _isChanged |= (_dinhmuc != value); _dinhmuc = value; }
        }


        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public string NuocId
        {
            get { return _nuocid; }
            set
            {
                if (value != null)
                    if (value.Length > 32)
                        throw new ArgumentOutOfRangeException("Invalid value for NuocId", value, value.ToString());

                _isChanged |= (_nuocid != value); _nuocid = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>		

        [DataMember]
        public string DienGiai
        {
            get { return _diengiai; }
            set
            {
                if (value != null)
                    if (value.Length > 256)
                        throw new ArgumentOutOfRangeException("Invalid value for DienGiai", value, value.ToString());

                _isChanged |= (_diengiai != value); _diengiai = value;
            }
        }

        [DataMember]
        public int CachTinh
        {
            get { return _CachTinh; }
            set { _isChanged |= (_CachTinh != value); _CachTinh = value; }
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
            VnsDinhMuc castObj = (VnsDinhMuc)obj;
            return (castObj != null) &&
                (this._dinhmucid == castObj.DinhMucId);
        }

        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {

            int hash = 57;
            hash = 27 * hash * _dinhmucid.GetHashCode();
            return hash;
        }
        #endregion

    }
}
