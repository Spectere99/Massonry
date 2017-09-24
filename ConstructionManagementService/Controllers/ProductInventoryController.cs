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
    /// <summary>
    /// API for Product Inventory Items
    /// </summary>
    public class ProductInventoryController : ApiController
    {
        static ILog _log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
        );

        //GET api/ProductInventory
        /// <summary>
        /// GET Action for Product Inventory Items
        /// </summary>
        /// <param name="request">Contains Header values</param>
        /// <returns>IHttpActionResult</returns>
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
                    ProductInventoryActions productInventoryActions = new ProductInventoryActions();
                    _log.Debug("Getting Product Inventories");
                    IEnumerable<ProductInventoryModel> productInventoryList = productInventoryActions.Get(showInActive);
                    var productInventoryModels = productInventoryList as IList<ProductInventoryModel> ?? productInventoryList.ToList();
                    _log.DebugFormat("Product Inventory retreived Count: {0}", productInventoryModels.Count());
                    return Ok(productInventoryModels);
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting Product Inventory.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");

        }

        /// <summary>
        /// GET Action for a single Product Inventory Items
        /// </summary>
        /// <param name="id">Id of the Product Inventory Item</param>
        /// <param name="request">Contains Header information</param>
        /// <returns>IHttpActionREsult</returns>
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

                ProductInventoryActions productInventoryActions = new ProductInventoryActions();
                try
                {
                    _log.Debug("Getting Product Inventory");

                    var productInventoryModel = productInventoryActions.GetById(id);
                    if (productInventoryModel != null)
                    {
                        _log.DebugFormat("Product Inventory retrieved. ID: {0}", productInventoryModel.Id);
                    }
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while getting Product Inventory.", e);
                    return InternalServerError(e);
                }
            }
            return BadRequest("Header value <userid> not found.");
        }

        /// <summary>
        /// POST action for Creating a new Product Inventory Item
        /// </summary>
        /// <param name="request">Contains Header values</param>
        /// <param name="value">ProductInventoryModel</param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Post(HttpRequestMessage request, [FromBody]ProductInventoryModel value)
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
                    ProductInventoryActions productInventoryActions = new ProductInventoryActions();

                    productInventoryActions.Insert(value, user);

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while adding Product Inventory.", e);
                    return InternalServerError(e);
                }

            }

            return BadRequest("Header value <userid> not found.");
        }

        /// <summary>
        /// POST action for updating a Product Inventory Item
        /// </summary>
        /// <param name="request">Contains Header values</param>
        /// <param name="value">ProductInventoryModel</param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Put(HttpRequestMessage request, ProductInventoryModel value)
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
                    ProductInventoryActions productInventoryActions = new ProductInventoryActions();

                    productInventoryActions.Update(value, user);
                    _log.Debug("Product Inventory Updated");

                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while updating Product Inventory.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");
        }
        
        /// <summary>
        /// DELETE action for Product Invetory Item
        /// </summary>
        /// <param name="id">ID of Product Inventory Item to Delete</param>
        /// <param name="request">Contains Header value</param>
        /// <returns>IHttpActionResult</returns>
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
                    ProductInventoryActions productInventoryActions = new ProductInventoryActions();

                    productInventoryActions.Deactivate(id, user);
                    return Ok();
                }
                catch (Exception e)
                {
                    _log.Error("An error occurred while DeActivating Product Inventory.", e);
                    return InternalServerError(e);
                }
            }

            return BadRequest("Header value <userid> not found.");
        }
    }
}
