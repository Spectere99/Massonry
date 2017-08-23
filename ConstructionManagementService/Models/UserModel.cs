using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace ConstructionManagementService.Models
{
    public class UserModel
    {
        [JsonProperty("id")]
        public int UserId { get; set; }
        [JsonProperty ("user")]
        public string UserName {get; set;}
        [JsonProperty ("email")]
        public string Email { get; set; }
        [JsonProperty ("firstName")]
        public string FirstName { get; set; }
        [JsonProperty ("lastName")]
        public string LastName { get; set; }
        [JsonProperty ("contactNumber")]
        public int ContactNumber { get; set;}
        [JsonProperty ("updated")]
        public DateTime LastUpdated { get; set; }

    }
}