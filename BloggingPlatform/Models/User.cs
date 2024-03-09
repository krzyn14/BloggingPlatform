namespace BloggingPlatform.Models
{
    public class User
    { 
        public int Id { get; set; }  
        public string UserName { get; set; } 
        public string Email { get; set; }
        public ICollection<BlogPost>? Posts { get; set; }
    }
}
