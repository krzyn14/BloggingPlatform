using BloggingPlatform.Models;

namespace BloggingPlatform.Interfaces
{
    public interface IBlogPostRepository
    {
        ICollection<BlogPost> GetBlogPosts(); 
        void AddBlogPost(); 
        void RemoveBlogPost(int Id); 
        void EditBlogPost(int Id);
    }
}
