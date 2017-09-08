using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConstructionManagementService.DataActions;
using ConstructionManagementService.Models;
using log4net;

namespace ConstructionManagementService.Controllers
{
    public class VendorController : ApiController
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
            if (headers.Contains("userid"))
            {
                var user = headers.GetValues("userid").First();
                _log.InfoFormat("Handling GET request from user: {0}", user);

                try
                {
                    VendorActions vendorActions = new VendorActions();
                    _log.Debug("Getting user Types");
                    IEnumerable<VendorModel> userList = vendorActions.Get(showInActive);
                    var vendorModels = userList as IList<VendorModel> ?? userList.ToList();
                    _log.DebugFormat("Vendors retreived Count: {0}", vendorModels.Count());
                    return Ok(vendorModels);
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting Vendors.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");
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

                VendorActions vendorActions = new VendorActions();
                try
                {
                    _log.Debug("Getting userType");

                    var vendorModel = vendorActions.GetById(id);
                    if (vendorModel != null)
                    {
                        _log.DebugFormat("Vendor retrieved. ID: {0}", vendorModel.Id);
                        return Ok(vendorModel);
                    }
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting Vendor.", e);
                    return InternalServerError(e);
                }
            }
            return BadRequest("Header value <userid> not found.");
        }

        // POST: api/user
        public IHttpActionResult Post(HttpRequestMessage request, [FromBody]VendorModel value)
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
                    VendorActions vendorActions = new VendorActions();

                    vendorActions.Insert(value, user);
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while adding Vendor.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");
        }

        // PUT: api/user/5
        public IHttpActionResult Put(HttpRequestMessage request, VendorModel value)
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
                    VendorActions vendorActions = new VendorActions();

                    vendorActions.Update(value, user);
                    _log.Debug("Vendor Updated");
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while updating Vendor.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");
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
            if (headers.Contains("userid"))
            {
                var user = headers.GetValues("userid").First();
                _log.InfoFormat("Handling  DELETE request from user: {0}", user);

                if (!ModelState.IsValid)
                    return BadRequest("Invalid data.");

                try
                {
                    VendorActions vendorActions = new VendorActions();

                    vendorActions.Deactivate(id, user);
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while DeActivating Vendor.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");
        }
    }
}
