using BloggingPlatform.Models;

namespace BloggingPlatform.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUserById(int Id);
        void UpdateUserMail(int Id, string mail);  
        bool UserExists(int Id);
    }
}
