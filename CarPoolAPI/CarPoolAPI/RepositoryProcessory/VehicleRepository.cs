using CarPoolAPI.Enums;
using CarPoolAPI.Models;
using CarPoolAPI.PostModel;
using CarPoolAPI.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CarPoolAPI.RepositoryProcessory
{
    public class VehicleRepository:IVehicleRepository
    {
        private readonly Dictionary<VehicleType, int> VehicleCapacity = new Dictionary<VehicleType, int> {
        [VehicleType.MOPED] = 2,[VehicleType.HATCHBACK]=4,[VehicleType.LIMO]=10,[VehicleType.BIKE]=2,[VehicleType.OPEN_AIR]=2,[VehicleType.SEDAN]=4,[VehicleType.SUV]=6
        };
        
        public Vechicles Create(PostVehicle postVehicle)
        {
            Vechicles aVehicle = null;
            using(var context = new CarPoolContext())
            {
               var vechicle = context.Add(new Vechicles() { Capacity = VehicleCapacity[postVehicle.Type], NumberPlate = postVehicle.NumberPlate,Type=postVehicle.Type });
                context.SaveChanges();
                aVehicle = vechicle.Entity;
            }
            return aVehicle; 
        }

        public List<Vechicles> GetAll()
        {
            List < Vechicles > vechicles = new List<Vechicles>();
            using(var context = new CarPoolContext())
            {
              vechicles = context.Vechicles.ToList();
            }
            return vechicles;
        }

        public Vechicles GetById(int id)
        {
            Vechicles vehicle;
            using(var context = new CarPoolContext())
            {
                vehicle = context.Vechicles.Find(id);
            }
            return vehicle;
        }

        public bool Update(PostVehicle postVehicle)
        {
            bool flag = false;
          //###
            postVehicle.Capacity = VehicleCapacity[postVehicle.Type];
            if (postVehicle.Capacity <= postVehicle.MaxOffer)
                return false;
                using (var context = new CarPoolContext())
            {
                if (context.Offerrings.Find(postVehicle.OfferId).DepartTime == DateTime.MinValue)
                {
                    Offerring offer = context.Offerrings.Single(e => e.Id == postVehicle.OfferId);
                     int count = context.Bookings.Where(e => e.OfferId == postVehicle.OfferId && e.Active && (e.BookingStatus==BookingStatus.REQUESTED||e.BookingStatus==BookingStatus.ACCEPTED)).Count();
                    if (postVehicle.MaxOffer >= offer.MaxOfferSeats && count <= postVehicle.Capacity )
                    {
                            Vechicles vechicles = context.Vechicles.Find(postVehicle.Id);
                            vechicles.NumberPlate = postVehicle.NumberPlate;
                            vechicles.Type = postVehicle.Type;
                            vechicles.Capacity = VehicleCapacity[vechicles.Type];
                        }
                        offer.MaxOfferSeats = postVehicle.MaxOffer;

                    context.SaveChanges();
                    flag = true;

                    }
                    else
                        flag = false;
                }
            return flag;

        }
    }
}
