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
                    ProductInventoryId = material.ProductInventoryID,
                    ProductInventory = new ProductInventoryModel
                    {
                        Id = material.ProductInventory.ProductInventoryID,
                        Product = material.ProductInventory.Product,
                        ProductCode = material.ProductInventory.ProductCode,
                        VendorId = material.ProductInventory.VendorID,
                        Vendor = new VendorModel
                        {
                            Id = material.ProductInventory.Vendor.VendorID,
                            Name = material.ProductInventory.Vendor.VendorName,
                            ShippingAddressId = material.ProductInventory.Vendor.ShippingAddressId ?? -1,
                            ShippingAddress = material.ProductInventory.Vendor.ShippingAddress != null ? new AddressModel
                            {
                                Id = material.ProductInventory.Vendor.ShippingAddress.Id,
                                Name = material.ProductInventory.Vendor.ShippingAddress.Name,
                                Address1 = material.ProductInventory.Vendor.ShippingAddress.Address1,
                                Address2 = material.ProductInventory.Vendor.ShippingAddress.Address2,
                                City = material.ProductInventory.Vendor.ShippingAddress.City,
                                State = material.ProductInventory.Vendor.ShippingAddress.State,
                                Zip = material.ProductInventory.Vendor.ShippingAddress.Zip,
                                IsActive = material.ProductInventory.Vendor.ShippingAddress.IsActive,
                                Created = material.ProductInventory.Vendor.ShippingAddress.Created,
                                CreatedBy = material.ProductInventory.Vendor.ShippingAddress.CreatedBy,
                                LastUpdated = material.ProductInventory.Vendor.ShippingAddress.LastUpdated,
                                LastUpdatedBy = material.ProductInventory.Vendor.ShippingAddress.LastUpdatedBy
                            } : null,
                            BillingAddressId = material.ProductInventory.Vendor.BillingAddressId ?? -1,
                            BillingAddress = material.ProductInventory.Vendor.BillingAddress != null ? new AddressModel
                            {
                                Id = material.ProductInventory.Vendor.BillingAddress.Id,
                                Name = material.ProductInventory.Vendor.BillingAddress.Name,
                                Address1 = material.ProductInventory.Vendor.BillingAddress.Address1,
                                Address2 = material.ProductInventory.Vendor.BillingAddress.Address2,
                                City = material.ProductInventory.Vendor.BillingAddress.City,
                                State = material.ProductInventory.Vendor.BillingAddress.State,
                                Zip = material.ProductInventory.Vendor.BillingAddress.Zip,
                                IsActive = material.ProductInventory.Vendor.BillingAddress.IsActive,
                                Created = material.ProductInventory.Vendor.BillingAddress.Created,
                                CreatedBy = material.ProductInventory.Vendor.BillingAddress.CreatedBy,
                                LastUpdated = material.ProductInventory.Vendor.BillingAddress.LastUpdated,
                                LastUpdatedBy = material.ProductInventory.Vendor.BillingAddress.LastUpdatedBy
                            } : null,
                            IsActive = material.ProductInventory.Vendor.IsActive,
                            Created = material.ProductInventory.Vendor.Created,
                            CreatedBy = material.ProductInventory.Vendor.CreatedBy,
                            LastUpdated = material.ProductInventory.Vendor.LastUpdated,
                            LastUpdatedBy = material.ProductInventory.Vendor.LastUpdatedBy
                        },
                        ColorId = material.ProductInventory.Color.LookupID,
                        Color = new LookupModelView()
                        {
                            Id = material.ProductInventory.Color.LookupID,
                            Value = material.ProductInventory.Color.LookupValue,
                            LookupTypeId = material.ProductInventory.Color.LookupTypeID,
                            LookupTypeValue = material.ProductInventory.Color.LookupValue
                        },
                        ProductTypeId = material.ProductInventory.ProductTypeID ?? -1,
                        ProductType = new LookupModelView()
                        {
                            Id = material.ProductInventory.ProductType.LookupID,
                            Value = material.ProductInventory.ProductType.LookupValue,
                            LookupTypeId = material.ProductInventory.ProductType.LookupTypeID,
                            LookupTypeValue = material.ProductInventory.ProductType.LookupValue
                        },
                        QtyOnHand = material.ProductInventory.QtyOnHand,
                        UomId = material.ProductInventory.Uom.LookupID,
                        Uom = new LookupModelView()
                        {
                            Id = material.ProductInventory.Uom.LookupID,
                            Value = material.ProductInventory.Uom.LookupValue,
                            LookupTypeId = material.ProductInventory.Uom.LookupTypeID,
                            LookupTypeValue = material.ProductInventory.Uom.LookupValue

                        },
                        IsActive = material.ProductInventory.IsActive,
                        Created = material.ProductInventory.Created,
                        CreatedBy = material.ProductInventory.CreatedBy,
                        LastUpdated = material.ProductInventory.LastUpdated,
                        LastUpdatedBy = material.ProductInventory.LastUpdatedBy
                    },
                    RequiredQuantity=material.RequiredQuantity,
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
                var generalMaterialModel = new GeneralMaterialModel()
                {
                   
                    MaterialId = generalMaterials.MaterialID,
                    ProductInventoryId = generalMaterials.ProductInventoryID,
                    ProductInventory = new ProductInventoryModel
                    {
                        Id = generalMaterials.ProductInventory.ProductInventoryID,
                        Product = generalMaterials.ProductInventory.Product,
                        ProductCode = generalMaterials.ProductInventory.ProductCode,
                        VendorId = generalMaterials.ProductInventory.VendorID,
                        Vendor = new VendorModel
                        {
                            Id = generalMaterials.ProductInventory.Vendor.VendorID,
                            Name = generalMaterials.ProductInventory.Vendor.VendorName,
                            ShippingAddressId = generalMaterials.ProductInventory.Vendor.ShippingAddressId ?? -1,
                            ShippingAddress = generalMaterials.ProductInventory.Vendor.ShippingAddress != null ? new AddressModel
                            {
                                Id = generalMaterials.ProductInventory.Vendor.ShippingAddress.Id,
                                Name = generalMaterials.ProductInventory.Vendor.ShippingAddress.Name,
                                Address1 = generalMaterials.ProductInventory.Vendor.ShippingAddress.Address1,
                                Address2 = generalMaterials.ProductInventory.Vendor.ShippingAddress.Address2,
                                City = generalMaterials.ProductInventory.Vendor.ShippingAddress.City,
                                State = generalMaterials.ProductInventory.Vendor.ShippingAddress.State,
                                Zip = generalMaterials.ProductInventory.Vendor.ShippingAddress.Zip,
                                IsActive = generalMaterials.ProductInventory.Vendor.ShippingAddress.IsActive,
                                Created = generalMaterials.ProductInventory.Vendor.ShippingAddress.Created,
                                CreatedBy = generalMaterials.ProductInventory.Vendor.ShippingAddress.CreatedBy,
                                LastUpdated = generalMaterials.ProductInventory.Vendor.ShippingAddress.LastUpdated,
                                LastUpdatedBy = generalMaterials.ProductInventory.Vendor.ShippingAddress.LastUpdatedBy
                            } : null,
                            BillingAddressId = generalMaterials.ProductInventory.Vendor.BillingAddressId ?? -1,
                            BillingAddress = generalMaterials.ProductInventory.Vendor.BillingAddress != null ? new AddressModel
                            {
                                Id = generalMaterials.ProductInventory.Vendor.BillingAddress.Id,
                                Name = generalMaterials.ProductInventory.Vendor.BillingAddress.Name,
                                Address1 = generalMaterials.ProductInventory.Vendor.BillingAddress.Address1,
                                Address2 = generalMaterials.ProductInventory.Vendor.BillingAddress.Address2,
                                City = generalMaterials.ProductInventory.Vendor.BillingAddress.City,
                                State = generalMaterials.ProductInventory.Vendor.BillingAddress.State,
                                Zip = generalMaterials.ProductInventory.Vendor.BillingAddress.Zip,
                                IsActive = generalMaterials.ProductInventory.Vendor.BillingAddress.IsActive,
                                Created = generalMaterials.ProductInventory.Vendor.BillingAddress.Created,
                                CreatedBy = generalMaterials.ProductInventory.Vendor.BillingAddress.CreatedBy,
                                LastUpdated = generalMaterials.ProductInventory.Vendor.BillingAddress.LastUpdated,
                                LastUpdatedBy = generalMaterials.ProductInventory.Vendor.BillingAddress.LastUpdatedBy
                            } : null,
                            IsActive = generalMaterials.ProductInventory.Vendor.IsActive,
                            Created = generalMaterials.ProductInventory.Vendor.Created,
                            CreatedBy = generalMaterials.ProductInventory.Vendor.CreatedBy,
                            LastUpdated = generalMaterials.ProductInventory.Vendor.LastUpdated,
                            LastUpdatedBy = generalMaterials.ProductInventory.Vendor.LastUpdatedBy
                        },
                        ColorId = generalMaterials.ProductInventory.Color.LookupID,
                        Color = new LookupModelView()
                        {
                            Id = generalMaterials.ProductInventory.Color.LookupID,
                            Value = generalMaterials.ProductInventory.Color.LookupValue,
                            LookupTypeId = generalMaterials.ProductInventory.Color.LookupTypeID,
                            LookupTypeValue = generalMaterials.ProductInventory.Color.LookupValue
                        },
                        ProductTypeId = generalMaterials.ProductInventory.ProductTypeID ?? -1,
                        ProductType = new LookupModelView()
                        {
                            Id = generalMaterials.ProductInventory.ProductType.LookupID,
                            Value = generalMaterials.ProductInventory.ProductType.LookupValue,
                            LookupTypeId = generalMaterials.ProductInventory.ProductType.LookupTypeID,
                            LookupTypeValue = generalMaterials.ProductInventory.ProductType.LookupValue
                        },
                        QtyOnHand = generalMaterials.ProductInventory.QtyOnHand,
                        UomId = generalMaterials.ProductInventory.Uom.LookupID,
                        Uom = new LookupModelView()
                        {
                            Id = generalMaterials.ProductInventory.Uom.LookupID,
                            Value = generalMaterials.ProductInventory.Uom.LookupValue,
                            LookupTypeId = generalMaterials.ProductInventory.Uom.LookupTypeID,
                            LookupTypeValue = generalMaterials.ProductInventory.Uom.LookupValue

                        },
                        IsActive = generalMaterials.ProductInventory.IsActive,
                        Created = generalMaterials.ProductInventory.Created,
                        CreatedBy = generalMaterials.ProductInventory.CreatedBy,
                        LastUpdated = generalMaterials.ProductInventory.LastUpdated,
                        LastUpdatedBy = generalMaterials.ProductInventory.LastUpdatedBy
                    },
                    RequiredQuantity= generalMaterials.RequiredQuantity,
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
                ProductInventoryID = generalMaterialModel.ProductInventoryId,
                RequiredQuantity = generalMaterialModel.RequiredQuantity,
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

            generalMaterial.ProductInventoryID = generalMaterialModel.ProductInventoryId;
            generalMaterial.RequiredQuantity = generalMaterialModel.RequiredQuantity;
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