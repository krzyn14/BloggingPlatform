﻿namespace BloggingPlatform.Dto
{
    public class BlogPostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } 
        public int UserId { get; set; }
    }
}
