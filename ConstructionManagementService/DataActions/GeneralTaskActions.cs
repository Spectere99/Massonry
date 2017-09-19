using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using ConstructionManagementService.Models;

namespace ConstructionManagementService.DataActions
{
    public class GeneralTaskActions : IActions<GeneralTaskModel>
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();

        public IEnumerable<GeneralTaskModel> Get(bool showInactive)
        {
            try
            {
                var generalTasks = showInactive ? _dbContext.GeneralTasks.ToList() :
                    _dbContext.GeneralTasks.Where(p => p.IsActive).ToList();

                var generalTaskModels = generalTasks.Select(generalTask => new GeneralTaskModel
                {
                    Id = generalTask.GenTaskID,
                    Name = generalTask.TaskName,
                    Description = generalTask.TaskDescription,
                    Options = generalTask.GeneralTaskOptions.Select(option => new GeneralTaskOptionModelView()
                    {
                        Id = option.GenTaskOptionID,
                        OptionLookupId = option.GenOptionLookupID,
                        TaskId = option.GenTaskID,
                        TaskOptionLookup = new LookupModelView()
                        {
                            Id = option.Lookup.LookupID,
                            Value = option.Lookup.LookupValue,
                            LookupTypeValue = option.Lookup.LookupType.LookupType1                        
                        }
                    }).ToList(),
                    IsActive = generalTask.IsActive,
                    Created = generalTask.Created,
                    CreatedBy = generalTask.CreatedBy,
                    LastUpdated = generalTask.LastUpdated,
                    LastUpdatedBy = generalTask.LastUpdatedBy
                }).ToList();

                return generalTaskModels;
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

        public GeneralTaskModel GetById(int id)
        {
            try
            {
                var generalTask = _dbContext.GeneralTasks.Find(id);

                if (generalTask != null)
                {
                    var generalTaskModel = new GeneralTaskModel
                    {
                        Id = generalTask.GenTaskID,
                        Name = generalTask.TaskName,
                        Description = generalTask.TaskDescription,
                        IsActive = generalTask.IsActive,
                        Created = generalTask.Created,
                        CreatedBy = generalTask.CreatedBy,
                        LastUpdated = generalTask.LastUpdated,
                        LastUpdatedBy = generalTask.LastUpdatedBy
                    };

                    return generalTaskModel;
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

        public void Insert(GeneralTaskModel modelObj, string user)
        {
            GeneralTask newGeneralTask = new GeneralTask
            {
                GenTaskID = modelObj.Id,
                TaskName = modelObj.Name,
                TaskDescription = modelObj.Description,
                IsActive = modelObj.IsActive,
                Created = DateTime.Now,
                CreatedBy = user,
                LastUpdated = DateTime.Now,
                LastUpdatedBy = user
            };

            _dbContext.GeneralTasks.Add(newGeneralTask);
            _dbContext.SaveChanges();
        }

        public void Update(GeneralTaskModel modelObj, string user)
        {
            GeneralTask updGeneralTask = _dbContext.GeneralTasks.Find(modelObj.Id);
            if (updGeneralTask == null)
            {
                return;
            }
            updGeneralTask.TaskName = modelObj.Name;
            updGeneralTask.TaskDescription = modelObj.Description;
            updGeneralTask.IsActive = modelObj.IsActive;
            updGeneralTask.Created = DateTime.Now;
            updGeneralTask.CreatedBy = user;
            updGeneralTask.LastUpdated = DateTime.Now;
            updGeneralTask.LastUpdatedBy = user;
            _dbContext.SaveChanges();
        }

        public void Deactivate(int id, string user)
        {
            GeneralTask delGeneralTask = _dbContext.GeneralTasks.Find(id);

            if (delGeneralTask == null)
            {
                return;
            }

            delGeneralTask.IsActive = false;
            delGeneralTask.LastUpdated = DateTime.Now;
            delGeneralTask.LastUpdatedBy = user;
            _dbContext.SaveChanges();
        }
    }
}