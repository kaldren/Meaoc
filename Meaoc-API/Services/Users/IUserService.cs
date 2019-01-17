using System.Collections.Generic;
using System.Threading.Tasks;
using Meaoc_API.Domain.Models;

namespace Meaoc_API.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<User> GetUserById(int id);
        Task<List<User>> GetUsersByTerm(string term);
        Task<User> GetIdByUsername(string username);
        Task<User> Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}