using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CarPoolAPI.Enums;
namespace CarPoolAPI.Models
{
    public class AnounceOfferring
    {
        [Key]
        public int Id { get; set; }

        public int OfferId { get; set; }
        public virtual Offerring Offerring { get; set; }

        [Column(TypeName ="nvarchar(15)")]
        public AnounceStatus Status { get; set; }
        public int AnounceId { get; set; }
        public virtual Anounce Anounce { get; set; }
        }
}
