using System.ComponentModel.DataAnnotations;

namespace Meaoc_API.Data.Dtos
{
    public class LoginUserDto
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}