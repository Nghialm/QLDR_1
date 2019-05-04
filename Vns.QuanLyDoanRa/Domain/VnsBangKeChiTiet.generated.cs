using System;
using System.ComponentModel;
using Vns.Erp.Core.Domain;

namespace Vns.QuanLyDoanRa.Domain
{
    public partial class VnsBangKeChiTiet : DomainObject<System.Guid>, INotifyPropertyChanged
    {
        #region Declarations

		
		private System.Guid _BangKeId = new Guid();
		private int _SoHoaDon = 0;
		private System.DateTime _NgayHoaDon = new DateTime();
		private int _SoChungTu = 0;
		private System.DateTime _NgayChungTu = new DateTime();
		private System.Guid _LoaiDoanRaId = new Guid();
		private System.Guid _DoanRaId = new Guid();
		private System.Guid _MucTieuMucId = new Guid();
		private string _NoiDung = String.Empty;
		private decimal _SoLuong = 0;
		private decimal _DinhMucNte = 0;
		private decimal _SoTienNte = 0;
		private decimal _SoTien = 0;
		private decimal _TyGia = 0;
		
		
		
        #endregion

        #region Constructors

        public VnsBangKeChiTiet() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_BangKeId);
			sb.Append(_SoHoaDon);
			sb.Append(_NgayHoaDon);
			sb.Append(_SoChungTu);
			sb.Append(_NgayChungTu);
			sb.Append(_LoaiDoanRaId);
			sb.Append(_DoanRaId);
			sb.Append(_MucTieuMucId);
			sb.Append(_NoiDung);
			sb.Append(_SoLuong);
			sb.Append(_DinhMucNte);
			sb.Append(_SoTienNte);
			sb.Append(_SoTien);
			sb.Append(_TyGia);

            return sb.ToString().GetHashCode();
        }
		
		public VnsBangKeChiTiet Clone()
        {
            return (VnsBangKeChiTiet)this.MemberwiseClone();
        }
		
		public void SetProperty(VnsBangKeChiTiet des)
		{
			//ID Field
			Id = des.Id;
			//Non ID Field
			_BangKeId = des.BangKeId;
			_SoHoaDon = des.SoHoaDon;
			_NgayHoaDon = des.NgayHoaDon;
			_SoChungTu = des.SoChungTu;
			_NgayChungTu = des.NgayChungTu;
			_LoaiDoanRaId = des.LoaiDoanRaId;
			_DoanRaId = des.DoanRaId;
			_MucTieuMucId = des.MucTieuMucId;
			_NoiDung = des.NoiDung;
			_SoLuong = des.SoLuong;
			_DinhMucNte = des.DinhMucNte;
			_SoTienNte = des.SoTienNte;
			_SoTien = des.SoTien;
			_TyGia = des.TyGia;
		}

        #endregion

        #region Properties

		public virtual System.Guid BangKeId
        {
            get { return _BangKeId; }
			set
			{
				OnBangKeIdChanging();
				_BangKeId = value;
				OnBangKeIdChanged();
			}
        }
		partial void OnBangKeIdChanging();
		partial void OnBangKeIdChanged();
		
		public virtual int SoHoaDon
        {
            get { return _SoHoaDon; }
			set
			{
				OnSoHoaDonChanging();
				_SoHoaDon = value;
				OnSoHoaDonChanged();
			}
        }
		partial void OnSoHoaDonChanging();
		partial void OnSoHoaDonChanged();
		
		public virtual System.DateTime NgayHoaDon
        {
            get { return _NgayHoaDon; }
			set
			{
				OnNgayHoaDonChanging();
				_NgayHoaDon = value;
				OnNgayHoaDonChanged();
			}
        }
		partial void OnNgayHoaDonChanging();
		partial void OnNgayHoaDonChanged();
		
		public virtual int SoChungTu
        {
            get { return _SoChungTu; }
			set
			{
				OnSoChungTuChanging();
				_SoChungTu = value;
				OnSoChungTuChanged();
			}
        }
		partial void OnSoChungTuChanging();
		partial void OnSoChungTuChanged();
		
		public virtual System.DateTime NgayChungTu
        {
            get { return _NgayChungTu; }
			set
			{
				OnNgayChungTuChanging();
				_NgayChungTu = value;
				OnNgayChungTuChanged();
			}
        }
		partial void OnNgayChungTuChanging();
		partial void OnNgayChungTuChanged();
		
		public virtual System.Guid LoaiDoanRaId
        {
            get { return _LoaiDoanRaId; }
			set
			{
				OnLoaiDoanRaIdChanging();
				_LoaiDoanRaId = value;
				OnLoaiDoanRaIdChanged();
			}
        }
		partial void OnLoaiDoanRaIdChanging();
		partial void OnLoaiDoanRaIdChanged();
		
		public virtual System.Guid DoanRaId
        {
            get { return _DoanRaId; }
			set
			{
				OnDoanRaIdChanging();
				_DoanRaId = value;
				OnDoanRaIdChanged();
			}
        }
		partial void OnDoanRaIdChanging();
		partial void OnDoanRaIdChanged();
		
		public virtual System.Guid MucTieuMucId
        {
            get { return _MucTieuMucId; }
			set
			{
				OnMucTieuMucIdChanging();
				_MucTieuMucId = value;
				OnMucTieuMucIdChanged();
			}
        }
		partial void OnMucTieuMucIdChanging();
		partial void OnMucTieuMucIdChanged();
		
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
		
		public virtual decimal SoLuong
        {
            get { return _SoLuong; }
			set
			{
				OnSoLuongChanging();
				_SoLuong = value;
				OnSoLuongChanged();
			}
        }
		partial void OnSoLuongChanging();
		partial void OnSoLuongChanged();
		
		public virtual decimal DinhMucNte
        {
            get { return _DinhMucNte; }
			set
			{
				OnDinhMucNteChanging();
				_DinhMucNte = value;
				OnDinhMucNteChanged();
			}
        }
		partial void OnDinhMucNteChanging();
		partial void OnDinhMucNteChanged();
		
		public virtual decimal SoTienNte
        {
            get { return _SoTienNte; }
			set
			{
				OnSoTienNteChanging();
				_SoTienNte = value;
				OnSoTienNteChanged();
			}
        }
		partial void OnSoTienNteChanging();
		partial void OnSoTienNteChanged();
		
		public virtual decimal SoTien
        {
            get { return _SoTien; }
			set
			{
				OnSoTienChanging();
				_SoTien = value;
				OnSoTienChanged();
			}
        }
		partial void OnSoTienChanging();
		partial void OnSoTienChanged();
		
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
