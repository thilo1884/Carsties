using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Entities;

namespace SearchService.Models
{
    public class Item : Entity
    {
        // In this case no need of an uid because is provided by Entity MongoDB
        public int ReservePrice { get; set; }
        public string Seller { get; set; }
        public string Winner { get; set; }
        public int SoldAmount { get; set; }
        public int CurrentHighBid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime AuctionEnd { get; set; }
        public String Status { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        public string ImageUrl { get; set; }
    }
}