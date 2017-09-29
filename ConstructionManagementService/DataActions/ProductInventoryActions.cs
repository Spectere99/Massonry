using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using ConstructionManagementService.Models;

namespace ConstructionManagementService.DataActions
{
    public class ProductInventoryActions : IActions<ProductInventoryModel>, IDisposable
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();

        public IEnumerable<ProductInventoryModel> Get(bool showInactive)
        {
            try
            {
                var productInventories = showInactive ? _dbContext.ProductInventories.ToList() :
                    _dbContext.ProductInventories.Where(p => p.IsActive).ToList();

                var generalMaterialsModels = productInventories.Select(productInventory => new ProductInventoryModel
                    {
                        Id = productInventory.ProductInventoryID,
                        Product = productInventory.Product,
                        ProductCode = productInventory.ProductCode,
                        VendorId = productInventory.VendorID,
                        Vendor = new VendorModel
                        {
                            Id = productInventory.Vendor.VendorID,
                            Name = productInventory.Vendor.VendorName,
                            ShippingAddressId = productInventory.Vendor.ShippingAddressId ?? -1,
                            ShippingAddress = productInventory.Vendor.ShippingAddress != null ? new AddressModel
                            {
                                Id = productInventory.Vendor.ShippingAddress.Id,
                                Name = productInventory.Vendor.ShippingAddress.Name,
                                Address1 = productInventory.Vendor.ShippingAddress.Address1,
                                Address2 = productInventory.Vendor.ShippingAddress.Address2,
                                City = productInventory.Vendor.ShippingAddress.City,
                                State = productInventory.Vendor.ShippingAddress.State,
                                Zip = productInventory.Vendor.ShippingAddress.Zip,
                                IsActive = productInventory.Vendor.ShippingAddress.IsActive,
                                Created = productInventory.Vendor.ShippingAddress.Created,
                                CreatedBy = productInventory.Vendor.ShippingAddress.CreatedBy,
                                LastUpdated = productInventory.Vendor.ShippingAddress.LastUpdated,
                                LastUpdatedBy = productInventory.Vendor.ShippingAddress.LastUpdatedBy
                            } : null,
                            BillingAddressId = productInventory.Vendor.BillingAddressId ?? -1,
                            BillingAddress = productInventory.Vendor.BillingAddress != null ? new AddressModel
                            {
                                Id = productInventory.Vendor.BillingAddress.Id,
                                Name = productInventory.Vendor.BillingAddress.Name,
                                Address1 = productInventory.Vendor.BillingAddress.Address1,
                                Address2 = productInventory.Vendor.BillingAddress.Address2,
                                City = productInventory.Vendor.BillingAddress.City,
                                State = productInventory.Vendor.BillingAddress.State,
                                Zip = productInventory.Vendor.BillingAddress.Zip,
                                IsActive = productInventory.Vendor.BillingAddress.IsActive,
                                Created = productInventory.Vendor.BillingAddress.Created,
                                CreatedBy = productInventory.Vendor.BillingAddress.CreatedBy,
                                LastUpdated = productInventory.Vendor.BillingAddress.LastUpdated,
                                LastUpdatedBy = productInventory.Vendor.BillingAddress.LastUpdatedBy
                            } : null,
                            IsActive = productInventory.Vendor.IsActive,
                            Created = productInventory.Vendor.Created,
                            CreatedBy = productInventory.Vendor.CreatedBy,
                            LastUpdated = productInventory.Vendor.LastUpdated,
                            LastUpdatedBy = productInventory.Vendor.LastUpdatedBy
                        },
                        ColorId = productInventory.Color.LookupID,
                        Color = new LookupModelView()
                        {
                            Id = productInventory.Color.LookupID,
                            Value = productInventory.Color.LookupValue,
                            LookupTypeId = productInventory.Color.LookupTypeID,
                            LookupTypeValue = productInventory.Color.LookupType.LookupType1
                        },
                        ProductTypeId = productInventory.ProductTypeID ?? -1,
                        ProductType = new LookupModelView()
                        {
                            Id = productInventory.ProductType.LookupID,
                            Value = productInventory.ProductType.LookupValue,
                            LookupTypeId = productInventory.ProductType.LookupTypeID,
                            LookupTypeValue = productInventory.ProductType.LookupType.LookupType1
                        },
                        QtyOnHand = productInventory.QtyOnHand,
                        UomId = productInventory.Uom.LookupID,
                        Uom = new LookupModelView()
                        {
                            Id = productInventory.Uom.LookupID,
                            Value = productInventory.Uom.LookupValue,
                            LookupTypeId = productInventory.Uom.LookupTypeID,
                            LookupTypeValue = productInventory.Uom.LookupType.LookupType1

                        },
                        IsActive = productInventory.IsActive,
                        Created = productInventory.Created,
                        CreatedBy = productInventory.CreatedBy,
                        LastUpdated = productInventory.LastUpdated,
                        LastUpdatedBy = productInventory.LastUpdatedBy
                    }).ToList();
                return generalMaterialsModels;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ProductInventoryModel GetById(int id)
        {
            try
            {
                var productInventory = _dbContext.ProductInventories.Find(id);
                if (productInventory == null)
                {
                    return null;
                }
                var productInventoryModel = new ProductInventoryModel()
                {
                    Id = productInventory.ProductInventoryID,
                    Product = productInventory.Product,
                    ProductCode = productInventory.ProductCode,
                    VendorId = productInventory.VendorID,
                    Vendor = new VendorModel
                    {
                        Id = productInventory.Vendor.VendorID,
                        Name = productInventory.Vendor.VendorName,
                        ShippingAddressId = productInventory.Vendor.ShippingAddressId ?? -1,
                        ShippingAddress = productInventory.Vendor.ShippingAddress != null ? new AddressModel
                        {
                            Id = productInventory.Vendor.ShippingAddress.Id,
                            Name = productInventory.Vendor.ShippingAddress.Name,
                            Address1 = productInventory.Vendor.ShippingAddress.Address1,
                            Address2 = productInventory.Vendor.ShippingAddress.Address2,
                            City = productInventory.Vendor.ShippingAddress.City,
                            State = productInventory.Vendor.ShippingAddress.State,
                            Zip = productInventory.Vendor.ShippingAddress.Zip,
                            IsActive = productInventory.Vendor.ShippingAddress.IsActive,
                            Created = productInventory.Vendor.ShippingAddress.Created,
                            CreatedBy = productInventory.Vendor.ShippingAddress.CreatedBy,
                            LastUpdated = productInventory.Vendor.ShippingAddress.LastUpdated,
                            LastUpdatedBy = productInventory.Vendor.ShippingAddress.LastUpdatedBy
                        } : null,
                        BillingAddressId = productInventory.Vendor.BillingAddressId ?? -1,
                        BillingAddress = productInventory.Vendor.BillingAddress != null ? new AddressModel
                        {
                            Id = productInventory.Vendor.BillingAddress.Id,
                            Name = productInventory.Vendor.BillingAddress.Name,
                            Address1 = productInventory.Vendor.BillingAddress.Address1,
                            Address2 = productInventory.Vendor.BillingAddress.Address2,
                            City = productInventory.Vendor.BillingAddress.City,
                            State = productInventory.Vendor.BillingAddress.State,
                            Zip = productInventory.Vendor.BillingAddress.Zip,
                            IsActive = productInventory.Vendor.BillingAddress.IsActive,
                            Created = productInventory.Vendor.BillingAddress.Created,
                            CreatedBy = productInventory.Vendor.BillingAddress.CreatedBy,
                            LastUpdated = productInventory.Vendor.BillingAddress.LastUpdated,
                            LastUpdatedBy = productInventory.Vendor.BillingAddress.LastUpdatedBy
                        } : null,
                        IsActive = productInventory.Vendor.IsActive,
                        Created = productInventory.Vendor.Created,
                        CreatedBy = productInventory.Vendor.CreatedBy,
                        LastUpdated = productInventory.Vendor.LastUpdated,
                        LastUpdatedBy = productInventory.Vendor.LastUpdatedBy
                    },
                    ColorId = productInventory.Color.LookupID,
                    Color = new LookupModelView()
                    {
                        Id = productInventory.Color.LookupID,
                        Value = productInventory.Color.LookupValue,
                        LookupTypeId = productInventory.Color.LookupTypeID,
                        LookupTypeValue = productInventory.Color.LookupValue
                    },
                    ProductTypeId = productInventory.ProductTypeID ?? -1,
                    ProductType = new LookupModelView()
                    {
                        Id = productInventory.ProductType.LookupID,
                        Value = productInventory.ProductType.LookupValue,
                        LookupTypeId = productInventory.ProductType.LookupTypeID,
                        LookupTypeValue = productInventory.ProductType.LookupValue
                    },
                    QtyOnHand = productInventory.QtyOnHand,
                    UomId = productInventory.Uom.LookupID,
                    Uom = new LookupModelView()
                    {
                        Id = productInventory.Uom.LookupID,
                        Value = productInventory.Uom.LookupValue,
                        LookupTypeId = productInventory.Uom.LookupTypeID,
                        LookupTypeValue = productInventory.Uom.LookupValue

                    },
                    IsActive = productInventory.IsActive,
                    Created = productInventory.Created,
                    CreatedBy = productInventory.CreatedBy,
                    LastUpdated = productInventory.LastUpdated,
                    LastUpdatedBy = productInventory.LastUpdatedBy
                };
                return productInventoryModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insert(ProductInventoryModel modelObj, string user)
        {
            try
            {
                ProductInventory productInventory = new ProductInventory
                {
                    ProductInventoryID = 0,
                    Product = modelObj.Product,
                    ProductCode = modelObj.ProductCode,
                    VendorID = modelObj.VendorId,
                    ColorLookupID = modelObj.ColorId,
                    ProductTypeID = modelObj.ProductTypeId,
                    QtyOnHand = modelObj.QtyOnHand,
                    UomLookupID = modelObj.UomId,
                    IsActive = true,
                    Created = DateTime.Now,
                    CreatedBy = user,
                    LastUpdated = DateTime.Now,
                    LastUpdatedBy = user
                };
                _dbContext.ProductInventories.Add(productInventory);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(ProductInventoryModel modelObj, string user)
        {
            try
            {
                 ProductInventory productInventory = _dbContext.ProductInventories.Find(modelObj.Id);
                if (productInventory == null)
                {
                    return;
                }
                productInventory.Product = modelObj.Product;
                productInventory.ProductCode = modelObj.ProductCode;
                productInventory.VendorID = modelObj.VendorId;
                productInventory.ColorLookupID = modelObj.ColorId;
                productInventory.ProductTypeID = modelObj.ProductTypeId;
                productInventory.QtyOnHand = modelObj.QtyOnHand;
                productInventory.UomLookupID = modelObj.UomId;
                productInventory.IsActive = modelObj.IsActive;
                productInventory.LastUpdated = DateTime.Now;
                productInventory.LastUpdatedBy = user;
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Deactivate(int id, string user)
        {
            try
            {
                ProductInventory productInventory = _dbContext.ProductInventories.Find(id);

                if (productInventory == null)
                {
                    return;
                }

                productInventory.IsActive = false;
                productInventory.LastUpdated = DateTime.Now;
                productInventory.LastUpdatedBy = user;
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}