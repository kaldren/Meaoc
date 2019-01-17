using System.Threading.Tasks;
using Meaoc_API.Domain.Dtos;

namespace Meaoc_API.Services.Auth
{
    public interface IAuthService
    {
         Task<bool> UserExists(string email);
         Task<bool> EmailExists(string username);
         UserLoggedInDto Authenticate(string email, string password);
    }
}