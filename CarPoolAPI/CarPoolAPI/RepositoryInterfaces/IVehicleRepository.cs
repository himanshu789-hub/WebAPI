using CarPoolAPI.Models;
using CarPoolAPI.PostModel;
using System.Collections.Generic;

namespace CarPoolAPI.RepositoryInterfaces
{
    public interface IVehicleRepository
    {
        public Vechicles Create(PostVehicle postVehicle);
        public bool Update(PostVehicle postVehicle);
      // public bool Delete(int id);
        public List<Vechicles> GetAll();
        public Vechicles GetById(int id);        
    }
}
