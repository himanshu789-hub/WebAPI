using CarPoolAPI.Models;
using CarPoolAPI.PostModel;
using System.Collections.Generic;
using CarPoolAPI.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolAPI.Controllers
{
    //DONE
    public class VehicleController:ControllerBase
    {
       readonly IVehicleRepository _repos;
        public VehicleController(IVehicleRepository repos) => _repos = repos;

        [HttpGet]
        public List<Vechicles> GetAll()
        {
            return _repos.GetAll();
        }

        [HttpGet]
        public Vechicles GetById(int offerId)
        {
            return _repos.GetById(offerId);
        }

        [HttpPost]
        public  Vechicles PostVehicle([FromBody]PostVehicle postVehicle)
        {
            return _repos.Create(postVehicle);
        }

        [HttpPut]
        public bool Update([FromBody]PostVehicle postVehicle)
        {
            return _repos.Update(postVehicle);
        }
    }
}
