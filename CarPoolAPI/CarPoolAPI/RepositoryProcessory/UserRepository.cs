using CarPoolAPI.RepositoryInterfaces;
using CarPoolAPI.Models;
using System.Linq;
using System.Collections.Generic;
using CarPoolAPI.PostModel;
namespace CarPoolAPI.RepositoryProcessory
{
    public class UserRepository:IUserRepository
    {
        CarPoolContext _context;
        public UserRepository(CarPoolContext context) => _context = context;

        public User Create(PostUser postUser)
        {
            User user = new User {Name=postUser.Name,Password=postUser.Password,Age=postUser.Age,Gender=postUser.Gender};
            var addedUser = _context.Users.Add(user);
            _context.SaveChanges();
          
            return addedUser.Entity;
        }   //DONE

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        } //DONE

        public User GetById(int userId)
        {
          return _context.Users.Find(userId);
        }   //DONE

        public bool LogIn(int userId, string password)
        {
            return _context.Users.Where(e => e.Id == userId && e.Password == password)!=null;
        }

    }
}
