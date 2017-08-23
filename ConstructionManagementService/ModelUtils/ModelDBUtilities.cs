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


        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
