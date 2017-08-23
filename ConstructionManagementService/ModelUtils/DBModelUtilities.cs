using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementService.Models;
using ConstructionManagementData;

namespace ConstructionManagementService.ModelUtils
{
    public class DBModelUtilities:IDisposable 
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();
        public IEnumerable<LookupTypeModel> GetLookupTypes()
        {
            var lookups = _dbContext.LookupTypes.ToList();
            List<LookupTypeModel> lookupModel = lookups.Select(lookup => new LookupTypeModel
                {
                    LookupTypeId = lookup.LookupTypeID,
                    Type = lookup.LookupType1
                })
                .ToList();

            return lookupModel;
        }
        public IEnumerable<GeneralMaterialModel> GetMaterials()
        {
            var generalMaterials = _dbContext.GeneralMaterials.ToList();
            List<GeneralMaterialModel> generalMaterialsModelList = generalMaterials.Select(material => new GeneralMaterialModel
                {
                    MaterialId = material.MaterialID,
                    VendorId = material.VendorID,
                    MaterialProduct = material.MaterialProduct,
                    Color = new LookupModel()
                    {
                        LookupId = material.Color.LookupID,
                        Value = material.Color.LookupValue,
                        LookupType = new LookupTypeModel()
                        {
                            LookupTypeId = material.Color.LookupType.LookupTypeID,
                            Type = material.Color.LookupType.LookupType1,
                        }
                    },
                    MaterialType = new LookupModel()
                    {
                        LookupId = material.MaterialType.LookupID,
                        Value = material.MaterialType.LookupValue,
                        LookupType = new LookupTypeModel()
                        {
                            LookupTypeId = material.MaterialType.LookupType.LookupTypeID,
                            Type = material.MaterialType.LookupType.LookupType1,
                        }
                    },
                    Quantity = material.Quantity,
                    Uom = new LookupModel()
                    {
                        LookupId = material.UOM.LookupID,
                        Value = material.UOM.LookupValue,
                        LookupType = new LookupTypeModel()
                        {
                            LookupTypeId = material.UOM.LookupType.LookupTypeID,
                            Type = material.UOM.LookupType.LookupType1,
                        }
                    },
                })
                .ToList();

            return generalMaterialsModelList;
        }
        public LookupModel GetLookupById(int id)
        {
            var lookups = _dbContext.Lookups.SingleOrDefault(p => p.LookupID == id);
            if (lookups != null)
            {
                LookupModel lookup = new LookupModel()
                {
                    LookupId = lookups.LookupID,
                    Value = lookups.LookupValue,
                    LookupType = new LookupTypeModel()
                    {
                        LookupTypeId = lookups.LookupType.LookupTypeID,
                        Type = lookups.LookupType.LookupType1
                    }
                };
                return lookup;
            }
            return null;
        }
        public IEnumerable<LookupModel> GetLookups()
        {
            var lookups = _dbContext.Lookups.ToList();
            List<LookupModel> lookupModel = lookups.Select(lookup => new LookupModel
            {
                LookupId = lookup.LookupID,
                Value = lookup.LookupValue,
                LookupType = new LookupTypeModel()
                {
                    LookupTypeId = lookup.LookupType.LookupTypeID,
                    Type = lookup.LookupType.LookupType1
                }
            }).ToList();

            return lookupModel;
        }
        public IEnumerable<LookupModel> GetLookupByTypeId(int id)
        {
            var lookups = _dbContext.Lookups.Where(p => p.LookupType.LookupTypeID == id).ToList();
            List<LookupModel> lookupModel = lookups.Select(lookup => new LookupModel
            {
                LookupId = lookup.LookupID,
                Value = lookup.LookupValue,
                LookupType = new LookupTypeModel()
                {
                    LookupTypeId = lookup.LookupType.LookupTypeID,
                    Type = lookup.LookupType.LookupType1
                }
            }).ToList();

            return lookupModel;
        }

        #region Security
        public IEnumerable<PermissionModel> GetPermissions()
        {
            var permissions = _dbContext.Permissions.ToList();
            List<PermissionModel> permissionModels = permissions.Select(permission => new PermissionModel()
            {
                PermissionId = permission.PermissionID,
                Permission = permission.Permission1,
                ModuleKeyId = permission.PermissionModuleKey,
                CanAccess = permission.CanAcceess,
                CanUpdate = permission.CanUpdate,
                CanDelete = permission.CanDelete,
                LastUpdated = permission.LastUpdated
            }).ToList();

            return permissionModels;
        }
        public IEnumerable<RoleModel> GetRoles()
        {
            var roles = _dbContext.Roles.ToList();
            List<RoleModel> roleModels = roles.Select(role => new RoleModel
            {
                RoleId = role.RoleID,
                Role = role.Role1,
                Permission = new PermissionModel()
                {
                    PermissionId = role.Permission.PermissionID,
                    Permission = role.Permission.Permission1,
                    CanAccess = role.Permission.CanAcceess,
                    CanUpdate = role.Permission.CanUpdate,
                    CanDelete = role.Permission.CanDelete,
                    LastUpdated = role.Permission.LastUpdated
                }
            }).ToList();

            return roleModels;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            var users = _dbContext.Users.ToList();
            List<UserModel> userModels = users.Select(user => new UserModel
            {
                UserId = user.UserID,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ContactNumber = user.ContactNumber,
                LastUpdated = user.LastUpdated,
                Roles = user.UserRoles.Select(role => new RoleModel
                {
                    RoleId = role.Role.RoleID,
                    Role = role.Role.Role1,
                    LastUpdated = role.Role.LastUpdated,
                    Permission = new PermissionModel()
                    {
                        PermissionId = role.Role.Permission.PermissionID,
                        Permission = role.Role.Permission.Permission1,
                        CanAccess = role.Role.Permission.CanAcceess,
                        CanUpdate = role.Role.Permission.CanUpdate,
                        CanDelete = role.Role.Permission.CanDelete,
                        ModuleKeyId = role.Role.Permission.PermissionModuleKey,
                        LastUpdated = role.Role.Permission.LastUpdated
                    }
                }).ToList()
            }).ToList();

            return userModels;
        }
        public UserModel GetUserById(int id)
        {
            var users = _dbContext.Users.SingleOrDefault(p => p.UserID == id);
            if (users != null)
            {
                var user = new UserModel()
                {
                    UserId = users.UserID,
                    UserName = users.UserName,
                    FirstName = users.FirstName,
                    LastName = users.LastName,
                    Email = users.Email,
                    ContactNumber = users.ContactNumber,
                    LastUpdated = users.LastUpdated,
                    Roles = users.UserRoles.Select(role => new RoleModel
                    {
                        RoleId = role.Role.RoleID,
                        Role = role.Role.Role1,
                        LastUpdated = role.Role.LastUpdated,
                        Permission = new PermissionModel()
                        {
                            PermissionId = role.Role.Permission.PermissionID,
                            Permission = role.Role.Permission.Permission1,
                            CanAccess = role.Role.Permission.CanAcceess,
                            CanUpdate = role.Role.Permission.CanUpdate,
                            CanDelete = role.Role.Permission.CanDelete,
                            ModuleKeyId = role.Role.Permission.PermissionModuleKey,
                            LastUpdated = role.Role.Permission.LastUpdated
                        }
                    }).ToList()
                };
                return user;
            }
            return null;
        }
        #endregion


        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }



        }
    }
}
