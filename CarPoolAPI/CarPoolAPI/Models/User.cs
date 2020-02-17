using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarPoolAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public ICollection<Offerring> Offerrings { get; set; }

        public ICollection<Anounce> Announces { get; set; }

        public User()
        {
            Offerrings = new HashSet<Offerring>();
            Bookings = new HashSet<Booking>();
            Announces = new HashSet<Anounce>();
        }

    }
}
