using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using ConstructionManagementService.Models;
using ConstructionManagementService.DataActions;
using log4net;

namespace ConstructionManagementService.Controllers
{
    public class GeneralTaskController : ApiController
    {
        static ILog _log = log4net.LogManager.GetLogger(
                   System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
               );

        //GET api/GeneralTask
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
                    GeneralTaskActions genTaskActions = new GeneralTaskActions();
                    _log.Debug("Getting General Materials");
                    IEnumerable<GeneralTaskModel> genTaskList = genTaskActions.Get(showInActive);
                    var genTaskModels = genTaskList as IList<GeneralTaskModel> ?? genTaskList.ToList();
                    _log.DebugFormat("General Materials retreived Count: {0}", genTaskModels.Count());
                    return Ok(genTaskModels);
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

                GeneralTaskActions generalTaskActions = new GeneralTaskActions();
                try
                {
                    _log.Debug("Getting General Tasks");

                    var generalTaskModel = generalTaskActions.GetById(id);
                    if (generalTaskModel != null)
                    {
                        _log.DebugFormat("General Task retrieved. ID: {0}", generalTaskModel.Id);
                        return Ok(generalTaskModel);
                    }
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting General Task.", e);
                    return InternalServerError(e);
                }
            }
            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Post(HttpRequestMessage request, [FromBody]GeneralTaskModel value)
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
                    GeneralTaskActions generalTaskActions = new GeneralTaskActions();

                    generalTaskActions.Insert(value, user);

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while adding General Tasks.", e);
                    return InternalServerError(e);
                }

            }

            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Put(HttpRequestMessage request, GeneralTaskModel value)
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
                    GeneralTaskActions generalTaskActions = new GeneralTaskActions();

                    generalTaskActions.Update(value, user);
                    _log.Debug("General Task Updated");

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while updating Tasks.", e);
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
                    GeneralTaskActions generalTaskActions = new GeneralTaskActions();

                    generalTaskActions.Deactivate(id, user);
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
