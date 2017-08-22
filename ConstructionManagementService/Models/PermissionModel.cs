using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConstructionManagementService.Models
{
    public class PermissionModel
    {
        [JsonProperty("id")]
        public int PermissionId { get; set; }
        [JsonProperty("permission")]
        public string Permission { get; set; }
        [JsonProperty("moduleId")]
        public int ModuleKeyId { get; set; }
        [JsonProperty("canAccess")]
        public bool CanAccess { get; set; }
        [JsonProperty("canUpdate")]
        public bool CanUpdate { get; set; }
        [JsonProperty("canDelete")]
        public bool CanDelete { get; set; }
        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }
        

    }
}