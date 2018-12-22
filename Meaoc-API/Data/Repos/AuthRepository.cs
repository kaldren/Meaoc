using System.Linq;
using System.Threading.Tasks;
using Meaoc_API.Data.Models;
using Meaoc_API.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Meaoc_API.Data.Repos
{
    public class AuthRepository : IAuthRepository
    {
        private readonly MeaocContext _context;

        public AuthRepository(MeaocContext context)
        {
            _context = context;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}