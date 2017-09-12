
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Newtonsoft.Json;
    namespace ConstructionManagementService.Models
    {
        public class GeneralPlanModel
        {
            [JsonProperty("id")]
            public int Id { get; set; }
            [JsonProperty("planName")]
            public string PlanName { get; set; }
            [JsonProperty("elevationLookupId")]
            public int ElevationLookupId { get; set; }
            [JsonProperty("elevation")]//color
            public LookupModel Elevation { get; set; }
            [JsonProperty("garageTypeLookupId")]
            public int GarageTypeLookupId { get; set; }
            [JsonProperty("garageType")]//color
            public LookupModel GarageType { get; set; }
            [JsonProperty("isActive")]
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