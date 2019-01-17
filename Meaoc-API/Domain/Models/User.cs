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
    }
}