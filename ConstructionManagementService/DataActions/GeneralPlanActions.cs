using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using ConstructionManagementService.Models;


namespace ConstructionManagementService.DataActions
{
    public class GeneralPlanActions : IActions<GeneralPlanModel>, IDisposable
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
                    Elevation = new LookupModel()
                    {
                        Id = generalPlan.Elevation.LookupID,
                        Value = generalPlan.Elevation.LookupValue,
                        LookupType = new LookupTypeModel()
                        {
                            Id = generalPlan.Elevation.LookupType.LookupTypeID,
                            TypeDescription = generalPlan.Elevation.LookupType.LookupType1,
                            IsActive = generalPlan.Elevation.LookupType.IsActive,
                            Created = generalPlan.Elevation.LookupType.Created,
                            CreatedBy = generalPlan.Elevation.LookupType.CreatedBy,
                            LastUpdated = generalPlan.Elevation.LookupType.LastUpdated,
                            LastUpdatedBy = generalPlan.Elevation.LookupType.LastUpdatedBy
                        }
                    },
                    GarageTypeLookupId = generalPlan.GarageTypeLookupID,
                    GarageType = new LookupModel()
                    {
                        Id = generalPlan.GarageType.LookupID,
                        Value = generalPlan.GarageType.LookupValue,
                        LookupType = new LookupTypeModel()
                        {
                            Id = generalPlan.GarageType.LookupType.LookupTypeID,
                            TypeDescription = generalPlan.GarageType.LookupType.LookupType1,
                            IsActive = generalPlan.GarageType.LookupType.IsActive,
                            Created = generalPlan.GarageType.LookupType.Created,
                            CreatedBy = generalPlan.GarageType.LookupType.CreatedBy,
                            LastUpdated = generalPlan.GarageType.LookupType.LastUpdated,
                            LastUpdatedBy = generalPlan.GarageType.LookupType.LastUpdatedBy
                        }
                    },
                    Tasks = generalPlan.GeneralPlanTasks.Select(task => new GeneralTaskModelView
                    {
                        Id = task.GenTaskID,
                        Name = task.GeneralTask.TaskName,
                        Description = task.GeneralTask.TaskDescription,
                        Options = task.GeneralTask.GeneralTaskOptions.Select(option => new GeneralTaskOptionModelView
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
                        }).ToList()
                    }).ToList(),
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
        }
        public GeneralPlanModel GetById(int id)

        {
            try
            {
                var generalPlan = _dbContext.GeneralPlans.Find(id);

                if (generalPlan == null)
                {
                    return null;
                }
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }

}
