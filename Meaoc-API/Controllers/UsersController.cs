using System.Threading.Tasks;
using AutoMapper;
using Meaoc_API.Data.Dtos;
using Meaoc_API.Data.Models;
using Meaoc_API.Data.Repos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meaoc_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;

        public UsersController(
            IUserRepository userRepository,
            IAuthRepository authRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _authRepository = authRepository;
            _mapper = mapper;
        }

        // POST api/values
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
        {
            if (await _authRepository.EmailExists(createUserDto.Email))
            {
                var response = new
                {
                    StatusCode = 400,
                    Error = "Email address is already taken"
                };

                return BadRequest(response);
            }

            if (await _authRepository.UserExists(createUserDto.Username))
            {
                var response = new
                {
                    StatusCode = 400,
                    Error = "Username is already taken"
                };

                return BadRequest(response);
            }

            var userToCreate = _mapper.Map<User>(createUserDto);

            await _userRepository.Create(userToCreate, createUserDto.Password);
            return Ok(createUserDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Error = "Invalid username id"
                });
            }

            // Map to UserDto for security
            var userDto = _mapper.Map<UserDto>(user);

            return Ok(new
            {
                StatusCode = 200,
                Data = userDto
            });
        }
    }
}