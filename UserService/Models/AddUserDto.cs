using System.ComponentModel.DataAnnotations;

namespace User.Models
{
    public class AddUserDto
    {
        [Required]
        public string Username { get; set; }
    }
}
