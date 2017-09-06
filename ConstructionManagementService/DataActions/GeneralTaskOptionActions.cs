using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using ConstructionManagementService.Models;

namespace ConstructionManagementService.DataActions
{
    public class GeneralTaskOptionActions : IActions<GeneralTaskOptionModel>
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();

        public IEnumerable<GeneralTaskOptionModel> Get(bool showInactive)
        {
            try
            {
                var generalTaskOptions = showInactive
                    ? _dbContext.GeneralTaskOptions.ToList()
                    : _dbContext.GeneralTaskOptions.Where(p => p.IsActive).ToList();

                var generalTaskOptionModels = generalTaskOptions.Select(generalTaskOption => new GeneralTaskOptionModel
                {
                    Id = generalTaskOption.GenOptionLookupID,
                    TaskOption = new LookupModel
                    {
                        Id = generalTaskOption.Lookup.LookupID,
                        LookupTypeId = generalTaskOption.Lookup.LookupTypeID,
                        LookupType = new LookupTypeModel
                        {
                            Id = generalTaskOption.Lookup.LookupType.LookupTypeID,
                            TypeDescription = generalTaskOption.Lookup.LookupType.LookupType1
                        }
                    }
                });

                return generalTaskOptionModels;
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

        public GeneralTaskOptionModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(GeneralTaskOptionModel modelObj, string userId)
        {
            throw new NotImplementedException();
        }

        public void Update(GeneralTaskOptionModel modelObj, string userId)
        {
            throw new NotImplementedException();
        }

        public void Deactivate(int id, string userId)
        {
            throw new NotImplementedException();
        }
    }
}