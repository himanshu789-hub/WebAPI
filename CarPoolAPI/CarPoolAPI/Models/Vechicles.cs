using CarPoolAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarPoolAPI.Models
{
    public class Vechicles
    {
        [Key]
        public int Id { get; set; }
        public string NumberPlate { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "nvarchar(10)")]
        public VehicleType Type { get; set; }

        public Offerring Offerring { get; set; }
        public int Capacity { get; set; }
    }
}