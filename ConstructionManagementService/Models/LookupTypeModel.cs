﻿using System;
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
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }
        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }
        [JsonProperty("lastUpdatedBy")]
        public string LastUpdatedBy { get; set; }

    }
    public class LookupTypeModelView
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("typeDescription")]
        public string TypeDescription { get; set; }
    }
}