using CarPoolAPI.Enums;
using CarPoolAPI.Models;
using CarPoolAPI.PostModel;
using System.Collections.Generic;

namespace CarPoolAPI.RepositoryInterfaces
{
  public  interface IBookingRepository
    {
        Booking Create(PostBooking postBooking);
        Booking AcceptBooking(PostBooking postBooking);
        BookingStatus GetStatusById(int id);
        List<Booking> GetByOfferId(int offerId);
        bool Update(int bookingId,BookingStatus bookingStatus);
        bool Delete(int bookingId);
        List<Booking> GetAll();        
    //    public void AcceptRequest(int bookingId);
    //    public void Closed(int userId);
    //    public void RejectABooking(int bookingId);
    //    public void AddAnnounceBooking(PostBooking postBooking);
    }
}
