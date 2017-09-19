using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using ConstructionManagementService.Models;

namespace ConstructionManagementService.DataActions
{
    public class GeneralMaterialActions : IActions<GeneralMaterialModel>
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();

        public IEnumerable<GeneralMaterialModel> Get(bool showInactive)
        {
            try
            {
                var generalMaterials = showInactive ? _dbContext.GeneralMaterials.ToList() :
                                       _dbContext.GeneralMaterials.Where(p => p.IsActive).ToList();

                var generalMaterialsModels = generalMaterials.Select(material => new GeneralMaterialModel
                {
                    MaterialId = material.MaterialID,
                    VendorId = material.VendorID,
                    MaterialProduct = material.MaterialProduct,
                    ColorId = material.Color.LookupID,
                    Color = new LookupModel()
                    {
                        Id = material.Color.LookupID,
                        Value = material.Color.LookupValue,
                        LookupType = new LookupTypeModel()
                        {
                            Id = material.Color.LookupType.LookupTypeID,
                            TypeDescription = material.Color.LookupType.LookupType1,
                        }
                    },
                    materialTypeId=material.MaterialType.LookupID,
                    MaterialType = new LookupModel()
                    {
                        Id = material.MaterialType.LookupID,
                        Value = material.MaterialType.LookupValue,
                        LookupType = new LookupTypeModel()
                        {
                            Id = material.MaterialType.LookupType.LookupTypeID,
                            TypeDescription = material.MaterialType.LookupType.LookupType1,
                        }
                    },
                    Quantity = material.Quantity,
                    uomId=material.UOM.LookupID,
                    Uom = new LookupModel()
                    {
                        Id = material.UOM.LookupID,
                        Value = material.UOM.LookupValue,
                        LookupType = new LookupTypeModel()
                        {
                            Id = material.UOM.LookupType.LookupTypeID,
                            TypeDescription = material.UOM.LookupType.LookupType1,
                        }
                    
                    },
                    IsActive = material.IsActive,
                    Created = material.Created,
                    CreatedBy = material.CreatedBy,
                    LastUpdated = material.LastUpdated,
                    LastUpdatedBy = material.LastUpdatedBy
                })
                    .ToList();
                return generalMaterialsModels;
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

        public GeneralMaterialModel GetById(int id)
        {
            try
            {
                var generalMaterials = _dbContext.GeneralMaterials.Find(id);
                if (generalMaterials == null)
                {
                    return null;
                }
                var generalMaterialModel = new GeneralMaterialModel
                {
                    MaterialId = generalMaterials.MaterialID,
                    VendorId = generalMaterials.VendorID,
                    MaterialProduct = generalMaterials.MaterialProduct,
                    ColorId= generalMaterials.Color.LookupID,
                    Color = new LookupModel()
                    {
                        Id = generalMaterials.Color.LookupID,
                        Value = generalMaterials.Color.LookupValue,
                        LookupType = new LookupTypeModel()
                        {
                            Id = generalMaterials.Color.LookupType.LookupTypeID,
                            TypeDescription = generalMaterials.Color.LookupType.LookupType1,
                        }
                    },
                    materialTypeId= generalMaterials.MaterialType.LookupID,
                    MaterialType = new LookupModel()
                    {
                        Id = generalMaterials.MaterialType.LookupID,
                        Value = generalMaterials.MaterialType.LookupValue,
                        LookupType = new LookupTypeModel()
                        {
                            Id = generalMaterials.MaterialType.LookupType.LookupTypeID,
                            TypeDescription = generalMaterials.MaterialType.LookupType.LookupType1,
                        }
                    },
                    Quantity = generalMaterials.Quantity,
                    uomId=generalMaterials.UOM.LookupID,
                    Uom = new LookupModel()
                    {
                        Id = generalMaterials.UOM.LookupID,
                        Value = generalMaterials.UOM.LookupValue,
                        LookupType = new LookupTypeModel()
                        {
                            Id = generalMaterials.UOM.LookupType.LookupTypeID,
                            TypeDescription = generalMaterials.UOM.LookupType.LookupType1,
                        }
                    },
                    IsActive = generalMaterials.IsActive,
                    Created = generalMaterials.Created,
                    CreatedBy = generalMaterials.CreatedBy,
                    LastUpdated = generalMaterials.LastUpdated,
                    LastUpdatedBy = generalMaterials.LastUpdatedBy
                };
                return generalMaterialModel;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _dbContext.Dispose();
            }
        }

        public void Insert(GeneralMaterialModel generalMaterialModel, string user)
        {
            GeneralMaterial generalMaterial= new GeneralMaterial
            {
                MaterialID = 0,
                VendorID = generalMaterialModel.VendorId,
                MaterialProduct = generalMaterialModel.MaterialProduct,
                ColorLookupID = generalMaterialModel.ColorId,
                MaterialTypeLookupID = generalMaterialModel.materialTypeId,
                Quantity = generalMaterialModel.Quantity,
                UomLookupID = generalMaterialModel.uomId,
                IsActive = true,
                Created = DateTime.Now,
                CreatedBy = user,
                LastUpdated = DateTime.Now,
                LastUpdatedBy = user

            };
            _dbContext.GeneralMaterials.Add(generalMaterial);
            _dbContext.SaveChanges();
        }

        public void Update(GeneralMaterialModel generalMaterialModel, string user)
        {
            GeneralMaterial generalMaterial = _dbContext.GeneralMaterials.Find(generalMaterialModel.MaterialId);
            if (generalMaterial==null)
           {
                return;
           }

            generalMaterial.VendorID = generalMaterialModel.VendorId;
            generalMaterial.MaterialProduct = generalMaterialModel.MaterialProduct;
            generalMaterial.ColorLookupID = generalMaterialModel.ColorId;
            generalMaterial.MaterialTypeLookupID = generalMaterialModel.materialTypeId;
            generalMaterial.Quantity = generalMaterialModel.Quantity;
            generalMaterial.UomLookupID = generalMaterialModel.uomId;
            generalMaterial.IsActive = generalMaterialModel.IsActive;
            generalMaterial.LastUpdated = DateTime.Now;
            generalMaterial.LastUpdatedBy = user;
            _dbContext.SaveChanges();
        }

        public void Deactivate(int id, string user)
        {
            GeneralMaterial generalMaterial = _dbContext.GeneralMaterials.Find(id);

            if(generalMaterial == null)
            {
                return;
            }

            generalMaterial.IsActive = false;
            generalMaterial.LastUpdated = DateTime.Now;
            generalMaterial.LastUpdatedBy = user;
            _dbContext.SaveChanges();
        }
    }
}