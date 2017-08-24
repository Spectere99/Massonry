using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConstructionManagementService.Models
{
    public class GeneralSubTaskModel
    {
        [JsonProperty("id")]
        public int SubTaskId { get; set; }
        [JsonProperty("taskName")]
        public string SubTaskName { get; set; }
        [JsonProperty("taskDescription")]
        public string SubTaskDesription { get; set; }
        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }
    }
}