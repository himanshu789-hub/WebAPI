using CarPoolAPI.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using CarPoolAPI.PostModel;
using CarPoolAPI.Models;
using CarPoolAPI.Enums;
using System.Collections.Generic;

namespace CarPoolAPI.Controllers
{
    public class OfferringController : ControllerBase
    {
        readonly IOfferringRepository _repos;
        readonly IAnnounceRepository _announceRepos;
        public OfferringController(IOfferringRepository repos, IAnnounceRepository announceRepos) { 
            _repos = repos; _announceRepos = announceRepos; 
        }

        [HttpPost]
        //POST
        public Offerring Add([FromBody]PostOfferring offerring)
        {
          return _repos.Create(offerring);
        }

        [HttpGet]
        public List<Offerring> GetByEndPoints([FromQuery]Address source, [FromQuery]Address destination)
        {
           return _repos.GetByEndPoints(source, destination);
        }

        //DONE
        [HttpGet]
        public Offerring GetById([FromQuery]int id)
        {
            return _repos.GetById(id);
        }

        [HttpGet]
        public List<Anounce> GetAnouncesById(int offerId)
        {
            return _announceRepos.GetAnnouncesByOfferId(offerId);
        }

        public bool Delete(PostOfferring postOfferring)
        {
            return _repos.Delete(postOfferring.Id,postOfferring.Location);
        }

    }
}