using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using ConstructionManagementService.Models;

namespace ConstructionManagementService.DataActions
{
    public class GeneralSubTaskActions : IActions<GeneralSubTaskModel>
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();


        public IEnumerable<GeneralSubTaskModel> Get(bool showInactive)
        {
            try
            { 
                var generalSubtasks = showInactive ? _dbContext.GeneralSubTasks.ToList() :
                    _dbContext.GeneralSubTasks.Where(p => p.IsActive).ToList();

                var generalSubtasksModels = generalSubtasks.Select(generalSubtask => new GeneralSubTaskModel
                {  Id = generalSubtask.GenSubTaskID,
                    Name = generalSubtask.SubTaskName,
                    Description = generalSubtask.SubTaskDescription,
                    IsActive = generalSubtask.IsActive,
                    Created = generalSubtask.Created,
                    CreatedBy = generalSubtask.CreatedBy,
                    LastUpdated = generalSubtask.LastUpdated
                }).ToList();

                return generalSubtasksModels;
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
        public GeneralSubTaskModel GetById(int id)
        {
            try
            {
                var generalSubTask = _dbContext.GeneralSubTasks.Find(id);

                if (generalSubTask != null)
                {
                    var generalSubTaskModel = new GeneralSubTaskModel
                    {
                        Id = generalSubTask.GenSubTaskID,
                        Name = generalSubTask.SubTaskName,
                        Description = generalSubTask.SubTaskDescription,
                        IsActive = generalSubTask.IsActive,
                        Created = generalSubTask.Created,
                        CreatedBy = generalSubTask.CreatedBy,
                        LastUpdated = generalSubTask.LastUpdated,
                        LastUpdatedBy = generalSubTask.LastUpdatedBy
                    };
                    return generalSubTaskModel;
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

        public void Insert(GeneralSubTaskModel modelObj, string user)
        {
            try
            {
                GeneralSubTask newGeneralSubTask = new GeneralSubTask
                {
                    GenSubTaskID = modelObj.Id,
                    SubTaskName = modelObj.Name,
                    SubTaskDescription = modelObj.Description,
                    IsActive = modelObj.IsActive,
                    Created = DateTime.Now,
                    CreatedBy = user,
                    LastUpdated = DateTime.Now,
                    LastUpdatedBy = user
                };

                _dbContext.GeneralSubTasks.Add(newGeneralSubTask);
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

        public void Update(GeneralSubTaskModel modelObj, string user)
        {
            try
            {
                GeneralSubTask updGeneralSubTask = _dbContext.GeneralSubTasks.Find(modelObj.Id);
                if (updGeneralSubTask == null)
                {
                    return;
                }
                updGeneralSubTask.SubTaskName = modelObj.Name;
                updGeneralSubTask.SubTaskDescription = modelObj.Description;
                updGeneralSubTask.IsActive = modelObj.IsActive;
                updGeneralSubTask.Created = DateTime.Now;
                updGeneralSubTask.CreatedBy = user;
                updGeneralSubTask.LastUpdated = DateTime.Now;
                updGeneralSubTask.LastUpdatedBy = user;
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
                GeneralSubTask delGeneralSubTask = _dbContext.GeneralSubTasks.Find(id);

                if (delGeneralSubTask == null)
                {
                    return;
                }

                delGeneralSubTask.IsActive = false;
                delGeneralSubTask.LastUpdated = DateTime.Now;
                delGeneralSubTask.LastUpdatedBy = user;
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