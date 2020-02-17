using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPoolAPI.PostModel;
using CarPoolAPI.Models;
namespace CarPoolAPI.RepositoryInterfaces
{
    public interface IAnnounceRepository
    {
        Anounce Create(PostAnnounce announce);
        bool Update(PostAnnounce announce);
        bool Delete(int userId);
        bool AcceptAnnounce(int announceId, int offerId);
        List<Anounce> GetAnnouncesByOfferId(int offerId);
        List<Offerring> GetOffersById(int id);
        bool CommitAnnounce(int id,int offerId);
        List<Anounce> GetAll();
        Anounce GetById(int id);
    }
}
