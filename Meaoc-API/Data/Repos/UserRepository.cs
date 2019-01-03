using System;
using System.Linq;
using System.Threading.Tasks;
using Meaoc_API.Data.Repos.Interfaces;
using Meaoc_API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Meaoc_API.Data.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly MeaocContext _context;

        public UserRepository(MeaocContext context)
        {
            _context = context;
        }

        public Task<User> Authenticate(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Create(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public void Update(User user, string password = null)
        {
            throw new System.NotImplementedException();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) 
            {
                throw new ArgumentNullException("Null password");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password should not be null or whitespace");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public Task<User> GetIdByUsername(string username)
        {
            return _context.Users.FirstOrDefaultAsync(p => p.Username == username);
        }
    }
}