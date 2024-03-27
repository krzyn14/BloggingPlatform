using Microsoft.AspNetCore.Mvc;
using BloggingPlatform.Interfaces;
using BloggingPlatform.Models;
using BloggingPlatform.Dto;
using AutoMapper;

namespace BloggingPlatform.Controllers
{
    [Route("api/users")]
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

        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(ICollection<User>))]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            return Ok(users);
        }

        [HttpGet("getUser/{userId}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int userId)
        {
            if(!_userRepository.UserExists(userId)) 
                return NotFound("There is no user with such ID"); 

            var user = _mapper.Map<UserDto>(_userRepository.GetUserById(userId)); 

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }

        [HttpPost("createUser")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserCreateDto userToCreate)
        {
            if(userToCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            if(!_userRepository.IsEmailUnique(userToCreate.Email) || !userToCreate.Email.Contains('@') ) {
                return BadRequest("Wrong email input!"); 
            }

            var user = _mapper.Map<User>(userToCreate);

            if (!_userRepository.CreateUser(user))
            {
                ModelState.AddModelError("", "Something went wrong, the post wasn't saved");
                return StatusCode(500, ModelState);
            }

            return Ok("User successfully created!");
        }

        [HttpDelete("deleteUser")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int userId)
        {
            if(!_userRepository.UserExists(userId))
                return NotFound("There is no user with such ID"); 

            var userToDelete = _userRepository.GetUserById(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userRepository.RemoveUser(userToDelete))
            {
                ModelState.AddModelError("ErrorMessage", "Something went wrong!");
                return StatusCode(500, ModelState);
            }

            return Ok("User successfully removed!");
        }

    }
}
