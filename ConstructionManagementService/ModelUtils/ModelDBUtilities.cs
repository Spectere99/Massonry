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
                VendorId = material.VendorID,
                MaterialProduct = material.MaterialProduct,
                Color = new LookupModel()
                {
                    LookupId=material.Color.LookupID,
                    Value=material.Color.LookupValue,
                    LookupType = new LookupTypeModel()
                    {
                        LookupTypeId = material.Color.LookupType.LookupTypeID,
                        Type= material.Color.LookupType.LookupType1,
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
                Uom= new LookupModel()
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

        public LookupType GetDBLookupTypeById(int id)
        {
            var lookupType = _dbContext.LookupTypes.SingleOrDefault(p => p.LookupTypeID == id);

            return lookupType;
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
