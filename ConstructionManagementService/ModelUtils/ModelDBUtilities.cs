using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementService.Models;
using ConstructionManagementData;

namespace ConstructionManagementService.ModelUtils
{
    public class ModelDBUtilities:IDisposable 
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();

        public LookupType GetLookupTypeById(int id)
        {
            var lookupType = _dbContext.LookupTypes.SingleOrDefault(p => p.LookupTypeID == id);
            return lookupType;
        }

        public void InsertLookupType(LookupTypeModel lookupTypeModel, string user)
        {
            LookupType lookupType = new LookupType
            {
                LookupTypeID = 0,
                LookupType1 = lookupTypeModel.Type,
                LastUpdated = DateTime.Now,
                LastUpdatedBy = user
            };

            _dbContext.LookupTypes.Add(lookupType);
            _dbContext.SaveChanges();

        }
        public void UpdateLookupType(LookupTypeModel lookupTypeModel, string user)
        {
            LookupType lookupType = _dbContext.LookupTypes.Find(lookupTypeModel.LookupTypeId);
            if (lookupType == null)
            {
                return;
            }

            lookupType.LookupType1 = lookupTypeModel.Type;
            lookupType.LastUpdated = DateTime.Now;
            lookupType.LastUpdatedBy = user;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
