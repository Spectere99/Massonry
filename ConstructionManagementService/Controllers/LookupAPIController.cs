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
    public class LookupAPIController : ApiController
    {
        static ILog _log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
        );
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();
        //GET api/Lookup
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
                    _log.Debug("Getting Lookups");
                    IEnumerable<LookupModel> lookupList = GetLookups();
                    var lookupModels = lookupList as IList<LookupModel> ?? lookupList.ToList();
                    _log.DebugFormat("Lookups retreived Count: {0}", lookupModels.Count());
                    return Ok(lookupModels);
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting Lookup Types.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");



        }

        public IHttpActionResult Get(int id, HttpRequestMessage request)
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
                    _log.Debug("Getting Lookups");
                    IEnumerable<LookupModel> lookupList = GetLookupByTypeId(id);
                    var lookupModels = lookupList as IList<LookupModel> ?? lookupList.ToList();
                    _log.DebugFormat("Lookups retreived Count: {0}", lookupModels.Count());
                    return Ok(lookupModels);
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting Lookup Types.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");



        }

        public IHttpActionResult Post(HttpRequestMessage request, LookupModel value)
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
                    _log.DebugFormat("Adding new Lookup (LookupID: {0}, LookupValue: {1})", value.LookupId, value.Value);
                    Lookup newLookup = new Lookup()
                    {
                        LookupType = GetDBLookupTypeById(value.LookupType.LookupTypeId),
                        LookupID = 0,
                        LookupValue = value.Value,
                        LastUpdated = DateTime.Now,
                        LastUpdatedBy = 1
                    };
                    _dbContext.Lookups.Add(newLookup);

                    _dbContext.SaveChanges();

                    _log.Debug("Lookup Added");

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while adding Lookup.", e);
                    return InternalServerError(e);
                }
                
            }

            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Put(HttpRequestMessage request, LookupModel value)
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
                    var existingLookup = _dbContext.Lookups
                        .FirstOrDefault(l => l.LookupID == value.LookupId);

                    
                    if (existingLookup != null)
                    {
                        _log.DebugFormat("Updating existing Lookup (LookupID: {0}, new_Lookup: {1})", existingLookup.LookupID, value.Value);
                        existingLookup.LookupID = value.LookupId;

                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        _log.DebugFormat("Lookup Not Found (LookupID={0}", value.LookupId);
                        return NotFound();
                    }

                    _log.Debug("Lookup Updated");
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while updating Lookup.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");
        }

        //Helper Methods
        private IEnumerable<LookupModel> GetLookups()
        {
            var lookups = _dbContext.Lookups.ToList();
            List<LookupModel> lookupModel = lookups.Select(lookup => new LookupModel
                {
                    LookupId = lookup.LookupID,
                    Value = lookup.LookupValue,
                    LookupType = new LookupTypeModel()
                    {
                        LookupTypeId = lookup.LookupType.LookupTypeID,
                        Type = lookup.LookupType.LookupType1
                    }
                }).ToList();

            return lookupModel;
        }

        private IEnumerable<LookupModel> GetLookupByTypeId(int id)
        {
            var lookups = _dbContext.Lookups.Where(p => p.LookupType.LookupTypeID == id).ToList();
            List<LookupModel> lookupModel = lookups.Select(lookup => new LookupModel
            {
                LookupId = lookup.LookupID,
                Value = lookup.LookupValue,
                LookupType = new LookupTypeModel()
                {
                    LookupTypeId = lookup.LookupType.LookupTypeID,
                    Type = lookup.LookupType.LookupType1
                }
            }).ToList();

            return lookupModel;
        }

        private LookupType GetDBLookupTypeById(int id)
        {
            var lookupType = _dbContext.LookupTypes.SingleOrDefault(p => p.LookupTypeID == id);

            return lookupType;
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