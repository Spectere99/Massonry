using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using ConstructionManagementService.Models;

namespace ConstructionManagementService.DataActions
{
    public class GeneralTaskMaterialActions : IActions<GeneralTaskMaterialModel>, IDisposable
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();


        public IEnumerable<GeneralTaskMaterialModel> Get(bool showInactive)
        {
            try
            {
                var generalTaskMaterials = showInactive ? _dbContext.GeneralTaskMaterials.ToList() : _dbContext.GeneralTaskMaterials.Where(p => p.IsActive).ToList();

                var generalTaskMaterialModels = generalTaskMaterials.Select(generalTaskMaterial => new GeneralTaskMaterialModel
                {
                    Id = generalTaskMaterial.GenTaskMaterialID,
                    TaskId = generalTaskMaterial.GenTaskID,
                    IsActive = generalTaskMaterial.IsActive,
                    Created = generalTaskMaterial.Created,
                    CreatedBy = generalTaskMaterial.CreatedBy,
                    LastUpdated = generalTaskMaterial.LastUpdated,
                    LastUpdatedBy = generalTaskMaterial.LastUpdatedBy
                });


                return generalTaskMaterialModels;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public GeneralTaskMaterialModel GetById(int id)
        {

            try
            {
                var generalTaskMaterial = _dbContext.GeneralTaskMaterials.Find(id);

                if (generalTaskMaterial == null)
                {
                    return null;
                }
                var generalTaskMaterialModel = new GeneralTaskMaterialModel()
                {
                    Id = generalTaskMaterial.GenTaskMaterialID,
                    TaskId = generalTaskMaterial.GenTaskID,
                    IsActive = generalTaskMaterial.IsActive,
                    Created = generalTaskMaterial.Created,
                    CreatedBy = generalTaskMaterial.CreatedBy,
                    LastUpdated = generalTaskMaterial.LastUpdated,
                    LastUpdatedBy = generalTaskMaterial.LastUpdatedBy
                };

                return generalTaskMaterialModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Insert(GeneralTaskMaterialModel generalTaskMaterialModel, string user)
        {

            GeneralTaskMaterial generalTaskMaterial = new GeneralTaskMaterial
            {
                GenTaskMaterialID = 0,
                GenTaskID = generalTaskMaterialModel.TaskId,
                IsActive = generalTaskMaterialModel.IsActive,
                Created = DateTime.Now,
                CreatedBy = generalTaskMaterialModel.CreatedBy,
                LastUpdated = DateTime.Now,
                LastUpdatedBy = user
            };

            _dbContext.GeneralTaskMaterials.Add(generalTaskMaterial);
            _dbContext.SaveChanges();
        }


        public void Update(GeneralTaskMaterialModel generalTaskMaterialModel, string user)
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
   
