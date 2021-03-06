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
	[DataContract(Namespace ="http://Vns.QuanLyDoanRa",IsReference=true)]
	public partial class VnsThanhVien : DomainObject<Guid>, INotifyPropertyChanged
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
		private Guid _thanhvienid; 
		private string _tenthanhvien; 
		private int _soluong; 
		private int _phanloai; 
		private Guid _lichcongtacid;
        private Guid _CongTacId; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public VnsThanhVien()
		{
				_thanhvienid =  new Guid(); 
				_tenthanhvien =  String.Empty; 
				_soluong = 0; 
				_phanloai = 0; 
				_lichcongtacid =  new Guid();
                _CongTacId = new Guid();
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 
		/// </summary>		
		
		[DataMember]
		public  Guid ThanhVienId
		{
			get { return _thanhvienid; }
			set { _isChanged |= (_thanhvienid != value); _thanhvienid = value; }
			}
			
			
		/// <summary>
		/// 
		/// </summary>		
		
		[DataMember]
		public  string TenThanhVien
		{
			get { return _tenthanhvien; }
			set	
			{
				if ( value != null)
					if( value.Length > 512)
						throw new ArgumentOutOfRangeException("Invalid value for TenThanhVien", value, value.ToString());
				
				_isChanged |= (_tenthanhvien != value); _tenthanhvien = value;
			}
			}
			
			
		/// <summary>
		/// 
		/// </summary>		
		
		[DataMember]
		public  int SoLuong
		{
			get { return _soluong; }
			set { _isChanged |= (_soluong != value); _soluong = value; }
			}
			
			
		/// <summary>
		/// 
		/// </summary>		
		
		[DataMember]
		public  int PhanLoai
		{
			get { return _phanloai; }
			set { _isChanged |= (_phanloai != value); _phanloai = value; }
			}
			
			
		/// <summary>
		/// 
		/// </summary>		
		
		[DataMember]
		public  Guid LichCongTacId
		{
			get { return _lichcongtacid; }
			set { _isChanged |= (_lichcongtacid != value); _lichcongtacid = value; }
			}

        [DataMember]
        public Guid CongTacId
        {
            get { return _CongTacId; }
            set { _isChanged |= (_CongTacId != value); _CongTacId = value; }
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
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
			VnsThanhVien castObj = (VnsThanhVien)obj; 
			return ( castObj != null ) &&
				( this._thanhvienid == castObj.ThanhVienId);
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _thanhvienid.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
