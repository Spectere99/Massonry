using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using ConstructionManagementService.Models;

namespace ConstructionManagementService.DataActions
{
    public class LookupTypeActions
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();

        public IEnumerable<LookupTypeModel> Get(bool showInactive)
        {
            try
            {
                var lookupTypes = showInactive ? _dbContext.LookupTypes.ToList() :
                    _dbContext.LookupTypes.Where(p => p.IsActive).ToList();

                var lookupTypeModels = lookupTypes.Select(lookupType => new LookupTypeModel
                {
                    Id = lookupType.LookupTypeID,
                    TypeDescription = lookupType.LookupType1,
                    IsActive = lookupType.IsActive
                }).ToList();

                return lookupTypeModels;
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
        public LookupTypeModel GetById(int id)
        {
            try
            {
                var lookupType = _dbContext.LookupTypes.Find(id);
                var lookupTypeModel = new LookupTypeModel
                {
                    Id = lookupType.LookupTypeID,
                    TypeDescription = lookupType.LookupType1
                };

                return lookupTypeModel;
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
        public void Insert(LookupTypeModel lookupTypeModel, string user)
        {
            LookupType lookupType = new LookupType
            {
                LookupTypeID = 0,
                LookupType1 = lookupTypeModel.TypeDescription,
                IsActive = lookupTypeModel.IsActive,
                Created = DateTime.Now,
                CreatedBy = user,
                LastUpdated = DateTime.Now,
                LastUpdatedBy = user
            };

            _dbContext.LookupTypes.Add(lookupType);
            _dbContext.SaveChanges();

        }
        public void Update(LookupTypeModel lookupTypeModel, string user)
        {
            LookupType lookupType = _dbContext.LookupTypes.Find(lookupTypeModel.Id);
            if (lookupType == null)
            {
                return;
            }

            lookupType.LookupType1 = lookupTypeModel.TypeDescription;
            lookupType.IsActive = lookupTypeModel.IsActive;
            lookupType.LastUpdated = DateTime.Now;
            lookupType.LastUpdatedBy = user;
            _dbContext.SaveChanges();
        }
        public void Deactivate(int id, string user)
        {
            LookupType lookupType = _dbContext.LookupTypes.Find(id);

            if (lookupType == null)
            {
                return;
            }

            lookupType.IsActive = false;
            lookupType.LastUpdated = DateTime.Now;
            lookupType.LastUpdatedBy = user;
            _dbContext.SaveChanges();

        }
    }
}