using BloggingPlatform.Interfaces;
using BloggingPlatform.Models;

namespace BloggingPlatform.Tests
{
    public class BloggingPlatformUserRepoFake : IBlogPostRepository, IUserRepository
    {
        private readonly List<User> _users;
        private readonly List<BlogPost> _posts; 

        public BloggingPlatformUserRepoFake()
        { 
            _users = new List<User>() 
            {
                new User() {Id = 1, Email = "user1@gmail.com", Username = "user1"}, 
                new User() {Id = 2, Email = "user2@gmail.com", Username = "user2"}, 
                new User() {Id = 3, Email = "user3@gmail.com", Username = "user3"}
            };

            _posts = new List<BlogPost>()
            {
                new BlogPost() {Id = 1, User = _users[0], Content = "User1 is an author", Title = "User1 - My Post",
                    CreatedDate = DateTime.Now, UserId = 1},
                new BlogPost() {Id = 2, User = _users[1], Content = "User2 is an author", Title = "User2 - My Post",
                    CreatedDate = DateTime.Now, UserId= 2}
            };
        }

        public bool AddBlogPost(BlogPost blogPost)
        {
            throw new NotImplementedException(); //we don't need it
        }

        public bool BlogPostExists(int id)
        {
           return _posts.Any(x => x.Id == id);
        }

        public bool CreateUser(User user)
        {
            throw new NotImplementedException(); //we don't need it
        }

        public bool EditBlogPost(int postId, string title, string content)
        {
            var post = _posts.FirstOrDefault(x => x.Id == postId);

            post.Title = title; 
            post.Content = content; 
            post.UpdatedDate = DateTime.Now;

            _posts[post.Id - 1] = post;

            return true;
        }

        public BlogPost GetBlogPost(int id)
        {
            return _posts.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<BlogPost> GetBlogPosts()
        {
            throw new NotImplementedException(); //we don't need it 
        }

        public ICollection<BlogPost> GetBlogPostsByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool IsEmailUnique(string email)
        {
            throw new NotImplementedException();
        }

        public bool RemoveBlogPost(BlogPost blogPost)
        {
            _posts.Remove(blogPost); 

            return true;
        }

        public bool RemoveUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UserExists(int Id)
        {
            return _users.Any(x =>  x.Id == Id);
        }
    }
}
