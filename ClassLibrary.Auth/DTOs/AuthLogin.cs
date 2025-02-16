using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Auth.DTOs
{
    public class AuthLogin
    {
        [EmailAddress]
        [MaxLength(100)]
        public required string Email { get; set; } = string.Empty;

        [MinLength(6)]
        [MaxLength(50)]
        public required string Password { get; set; } = string.Empty;
    }
}
