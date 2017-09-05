using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using ConstructionManagementService.Models;

namespace ConstructionManagementService.DataActions
{
    public class LookupActions
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();

        public LookupActions()
        {

        }

        public IEnumerable<LookupModel> Get(bool showInactive)
        {
            try
            {
                var lookups = showInactive ? _dbContext.Lookups.ToList() :
                    _dbContext.Lookups.Where(p => p.IsActive).ToList();
                var lookupModels = lookups.Select(lookup => new LookupModel
                {
                    Id = lookup.LookupID,
                    Value = lookup.LookupValue,
                    LookupType = new LookupTypeModel
                    {
                        Id = lookup.LookupType.LookupTypeID,
                        TypeDescription = lookup.LookupType.LookupType1,
                        IsActive = lookup.LookupType.IsActive
                    },
                    LookupTypeId = lookup.LookupTypeID,
                    IsActive = lookup.IsActive
                }).ToList();

                return lookupModels;
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
        public LookupModel GetById(int id)
        {
            try
            {
                var lookup = _dbContext.Lookups.Find(id);
                var lookupModel = new LookupModel
                {
                    Id = lookup.LookupID,
                    Value = lookup.LookupValue,
                    LookupTypeId = lookup.LookupTypeID,
                    LookupType = new LookupTypeModel()
                    {
                        Id = lookup.LookupType.LookupTypeID,
                        TypeDescription = lookup.LookupType.LookupType1
                    }

                };

                return lookupModel;
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
        public void Insert(LookupModel lookupModel, string user)
        {
            Lookup lookup = new Lookup
            {
                LookupID = 0,
                LookupValue = lookupModel.Value,
                LookupTypeID = lookupModel.LookupTypeId,
                IsActive = lookupModel.IsActive,
                Created = DateTime.Now,
                CreatedBy = user,
                LastUpdated = DateTime.Now,
                LastUpdatedBy = user
            };

            _dbContext.Lookups.Add(lookup);
            _dbContext.SaveChanges();
        }
        public void Update(LookupModel lookupModel, string user)
        {
            Lookup lookup = _dbContext.Lookups.Find(lookupModel.Id);
            if (lookup == null)
            {
                return;
            }

            lookup.LookupValue = lookupModel.Value;
            lookup.LookupTypeID = lookupModel.LookupTypeId;
            lookup.IsActive = lookupModel.IsActive;
            lookup.LastUpdated = DateTime.Now;
            lookup.LastUpdatedBy = user;
            _dbContext.SaveChanges();
        }
        public void Deactivate(int id, string user)
        {
            Lookup lookup = _dbContext.Lookups.Find(id);

            if (lookup == null)
            {
                return;
            }

            lookup.IsActive = false;
            lookup.LastUpdated = DateTime.Now;
            lookup.LastUpdatedBy = user;
            _dbContext.SaveChanges();
        }
    }
}