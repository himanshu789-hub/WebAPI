using System.Collections.Generic;
using CarPoolAPI.RepositoryInterfaces;
using CarPoolAPI.PostModel;
using CarPoolAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolAPI.Controllers
{
    public class AnnounceController : ControllerBase
    {
        readonly  IAnnounceRepository _repos;
        public AnnounceController(IAnnounceRepository repos) => _repos = repos;
     
        [HttpPost]
        public void Add([FromBody]PostAnnounce postAnnounce)
        {
            _repos.Create(postAnnounce);
        }

        [HttpPut]
        public bool Update([FromBody]PostAnnounce postAnnounce)
        {
          return  _repos.Update(postAnnounce);
        }

        [HttpPut]
        public bool Delete(int userId)
        {
           return _repos.Delete(userId);
        }

        public Anounce GetById([FromQuery] int id)
        {
            return _repos.GetById(id);
        }

        [HttpGet]
        public List<Offerring> GetOfferById([FromQuery]int id)
        {
            return _repos.GetOffersById(id);
        }
        
        [HttpGet]
        public List<Anounce> GetAll()
        {
            return _repos.GetAll();
        }

        [HttpGet]
        public List<Anounce> GetAnouncesByOfferId([FromQuery] int offerId)
        {
            return _repos.GetAnnouncesByOfferId(offerId);
        }

        [HttpPost]
        public bool AcceptAnnounce([FromBody]PostAnnounce postAnnounce)
        {
           return _repos.AcceptAnnounce(postAnnounce.Id, postAnnounce.OfferId);
        }

        [HttpPut]
        public bool Confirmation([FromBody]PostAnnounce postAnnounce)
        {
           return _repos.CommitAnnounce(postAnnounce.Id, postAnnounce.OfferId);
        }
    }
}
