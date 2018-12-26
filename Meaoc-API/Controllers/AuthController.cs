using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Meaoc_API.Data.Dtos;
using Meaoc_API.Data.Models;
using Meaoc_API.Data.Repos.Interfaces;
using Meaoc_API.Helpers;
using Meaoc_API.Helpers.ApiResponses;
using Meaoc_API.Helpers.Token;
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
        public IActionResult Authenticate([FromBody] LoginUserDto loginUserDto)
        {
            var loggedInUser = TryLoginUserOrNull(loginUserDto);

            if (loggedInUser == null)
            {
                return BadRequest(
                    new BaseApiResponse(HttpStatusCode.Unauthorized,
                        "Invalid authorization credentials",
                        new Dictionary<string, string> {
                            {"Authorization", $"Invalid authorization credentials"},
                        }));

            }

            return Ok(loggedInUser);
        }

        private UserLoggedInDto TryLoginUserOrNull(LoginUserDto loginUserDto)
        {
            var user = _authRepository.Authenticate(loginUserDto.Email, loginUserDto.Password);

            if (user == null)
            {
                return null;
            }

            Token token = new TokenGenerator().Generate(user, _appSettings);
            user.Token = token.TokenString;

            return user;
        }
    }
}