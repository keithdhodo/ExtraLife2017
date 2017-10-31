using System;
using Newtonsoft.Json;

namespace ExtraLife2017.Web.Models
{
    public class Prize
    {
        [JsonProperty("_id")]
        public Guid _id { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("productCode")]
        public string ProductCode { get; set; }
        [JsonProperty("prizeId")]
        public int PrizeId { get; set; }
        [JsonProperty("productName")]
        public string ProductName { get; set; }
        [JsonProperty("releaseDate")]
        public DateTime ReleaseDate { get; set; }
    }
}