using Microsoft.IdentityModel.Tokens;

namespace Meaoc_API.Helpers.Token
{
    public class Token
    {
        public SecurityToken SecurityToken { get; set; }
        public string TokenString { get; set; }
    }
}