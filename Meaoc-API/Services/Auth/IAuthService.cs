using System.Threading.Tasks;
using Meaoc_API.Domain.Dtos;
using Meaoc_API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meaoc_API.Services
{
    public interface IAuthService
    {
         Task<bool> UserExists(string email);
         Task<bool> EmailExists(string username);
         UserLoggedInDto Authenticate(string email, string password);
    }
}