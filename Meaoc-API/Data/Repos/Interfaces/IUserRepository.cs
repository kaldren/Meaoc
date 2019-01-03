using System.Threading.Tasks;
using Meaoc_API.Data.Models;

namespace Meaoc_API.Data.Repos.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);
        Task<User> GetById(int id);
        Task<User> GetIdByUsername(string username);
        Task<User> Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}