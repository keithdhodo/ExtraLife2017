using System;

namespace ExtraLife2017.Web.Models
{
    public class Prize
    {
        public Guid _id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; set; }
        public int PrizeId { get; set; }
        public string ProductName { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}