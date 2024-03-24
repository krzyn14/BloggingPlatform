using Microsoft.AspNetCore.Mvc;
using BloggingPlatform.Models;
using BloggingPlatform.Interfaces;
using AutoMapper;
using BloggingPlatform.Dto;

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
                return NotFound("There is no such a post");

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
                return NotFound("User not found");

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

            if (!ModelState.IsValid || blogPostToCreate == null)
                return BadRequest("Wrong request, ");

            if (!_userRepository.UserExists(blogPostToCreate.UserId) && blogPostToCreate.UserId != null)
            {
               return NotFound("User not found");
            }

            var blogPost = _mapper.Map<BlogPost>(blogPostToCreate);

            if(!_blogPostRepository.AddBlogPost(blogPost))
            {
                ModelState.AddModelError("ErrorMessage", "Something went wrong, the post wasn't saved");
                return StatusCode(500, ModelState);
            }

            return Ok("Blog Post successfully created!");
        }

        [HttpPut("editBlogPost/{postId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateBlogPost(int postId, [FromBody] BlogPostUpdateDto values)
        {

            if (!_blogPostRepository.BlogPostExists(postId))
                return NotFound("Post not found"); 

            if (!_userRepository.UserExists(values.UserId))
                return NotFound("User not Found");

            if (!(_blogPostRepository.GetBlogPost(postId).UserId == values.UserId))
            {
                //ModelState.AddModelError("Error", "You are not authorized to perform this action");
                return StatusCode(403, "You are not authorized to perform this action");
            }
                
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            if(!_blogPostRepository.EditBlogPost(postId, values.Title, values.Content))
            {
                ModelState.AddModelError("ErrorMessage", "Something went wrong!"); 
                return StatusCode(500, ModelState);
            }

            return Ok("Blog Post successfully updated");
        }

        [HttpDelete("deleteBlogPost/{postId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBlogPost(int postId, int userId)
        {
            if (!_blogPostRepository.BlogPostExists(postId))
                return NotFound();

            if (!_userRepository.UserExists(userId))
                return BadRequest(ModelState);

            var blogPostToDelete = _blogPostRepository.GetBlogPost(postId);

            if (!(blogPostToDelete.UserId == userId))
            {
               // ModelState.AddModelError("Error", "You are not authorized to perform this action");
                return StatusCode(403, "You are not authorized to perform this action");
            }

            if (!ModelState.IsValid)
                return BadRequest();

            if (!_blogPostRepository.RemoveBlogPost(blogPostToDelete))
            {
                ModelState.AddModelError("ErrorMessage", "Something went wrong!");
                return StatusCode(500, ModelState);
            }

            return Ok("Blog Post succesfully updated");
        }

    }
}
