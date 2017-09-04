using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using ConstructionManagementService.Models;

namespace SIMSService.DataActions
{
    public class RoleActions
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();

        public RoleActions()
        { }

        public IEnumerable<RoleModel> Get(bool showInactive)
        {
            try
            {
                var roles = showInactive ? _dbContext.Roles.ToList() :
                    _dbContext.Roles.Where(p => p.IsActive).ToList();
                var roleModels = roles.Select(role => new RoleModel
                {
                    Id = role.RoleID,
                    Role = role.Role1,
                    PermissionId = role.PermissionID,
                    Permission = new PermissionModel
                    {
                      Id = role.Permission.PermissionID,
                      Permission  = role.Permission.Permission1,
                      PermissionModuleKey = role.Permission.PermissionModuleKey,
                      CanAccess = role.Permission.CanAccess,
                      CanUpdate = role.Permission.CanUpdate,
                      CanDelete = role.Permission.CanDelete,
                      IsActive = role.Permission.IsActive,
                      Created = role.Permission.Created,
                      CreatedBy = role.Permission.CreatedBy,
                      LastUpdated = role.Permission.LastUpdated,
                      LastUpdatedBy = role.Permission.LastUpdatedBy
                    },
                    IsActive = role.IsActive,
                    Created = role.Created,
                    CreatedBy = role.CreatedBy,
                    LastUpdated = role.LastUpdated,
                    LastUpdatedBy = role.LastUpdatedBy
                }).ToList();

                return roleModels;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _dbContext.Dispose();
            }

        }
        public RoleModel GetById(int id)
        {
            try
            {
                var role = _dbContext.Roles.Find(id);
                if (role == null)
                {
                    return null;
                }
                var roleModel = new RoleModel
                {
                    Id = role.RoleID,
                    Role = role.Role1,
                    PermissionId = role.PermissionID,
                    Permission = new PermissionModel
                    {
                        Id = role.Permission.PermissionID,
                        Permission = role.Permission.Permission1,
                        PermissionModuleKey = role.Permission.PermissionModuleKey,
                        CanAccess = role.Permission.CanAccess,
                        CanUpdate = role.Permission.CanUpdate,
                        CanDelete = role.Permission.CanDelete,
                        IsActive = role.Permission.IsActive,
                        Created = role.Permission.Created,
                        CreatedBy = role.Permission.CreatedBy,
                        LastUpdated = role.Permission.LastUpdated,
                        LastUpdatedBy = role.Permission.LastUpdatedBy
                    },
                    IsActive = role.IsActive,
                    Created = role.Created,
                    CreatedBy = role.CreatedBy,
                    LastUpdated = role.LastUpdated,
                    LastUpdatedBy = role.LastUpdatedBy
                };

                return roleModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _dbContext.Dispose();
            }
        }
        public void Insert(RoleModel roleModel, string user)
        {
            Role newRole = new Role
            {
                RoleID = roleModel.Id,
                Role1 = roleModel.Role,
                PermissionID = roleModel.PermissionId,
                IsActive = roleModel.IsActive,
                Created = DateTime.Now,
                CreatedBy = user,
                LastUpdated = DateTime.Now,
                LastUpdatedBy = user
            };

            _dbContext.Roles.Add(newRole);
            _dbContext.SaveChanges();
        }
        public void Update(RoleModel roleModel, string user)
        {
            Role updRole = _dbContext.Roles.Find(roleModel.Id);
            if (updRole == null)
            {
                return;
            }

            updRole.RoleID = roleModel.Id;
            updRole.Role1 = roleModel.Role;
            updRole.PermissionID = roleModel.PermissionId;
            updRole.IsActive = roleModel.IsActive;
            updRole.Created = DateTime.Now;
            updRole.CreatedBy = user;
            updRole.LastUpdated = DateTime.Now;
            updRole.LastUpdatedBy = user;
            _dbContext.SaveChanges();
        }
        public void Deactivate(int id, string user)
        {
            Role delRole = _dbContext.Roles.Find(id);

            if (delRole == null)
            {
                return;
            }

            delRole.IsActive = false;
            delRole.LastUpdated = DateTime.Now;
            delRole.LastUpdatedBy = user;
            _dbContext.SaveChanges();

        }
    }
}