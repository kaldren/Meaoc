using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Meaoc_API.Data.Dtos;
using Meaoc_API.Data.Models;
using Meaoc_API.Data.Repos.Interfaces;
using Meaoc_API.Helpers.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Meaoc_API.Data.Repos
{
    public class AuthRepository : IAuthRepository
    {
        private readonly MeaocContext _context;
        private readonly IMapper _mapper;

        public AuthRepository(MeaocContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
        public UserLoggedInDto Authenticate(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == email);

            if (user == null)
            {
                throw new InvalidLoginCredentialsException("User with that email doesn't exist");
            }

            if (!VerifyPasswordhash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new InvalidLoginCredentialsException("Verifying the hash failed");
            }

            var loggedInUserDto  = _mapper.Map<UserLoggedInDto>(user);

            return loggedInUserDto;
        }

        private bool VerifyPasswordhash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}