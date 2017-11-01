using System;
using Newtonsoft.Json;

namespace ExtraLife2017.Web.Models
{
    public class Prize
    {
        [JsonProperty("_id")]
        public Guid Id { get; set; }
        
        [JsonProperty("prizeId")]
        public int PrizeId { get; set; }

        [JsonProperty("dateToDisplay")]
        public DateTime DateToDisplay { get; set; }

        [JsonProperty("dateAdded")]
        public DateTime DateAdded { get; set; }

        [JsonProperty("prizeName")]
        public string PrizeName { get; set; }

        [JsonProperty("donor")]
        public string Donor { get; set; }

        [JsonProperty("tier")]
        public int Tier { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("restriction")]
        public string Restriction { get; set; }

        [JsonProperty("wonBy")]
        public string WonBy { get; set; }
    }
}