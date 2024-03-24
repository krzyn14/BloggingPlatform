using BloggingPlatform.Models;

namespace BloggingPlatform.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUserById(int Id);
        bool UserExists(int Id);
        bool CreateUser(User user);
        bool RemoveUser(User user);
        bool IsEmailUnique(string email);
        bool Save();
    }
}
