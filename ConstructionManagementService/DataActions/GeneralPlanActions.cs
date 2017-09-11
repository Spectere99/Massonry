using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using ConstructionManagementService.Models;


namespace ConstructionManagementService.DataActions
{
    public class GeneralPlanActions : IActions<GeneralPlanModel>
    {
       private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();

        public IEnumerable<GeneralPlanModel> Get(bool showInactive)
        {
            try
            {
                var generalPlans = showInactive ? _dbContext.GeneralPlans.ToList() : _dbContext.GeneralPlans.Where(p => p.IsActive).ToList();

                var generalPlanModels = generalPlans.Select(generalPlan => new GeneralPlanModel
                {
                    Id = generalPlan.GenPlanID,
                    PlanName = generalPlan.PlanName,
                    ElevationLookupId = generalPlan.ElevationLookupID,
                    GarageTypeLookupId = generalPlan.GarageTypeLookupID,
                    IsActive = generalPlan.IsActive,
                    Created = generalPlan.Created,
                    CreatedBy = generalPlan.CreatedBy,
                    LastUpdated = generalPlan.LastUpdated,
                    LastUpdatedBy = generalPlan.LastUpdatedBy
                });
                

                return generalPlanModels;
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
        public GeneralPlanModel GetById(int id)

        {
            try
            {
                var generalPlan = _dbContext.GeneralPlans.Find(id);

                if (generalPlan != null)
                {
                    var generalPlanModel = new GeneralPlanModel()
                    {
                        Id = generalPlan.GenPlanID,
                        PlanName = generalPlan.PlanName,
                        ElevationLookupId = generalPlan.ElevationLookupID,
                        GarageTypeLookupId = generalPlan.GarageTypeLookupID,
                        IsActive = generalPlan.IsActive,
                        Created = generalPlan.Created,
                        CreatedBy = generalPlan.CreatedBy,
                        LastUpdated = generalPlan.LastUpdated,
                        LastUpdatedBy = generalPlan.LastUpdatedBy
                    };
                
                    return generalPlanModel;
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
            

        public void Insert(GeneralPlanModel generalPlanModel, string user)
        {

            GeneralPlan generalPlan = new GeneralPlan
            {
                
                GenPlanID= 0,
                PlanName = generalPlanModel.PlanName,
                ElevationLookupID = generalPlanModel.ElevationLookupId,
                GarageTypeLookupID = generalPlanModel.GarageTypeLookupId,
                IsActive = generalPlanModel.IsActive,
                Created = DateTime.Now,
                CreatedBy = user,
                LastUpdated = DateTime.Now,
                LastUpdatedBy = user

            };
            _dbContext.GeneralPlans.Add(generalPlan);
            _dbContext.SaveChanges();
        }

        public void Update(GeneralPlanModel generalPlanModel, string user)
        {
            GeneralPlan generalPlan = _dbContext.GeneralPlans.Find(generalPlanModel.Id);
            if (generalPlan == null)
            {
                return;
            }
            generalPlan.GenPlanID = generalPlanModel.Id;
            generalPlan.PlanName = generalPlanModel.PlanName;
            generalPlan.ElevationLookupID = generalPlanModel.ElevationLookupId;
            generalPlan.GarageTypeLookupID = generalPlanModel.GarageTypeLookupId;
            generalPlan.IsActive = generalPlanModel.IsActive;
            generalPlan.Created = generalPlanModel.Created;
            generalPlan.CreatedBy = generalPlanModel.CreatedBy;
            generalPlan.LastUpdated = DateTime.Now;
            generalPlan.LastUpdatedBy = user;
            _dbContext.SaveChanges();
        }
        public void Deactivate(int id, string user)
        {
            GeneralPlan generalPlan = _dbContext.GeneralPlans.Find(id);

            if (generalPlan == null)
            {
                return;
            }

            generalPlan.IsActive = false;
            generalPlan.LastUpdated = DateTime.Now;
            generalPlan.LastUpdatedBy = user;
            _dbContext.SaveChanges();
        }
    }

}
