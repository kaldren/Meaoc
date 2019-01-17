using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Meaoc_API.Domain.Dtos;
using Meaoc_API.Domain.Models;
using Meaoc_API.Services;
using Meaoc_API.Helpers;
using Meaoc_API.Helpers.ApiResponses;
using Meaoc_API.Helpers.Exceptions;
using Meaoc_API.Helpers.Token;
using Meaoc_API.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Meaoc_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authRepository;
        private readonly IMapper _mapper;
        private readonly ITokenValidator _tokenValidator;
        private readonly AppSettings _appSettings;

        public AuthController(IAuthService authRepository,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            ITokenValidator tokenValidator)
        {
            _authRepository = authRepository;
            _mapper = mapper;
            _tokenValidator = tokenValidator;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginUserDto loginUserDto)
        {
            try
            {
                var loggedInUser = TryLoginUser(loginUserDto);

                return Ok(loggedInUser);
            }
            catch (InvalidLoginCredentialsException)
            {
                return Unauthorized(
                    new BaseApiResponse(HttpStatusCode.Unauthorized, "Invalid authorization credentials",
                        new Dictionary<string, string> {
                            {"Authorization", $"Invalid authorization credentials"},
                        }));
            }

        }

        private UserLoggedInDto TryLoginUser(LoginUserDto loginUserDto)
        {
            var user = _authRepository.Authenticate(loginUserDto.Email, loginUserDto.Password);

            Token token = new TokenGenerator().Generate(user, _appSettings);
            user.Token = token.TokenString;

            return user;
        }

        [AllowAnonymous]
        [HttpPost("validatetoken")]
        public string ValidateExistingToken([FromBody] LocalStorageTokenDto tokenDto)
        {
            try
            {
                _tokenValidator.ValidateExistingUserToken(tokenDto.Token);

                return JsonConvert.SerializeObject(new LocalStorageTokenDto
                {
                    Token = tokenDto.Token,
                    ValidToken = true
                });
            }
            catch (Exception)
            {
                return JsonConvert.SerializeObject(new LocalStorageTokenDto
                {
                    Token = "invalid_token",
                    ValidToken = false
                });
            }
        }
    }
}