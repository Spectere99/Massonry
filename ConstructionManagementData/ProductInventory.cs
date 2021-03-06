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
    
    public partial class ProductInventory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductInventory()
        {
            this.GeneralMaterials = new HashSet<GeneralMaterial>();
        }
    
        public int ProductInventoryID { get; set; }
        public string Product { get; set; }
        public string ProductCode { get; set; }
        public int VendorID { get; set; }
        public Nullable<int> ColorLookupID { get; set; }
        public Nullable<int> ProductTypeID { get; set; }
        public int QtyOnHand { get; set; }
        public int UomLookupID { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GeneralMaterial> GeneralMaterials { get; set; }
        public virtual Lookup ProductType { get; set; }
        public virtual Lookup Color { get; set; }
        public virtual Lookup Uom { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
