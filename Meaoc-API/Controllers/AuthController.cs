using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Meaoc_API.Data.Dtos;
using Meaoc_API.Data.Models;
using Meaoc_API.Data.Repos.Interfaces;
using Meaoc_API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Meaoc_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AuthController(IAuthRepository authRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _authRepository = authRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] AuthenticateUserDto authenticateUserDto)
        {
            var user = _authRepository.Authenticate(authenticateUserDto.Email, authenticateUserDto.Password);


            if (authenticateUserDto == null)
            {
                var errorResponse = new
                {
                    StatusCode = 401,
                    Error = "Invalid credentials"
                };

                return Unauthorized(errorResponse);
            }

            // Map to UserDto for security
            var userDto = _mapper.Map<UserDto>(user);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, userDto.Id.ToString())
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var result = new 
            {
                Id = userDto.Id,
                Username = userDto.Username,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Token = tokenString
            };

            return Ok(result);
        } 
    }
}