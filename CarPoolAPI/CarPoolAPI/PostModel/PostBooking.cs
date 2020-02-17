using CarPoolAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPoolAPI.PostModel
{
    public class PostBooking
    {
        public int Id { get; set; }
        public Address RequestedSource { get; set; }

        public Address RequestedDestination { get; set; }

        public BookingStatus BookingStatus { get; set; }
        public float FarePrice { get; set; }
        public DateTime DateTime{get;set;}
        public DateTime EndTime { get; set; }

        public int AnnounceId { get; set; }
        public int UserId { get; set; }
        public int OfferId { get; set; }
    }
}
