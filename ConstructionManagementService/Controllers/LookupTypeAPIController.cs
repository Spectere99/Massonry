using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using ConstructionManagementService.Models;
using ConstructionManagementData;
using log4net;

namespace ConstructionManagementService.Controllers
{
    public class LookupTypeAPIController : ApiController
    {
        static ILog _log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
        );
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();
        //GET api/LookupType
        public IHttpActionResult Get(HttpRequestMessage request)
        {
            if (_log.IsDebugEnabled)
                {
                    _log.DebugFormat("Executing call in debug mode");
                }

            var headers = request.Headers;
            //Check the request object to see if they passed a userId
            if (headers.Contains("userid"))
            {
                var user = headers.GetValues("userid").First();
                _log.InfoFormat("Handling GET request from user: {0}", user);
                    
                try
                {
                    _log.Debug("Getting Lookup Types");
                    IEnumerable<LookupTypeModel> lookupTypeList = GetLookupTypes();
                    var lookupTypeModels = lookupTypeList as IList<LookupTypeModel> ?? lookupTypeList.ToList();
                    _log.DebugFormat("Lookup Types retreived Count: {0}", lookupTypeModels.Count());
                    return Ok(lookupTypeModels);
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting Lookup Types.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");



        }

        public IHttpActionResult Post(HttpRequestMessage request, LookupTypeModel value)
        {
            if (_log.IsDebugEnabled)
            {
                _log.DebugFormat("Executing call in debug mode");
            }

            var headers = request.Headers;
            //Check the request object to see if they passed a userId
            if (headers.Contains("userid"))
            {
                var user = headers.GetValues("userid").First();
                _log.InfoFormat("Handling POST request from user: {0}", user);

                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                try
                {
                    _log.DebugFormat("Adding new LookupType (LookupTypeID: {0}, LookupType: {1})", value.LookupTypeId, value.Type);
                    _dbContext.LookupTypes.Add(new LookupType()
                    {
                        LookupTypeID = value.LookupTypeId,
                        LookupType1 = value.Type,
                        LastUpdatedBy = user,
                        LastUpdated = DateTime.Now
                    });

                    _dbContext.SaveChanges();

                    _log.Debug("Lookup Type Added");

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while adding Lookup Types.", e);
                    return InternalServerError(e);
                }
                
            }

            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Put(HttpRequestMessage request, LookupTypeModel value)
        {
            if (_log.IsDebugEnabled)
            {
                _log.DebugFormat("Executing call in debug mode");
            }

            var headers = request.Headers;
            //Check the request object to see if they passed a userId
            if (headers.Contains("userid"))
            {
                var user = headers.GetValues("userid").First();
                _log.InfoFormat("Handling PUT request from user: {0}", user);

                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                try
                {
                    var existingLookupType = _dbContext.LookupTypes
                        .FirstOrDefault(l => l.LookupTypeID == value.LookupTypeId);

                    
                    if (existingLookupType != null)
                    {
                        _log.DebugFormat("Updating existing LookupType (LookupTypeID: {0}, new_LookupType: {1})", existingLookupType.LookupTypeID, value.Type);
                        existingLookupType.LookupType1 = value.Type;
                        

                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        _log.DebugFormat("Lookup Type Not Found (LookupTypeID={0}", value.LookupTypeId);
                        return NotFound();
                    }

                    _log.Debug("Lookup Type Updated");
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while updating Lookup Types.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");
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