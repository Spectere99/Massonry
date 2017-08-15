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
    public class MaterialAPIController: ApiController
    {
        static ILog _log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
        );
        private readonly ConstructionManagerEntities _dbContext = new ConstructionManagerEntities();
        //GET api/Material
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
                    _log.Debug("Getting Materials");
                    IEnumerable<MaterialModel> materialList = GetMaterials();
                    var materialModels = materialList as IList<MaterialModel> ?? materialList.ToList();
                    _log.DebugFormat("Materials retreived Count: {0}", materialModels.Count());
                    return Ok(materialModels);
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting Lookup Types.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");



        }

        public IHttpActionResult Post(HttpRequestMessage request, MaterialModel value)
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
                    _log.DebugFormat("Adding new Material (MaterialId: {0}, VendorId: {1}), MaterialProduct: {2}, Color: {3}, CategoryId: {4}, Quantity: {5}, UomId: {6}", value.MaterialId, value.VendorId, value.MaterialProduct,
                        value.Color, value.CategoryId, value.Quantity, value.UomId);
                    _dbContext.GeneralMaterials.Add(new GeneralMaterial()
                    {
                        MaterialID = value.MaterialId,
                        VendorID = value.VendorId,
                        MaterialProduct= value.MaterialProduct,
                        //Color = value.Color,
                        //MaterialType = value.MaterialId,
                        Quantity = value.Quantity,
                        UomLookupID = value.UomId

                    });

                    _dbContext.SaveChanges();

                    _log.Debug("Material Added");

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while adding Materials.", e);
                    return InternalServerError(e);
                }

            }

            return BadRequest("Header value <userid> not found.");
        }

        public IHttpActionResult Put(HttpRequestMessage request, MaterialModel value)
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
                    var existingMaterial = _dbContext.GeneralMaterials
                        .FirstOrDefault(m => m.MaterialID== value.MaterialId);


                    if (existingMaterial != null)
                    {
                        _log.DebugFormat("Updating existing Material (MaterialId: {0}, VendorId: {1}), MaterialProduct: {2}, Color: {3}, CategoryId: {4}, Quantity: {5}, UomId: {6}", value.MaterialId, value.VendorId, value.MaterialProduct,
                        value.Color, value.CategoryId, value.Quantity, value.UomId);
                        //existingMaterial.VendorLookupID = value.VendorId;
                        existingMaterial.MaterialProduct = value.MaterialProduct;
                       // existingMaterial.Color = value.Color;
                        //existingMaterial.CategoryLookupID = value.CategoryId;
                        existingMaterial.Quantity = value.Quantity;
                        existingMaterial.UomLookupID = value.UomId;
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        _log.DebugFormat("Material Not Found (MaterialID={0}", value.MaterialId);
                        return NotFound();
                    }

                    _log.Debug("Material Updated");
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

        //Helper Methods
        private IEnumerable<MaterialModel> GetMaterials()
        {
            var materials = _dbContext.GeneralMaterials.ToList();
            List<MaterialModel> MaterialsModel = materials.Select(material => new MaterialModel
            {
                MaterialId = material.MaterialID,
                //VendorId = material.VendorLookupID,
                MaterialProduct= material.MaterialProduct,
                Color = GetLookup(material.ColorLookupID),
                //CategoryId = material.CategoryLookupID,
                Quantity = material.Quantity,
                UomId = material.UomLookupID
            })
                .ToList();

            return MaterialsModel;
        }

        private LookupModel GetLookup(int? lookupId)
        {
            var lookup = _dbContext.Lookups.FirstOrDefault(p => p.LookupID == lookupId);

            if (lookup != null)
            {
                LookupModel lm = new LookupModel
                {
                    LookupId = lookup.LookupID,
                    TypeId = lookup.LookupTypeID,
                    Value = lookup.LookupValue
                };

                return lm;
            }

            return null;
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
    