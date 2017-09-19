using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConstructionManagementService.Models
{
    public class VendorModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("shippingAddressId")]
        public int ShippingAddressId { get; set; }
        [JsonProperty("shippingAddress")]
        public AddressModel ShippingAddress { get; set; }
        [JsonProperty("billingAddressId")]
        public int BillingAddressId { get; set; }
        [JsonProperty("billingAddress")]
        public AddressModel BillingAddress { get; set; }
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