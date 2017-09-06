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


        public void Deactivate(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GeneralSubTaskModel> Get(bool showInactive)
        {
            try { 
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
            throw new NotImplementedException();
        }

        public void Insert(GeneralSubTaskModel modelObj, string userId)
        {
            throw new NotImplementedException();
        }

        public void Update(GeneralSubTaskModel modelObj, string userId)
        {
            throw new NotImplementedException();
        }
    }
}