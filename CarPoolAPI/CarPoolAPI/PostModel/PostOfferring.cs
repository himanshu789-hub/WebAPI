using CarPoolAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPoolAPI.PostModel
{
    public class PostOfferring
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime TentativeTime { get; set; }

        public Discount Discount { get; set; }

        public Address Source { get; set; }

        public Address Destination { get; set; }

        public float PricePerKM { get; set; }

        public int VehicleRef { get; set; }

        public int MaxOfferSeats { get; set; }

        public List<int> Route { get; set; }

         public Address Location{get;set;}
    }
}
