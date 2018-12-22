using System.Threading.Tasks;

namespace Meaoc_API.Data.Repos.Interfaces
{
    public interface IAuthRepository
    {
         Task<bool> UserExists(string email);
         Task<bool> EmailExists(string username);
    }
}