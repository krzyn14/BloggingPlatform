using BloggingPlatform.Interfaces;
using BloggingPlatform.Models;

namespace BloggingPlatform.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext) 
        { 
            _databaseContext = databaseContext;
        }
        public User GetUserById(int Id)
        {
            return _databaseContext.Users.FirstOrDefault(u => u.Id == Id); 
        }

        public ICollection<User> GetUsers()
        {
            return _databaseContext.Users.OrderBy(x => x.Id).ToList();
        }

        public void UpdateUserMail(int Id, string mail)
        {
            var user = _databaseContext.Users.FirstOrDefault(x => x.Id == Id);  
            user.Email = mail;

            _databaseContext.Users.Update(user); 
            _databaseContext.SaveChanges();
        } 

        public bool UserExists(int Id)
        {
            return _databaseContext.Users.Any(x => x.Id == Id);
        }
    }
}
