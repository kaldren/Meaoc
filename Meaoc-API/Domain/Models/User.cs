using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meaoc_API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [InverseProperty("Author")]
        public List<Message> SentMessages { get; set; }

        [InverseProperty("Recipient")]
        public List<Message> ReceivedMessages { get; set; }

        public User()
        {
            CreatePasswordHashAndSalt();
        }

        private void CreatePasswordHashAndSalt()
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var dict = new Dictionary<byte[], byte[]>();
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("parola123"));
            }
        }
    }
}