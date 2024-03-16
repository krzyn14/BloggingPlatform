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

        public void AddBlogPost(/*parameters*/)
        {
            throw new NotImplementedException();
        }

        public void EditBlogPost(int Id)
        {
            //tbd - first let's think what should be edited
            throw new NotImplementedException();
        }

        public ICollection<BlogPost> GetBlogPosts()
        {
            return _databaseContext.BlogPosts.OrderBy(x => x.Id).ToList();
        }

        public void RemoveBlogPost(int Id)
        {
            var blogPost = _databaseContext.BlogPosts.FirstOrDefault(x => x.Id == Id);
            _databaseContext.Remove(blogPost);
        }
    }
}
