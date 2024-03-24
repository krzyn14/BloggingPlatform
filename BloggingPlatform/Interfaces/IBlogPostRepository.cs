using BloggingPlatform.Models;

namespace BloggingPlatform.Interfaces
{
    public interface IBlogPostRepository
    {
        ICollection<BlogPost> GetBlogPosts(); 
        bool AddBlogPost(BlogPost blogPost); 
        bool RemoveBlogPost(BlogPost blogPost); 
        bool EditBlogPost(int postId, string title, string content);
        BlogPost GetBlogPost(int id); 
        ICollection<BlogPost> GetBlogPostsByUserId(int id);
        bool BlogPostExists(int id); 
        bool Save();
    }
}
