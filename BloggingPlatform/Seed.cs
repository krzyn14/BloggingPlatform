using BloggingPlatform.Models; 

namespace BloggingPlatform
{
    public class Seed
    {
        private readonly DatabaseContext databaseContext; 

        public Seed(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void SeedDataContext()
        {
            if(!databaseContext.Users.Any() && !databaseContext.BlogPosts.Any()) { 
                var users = new List<User>();   

                users.Add(new User { Email = "jankowalski@gmail.com", Username = "Jan"});
                users.Add(new User { Email = "gwszola@gmail.com", Username = "Grzegorz1" });
                users.Add(new User { Email = "ekowalewicz@gmail.com", Username = "Eryk33" });
                users.Add(new User { Email = "krogan@gmail.com", Username = "Krzysztof4" });

                var blogs = new List<BlogPost>(); 

                blogs.Add(new BlogPost { User = users[0], Content = "Hello World!", Title = "First Post" });
                blogs.Add(new BlogPost { User = users[1], Content = "I don't like pizza", Title = "Pizza" });
                blogs.Add(new BlogPost { User = users[2], Content = "I have just met Elon Musk", Title = "WOOW" });
                blogs.Add(new BlogPost { User = users[3], Content = "Greetings from Greece", Title = "Holidays!" });

                databaseContext.Users.AddRange(users);
                databaseContext.BlogPosts.AddRange(blogs);

                databaseContext.SaveChanges();


            }
        }
    }
}
