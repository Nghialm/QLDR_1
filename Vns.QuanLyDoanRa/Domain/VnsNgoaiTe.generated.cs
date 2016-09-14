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


        private string _Mangoaite = String.Empty;
        private string _Tenngoaite = String.Empty;
		
		
		
        #endregion

        #region Constructors

        public VnsNgoaiTe() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_Mangoaite);
			sb.Append(_Tenngoaite);

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
			_Mangoaite = des.Mangoaite;
			_Tenngoaite = des.Tenngoaite;
		}

        #endregion

        #region Properties

		public virtual string Mangoaite
        {
            get { return _Mangoaite; }
			set
			{
				OnMangoaiteChanging();
				_Mangoaite = value;
				OnMangoaiteChanged();
			}
        }
		partial void OnMangoaiteChanging();
		partial void OnMangoaiteChanged();
		
		public virtual string Tenngoaite
        {
            get { return _Tenngoaite; }
			set
			{
				OnTenngoaiteChanging();
				_Tenngoaite = value;
				OnTenngoaiteChanged();
			}
        }
		partial void OnTenngoaiteChanging();
		partial void OnTenngoaiteChanged();
		
        #endregion
		
		
    }
}
