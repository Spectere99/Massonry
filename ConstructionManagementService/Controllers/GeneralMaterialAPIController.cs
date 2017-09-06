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
using log4net;

    namespace ConstructionManagementService.Controllers
    {
        public class GeneralMaterialAPIController : ApiController
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
                //DBModelUtilities dbModelUtilities = new DBModelUtilities();
                var headers = request.Headers;
                //Check the request object to see if they passed a userId
                if (headers.Contains("userid"))
                {
                    var user = headers.GetValues("userid").First();
                    _log.InfoFormat("Handling GET request from user: {0}", user);

                    try
                    {
                        _log.Debug("Getting Materials");
                        //IEnumerable<GeneralMaterialModel> generalMaterialList = dbModelUtilities.GetMaterials();
                        //var generalMaterialModels = generalMaterialList as IList<GeneralMaterialModel> ?? generalMaterialList.ToList();
                        //_log.DebugFormat("General Materials retrieved Count: {0}", generalMaterialModels.Count());
                        return Ok("");
                    }
                    catch (Exception e)
                    {
                        _log.Error("An error occurred while getting Lookup Types.", e);
                        return InternalServerError(e);
                    }
                }

                return BadRequest("Header value <userid> not found.");

            }

            public IHttpActionResult Post(HttpRequestMessage request, GeneralMaterialModel value)
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
                    //ModelDBUtilities modelDbUtilities = new ModelDBUtilities();
                    try
                    {
                        _log.DebugFormat("Adding new General Material (MaterialId: {0}, VendorId: {1}), MaterialProduct: {2}, Color: {3}, MaterialTypeId: {4}, Quantity: {5}, UomId: {6}", value.MaterialId, value.VendorId, value.MaterialProduct,
                            value.Color.Id, value.MaterialType.Id, value.Quantity, value.Uom.Id);
                       // modelDbUtilities.InsertGeneralMaterial(value, user);  
                        _log.Debug("General Material Added");

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
                //ModelDBUtilities modelDBUtilities = new ModelDBUtilities();
                try
                {

                    _log.DebugFormat("Updating existing Material (MaterialId: {0}, VendorId: {1}), MaterialType: {2}, Color: {3}, CategoryId: {4}, Quantity: {5}, UomId: {6}", value.MaterialId, value.VendorId, value.MaterialType.Id, value.Color.Id, value.Quantity, value.Uom.Id
                        );
                    //modelDBUtilities.UpdateGeneralMaterial(value, user);

                    _log.Debug("Material Updated");
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while updating Materials.", e);
                    return InternalServerError(e);
                }
                finally
                {
                    //modelDBUtilities.Dispose();
                }
            }

            return BadRequest("Header value <userid> not found.");
        }

        //Helper Methods


        //protected override void Dispose(bool disposing)
        //    {
        //    ModelDBUtilities modelDButilities = new ModelDBUtilities();
        //        if (disposing)
        //        {
        //        modelDButilities.Dispose();
        //        }

        //        base.Dispose(disposing);
        //    }
        }
    }


