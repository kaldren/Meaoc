using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Meaoc_API.Domain.Dtos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Meaoc_API.Helpers.Token
{
    public class TokenGenerator
    {

        public TokenGenerator()
        {
        }

        public Token Generate(UserLoggedInDto userDto, AppSettings appSettings) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userDto.Id.ToString())
                }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            Token token = new Token();
            token.SecurityToken = tokenHandler.CreateToken(tokenDescriptor);
            token.TokenString = tokenHandler.WriteToken(token.SecurityToken);

            return token;
        }
    }
}