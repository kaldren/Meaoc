using System.ComponentModel.DataAnnotations;

namespace Meaoc_API.Data.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }
    }
}