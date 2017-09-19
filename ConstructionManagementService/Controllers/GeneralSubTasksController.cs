using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementService.Models;
using ConstructionManagementData;
using log4net;
using ConstructionManagementService.ModelUtils;


namespace ConstructionManagementService.Controllers
{
    public class GeneralSubTasksController
    {
        private static readonly ILog _log = LogManager.GetLogger(
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
            if (headers.Contains("id"))
            {
                var user = headers.GetValues("id").First();
                _log.InfoFormat("Handling GET request from user: {0}", user);

                try
                {
                    GeneralSubTask GeneralSubtask = new GeneralSubTask();
                    _log.Debug("Getting Subtasks");
                    IEnumerable<GeneralSubTaskModel> GeneralSubTask = GeneralSubTask.Get(showInActive);
                    var GeneralSubtaskModel = GeneralSubTask as IList<GeneralSubTaskModel> ?? GeneralSubTasklist.ToList();
                    _log.DebugFormat("Subtasks retreived Count: {0}", GeneralSubTaskModel.Count());
                    return Ok(GeneralSubTaskModel);
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting user Types.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <id> not found.");
        }

        // GET: api/user/5
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

                GeneralSubTask subtaskActions = new GeneralSubTaskActions();
                try
                {
                    _log.Debug("Getting descpition");

                    var GeneralSubtasks = GeneralSubTask.GetById(id);
                    if (GeneralSubTask != null)
                    {
                        _log.DebugFormat("subTask retrieved. ID: {0}", GeneralSubTask.Id);
                        return Ok(GeneralSubTaskModel);
                    }
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting subtask Type.", e);
                    return InternalServerError(e);
                }
            }
            return BadRequest("Header value <id> not found.");
        }

        // POST: api/user
        public IHttpActionResult Post(HttpRequestMessage request, [FromBody]GeneralSubTaskModel value)
        {
            if (_log.IsDebugEnabled)
            {
                _log.DebugFormat("Executing call in debug mode");
            }

            var headers = request.Headers;
            //Check the request object to see if they passed a userId
            if (headers.Contains("id"))
            {
                var user = headers.GetValues("id").First();
                _log.InfoFormat("Handling POST request from user: {0}", user);

                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");
                try
                {
                    GeneralSubataskActions userActions = new GeneralSubataskActions();

                    userActions.Insert(value, user);
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while adding a subtask.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <id> not found.");
        }

        // PUT: api/user/5
        public IHttpActionResult Put(HttpRequestMessage request, GeneralSubTaskModel value)
        {
            if (_log.IsDebugEnabled)
            {
                _log.DebugFormat("Executing call in debug mode");
            }

            var headers = request.Headers;
            //Check the request object to see if they passed a userId
            if (headers.Contains("id"))
            {
                var user = headers.GetValues("id").First();
                _log.InfoFormat("Handling PUT request from user: {0}", user);

                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                try
                {
                    GeneralSubataskActions userActions = new GeneralSubataskActions();

                    userActions.Update(value, user);
                    _log.Debug("General Subtask Updated");
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while updating General Subtasks.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <id> not found.");
        }

        // DELETE: api/user/5
        public IHttpActionResult Delete(int id, HttpRequestMessage request)
        {
            if (_log.IsDebugEnabled)
            {
                _log.DebugFormat("Executing call in debug mode");
            }

            var headers = request.Headers;
            //Check the request object to see if they passed a userId
            if (headers.Contains("id"))
            {
                var user = headers.GetValues("id").First();
                _log.InfoFormat("Handling  DELETE request from user: {0}", user);

                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                try
                {
                    GeneralSubataskActions userActions = new GeneralSubataskActions();

                    userActions.Deactivate(id, user);
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while DeActivating Subtask.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <id> not found.");
        }
    }


}
