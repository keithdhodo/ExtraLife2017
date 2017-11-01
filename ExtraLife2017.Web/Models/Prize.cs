using System;
using Newtonsoft.Json;

namespace ExtraLife2017.Web.Models
{
    public class Prize
    {
        [JsonProperty("_id")]
        public Guid Id { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("prizeId")]
        public int PrizeId { get; set; }
        [JsonProperty("prizeName")]
        public string PrizeName { get; set; }
        [JsonProperty("dateAdded")]
        public DateTime DateAdded { get; set; }
        [JsonProperty("tier")]
        public int Tier { get; set; }
        [JsonProperty("displayDate")]
        public DateTime DisplayDate { get; set; }
        [JsonProperty("wonBy")]
        public string WonBy { get; set; }
    }
}