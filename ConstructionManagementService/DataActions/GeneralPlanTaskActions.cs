using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using ConstructionManagementService.Models;

namespace ConstructionManagementService.DataActions
{
    public class GeneralPlanTaskActions : IActions<GeneralPlanTaskModel>
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();


        public IEnumerable<GeneralPlanTaskModel> Get(bool showInactive)
        {
            try
            {
                var generalPlanTasks = showInactive ? _dbContext.GeneralPlanTasks.ToList() :
                    _dbContext.GeneralPlanTasks.Where(p => p.IsActive).ToList();

                var generalPlanTasksModels = generalPlanTasks.Select(generalPlanTask => new GeneralPlanTaskModel
                {
                    Id = generalPlanTask.GenPlanTaskID,
                    PlanId = generalPlanTask.GenPlanID,
                    //Add GeneralPlanTask
                    TaskId = generalPlanTask.GenTaskID,
                    GeneralTask = new GeneralTaskModel
                    {
                        Id = generalPlanTask.GeneralTask.GenTaskID,
                        Name = generalPlanTask.GeneralTask.TaskName,
                        Description = generalPlanTask.GeneralTask.TaskDescription,
                        IsActive = generalPlanTask.GeneralTask.IsActive,
                        Created = generalPlanTask.GeneralTask.Created,
                        CreatedBy = generalPlanTask.GeneralTask.CreatedBy,
                        LastUpdated = generalPlanTask.GeneralTask.LastUpdated,
                        LastUpdatedBy = generalPlanTask.GeneralTask.LastUpdatedBy,
                    },
                    IsActive = generalPlanTask.IsActive,
                    Created = generalPlanTask.Created,
                    CreatedBy = generalPlanTask.CreatedBy,
                    LastUpdated = generalPlanTask.LastUpdated
                }).ToList();

                return generalPlanTasksModels;
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
        public GeneralPlanTaskModel GetById(int id)
        {
            try
            {
                var generalPlanTask = _dbContext.GeneralPlanTasks.Find(id);

                if (generalPlanTask != null)
                {
                    var generalPlanTaskModel = new GeneralPlanTaskModel()
                    {
                        Id = generalPlanTask.GenPlanTaskID,
                        PlanId = generalPlanTask.GenPlanID,
                        //Add GeneralPlanTask
                        TaskId = generalPlanTask.GenTaskID,
                        GeneralTask = new GeneralTaskModel
                        {
                            Id = generalPlanTask.GeneralTask.GenTaskID,
                            Name = generalPlanTask.GeneralTask.TaskName,
                            Description = generalPlanTask.GeneralTask.TaskDescription,
                            IsActive = generalPlanTask.GeneralTask.IsActive,
                            Created = generalPlanTask.GeneralTask.Created,
                            CreatedBy = generalPlanTask.GeneralTask.CreatedBy,
                            LastUpdated = generalPlanTask.GeneralTask.LastUpdated,
                            LastUpdatedBy = generalPlanTask.GeneralTask.LastUpdatedBy,
                        },
                        IsActive = generalPlanTask.IsActive,
                        Created = generalPlanTask.Created,
                        CreatedBy = generalPlanTask.CreatedBy,
                        LastUpdated = generalPlanTask.LastUpdated
                    };
                    return generalPlanTaskModel;
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

        public void Insert(GeneralPlanTaskModel modelObj, string user)
        {
            try
            {
                GeneralPlanTask newGeneralPlanTask = new GeneralPlanTask
                {
                    GenPlanTaskID = modelObj.Id,
                    GenPlanID = modelObj.PlanId,
                    GenTaskID = modelObj.TaskId,
                    IsActive = modelObj.IsActive,
                    Created = DateTime.Now,
                    CreatedBy = user,
                    LastUpdated = DateTime.Now,
                    LastUpdatedBy = user
                };

                _dbContext.GeneralPlanTasks.Add(newGeneralPlanTask);
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

        public void Update(GeneralPlanTaskModel modelObj, string user)
        {
            try
            {
                GeneralPlanTask updGeneralPlanTask = _dbContext.GeneralPlanTasks.Find(modelObj.Id);
                if (updGeneralPlanTask == null)
                {
                    return;
                }
                updGeneralPlanTask.GenPlanTaskID = modelObj.Id;
                updGeneralPlanTask.GenPlanID = modelObj.PlanId;
                updGeneralPlanTask.GenTaskID = modelObj.TaskId;
                updGeneralPlanTask.IsActive = modelObj.IsActive;
                updGeneralPlanTask.Created = modelObj.Created;
                updGeneralPlanTask.CreatedBy = modelObj.CreatedBy;
                updGeneralPlanTask.LastUpdated = DateTime.Now;
                updGeneralPlanTask.LastUpdatedBy = user;
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
                GeneralPlanTask delGeneralPlanTask = _dbContext.GeneralPlanTasks.Find(id);

                if (delGeneralPlanTask == null)
                {
                    return;
                }

                delGeneralPlanTask.IsActive = false;
                delGeneralPlanTask.LastUpdated = DateTime.Now;
                delGeneralPlanTask.LastUpdatedBy = user;
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

        public void Delete(int id, string user)
        {
            GeneralPlanTask delGeneralPlanTask = _dbContext.GeneralPlanTasks.FirstOrDefault(p => p.GenPlanTaskID == id);

            if (delGeneralPlanTask == null)
            {
                return;
            }

            _dbContext.Entry(delGeneralPlanTask).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }
    }
}