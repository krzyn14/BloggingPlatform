using BloggingPlatform.Models;

namespace BloggingPlatform.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUserById(int Id);
      //ICollection<User> UpdateUserMail(int Id); 
    }
}
