using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConstructionManagementService.Models
{
    public class GeneralTaskModel
    {
        [JsonProperty("id")]
        public int GeneralTaskId { get; set; }
        [JsonProperty("name")]
        public string TaskName { get; set; }
        [JsonProperty("description")]
        public string TaskDescription { get; set; }
        [JsonProperty("options")]
        public List<TaskOptionModel> TaskOptions { get; set; }
        [JsonProperty("materials")]
        public List<GeneralMaterialModel> TaskMaterials { get; set; }
        [JsonProperty("subTasks")]
        public List<GeneralSubTaskModel> SubTasks { get; set; }
        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }
    }
}