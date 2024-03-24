using BloggingPlatform.Interfaces;
using BloggingPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatform.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext) 
        { 
            _databaseContext = databaseContext;
        }

        public bool CreateUser(User user)
        {
            _databaseContext.Users.Add(user);

            return Save();
        } 

        public bool RemoveUser(User user) 
        { 
            _databaseContext.Users.Remove(user); 

            return Save();
        }

        public User GetUserById(int Id)
        {
            return _databaseContext.Users.FirstOrDefault(u => u.Id == Id); 
        }

        public ICollection<User> GetUsers()
        {
            return _databaseContext.Users.OrderBy(x => x.Id).ToList();
        }
        public bool IsEmailUnique(string email)
        {
            var user = _databaseContext.Users.FirstOrDefault(x => x.Email == email);

            if (user != null)
                return false; 

            return true;
        }

        public bool Save()
        {
            var saved = _databaseContext.SaveChanges();

            return saved > 0 ? true : false;
        }

        public bool UserExists(int Id)
        {
            return _databaseContext.Users.Any(x => x.Id == Id);
        }
    }
}
