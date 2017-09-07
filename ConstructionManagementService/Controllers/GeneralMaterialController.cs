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
        public class GeneralMaterialController : ApiController
        {
            static ILog _log = log4net.LogManager.GetLogger(
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
            );
            
            //GET api/GeneralMaterial
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
                        GeneralMaterialActions genMaterialActions = new GeneralMaterialActions();
                        _log.Debug("Getting General Materials");
                        IEnumerable<GeneralMaterialModel> genMaterialList = genMaterialActions.Get(showInActive);
                        var genMaterialModels = genMaterialList as IList<GeneralMaterialModel> ?? genMaterialList.ToList();
                        _log.DebugFormat("General Materials retreived Count: {0}", genMaterialModels.Count());
                        return Ok(genMaterialModels);
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

                GeneralMaterialActions generalMaterialActions = new GeneralMaterialActions();
                try
                {
                    _log.Debug("Getting General Materials");

                    var generalMaterialModel = generalMaterialActions.GetById(id);
                    if (generalMaterialModel!= null)
                    {
                        _log.DebugFormat("General Material retrieved. ID: {0}",generalMaterialModel.MaterialId);
                        return Ok(generalMaterialModel);
                    }
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting General Material.", e);
                    return InternalServerError(e);
                }
            }
            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Post(HttpRequestMessage request, [FromBody]GeneralMaterialModel value)
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
                        GeneralMaterialActions generalMaterialActions = new GeneralMaterialActions();

                        generalMaterialActions.Insert(value, user);
                      
                        return Ok();
                    }
                    catch (Exception e)
                    {
                        _log.Error("An error occurred while adding General Materials.", e);
                        return InternalServerError(e);
                    }

                }

            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Put(HttpRequestMessage request, GeneralMaterialModel value)
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
                    GeneralMaterialActions generalMaterialActions = new GeneralMaterialActions();

                    generalMaterialActions.Update(value, user);
                    _log.Debug("General Material Updated");

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while updating Materials.", e);
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
                   GeneralMaterialActions generalMaterialActions = new GeneralMaterialActions();

                   generalMaterialActions.Deactivate(id, user);
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


