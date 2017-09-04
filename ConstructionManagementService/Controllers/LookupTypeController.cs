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
using ConstructionManagementService.DataActions;
using ConstructionManagementService.ModelUtils;
using log4net;

namespace ConstructionManagementService.Controllers
{
    public class LookupTypeController : ApiController
    {
        static ILog _log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
        );
        public IHttpActionResult Get(HttpRequestMessage request)
        {
            if (_log.IsDebugEnabled)
            {
                _log.DebugFormat("Executing call in debug mode");
            }

            var headers = request.Headers;
            bool showInActive = false;

            if (headers.Contains("showInactive"))
            {
                showInActive = Boolean.Parse(headers.GetValues("showInactive").First());
            }

            //Check the request object to see if they passed a userId
            if (headers.Contains("userid"))
            {
                var user = headers.GetValues("userid").First();
                _log.InfoFormat("Handling GET request from user: {0}", user);

                try
                {
                    LookupTypeActions lookupActions = new LookupTypeActions();
                    _log.Debug("Getting Lookup Types");
                    IEnumerable<LookupTypeModel> lookupTypeList = lookupActions.Get(showInActive);
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

        // GET: api/LookupType/5
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

                LookupTypeActions lookupActions = new LookupTypeActions();
                try
                {
                    _log.Debug("Getting LookupType");

                    var lookupTypeModel = lookupActions.GetById(id);
                    if (lookupTypeModel != null)
                    {
                        _log.DebugFormat("LookupType retrieved. ID: {0}", lookupTypeModel.Id);
                        return Ok(lookupTypeModel);
                    }
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting Lookup Type.", e);
                    return InternalServerError(e);
                }
            }
            return BadRequest("Header value <userid> not found.");
        }

        // POST: api/LookupType
        public IHttpActionResult Post(HttpRequestMessage request, [FromBody]LookupTypeModel value)
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
                    LookupTypeActions lookupActions = new LookupTypeActions();

                    lookupActions.Insert(value, user);
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while adding Lookup Type.", e);
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
                    LookupTypeActions lookupActions = new LookupTypeActions();

                    lookupActions.Update(value, user);
                    _log.Debug("Lookup Type Updated");
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while updating Lookup Type.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");
        }

        // DELETE: api/LookupType/5
        public IHttpActionResult Delete(int id, HttpRequestMessage request)
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
                _log.InfoFormat("Handling  DELETE request from user: {0}", user);

                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                try
                {
                    LookupTypeActions lookupActions = new LookupTypeActions();

                    lookupActions.Deactivate(id, user);
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while DeActivating Lookup Type.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");
        }
    }
}