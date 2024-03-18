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
            CreateMap<UserDto, User>();
            CreateMap<BlogPost, BlogPostDto>(); 
            CreateMap<BlogPostDto, BlogPost>(); 
            CreateMap<BlogPostUpdateDto, BlogPost>(); 
            CreateMap<BlogPost, BlogPostUpdateDto>();
        }
    }
}
