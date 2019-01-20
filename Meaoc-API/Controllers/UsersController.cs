using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Meaoc_API.Domain.Dtos;
using Meaoc_API.Domain.Models;
using Meaoc_API.Services;
using Meaoc_API.Helpers.ApiResponses;
using Meaoc_API.Services.Auth;
using Meaoc_API.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meaoc_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userRepository;
        private readonly IAuthService _authRepository;
        private readonly IMapper _mapper;

        public UsersController(
            IUserService userRepository,
            IAuthService authRepository,
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
                    new BaseApiResponse(HttpStatusCode.BadRequest,"Email address is already taken"));
            }

            if (await _authRepository.UserExists(createUserDto.Username))
            {
                return BadRequest(
                    new BaseApiResponse(HttpStatusCode.BadRequest, "Username is already taken"));
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