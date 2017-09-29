using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConstructionManagementService.Models
{
    /// <summary>
    /// Product Inventory Object Model
    /// </summary>
    public class ProductInventoryModel : ModelBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("product")]
        public string Product { get; set; }
        [JsonProperty("productCode")]
        public string ProductCode { get; set; }
        [JsonProperty("vendorId")]
        public int VendorId { get; set; }
        [JsonProperty("vendor")]
        public VendorModel Vendor { get; set; }
        [JsonProperty("colorId")] 
        public int ColorId { get; set; }
        [JsonProperty("color")]
        public LookupModelView Color { get; set; }
        [JsonProperty("productTypeId")]
        public int ProductTypeId { get; set; }
        [JsonProperty("productType")]
        public LookupModelView ProductType { get; set; }
        [JsonProperty("qtyOnHand")]
        public int QtyOnHand { get; set; }
        [JsonProperty("uomId")]//uomId
        public int UomId { get; set; }
        [JsonProperty("unitOfMeasure")]//Uom
        public LookupModelView Uom { get; set; }
        
    }

    public class ProductInventoryModelView
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("product")]
        public string Product { get; set; }
        [JsonProperty("productCode")]
        public string ProductCode { get; set; }
        [JsonProperty("vendorId")]
        public int VendorId { get; set; }
        [JsonProperty("vendor")]
        public VendorModel Vendor { get; set; }
        [JsonProperty("colorId")]
        public int ColorId { get; set; }
        [JsonProperty("color")]
        public LookupModelView Color { get; set; }
        [JsonProperty("productTypeId")]
        public int ProductTypeId { get; set; }
        [JsonProperty("productType")]
        public LookupModelView ProductType { get; set; }
        [JsonProperty("qtyOnHand")]
        public int QtyOnHand { get; set; }
        [JsonProperty("uomId")]//uomId
        public int UomId { get; set; }
        [JsonProperty("unitOfMeasure")]//Uom
        public LookupModelView Uom { get; set; }
    }
}