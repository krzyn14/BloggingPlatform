using BloggingPlatform.Interfaces;
using BloggingPlatform.Models;
using System.Collections.Immutable;

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
            _posts.Add(blogPost);

            return true;
        }

        public bool BlogPostExists(int id)
        {
           return _posts.Any(x => x.Id == id);
        }

        public bool CreateUser(User user)
        {
            _users.Add(user);

            return true;
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
            return _posts;
        }

        public ICollection<BlogPost> GetBlogPostsByUserId(int id)
        {
            return _posts.Where(x => x.UserId == id).ToImmutableList();
        }

        public User GetUserById(int Id)
        {
            return _users.FirstOrDefault(x => x.Id == Id);
        }

        public ICollection<User> GetUsers()
        {
            return _users;
        }

        public bool IsEmailUnique(string email)
        {
            var user = _users.FirstOrDefault(x => x.Email == email);

            if (user != null)
                return false; 

            return true;
        }

        public bool RemoveBlogPost(BlogPost blogPost)
        {
            _posts.Remove(blogPost); 

            return true;
        }

        public bool RemoveUser(User user)
        {
            _users.Remove(user);

            return true;
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
