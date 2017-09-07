using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConstructionManagementService.Models
{
    public class GeneralTaskSubTaskModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("taskId")]
        public int TaskId { get; set; }
        [JsonProperty("task")]
        public GeneralTaskModel GeneralTask { get; set; }
        [JsonProperty("subTaskId")]
        public int SubTaskId { get; set; }
        [JsonProperty("subTask")]
        public GeneralSubTaskModel GeneralSubTask { get; set; }
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