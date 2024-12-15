using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Model
{
    public class LoginDTO
    {
        [Required]
        public string Policy { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
