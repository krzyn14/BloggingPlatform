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
        private readonly IBlogPostRepository _blogPostRepository; 
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public BlogPostController(IBlogPostRepository blogPostRepository, IMapper mapper, IUserRepository userRepository)
        {
            _blogPostRepository = blogPostRepository; 
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<BlogPost>))]
        public IActionResult GetBlogPosts()
        {
            var posts = _mapper.Map<List<BlogPostDto>>(_blogPostRepository.GetBlogPosts());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(posts);
        }

        [HttpGet("{postId}")]
        [ProducesResponseType(200, Type = typeof(BlogPost))]
        [ProducesResponseType(400)]
        public IActionResult GetBlogPost(int postId)
        {
            if (!_blogPostRepository.BlogPostExists(postId))
                return NotFound();

            var post = _mapper.Map<BlogPostDto>(_blogPostRepository.GetBlogPost(postId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(post);
        }

        [HttpGet("userPost/{userId}")]
        [ProducesResponseType(200, Type = typeof(ICollection<BlogPost>))]
        [ProducesResponseType(400)]
        public IActionResult GetBlogPostsByUserId(int userId)
        {
            if (!_userRepository.UserExists(userId))
                return NotFound();

            var posts = _mapper.Map<List<BlogPostDto>>(_blogPostRepository.GetBlogPostsByUserId(userId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(posts);
        }

        [HttpPost("createPost")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateBlogPost([FromBody] BlogPostDto blogPostToCreate)
        {
            if (blogPostToCreate == null || !_userRepository.UserExists(blogPostToCreate.UserId)) 
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var blogPost = _mapper.Map<BlogPost>(blogPostToCreate);

            if(!_blogPostRepository.AddBlogPost(blogPost))
            {
                ModelState.AddModelError("", "Something went wrong, the post wasn't saved");
                return StatusCode(500, ModelState);
            }

            return Ok("Blog Post successfully created!");
        }

        [HttpPut("editBlogPost/{postId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateBlogPost(int postId, [FromBody]BlogPostUpdateDto blogPostUpdated)
        {
            if (blogPostUpdated == null) 
                return BadRequest(ModelState); 

            if (!_userRepository.UserExists(blogPostUpdated.UserId))
                return BadRequest(ModelState);

            if (!_blogPostRepository.BlogPostExists(postId)) 
                return NotFound();

            if (!(_blogPostRepository.GetBlogPost(postId).UserId == blogPostUpdated.UserId))
            {
                ModelState.AddModelError("", "You are not authorized to perform this action");
                return StatusCode(403, ModelState);
            }
                
            if(!ModelState.IsValid) 
                return BadRequest();

            var blogPostMap = _mapper.Map<BlogPost>(blogPostUpdated);

            if(!_blogPostRepository.EditBlogPost(postId, blogPostMap))
            {
                ModelState.AddModelError("", "Something went wrong!"); 
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("deleteBlogPost/{postId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBlogPost(int postId, int userId)
        {
            if (!_userRepository.UserExists(userId))
                return BadRequest(ModelState);

            if (!_blogPostRepository.BlogPostExists(postId))
                return NotFound();

            var blogPostToDelete = _blogPostRepository.GetBlogPost(postId);

            if (!(blogPostToDelete.UserId == userId))
            {
                ModelState.AddModelError("", "You are not authorized to perform this action");
                return StatusCode(403, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_blogPostRepository.RemoveBlogPost(blogPostToDelete))
            {
                ModelState.AddModelError("", "Something went wrong!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
