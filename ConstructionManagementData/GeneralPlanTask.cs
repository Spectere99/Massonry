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
    
    public partial class GeneralPlanTask
    {
        public int GenPlanTaskID { get; set; }
        public int GenPlanID { get; set; }
        public int GenTaskID { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
    
        public virtual GeneralPlan GeneralPlan { get; set; }
        public virtual GeneralTask GeneralTask { get; set; }
    }
}