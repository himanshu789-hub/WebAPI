using CarPoolAPI.Enums;
using CarPoolAPI.RepositoryInterfaces;
using System;
using CarPoolAPI.Models;
using System.Linq;
using System.Collections.Generic;
using CarPoolAPI.PostModel;
using Microsoft.EntityFrameworkCore;
namespace CarPoolAPI.RepositoryProcessory
{
    public class OfferringRepository : IOfferringRepository
    {
        CarPoolContext _context;
        public OfferringRepository(CarPoolContext context)
        {
            _context = context;
        }
        public Offerring Create(PostOfferring postOfferring)
        {
            Offerring offer = new Offerring
            {
                Active = true,
                CurrentLocation = postOfferring.Source,
                Destination = postOfferring.Destination,
                Source = postOfferring.Source,
                UserId = postOfferring.UserId,
                Discount = postOfferring.Discount,
                MaxOfferSeats = postOfferring.MaxOfferSeats,
                PricePerKM = postOfferring.PricePerKM,
                VechicleRef = postOfferring.VehicleRef,
                StartTime =postOfferring.StartTime,
                TentativeTime = postOfferring.TentativeTime
    };
            var offerring = _context.Offerrings.Add(offer).Entity;
            _context.SaveChanges();
            foreach (Address point in postOfferring.Route)
            {
                _context.ViaPoints.Add(new ViaPoints { Branch = point, OfferId =  offerring.Id});
            }
            _context.SaveChanges();

            return _context.Offerrings.Where(e => e.Id == offerring.Id).Include(e => e.ViaPoints).Include(e=>e.Vechicles).Include(e=>e.User).Single(); 
        }
        public bool Update(PostOfferring putOfferring)
        {
            bool flag = true;
            if (IsUpdatable(putOfferring.Id))
            {
                using(CarPoolContext context = new CarPoolContext())
                {
                    Offerring offer = context.Offerrings.Where(e => e.Id == putOfferring.Id).Single();
                    List<AnounceOfferring> anounceOfferrings = context.AnounceOfferrings.Where(e => e.OfferId == putOfferring.Id).ToList();
                    foreach(AnounceOfferring anounceOfferring in anounceOfferrings)
                    {
                        anounceOfferring.Status = AnounceStatus.CANCELED;
                    }
                    offer.Source = putOfferring.Source;
                    offer.Destination = putOfferring.Destination;
                    offer.Discount = putOfferring.Discount;
                    offer.CurrentLocation = putOfferring.Source;
                    offer.StartTime = putOfferring.StartTime;
                    offer.TentativeTime = putOfferring.TentativeTime;
                    offer.TotalEarning = 0;
                    context.ViaPoints.RemoveRange(context.ViaPoints.Where(e=>e.OfferId==offer.Id).ToList());
                    foreach(Address location in putOfferring.Route)
                        context.Add(new ViaPoints() { Branch = location, OfferId = offer.Id });
                    
                    context.SaveChanges();
                }
              flag = true;
            }
            else
                flag =  false;

            return flag;
        }
        public bool IsUpdatable(int id)
        {
            bool flag;
            using(var context = new CarPoolContext())
            {
    int count = context.Bookings.Where(e => e.OfferId == id && e.BookingStatus==BookingStatus.REQUESTED||e.BookingStatus==BookingStatus.ACCEPTED).Count();
                    if (count == 0)
                        flag = true;
                    else
                        flag = false;
           }
            return flag;
        }
        public bool Delete(int id,Address place)
        {
            Offerring offerring = new Offerring();
            using (var context = new CarPoolContext())
            {
                Address currentLocation = context.Offerrings.Where(e => e.Id == id).Select(e => e.CurrentLocation).Single(); 
                foreach(Booking booking in context.Bookings.Where(e => e.OfferId == id && e.Active && e.Destination>=currentLocation ))
                {
                    booking.BookingStatus = BookingStatus.DESTROYED;
                    booking.Active = false;
                }
                context.SaveChanges();
            }
            return true;
        }
        public List<Offerring> GetActiveOffers()
        {
            List<Offerring> offerrings = new List<Offerring>();
            using(var context =  new CarPoolContext())
            {
                offerrings = context.Offerrings.Include(e=>e.Bookings).ThenInclude(e=>e.User).Include(e=>e.User).Include(e=>e.Vechicles).Include(e=>e.ViaPoints).ToList();
            }
            return offerrings;
        }
        public List<Offerring> GetByEndPoints(Address Source, Address Destination)
        {
            List<Offerring> offerringsResult = new List<Offerring>();
            List<Offerring> offerrings = _context.Offerrings.Where(e=>e.Active).
            Include(e=>e.ViaPoints).Include(e=>e.User).Include(e=>e.Vechicles).ToList();
            if (offerrings.Count == 0)
                return null;
            foreach (Offerring offer in offerrings)
            {
                List<Address> route = new List<Address>();
                route.Add(offer.Source);
                route.AddRange(_context.ViaPoints.Where(e => e.OfferId.Equals(offer.Id)).Select(e => e.Branch).ToList());
                route.Add(offer.Destination);
                List<Address> path = new List<Address>();
                //if (route.IndexOf(Source) != -1 && route.IndexOf(Destination) != -1)
                //{
                //    s = route.IndexOf(Source);d = route.IndexOf(Destination);
                //    path.AddRange(route.GetRange(0,route.IndexOf(Destination)));
                //}
                //else if (route.IndexOf(Source) != -1 && route.IndexOf(Destination) == -1)
                //{
                //    s = route.IndexOf(Source);d = route.Count()-1;
                //    path.AddRange(route.GetRange(route.IndexOf(Source), route.Count()-route.IndexOf(Source)-1));
                //}
                //else if (route.IndexOf(Source) == -1 && route.IndexOf(Destination) != -1)
                //{
                //    s = 0;d = route.IndexOf(Destination);
                //    path.AddRange(route.GetRange(0, route.IndexOf(Destination)));
                //}
                //else
                //    continue;
                if (route.IndexOf(Source) != -1 && route.IndexOf(Destination) != -1)
                {
                    path.AddRange(route.GetRange(0, route.IndexOf(Destination)));
                }
                else
                    continue;

                int numberOfBookedSeats = 0;
                bool flag = false;
                Address Link = 0;

                foreach (Address branch in path)
                {
                    numberOfBookedSeats -= _context.Bookings.Where(e => e.Active == true && e.Offerring.Id == offer.Id && e.BookingStatus == BookingStatus.ACCEPTED && e.Destination == branch).Count();

                    numberOfBookedSeats += _context.Bookings.Where(e => e.Active == true && e.Offerring.Id == offer.Id && e.BookingStatus == BookingStatus.ACCEPTED && e.Soure == branch).Count();
                    if (numberOfBookedSeats >= offer.MaxOfferSeats)
                    {
                        Link = branch;
                        flag = true;
                        break;
                    }

                }

                if (!flag)
                {
                    offerringsResult.Add(offer);
                }
                else
                {
                    if (route.IndexOf(Source) >= route.IndexOf(Link) && route.IndexOf(Destination) > route.IndexOf(Link))
                    {
                        offerringsResult.Add(offer);
                    }
                    else
                        continue;

                }
                //if (numberOfBookedSeats < o.MaxOfferSeats)
                //{
                //    int count = _context.Bookings.Where(e => e.Active == true && e.BookingStatus == BookingStatus.ACCEPTED && (e.Soure >= o.Source && e.Destination <= o.Destination)).Count();
                //    int count = _context.Bookings.Where(e => e.Active == true && e.OfferId == o.Id).ToList().FindAll(e => e.BookingStatus == BookingStatus.ACCEPTED && (e.Soure >= o.Source && e.Destination <= o.Destination)).Count();
                //    if (count > 0 && count + numberOfBookedSeats >= o.MaxOfferSeats)
                //    {

                //        continue;
                //    }
                //    else
                //        offerringsResult.Add(o);
                //}
                //else
                //    continue;
            }

            return offerringsResult;
        }
        public Offerring GetById(int id)
        
        {
            var view = _context.Offerrings.Where(e=>e.Active && e.Id==id).Include(e=>e.ViaPoints).Include(e=>e.Bookings).Single();
            return view;
        }
        public bool IsEndPointsWithinReachByOfferId(int offerId, Address source, Address destination)
        {
            bool flag = false;
            using (var context = new CarPoolContext())
            {
                List<Address> route = new List<Address>();
                Offerring offer = context.Offerrings.Where(e=>e.Id==offerId).ToList().First();
                route.Add(offer.Source);
                route.AddRange(context.ViaPoints.Where(e => e.OfferId.Equals(offer.Id)).Select(e => e.Branch).ToList());
                route.Add(offer.Destination);
                List<Address> path = new List<Address>();

                if (route.IndexOf(source) != -1 && route.IndexOf(destination) != -1)
                {
                    flag = true;
                }
            }
            return flag;
        }

    }
}
