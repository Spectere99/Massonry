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
    public class GeneralPlanController : ApiController
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
                    GeneralPlanActions genPlanActions = new GeneralPlanActions();
                    _log.Debug("Getting General Materials");
                    IEnumerable<GeneralPlanModel> genPlanList = genPlanActions.Get(showInActive);
                    var genPlanModels = genPlanList as IList<GeneralPlanModel> ?? genPlanList.ToList();
                    _log.DebugFormat("General Materials retreived Count: {0}", genPlanModels.Count());
                    return Ok(genPlanModels);
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

                GeneralPlanActions generalPlanActions = new GeneralPlanActions();
                try
                {
                    _log.Debug("Getting General Plans");

                    var generalPlanModel = generalPlanActions.GetById(id);
                    if (generalPlanModel != null)
                    {
                        _log.DebugFormat("General Plan retrieved. ID: {0}", generalPlanModel.Id);
                    }
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting General Plan.", e);
                    return InternalServerError(e);
                }
            }
            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Post(HttpRequestMessage request, [FromBody]GeneralPlanModel value)
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
                    GeneralPlanActions generalPlanActions = new GeneralPlanActions();

                    generalPlanActions.Insert(value, user);

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while adding General Plans.", e);
                    return InternalServerError(e);
                }

            }

            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Put(HttpRequestMessage request, GeneralPlanModel value)
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
                    GeneralPlanActions generalPlanActions = new GeneralPlanActions();

                    generalPlanActions.Update(value, user);
                    _log.Debug("General Plan Updated");

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while updating Plans.", e);
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
                    GeneralPlanActions generalPlanActions = new GeneralPlanActions();

                    generalPlanActions.Deactivate(id, user);
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
