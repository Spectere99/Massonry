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
    public class GeneralSubTaskController
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
                    GeneralSubTaskActions genTaskOptionActions = new GeneralSubTaskActions();
                    _log.Debug("Getting General SubTasks");
                    IEnumerable<GeneralSubTaskActions> genSubTaskList = generalSubTaskActions.Get(showInActive);
                    var genSubTaskModels = genSubTaskList as IList<GeneralSubTaskModel> ?? genSubTaskList.ToList();
                    _log.DebugFormat("General SubTasks retreived Count: {0}", genSubTaskModels.Count());
                    return Ok(genSubTaskModels);
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting SubTask Options.", e);
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

                GeneralTaskOptionActions generalTaskOptionActions = new GeneralTaskOptionActions();
                try
                {
                    _log.Debug("Getting General SubTask Options");

                    var generalSubTaskModel = generalSubTaskActions.GetById(id);
                    if (generalSubTaskModel != null)
                    {
                        _log.DebugFormat("General SubTask Option retrieved. ID: {0}", generalSubTaskModel.Id);
                    }
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting General Task Option.", e);
                    return InternalServerError(e);
                }
            }
            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Post(HttpRequestMessage request, [FromBody]GeneralTaskOptionModel value)
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
                    GeneralSubTaskActions generalSubTaskActions = new GeneralSubTaskActions();

                    GeneralSubTaskActions.Insert(value, user);

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while adding General Task Option.", e);
                    return InternalServerError(e);
                }

            }

            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Put(HttpRequestMessage request, GeneralTaskOptionModel value)
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
                    GeneralSubTaskActions generalSubTaskActions = new GeneralSubTaskActions();

                    generalSubTaskActions.Update(value, user);
                    _log.Debug("General SubTask  Updated");

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while updating Task Options.", e);
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
                    GeneralSubTaskActions generalSubTaskActions = new GeneralSubTaskActions();

                    generalSubTaskActions.Deactivate(id, user);
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while DeActivating SubTask.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");
        }

    }
}