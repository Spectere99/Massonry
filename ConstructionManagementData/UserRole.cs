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
    
    public partial class UserRole
    {
        public int UserRoleID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
    
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}