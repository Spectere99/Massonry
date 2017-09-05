using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementService.Models;

namespace ConstructionManagementService.DataActions
{
    public class GeneralMaterialActions : IActions<GeneralMaterialModel>
    {
        public IEnumerable<GeneralMaterialModel> Get(bool showInactive)
        {
            throw new NotImplementedException();
        }

        public GeneralMaterialModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(GeneralMaterialModel modelObj, string userId)
        {
            throw new NotImplementedException();
        }

        public void Update(GeneralMaterialModel modelObj, string userId)
        {
            throw new NotImplementedException();
        }

        public void Deactivate(int id, string userId)
        {
            throw new NotImplementedException();
        }
    }
}