using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConstructionManagementService.Models;
using ConstructionManagementData;
using ConstructionManagementService.ModelUtils;
using log4net;

namespace ConstructionManagementService.Controllers
{
    public class SecurityController : ApiController
    {
        private static readonly ILog _log = LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
        );
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();
        //GET api/LookupType
        public IHttpActionResult Get(HttpRequestMessage request)
        {
            return Ok();
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
                    //_log.DebugFormat("Adding new User (UserID: {0}, UserName: {1})", value.UserID, value.UserName);
                    //_dbContext.Users.Add(new User()
                    //{
                    //    UserID = value.UserID,
                    //    UserName = value.UserName
                    //});

                    //_dbContext.SaveChanges();

                    //_log.Debug("User Added");

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
                    var existingUser = _dbContext.Users
                        .FirstOrDefault(l => l.UserID == value.UserID);


                    if (existingUser != null)
                    {
                        _log.DebugFormat("Updating existing User (UserID: {0}, UserName: {1})", existingUser.UserID, value.UserName);
                        existingUser.UserName = value.UserName;

                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        _log.DebugFormat("User Not Found (UserID={0}", value.UserID);
                        return NotFound();
                    }

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
