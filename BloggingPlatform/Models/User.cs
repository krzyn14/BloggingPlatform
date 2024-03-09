using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BloggingPlatform.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public List<BlogPost>? Posts { get; set; } = new List<BlogPost>(); 
    }
}
