using CarPoolAPI.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPoolAPI.Models
{
    public class ViaPoints
    {
        public int Id { get; set; }

        [Column(TypeName ="nvarchar(15)")]
        public Address Branch { get; set; }
        public int OfferId { get; set; }
        public virtual Offerring Offerring { get; set; }
    }
}
