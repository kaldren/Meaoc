using System.ComponentModel.DataAnnotations;

namespace Meaoc_API.Domain.Dtos
{
    public class CreateUserDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}