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
	public partial class VnsLoaiDoanRa : DomainObject<Guid>, INotifyPropertyChanged
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
		private Guid _loaidoanraid; 
		private string _maloaidoanra; 
		private string _tenloaidoanra; 		
		#endregion
		
		#region Default ( Empty ) Class Constuctor
		/// <summary>
		/// default constructor
		/// </summary>
		public VnsLoaiDoanRa()
		{
				_loaidoanraid =  new Guid(); 
				_maloaidoanra =  String.Empty; 
				_tenloaidoanra =  String.Empty; 
		}
		#endregion // End of Default ( Empty ) Class Constuctor
		
		#region Public Properties
			
		/// <summary>
		/// 
		/// </summary>		
		
		[DataMember]
		public  Guid LoaiDoanRaId
		{
			get { return _loaidoanraid; }
			set { _isChanged |= (_loaidoanraid != value); _loaidoanraid = value; }
			}
			
			
		/// <summary>
		/// 
		/// </summary>		
		
		[DataMember]
		public  string MaLoaiDoanRa
		{
			get { return _maloaidoanra; }
			set	
			{
				if ( value != null)
					if( value.Length > 32)
						throw new ArgumentOutOfRangeException("Invalid value for MaLoaiDoanRa", value, value.ToString());
				
				_isChanged |= (_maloaidoanra != value); _maloaidoanra = value;
			}
			}
			
			
		/// <summary>
		/// 
		/// </summary>		
		
		[DataMember]
		public  string TenLoaiDoanRa
		{
			get { return _tenloaidoanra; }
			set	
			{
				if ( value != null)
					if( value.Length > 128)
						throw new ArgumentOutOfRangeException("Invalid value for TenLoaiDoanRa", value, value.ToString());
				
				_isChanged |= (_tenloaidoanra != value); _tenloaidoanra = value;
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
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
			VnsLoaiDoanRa castObj = (VnsLoaiDoanRa)obj; 
			return ( castObj != null ) &&
				( this._loaidoanraid == castObj.LoaiDoanRaId);
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _loaidoanraid.GetHashCode();
			return hash; 
		}
		#endregion
		
	}
}
