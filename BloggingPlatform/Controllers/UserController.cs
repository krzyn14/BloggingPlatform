using Microsoft.AspNetCore.Mvc;
using BloggingPlatform.Interfaces;
using BloggingPlatform.Repository;
using BloggingPlatform.Models;
using BloggingPlatform.Dto;
using AutoMapper;

namespace BloggingPlatform.Controllers
{
    [Route("api/usercontroller")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository; 
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository; 
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<User>))]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            return Ok(users);
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int userId)
        {
            if(!_userRepository.UserExists(userId)) 
                return NotFound(); 

            var user = _mapper.Map<UserDto>(_userRepository.GetUserById(userId)); 

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }
    }
}
