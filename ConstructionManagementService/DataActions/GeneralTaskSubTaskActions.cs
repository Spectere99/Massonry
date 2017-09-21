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

        public void Insert(GeneralTaskSubTaskModel generalTaskSubTaskModel, string user)
        {

            GeneralTaskSubTask generalTaskSubTask = new GeneralTaskSubTask
            {
                GenTaskSubTaskID= 0,
                GenTaskID = generalTaskSubTaskModel.TaskId,
                GenSubTaskID = generalTaskSubTaskModel.SubTaskId,
                GeneralSubTask =
                IsActive = generalTaskSubTask.IsActive,
                Created = generalTaskSubTask.Created,
                CreatedBy = generalTaskSubTask.CreatedBy,
                LastUpdated = generalTaskSubTask.LastUpdated,
                LastUpdatedBy = generalTaskSubTask.LastUpdatedBy
            };

            _dbContext.GeneralTaskMaterials.Add(generalTaskMaterial);
            _dbContext.SaveChanges();
        }


        public void Update(GeneralTaskSubTaskModel generalTaskMaterialModel, string user)
        {
            GeneralTaskMaterial generalTaskMaterial = _dbContext.GeneralTaskMaterials.Find(generalTaskMaterialModel.Id); ; if (generalTaskMaterial == null)
            {
                return;
            }
            generalTaskMaterial.GenTaskMaterialID = generalTaskMaterialModel.Id;
            generalTaskMaterial.GenTaskID = generalTaskMaterialModel.TaskId;
            generalTaskMaterial.IsActive = generalTaskMaterialModel.IsActive;
            generalTaskMaterial.Created = generalTaskMaterialModel.Created;
            generalTaskMaterial.CreatedBy = generalTaskMaterialModel.CreatedBy;
            generalTaskMaterial.LastUpdated = DateTime.Now;
            generalTaskMaterial.LastUpdatedBy = user;
            _dbContext.SaveChanges();
        }


        public void Deactivate(int id, string user)
        {
            GeneralTaskMaterial generalTaskMaterial = _dbContext.GeneralTaskMaterials.Find(id);

            if (generalTaskMaterial == null)
            {
                return;
            }

            generalTaskMaterial.IsActive = false;
            generalTaskMaterial.LastUpdated = DateTime.Now;
            generalTaskMaterial.LastUpdatedBy = user;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}