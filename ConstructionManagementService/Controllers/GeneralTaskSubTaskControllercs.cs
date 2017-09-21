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
    public class GeneralTaskSubTaskController : ApiController
    {
        static ILog _log = log4net.LogManager.GetLogger(
                   System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
               );

        //GET api/GeneralPlan
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
                    GeneralTaskSubTaskActions genTaskSubTaskActions = new GeneralTaskSubTaskActions();
                    _log.Debug("Getting General Task SubTasks");
                    IEnumerable<GeneralTaskSubTaskModel> genTaskSubTaskList = genTaskSubTaskActions.Get(showInActive);
                    var genTaskSubTaskModels = genTaskSubTaskList as IList<GeneralTaskSubTaskModel> ?? genTaskSubTaskList.ToList();
                    _log.DebugFormat("General Task Sub Tasks retreived Count: {0}", genTaskSubTaskModels.Count());
                    return Ok(genTaskSubTaskModels);
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting General Task Sub Tasks.", e);
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

                GeneralTaskSubTaskActions generalTaskSubTaskActions = new GeneralTaskSubTaskActions();
                try
                {
                    _log.Debug("Getting General Task Sub Tasks");

                    var generalTaskSubTaskModel = generalTaskSubTaskActions.GetById(id);
                    if (generalTaskSubTaskModel != null)
                    {
                        _log.DebugFormat("General Task Sub Task retrieved. ID: {0}", generalTaskSubTaskModel.Id);
                    }
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting General Task Sub Task.", e);
                    return InternalServerError(e);
                }
            }
            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Post(HttpRequestMessage request, [FromBody]GeneralTaskSubTaskModel value)
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
                    GeneralTaskSubTaskActions generalTaskSubTaskActions = new GeneralTaskSubTaskActions();

                    generalTaskSubTaskActions.Insert(value, user);

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while adding General Task Sub Task.", e);
                    return InternalServerError(e);
                }

            }

            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Put(HttpRequestMessage request, GeneralTaskSubTaskModel value)
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
                    GeneralTaskSubTaskActions generalTaskSubTaskActions = new GeneralTaskSubTaskActions();

                    generalTaskSubTaskActions.Update(value, user);
                    _log.Debug("General Task Sub Tasks Updated");

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while updating Task Sub Tasks.", e);
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
                    GeneralTaskSubTaskActions generalTaskSubTaskActions = new GeneralTaskSubTaskActions();

                    generalTaskSubTaskActions.Deactivate(id, user);
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while DeActivating General Task Materials.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");
        }

    }
}