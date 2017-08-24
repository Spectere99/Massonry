using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConstructionManagementService.Models
{
    public class TaskOptionModel
    {
        [JsonProperty("id")]
        public int TaskOptionId { get; set; }
        [JsonProperty("value")]
        public LookupModel OptionValue { get; set; }
    }
}