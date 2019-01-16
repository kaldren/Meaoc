using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Meaoc_API.Data.Dtos;
using Meaoc_API.Data.Models;
using Meaoc_API.Data.Repos.Interfaces;
using Meaoc_API.Helpers.ApiResponses;
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
                 return BadRequest(
                    new BaseApiResponse(HttpStatusCode.BadRequest, 
                        "Email address is already taken", 
                        new Dictionary<string, string> {
                            {"Email", $"The email address {createUserDto.Email} is already taken"},
                    }));
            }

            if (await _authRepository.UserExists(createUserDto.Username))
            {
                return BadRequest(
                    new BaseApiResponse(HttpStatusCode.BadRequest, 
                        "Username is already taken", 
                        new Dictionary<string, string> {
                            {"Username", $"The username {createUserDto.Username} is already taken"},
                        }));
            }

            var userToCreate = _mapper.Map<User>(createUserDto);

            await _userRepository.Create(userToCreate, createUserDto.Password);
            return Ok(createUserDto);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetIdByUsername(string username) {
            var user = await _userRepository.GetIdByUsername(username);

            return Ok(new {
                userId = user.Id
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersByTerm([FromQuery(Name="term")]string term) {
            var users = await _userRepository.GetUsersByTerm(term);

            return Ok(users);
        }
    }
}