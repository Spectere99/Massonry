using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConstructionManagementService.Models
{
    public class RoleModel
    {
        [JsonProperty("id")]
        public int RoleId { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("permission")]
        public PermissionModel Permission { get; set; }
        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }

    }
}