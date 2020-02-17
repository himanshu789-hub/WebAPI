using CarPoolAPI.Enums;
using CarPoolAPI.Models;
using CarPoolAPI.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CarPoolAPI.PostModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarPoolAPI.Controllers
{
    public class BookingController : ControllerBase
    {
        readonly IBookingRepository _repos;
    
        public BookingController(IBookingRepository repos) => _repos = repos;

        [HttpGet]
        public BookingStatus ViewStatus([FromQuery]int bookingId)
        {
            return _repos.GetStatusById(bookingId);
        }

        [HttpGet]
        public List<Booking> GetAllByOfferId([FromQuery]int offerId)
        {
            return _repos.GetByOfferId(offerId);
        }

        [HttpPost]
        public Booking Create([FromBody] PostBooking booking)
        {
           return _repos.Create(booking);
        }

        [HttpPut]
        public Booking AcceptBooking([FromBody] PostBooking booking)
        {
        return _repos.AcceptBooking(booking);
        }

        [HttpPut]
        public Booking AddAnnounceBooking([FromBody]PostBooking postBooking)
        {
          return _repos.AcceptBooking(postBooking);
        }

        [HttpPut]
        public void UpdateBookingStatus([FromBody]PostBooking postBooking)
        {
           if(postBooking.BookingStatus==BookingStatus.COMPLETED)
            {
                _repos.Update(postBooking.Id,BookingStatus.COMPLETED);
            }
           else if(postBooking.BookingStatus==BookingStatus.REJECTED)
            {
                _repos.Update(postBooking.Id,BookingStatus.REJECTED);
            }
           else if(postBooking.BookingStatus==BookingStatus.ACCEPTED)
            {
                _repos.Update(postBooking.Id,BookingStatus.COMPLETED);
            }
        }
      
        [HttpGet]
        public List<Booking> GetAll()
        {
            return _repos.GetAll();
        }
    }
}
