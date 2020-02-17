using CarPoolAPI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPoolAPI.Models
{
    public class Offerring
    {
        [Key]
        public int Id { get; set; }
        
        public bool Active { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime TentativeTime { get; set; }

        public DateTime EndTime;

        public DateTime DepartTime { get; set; }

        public int SeatsAvail { get; set; }


        [Column(TypeName = "nvarchar(15)")]
        public Discount Discount { get; set; }


        [Column(TypeName = "nvarchar(15)")]
        public Address Source { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public Address CurrentLocation { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public Address Destination { get; set; }

        public float PricePerKM { get; set; }

        
        public float TotalEarning { get; set; }

        public int MaxOfferSeats { get; set; }

        
        public virtual User User { get; set; }

        public int VechicleRef { get; set; }
        public Vechicles Vechicles { get; set; }

        public int UserId { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<ViaPoints> ViaPoints { get; set; }

        public ICollection<AnounceOfferring> AnnounceOfferrings { get; set; }

        
        public Offerring()
        {
            Bookings = new HashSet<Booking>();
            ViaPoints = new HashSet<ViaPoints>();
            AnnounceOfferrings = new HashSet<AnounceOfferring>();
        }

    }
}
