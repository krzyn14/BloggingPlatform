using Microsoft.AspNetCore.Mvc;
using BloggingPlatform.Models;
using BloggingPlatform.Interfaces;
using BloggingPlatform.Mapper;
using AutoMapper;
using BloggingPlatform.Dto;
using BloggingPlatform.Repository;

namespace BloggingPlatform.Controllers
{
    [Route("api/blogpostcontroller")]
    [ApiController]
    public class BlogPostController : Controller
    {
        private readonly IBlogPostRepository _blogPostrepository; 
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public BlogPostController(IBlogPostRepository blogPostRepository, IMapper mapper, IUserRepository userRepository)
        {
            _blogPostrepository = blogPostRepository; 
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<BlogPost>))]
        public IActionResult GetBlogPosts()
        {
            var posts = _mapper.Map<List<BlogPostDto>>(_blogPostrepository.GetBlogPosts());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(posts);
        }

        [HttpGet("{postId}")]
        [ProducesResponseType(200, Type = typeof(BlogPost))]
        [ProducesResponseType(400)]
        public IActionResult GetBlogPost(int postId)
        {
            if (!_blogPostrepository.BlogPostExists(postId))
                return NotFound();

            var post = _mapper.Map<BlogPostDto>(_blogPostrepository.GetBlogPost(postId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(post);
        }

        [HttpGet("/user/{userId}")]
        [ProducesResponseType(200, Type = typeof(ICollection<BlogPost>))]
        [ProducesResponseType(400)]
        public IActionResult GetBlogPostsByUserId(int userId)
        {
            if (!_userRepository.UserExists(userId))
                return NotFound();

            var posts = _mapper.Map<List<BlogPostDto>>(_blogPostrepository.GetBlogPostsByUserId(userId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(posts);
        }


    }
}
