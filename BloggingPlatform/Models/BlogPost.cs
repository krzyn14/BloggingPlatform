
namespace BloggingPlatform.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public User User { get; set; } 
        public int UserId { get; set; } //shadow foreign key propery can be used but implementing id is more comfortable for filtering 
    }
}
