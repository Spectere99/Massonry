
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConstructionManagementService.Models
    {
        public class GeneralMaterialModel
        {
            [JsonProperty("id")]//MaterialID 
            public int MaterialId { get; set; }
            [JsonProperty("vendorId")]//VendorID
            public int VendorId { get; set; }
            [JsonProperty("materialProduct")]//MaterialProduct
            public string MaterialProduct { get; set; }
            [JsonProperty("color")]//Color
            public LookupModel Color { get; set; }
            [JsonProperty("materialType")]//Category
            public LookupModel MaterialType { get; set; }
            [JsonProperty("quantity")]//Quantity
            public int Quantity { get; set; }
            [JsonProperty("unitOfMeasure")]//Uom
            public LookupModel Uom { get; set; }


    }
    }
