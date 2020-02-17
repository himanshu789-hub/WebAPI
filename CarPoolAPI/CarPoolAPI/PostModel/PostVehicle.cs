using CarPoolAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPoolAPI.PostModel
{
    public class PostVehicle
    {
        public int Id { get; set; }
        public string NumberPlate { get; set; }
        public VehicleType Type { get; set; }
        public int MaxOffer { get; set; }
        public int Capacity { get; set; }
        public int OfferId { get; set; }


    }
}
