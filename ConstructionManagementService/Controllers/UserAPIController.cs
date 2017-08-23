using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConstructionManagementData;
using ConstructionManagementService.ModelUtils;
using log4net;

namespace ConstructionManagementService.Controllers
{
    public class UserAPIController : ApiController
    {
        private static readonly ILog _log = LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
        );

        private readonly ModelDBUtilities _modelDbUtilities = new ModelDBUtilities();
        // GET: api/UserAPI
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
                    var userList = _modelDbUtilities.GetUsers();
                    if (userList != null)
                    {
                        _log.DebugFormat("Lookup Types retreived Count: {0}", userList.Count());
                        return Ok(userList);
                    }
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting Lookup Types.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Post(HttpRequestMessage request, User value)
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
                    _log.DebugFormat("Adding new User (UserID: {0}, UserName: {1})", value.UserID, value.UserName);
                    //_dbContext.Users.Add(new User()
                    //{
                    //    UserID = value.UserID,
                    //    UserName = value.UserName
                    //});

                    //_dbContext.SaveChanges();

                    _log.Debug("User Added");

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while adding Users.", e);
                    return InternalServerError(e);
                }

            }

            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Put(HttpRequestMessage request, User value)
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
                    //var existingUser = _dbContext.Users
                    //    .FirstOrDefault(l => l.UserID == value.UserID);


                    //if (existingUser != null)
                    //{
                    //    _log.DebugFormat("Updating existing User (UserID: {0}, UserName: {1})", existingUser.UserID, value.UserName);
                    //    existingUser.UserName = value.UserName;

                    //    _dbContext.SaveChanges();
                    //}
                    //else
                    //{
                    //    _log.DebugFormat("User Not Found (UserID={0}", value.UserID);
                    //    return NotFound();
                    //}

                    _log.Debug("User Updated");
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while updating User.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");
        }

        // DELETE: api/UserAPI/5
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                
                _modelDbUtilities.Dispose();
            }

            base.Dispose(disposing);
        }
    }

    
}
