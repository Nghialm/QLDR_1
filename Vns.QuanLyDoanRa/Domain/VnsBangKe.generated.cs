using System;
using System.ComponentModel;
using Vns.Erp.Core.Domain;

namespace Vns.QuanLyDoanRa.Domain
{
    public partial class VnsBangKe : DomainObject<System.Guid>, INotifyPropertyChanged
    {
        #region Declarations

		
		private int _HinhThucThanhToan = 0;
		private System.DateTime _NgayLap = new DateTime();
		private System.Guid _LoaiBangKeId = new Guid();
		private string _MaLoaiBangKe = String.Empty;
		private string _NoiDung = String.Empty;
		private string _NguoiLapPhieu = String.Empty;
		private string _DiaChi = String.Empty;
		private int _TrangThai = 0;
		private string _SoBangKe = String.Empty;
		private string _NhomCt = String.Empty;
		
		
		
        #endregion

        #region Constructors

        public VnsBangKe() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_HinhThucThanhToan);
			sb.Append(_NgayLap);
			sb.Append(_LoaiBangKeId);
			sb.Append(_MaLoaiBangKe);
			sb.Append(_NoiDung);
			sb.Append(_NguoiLapPhieu);
			sb.Append(_DiaChi);
			sb.Append(_TrangThai);
			sb.Append(_SoBangKe);
			sb.Append(_NhomCt);

            return sb.ToString().GetHashCode();
        }
		
		public VnsBangKe Clone()
        {
            return (VnsBangKe)this.MemberwiseClone();
        }
		
		public void SetProperty(VnsBangKe des)
		{
			//ID Field
			Id = des.Id;
			//Non ID Field
			_HinhThucThanhToan = des.HinhThucThanhToan;
			_NgayLap = des.NgayLap;
			_LoaiBangKeId = des.LoaiBangKeId;
			_MaLoaiBangKe = des.MaLoaiBangKe;
			_NoiDung = des.NoiDung;
			_NguoiLapPhieu = des.NguoiLapPhieu;
			_DiaChi = des.DiaChi;
			_TrangThai = des.TrangThai;
			_SoBangKe = des.SoBangKe;
			_NhomCt = des.NhomCt;
		}

        #endregion

        #region Properties

		public virtual int HinhThucThanhToan
        {
            get { return _HinhThucThanhToan; }
			set
			{
				OnHinhThucThanhToanChanging();
				_HinhThucThanhToan = value;
				OnHinhThucThanhToanChanged();
			}
        }
		partial void OnHinhThucThanhToanChanging();
		partial void OnHinhThucThanhToanChanged();
		
		public virtual System.DateTime NgayLap
        {
            get { return _NgayLap; }
			set
			{
				OnNgayLapChanging();
				_NgayLap = value;
				OnNgayLapChanged();
			}
        }
		partial void OnNgayLapChanging();
		partial void OnNgayLapChanged();
		
		public virtual System.Guid LoaiBangKeId
        {
            get { return _LoaiBangKeId; }
			set
			{
				OnLoaiBangKeIdChanging();
				_LoaiBangKeId = value;
				OnLoaiBangKeIdChanged();
			}
        }
		partial void OnLoaiBangKeIdChanging();
		partial void OnLoaiBangKeIdChanged();
		
		public virtual string MaLoaiBangKe
        {
            get { return _MaLoaiBangKe; }
			set
			{
				OnMaLoaiBangKeChanging();
				_MaLoaiBangKe = value;
				OnMaLoaiBangKeChanged();
			}
        }
		partial void OnMaLoaiBangKeChanging();
		partial void OnMaLoaiBangKeChanged();
		
		public virtual string NoiDung
        {
            get { return _NoiDung; }
			set
			{
				OnNoiDungChanging();
				_NoiDung = value;
				OnNoiDungChanged();
			}
        }
		partial void OnNoiDungChanging();
		partial void OnNoiDungChanged();
		
		public virtual string NguoiLapPhieu
        {
            get { return _NguoiLapPhieu; }
			set
			{
				OnNguoiLapPhieuChanging();
				_NguoiLapPhieu = value;
				OnNguoiLapPhieuChanged();
			}
        }
		partial void OnNguoiLapPhieuChanging();
		partial void OnNguoiLapPhieuChanged();
		
		public virtual string DiaChi
        {
            get { return _DiaChi; }
			set
			{
				OnDiaChiChanging();
				_DiaChi = value;
				OnDiaChiChanged();
			}
        }
		partial void OnDiaChiChanging();
		partial void OnDiaChiChanged();
		
		public virtual int TrangThai
        {
            get { return _TrangThai; }
			set
			{
				OnTrangThaiChanging();
				_TrangThai = value;
				OnTrangThaiChanged();
			}
        }
		partial void OnTrangThaiChanging();
		partial void OnTrangThaiChanged();
		
		public virtual string SoBangKe
        {
            get { return _SoBangKe; }
			set
			{
				OnSoBangKeChanging();
				_SoBangKe = value;
				OnSoBangKeChanged();
			}
        }
		partial void OnSoBangKeChanging();
		partial void OnSoBangKeChanged();
		
		public virtual string NhomCt
        {
            get { return _NhomCt; }
			set
			{
				OnNhomCtChanging();
				_NhomCt = value;
				OnNhomCtChanged();
			}
        }
		partial void OnNhomCtChanging();
		partial void OnNhomCtChanged();
		
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
