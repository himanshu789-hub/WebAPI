using CarPoolAPI.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPoolAPI.Models
{
    public class Anounce
    {
        [Key]
        public int Id { get; set; }

        [Column("Source",TypeName = "nvarchar(15)")]
        public Address Source { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public Address Destination { get; set; }

        public DateTime DateTime;

        public DateTime AllotDateTime;

        public bool Active { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
        public Nullable<int> BookingRef { get; set; }
        public virtual Booking Booking { get; set; }

        public virtual ICollection<AnounceOfferring> AnnounceOfferrings { get; set; }
        public Anounce() => AnnounceOfferrings = new HashSet<AnounceOfferring>();
    }
}
