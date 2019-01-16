using System.Collections.Generic;
using System.Threading.Tasks;
using Meaoc_API.Data.Models;

namespace Meaoc_API.Data.Repos.Interfaces
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