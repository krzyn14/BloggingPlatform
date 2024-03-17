using BloggingPlatform.Interfaces;
using BloggingPlatform.Models;

namespace BloggingPlatform.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly DatabaseContext _databaseContext; 

        public BlogPostRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void AddBlogPost(string title, string content, int userId)
        {
            var newPost = new BlogPost { Title = title, Content = content, UserId = userId}; 

            _databaseContext.Add(newPost);
            _databaseContext.SaveChanges();
        }

        public void EditBlogPost(int Id, string? content, string? title, int userId)
        {
            //tbd - first let's think what should be edited
            throw new NotImplementedException();
        }

        public ICollection<BlogPost> GetBlogPosts()
        {
            return _databaseContext.BlogPosts.OrderBy(x => x.Id).ToList();
        }

        public void RemoveBlogPost(int Id, int userId)
        {
            var blogPost = _databaseContext.BlogPosts.FirstOrDefault(x => x.Id == Id);
            _databaseContext.Remove(blogPost);
        }

        public BlogPost GetBlogPost(int id)
        {
            return _databaseContext.BlogPosts.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<BlogPost> GetBlogPostsByUserId(int userId)
        {
            return _databaseContext.BlogPosts.Where(x => x.UserId == userId).OrderBy(x => x.Id).ToList();
        }

        public bool BlogPostExists(int blogPostId)
        {
            return _databaseContext.BlogPosts.Any(x => x.Id == blogPostId);
        }
    }
}
