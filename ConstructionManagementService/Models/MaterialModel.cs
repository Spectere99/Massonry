
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConstructionManagementService.Models
    {
        public class MaterialModel
        {
            [JsonProperty("id")]//MaterialID 
            public int MaterialId { get; set; }
            [JsonProperty("vendor id")]//VendorID
            public int VendorId { get; set; }
            [JsonProperty("material product")]//MaterialProduct
            public string MaterialProduct { get; set; }
            [JsonProperty("color")]//Color
            public string Color { get; set; }
            [JsonProperty("category id")]//CategoryID
            public int CategoryId { get; set; }
            [JsonProperty("quantity")]//Quantity
            public int Quantity { get; set; }
            [JsonProperty("unit of measure id")]//UomID
            public int UomId { get; set; }


    }
    }
