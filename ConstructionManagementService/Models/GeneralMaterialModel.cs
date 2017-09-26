
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
            [JsonProperty("productInventoryId")]//materialID 
            public int ProductInventoryId { get; set; }
            [JsonProperty("productInventory")]
            public ProductInventoryModel ProductInventory { get; set; }
            [JsonProperty("requiredQuantity")]//materialID 
            public int RequiredQuantity { get; set; }
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
