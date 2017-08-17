﻿
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
            [JsonProperty("vendorId")]//VendorID
            public int VendorId { get; set; }
            [JsonProperty("materialProduct")]//MaterialProduct
            public string MaterialProduct { get; set; }
            [JsonProperty("color")]//Color
            public LookupModel Color { get; set; }
            [JsonProperty("categoryId")]//CategoryID
            public int CategoryId { get; set; }
            [JsonProperty("quantity")]//Quantity
            public int Quantity { get; set; }
            [JsonProperty("unitOfMeasureId")]//UomID
            public int UomId { get; set; }


    }
    }