using System.Threading.Tasks;
using AutoMapper;
using Meaoc_API.Data.Dtos;
using Meaoc_API.Data.Models;
using Meaoc_API.Data.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Meaoc_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, 
            IAuthRepository authRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _authRepository = authRepository;
            _mapper = mapper;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDto createUserDto)
        {
            if (await _authRepository.EmailExists(createUserDto.Email))
            {
                return BadRequest("Email address is already taken");
            }

            if (await _authRepository.UserExists(createUserDto.Username))
            {
                return BadRequest("Username is already taken");
            }

            var userToCreate = _mapper.Map<User>(createUserDto);

            await _userRepository.Create(userToCreate, createUserDto.Password);
            return Ok(createUserDto);
        }
    }
}