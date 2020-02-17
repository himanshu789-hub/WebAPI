using CarPoolAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPoolAPI.PostModel
{
    public class PostAnnounce
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OfferId { get; set; }
        public Address Source { get; set; }
        public Address Destination { get; set; }
        public int BookId { get; set; }
        public DateTime DateTime{get;set;}
        public DateTime AlotDateTime{get;set;}
    }
}
