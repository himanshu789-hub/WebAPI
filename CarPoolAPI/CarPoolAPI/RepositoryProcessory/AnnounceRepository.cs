using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPoolAPI.Models;
using CarPoolAPI.PostModel;
using CarPoolAPI.Enums;
using CarPoolAPI.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
namespace CarPoolAPI.RepositoryProcessory
{
    //DONE
    public class AnnounceRepository:IAnnounceRepository
    {
         IOfferringRepository _offerRepos;
         IBookingRepository _bookRepos;
        public AnnounceRepository(IOfferringRepository offerRepos, IBookingRepository bookRepos) { _offerRepos = offerRepos; _bookRepos = bookRepos; }
        public Anounce Create(PostAnnounce announce)
        {
            Anounce addedAnnounce = null;
            using (var context = new CarPoolContext())
            {
               var createdAnnounce = context.Anounces.Add(new Anounce() { Active = true, Destination = announce.Destination, Source = announce.Source, UserId = announce.UserId});
                context.SaveChanges();
                addedAnnounce = createdAnnounce.Entity;
            }
         return addedAnnounce;
        }
        public bool Update(PostAnnounce postAnnounce)
        {
            bool  flag = false;
            using(var context = new CarPoolContext())
            {
                //announceId 
               Anounce tempAnounce =  context.Anounces.Where(e=>e.Id==postAnnounce.Id).Include(e=>e.User).First();
                if (tempAnounce == null)
                    flag =  false;
                else
                    {
                    tempAnounce.Source = postAnnounce.Source;
                    tempAnounce.Destination = postAnnounce.Destination;
                    flag = true;
                    context.SaveChanges();
                }
                    
            }
            return flag;
        }
        public bool Delete(int userId)
        {
            using(var context =  new CarPoolContext())
            {
                List<Anounce> anounces = context.Anounces.Where(e => e.Active == true).ToList();
                Anounce tempAnounce = anounces.Find(e=>e.UserId==userId);
                tempAnounce.Active = false;

                List<AnounceOfferring> anounceOfferrings = context.AnounceOfferrings.Where(e => e.AnounceId == tempAnounce.Id && e.Status == AnounceStatus.APPROVED || e.Status == AnounceStatus.COMMITTED).ToList();
                if(anounceOfferrings!=null)
                {
                    foreach(AnounceOfferring anounceOfferring in anounceOfferrings)
                    {
                        anounceOfferring.Status = AnounceStatus.CANCELED;
                    }
                }
                context.SaveChanges();
            }
            return true;
        }
        public List<Anounce> GetAnnouncesByOfferId(int offerId)
        {
            List<Anounce> anounces = new List<Anounce>();
            using(var context =  new CarPoolContext())
            {
                List<Anounce> tempAnounces = context.Anounces.Where(e => e.Active == true && e.BookingRef==null).ToList();
                foreach(Anounce announce in tempAnounces)
                {
                    if (_offerRepos.IsEndPointsWithinReachByOfferId(offerId, announce.Source, announce.Destination))
                    {
                        anounces.Add(announce);
                    }
                }
            }
            if (anounces.Count == 0)
                return null;

            return anounces;
        }
        public List<Offerring> GetOffersById(int id)
        {
            List<Offerring> offerrings = new List<Offerring>();

            using (var context = new CarPoolContext())
            {
                Anounce anounce = context.Anounces.Where(e=>e.Id==id).ToList().First();
                List<int> approvedOfferer = context.AnounceOfferrings.Where(e => e.AnounceId == id).Select(e=>e.OfferId).ToList();
                offerrings.AddRange(context.Offerrings.Where(e=> approvedOfferer.Contains(e.Id)).Include(e=>e.User).Include(e=>e.Vechicles).Include(e=>e.ViaPoints));
            }
            if (offerrings.Count == 0)
                return null;
         return offerrings;
        }
        public bool AcceptAnnounce(int announceId,int offerId)
        {
            using(var context =  new CarPoolContext())
            {
                context.AnounceOfferrings.Add(new AnounceOfferring() { AnounceId = announceId, OfferId = offerId, Status = AnounceStatus.APPROVED });
                context.SaveChanges();
            }
            return true;
        }
        public bool CommitAnnounce(int id,int offerId)
        {
          using(var context = new CarPoolContext())
            {
              List<AnounceOfferring> anounceOfferrings =  context.AnounceOfferrings.Where(e => e.AnounceId == id).ToList();
              foreach(AnounceOfferring anounceOfferring in anounceOfferrings)
                {
                    if (anounceOfferring.OfferId == offerId)
                    {
                        anounceOfferring.Status = AnounceStatus.COMMITTED;
                        Anounce anounce = context.Anounces.Where(e => e.Id == id).ToList().First();
                        PostBooking postBooking = new PostBooking()
                        {
                            AnnounceId = id,
                            BookingStatus = BookingStatus.ACCEPTED,
                            FarePrice = 0,
                            OfferId = offerId,
                          
                            UserId = anounce.UserId,RequestedSource=anounce.Source,RequestedDestination=anounce.Destination
                        };
                        _bookRepos.AcceptBooking(postBooking); 
                                              
                    }
                    else
                        anounceOfferring.Status = AnounceStatus.REJECTED;
                }
                context.SaveChanges();
                return true;
            }
        }
        public Anounce GetById(int anounceId)
        {
            Anounce anounce;
          using(var context =  new CarPoolContext())
            {
                //make use of lazy loading 
                //don't allow to give user object with password
             anounce = context.Anounces.Where(e=>e.Id==anounceId).Include(e=>e.User).First();
            }
            return anounce;
        }
        public List<Anounce> GetAll()
        {
            List < Anounce > anounces = new List<Anounce>();
            using(var context =  new CarPoolContext())
            {
                anounces = context.Anounces.Include(e => e.Booking).ToList();
            }
            return anounces;
        }
    }
}
