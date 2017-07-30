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
        public int LookupTypeId { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    
    }
}