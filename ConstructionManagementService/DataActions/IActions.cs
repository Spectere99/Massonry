using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstructionManagementService.DataActions
{
    public interface IActions<T>
    {
        IEnumerable<T> Get(bool showInactive);
        T GetById(int id);
        void Insert(T modelObj, string userId);
        void Update(T modelObj, string userId);
        void Deactivate(int id, string userId);

    }
}