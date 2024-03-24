using BloggingPlatform.Interfaces;
using BloggingPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatform.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly DatabaseContext _databaseContext; 

        public BlogPostRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool AddBlogPost(BlogPost blogPost)
        {
            _databaseContext.Add(blogPost);

            return Save();
        }

        public bool EditBlogPost(int postId, string title, string content)
        {
            var post = _databaseContext.BlogPosts.FirstOrDefault(p => p.Id == postId);

            post.Title = title;
            post.Content = content;
            post.UpdatedDate = DateTime.Now;

            _databaseContext.Update(post);

            return Save();
        }

        public ICollection<BlogPost> GetBlogPosts()
        {
            return _databaseContext.BlogPosts.AsNoTracking().OrderBy(x => x.Id).ToList();
        }

        public bool RemoveBlogPost(BlogPost blogPost)
        {
            _databaseContext.Remove(blogPost);

            return Save();
        }

        public BlogPost GetBlogPost(int id)
        {
            return _databaseContext.BlogPosts.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public ICollection<BlogPost> GetBlogPostsByUserId(int userId)
        {
            return _databaseContext.BlogPosts.AsNoTracking().Where(x => x.UserId == userId).OrderBy(x => x.Id).ToList();
        }

        public bool BlogPostExists(int blogPostId)
        {
            return _databaseContext.BlogPosts.AsNoTracking().Any(x => x.Id == blogPostId);
        }

        public bool Save()
        {
            var saved = _databaseContext.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
