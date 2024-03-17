using BloggingPlatform.Models;

namespace BloggingPlatform.Interfaces
{
    public interface IBlogPostRepository
    {
        ICollection<BlogPost> GetBlogPosts(); 
        void AddBlogPost(string title, string content, int userId); 
        void RemoveBlogPost(int Id, int userId); 
        void EditBlogPost(int Id, string? content, string? title, int userId);
        BlogPost GetBlogPost(int id); 
        ICollection<BlogPost> GetBlogPostsByUserId(int id);
        bool BlogPostExists(int id);
    }
}
