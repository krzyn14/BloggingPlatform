using AutoMapper;
using BloggingPlatform.Dto;
using BloggingPlatform.Models;

namespace BloggingPlatform.Mapper 
{
    public class MappingProfiles : Profile
    { 
        public MappingProfiles() 
        {
            CreateMap<User, UserDto>(); 
            CreateMap<BlogPost, BlogPostDto>();
        }
    }
}
