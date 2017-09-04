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
        #region Private Variables
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();
        #endregion

        #region LookupType Functions
        public void InsertLookupType(LookupTypeModel lookupTypeModel, string user)
        {
            LookupType lookupType = new LookupType
            {
                LookupTypeID = 0,
                LookupType1 = lookupTypeModel.TypeDescription,
                LastUpdated = DateTime.Now,
                LastUpdatedBy = user
            };

            _dbContext.LookupTypes.Add(lookupType);
            _dbContext.SaveChanges();

        }
        public void UpdateLookupType(LookupTypeModel lookupTypeModel, string user)
        {
            LookupType lookupType = _dbContext.LookupTypes.Find(lookupTypeModel.Id);
            if (lookupType == null)
            {
                return;
            }

            lookupType.LookupType1 = lookupTypeModel.TypeDescription;
            lookupType.LastUpdated = DateTime.Now;
            lookupType.LastUpdatedBy = user;
            _dbContext.SaveChanges();
        }
        #endregion
        #region Lookup Functions

        #endregion
        #region User Functions

        #endregion
        #region Role Functions

        #endregion
        #region Permission Functions

        #endregion  
        #region GeneralMaterial Functions
        public void InsertGeneralMaterial(GeneralMaterialModel generalMaterialModel, string user)
        {
            GeneralMaterial genMaterial = new GeneralMaterial
            {
                MaterialID = 0,
                MaterialProduct = generalMaterialModel.MaterialProduct,
                Quantity = generalMaterialModel.Quantity,
                MaterialTypeLookupID = generalMaterialModel.MaterialType.Id,
                UomLookupID = generalMaterialModel.Uom.Id,
                ColorLookupID = generalMaterialModel.Color.Id,
                VendorID = generalMaterialModel.VendorId,
                LastUpdated = DateTime.Now,
                LastUpdatedBy = user
            };

            _dbContext.GeneralMaterials.Add(genMaterial);
            _dbContext.SaveChanges();
        }
        #endregion

        #region Clean-up Functions
        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
        #endregion
    }
}
