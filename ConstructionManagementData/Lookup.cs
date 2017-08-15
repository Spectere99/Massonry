//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConstructionManagementData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lookup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lookup()
        {
            this.MaterialTypes = new HashSet<GeneralMaterial>();
            this.Uoms = new HashSet<GeneralMaterial>();
            this.Colors = new HashSet<GeneralMaterial>();
            this.GeneralTaskOptions = new HashSet<GeneralTaskOption>();
        }
    
        public int LookupID { get; set; }
        public int LookupTypeID { get; set; }
        public string LookupValue { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public int LastUpdatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GeneralMaterial> MaterialTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GeneralMaterial> Uoms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GeneralMaterial> Colors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GeneralTaskOption> GeneralTaskOptions { get; set; }
        public virtual LookupType LookupType { get; set; }
    }
}
