using System;
using System.ComponentModel;
using Vns.Erp.Core.Domain;
using System.Runtime.Serialization;
namespace Vns.QuanLyDoanRa.Domain
{
    [Serializable]
    [DataContract(Namespace = "http://Vns.QuanLyDoanRa", IsReference = true)]
    public partial class VnsDuLuongDauKy : DomainObject<System.Guid>, INotifyPropertyChanged
    {
        #region Declarations

		
		private System.DateTime _NgayTinh = new DateTime();
		private System.Guid _NguonId = new Guid();
		private System.Guid _GiaoDichId = new Guid();
        private String _NghiepVu = String.Empty;
		private decimal _DuLuong = 0;
		private decimal _TyGia = 0;
		private decimal _SoTienTon = 0;
		private int _PhuongPhapId = 0;
        private DateTime _NgayCt = new DateTime();
		
		
        #endregion

        #region Constructors

        public VnsDuLuongDauKy() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_NgayTinh);
			sb.Append(_NguonId);
			sb.Append(_GiaoDichId);
			sb.Append(_DuLuong);
			sb.Append(_TyGia);
			sb.Append(_SoTienTon);
			sb.Append(_PhuongPhapId);

            return sb.ToString().GetHashCode();
        }
		
		public VnsDuLuongDauKy Clone()
        {
            return (VnsDuLuongDauKy)this.MemberwiseClone();
        }
		
		public void SetProperty(VnsDuLuongDauKy des)
		{
			//ID Field
			Id = des.Id;
			//Non ID Field
			_NgayTinh = des.NgayTinh;
			_NguonId = des.NguonId;
			_GiaoDichId = des.GiaoDichId;
			_DuLuong = des.DuLuong;
			_TyGia = des.TyGia;
			_SoTienTon = des.SoTienTon;
			_PhuongPhapId = des.PhuongPhapId;
		}

        #endregion

        #region Properties
        [DataMember]
		public virtual System.DateTime NgayTinh
        {
            get { return _NgayTinh; }
			set
			{
				OnNgayTinhChanging();
				_NgayTinh = value;
				OnNgayTinhChanged();
			}
        }
		partial void OnNgayTinhChanging();
		partial void OnNgayTinhChanged();
        [DataMember]
		public virtual System.Guid NguonId
        {
            get { return _NguonId; }
			set
			{
				OnNguonIdChanging();
				_NguonId = value;
				OnNguonIdChanged();
			}
        }
		partial void OnNguonIdChanging();
		partial void OnNguonIdChanged();
        [DataMember]
		public virtual System.Guid GiaoDichId
        {
            get { return _GiaoDichId; }
			set
			{
				OnGiaoDichIdChanging();
				_GiaoDichId = value;
				OnGiaoDichIdChanged();
			}
        }
		partial void OnGiaoDichIdChanging();
		partial void OnGiaoDichIdChanged();
        [DataMember]
        public virtual String NghiepVu
        {
            get { return _NghiepVu; }
            set { _NghiepVu = value; }
        }
        [DataMember]
		public virtual decimal DuLuong
        {
            get { return _DuLuong; }
			set
			{
				OnDuLuongChanging();
				_DuLuong = value;
				OnDuLuongChanged();
			}
        }
		partial void OnDuLuongChanging();
		partial void OnDuLuongChanged();
        [DataMember]
		public virtual decimal TyGia
        {
            get { return _TyGia; }
			set
			{
				OnTyGiaChanging();
				_TyGia = value;
				OnTyGiaChanged();
			}
        }
		partial void OnTyGiaChanging();
		partial void OnTyGiaChanged();
        [DataMember]
		public virtual decimal SoTienTon
        {
            get { return _SoTienTon; }
			set
			{
				OnSoTienTonChanging();
				_SoTienTon = value;
				OnSoTienTonChanged();
			}
        }
		partial void OnSoTienTonChanging();
		partial void OnSoTienTonChanged();
        [DataMember]
		public virtual int PhuongPhapId
        {
            get { return _PhuongPhapId; }
			set
			{
				OnPhuongPhapIdChanging();
				_PhuongPhapId = value;
				OnPhuongPhapIdChanged();
			}
        }
		partial void OnPhuongPhapIdChanging();
		partial void OnPhuongPhapIdChanged();
        [DataMember]
        public virtual DateTime NgayCt
        {
            get { return _NgayCt; }
            set { _NgayCt = value; }
        }
        #endregion
		
		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
		#endregion
    }
}
