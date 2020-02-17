﻿using CarPoolAPI.Models;
using CarPoolAPI.PostModel;
using CarPoolAPI.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarPoolAPI.Controllers
{
 
    //DONE
    public class UserController : ControllerBase
    {
       readonly IUserRepository _repos;

        public UserController(IUserRepository repos) => _repos = repos;
        
        [HttpGet]
        public List<User> GetAll()
        {
            return _repos.GetAll();
        }//DONE

        [HttpPost]
        public User Create([FromBody]PostUser user)
        {
           return _repos.Create(user);
        }//DONE

        [HttpGet]
        public User GetById([FromQuery]int id)
        {
            return _repos.GetById(id);
        }//DONE

        [HttpGet]
        public bool Login([FromQuery]int userid, [FromQuery]string password)
        {
            return _repos.LogIn(userid, password);
        }//DONE

    }
}