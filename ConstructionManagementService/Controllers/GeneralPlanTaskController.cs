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
    public class GeneralPlanTaskController : ApiController

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
                    GeneralPlanTaskActions genPlanTaskActions = new GeneralPlanTaskActions();
                    _log.Debug("Getting General Plan Task");
                    IEnumerable<GeneralPlanTaskModel> genPlanTaskList = genPlanTaskActions.Get(showInActive);
                    var genPlanTaskModels = genPlanTaskList as IList<GeneralPlanTaskModel> ?? genPlanTaskList.ToList();
                    _log.DebugFormat("General Plan Tasks retreived Count: {0}", genPlanTaskModels.Count());
                    return Ok(genPlanTaskModels);
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting General Plan Tasks.", e);
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

                GeneralPlanTaskActions generalPlanTaskActions = new GeneralPlanTaskActions();
                try
                {
                    _log.Debug("Getting General Plan Tasks");

                    var generalPlanTaskModel = generalPlanTaskActions.GetById(id);
                    if (generalPlanTaskModel != null)
                    {
                        _log.DebugFormat("General Plan Task retrieved. ID: {0}", generalPlanTaskModel.Id);
                    }
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting General Plan Task.", e);
                    return InternalServerError(e);
                }
            }
            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Post(HttpRequestMessage request, [FromBody]GeneralPlanTaskModel value)
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
                    GeneralPlanTaskActions generalPlanTaskActions = new GeneralPlanTaskActions();

                    generalPlanTaskActions.Insert(value, user);

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while adding General Plan Tasks.", e);
                    return InternalServerError(e);
                }

            }

            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Put(HttpRequestMessage request, GeneralPlanTaskModel value)
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
                    GeneralPlanTaskActions generalPlanTaskActions = new GeneralPlanTaskActions();

                    generalPlanTaskActions.Update(value, user);
                    _log.Debug("General Plan Task Updated");

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while updating Plan Tasks.", e);
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
                    GeneralPlanTaskActions generalPlanTaskActions = new GeneralPlanTaskActions();

                    generalPlanTaskActions.Deactivate(id, user);
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while DeActivating Plan Task.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");
        }

    }
}
