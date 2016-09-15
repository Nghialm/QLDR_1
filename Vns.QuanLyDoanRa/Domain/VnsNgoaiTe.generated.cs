/*
insert license info here
*/
using System;
using System.ComponentModel;
using Vns.Erp.Core.Domain;
using System.Runtime.Serialization;
namespace Vns.QuanLyDoanRa.Domain
{
    public partial class VnsNgoaiTe : DomainObject<Guid>
    {
        #region Declarations


        private string _MaNgoaiTe = String.Empty;
        private string _TenNgoaiTe = String.Empty;
		
		
		
        #endregion

        #region Constructors

        public VnsNgoaiTe() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_MaNgoaiTe);
			sb.Append(_TenNgoaiTe);

            return sb.ToString().GetHashCode();
        }
		
		public VnsNgoaiTe Clone()
        {
            return (VnsNgoaiTe)this.MemberwiseClone();
        }
		
		public void SetProperty(VnsNgoaiTe des)
		{
			//ID Field
			Id = des.Id;
			//Non ID Field
			_MaNgoaiTe = des.MaNgoaiTe;
			_TenNgoaiTe = des.TenNgoaiTe;
		}

        #endregion

        #region Properties

		public virtual string MaNgoaiTe
        {
            get { return _MaNgoaiTe; }
			set
			{
				OnMangoaiteChanging();
				_MaNgoaiTe = value;
				OnMangoaiteChanged();
			}
        }
		partial void OnMangoaiteChanging();
		partial void OnMangoaiteChanged();
		
		public virtual string TenNgoaiTe
        {
            get { return _TenNgoaiTe; }
			set
			{
				OnTenngoaiteChanging();
				_TenNgoaiTe = value;
				OnTenngoaiteChanged();
			}
        }
		partial void OnTenngoaiteChanging();
		partial void OnTenngoaiteChanged();
		
        #endregion
		
		
    }
}
