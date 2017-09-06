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
                    TaskSubTasks = generalTask.GeneralTaskSubTasks.Select(genSubTask => new GeneralTaskSubTaskModel
                    {
                        Id = genSubTask.GenTaskSubTaskID,
                        GeneralSubTask = new GeneralSubTaskModel
                        {
                            
                        }
                    })

                    IsActive = generalTask.IsActive,
                    Created = generalTask.Created,
                    CreatedBy = generalTask.CreatedBy,
                    LastUpdated = generalTask.LastUpdated,
                    LastUpdatedBy = generalTask.LastUpdatedBy
                }).ToList();

                return genergalTaskModels;
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
            throw new NotImplementedException();
        }

        public void Insert(GeneralTaskModel modelObj, string userId)
        {
            throw new NotImplementedException();
        }

        public void Update(GeneralTaskModel modelObj, string userId)
        {
            throw new NotImplementedException();
        }

        public void Deactivate(int id, string userId)
        {
            throw new NotImplementedException();
        }
    }
}