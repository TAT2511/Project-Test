//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alumni_LoaiDonViHanhChinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumni_LoaiDonViHanhChinh()
        {
            this.Alumni_DonViHanhChinh = new HashSet<Alumni_DonViHanhChinh>();
        }
    
        public System.Guid ID { get; set; }
        public string MaLoaiDonViHanhChinh { get; set; }
        public string TenLoaiDonViHanhChinh { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<System.DateTime> Deleted { get; set; }
        public string DeletedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alumni_DonViHanhChinh> Alumni_DonViHanhChinh { get; set; }
    }
}