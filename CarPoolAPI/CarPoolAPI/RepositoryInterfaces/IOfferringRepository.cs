using System.Collections.Generic;
using CarPoolAPI.PostModel;
using CarPoolAPI.Enums;
using CarPoolAPI.Models;

namespace CarPoolAPI.RepositoryInterfaces
{
    public interface IOfferringRepository
    {
         public Offerring Create(PostOfferring postOfferring);
         public bool Delete(int id,Address place);
         public List<Offerring> GetByEndPoints(Address Source, Address Destination);
         public Offerring GetById(int id);
         public bool IsEndPointsWithinReachByOfferId(int OfferId,Address source, Address destination);
         public List<Offerring> GetActiveOffers();
         public bool Update(PostOfferring postOfferring);
//Why to have get all for admin, he can downlaod whole file instead of getting whole data}
    }
}
