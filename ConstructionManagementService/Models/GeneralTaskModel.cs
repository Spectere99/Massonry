using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstructionManagementData;
using Newtonsoft.Json;

namespace ConstructionManagementService.Models
{
    public class GeneralTaskModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("options")]
        public List<GeneralTaskOptionModelView> Options { get; set; }
        [JsonProperty("subTasks")]
        public List<GeneralSubTaskModel> GeneralSubTasks { get; set; }
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
    public class GeneralTaskModelView
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("options")]
        public List<GeneralTaskOptionModelView> Options { get; set; }
    }
}