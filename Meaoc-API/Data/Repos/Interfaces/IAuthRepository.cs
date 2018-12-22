using System.Threading.Tasks;
using Meaoc_API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meaoc_API.Data.Repos.Interfaces
{
    public interface IAuthRepository
    {
         Task<bool> UserExists(string email);
         Task<bool> EmailExists(string username);
         User Authenticate(string email, string password);
    }
}