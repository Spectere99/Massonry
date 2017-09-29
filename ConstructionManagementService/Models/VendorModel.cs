using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConstructionManagementService.Models
{
    public class VendorModel : ModelBase
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

    }

    public class VendorModelView
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("shippingAddress")]
        public string ShippingAddress { get; set; }
        [JsonProperty("billingAddress")]
        public string BillingAddress { get; set; }
    }
}