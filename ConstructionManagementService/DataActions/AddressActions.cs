using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using ConstructionManagementService.Models;

namespace ConstructionManagementService.DataActions
{
    public class AddressActions : IActions<AddressModel>
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();

        public IEnumerable<AddressModel> Get(bool showInactive)
        {
            try
            {
                var addresses = showInactive ? _dbContext.Addresses.ToList() :
                    _dbContext.Addresses.Where(p => p.IsActive).ToList();

                var addressModels = addresses.Select(address => new AddressModel
                {
                    Id = address.Id,
                    Name = address.Name,
                    Address1 = address.Address1,
                    Address2 = address.Address2,
                    City = address.City,
                    State = address.State,
                    Zip = address.Zip,
                    IsActive = address.IsActive,
                    Created = address.Created,
                    CreatedBy = address.CreatedBy,
                    LastUpdated = address.LastUpdated,
                    LastUpdatedBy = address.LastUpdatedBy
                });

                return addressModels;
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

        public AddressModel GetById(int id)
        {
            try
            {
                var address = _dbContext.Addresses.Find(id);
                if (address != null)
                {
                    var addressModel = new AddressModel
                    {
                        Id = address.Id,
                        Name = address.Name,
                        Address1 = address.Address1,
                        Address2 = address.Address2,
                        City = address.City,
                        State = address.State,
                        Zip = address.Zip,
                        IsActive = address.IsActive,
                        Created = address.Created,
                        CreatedBy = address.CreatedBy,
                        LastUpdated = address.LastUpdated,
                        LastUpdatedBy = address.LastUpdatedBy
                    };
                    return addressModel;
                }
                return null;
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

        public void Insert(AddressModel modelObj, string user)
        {
            try
            {
                Address newAddress = new Address
                {
                    Id = modelObj.Id,
                    Name = modelObj.Name,
                    Address1 = modelObj.Address1,
                    Address2 = modelObj.Address2,
                    City = modelObj.City,
                    State = modelObj.State,
                    IsActive = true,
                    Created = DateTime.Now,
                    CreatedBy = user,
                    LastUpdated = DateTime.Now,
                    LastUpdatedBy = user
                };
                _dbContext.Addresses.Add(newAddress);
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

        public void Update(AddressModel modelObj, string user)
        {
            try
            {
                Address updAddress = _dbContext.Addresses.Find(modelObj.Id);
                if (updAddress == null)
                {
                    return;
                }
                updAddress.Id = modelObj.Id;
                updAddress.Name = modelObj.Name;
                updAddress.Address1 = modelObj.Address1;
                updAddress.Address2 = modelObj.Address2;
                updAddress.City = modelObj.City;
                updAddress.State = modelObj.State;
                updAddress.IsActive = modelObj.IsActive;
                updAddress.Created = modelObj.Created;
                updAddress.CreatedBy = modelObj.CreatedBy;
                updAddress.LastUpdated = DateTime.Now;
                updAddress.LastUpdatedBy = user;

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
                Address delAddress = _dbContext.Addresses.Find(id);

                if (delAddress == null)
                {
                    return;
                }

                delAddress.IsActive = false;
                delAddress.LastUpdated = DateTime.Now;
                delAddress.LastUpdatedBy = user;
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