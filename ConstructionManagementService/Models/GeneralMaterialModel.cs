
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConstructionManagementService.Models
    {
        public class GeneralMaterialModel
        {
            [JsonProperty("id")]//materialID 
            public int MaterialId { get; set; }
            [JsonProperty("vendorId")]//vendorID
            public int VendorId { get; set; }
            [JsonProperty("materialProduct")]//materialProduct
            public string MaterialProduct { get; set; }
            [JsonProperty("colorId")] //colorId
            public int ColorId { get; set;}
            [JsonProperty("color")]//color
            public LookupModel Color { get; set; }
            [JsonProperty("materialTypeId")]//materialTypeId
            public int materialTypeId { get; set; }
            [JsonProperty("materialType")]//materialType
            public LookupModel MaterialType { get; set; }
            [JsonProperty("quantity")]//Quantity
            public int Quantity { get; set; }
            [JsonProperty ("uomId")]//uomId
            public int uomId { get; set; }
            [JsonProperty("unitOfMeasure")]//Uom
            public LookupModel Uom { get; set; }
            [JsonProperty("isActive")]//isActive
            public bool IsActive { get; set; }
            [JsonProperty("lastUpdated")]
            public DateTime LastUpdated { get; set; }
            [JsonProperty("lastUpdatedBy")]
            public string LastUpdatedBy { get; set; }
            [JsonProperty("created")]
            public DateTime Created { get; set; }
            [JsonProperty("createdBy")]
            public string CreatedBy { get; set; }

    }
    }
