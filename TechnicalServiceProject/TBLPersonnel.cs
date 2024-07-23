//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TechnicalServiceProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLPersonnel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLPersonnel()
        {
            this.TBLBillingInfo = new HashSet<TBLBillingInfo>();
            this.TBLProductAcceptance = new HashSet<TBLProductAcceptance>();
            this.TBLProductMovement = new HashSet<TBLProductMovement>();
        }
    
        public short ID { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public Nullable<byte> DEPARTMAN { get; set; }
        public string FOTOGRAF { get; set; }
        public string MAIL { get; set; }
        public string TELEFON { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLBillingInfo> TBLBillingInfo { get; set; }
        public virtual TBLDepartment TBLDepartment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLProductAcceptance> TBLProductAcceptance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLProductMovement> TBLProductMovement { get; set; }
    }
}
