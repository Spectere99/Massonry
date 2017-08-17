using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConstructionManagementService.Models
{
    public class LookupModel
    {
        [JsonProperty("id")]
        public int LookupId { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("lookupType")]
        public LookupTypeModel LookupType { get; set; }
    
    }
}