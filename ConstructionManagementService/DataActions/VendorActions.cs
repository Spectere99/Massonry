using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using ConstructionManagementService.Models;

namespace ConstructionManagementService.DataActions
{
    public class VendorActions : IActions<VendorModel>
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();

        public IEnumerable<VendorModel> Get(bool showInactive)
        {
            try
            {
                var vendors = showInactive ? _dbContext.Vendors.ToList() :
                    _dbContext.Vendors.Where(p => p.IsActive).ToList();

                var vendorModels = vendors.Select(vendor => new VendorModel
                {
                    Id = vendor.VendorID,
                    Name = vendor.VendorName,
                    IsActive = vendor.IsActive,
                    Created = vendor.Created,
                    CreatedBy = vendor.CreatedBy,
                    LastUpdated = vendor.LastUpdated,
                    LastUpdatedBy = vendor.LastUpdatedBy
                    
                }).ToList();

                return vendorModels;
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

        public VendorModel GetById(int id)
        {
            try
            {
                var vendor = _dbContext.Vendors.Find(id);
                if (vendor == null)
                {
                    return null;
                }
                var vendorModel = new VendorModel
                {
                    Id = vendor.VendorID,
                    Name = vendor.VendorName,
                    IsActive = vendor.IsActive,
                    Created = vendor.Created,
                    CreatedBy = vendor.CreatedBy,
                    LastUpdated = vendor.LastUpdated,
                    LastUpdatedBy = vendor.LastUpdatedBy
                };

                return vendorModel;
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

        public void Insert(VendorModel modelObj, string user)
        {
            try
            {
                Vendor vendor = new Vendor
                {
                    VendorID = 0,
                    VendorName = modelObj.Name,
                    IsActive = modelObj.IsActive,
                    Created = DateTime.Now,
                    CreatedBy = user,
                    LastUpdated = DateTime.Now,
                    LastUpdatedBy = user
                };

                _dbContext.Vendors.Add(vendor);
                _dbContext.SaveChanges();
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

        public void Update(VendorModel modelObj, string user)
        {
            try
            {
                Vendor vendor = _dbContext.Vendors.Find(modelObj.Id);
                if (vendor == null)
                {
                    return;
                }

                vendor.VendorID = modelObj.Id;
                vendor.VendorName = modelObj.Name;
                vendor.IsActive = modelObj.IsActive;
                vendor.LastUpdated = DateTime.Now;
                vendor.LastUpdatedBy = user;
                _dbContext.SaveChanges();
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

        public void Deactivate(int id, string user)
        {
            try
            {
                Vendor vendor = _dbContext.Vendors.Find(id);

                if (vendor == null)
                {
                    return;
                }

                vendor.IsActive = false;
                vendor.LastUpdated = DateTime.Now;
                vendor.LastUpdatedBy = user;
                _dbContext.SaveChanges();
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
    }
}