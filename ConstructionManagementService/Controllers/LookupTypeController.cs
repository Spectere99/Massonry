using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using ConstructionManagementService.Models;
using ConstructionManagementData;

namespace ConstructionManagementService.Controllers
{
    public class LookupTypeController : ApiController
    {
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();
        //GET api/LookupType
        [ResponseType(typeof(IEnumerable<LookupTypeModel>))]
        public IHttpActionResult Get()
        {
            IEnumerable<LookupTypeModel> lookupTypeList = GetLookupTypes();

            return this.Ok(lookupTypeList);
        }

        public IHttpActionResult Post(LookupTypeModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            _dbContext.LookupTypes.Add(new LookupType()
            {
                LookupTypeID = value.LookupTypeId,
                LookupType1 = value.Type
            });

            _dbContext.SaveChanges();

            return Ok();
         }

        public IHttpActionResult Put(LookupTypeModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var existingLookupType =_dbContext.LookupTypes
                .FirstOrDefault(l => l.LookupTypeID == value.LookupTypeId);

            if (existingLookupType != null)
            {
                //if (value.LookupTypeId != id)
                //{
                //    return BadRequest("ID did not match actual value.");
                //}
                existingLookupType.LookupType1 = value.Type;

                _dbContext.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }
        //Helper Methods
        private IEnumerable<LookupTypeModel> GetLookupTypes()
        {
            var lookups = _dbContext.LookupTypes.ToList();
            List<LookupTypeModel> lookupModel = lookups.Select(lookup => new LookupTypeModel
                {
                    LookupTypeId = lookup.LookupTypeID,
                    Type = lookup.LookupType1
                })
                .ToList();

            return lookupModel;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}