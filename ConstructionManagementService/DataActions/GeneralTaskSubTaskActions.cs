using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using ConstructionManagementService.Models;

namespace ConstructionManagementService.DataActions
{
    public class GeneralTaskSubTaskActions : IActions<GeneralTaskSubTaskModel>, IDisposable
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();


        public IEnumerable<GeneralTaskSubTaskModel> Get(bool showInactive)
        {
            try
            {
                var generalTaskSubTasks = showInactive ? _dbContext.GeneralTaskSubTasks.ToList() : _dbContext.GeneralTaskSubTasks.Where(p => p.IsActive).ToList();

                var generalTaskSubTaskModels = generalTaskSubTasks.Select(generalTaskSubTask => new GeneralTaskSubTaskModel
                {
                    Id = generalTaskSubTask.GenTaskSubTaskID,
                    TaskId = generalTaskSubTask.GenTaskID,
                    GeneralTask = new GeneralTaskModel
                    {
                        Id = generalTaskSubTask.GeneralTask.GenTaskID,
                        Name = generalTaskSubTask.GeneralTask.TaskName,
                        Description = generalTaskSubTask.GeneralTask.TaskDescription,
                        Options = generalTaskSubTask.GeneralTask.GeneralTaskOptions.Select(option => new GeneralTaskOptionModelView()
                        {
                            Id = option.GenTaskOptionID,
                            OptionLookupId = option.GenOptionLookupID,
                            TaskId = option.GenTaskID,
                            TaskOptionLookup = new LookupModelView()
                            {
                                Id = option.Lookup.LookupID,
                                Value = option.Lookup.LookupValue,
                                LookupTypeId = option.Lookup.LookupTypeID,
                                LookupTypeValue = option.Lookup.LookupType.LookupType1
                            }
                        }).ToList(),
                    }, 
                    SubTaskId = generalTaskSubTask.GenTaskSubTaskID,
                    GeneralSubTask = new GeneralSubTaskModel()
                    {
                        Id = generalTaskSubTask.GeneralSubTask.GenSubTaskID,
                        Name = generalTaskSubTask.GeneralSubTask.SubTaskName,
                        Description = generalTaskSubTask.GeneralSubTask.SubTaskDescription,
                        IsActive = generalTaskSubTask.GeneralSubTask.IsActive,
                        Created = generalTaskSubTask.GeneralSubTask.Created,
                        CreatedBy = generalTaskSubTask.GeneralSubTask.CreatedBy,
                        LastUpdated = generalTaskSubTask.GeneralSubTask.LastUpdated
                    },
                    IsActive = generalTaskSubTask.IsActive,
                    Created = generalTaskSubTask.Created,
                    CreatedBy = generalTaskSubTask.CreatedBy,
                    LastUpdated = generalTaskSubTask.LastUpdated,
                    LastUpdatedBy = generalTaskSubTask.LastUpdatedBy
                });


                return generalTaskSubTaskModels;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public GeneralTaskSubTaskModel GetById(int id)
        {

            try
            {
                var generalTaskSubTask = _dbContext.GeneralTaskSubTasks.Find(id);

                if (generalTaskSubTask == null)
                {
                    return null;
                }
                var generalTaskSubTaskModel = new GeneralTaskSubTaskModel()
                {
                    Id = generalTaskSubTask.GenTaskSubTaskID,
                    TaskId = generalTaskSubTask.GenTaskID,
                    SubTaskId = generalTaskSubTask.GenTaskSubTaskID,
                    GeneralSubTask = new GeneralSubTaskModel()
                    {
                        Id = generalTaskSubTask.GeneralSubTask.GenSubTaskID,
                        Name = generalTaskSubTask.GeneralSubTask.SubTaskName,
                        Description= generalTaskSubTask.GeneralSubTask.SubTaskDescription,
                        IsActive = generalTaskSubTask.GeneralSubTask.IsActive,
                        Created = generalTaskSubTask.GeneralSubTask.Created,
                        CreatedBy = generalTaskSubTask.GeneralSubTask.CreatedBy,
                        LastUpdated = generalTaskSubTask.GeneralSubTask.LastUpdated
                    },
                    IsActive = generalTaskSubTask.IsActive,
                    Created = generalTaskSubTask.Created,
                    CreatedBy = generalTaskSubTask.CreatedBy,
                    LastUpdated = generalTaskSubTask.LastUpdated,
                    LastUpdatedBy = generalTaskSubTask.LastUpdatedBy
                };

                return generalTaskSubTaskModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insert(GeneralTaskSubTaskModel modelObj, string user)
        {

            GeneralTaskSubTask generalTaskSubTask = new GeneralTaskSubTask
            {
                GenTaskSubTaskID= 0,
                GenTaskID = modelObj.TaskId,
                GenSubTaskID = modelObj.SubTaskId,
                IsActive = modelObj.IsActive,
                Created = DateTime.Now,
                CreatedBy = user,
                LastUpdated = DateTime.Now,
                LastUpdatedBy = user,
            };

            _dbContext.GeneralTaskSubTasks.Add(generalTaskSubTask);
            _dbContext.SaveChanges();
        }


        public void Update(GeneralTaskSubTaskModel modelObj, string user)
        {
            GeneralTaskSubTask generalTaskSubTask = _dbContext.GeneralTaskSubTasks.Find(modelObj.Id);
            if (generalTaskSubTask == null)
            {
                return;
            }
            
            generalTaskSubTask.GenTaskID = modelObj.TaskId;
            generalTaskSubTask.GenSubTaskID = modelObj.SubTaskId;
            generalTaskSubTask.IsActive = modelObj.IsActive;
            generalTaskSubTask.LastUpdated = DateTime.Now;
            generalTaskSubTask.LastUpdatedBy = user;
            _dbContext.SaveChanges();
        }


        public void Deactivate(int id, string user)
        {
            GeneralTaskSubTask generalTaskSubTask = _dbContext.GeneralTaskSubTasks.Find(id);

            if (generalTaskSubTask == null)
            {
                return;
            }

            generalTaskSubTask.IsActive = false;
            generalTaskSubTask.LastUpdated = DateTime.Now;
            generalTaskSubTask.LastUpdatedBy = user;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}