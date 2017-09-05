using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConstructionManagementService.Models
{
    public class LookupTypeModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("typeDescription")]
        public string TypeDescription { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

    }
}