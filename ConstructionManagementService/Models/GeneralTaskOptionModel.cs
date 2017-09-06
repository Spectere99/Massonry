using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConstructionManagementService.Models
{
    public class GeneralTaskOptionModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("taskId")]
        public int TaskId { get; set; }
        [JsonProperty("task")]
        public GeneralTaskModel Task { get; set; }
        [JsonProperty("option")]
        public LookupModel TaskOption { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }
        [JsonProperty("lastUpdatedBy")]
        public string LastUpdatedBy { get; set; }
    }
}