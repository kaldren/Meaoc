using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Meaoc_API.Helpers.Token
{
    public class TokenValidator : ITokenValidator
    {
        private readonly AppSettings _appSettings;
        public TokenValidator(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public string ValidateExistingUserToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validaitonParameters = GetValidationParameters();

            SecurityToken validateToken;
            IPrincipal principal = tokenHandler.ValidateToken(token, validaitonParameters, out validateToken);

            return token;
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }
    }
}