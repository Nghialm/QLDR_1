using System;
using System.ComponentModel;
using Vns.Erp.Core.Domain;
using System.Runtime.Serialization;
namespace Vns.QuanLyDoanRa.Domain
{
    [Serializable]
    [DataContract(Namespace = "http://Vns.QuanLyDoanRa", IsReference = true)]
    public partial class VnsSoDuCuoiKy : DomainObject<System.Guid>, INotifyPropertyChanged
    {
        #region Declarations

		
		private System.DateTime _NgayTinh = new DateTime();
		private System.Guid _NguonId = new Guid();
        private String _NghiepVu = String.Empty;
		private decimal _SoTienNte = 0;
		private decimal _TyGia = 0;
		private decimal _SoTien = 0;
		
		
        #endregion

        #region Constructors

        public VnsSoDuCuoiKy() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_NgayTinh);
			sb.Append(_NguonId);
			sb.Append(_SoTienNte);
			sb.Append(_TyGia);
			sb.Append(_SoTien);

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
			_SoTienNte = des.DuLuong;
			_TyGia = des.TyGia;
			_SoTien = des.SoTienTon;
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
        public virtual String NghiepVu
        {
            get { return _NghiepVu; }
            set { _NghiepVu = value; }
        }
        [DataMember]
        public virtual decimal SoTienNte
        {
            get { return _SoTienNte; }
			set
			{
				OnDuLuongChanging();
				_SoTienNte = value;
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
        public virtual decimal SoTien
        {
            get { return _SoTien; }
			set
			{
				OnSoTienTonChanging();
				_SoTien = value;
				OnSoTienTonChanged();
			}
        }
		partial void OnSoTienTonChanging();
		partial void OnSoTienTonChanged();
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
