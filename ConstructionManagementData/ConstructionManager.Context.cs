﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ConstructionManagerEntities : DbContext
    {
        public ConstructionManagerEntities()
            : base("name=ConstructionManagerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Lookup> Lookups { get; set; }
        public virtual DbSet<LookupType> LookupTypes { get; set; }
        public virtual DbSet<GeneralMaterial> GeneralMaterials { get; set; }
        public virtual DbSet<GeneralPlan> GeneralPlans { get; set; }
        public virtual DbSet<GeneralPlanTask> GeneralPlanTasks { get; set; }
        public virtual DbSet<GeneralSubTask> GeneralSubTasks { get; set; }
        public virtual DbSet<GeneralTaskMaterial> GeneralTaskMaterials { get; set; }
        public virtual DbSet<GeneralTaskOption> GeneralTaskOptions { get; set; }
        public virtual DbSet<GeneralTask> GeneralTasks { get; set; }
        public virtual DbSet<GeneralTaskSubTask> GeneralTaskSubTasks { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
    }
}
