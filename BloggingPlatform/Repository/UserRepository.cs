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

        public void UpdateUserMail(int Id)
        {
            throw new NotImplementedException();
        } 

        public bool UserExists(int Id)
        {
            return _databaseContext.Users.Any(x => x.Id == Id);
        }
    }
}
