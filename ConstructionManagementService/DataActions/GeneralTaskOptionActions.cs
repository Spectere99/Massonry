using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using ConstructionManagementService.Models;

namespace ConstructionManagementService.DataActions
{
    public class GeneralTaskOptionActions : IActions<GeneralTaskOptionModel>
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();

        public IEnumerable<GeneralTaskOptionModel> Get(bool showInactive)
        {
            try
            {
                var generalTaskOptions = showInactive
                    ? _dbContext.GeneralTaskOptions.ToList()
                    : _dbContext.GeneralTaskOptions.Where(p => p.IsActive).ToList();

                var generalTaskOptionModels = generalTaskOptions.Select(generalTaskOption => new GeneralTaskOptionModel
                {
                    Id = generalTaskOption.GenTaskOptionID,
                    TaskId = generalTaskOption.GenTaskID,
                    OptionLookupId = generalTaskOption.GenOptionLookupID,
                    TaskOptionLookup = new LookupModel
                    {
                        Id = generalTaskOption.Lookup.LookupID,
                        Value = generalTaskOption.Lookup.LookupValue,
                        LookupTypeId = generalTaskOption.Lookup.LookupTypeID,
                        LookupType = new LookupTypeModel
                        {
                            Id = generalTaskOption.Lookup.LookupType.LookupTypeID,
                            TypeDescription = generalTaskOption.Lookup.LookupType.LookupType1,
                            IsActive = generalTaskOption.Lookup.LookupType.IsActive,
                            Created = generalTaskOption.Lookup.LookupType.Created,
                            CreatedBy = generalTaskOption.Lookup.LookupType.CreatedBy,
                            LastUpdated = generalTaskOption.Lookup.LookupType.LastUpdated,
                            LastUpdatedBy = generalTaskOption.Lookup.LookupType.LastUpdatedBy
                        },
                        IsActive = generalTaskOption.Lookup.IsActive,
                        Created = generalTaskOption.Lookup.Created,
                        CreatedBy = generalTaskOption.Lookup.CreatedBy,
                        LastUpdated = generalTaskOption.Lookup.LastUpdated,
                        LastUpdatedBy = generalTaskOption.Lookup.LastUpdatedBy
                    },
                    IsActive = generalTaskOption.IsActive,
                    Created = generalTaskOption.Created,
                    CreatedBy = generalTaskOption.CreatedBy,
                    LastUpdated = generalTaskOption.LastUpdated,
                    LastUpdatedBy = generalTaskOption.LastUpdatedBy
                });

                return generalTaskOptionModels;
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

        public GeneralTaskOptionModel GetById(int id)
        {
            try
            {
                var generalTaskOption = _dbContext.GeneralTaskOptions.Find(id);

                if (generalTaskOption != null)
                {
                    var generalTaskOptionModel = new GeneralTaskOptionModel
                    {
                        Id = generalTaskOption.GenTaskOptionID,
                        TaskId = generalTaskOption.GenTaskID,
                        OptionLookupId = generalTaskOption.GenOptionLookupID,
                        TaskOptionLookup = new LookupModel
                        {
                            Id = generalTaskOption.Lookup.LookupID,
                            Value = generalTaskOption.Lookup.LookupValue,
                            LookupTypeId = generalTaskOption.Lookup.LookupTypeID,
                            LookupType = new LookupTypeModel
                            {
                                Id = generalTaskOption.Lookup.LookupType.LookupTypeID,
                                TypeDescription = generalTaskOption.Lookup.LookupType.LookupType1,
                                IsActive = generalTaskOption.Lookup.LookupType.IsActive,
                                Created = generalTaskOption.Lookup.LookupType.Created,
                                CreatedBy = generalTaskOption.Lookup.LookupType.CreatedBy,
                                LastUpdated = generalTaskOption.Lookup.LookupType.LastUpdated,
                                LastUpdatedBy = generalTaskOption.Lookup.LookupType.LastUpdatedBy
                            },
                            IsActive = generalTaskOption.Lookup.IsActive,
                            Created = generalTaskOption.Lookup.Created,
                            CreatedBy = generalTaskOption.Lookup.CreatedBy,
                            LastUpdated = generalTaskOption.Lookup.LastUpdated,
                            LastUpdatedBy = generalTaskOption.Lookup.LastUpdatedBy
                        },
                        IsActive = generalTaskOption.IsActive,
                        Created = generalTaskOption.Created,
                        CreatedBy = generalTaskOption.CreatedBy,
                        LastUpdated = generalTaskOption.LastUpdated,
                        LastUpdatedBy = generalTaskOption.LastUpdatedBy
                    };

                    return generalTaskOptionModel;
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

        public void Insert(GeneralTaskOptionModel modelObj, string user)
        {
            try
            {
                GeneralTaskOption newGeneralTaskOption = new GeneralTaskOption
                {
                    GenTaskOptionID = modelObj.Id,
                    GenTaskID = modelObj.TaskId,
                    GenOptionLookupID = modelObj.OptionLookupId,
                    IsActive = modelObj.IsActive,
                    Created = DateTime.Now,
                    CreatedBy = user,
                    LastUpdated = DateTime.Now,
                    LastUpdatedBy = user
                };

                _dbContext.GeneralTaskOptions.Add(newGeneralTaskOption);
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

        public void Update(GeneralTaskOptionModel modelObj, string user)
        {
            try
            {
                GeneralTaskOption updGeneralTaskOption = _dbContext.GeneralTaskOptions.Find(modelObj.Id);
                if (updGeneralTaskOption == null)
                {
                    return;
                }
                updGeneralTaskOption.GenTaskOptionID = modelObj.Id;
                updGeneralTaskOption.GenTaskID = modelObj.TaskId;
                updGeneralTaskOption.GenOptionLookupID = modelObj.OptionLookupId;
                updGeneralTaskOption.IsActive = modelObj.IsActive;
                updGeneralTaskOption.Created = DateTime.Now;
                updGeneralTaskOption.CreatedBy = user;
                updGeneralTaskOption.LastUpdated = DateTime.Now;
                updGeneralTaskOption.LastUpdatedBy = user;
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
                GeneralTaskOption delGeneralTaskOption = _dbContext.GeneralTaskOptions.Find(id);

                if (delGeneralTaskOption == null)
                {
                    return;
                }

                delGeneralTaskOption.IsActive = false;
                delGeneralTaskOption.LastUpdated = DateTime.Now;
                delGeneralTaskOption.LastUpdatedBy = user;
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