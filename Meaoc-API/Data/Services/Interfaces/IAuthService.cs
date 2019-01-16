using System.Threading.Tasks;
using Meaoc_API.Data.Dtos;
using Meaoc_API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meaoc_API.Data.Repos.Interfaces
{
    public interface IAuthService
    {
         Task<bool> UserExists(string email);
         Task<bool> EmailExists(string username);
         UserLoggedInDto Authenticate(string email, string password);
    }
}