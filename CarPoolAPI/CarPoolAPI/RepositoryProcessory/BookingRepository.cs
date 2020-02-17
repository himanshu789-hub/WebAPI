using CarPoolAPI.Enums;
using CarPoolAPI.RepositoryInterfaces;
using CarPoolAPI.Models;
using System.Linq;
using System.Collections.Generic;
using CarPoolAPI.PostModel;
using Microsoft.EntityFrameworkCore;
namespace CarPoolAPI.RepositoryProcessory
{
    public class BookingRepository : IBookingRepository
    {
        CarPoolContext _context;
        public BookingRepository(CarPoolContext context) => _context = context;
        
        public Booking Create(PostBooking postBooking)
        {
            Booking booking = new Booking
            {
                Active = true,
                BookingStatus = BookingStatus.REQUESTED,
                RequestedSource=postBooking.RequestedSource,
                RequestedDestination = postBooking.RequestedDestination,
                OfferId=postBooking.OfferId,
                UserId=postBooking.UserId
            };
            var addedBooking = _context.Bookings.Add(booking);
            _context.SaveChanges();
            return addedBooking.Entity;
        }
        public Booking AcceptBooking(PostBooking postBooking)
        {
            Booking book = new Booking()
            {
                UserId = postBooking.UserId,
                Active = true,
                AnounceId = postBooking.AnnounceId+"",
                BookingStatus = BookingStatus.ACCEPTED,
                RequestedSource=postBooking.RequestedSource,RequestedDestination=postBooking.RequestedDestination,
                Soure = postBooking.RequestedSource,
                Destination = postBooking.RequestedDestination,
                FarePrice = postBooking.FarePrice,
                OfferId = postBooking.OfferId,
                DateTime = postBooking.DateTime
            };
            
            using(var context  =  new CarPoolContext())
            {
                var booking = context.Bookings.Add(book);
                context.SaveChanges();
                book = booking.Entity;
                context.Anounces.Where(e => e.Id == postBooking.AnnounceId).ToList().First().BookingRef = context.Bookings.Select(e => e.Id).ToList().Max();
                context.SaveChanges();
            }
            return book;
        }
        public BookingStatus GetStatusById(int bookingId) => _context.Bookings.Find(bookingId).BookingStatus;
        public List<Booking> GetByOfferId(int offerId)
        {
            return _context.Bookings.ToList().FindAll(e => e.Active == true && e.OfferId.Equals(offerId) && e.BookingStatus==BookingStatus.REQUESTED);
        }
        public bool Update(int bookingId, BookingStatus bookingStatus)
        {
            if(bookingStatus==BookingStatus.ACCEPTED)
            {
                _context.Bookings.Where(b => b.Id.Equals(bookingId)).Single().BookingStatus = BookingStatus.ACCEPTED;
                _context.SaveChanges();
                return true;
            }
            else if(bookingStatus==BookingStatus.REJECTED)
            {

                List<Booking> l = _context.Bookings.Where(b => b.Id == bookingId).ToList();
                l.First().BookingStatus = BookingStatus.REJECTED;
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        public bool Delete(int bookingId)
        {
            Booking b = _context.Bookings.Where(b => b.Id==bookingId && b.Active == true).Single();
            b.Active = false;
            _context.SaveChanges();
            return true;
        }        
        public List<Booking> GetAll()
        {
            List<Booking> Bookings = new List<Booking>();
            using(var context = new CarPoolContext() )
            {
             Bookings = context.Bookings.Include(e => e.User).ToList();
            }
            if (Bookings.Count == 0)
                return null;
            return Bookings;

        }
    }
}
