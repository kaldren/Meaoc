using System.ComponentModel.DataAnnotations;

namespace Meaoc_API.Data.Dtos
{
    public class AuthenticateUserDto
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}