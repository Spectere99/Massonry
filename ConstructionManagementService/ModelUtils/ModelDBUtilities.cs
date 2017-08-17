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
                //VendorId = material.VendorLookupID,
                MaterialProduct = material.MaterialProduct,
                //Color = GetLookup(material.ColorLookupID),
                //CategoryId = material.CategoryLookupID,
                Quantity = material.Quantity,
                UomId = material.UomLookupID
            })
                .ToList();

            return generalMaterialsModelList;
        }
       public void Dispose()
        {
            if (_dbContext!=null)
            {
                _dbContext.Dispose();
            }

           
        }
    }
}
